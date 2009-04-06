using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace beans
{
    
    public enum TribeDiplomate
    {
        NoRelation = 0,
        NAP = 1,
        Ally = 2,
        Enemy = 3
    }

    public class TribeDiplomateFactory
    {
        public static TribeDiplomate GetDiplomacy(string type)
        {
            switch (type)
            {
                case "1":
                    return TribeDiplomate.NAP;
                case "2":
                    return TribeDiplomate.Ally;
                case "3":
                    return TribeDiplomate.Enemy;
                default:
                    return TribeDiplomate.NoRelation;
            }
        }
    }
}
