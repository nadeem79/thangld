using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace beans
{
    [Flags]
    public enum BuildingType
    {
        NoBuiding = 70000,
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
        Wall,
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
    }
}
