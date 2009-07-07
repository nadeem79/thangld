using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace beans
{
    public enum BuildingType
    {
        NoBuiding = 0,
        Headquarter,
        Barracks,
        Stable,
        Workshop,
        Academy,
        Smithy,
        Rally,
        Market,
        TimberCamp,
        ClayPit,
        IronMine,
        Farm,
        Warehouse,
        HidingPlace,
        Wall
    }

    public class BuildingTypeFactory
    {
        public static BuildingType GetType(string code)
        {
            int key = 0;
            int.TryParse(code, out key);
            try
            {
                return (BuildingType)key;
            }
            catch
            {
                return BuildingType.NoBuiding;
            }
        }

        public static string ToString(BuildingType type)
        {
            switch (type)
            {
                case BuildingType.Headquarter:
                    return "Nhà chính";
                case BuildingType.Barracks:
                    return "Bộ binh";
                case BuildingType.Stable:
                    return "Kỵ binh";
                case BuildingType.Workshop:
                    return "Nhà xe";
                case BuildingType.Academy:
                    return "Trường đại học";
                case BuildingType.Smithy:
                    return "Viện nghiên cứu";
                case BuildingType.Rally:
                    return "Trại lính";
                case BuildingType.Market:
                    return "Chợ";
                case BuildingType.TimberCamp:
                    return "Trại gỗ";
                case BuildingType.ClayPit:
                    return "Lò gạch";
                case BuildingType.IronMine:
                    return "Mỏ kim loại";
                case BuildingType.Farm:
                    return "Dân cư";
                case BuildingType.Warehouse:
                    return "Nhà kho";
                case BuildingType.HidingPlace:
                    return "Kho tàng";
                case BuildingType.Wall:
                    return "Tường thành";
                default:
                    return "";
            }
        }
    }
}
