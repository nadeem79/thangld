using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace beans
{
    public enum ResearchableStatus
    {
        NotEnoughIron,
        NotEnoughWood,
        NotEnoughClay,
        RequirementNotMet,
        JustDoIt
    }

    public class ResearchableStatusFactory
    {
        public static string ToString(ResearchableStatus status)
        {
            switch (status)
            {
                case ResearchableStatus.NotEnoughWood:
                    return "Không đủ gỗ";
                case ResearchableStatus.NotEnoughClay:
                    return "Không đủ gạch";
                case ResearchableStatus.NotEnoughIron:
                    return "Không đủ kim loại";
                case ResearchableStatus.JustDoIt:
                    return "Nghiên cứu";
                case ResearchableStatus.RequirementNotMet:
                    return "Chưa đủ điều kiện nghiên cứu";
                default:
                    return "";
            }
        }

    }
}
