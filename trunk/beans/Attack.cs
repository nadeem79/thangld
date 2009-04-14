using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using uNhAddIns;
using NHibernate.UserTypes;

namespace beans
{
    public class Attack:MovingCommand
    {
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
        public BuildingType Building
        {
            get;
            set;
        }
        public override MoveType Type
        {
            get
            {
                return MoveType.Attack;
            }
        }

        #endregion

        #region Static Members

        public static Attack CreateAttack(ISession session,
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
                                           int noble,
                                           BuildingType building)
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

            Attack attack = new Attack();

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

            attack.From = from;
            attack.StartTime = DateTime.Now;
            attack.To = session.Load<Village>(intTo);
            attack.Spear = spear;
            attack.Sword = sword;
            attack.Axe = axe;
            attack.Scout = scout;
            attack.Light = light;
            attack.Heavy = heavy;
            attack.Ram = ram;
            attack.Catapult = catapult;
            attack.Noble = noble;
            attack.StartTime = DateTime.Now;
            attack.LandingTime = Map.LandingTime(type, attack.From, attack.To, attack.StartTime); 
            attack.Building = building;
            attack.Pending = true;
            session.Save(attack);
            
            return attack;
        }
        #endregion

        #region Methods

        public void execute(ISession session)
        {
            if ((this.Spear > this.From.Spear) ||
            (this.Sword > this.From.Sword) ||
            (this.Axe > this.From.Axe) ||
            (this.Scout > this.From.Scout) ||
            (this.Light > this.From.Light) ||
            (this.Heavy > this.From.Heavy) ||
            (this.Ram > this.From.Ram) ||
            (this.Catapult > this.From.Catapult) ||
            (this.Noble > this.From.Noble))
                throw new Exception("Không đủ quân");

            TimeSpan transitTime = this.LandingTime - this.StartTime;
            this.StartTime = DateTime.Now;
            this.LandingTime = this.StartTime + transitTime;
            this.Pending = false;

            this.From.Spear -= this.Spear;
            this.From.Sword -= this.Sword;
            this.From.Axe -= this.Axe;
            this.From.Scout -= this.Scout;
            this.From.Light -= this.Light;
            this.From.Heavy -= this.Heavy;
            this.From.Ram -= this.Ram;
            this.From.Catapult -= this.Catapult;
            this.From.Noble -= this.Noble;

            session.Update(this);
            session.Update(this.From);
        }

        public override void save(ISession session)
        {
            if ((this.Spear > this.From.Spear) ||
            (this.Sword > this.From.Sword) ||
            (this.Axe > this.From.Axe) ||
            (this.Scout > this.From.Scout) ||
            (this.Light > this.From.Light) ||
            (this.Heavy > this.From.Heavy) ||
            (this.Ram > this.From.Ram) ||
            (this.Catapult > this.From.Catapult) ||
            (this.Noble > this.From.Noble))
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

            this.From.Spear -= this.Spear;
            this.From.Sword -= this.Sword;
            this.From.Axe -= this.Axe;
            this.From.Scout -= this.Scout;
            this.From.Light -= this.Light;
            this.From.Heavy -= this.Heavy;
            this.From.Ram -= this.Ram;
            this.From.Catapult -= this.Catapult;
            this.From.Noble -= this.Noble;

            session.Save(this);
            session.Update(this.From);
        }

