using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using NHibernate.Criterion;

namespace beans
{
    public class Support:MovingCommand
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

        public override MoveType Type
        {
            get
            {
                return MoveType.Support;
            }
            set
            {
                if (value != MoveType.Support)
                    throw new ArgumentException("Đây là lệnh support");
            }
        }
        #endregion

        #region Constructors
        public Support()
        {

        }

        public Support(int ID)
            : this()
        {

        }
        #endregion

        #region Methods

        #endregion

        public override void effect(ISession session)
        {
            ICriteria criteria = session.CreateCriteria(typeof(Stationed));

            criteria.Add(Expression.Eq("AtVillage", this.To));
            criteria.Add(Expression.Eq("FromVillage", this.From));
            IList<Stationed> lstStations = criteria.List<Stationed>();

            if (lstStations.Count == 0)
            {
                Stationed newStation = new Stationed();
                newStation.FromVillage = this.From;
                newStation.AtVillage = this.To;
                newStation.Spear = this.Spear;
                newStation.Sword = this.Sword;
                newStation.Axe = this.Axe;
                newStation.Scout = this.Scout;
                newStation.Light = this.Light;
                newStation.Heavy = this.Heavy;
                newStation.Ram = this.Ram;
                newStation.Catapult = this.Catapult;
                newStation.Noble = this.Noble;

                session.Save(newStation);
            }
            else
            {
                Stationed station = lstStations[0];
                station.Spear += this.Spear;
                station.Sword += this.Sword;
                station.Axe += this.Axe;
                station.Scout += this.Scout;
                station.Light += this.Light;
                station.Heavy += this.Heavy;
                station.Ram += this.Ram;
                station.Catapult += this.Catapult;
                station.Noble += this.Noble;
                session.Save(station);
                return;
            }

            SupportReport supportReport = new SupportReport();
            supportReport.Owner = this.To.Owner;
            supportReport.Time = this.LandingTime;
            supportReport.Title = this.From.Owner + " gửi quân hỗ trợ " + this.To.Name + "(" + this.To.X.ToString("0:000") + "|" + this.To.Y.ToString("0:000") + ")";



            session.Save(supportReport);
            supportReport.Owner = this.From.Owner;
            session.Save(supportReport);


        }
    }
}
