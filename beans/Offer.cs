﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using System.Data;

namespace beans
{
    public class Offer : IdentityObject
    {

        public virtual int MaxTransportTime
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
                throw new Exception("Không đủ tài nguyên");
            int merchant = (int)Math.Ceiling((double)(this.OfferQuantity / 1000)) * this.OfferNumber;
            if (merchant > this.AtVillage.VillageBuildingData.Merchant)
                throw new Exception("Không đủ thương nhân");

            this.AtVillage[this.OfferType] -= quantity;
            this.AtVillage.VillageBuildingData.Merchant -= merchant;
            this.CreateTime = DateTime.Now;

            ITransaction trans = session.BeginTransaction(IsolationLevel.ReadUncommitted);
            session.Save(this);
            session.Update(this.AtVillage.VillageBuildingData);
            session.Update(this.AtVillage.VillageResourceData);
            trans.Commit();
        }

        public virtual Offer IncreaseOffer(int increment, ISession session)
        {
            int quantity = this.OfferQuantity * increment;
            if (this.AtVillage[this.OfferType] < quantity)
                throw new Exception("Không đủ tài nguyên");
            int merchant = (int)Math.Ceiling((double)(this.OfferQuantity / 1000)) * quantity;
            if (merchant > this.AtVillage.VillageBuildingData.Merchant)
                throw new Exception("Không đủ thương nhân");

            this.OfferNumber += increment;
            this.AtVillage[this.OfferType] -= quantity;
            this.AtVillage.VillageBuildingData.Merchant -= merchant;

            ITransaction trans = session.BeginTransaction(IsolationLevel.ReadUncommitted);
            session.Update(this);
            session.Update(this.AtVillage.VillageBuildingData);
            session.Update(this.AtVillage.VillageResourceData);
            trans.Commit();

            return this;
        }

        public virtual Offer DecreaseOffer(int increment, ISession session)
        {
            int quantity = this.OfferQuantity * increment;
            int merchant = (int)Math.Ceiling((double)(this.OfferQuantity / 1000)) * increment;

            this.OfferNumber -= increment;
            this.AtVillage[this.OfferType] += quantity;
            this.AtVillage.VillageBuildingData.Merchant += merchant;

            ITransaction trans = session.BeginTransaction(IsolationLevel.ReadUncommitted);
            session.Update(this);
            session.Update(this.AtVillage.VillageBuildingData);
            session.Update(this.AtVillage.VillageResourceData);
            trans.Commit();

            return this;
        }

        



    }
}
