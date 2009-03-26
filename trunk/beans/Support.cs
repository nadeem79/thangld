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
        public override MoveType Type
        {
            get { return MoveType.Support; }
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

        #region Static Members
        public static Support CreateSupport(ISession session,
                                            Village from,
                                            int x,
                                            int y,
                                            int spear,
                                            int sword,
                                            int axe,
                                            int scout,
                                            int light,
                                            int heavy,
                                            int ram,
                                            int catapult,
                                            int noble)
        {
            if (x == from.X && y == from.Y)
                throw new Exception("Nhập toạ độ");

            int intTo = Village.CheckVillage(x, y, session);

            if (intTo < 0)
                throw new Exception("Toạ độ không tồn tại");

            if ((spear + sword + axe + scout + light + heavy + ram + catapult + noble) == 0)
                throw new Exception("Nhập một loại quân");

            if ((spear > from.Spear) ||
            (sword > from.Sword) ||
            (axe > from.Axe) ||
            (scout > from.Scout) ||
            (light > from.Light) ||
            (heavy > from.Heavy) ||
            (ram > from.Ram) ||
            (catapult > from.Catapult) ||
            (noble > from.Noble))
                throw new Exception("Không đủ quân");

            Support support = new Support();
            support.From = from;
            support.StartTime = DateTime.Now;
            support.To = session.Load<Village>(intTo);
            support.Spear = spear;
            support.Sword = sword;
            support.Axe = axe;
            support.Scout = scout;
            support.Light = light;
            support.Heavy = heavy;
            support.Ram = ram;
            support.Catapult = catapult;
            support.Noble = noble;

            TroopType type = TroopType.Spear;
            if (scout > 0)
                type = TroopType.Scout;
            if (light > 0)
                type = TroopType.Light;
            if (heavy > 0)
                type = TroopType.Heavy;
            if (spear > 0)
                type = TroopType.Spear;
            if (axe > 0)
                type = TroopType.Axe;
            if (sword > 0)
                type = TroopType.Sword;
            if (ram > 0)
                type = TroopType.Ram;
            if (catapult > 0)
                type = TroopType.Catapult;
            if (noble > 0)
                type = TroopType.Nobleman;
            support.LandingTime = Map.LandingTime(type, support.From.X, support.From.Y, support.To.X, support.To.Y, support.StartTime);

            from.Spear -= spear;
            from.Sword -= sword;
            from.Axe -= axe;
            from.Scout -= scout;
            from.Light -= light;
            from.Heavy -= heavy;
            from.Ram -= ram;
            from.Catapult -= catapult;
            from.Noble -= noble;

            session.Save(support);
            session.Update(from);
            return support;
        }
        #endregion

        #region Methods
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
            supportReport.Title = this.From.Owner + " gửi quân hỗ trợ " + this.To.Name + "(" + this.To.X.ToString("000") + "|" + this.To.Y.ToString("000") + ")";
            supportReport.From = this.From;
            supportReport.To = this.To;
            supportReport.Spear = this.Spear;
            supportReport.Sword = this.Sword;
            supportReport.Axe = this.Axe;
            supportReport.Scout = this.Scout;
            supportReport.Light = this.Light;
            supportReport.Heavy = this.Heavy;
            supportReport.Ram = this.Ram;
            supportReport.Catapult = this.Catapult;
            supportReport.Noble = this.Noble;

            session.Save(supportReport);
            supportReport.Owner = this.From.Owner;
            session.Save(supportReport);


        }    
        #endregion

        
    }
}
