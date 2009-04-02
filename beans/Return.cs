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
        #endregion

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
        public int Clay
        {
            get;
            set;
        }
        public int Iron
        {
            get;
            set;
        }
        public override MoveType Type
        {
            get { return MoveType.Return; }
        }
        #endregion

        #region Constructors
        public Return()
        {

        }

        #endregion

        #region Methods

        public override void save(ISession session)
        {
            session.Save(this);
        }

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
