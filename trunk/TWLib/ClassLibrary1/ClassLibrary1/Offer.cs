using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TWLib
{
    public class Offer
    {
        #region Variables
        private ResourcesType offerType;
        private int offerQuantity;
        private ResourcesType forType;
        private int forQuantity;
        private int offerNumber;

        
        #endregion

        #region Properties
        public ResourcesType OfferType
        {
            get { return offerType; }
            set { offerType = value; }
        }
        
        public int OfferQuantity
        {
            get { return offerQuantity; }
            set { offerQuantity = value; }
        }
        
        public ResourcesType ForType
        {
            get { return forType; }
            set { forType = value; }
        }
        
        public int ForQuantity
        {
            get { return forQuantity; }
            set { forQuantity = value; }
        }

        public int OfferNumber
        {
            get { return offerNumber; }
            set { offerNumber = value; }
        }
        #endregion

        #region Constructors
        public Offer()
        {

        }
        public Offer(int ID)
            : this()
        {

        }
        #endregion

    }
}
