using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;

namespace beans
{
    public class Return:MovingCommand
    {
        #region Variables

        private int scoutSent;
        private int spearSent;
        private int swordSent;
        private int axeSent;
        private int lightSent;
        private int heavySent;
        private int ramSent;
        private int catapultSent;
        private int nobleSent;
        private int wood;
        private int clay;
        private int iron;
        private MoveType type;
        
        #endregion

        #region Properties

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

        public virtual int Iron
        {
            get { return iron; }
            set { iron = value; }
        }

        public virtual int Clay
        {
            get { return clay; }
            set { clay = value; }
        }

        public virtual int Wood
        {
            get { return wood; }
            set { wood = value; }
        }

        public override MoveType Type
        {
            get
            {
                return MoveType.Return;
            }
            set
            {
                if (value != MoveType.Return)
                    throw new ArgumentException("Đây là lệnh rút quân");
            }
        }
        #endregion

        #region Constructors
        public Return()
        {

        }

        #endregion

        #region Methods

        public override void effect(ISession session)
        {
            this.To.Spear += this.Spear;
            this.To.Sword += this.Sword;
            this.To.Axe += this.Axe;
            this.To.Scout += this.Scout;
            this.To.Light += this.Light;
            this.To.Heavy += this.Heavy;
            this.To.Ram += this.Ram;
            this.To.Catapult += this.Catapult;
            this.To.Noble += this.Noble;
            this.To.Clay += this.Clay;
            this.To.Wood += this.Wood;
            this.To.Iron += this.Iron;
        }

        #endregion
    }
}
