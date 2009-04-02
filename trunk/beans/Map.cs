using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using NHibernate.Criterion;

namespace beans
{
    public class Map
    {

        public static double RangeCalculator(int sourceX, int sourceY, int desX, int desY)
        {
            return Math.Sqrt(Math.Pow(sourceX - desX, 2) + Math.Pow(sourceY - desY, 2));
        }

        public static DateTime LandingTime (TroopType troop, int sourceX, int sourceY, int desX, int desY, DateTime start)
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
        public static DateTime LandingTime(TroopType troop, Village from, Village to, DateTime start)
        {
            return Map.LandingTime(troop, from.X, from.Y, to.X, to.Y, start);
        }
        
        public static IList<Village> GetMap(Village center, ISession session)
        {
            ICriteria criteria = session.CreateCriteria(typeof(Village));

            criteria.Add(Expression.Le("X", center.X + 7));
            criteria.Add(Expression.Ge("X", center.X - 7));
            criteria.Add(Expression.Le("Y", center.Y + 7));
            criteria.Add(Expression.Ge("Y", center.Y - 7));
            criteria.AddOrder(Order.Desc("X"));
            criteria.AddOrder(Order.Desc("Y"));

            return criteria.List<Village>();
        }

        public static IList<Village> GetMap(int x, int y, ISession session)
        {
            ICriteria criteria = session.CreateCriteria(typeof(Village));
            criteria.Add(Expression.Le("X", x + 7));
            criteria.Add(Expression.Ge("X", x - 7));
            criteria.Add(Expression.Le("Y", y + 7));
            criteria.Add(Expression.Ge("Y", y - 7));
            criteria.AddOrder(Order.Desc("X"));
            criteria.AddOrder(Order.Desc("Y"));

            return criteria.List<Village>();
        } 

    }
}
