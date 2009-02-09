using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TWLib
{
    public class Trading
    {
        #region Variables
        private int id;
        private ResourcesType type;
        private int quantity;
        private Village fromVillage;
        private Village toVillage;

        #endregion

        #region Properties
        public int ID
        {
            get { return id; }
            set { id = value; }
        }

        public ResourcesType Type
        {
            get { return type; }
            set { type = value; }
        }

        public int Quantity
        {
            get { return quantity; }
            set { quantity = value; }
        }

        public Village FromVillage
        {
            get { return fromVillage; }
            set { fromVillage = value; }
        }

        public Village ToVillage
        {
            get { return toVillage; }
            set { toVillage = value; }
        }
        #endregion


        #region Constructor
        public Trading()
        {

        }

        public Trading(int ID)
            : this()
        {

        }
        #endregion



    }
}
