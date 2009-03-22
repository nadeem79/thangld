using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace beans
{
    public abstract class Report:IdentityObject
    {
        #region Variables
        #endregion

        #region Properties
        public virtual Player Owner
        {
            get;
            set;
        }

        public abstract ReportType Type
        {
            get;
        }

        public virtual string Description
        {
            get;
            set;
        }

        public virtual string Title
        {
            get;
            set;
        }

        public virtual DateTime Time
        {
            get;
            set;
        }

        public virtual bool Unread
        {
            get;
            set;
        }
        #endregion

        #region Constructors
        #endregion
    }
}
