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
        public abstract ReportType Type
        {
            get;
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
