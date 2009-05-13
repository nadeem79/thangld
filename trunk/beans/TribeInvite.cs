using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace beans
{
    public class TribeInvite:IdentityObject
    {
        public Player Inviter
        {
            get; set;
        }
        public Player Player
        {
            get;
            set;
        }
        public Group Group
        {
            get;
            set;
        }
        public DateTime Time
        {
            get;
            set;
        }
    }
}
