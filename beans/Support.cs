using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using NHibernate.Linq;
using NHibernate.Criterion;
using System.Data;

namespace beans
{
    public class Support:MovingCommand
    {

        public virtual int Spear
        {
            get;
            set;
        }
        public virtual int Sword
        {
            get;
            set;
        }
        public virtual int Axe
        {
            get;
            set;
        }
        public virtual int Scout
        {
            get;
            set;
        }
        public virtual int LightCavalry
        {
            get;
            set;
        }
        public virtual int HeavyCavalry
        {
            get;
            set;
        }
        public virtual int Ram
        {
            get;
            set;
        }
        public virtual int Catapult
        {
            get;
            set;
        }
        public virtual int Noble
        {
            get;
            set;
        }
        public override MoveType Type
        {
            get { return MoveType.Support; }
        }
        public override Hero Hero
        {
            get;
            set;
        }


        public override void Save(ISession session)
        {
            if ((this.Spear > this.FromVillage.VillageTroopData.Spear) ||
            (this.Sword > this.FromVillage.VillageTroopData.Sword) ||
            (this.Axe > this.FromVillage.VillageTroopData.Axe) ||
            (this.Scout > this.FromVillage.VillageTroopData.Scout) ||
            (this.LightCavalry > this.FromVillage.VillageTroopData.LightCavalry) ||
            (this.HeavyCavalry > this.FromVillage.VillageTroopData.HeavyCavalry) ||
            (this.Ram > this.FromVillage.VillageTroopData.Ram) ||
            (this.Catapult > this.FromVillage.VillageTroopData.Catapult) ||
            (this.Noble > this.FromVillage.VillageTroopData.Noble))
                throw new Exception("Không đủ quân");

            TroopType type = TroopType.Spear;
            if (this.Scout > 0)
                type = TroopType.Scout;
            if (this.LightCavalry > 0)
                type = TroopType.Light;
            if (this.HeavyCavalry > 0)
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

            this.StartingTime = DateTime.Now;
            this.LandingTime = Map.LandingTime(type, this.FromVillage, this.ToVillage, this.StartingTime);

            this.FromVillage.VillageTroopData.Spear -= this.Spear;
            this.FromVillage.VillageTroopData.Sword -= this.Sword;
            this.FromVillage.VillageTroopData.Axe -= this.Axe;
            this.FromVillage.VillageTroopData.Scout -= this.Scout;
            this.FromVillage.VillageTroopData.LightCavalry -= this.LightCavalry;
            this.FromVillage.VillageTroopData.HeavyCavalry -= this.HeavyCavalry;
            this.FromVillage.VillageTroopData.Ram -= this.Ram;
            this.FromVillage.VillageTroopData.Catapult -= this.Catapult;
            this.FromVillage.VillageTroopData.Noble -= this.Noble;

            this.FromVillage.VillageTroopData.SpearInVillage -= this.Spear;
            this.FromVillage.VillageTroopData.SwordInVillage -= this.Sword;
            this.FromVillage.VillageTroopData.AxeInVillage -= this.Axe;
            this.FromVillage.VillageTroopData.ScoutInVillage -= this.Scout;
            this.FromVillage.VillageTroopData.LightCavalry -= this.LightCavalry;
            this.FromVillage.VillageTroopData.HeavyCavalryInVillage -= this.HeavyCavalry;
            this.FromVillage.VillageTroopData.RamInVillage -= this.Ram;
            this.FromVillage.VillageTroopData.CatapultInVillage -= this.Catapult;
            this.FromVillage.VillageTroopData.NobleInVillage -= this.Noble;

            this.FromVillage.MovingCommandsFromMe.Add(this);
            this.ToVillage.MovingCommandsToMe.Add(this);
            session.Save(this);
            session.Update(this.FromVillage);
            session.Update(this.ToVillage);

        }

