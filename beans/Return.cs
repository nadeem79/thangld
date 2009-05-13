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
        public int Merchant
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
            this.To.Troop.Spear += this.Spear;
            this.To.Troop.Sword += this.Sword;
            this.To.Troop.Axe += this.Axe;
            this.To.Troop.Scout += this.Scout;
            this.To.Troop.Light += this.Light;
            this.To.Troop.Heavy += this.Heavy;
            this.To.Troop.Ram += this.Ram;
            this.To.Troop.Catapult += this.Catapult;
            this.To.Troop.Noble += this.Noble;
            this.To.Resources.Clay += this.Clay;
            this.To.Resources.Wood += this.Wood;
            this.To.Resources.Iron += this.Iron;
        }

        public override void cancel(ISession session)
        {
            throw new Exception("HACK!!!");
        }
        #endregion
    }
}
