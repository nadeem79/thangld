using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using NHibernate.Linq;
using NHibernate.Criterion;

namespace beans
{
    public partial class Village
    {

        public virtual int GetIncomingAttackCount(ISession session)
        {

            return (from attack in session.Linq<Attack>()
                    where attack.ToVillage == this
                    select attack).Count();

        }
        public virtual int GetIncomingSupportCount(ISession session)
        {
            return (from support in session.Linq<Support>()
                    where support.ToVillage == this
                    select support).Count();
        }

        public virtual IList<MovingCommand> TroopMovement
        {
            get;
            set;
        }
        public virtual IList<MovingCommand> TroopToMe
        {
            get;
            set;
        }
        public virtual IList<MovingCommand> TroopFromMe
        {
            get;
            set;
        }
        public virtual IList<Station> StationsAtMe
        {
            get;
            set;
        }
        public virtual IList<Station> StationsFromMe
        {
            get;
            set;
        }

        public virtual void PrepareTroopData(ISession session)
        {
            ICriteria criteria = session.CreateCriteria<MovingCommand>();
            criteria.Add(Expression.Gt("LandingTime", this.LastUpdate));
            criteria.Add(Expression.Or
                        (
                            Expression.And
                            (
                                Expression.And
                                (
                                    Expression.Sql("this_.type<>1"), // không phải send resource
                                    Expression.Sql("this_.merchant is null") // có merchant = 0
                                ),
                                Expression.Or // đến bất kỳ đâu
                                (
                                    Expression.Eq("FromVillage", this),
                                    Expression.Eq("ToVillage", this)
                                )
                            ),
                            Expression.And
                            (
                                Expression.And
                                (
                                    Expression.Sql("this_.type=4"), // đối tượng return
                                    Expression.Sql("this_.merchant is null or this_.merchant=0") // có merchant = 0
                                ),
                                Expression.Eq("ToVillage", this) // đến làng this
                            )
                        ));

            criteria.AddOrder(Order.Asc("LandingTime"));

            this.TroopMovement = criteria.List<MovingCommand>();

            this.TroopFromMe = (from movingCommand in this.TroopMovement
                                where movingCommand.FromVillage == this
                                select movingCommand).ToList<MovingCommand>();

            this.TroopToMe = (from movingCommand in this.TroopMovement
                              where movingCommand.ToVillage == this
                              select movingCommand).ToList<MovingCommand>();

        }

        public virtual void PrepareStationData(ISession session)
        {
            IList<Station> stations = (from station in session.Linq<Station>()
                                       where station.AtVillage == this
                                       || station.FromVillage == this
                                       select station).ToList<Station>();
            
            this.StationsAtMe = (from station in stations
                                 where station.AtVillage == this
                                 select station).ToList<Station>();
            this.StationsFromMe = (from station in stations
                                   where station.FromVillage == this
                                   select station).ToList<Station>();

        }

        public virtual IList<MovingCommand> GetTroopMovement(ISession session)
        {

            ICriteria criteria = session.CreateCriteria<MovingCommand>();
            criteria.Add(Expression.Gt("LandingTime", this.LastUpdate));
            criteria.Add(Expression.Or
                        (
                            Expression.And
                            (
                                Expression.And
                                (
                                    Expression.Sql("this_.type<>1"), // không phải send resource
                                    Expression.Sql("this_.merchant=0") // có merchant = 0
                                ),
                                Expression.Or // đến bất kỳ đâu
                                (
                                    Expression.Eq("FromVillage", this),
                                    Expression.Eq("ToVillage", this)
                                 )
                            ),
                            Expression.And
                            (
                                Expression.And
                                (
                                    Expression.Sql("this_.type=4"), // đối tượng return
                                    Expression.Sql("this_.merchant=0") // có merchant = 0
                                ),
                                Expression.Eq("ToVillage", this) // đến làng this
                            )
                        ));

            criteria.AddOrder(Order.Asc("LandingTime"));
            
            return criteria.List<MovingCommand>();
            
        }

