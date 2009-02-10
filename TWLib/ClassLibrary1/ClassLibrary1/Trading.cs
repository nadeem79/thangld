using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Beans
{
    public class Trading
    {
        #region Variables
        private int id;
        private int wood;
        private int clay;
        private int iron;

        
        private Village fromVillage;
        private Village toVillage;
        private bool hide;

        

        #endregion

        #region Properties
        public int ID
        {
            get { return id; }
            set { id = value; }
        }

        public int Wood
        {
            get { return wood; }
            set { wood = value; }
        }

        public int Clay
        {
            get { return clay; }
            set { clay = value; }
        }

        public int Iron
        {
            get { return iron; }
            set { iron = value; }
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

        public bool Hide
        {
            get { return hide; }
            set { hide = value; }
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
