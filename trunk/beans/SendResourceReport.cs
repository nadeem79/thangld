using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace beans
{
    public class SendResourceReport : Report
    {

        public int Wood
        {
            get;
            set;
        }
        public int Clay
        {
            get;
            set;
        }
        public int Iron
        {
            get;
            set;
        }

        public Village FromVillage
        {
            get;
            set;
        }
        public Player FromPlayer
        {
            get;
            set;
        }

        public Village ToVillage
        {
            get;
            set;
        }
        public Player ToPlayer
        {
            get;
            set;
        }

        public override ReportType Type
        {
            get { return ReportType.ResourceReceive; }
        }
    }
}
