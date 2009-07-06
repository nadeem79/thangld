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
        public int LightCavalry
        {
            get;
            set;
        }
        public int HeavyCavalry
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


        #region Methods

        public override void Save(ISession session)
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

        public override MovingCommand Effect(ISession session)
        {
            ICriteria criteria = session.CreateCriteria(typeof(Station));

            criteria.Add(Expression.Eq("AtVillage", this.To));
            criteria.Add(Expression.Eq("FromVillage", this.From));
            IList<Station> lstStations = criteria.List<Station>();

            if (lstStations.Count == 0)
            {
                Station newStation = new Station();
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
                Station station = lstStations[0];
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

        public override MovingCommand Cancel(ISession session)
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
