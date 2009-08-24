using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using NHibernate.Linq;
using NHibernate.Criterion;
using System.Diagnostics;
using System.Data;

namespace beans
{
    public class VillageMarketMethods
    {

        public Village Village
        {
            get;
            set;
        }

        public virtual Offer CreateOffer(ResourcesType offerType, int offerQuantity, ResourcesType forType, int forQuantity, int maxTransportTime, int offerNumber)
        {
            
            if (this.Village[offerType] < offerQuantity * offerNumber)
                throw new TribalWarsException("Không đủ tài nguyên");
            if (Math.Ceiling((double)(offerQuantity * offerNumber / 1000)) > this.Village.VillageBuildingData.Merchant)
                throw new TribalWarsException("Không đủ thương nhân");
            if (offerType==forType)
                throw new TribalWarsException("Nhập loại tài nguyên");


            Offer offer = new Offer();
            offer.AtVillage = this.Village;
            offer.ForQuantity = forQuantity;
            offer.ForType = forType;
            offer.MaxTransportTime = maxTransportTime;
            offer.OfferNumber = offerNumber;
            offer.OfferQuantity = offerQuantity;
            offer.OfferType = offerType;

            return offer;
        }

        public virtual SendResource AcceptOffer(int offerId, int quantity, ISession session)
        {
            Offer offer = null;
            try
            {
                offer = session.Load<Offer>(offerId);
            }
            catch
            {
                throw new Exception("Offer không tồn tại");
            }


            if (offer.AtVillage == this.Village)
                return null;

            

            int resourceNeeded = offer.ForQuantity * quantity;
            if (resourceNeeded > this.Village[offer.ForType])
                throw new Exception("Không đủ tài nguyên");

            int merchantNeeded = (int)Math.Ceiling((double)resourceNeeded / 1000);
            if (merchantNeeded > this.Village.VillageBuildingData.Merchant)
                throw new Exception("Không đủ merchant");

            if (offer.OfferNumber < quantity)
                quantity = offer.OfferNumber;

            offer.OfferNumber -= quantity;

            SendResource sendToSource = new SendResource();
            sendToSource.FromVillage = this.Village;
            sendToSource.ToVillage = offer.AtVillage;
            sendToSource.StartingTime = DateTime.Now;
            sendToSource.LandingTime = Map.LandingTime(TroopType.Merchant, this.Village, offer.AtVillage, sendToSource.StartingTime);
            sendToSource.Merchant = merchantNeeded;
            switch (offer.ForType)
            {
                case ResourcesType.Clay:
                    sendToSource.Clay = resourceNeeded;
                    break;
                case ResourcesType.Wood:
                    sendToSource.Wood = resourceNeeded;
                    break;
                case ResourcesType.Iron:
                    sendToSource.Iron = resourceNeeded;
                    break;
                default:
                    break;
            }
            SendResource sendFromSource = new SendResource();
            sendFromSource.FromVillage = offer.AtVillage;
            sendFromSource.ToVillage = this.Village;
            sendFromSource.StartingTime = DateTime.Now;
            sendFromSource.LandingTime = Map.LandingTime(TroopType.Merchant, this.Village, offer.AtVillage, sendFromSource.StartingTime);
            sendFromSource.Merchant = (int)Math.Ceiling((double)offer.OfferQuantity / 1000) * quantity;
            switch (offer.OfferType)
            {
                case ResourcesType.Clay:
                    sendFromSource.Clay = offer.OfferQuantity * quantity;
                    break;
                case ResourcesType.Wood:
                    sendFromSource.Wood = offer.OfferQuantity * quantity;
                    break;
                case ResourcesType.Iron:
                    sendFromSource.Iron = offer.OfferQuantity * quantity;
                    break;
                default:
                    break;
            }

            this.Village[offer.ForType] -= resourceNeeded;
            this.Village.VillageBuildingData.Merchant -= sendToSource.Merchant;
            offer.AtVillage[offer.OfferType] -= resourceNeeded;
            offer.AtVillage.VillageBuildingData.Merchant -= sendFromSource.Merchant;

            OfferAcceptedReport report = new OfferAcceptedReport();
            report.BoughtQuantity = offer.ForQuantity * quantity;
            report.BoughtType = offer.ForType;
            report.SoldQuantity = offer.OfferQuantity * quantity;
            report.SoldType = offer.OfferType;
            report.FromVillage = offer.AtVillage;
            report.FromPlayer = offer.AtVillage.Player;
            report.ToVillage = this.Village;
            report.ToPlayer = this.Village.Player;
            report.Owner = offer.AtVillage.Player;
            report.Time = DateTime.Now;
            report.Unread = true;
            report.Title = string.Format("{0} mua tài nguyên ở {1} ({2}|{3}", this.Village.Player.Username, offer.AtVillage.Name, offer.AtVillage.X.ToString("000"), offer.AtVillage.Y.ToString("000"));

            session.Save(sendFromSource);
            session.Save(sendToSource);
            session.Update(this.Village.VillageBuildingData);
            session.Update(offer.AtVillage.VillageBuildingData);
            session.Update(this.Village.VillageResourceData);
            session.Update(offer.AtVillage.VillageResourceData);
            if (offer.OfferNumber == 0)
                session.Delete(offer);
            else
                session.Update(offer);
            session.Save(report);

            return sendToSource;

        }

