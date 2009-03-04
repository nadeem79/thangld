using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace beans
{
    public class Stationed : IdentityObject
    {
        #region Variables
        private Village atVillage, fromVillage;

        private int scoutSent;
        private int spearSent;
        private int swordSent;
        private int axeSent;
        private int lightSent;
        private int heavySent;
        private int ramSent;
        private int catapultSent;
        private int nobleSent;
        
        #endregion

        #region Properties

        public virtual Village FromVillage
        {
            get { return fromVillage; }
            set { fromVillage = value; }
        }

        public virtual Village AtVillage
        {
            get { return atVillage; }
            set { atVillage = value; }
        }

        public virtual int Spear
        {
            get { return spearSent; }
            set { spearSent = value; }
        }

        public virtual int Sword
        {
            get { return swordSent; }
            set { swordSent = value; }
        }

        public virtual int Axe
        {
            get { return axeSent; }
            set { axeSent = value; }
        }

        public virtual int Scout
        {
            get { return scoutSent; }
            set { scoutSent = value; }
        }

        public virtual int Light
        {
            get { return lightSent; }
            set { lightSent = value; }
        }

        public virtual int Heavy
        {
            get { return heavySent; }
            set { heavySent = value; }
        }

        public virtual int Ram
        {
            get { return ramSent; }
            set { ramSent = value; }
        }

        public virtual int Catapult
        {
            get { return catapultSent; }
            set { catapultSent = value; }
        }

        public virtual int Noble
        {
            get { return nobleSent; }
            set { nobleSent = value; }
        }

        #endregion

        #region Constructors
        public Stationed()
        {

        }

        #endregion
    }
}
