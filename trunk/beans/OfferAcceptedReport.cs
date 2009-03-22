using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace beans
{
    public class OfferAcceptedReport : Report
    {


        #region Properties


        public override ReportType Type
        {
            get { return ReportType.OfferAccepted; }
        }
        #endregion

    }
}