        public virtual List<MovingCommand> GetTroopMovement(DateTime time, ISession session)
        {
            return (from movement in session.Linq<MovingCommand>()
                    where (movement.FromVillage == this || movement.ToVillage == this)
                    && movement.LandingTime < time
                    && movement.LandingTime > this.LastUpdate
                    && movement.GetType() != typeof(SendResource)
                    && (movement.GetType() == typeof(Return) && ((Return)movement).Merchant == 0)
                    orderby movement.LandingTime ascending
                    select movement).ToList();
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
                                    int noble,
                                    BuildingType building)
        {
            if (x == this.X && y == this.Y)
                throw new Exception("Nhập toạ độ");

            if ((spear + sword + axe + scout + light + heavy + ram + catapult + noble) == 0)
                throw new Exception("Nhập một loại quân");

            if ((spear > this.VillageTroopData.Spear) ||
            (sword > this.VillageTroopData.Sword) ||
            (axe > this.VillageTroopData.Axe) ||
            (scout > this.VillageTroopData.Scout) ||
            (light > this.VillageTroopData.LightCavalry) ||
            (heavy > this.VillageTroopData.HeavyCavalry) ||
            (ram > this.VillageTroopData.Ram) ||
            (catapult > this.VillageTroopData.Catapult) ||
            (noble > this.VillageTroopData.Noble))
                throw new Exception("Không đủ quân");

            Village toVillage = Village.GetVillageByCoordinate(x, y, session);
            if (toVillage == null)
                throw new Exception("Toạ độ không tồn tại");

            Attack attack = new Attack();
            attack.ToVillage = toVillage;
            attack.FromVillage = this;

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

            attack.Spear = spear;
            attack.Sword = sword;
            attack.Axe = axe;
            attack.Scout = scout;
            attack.LightCavalry = light;
            attack.HeavyCavalry = heavy;
            attack.Ram = ram;
            attack.Catapult = catapult;
            attack.Noble = noble;
            attack.StartingTime = DateTime.Now;
            attack.LandingTime = Map.LandingTime(type, attack.FromVillage.X, attack.FromVillage.Y, attack.ToVillage.X, attack.ToVillage.Y, attack.StartingTime);

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
            if (x == this.X && y == this.Y)
                throw new Exception("Nhập toạ độ");

            if ((spear + sword + axe + scout + light + heavy + ram + catapult + noble) == 0)
                throw new Exception("Nhập một loại quân");

            if ((spear > this.VillageTroopData.Spear) ||
            (sword > this.VillageTroopData.Sword) ||
            (axe > this.VillageTroopData.Axe) ||
            (scout > this.VillageTroopData.Scout) ||
            (light > this.VillageTroopData.LightCavalry) ||
            (heavy > this.VillageTroopData.HeavyCavalry) ||
            (ram > this.VillageTroopData.Ram) ||
            (catapult > this.VillageTroopData.Catapult) ||
            (noble > this.VillageTroopData.Noble))
                throw new Exception("Không đủ quân");

            Village toVillage = Village.GetVillageByCoordinate(x, y, session);
            if (toVillage == null)
                throw new Exception("Toạ độ không tồn tại");

            Support support = new Support();
            support.ToVillage = toVillage;
            support.FromVillage = this;

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
            support.LandingTime = Map.LandingTime(type, support.FromVillage.X, support.FromVillage.Y, support.ToVillage.X, support.ToVillage.Y, support.StartingTime);

            return support;
        }

        public virtual Return WithdrawStation(int stationId, ISession session)
        {

            Station station = Station.GetById(stationId, session);

            if (station.AtVillage != this && station.FromVillage != this)
                throw new TribalWarsException("Không có quân từ thành phố này");

            return station.Return(session);
        }

        public virtual Return WithdrawStation(  int stationId,
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

            Station station = Station.GetById(stationId, session);

            if (station.AtVillage != this && station.FromVillage != this)
                throw new TribalWarsException("Không có quân từ thành phố này");

            return station.Return(spear, sword, axe, scout, lightCavalry, heavyCavalry, ram, catapult, noble, session);
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

            if (station.AtVillage != this && station.FromVillage != this)
                throw new TribalWarsException("Không có quân từ thành phố này");

            return station.Return(spear, sword, axe, scout, lightCavalry, heavyCavalry, ram, catapult, noble, session);
        }

        public virtual Station GetStationById(int stationId, ISession session)
        {
            return (from station in session.Linq<Station>()
                    where station.ID == stationId
                    && (station.AtVillage == this || station.FromVillage == this)
                    select station).SingleOrDefault<Station>();
        }
    }
}