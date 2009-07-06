using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace beans
{
    public class OfferAcceptedReport : Report
    {

        public override ReportType Type
        {
            get { return ReportType.OfferAccepted; }
        }

        public ResourcesType BoughtType
        {
            get;
            set;
        }

        public ResourcesType SoldType
        {
            get;
            set;
        }

        public int BoughtQuantity
        {
            get;
            set;
        }

        public int SoldQuantity
        {
            get;
            set;
        }

    }
}
