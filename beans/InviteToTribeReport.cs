using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace beans
{
    public class InviteToTribeReport:Report
    {


        public override ReportType Type
        {
            get { return ReportType.InviteToTribe; }
        }

        public Group Tribe
        {
            get;
            set;
        }

        public Player Player
        {
            get;
            set;
        }

    }
}
