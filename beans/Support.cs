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

            session.Save(this);
            session.Update(this.FromVillage);
        }

        public override MovingCommand Effect(ISession session)
        {

            this.ToVillage.Update(this.LandingTime, session);

            ICriteria criteria = session.CreateCriteria(typeof(Station));

            criteria.Add(Expression.Eq("AtVillage", this.ToVillage));
            criteria.Add(Expression.Eq("FromVillage", this.FromVillage));
            IList<Station> lstStations = criteria.List<Station>();

            if (lstStations.Count == 0)
            {
                Station newStation = new Station();
                newStation.FromVillage = this.FromVillage;
                newStation.AtVillage = this.ToVillage;
                newStation.Spear = this.Spear;
                newStation.Sword = this.Sword;
                newStation.Axe = this.Axe;
                newStation.Scout = this.Scout;
                newStation.LightCavalry = this.LightCavalry;
                newStation.HeavyCavalry = this.HeavyCavalry;
                newStation.Ram = this.Ram;
                newStation.Catapult = this.Catapult;
                newStation.Noble = this.Noble;

                this.ToVillage.VillageTroopData.SpearInVillage += this.Spear;
                this.ToVillage.VillageTroopData.SwordInVillage += this.Sword;
                this.ToVillage.VillageTroopData.AxeInVillage+= this.Axe;
                this.ToVillage.VillageTroopData.LightCavalryInVillage += this.LightCavalry;
                this.ToVillage.VillageTroopData.HeavyCavalryInVillage += this.HeavyCavalry;
                this.ToVillage.VillageTroopData.ScoutInVillage += this.Scout;
                this.ToVillage.VillageTroopData.RamInVillage += this.Ram;
                this.ToVillage.VillageTroopData.CatapultInVillage += this.Catapult;
                this.ToVillage.VillageTroopData.NobleInVillage += this.Noble;

                session.Update(this.ToVillage);
                session.Save(newStation);
            }
            else
            {
                Station station = lstStations[0];
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

                session.Update(this.ToVillage.VillageTroopData);
                session.Save(station);
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

            session.Save(supportReport);
            supportReport.Owner = this.FromVillage.Player;
            session.Save(supportReport);

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


            session.Save(r);
            session.Delete(this);

            return r;
        }

        
        #endregion

        
    }
}
