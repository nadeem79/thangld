using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace beans
{
    public class Recruit : IdentityObject
    {
        #region Variable
        private Village inVillage;
        private DateTime start;
        private DateTime end;
        private TroopType troop;
        
        #endregion

        #region Properties

        public virtual Village InVillage
        {
            get { return inVillage; }
            set { inVillage = value; }
        }


        public virtual TroopType Troop
        {
            get { return troop; }
            set { troop = value; }
        }

        public virtual DateTime Start
        {
            get { return start; }
            set { start = value; }
        }

        public virtual DateTime End
        {
            get { return end; }
            set { end = value; }
        }
        private int quantity;

        public virtual int Quantity
        {
            get { return quantity; }
            set { quantity = value; }
        }
        #endregion

        #region Constructors
        public Recruit()
        {

        }
        #endregion
    }
}
