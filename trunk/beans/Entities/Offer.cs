using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace beans
{
    public class Offer : IdentityObject
    {
        #region Variables
        private Village atVillage;
        private ResourcesType offerType;
        private int offerQuantity;
        private ResourcesType forType;
        private int forQuantity;
        private int offerNumber;
        private int maxTransportTime;

        
        #endregion
        

        

        #region Properties

        public virtual int MaxTransportTime
        {
            get { return this.maxTransportTime; }
            set { this.maxTransportTime = value; }
        }

        public virtual ResourcesType OfferType
        {
            get { return offerType; }
            set { offerType = value; }
        }

        public virtual int OfferQuantity
        {
            get { return offerQuantity; }
            set { offerQuantity = value; }
        }

        public virtual ResourcesType ForType
        {
            get { return forType; }
            set { forType = value; }
        }

        public virtual int ForQuantity
        {
            get { return forQuantity; }
            set { forQuantity = value; }
        }

        public virtual int OfferNumber
        {
            get { return offerNumber; }
            set { offerNumber = value; }
        }

        public virtual Village AtVillage
        {
            get { return atVillage; }
            set { atVillage = value; }
        }
        #endregion

        

        #region Constructors
        public Offer()
        {

        }
        #endregion

    }
}
