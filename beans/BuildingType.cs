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
                    break;
                case BuildingType.Barracks:
                    return "Bộ binh";
                    break;
                case BuildingType.Stable:
                    return "Kỵ binh";
                    break;
                case BuildingType.Workshop:
                    return "Nhà xe";
                    break;
                case BuildingType.Academy:
                    return "Trường đại học";
                    break;
                case BuildingType.Smithy:
                    return "Viện nghiên cứu";
                    break;
                case BuildingType.Rally:
                    return "Trại lính";
                    break;
                case BuildingType.Market:
                    return "Chợ";
                    break;
                case BuildingType.TimberCamp:
                    return "Trại gỗ";
                    break;
                case BuildingType.ClayPit:
                    return "Lò gạch";
                    break;
                case BuildingType.IronMine:
                    return "Mỏ kim loại";
                    break;
                case BuildingType.Farm:
                    return "Dân cư";
                    break;
                case BuildingType.Warehouse:
                    return "Nhà kho";
                    break;
                case BuildingType.HidingPlace:
                    return "Kho tàng";
                    break;
                case BuildingType.Wall:
                    return "Tường thành";
                    break;
                default:
                    return "";
                    break;
            }
        }
    }
}
