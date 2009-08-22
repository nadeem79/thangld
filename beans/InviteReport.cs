using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace beans
{
    public class InviteReport : Report
    {

        public virtual Player Inviter
        {
            get;
            set;
        }
        public virtual Group Group
        {
            get;
            set;
        }

        public override ReportType Type
        {
            get { return ReportType.InviteToTribe; }
        }
    }
}
