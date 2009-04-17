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

            if ((spear > from.Troop.Spear) ||
            (sword > from.Troop.Sword) ||
            (axe > from.Troop.Axe) ||
            (scout > from.Troop.Scout) ||
            (light > from.Troop.Light) ||
            (heavy > from.Troop.Heavy) ||
            (ram > from.Troop.Ram) ||
            (catapult > from.Troop.Catapult) ||
            (noble > from.Troop.Noble))
                throw new Exception("Không đủ quân");

            Support support = new Support();
            support.To = session.Load<Village>(intTo);
            support.From = from;
            

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

            support.Spear = spear;
            support.Sword = sword;
            support.Axe = axe;
            support.Scout = scout;
            support.Light = light;
            support.Heavy = heavy;
            support.Ram = ram;
            support.Catapult = catapult;
            support.Noble = noble;
            support.StartTime = DateTime.Now;
            support.LandingTime = Map.LandingTime(type, support.From.X, support.From.Y, support.To.X, support.To.Y, support.StartTime);
            support.Pending = true;

            session.Save(support);

            return support;
        }
        #endregion

        #region Methods

        public void execute(ISession session)
        {
            if ((this.Spear > this.From.Troop.Spear) ||
            (this.Sword > this.From.Troop.Sword) ||
            (this.Axe > this.From.Troop.Axe) ||
            (this.Scout > this.From.Troop.Scout) ||
            (this.Light > this.From.Troop.Light) ||
            (this.Heavy > this.From.Troop.Heavy) ||
            (this.Ram > this.From.Troop.Ram) ||
            (this.Catapult > this.From.Troop.Catapult) ||
            (this.Noble > this.From.Troop.Noble))
                throw new Exception("Không đủ quân");

            TimeSpan transitTime = this.LandingTime - this.StartTime;
            this.StartTime = DateTime.Now;
            this.LandingTime = this.StartTime + transitTime;
            this.Pending = false;

            this.From.Troop.Spear -= this.Spear;
            this.From.Troop.Sword -= this.Sword;
            this.From.Troop.Axe -= this.Axe;
            this.From.Troop.Scout -= this.Scout;
            this.From.Troop.Light -= this.Light;
            this.From.Troop.Heavy -= this.Heavy;
            this.From.Troop.Ram -= this.Ram;
            this.From.Troop.Catapult -= this.Catapult;
            this.From.Troop.Noble -= this.Noble;

            this.From.Troop.TotalSpear -= this.Spear;
            this.From.Troop.TotalSword -= this.Sword;
            this.From.Troop.TotalAxe -= this.Axe;
            this.From.Troop.TotalScout -= this.Scout;
            this.From.Troop.TotalLight -= this.Light;
            this.From.Troop.TotalHeavy -= this.Heavy;
            this.From.Troop.TotalRam -= this.Ram;
            this.From.Troop.TotalCatapult -= this.Catapult;
            this.From.Troop.TotalNoble -= this.Noble;

            session.Update(this);
            session.Update(this.From);
        }

        public override void save(ISession session)
        {
            if ((this.Spear > this.From.Troop.Spear) ||
            (this.Sword > this.From.Troop.Sword) ||
            (this.Axe > this.From.Troop.Axe) ||
            (this.Scout > this.From.Troop.Scout) ||
            (this.Light > this.From.Troop.Light) ||
            (this.Heavy > this.From.Troop.Heavy) ||
            (this.Ram > this.From.Troop.Ram) ||
            (this.Catapult > this.From.Troop.Catapult) ||
            (this.Noble > this.From.Troop.Noble))
                throw new Exception("Không đủ quân");

            TroopType type = TroopType.Spear;
            if (this.Scout > 0)
                type = TroopType.Scout;
            if (this.Light > 0)
                type = TroopType.Light;
            if (this.Heavy > 0)
                type = TroopType.Heavy;
            if (this.Spear > 0)
                type = TroopType.Spear;
            if (this.Axe > 0)
                type = TroopType.Axe;
            if (this.Sword > 0)
                type = TroopType.Sword;
            if (this.Ram > 0)
                type = TroopType.Ram;
            if (this.Catapult > 0)
                type = TroopType.Catapult;
            if (this.Noble > 0)
                type = TroopType.Nobleman;

            this.StartTime = DateTime.Now;
            this.LandingTime = Map.LandingTime(type, this.From, this.To, this.StartTime);

            this.From.Troop.Spear -= this.Spear;
            this.From.Troop.Sword -= this.Sword;
            this.From.Troop.Axe -= this.Axe;
            this.From.Troop.Scout -= this.Scout;
            this.From.Troop.Light -= this.Light;
            this.From.Troop.Heavy -= this.Heavy;
            this.From.Troop.Ram -= this.Ram;
            this.From.Troop.Catapult -= this.Catapult;
            this.From.Troop.Noble -= this.Noble;

            this.From.Troop.TotalSpear -= this.Spear;
            this.From.Troop.TotalSword -= this.Sword;
            this.From.Troop.TotalAxe -= this.Axe;
            this.From.Troop.TotalScout -= this.Scout;
            this.From.Troop.TotalLight -= this.Light;
            this.From.Troop.TotalHeavy -= this.Heavy;
            this.From.Troop.TotalRam -= this.Ram;
            this.From.Troop.TotalCatapult -= this.Catapult;
            this.From.Troop.TotalNoble -= this.Noble;

            session.Save(this);
            session.Update(this.From);
        }

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

                this.To.Troop.TotalSpear += this.Spear;
                this.To.Troop.TotalSword += this.Sword;
                this.To.Troop.TotalAxe += this.Axe;
                this.To.Troop.TotalLight += this.Light;
                this.To.Troop.TotalHeavy += this.Heavy;
                this.To.Troop.TotalScout += this.Scout;
                this.To.Troop.TotalRam += this.Ram;
                this.To.Troop.TotalCatapult += this.Catapult;
                this.To.Troop.TotalNoble += this.Noble;

                session.Update(this.To);
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

                this.To.Troop.TotalSpear += this.Spear;
                this.To.Troop.TotalSword += this.Sword;
                this.To.Troop.TotalAxe += this.Axe;
                this.To.Troop.TotalLight += this.Light;
                this.To.Troop.TotalHeavy += this.Heavy;
                this.To.Troop.TotalScout += this.Scout;
                this.To.Troop.TotalRam += this.Ram;
                this.To.Troop.TotalCatapult += this.Catapult;
                this.To.Troop.TotalNoble += this.Noble;

                session.Update(this.To);
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

        public override void cancel(ISession session)
        {
            Return r = new Return();
            r.Spear = this.Spear;
            r.Sword = this.Sword;
            r.Axe = this.Axe;
            r.Scout = this.Scout;
            r.Light = this.Light;
            r.Heavy = this.Heavy;
            r.Ram = this.Ram;
            r.Catapult = this.Catapult;
            r.Noble = this.Noble;
            r.From = this.To;
            r.To = this.From;
            r.Pending = false;
            r.StartTime = DateTime.Now;
            r.LandingTime = r.StartTime.Add(this.LandingTime - this.StartTime);


            session.Save(r);
            session.Delete(this);
        }
        
        #endregion

        
    }
}
