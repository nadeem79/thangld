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

        public virtual ResourcesType BoughtType
        {
            get;
            set;
        }

        public virtual ResourcesType SoldType
        {
            get;
            set;
        }

        public virtual int BoughtQuantity
        {
            get;
            set;
        }

        public virtual int SoldQuantity
        {
            get;
            set;
        }
        public virtual Village FromVillage
        {
            get;
            set;
        }
        public virtual Village ToVillage
        {
            get;
            set;
        }

        public virtual Player FromPlayer
        {
            get;
            set;
        }
        public virtual Player ToPlayer
        {
            get;
            set;
        }

    }
}
