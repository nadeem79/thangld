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
            this.To.Update(this.LandingTime, session);

            Report report = new Report();
            report.Time = this.LandingTime;
            report.Owner = this.From.Owner;

            Report report2 = new Report();
            report2.Time = this.LandingTime;
            report2.Owner = this.To.Owner;

            //this.From.Update(this.LandingTime, session);

            AttackReport attack = new AttackReport();
            
            attack.From = this.From;
            attack.To = this.To;

            attack.SpearSent = this.Spear;
            attack.SwordSent = this.Sword;
            attack.AxeSent = this.Axe;
            attack.ScoutSent = this.Scout;
            attack.LightSent = this.Light;
            attack.HeavySent = this.Heavy;
            attack.RamSent = this.Ram;
            attack.CatapultSent = this.Catapult;
            attack.NobleSent = this.Noble;

            attack.SpearDefense = this.To.Troop.TotalSpear;
            attack.SwordDefense = this.To.Troop.TotalSword;
            attack.AxeDefense = this.To.Troop.TotalAxe;
            attack.ScoutDefense = this.To.Troop.TotalScout;
            attack.LightDefense = this.To.Troop.TotalLight;
            attack.HeavyDefense = this.To.Troop.TotalHeavy;
            attack.RamDefense = this.To.Troop.TotalRam;
            attack.CatapultDefense = this.To.Troop.TotalCatapult;
            attack.NobleDefense = this.To.Troop.TotalNoble;

            attack.LoyalAfter = this.To.Loyal;
            attack.Building = this.Building;
            attack.BuildingAfter = this.To[this.Building];

            Random r = new Random();
            attack.Luck = 0.3 * (2 * r.NextDouble() - 1);
            long infantryAttack = this.Spear * 10 + this.Sword * 25 + this.Axe * 40 + this.Noble * 30;
            long cavalryAttack = this.Light * 130 + this.Heavy * 150;
            long totalAttack = infantryAttack + cavalryAttack;

            double pInfantry = (double)infantryAttack / (double)totalAttack;
            double pCavalry = (double)cavalryAttack / (double)totalAttack;

            long infantryDefense = this.To.Troop.TotalSpear * 15 + this.To.Troop.TotalSword * 50 + this.To.Troop.TotalAxe * 10 + this.To.Troop.TotalLight * 30 + this.To.Troop.TotalHeavy * 200 + this.To.Troop.TotalNoble * 100;
            long cavalryDefense = this.To.Troop.TotalSpear * 45 + this.To.Troop.TotalSword * 15 + this.To.Troop.TotalAxe * 5 + this.To.Troop.TotalLight * 40 + this.To.Troop.TotalHeavy * 80 + this.To.Troop.TotalNoble * 50;
            long totalDefense = (long)(infantryDefense * pInfantry + cavalryDefense * pCavalry) + 100;

            totalAttack = (totalAttack / totalDefense) * totalAttack;
            totalAttack += (long)(totalAttack * attack.Luck);

            double ratio;   
            Player owner = this.To.Owner;
            attack.SuccessAttack = (totalAttack > totalDefense);
            if (totalAttack > totalDefense) // quân tấn công thắng
            {
                ratio = 1 - ((double)totalDefense / (double)totalAttack);

                this.From.Troop.InVillageSpear -= (int)Math.Round(this.Spear * (1 - ratio));
                this.From.Troop.InVillageSword -= (int)Math.Round(this.Sword * (1 - ratio));
                this.From.Troop.InVillageAxe -= (int)Math.Round(this.Axe * (1 - ratio));
                this.From.Troop.InVillageLight -= (int)Math.Round(this.Light * (1 - ratio));
                this.From.Troop.InVillageScout -= (int)Math.Round(this.Scout * (1 - ratio));
                this.From.Troop.InVillageHeavy -= (int)Math.Round(this.Heavy * (1 - ratio));
                this.From.Troop.InVillageRam -= (int)Math.Round(this.Ram * (1 - ratio));
                this.From.Troop.InVillageCatapult -= (int)Math.Round(this.Catapult * (1 - ratio));
                this.From.Troop.InVillageNoble -= (int)Math.Round(this.Noble * (1 - ratio));

                attack.SpearReturnt = this.Spear = (int)Math.Round(this.Spear * ratio);
                attack.SwordReturnt = this.Sword = (int)Math.Round(this.Sword * ratio);
                attack.AxeReturnt = this.Axe = (int)Math.Round(this.Axe * ratio);
                attack.LightReturnt = this.Light = (int)Math.Round(this.Light * ratio);
                attack.ScoutReturnt = this.Scout = (int)Math.Round(this.Scout * ratio);
                attack.HeavyReturnt = this.Heavy = (int)Math.Round(this.Heavy * ratio);
                attack.RamReturnt = this.Ram = (int)Math.Round(this.Ram * ratio);
                attack.CatapultReturnt = this.Catapult = (int)Math.Round(this.Catapult * ratio);
                attack.NobleReturnt = this.Noble = (int)Math.Round(this.Noble * ratio);

                this.To.Troop.InVillageSpear = attack.SpearSurvived = this.To.Troop.Spear = this.To.Troop.TotalSpear = 0;
                this.To.Troop.InVillageSword = attack.SwordSurvived = this.To.Troop.Sword = this.To.Troop.TotalSword = 0;
                this.To.Troop.InVillageAxe = attack.AxeSurvived = this.To.Troop.Axe = this.To.Troop.TotalAxe = 0;
                this.To.Troop.InVillageScout = attack.ScoutSurvived = this.To.Troop.Scout = this.To.Troop.TotalScout = 0;
                this.To.Troop.InVillageLight = attack.LightSurvived = this.To.Troop.Light = this.To.Troop.TotalLight = 0;
                this.To.Troop.InVillageHeavy = attack.HeavySurvived = this.To.Troop.Heavy = this.To.Troop.TotalHeavy = 0;
                this.To.Troop.InVillageRam = attack.RamSurvived = this.To.Troop.Ram = this.To.Troop.TotalRam = 0;
                this.To.Troop.InVillageCatapult = attack.CatapultSurvived = this.To.Troop.Catapult = this.To.Troop.TotalCatapult = 0;
                this.To.Troop.InVillageNoble = attack.NobleSurvived = this.To.Troop.Noble = this.To.Troop.TotalNoble = 0;

                if (this.Noble > 0)
                    this.To.Loyal -= (r.Next(15) + 20);
                if (this.To.Loyal <= 0)
                {
                    this.To.Owner.Point -= this.To.Points;
                    this.From.Owner.Point += this.To.Points;
                    this.To.Owner = this.From.Owner;
                    this.To.Loyal = 25;
                    foreach (Stationed station in this.To.Troop.TroopsOutside)
                    {
                        station.AtVillage.Update(this.LandingTime, session);
                        station.Delete(session);
                    }
                    this.To.Troop.TroopsOutside.Clear();


                    foreach (Stationed station in this.To.Troop.StationedTroops)
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

                    this.To.Troop.TotalSpear += this.Spear;
                    this.To.Troop.TotalSword += this.Sword;
                    this.To.Troop.TotalAxe += this.Axe;
                    this.To.Troop.TotalScout += this.Scout;
                    this.To.Troop.TotalLight += this.Light;
                    this.To.Troop.TotalHeavy += this.Heavy;
                    this.To.Troop.TotalRam += this.Ram;
                    this.To.Troop.TotalCatapult += this.Catapult;
                    this.To.Troop.TotalNoble += this.Noble;

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
                    int intTotalResource = this.To.Resources.Iron + this.To.Resources.Clay + this.To.Resources.Wood;

                    if (intTotalResource <= intCanHaul)
                    {
                        returnTroop.Clay = this.To.Resources.Clay;
                        returnTroop.Wood = this.To.Resources.Wood;
                        returnTroop.Iron = this.To.Resources.Iron;

                        this.To.Resources.Clay = this.To.Resources.Iron = this.To.Resources.Wood = 0;
                    }
                    else
                    {
                        returnTroop.Clay = (int)((double)this.To.Resources.Clay * (double)intCanHaul / (double)intTotalResource);
                        returnTroop.Wood = (int)((double)this.To.Resources.Wood * (double)intCanHaul / (double)intTotalResource);
                        returnTroop.Iron = (int)((double)this.To.Resources.Iron * (double)intCanHaul / (double)intTotalResource);

                        this.To.Resources.Clay -= returnTroop.Clay;
                        this.To.Resources.Wood -= returnTroop.Wood;
                        this.To.Resources.Iron -= returnTroop.Iron;
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

                this.From.Troop.InVillageSpear -= this.Spear;
                this.From.Troop.InVillageSword -= this.Sword;
                this.From.Troop.InVillageAxe -= this.Axe;
                this.From.Troop.InVillageLight -= this.Light;
                this.From.Troop.InVillageScout -= this.Scout;
                this.From.Troop.InVillageHeavy -= this.Heavy;
                this.From.Troop.InVillageRam -= this.Ram;
                this.From.Troop.InVillageCatapult -= this.Catapult;
                this.From.Troop.InVillageNoble -= this.Noble;

                this.To.Troop.InVillageSpear -= (int)Math.Round(this.To.Troop.Spear * (1 - ratio));
                this.To.Troop.InVillageSword -= (int)Math.Round(this.To.Troop.Sword * (1 - ratio));
                this.To.Troop.InVillageAxe -= (int)Math.Round(this.To.Troop.Axe * (1 - ratio));
                this.To.Troop.InVillageLight -= (int)Math.Round(this.To.Troop.Light * (1 - ratio));
                this.To.Troop.InVillageScout -= (int)Math.Round(this.To.Troop.Scout * (1 - ratio));
                this.To.Troop.InVillageHeavy -= (int)Math.Round(this.To.Troop.Heavy * (1 - ratio));
                this.To.Troop.InVillageRam -= (int)Math.Round(this.To.Troop.Ram * (1 - ratio));
                this.To.Troop.InVillageCatapult -= (int)Math.Round(this.To.Troop.Catapult * (1 - ratio));
                this.To.Troop.InVillageNoble -= (int)Math.Round(this.To.Troop.Noble * (1 - ratio));

                this.To.Troop.TotalSpear -= (int)Math.Round(this.To.Troop.Spear * (1 - ratio));
                this.To.Troop.TotalSword -= (int)Math.Round(this.To.Troop.Sword * (1 - ratio));
                this.To.Troop.TotalAxe -= (int)Math.Round(this.To.Troop.Axe * (1 - ratio));
                this.To.Troop.TotalLight -= (int)Math.Round(this.To.Troop.Light * (1 - ratio));
                this.To.Troop.TotalScout -= (int)Math.Round(this.To.Troop.Scout * (1 - ratio));
                this.To.Troop.TotalHeavy -= (int)Math.Round(this.To.Troop.Heavy * (1 - ratio));
                this.To.Troop.TotalRam -= (int)Math.Round(this.To.Troop.Ram * (1 - ratio));
                this.To.Troop.TotalCatapult -= (int)Math.Round(this.To.Troop.Catapult * (1 - ratio));
                this.To.Troop.TotalNoble -= (int)Math.Round(this.To.Troop.Noble * (1 - ratio));

                this.To.Troop.Spear = (int)Math.Round(this.To.Troop.Spear * ratio);
                this.To.Troop.Sword = (int)Math.Round(this.To.Troop.Sword * ratio);
                this.To.Troop.Axe = (int)Math.Round(this.To.Troop.Axe * ratio);
                this.To.Troop.Light = (int)Math.Round(this.To.Troop.Light * ratio);
                this.To.Troop.Scout = (int)Math.Round(this.To.Troop.Scout * ratio);
                this.To.Troop.Heavy = (int)Math.Round(this.To.Troop.Heavy * ratio);
                this.To.Troop.Ram = (int)Math.Round(this.To.Troop.Ram * ratio);
                this.To.Troop.Catapult = (int)Math.Round(this.To.Troop.Catapult * ratio);
                this.To.Troop.Noble = (int)Math.Round(this.To.Troop.Noble * ratio);

                foreach (Stationed station in this.To.Troop.StationedTroops)
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

            report.SetAttackReport(attack);
            report2.Description.Description = report.Description.Description;

            session.Update(this.To);
            session.Update(this.From);
            session.Update(this.To.Owner);
            session.Update(this.From.Owner);
            
            report.SetAttackReport(attack);
            session.Save(report);
            session.Save(report2);
            
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
