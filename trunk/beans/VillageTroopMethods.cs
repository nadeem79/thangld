using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate.Criterion;
using NHibernate;
using NHibernate.Linq;

namespace beans
{
    public class VillageTroopMethods
    {
        public Village Village
        {
            get;
            set;
        }

        private IList<MovingCommand> troopToMe = null, troopFromMe = null;

        public IList<MovingCommand> TroopToMe
        {
            get
            {
                if (this.troopToMe == null)
                    this.troopToMe = (from m in this.Village.MovingCommandsToMe
                                      where m.GetType() != typeof(SendResource)
                                      || (m.GetType() == typeof(Return) && ((Return)m).Merchant == 0)
                                      orderby m.LandingTime ascending
                                      select m).ToList<MovingCommand>();
                return this.troopToMe;
            }
        }
        public IList<MovingCommand> TroopFromMe
        {
            get
            {
                if (this.troopFromMe == null)
                    this.troopFromMe = (from m in this.Village.MovingCommandsFromMe
                                        where m.GetType() == typeof(Attack)
                                            || m.GetType() == typeof(Support)
                                        orderby m.LandingTime ascending
                                        select m).ToList<MovingCommand>();
                return this.troopFromMe;
            }
        }

        public virtual Attack CreateAttack(ISession session,
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
                                    Hero hero,
                                    BuildingType building)
        {
            if (x == this.Village.X && y == this.Village.Y)
                throw new Exception("Nhập toạ độ");

            if ((spear + sword + axe + scout + light + heavy + ram + catapult) == 0)
                throw new Exception("Nhập một loại quân");

            if ((spear > this.Village.VillageTroopData.Spear) ||
            (sword > this.Village.VillageTroopData.Sword) ||
            (axe > this.Village.VillageTroopData.Axe) ||
            (scout > this.Village.VillageTroopData.Scout) ||
            (light > this.Village.VillageTroopData.LightCavalry) ||
            (heavy > this.Village.VillageTroopData.HeavyCavalry) ||
            (ram > this.Village.VillageTroopData.Ram) ||
            (catapult > this.Village.VillageTroopData.Catapult))
                throw new Exception("Không đủ quân");

            Village toVillage = Village.GetVillageByCoordinate(x, y, session);
            if (toVillage == null)
                throw new Exception("Toạ độ không tồn tại");

            if (hero != null)
            {
                if (!this.Village.Heroes.Contains(hero))
                    throw new TribalWarsException("Không tồn tại hero trong thành phố");
                else if (this.Village.MainHero == hero)
                    throw new TribalWarsException("Không thể đưa chủ thành đi tấn công");
            }

            Attack attack = new Attack();
            attack.ToVillage = toVillage;
            attack.FromVillage = this.Village;

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
            attack.Building = building;
            attack.Spear = spear;
            attack.Sword = sword;
            attack.Axe = axe;
            attack.Scout = scout;
            attack.LightCavalry = light;
            attack.HeavyCavalry = heavy;
            attack.Ram = ram;
            attack.Catapult = catapult;
            attack.StartingTime = DateTime.Now;
            attack.LandingTime = Map.LandingTime(type, attack.FromVillage.X, attack.FromVillage.Y, attack.ToVillage.X, attack.ToVillage.Y, attack.StartingTime, Research.SpeedValuesDictionary[this.Village[ResearchType.Speed]]);
            return attack;
        }