        public override MovingCommand Effect(ISession session)
        {


            //ICriteria criteria = session.CreateCriteria(typeof(Station));

            //criteria.Add(Expression.Eq("AtVillage", this.ToVillage));
            //criteria.Add(Expression.Eq("FromVillage", this.FromVillage));
            //IList<Station> lstStations = criteria.List<Station>();

            Station station = (from s in this.ToVillage.StationsAtMe
                               where s.FromVillage == this.FromVillage
                               select s).SingleOrDefault<Station>();

            bool newStation = (station == null);
            if (newStation)
            {
                station = new Station();
                station.FromVillage = this.FromVillage;
                station.AtVillage = this.ToVillage;
                station.Spear = this.Spear;
                station.Sword = this.Sword;
                station.Axe = this.Axe;
                station.Scout = this.Scout;
                station.LightCavalry = this.LightCavalry;
                station.HeavyCavalry = this.HeavyCavalry;
                station.Ram = this.Ram;
                station.Catapult = this.Catapult;
                station.Noble = this.Noble;

                this.ToVillage.VillageTroopData.SpearInVillage += this.Spear;
                this.ToVillage.VillageTroopData.SwordInVillage += this.Sword;
                this.ToVillage.VillageTroopData.AxeInVillage+= this.Axe;
                this.ToVillage.VillageTroopData.LightCavalryInVillage += this.LightCavalry;
                this.ToVillage.VillageTroopData.HeavyCavalryInVillage += this.HeavyCavalry;
                this.ToVillage.VillageTroopData.ScoutInVillage += this.Scout;
                this.ToVillage.VillageTroopData.RamInVillage += this.Ram;
                this.ToVillage.VillageTroopData.CatapultInVillage += this.Catapult;
                this.ToVillage.VillageTroopData.NobleInVillage += this.Noble;

                this.ToVillage.StationsAtMe.Add(station);
                this.FromVillage.StationsFromMe.Add(station);

                session.Save(station);
            }
            else
            {
                station.Spear += this.Spear;
                station.Sword += this.Sword;
                station.Axe += this.Axe;
                station.Scout += this.Scout;
                station.LightCavalry += this.LightCavalry;
                station.HeavyCavalry += this.HeavyCavalry;
                station.Ram += this.Ram;
                station.Catapult += this.Catapult;
                station.Noble += this.Noble;

                this.ToVillage.VillageTroopData.SpearInVillage += this.Spear;
                this.ToVillage.VillageTroopData.SwordInVillage += this.Sword;
                this.ToVillage.VillageTroopData.AxeInVillage += this.Axe;
                this.ToVillage.VillageTroopData.LightCavalryInVillage += this.LightCavalry;
                this.ToVillage.VillageTroopData.HeavyCavalryInVillage += this.HeavyCavalry;
                this.ToVillage.VillageTroopData.ScoutInVillage += this.Scout;
                this.ToVillage.VillageTroopData.RamInVillage += this.Ram;
                this.ToVillage.VillageTroopData.CatapultInVillage += this.Catapult;
                this.ToVillage.VillageTroopData.NobleInVillage += this.Noble;

                session.Update(station);
            }

            SupportReport supportReport = new SupportReport();
            supportReport.Owner = this.ToVillage.Player;
            supportReport.Time = this.LandingTime;
            supportReport.Title = this.FromVillage.Player + " gửi quân hỗ trợ " + this.ToVillage.Name + "(" + this.ToVillage.X.ToString("000") + "|" + this.ToVillage.Y.ToString("000") + ")";
            supportReport.FromVillage = this.FromVillage;
            supportReport.ToVillage = this.ToVillage;
            supportReport.Spear = this.Spear;
            supportReport.Sword = this.Sword;
            supportReport.Axe = this.Axe;
            supportReport.Scout = this.Scout;
            supportReport.LightCavalry = this.LightCavalry;
            supportReport.HeavyCavalry = this.HeavyCavalry;
            supportReport.Ram = this.Ram;
            supportReport.Catapult = this.Catapult;
            supportReport.Noble = this.Noble;
            supportReport.FromPlayer = this.FromVillage.Player;
            supportReport.ToPlayer = this.ToVillage.Player;

            session.Save(supportReport);
            supportReport.Owner = this.FromVillage.Player;
            session.Save(supportReport);
            session.Delete(this);

            this.ToVillage.MovingCommandsToMe.Remove(this);
            this.FromVillage.MovingCommandsFromMe.Remove(this);

            session.Delete(this);
            session.Update(this.ToVillage);
            session.Update(this.FromVillage);

            return null;
        }

        public override MovingCommand Cancel(ISession session)
        {
            Return r = new Return();
            r.Spear = this.Spear;
            r.Sword = this.Sword;
            r.Axe = this.Axe;
            r.Scout = this.Scout;
            r.LightCavalry = this.LightCavalry;
            r.HeavyCavalry = this.HeavyCavalry;
            r.Ram = this.Ram;
            r.Catapult = this.Catapult;
            r.Noble = this.Noble;
            r.FromVillage = this.ToVillage;
            r.ToVillage = this.FromVillage;
            r.StartingTime = DateTime.Now;
            r.LandingTime = r.StartingTime.Add(this.LandingTime - this.StartingTime);

            this.ToVillage.MovingCommandsToMe.Remove(this);
            this.ToVillage.MovingCommandsFromMe.Add(r);

            this.FromVillage.MovingCommandsFromMe.Remove(this);
            this.FromVillage.MovingCommandsToMe.Add(r);

            session.Save(r);
            session.Delete(this);

            session.Update(this.ToVillage);
            session.Update(this.FromVillage);

            return r;
        }

        
    }
}
