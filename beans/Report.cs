using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace beans
{
    public class Report:IdentityObject
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
            get { return ReportType.All; }
        }
        public string Title
        {
            get;
            set;
        }
        public string Description
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
