using System;


namespace beans
{
    public abstract class Report:IdentityObject
    {
        public virtual Player Owner
        {
            get;
            set;
        }
        public virtual DateTime Time
        {
            get;
            set;
        }
        public abstract ReportType Type
        {
            get;
        }
        public virtual string Title
        {
            get;
            set;
        }

        public virtual bool Unread
        {
            get;
            set;
        }

    }
}
