using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace beans
{
    public enum ReportType
    {
        All = 0,
        Attack = 1,
        Defense = 2,
        DefenseOther = 3,
        ResourceReceive = 4,
        OfferAccepted = 5,
        Support = 6,
        SupportWithdawal = 7,
        InviteToTribe = 8
    }

    public class ReportTypeFactory
    {
        public static ReportType GetReportType(int type)
        {
            switch (type)
            {
                case 1:
                    return ReportType.Attack;
                case 2:
                    return ReportType.Defense;
                case 3:
                    return ReportType.DefenseOther;
                case 4:
                    return ReportType.ResourceReceive;
                case 5:
                    return ReportType.OfferAccepted;
                case 6:
                    return ReportType.Support;
                case 7:
                    return ReportType.SupportWithdawal;
                case 8:
                    return ReportType.InviteToTribe;
                default:
                    return ReportType.All;
            }
        }
    }
}
