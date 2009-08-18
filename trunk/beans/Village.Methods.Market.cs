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
    public partial class Village
    {

        public virtual Offer CreateOffer(ResourcesType offerType, int offerQuantity, ResourcesType forType, int forQuantity, int maxTransportTime, int offerNumber)
        {
            
            if (this[offerType] < offerQuantity * offerNumber)
                throw new TribalWarsException("Không đủ tài nguyên");
            if (Math.Ceiling((double)(offerQuantity * offerNumber / 1000)) > this.VillageBuildingData.Merchant)
                throw new TribalWarsException("Không đủ thương nhân");
            if (offerType==forType)
                throw new TribalWarsException("Nhập loại tài nguyên");


            Offer offer = new Offer();
            offer.AtVillage = this;
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
            

            if (offer.AtVillage == this)
                return null;

            if (offer.OfferNumber > quantity)
                throw new Exception("Vượt quá số lượng rao bán");

            int resourceNeeded = offer.ForQuantity * quantity;
            if (resourceNeeded > this[offer.ForType])
                throw new Exception("Không đủ tài nguyên");

            int merchantNeeded = (int)Math.Ceiling((double)(offer.ForQuantity / 1000)) * quantity;
            if (merchantNeeded > this.VillageBuildingData.Merchant)
                throw new Exception("Không đủ merchant");

            offer.OfferNumber -= quantity;

            SendResource sendToSource = new SendResource();
            sendToSource.FromVillage = this;
            sendToSource.ToVillage = offer.AtVillage;
            sendToSource.StartingTime = DateTime.Now;
            sendToSource.LandingTime = Map.LandingTime(TroopType.Merchant, this, offer.AtVillage, sendToSource.StartingTime);
            sendToSource.Merchant = (int)Math.Ceiling((double)resourceNeeded / 1000);
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
            sendFromSource.FromVillage = this;
            sendFromSource.ToVillage = offer.AtVillage;
            sendFromSource.StartingTime = DateTime.Now;
            sendFromSource.LandingTime = Map.LandingTime(TroopType.Merchant, this, offer.AtVillage, sendFromSource.StartingTime);
            sendFromSource.Merchant = merchantNeeded;
            switch (offer.ForType)
            {
                case ResourcesType.Clay:
                    sendFromSource.Clay = resourceNeeded;
                    break;
                case ResourcesType.Wood:
                    sendFromSource.Wood = resourceNeeded;
                    break;
                case ResourcesType.Iron:
                    sendFromSource.Iron = resourceNeeded;
                    break;
                default:
                    break;
            }

            this[offer.ForType] -= resourceNeeded;
            this.VillageBuildingData.Merchant -= sendToSource.Merchant;
            offer.AtVillage[offer.OfferType] -= resourceNeeded;
            offer.AtVillage.VillageBuildingData.Merchant -= sendFromSource.Merchant;

            ITransaction trans = session.BeginTransaction(IsolationLevel.ReadCommitted);
            session.Save(sendFromSource);
            session.Save(sendToSource);
            session.Update(this.VillageBuildingData);
            session.Update(offer.AtVillage.VillageBuildingData);
            session.Update(this.VillageResourceData);
            session.Update(offer.AtVillage.VillageResourceData);
            if (offer.OfferQuantity == 0)
                session.Delete(offer);
            else
                session.Update(offer);
            trans.Commit();

            return sendToSource;

        }

        public virtual IList<Offer> GetMyOffers(ISession session)
        {
            return (from offer in session.Linq<Offer>()
                    where offer.AtVillage == this
                    select offer).ToList<Offer>();
        }

        public virtual Offer IncreaseOffer(int offerId, int increment, ISession session)
        {

            Offer offer = Offer.GetOfferById(offerId, session);
            if (offer == null || offer.AtVillage != this)
                throw new TribalWarsException("Offer không tồn tại");


            int quantity = offer.OfferQuantity * increment;
            if (this[offer.OfferType] < quantity)
                throw new TribalWarsException("Không đủ tài nguyên");
            int merchant = (int)Math.Ceiling((double)(offer.OfferQuantity / 1000)) * increment;
            if (merchant > this.VillageBuildingData.Merchant)
                throw new TribalWarsException("Không đủ thương nhân");

            offer.OfferNumber += increment;
            this[offer.OfferType] -= quantity;
            this.VillageBuildingData.Merchant -= merchant;

            ITransaction trans = session.BeginTransaction(IsolationLevel.ReadUncommitted);
            session.Update(offer);
            session.Update(this.VillageBuildingData);
            session.Update(this.VillageResourceData);
            trans.Commit();

            return offer;
        }

        public virtual Offer DecreaseOffer(int offerId, int decrease, ISession session)
        {
            Offer offer = Offer.GetOfferById(offerId, session);
            if (offer == null || offer.AtVillage != this)
                throw new TribalWarsException("Offer không tồn tại");

            if (decrease > offer.OfferNumber)
                decrease = offer.OfferNumber;

            int quantity = offer.OfferQuantity * decrease;
            int merchant = (int)Math.Ceiling((double)(offer.OfferQuantity / 1000)) * decrease;

            offer.OfferNumber -= decrease;
            this[offer.OfferType] += quantity;
            this.VillageBuildingData.Merchant += merchant;

            ITransaction trans = session.BeginTransaction(IsolationLevel.ReadUncommitted);
            if (offer.OfferNumber > 0)
                session.Update(offer);
            else
                session.Delete(offer);
            session.Update(this.VillageBuildingData);
            session.Update(this.VillageResourceData);
            trans.Commit();

            return offer;
        }

        public virtual void DeleteOffer(int offerId, ISession session)
        {
            Offer offer = Offer.GetOfferById(offerId, session);
            if (offer == null || offer.AtVillage != this)
                throw new TribalWarsException("Offer không tồn tại");

            int quantity = offer.OfferQuantity * offer.OfferNumber;
            int merchant = (int)Math.Ceiling((double)(offer.OfferQuantity / 1000)) * offer.OfferNumber;

            this[offer.OfferType] += quantity;
            this.VillageBuildingData.Merchant += merchant;

            ITransaction trans = session.BeginTransaction(IsolationLevel.ReadUncommitted);
            session.Delete(offer);
            session.Update(this.VillageBuildingData);
            session.Update(this.VillageResourceData);
            trans.Commit();
        }
    }
}
