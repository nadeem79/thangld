using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace beans
{
    public class Build
    {
        #region Variable
        private int id;
        private Village inVillage;
        private DateTime start, end;
        private BuildingType building;
        #endregion

        #region Properties
        public virtual int ID
        {
            get { return id; }
            set { id = value; }
        }

        public virtual Village InVillage
        {
            get { return inVillage; }
            set { inVillage = value; }
        }


        public virtual BuildingType Building
        {
            get { return building; }
            set { building = value; }
        }

        public virtual DateTime Start
        {
            get { return start; }
            set { start = value; }
        }

        public virtual DateTime End
        {
            get { return this.end; }
            set { this.end = value; }
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