        public override void effect(ISession session)
        {
            this.To.Update(this.LandingTime, session);
            //this.From.Update(this.LandingTime, session);

            AttackReport defenseSideReport = new AttackReport();
            AttackReport attackSideReport = new AttackReport();
            
            attackSideReport.Time = this.LandingTime;
            attackSideReport.Title = this.From.Owner.Username + " tấn công " + this.To.Name + "(" + this.To.X.ToString("000") + "|" + this.To.Y.ToString("000") + ")";
            attackSideReport.From = this.From;
            attackSideReport.To = this.To;

            defenseSideReport.Time = this.LandingTime;
            defenseSideReport.Title = this.From.Owner.Username + " tấn công " + this.To.Name + "(" + this.To.X.ToString("000") + "|" + this.To.Y.ToString("000") + ")";
            defenseSideReport.From = this.From;
            defenseSideReport.To = this.To;

            attackSideReport.SpearSent = this.Spear;
            attackSideReport.SwordSent = this.Sword;
            attackSideReport.AxeSent = this.Axe;
            attackSideReport.ScoutSent = this.Scout;
            attackSideReport.LightSent = this.Light;
            attackSideReport.HeavySent = this.Heavy;
            attackSideReport.RamSent = this.Ram;
            attackSideReport.CatapultSent = this.Catapult;
            attackSideReport.NobleSent = this.Noble;

            defenseSideReport.SpearSent = this.Spear;
            defenseSideReport.SwordSent = this.Sword;
            defenseSideReport.AxeSent = this.Axe;
            defenseSideReport.ScoutSent = this.Scout;
            defenseSideReport.LightSent = this.Light;
            defenseSideReport.HeavySent = this.Heavy;
            defenseSideReport.RamSent = this.Ram;
            defenseSideReport.CatapultSent = this.Catapult;
            defenseSideReport.NobleSent = this.Noble;

            attackSideReport.SpearDefense = this.To.TotalSpear;
            attackSideReport.SwordDefense = this.To.TotalSword;
            attackSideReport.AxeDefense = this.To.TotalAxe;
            attackSideReport.ScoutDefense = this.To.TotalScout;
            attackSideReport.LightDefense = this.To.TotalLight;
            attackSideReport.HeavyDefense = this.To.TotalHeavy;
            attackSideReport.RamDefense = this.To.TotalRam;
            attackSideReport.CatapultDefense = this.To.TotalCatapult;
            attackSideReport.NobleDefense = this.To.TotalNoble;

            defenseSideReport.SpearDefense = this.To.TotalSpear;
            defenseSideReport.SwordDefense = this.To.TotalSword;
            defenseSideReport.AxeDefense = this.To.TotalAxe;
            defenseSideReport.ScoutDefense = this.To.TotalScout;
            defenseSideReport.LightDefense = this.To.TotalLight;
            defenseSideReport.HeavyDefense = this.To.TotalHeavy;
            defenseSideReport.RamDefense = this.To.TotalRam;
            defenseSideReport.CatapultDefense = this.To.TotalCatapult;
            defenseSideReport.NobleDefense = this.To.TotalNoble;

            attackSideReport.LoyalAfter = this.To.Loyal;
            attackSideReport.Building = this.Building;
            attackSideReport.BuildingAfter = this.To[this.Building];

            defenseSideReport.LoyalAfter = this.To.Loyal;
            defenseSideReport.Building = this.Building;
            defenseSideReport.BuildingAfter = this.To[this.Building];

            Random r = new Random();
            double luck = 0.3 * (2 * r.NextDouble() - 1);
            attackSideReport.Luck = luck;
            defenseSideReport.Luck = luck;
            long infantryAttack = this.Spear * 10 + this.Sword * 25 + this.Axe * 40 + this.Noble * 30;
            long cavalryAttack = this.Light * 130 + this.Heavy * 150;
            long totalAttack = infantryAttack + cavalryAttack;

            double pInfantry = (double)infantryAttack / (double)totalAttack;
            double pCavalry = (double)cavalryAttack / (double)totalAttack;

            long infantryDefense = this.To.TotalSpear * 15 + this.To.TotalSword * 50 + this.To.TotalAxe * 10 + this.To.TotalLight * 30 + this.To.TotalHeavy * 200 + this.To.TotalNoble * 100;
            long cavalryDefense = this.To.TotalSpear * 45 + this.To.TotalSword * 15 + this.To.TotalAxe * 5 + this.To.TotalLight * 40 + this.To.TotalHeavy * 80 + this.To.TotalNoble * 50;
            long totalDefense = (long)(infantryDefense * pInfantry + cavalryDefense * pCavalry) + 100;

            totalAttack = (totalAttack / totalDefense) * totalAttack;
            totalAttack += (long)(totalAttack * luck);

            double ratio;   
            Player owner = this.To.Owner;
            attackSideReport.SuccessAttack = defenseSideReport.SuccessAttack = (totalAttack > totalDefense);
            if (totalAttack > totalDefense)
            {
                ratio = 1 - ((double)totalDefense / (double)totalAttack);

                this.From.InVillageSpear -= (int)Math.Round(this.Spear * (1 - ratio));
                this.From.InVillageSword -= (int)Math.Round(this.Sword * (1 - ratio));
                this.From.InVillageAxe -= (int)Math.Round(this.Axe * (1 - ratio));
                this.From.InVillageLight -= (int)Math.Round(this.Light * (1 - ratio));
                this.From.InVillageScout -= (int)Math.Round(this.Scout * (1 - ratio));
                this.From.InVillageHeavy -= (int)Math.Round(this.Heavy * (1 - ratio));
                this.From.InVillageRam -= (int)Math.Round(this.Ram * (1 - ratio));
                this.From.InVillageCatapult -= (int)Math.Round(this.Catapult * (1 - ratio));
                this.From.InVillageNoble -= (int)Math.Round(this.Noble * (1 - ratio));

                defenseSideReport.SpearReturnt = attackSideReport.SpearReturnt = this.Spear = (int)Math.Round(this.Spear * ratio);
                defenseSideReport.SwordReturnt = attackSideReport.SwordReturnt = this.Sword = (int)Math.Round(this.Sword * ratio);
                defenseSideReport.AxeReturnt = attackSideReport.AxeReturnt = this.Axe = (int)Math.Round(this.Axe * ratio);
                defenseSideReport.LightReturnt = attackSideReport.LightReturnt = this.Light = (int)Math.Round(this.Light * ratio);
                defenseSideReport.ScoutReturnt = attackSideReport.ScoutReturnt = this.Scout = (int)Math.Round(this.Scout * ratio);
                defenseSideReport.HeavyReturnt = attackSideReport.HeavyReturnt = this.Heavy = (int)Math.Round(this.Heavy * ratio);
                defenseSideReport.RamReturnt = attackSideReport.RamReturnt = this.Ram = (int)Math.Round(this.Ram * ratio);
                defenseSideReport.CatapultReturnt = attackSideReport.CatapultReturnt = this.Catapult = (int)Math.Round(this.Catapult * ratio);
                defenseSideReport.NobleReturnt = attackSideReport.NobleReturnt = this.Noble = (int)Math.Round(this.Noble * ratio);

                this.To.InVillageSpear = defenseSideReport.SpearSurvived = attackSideReport.SpearSurvived = this.To.Spear = 0;
                this.To.InVillageSword = defenseSideReport.SwordSurvived = attackSideReport.SwordSurvived = this.To.Sword = 0;
                this.To.InVillageAxe = defenseSideReport.AxeSurvived = attackSideReport.AxeSurvived = this.To.Axe = 0;
                this.To.InVillageScout = defenseSideReport.ScoutSurvived = attackSideReport.ScoutSurvived = this.To.Scout = 0;
                this.To.InVillageLight = defenseSideReport.LightSurvived = attackSideReport.LightSurvived = this.To.Light = 0;
                this.To.InVillageHeavy = defenseSideReport.HeavySurvived = attackSideReport.HeavySurvived = this.To.Heavy = 0;
                this.To.InVillageRam = defenseSideReport.RamSurvived = attackSideReport.RamSurvived = this.To.Ram = 0;
                this.To.InVillageCatapult = defenseSideReport.CatapultSurvived = attackSideReport.CatapultSurvived = this.To.Catapult = 0;
                this.To.InVillageNoble = defenseSideReport.NobleSurvived = attackSideReport.NobleSurvived = this.To.Noble = 0;

                if (this.Noble > 0)
                    this.To.Loyal -= (r.Next(15) + 20);
                if (this.To.Loyal <= 0)
                {
                    this.To.Owner = this.From.Owner;
                    this.To.Loyal = 25;
                    foreach (Stationed station in this.To.TroopsOutside)
                        session.Delete(station);
                    this.To.TroopsOutside.Clear();


                    foreach (Stationed station in this.To.StationedTroops)
                    {
                        #region tạo report
                        if (station.FromVillage.Owner != this.To.Owner)
                        {
                            DefenseOtherReport defenseOtherReport = new DefenseOtherReport();
                            defenseOtherReport.Time = this.LandingTime;
                            defenseOtherReport.Owner = station.FromVillage.Owner;
                            defenseOtherReport.Title = "Quân phòng thủ của bạn ở " + this.To.Name + "(" + this.To.X.ToString() + "|" + this.To.Y.ToString() + ") bị tấn công";

                            session.Save(defenseOtherReport);
                        }
                        #endregion
                        session.Delete(station);
                    }

                    Stationed newStation = new Stationed();
                    newStation.AtVillage = this.To;
                    newStation.FromVillage = this.From;
                    newStation.Spear = this.Spear;
                    newStation.Sword = this.Sword;
                    newStation.Axe = this.Sword;
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
                    #region Quân thắng trận trở về

                    Return returnTroop = new Return();
                    returnTroop.From = this.To;
                    returnTroop.To = this.From;
                    returnTroop.Spear = this.Spear;
                    returnTroop.Sword = this.Sword;
                    returnTroop.Axe = this.Axe;
                    returnTroop.Scout = this.Scout;
                    returnTroop.Light = this.Light;
                    returnTroop.Heavy = this.Heavy;
                    returnTroop.Ram = this.Ram;
                    returnTroop.Catapult = this.Catapult;
                    returnTroop.Noble = this.Noble;
                    returnTroop.StartTime = this.LandingTime;
                    TroopType troop = TroopType.Scout;
                    if (returnTroop.Spear > 0)
                        troop = TroopType.Spear;
                    if (returnTroop.Axe > 0)
                        troop = TroopType.Axe;
                    if (returnTroop.Sword > 0)
                        troop = TroopType.Sword;
                    if (returnTroop.Scout > 0)
                        troop = TroopType.Scout;
                    if (returnTroop.Light > 0)
                        troop = TroopType.Light;
                    if (returnTroop.Heavy > 0)
                        troop = TroopType.Heavy;
                    if (returnTroop.Ram > 0)
                        troop = TroopType.Ram;
                    if (returnTroop.Catapult > 0)
                        troop = TroopType.Catapult;
                    if (returnTroop.Noble > 0)
                        troop = TroopType.Nobleman;
                    returnTroop.LandingTime = Map.LandingTime(troop, this.To.X, this.To.Y, this.From.X, this.From.Y, this.LandingTime);
                    
                    int intCanHaul = this.Spear * 25 + this.Sword * 15 + this.Axe * 10 + this.Light * 80 + this.Heavy;
                    int intTotalResource = this.To.Iron + this.To.Clay + this.To.Wood;

                    if (intTotalResource <= intCanHaul)
                    {
                        returnTroop.Clay = this.To.Clay;
                        returnTroop.Wood = this.To.Wood;
                        returnTroop.Iron = this.To.Iron;

                        this.To.Clay = this.To.Iron = this.To.Wood = 0;
                    }
                    else
                    {
                        returnTroop.Clay = (int)((double)this.To.Clay * (double)intCanHaul / (double)intTotalResource);
                        returnTroop.Wood = (int)((double)this.To.Wood * (double)intCanHaul / (double)intTotalResource);
                        returnTroop.Iron = (int)((double)this.To.Iron * (double)intCanHaul / (double)intTotalResource);

                        this.To.Clay -= returnTroop.Clay;
                        this.To.Wood -= returnTroop.Wood;
                        this.To.Iron -= returnTroop.Iron;
                    }

                    returnTroop.save(session);
                    #endregion
                }

            }
            else
            {
                if (totalAttack == 0)
                    totalAttack = 1;
                ratio = 1 - ((double)totalAttack / (double)totalDefense);

                this.From.InVillageSpear -= this.Spear;
                this.From.InVillageSword -= this.Sword;
                this.From.InVillageAxe -= this.Axe;
                this.From.InVillageLight -= this.Light ;
                this.From.InVillageScout -= this.Scout;
                this.From.InVillageHeavy -= this.Heavy;
                this.From.InVillageRam -= this.Ram;
                this.From.InVillageCatapult -= this.Catapult;
                this.From.InVillageNoble -= this.Noble;

                this.To.InVillageSpear -= (int)Math.Round(this.To.Spear * (1 - ratio));
                this.To.InVillageSword -= (int)Math.Round(this.To.Sword * (1 - ratio));
                this.To.InVillageAxe -= (int)Math.Round(this.To.Axe * (1 - ratio));
                this.To.InVillageLight -= (int)Math.Round(this.To.Light * (1 - ratio));
                this.To.InVillageScout -= (int)Math.Round(this.To.Scout * (1 - ratio));
                this.To.InVillageHeavy -= (int)Math.Round(this.To.Heavy * (1 - ratio));
                this.To.InVillageRam -= (int)Math.Round(this.To.Ram * (1 - ratio));
                this.To.InVillageCatapult -= (int)Math.Round(this.To.Catapult * (1 - ratio));
                this.To.InVillageNoble -= (int)Math.Round(this.To.Noble * (1 - ratio));

                this.To.Spear = (int)Math.Round(this.To.Spear * ratio);
                this.To.Sword = (int)Math.Round(this.To.Sword * ratio);
                this.To.Axe = (int)Math.Round(this.To.Axe * ratio);
                this.To.Light = (int)Math.Round(this.To.Light * ratio);
                this.To.Scout = (int)Math.Round(this.To.Scout * ratio);
                this.To.Heavy = (int)Math.Round(this.To.Heavy * ratio);
                this.To.Ram = (int)Math.Round(this.To.Ram * ratio);
                this.To.Catapult = (int)Math.Round(this.To.Catapult * ratio);
                this.To.Noble = (int)Math.Round(this.To.Noble * ratio);

                foreach (Stationed station in this.To.StationedTroops)
                {

                    station.Spear = (int)Math.Round(station.Spear * ratio);
                    station.Sword = (int)Math.Round(station.Sword * ratio);
                    station.Axe = (int)Math.Round(station.Axe * ratio);
                    station.Light = (int)Math.Round(station.Light * ratio);
                    station.Scout = (int)Math.Round(station.Scout * ratio);
                    station.Heavy = (int)Math.Round(station.Heavy * ratio);
                    station.Ram = (int)Math.Round(station.Ram * ratio);
                    station.Catapult = (int)Math.Round(station.Catapult * ratio);
                    station.Noble = (int)Math.Round(station.Noble * ratio);

                    #region tạo report
                    if (station.FromVillage.Owner != this.To.Owner)
                    {
                        DefenseOtherReport defenseOtherReport = new DefenseOtherReport();
                        defenseOtherReport.Time = this.LandingTime;
                        defenseOtherReport.Owner = station.FromVillage.Owner;
                        defenseOtherReport.Title = "Quân phòng thủ của bạn ở " + this.To.Name + "(" + this.To.X.ToString() + "|" + this.To.Y.ToString() + ") bị tấn công";

                        session.Save(defenseOtherReport);
                    }
                    #endregion



                    session.Update(station);

                }

            }

            this.From.LastUpdate = this.To.LastUpdate = this.LandingTime;
            session.Update(this.To);
            session.Update(this.From);

            attackSideReport.Owner = this.From.Owner;
            session.Save(attackSideReport);
            defenseSideReport.Owner = owner;
            session.Save(defenseSideReport);
            session.Delete(this);
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
