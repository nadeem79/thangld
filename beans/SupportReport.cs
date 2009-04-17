using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace beans
{
    public class SupportReport:Report
    {
        #region Variables

        #endregion

        #region Properties

        public ReportType Type
        {
            get { return ReportType.Support; }
        }
        public virtual Village From
        {
            get;
            set;
        }
        public virtual Village To
        {
            get;
            set;
        }
        public virtual int Spear
        {
            get;
            set;
        }
        public virtual int Sword
        {
            get;
            set;
        }
        public virtual int Axe
        {
            get;
            set;
        }
        public virtual int Scout
        {
            get;
            set;
        }
        public virtual int Light
        {
            get;
            set;
        }
        public virtual int Heavy
        {
            get;
            set;
        }
        public virtual int Ram
        {
            get;
            set;
        }
        public virtual int Catapult
        {
            get;
            set;
        }
        public virtual int Noble
        {
            get;
            set;
        }

        #endregion

    }
}