        public virtual Support CreateSupport(ISession session,
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
            if (x == this.Village.X && y == this.Village.Y)
                throw new Exception("Nhập toạ độ");

            if ((spear + sword + axe + scout + light + heavy + ram + catapult + noble) == 0)
                throw new Exception("Nhập một loại quân");

            if ((spear > this.Village.VillageTroopData.Spear) ||
            (sword > this.Village.VillageTroopData.Sword) ||
            (axe > this.Village.VillageTroopData.Axe) ||
            (scout > this.Village.VillageTroopData.Scout) ||
            (light > this.Village.VillageTroopData.LightCavalry) ||
            (heavy > this.Village.VillageTroopData.HeavyCavalry) ||
            (ram > this.Village.VillageTroopData.Ram) ||
            (catapult > this.Village.VillageTroopData.Catapult) ||
            (noble > this.Village.VillageTroopData.Noble))
                throw new Exception("Không đủ quân");

            Village toVillage = Village.GetVillageByCoordinate(x, y, session);
            if (toVillage == null)
                throw new Exception("Toạ độ không tồn tại");

            Support support = new Support();
            support.ToVillage = toVillage;
            support.FromVillage = this.Village;

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
            support.LightCavalry = light;
            support.HeavyCavalry = heavy;
            support.Ram = ram;
            support.Catapult = catapult;
            support.Noble = noble;
            support.StartingTime = DateTime.Now;
            support.LandingTime = Map.LandingTime(type, support.FromVillage.X, support.FromVillage.Y, support.ToVillage.X, support.ToVillage.Y, support.StartingTime, Research.SpeedValuesDictionary[this.Village[ResearchType.Speed]]);

            return support;
        }

        public virtual Return WithdrawStation(int stationId, ISession session)
        {

            Station station = session.Load<Station>(stationId);

            if (station.AtVillage != this.Village && station.FromVillage != this.Village)
                throw new TribalWarsException("Không có quân từ thành phố này");

            return station.Return(session, false);

        }
        public virtual Return WithdrawStation(int stationId,
                                                int spear,
                                                int sword,
                                                int axe,
                                                int scout,
                                                int lightCavalry,
                                                int heavyCavalry,
                                                int ram,
                                                int catapult,
                                                int noble,
                                                ISession session)
        {

            Station station = session.Load<Station>(stationId);

            if (station.AtVillage != this.Village && station.FromVillage != this.Village)
                throw new TribalWarsException("Không có quân từ thành phố này");

            return station.Return(spear, sword, axe, scout, lightCavalry, heavyCavalry, ram, catapult, noble, false, session);
        }
        public virtual Return WithdrawStation(Station station,
                                                int spear,
                                                int sword,
                                                int axe,
                                                int scout,
                                                int lightCavalry,
                                                int heavyCavalry,
                                                int ram,
                                                int catapult,
                                                int noble,
                                                ISession session)
        {

            if (station.AtVillage != this.Village && station.FromVillage != this.Village)
                throw new TribalWarsException("Không có quân từ thành phố này");

            return station.Return(spear, sword, axe, scout, lightCavalry, heavyCavalry, ram, catapult, noble, false, session);
        }

        public virtual Return SendBackStation(int stationId, ISession session)
        {

            Station station = session.Load<Station>(stationId);

            if (station.AtVillage != this.Village && station.FromVillage != this.Village)
                throw new TribalWarsException("Không có quân từ thành phố này");

            return station.Return(session, true);

        }
        public virtual Return SendBackStation(int stationId,
                                                int spear,
                                                int sword,
                                                int axe,
                                                int scout,
                                                int lightCavalry,
                                                int heavyCavalry,
                                                int ram,
                                                int catapult,
                                                int noble,
                                                ISession session)
        {

            Station station = session.Load<Station>(stationId);
            if (station.AtVillage != this.Village && station.FromVillage != this.Village)
                throw new TribalWarsException("Không có quân từ thành phố này");

            return station.Return(spear, sword, axe, scout, lightCavalry, heavyCavalry, ram, catapult, noble, true, session);
        }
        public virtual Return SendBackStation(Station station,
                                                int spear,
                                                int sword,
                                                int axe,
                                                int scout,
                                                int lightCavalry,
                                                int heavyCavalry,
                                                int ram,
                                                int catapult,
                                                int noble,
                                                ISession session)
        {

            if (station.AtVillage != this.Village && station.FromVillage != this.Village)
                throw new TribalWarsException("Không có quân từ thành phố này");

            return station.Return(spear, sword, axe, scout, lightCavalry, heavyCavalry, ram, catapult, noble, true, session);
        }

        public virtual Station GetStationById(int stationId, ISession session)
        {
            return (from station in session.Linq<Station>()
                    where station.ID == stationId
                    && (station.AtVillage == this.Village || station.FromVillage == this.Village)
                    select station).SingleOrDefault<Station>();
        }
    }
}
