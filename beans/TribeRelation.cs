using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace beans
{
    internal class TribeRelation:IdentityObject
    {
        public virtual Group CurrentTribe 
        {
            get;
            set;
        }
        public virtual Group DiplomaticTribe
        {
            get;
            set;
        }
        public virtual TribeDiplomate Diplomacy
        {
            get;
            set;
        }
    }
}
