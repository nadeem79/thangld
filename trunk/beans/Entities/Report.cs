using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace beans
{
    public abstract class Report:IdentityObject
    {
        #region Variables
        private DateTime time;
        private User owner;
        private string title;
        private string description;
        private bool unread;
        #endregion

        #region Properties
        public virtual User Owner
        {
            get { return this.owner; }
            set { this.owner = value; }
        }

        public abstract ReportType Type
        {
            get;
        }

        public virtual string Description
        {
            get { return description; }
            set { description = value; }
        }

        public virtual string Title
        {
            get { return title; }
            set { title = value; }
        }

        public virtual DateTime Time
        {
            get { return time; }
            set { time = value; }
        }

        public virtual bool Unread
        {
            get { return unread; }
            set { this.unread = value; }
        }
        #endregion

        #region Constructors
        public Report() { }
        #endregion
    }
}
