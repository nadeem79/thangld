using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace beans
{
    public class Offer : IdentityObject
    {
        #region Variables



        #endregion




        #region Properties

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

        public virtual Village AtVillage
        {
            get;
            set;
        }
        #endregion

        

        #region Constructors
        public Offer()
        {

        }
        #endregion

    }
}
