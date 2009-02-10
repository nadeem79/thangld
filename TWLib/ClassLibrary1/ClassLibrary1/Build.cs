using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Beans
{
    public class Build
    {
        #region Variable
        private int id;
        private Village inVillage;
        private DateTime start;
        private BuildingType building;
        #endregion

        #region Properties
        public int ID
        {
            get { return id; }
            set { id = value; }
        }

        public Village InVillage
        {
            get { return inVillage; }
            set { inVillage = value; }
        }
        

        public BuildingType Building
        {
            get { return building; }
            set { building = value; }
        }
        
        public DateTime Start
        {
            get { return start; }
            set { start = value; }
        }
        #endregion

        #region Constructors
        public Build()
        {

        }

        public Build(int ID)
            : this()
        {

        }
        #endregion

    }
}