        public virtual IList<Offer> GetMyOffers(ISession session)
        {
            return (from offer in session.Linq<Offer>()
                    where offer.AtVillage == this.Village
                    select offer).ToList<Offer>();
        }

        public virtual Offer IncreaseOffer(int offerId, int increment, ISession session)
        {

            Offer offer = Offer.GetOfferById(offerId, session);
            if (offer == null || offer.AtVillage != this.Village)
                throw new TribalWarsException("Offer không tồn tại");


            int quantity = offer.OfferQuantity * increment;
            if (this.Village[offer.OfferType] < quantity)
                throw new TribalWarsException("Không đủ tài nguyên");
            int merchant = (int)Math.Ceiling((double)(offer.OfferQuantity / 1000)) * increment;
            if (merchant > this.Village.VillageBuildingData.Merchant)
                throw new TribalWarsException("Không đủ thương nhân");

            offer.OfferNumber += increment;
            this.Village[offer.OfferType] -= quantity;
            this.Village.VillageBuildingData.Merchant -= merchant;

            session.Update(offer);
            session.Update(this.Village.VillageBuildingData);
            session.Update(this.Village.VillageResourceData);

            return offer;
        }

        public virtual Offer DecreaseOffer(int offerId, int decrease, ISession session)
        {
            Offer offer = Offer.GetOfferById(offerId, session);
            if (offer == null || offer.AtVillage != this.Village)
                throw new TribalWarsException("Offer không tồn tại");

            if (decrease > offer.OfferNumber)
                decrease = offer.OfferNumber;

            int quantity = offer.OfferQuantity * decrease;
            int merchant = (int)Math.Ceiling((double)(offer.OfferQuantity / 1000)) * decrease;

            offer.OfferNumber -= decrease;
            this.Village[offer.OfferType] += quantity;
            this.Village.VillageBuildingData.Merchant += merchant;

            if (offer.OfferNumber > 0)
                session.Update(offer);
            else
                session.Delete(offer);
            session.Update(this.Village.VillageBuildingData);
            session.Update(this.Village.VillageResourceData);

            return offer;
        }

        public virtual void DeleteOffer(int offerId, ISession session)
        {
            Offer offer = Offer.GetOfferById(offerId, session);
            if (offer == null || offer.AtVillage != this.Village)
                throw new TribalWarsException("Offer không tồn tại");

            int quantity = offer.OfferQuantity * offer.OfferNumber;
            int merchant = (int)Math.Ceiling((double)(offer.OfferQuantity / 1000)) * offer.OfferNumber;

            this.Village[offer.OfferType] += quantity;
            this.Village.VillageBuildingData.Merchant += merchant;

            session.Delete(offer);
            session.Update(this.Village.VillageBuildingData);
            session.Update(this.Village.VillageResourceData);
        }

        public virtual IList<Offer> GetOffers(ResourcesType forType, ResourcesType offerType, double maxDuration, double maxRatio, string orderby, ISession session)
        {
            var query = (from offer in session.Linq<Offer>()
                         where offer.AtVillage != this.Village
                         select offer);

            if (forType != ResourcesType.Any)
                query = query.Where<Offer>(offer => offer.ForType == forType);
            if (offerType != ResourcesType.Any)
                query = query.Where<Offer>(offer => offer.OfferType == offerType);
            if (maxDuration >0)
                query = query.Where<Offer>(offer => offer.MaxTransportTime <= maxDuration && Map.RangeCalculator(this.Village.X, this.Village.Y, offer.AtVillage.X, offer.AtVillage.Y) <= maxDuration);
            if (maxRatio > 0)
                query = query.Where<Offer>(offer => offer.OfferQuantity / offer.ForQuantity <= maxRatio);

            if (orderby == "Duration")
                query = query.OrderBy(offer => Map.RangeCalculator(this.Village.X, this.Village.Y, offer.AtVillage.X, offer.AtVillage.Y));
            else if (orderby == "Ration")
                query = query.OrderBy(offer => offer.OfferQuantity / offer.ForQuantity);

            return query.ToList<Offer>();
        }
    }
}
