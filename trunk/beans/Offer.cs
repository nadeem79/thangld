using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using System.Data;

namespace beans
{
    public class Offer : IdentityObject
    {

        public virtual double MaxTransportTime
        {
            get;
            set;
        }

        public virtual ResourcesType OfferType
        {
            get;
            set;
        }

        public virtual int OfferQuantity
        {
            get;
            set;
        }

        public virtual ResourcesType ForType
        {
            get;
            set;
        }

        public virtual int ForQuantity
        {
            get;
            set;
        }

        public virtual int OfferNumber
        {
            get;
            set;
        }

        public virtual DateTime CreateTime
        {
            get;
            set;
        }

        public virtual Village AtVillage
        {
            get;
            set;
        }

        public virtual void Save(ISession session)
        {
            int quantity = this.OfferQuantity * this.OfferNumber;
            if (this.AtVillage[this.OfferType] < quantity)
                throw new TribalWarsException("Không đủ tài nguyên");
            int merchant = (int)Math.Ceiling((double)(this.OfferQuantity / 1000)) * this.OfferNumber;
            if (merchant > this.AtVillage.VillageBuildingData.Merchant)
                throw new TribalWarsException("Không đủ thương nhân");

            this.AtVillage[this.OfferType] -= quantity;
            this.AtVillage.VillageBuildingData.Merchant -= merchant;
            this.CreateTime = DateTime.Now;

            this.AtVillage.Offers.Add(this);
            session.Update(this.AtVillage);
        }

        

        public static Offer GetOfferById(int id, ISession session)
        {
            return session.Get<Offer>(id);
        }
    }
}
