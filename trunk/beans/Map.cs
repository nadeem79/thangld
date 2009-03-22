using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace beans
{
    public class Map
    {

        public static double RangeCalculator(int sourceX, int sourceY, int desX, int desY)
        {
            return Math.Sqrt(Math.Pow(sourceX - desX, 2) + Math.Pow(sourceY - desY, 2));
        }

        public static DateTime LandingTime(TroopType troop, int sourceX, int sourceY, int desX, int desY, DateTime start)
        {
            int intMoveTime = 360000;
            switch (troop)
            {
                case TroopType.Axe:
                case TroopType.Spear:
                    intMoveTime = 1080000;
                    break;
                case TroopType.Sword:
                    intMoveTime = 1320000;
                    break;
                case TroopType.Heavy:
                    intMoveTime = 660000;
                    break;
                case TroopType.Light:
                    intMoveTime = 600000;
                    break;
                case TroopType.Scout:
                    intMoveTime = 540000;
                    break;
                case TroopType.Nobleman:
                    intMoveTime = 2100000;
                    break;
                case TroopType.Merchant:
                    intMoveTime = 360000;
                    break;
                case TroopType.Ram:
                case TroopType.Catapult:
                    intMoveTime = 1800000;
                    break;
                default:

                    break;
            }
            return start.AddMilliseconds(RangeCalculator(sourceX, sourceY, desX, desY) * intMoveTime);
        }

    }
}
