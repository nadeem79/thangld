using System;
using Antlr.StringTemplate;


namespace beans
{
    public abstract class Report:IdentityObject
    {
        public Player Owner
        {
            get;
            set;
        }
        public DateTime Time
        {
            get;
            set;
        }
        public virtual ReportType Type
        {
            get;
            set;
        }
        public string Title
        {
            get;
            set;
        }
        
        public bool Unread
        {
            get;
            set;
        }

    }
}
