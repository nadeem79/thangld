using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace beans
{
    internal class TribeRelation:IdentityObject
    {
        public Group CurrentTribe 
        {
            get;
            set;
        }
        public Group DiplomaticTribe
        {
            get;
            set;
        }
        public TribeDiplomate Diplomacy
        {
            get;
            set;
        }
    }
}
