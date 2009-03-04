using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace beans
{
    public class InviteToTribeReport : Report
    {

        #region Properties


        public override ReportType Type
        {
            get { return ReportType.InviteToTribe; }
        }
        #endregion


    }
}
