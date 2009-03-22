using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;

namespace beans
{
    public class Attack : MovingCommand
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

        public BuildingType Building
        {
            get;
            set;
        }
        

        #endregion

        #region Constructors
        public Attack()
        {

        }

        #endregion

        #region Static Members
        public static Attack CreateAttack(  ISession session,
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
            int intTo = Village.CheckVillage(x, y, session);
            
            if (intTo < 0)
                throw new Exception("Toạ độ không tồn tại");

            if ((spear + sword + axe + scout + light + heavy + ram + catapult + noble) == 0)
                throw new Exception("Nhập một loại quân");

            from.Update(DateTime.Now, session);
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
            attack.LandingTime = Map.LandingTime(type, attack.From.X, attack.From.Y, attack.To.X, attack.To.Y, attack.StartTime);
            attack.Type = MoveType.Attack;
            attack.Building = building;

            from.Spear -= spear;
            from.Sword -= sword;
            from.Axe -= axe;
            from.Scout -= scout;
            from.Light -= light;
            from.Heavy -= heavy;
            from.Ram -= ram;
            from.Catapult -= catapult;
            from.Noble -= noble;

            session.Save(attack);
            session.Update(from);
            return attack;
        }
        #endregion

        #region Methods


        //chưa xét trường hợp phá tường, phá nhà
        public override void effect(ISession session)
        {
            AttackReport report = new AttackReport();
            report.Time = this.LandingTime;
            report.Title = this.From.Owner.Username + " tấn công " + this.To.Name + "(" + this.To.X.ToString() + "|" + this.To.Y.ToString() + ")";
            report.From = this.From;
            report.To = this.To;
            
            report.SpearSent = this.Spear;
            report.SwordSent = this.Sword;
            report.AxeSent = this.Axe;
            report.ScoutSent = this.Scout;
            report.LightSent = this.Light;
            report.HeavySent = this.Heavy;
            report.RamSent = this.Ram;
            report.CatapultSent = this.Catapult;
            report.NobleSent = this.Noble;

            report.SpearDefense = this.To.TotalSpear;
            report.SwordDefense = this.To.TotalSword;
            report.AxeDefense = this.To.TotalAxe;
            report.ScoutDefense = this.To.TotalScout;
            report.LightDefense = this.To.TotalLight;
            report.HeavyDefense = this.To.TotalHeavy;
            report.RamDefense = this.To.TotalRam;
            report.CatapultDefense = this.To.TotalCatapult;
            report.NobleDefense = this.To.TotalNoble;

            report.LoyalAfter = this.To.Loyal;
            report.Building = this.Building;
            report.BuildingAfter = this.To[this.Building];
            
            

            Random r = new Random();
            double luck = r.NextDouble();
            int infantryAttack = this.Spear * 10 + this.Sword * 25 + this.Axe * 40 + this.Noble * 30;
            int cavalryAttack = this.Light * 130 + this.Heavy * 150;
            int totalAttack = infantryAttack + cavalryAttack;

            double pInfantry = (double)infantryAttack / (double)totalAttack;
            double pCavalry = (double)cavalryAttack / (double)totalAttack;

            int infantryDefense = this.To.TotalSpear * 15 + this.To.TotalSword * 50 + this.To.TotalAxe * 10 + this.To.TotalLight * 30 + this.To.TotalHeavy * 200 + this.To.TotalNoble * 100;
            int cavalryDefense = this.To.TotalSpear * 45 + this.To.TotalSword * 15 + this.To.TotalAxe * 5 + this.To.TotalLight * 40 + this.To.TotalHeavy * 80 + this.To.TotalNoble * 50;
            int totalDefense = (int)(infantryDefense * pInfantry + cavalryDefense * pCavalry) + 100;

            totalAttack = (totalAttack / totalDefense) * totalAttack;
            totalAttack += (int)(totalAttack * luck);

            double ratio;
            Player owner = this.To.Owner;
            if (totalAttack > totalDefense)
            {
                ratio = 1 - ((double)totalDefense / (double)totalAttack);

                this.Spear = (int)Math.Round(this.Spear*ratio);
                this.Sword = (int)Math.Round(this.Sword * ratio);
                this.Axe = (int)Math.Round(this.Axe * ratio);
                this.Light = (int)Math.Round(this.Light * ratio);
                this.Scout = (int)Math.Round(this.Scout * ratio);
                this.Heavy = (int)Math.Round(this.Heavy * ratio);
                this.Ram = (int)Math.Round(this.Ram * ratio);
                this.Catapult = (int)Math.Round(this.Catapult * ratio);
                this.Noble = (int)Math.Round(this.Noble * ratio);
                this.To.StationedTroops.Clear();

                this.To.Spear = 0;
                this.To.Sword = 0;
                this.To.Axe = 0;
                this.To.Scout = 0;
                this.To.Light = 0;
                this.To.Heavy = 0;
                this.To.Ram = 0;
                this.To.Catapult = 0;
                this.To.Noble = 0;

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
                    returnTroop.Spear = this.Spear;
                    returnTroop.Sword = this.Sword;
                    returnTroop.Axe = this.Axe;
                    returnTroop.Scout = this.Scout;
                    returnTroop.Light = this.Light;
                    returnTroop.Heavy = this.Heavy;
                    returnTroop.Ram = this.Ram;
                    returnTroop.Catapult = this.Catapult;
                    returnTroop.Noble = this.Noble;

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

                    session.Save(returnTroop);
                    #endregion
                }

            }
            else
            {
                if (totalAttack == 0)
                    totalAttack = 1;
                ratio = 1 - ((double)totalAttack / (double)totalDefense);

                this.To.Spear = (int)Math.Round(this.To.Spear*ratio);
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

            


            report.Owner = this.From.Owner;
            session.Save(report);
            report.Owner = owner;
            session.Save(report);
        }

        #endregion
    }
}
