using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace beans
{
    public abstract class TroopMovingCommand
    {

        #region Properties
        public int Spear
        {
            get;
            set;
        }
        public int Sword
        {
            get;
            set;
        }
        public int Axe
        {
            get;
            set;
        }
        public int Scout
        {
            get;
            set;
        }
        public int Light
        {
            get;
            set;
        }
        public int Heavy
        {
            get;
            set;
        }
        public int Ram
        {
            get;
            set;
        }
        public int Catapult
        {
            get;
            set;
        }
        public int Noble
        {
            get;
            set;
        }
        public int Wood
        {
            get;
            set;
        }
        public int Iron
        {
            get;
            set;
        }
        public int Clay
        {
            get;
            set;
        }
        public abstract MoveType Type
        {
            get;
        }

        #endregion



        public abstract void effect(NHibernate.ISession session);
    }
}
