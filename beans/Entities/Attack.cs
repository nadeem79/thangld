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
        
        private BuildingType building;

        private int scoutSent;
        private int spearSent;
        private int swordSent;
        private int axeSent;
        private int lightSent;
        private int heavySent;
        private int ramSent;
        private int catapultSent;
        private int nobleSent;
        
        #endregion

        #region Properties

        public virtual BuildingType Building
        {
            get { return building; }
            set { building = value; }
        }

        public virtual int Spear
        {
            get { return spearSent; }
            set { spearSent = value; }
        }

        public virtual int Sword
        {
            get { return swordSent; }
            set { swordSent = value; }
        }

        public virtual int Axe
        {
            get { return axeSent; }
            set { axeSent = value; }
        }

        public virtual int Scout
        {
            get { return scoutSent; }
            set { scoutSent = value; }
        }

        public virtual int Light
        {
            get { return lightSent; }
            set { lightSent = value; }
        }

        public virtual int Heavy
        {
            get { return heavySent; }
            set { heavySent = value; }
        }

        public virtual int Ram
        {
            get { return ramSent; }
            set { ramSent = value; }
        }

        public virtual int Catapult
        {
            get { return catapultSent; }
            set { catapultSent = value; }
        }

        public virtual int Noble
        {
            get { return nobleSent; }
            set { nobleSent = value; }
        }

        public override MoveType Type
        {
            get
            {
                return MoveType.Attack;
            }
        }

        #endregion

        #region Constructors
        public Attack()
        {

        }

        #endregion

        #region Methods


        //chưa xét trường hợp phá tường, phá nhà
        public override void effect(Village village, ISession session)
        {
            AttackReport report = new AttackReport();
            report.Time = this.LandingTime;
            report.Title = this.From.Owner.Username + " tấn công " + this.To.Name + "(" + this.To.X.ToString() + "|" + this.To.Y.ToString() + ")";
            report.From = this.From;
            report.To = village;
            
            report.SpearSent = this.Spear;
            report.SwordSent = this.Sword;
            report.AxeSent = this.Axe;
            report.ScoutSent = this.Scout;
            report.LightSent = this.Light;
            report.HeavySent = this.Heavy;
            report.RamSent = this.Ram;
            report.CatapultSent = this.Catapult;
            report.NobleSent = this.Noble;

            report.SpearDefense = village.TotalSpear;
            report.SwordDefense = village.TotalSword;
            report.AxeDefense = village.TotalAxe;
            report.ScoutDefense = village.TotalScout;
            report.LightDefense = village.TotalLight;
            report.HeavyDefense = village.TotalHeavy;
            report.RamDefense = village.TotalRam;
            report.CatapultDefense = village.TotalCatapult;
            report.NobleDefense = village.TotalNoble;

            report.LoyalAfter = village.Loyal;
            report.Building = this.Building;
            report.BuildingAfter = village[this.Building];
            
            

            Random r = new Random();
            double luck = r.NextDouble();
            int infantryAttack = this.Spear * 10 + this.Sword * 25 + this.Axe * 40 + this.Noble * 30;
            int cavalryAttack = this.Light * 130 + this.Heavy * 150;
            int totalAttack = infantryAttack + cavalryAttack;

            double pInfantry = (double)infantryAttack / (double)totalAttack;
            double pCavalry = (double)cavalryAttack / (double)totalAttack;

            int infantryDefense = village.TotalSpear * 15 + village.TotalSword * 50 + village.TotalAxe * 10 + village.TotalLight * 30 + village.TotalHeavy * 200 + village.TotalNoble * 100;
            int cavalryDefense = village.TotalSpear * 45 + village.TotalSword * 15 + village.TotalAxe * 5 + village.TotalLight * 40 + village.TotalHeavy * 80 + village.TotalNoble * 50;
            int totalDefense = (int)(infantryDefense * pInfantry + cavalryDefense * pCavalry) + 100;

            totalAttack = (totalAttack / totalDefense) * totalAttack;
            totalAttack += (int)(totalAttack * luck);

            double ratio;
            User owner = village.Owner;
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
                village.StationedTroops.Clear();

                village.Spear = 0;
                village.Sword = 0;
                village.Axe = 0;
                village.Scout = 0;
                village.Light = 0;
                village.Heavy = 0;
                village.Ram = 0;
                village.Catapult = 0;
                village.Noble = 0;

                if (this.Noble > 0)
                    village.Loyal -= (r.Next(15) + 20);
                if (village.Loyal <= 0)
                {
                    
                    village.Owner = this.From.Owner;
                    village.Loyal = 25;
                    foreach (Stationed station in village.TroopsOutside)
                        session.Delete(station);
                    village.TroopsOutside.Clear();


                    foreach (Stationed station in village.StationedTroops)
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
                    newStation.AtVillage = village;
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
                    int intTotalResource = village.Iron + village.Clay + village.Wood;

                    if (intTotalResource <= intCanHaul)
                    {
                        returnTroop.Clay = village.Clay;
                        returnTroop.Wood = village.Wood;
                        returnTroop.Iron = village.Iron;

                        village.Clay = village.Iron = village.Wood = 0;
                    }
                    else
                    {
                        returnTroop.Clay = (int)((double)village.Clay * (double)intCanHaul / (double)intTotalResource);
                        returnTroop.Wood = (int)((double)village.Wood * (double)intCanHaul / (double)intTotalResource);
                        returnTroop.Iron = (int)((double)village.Iron * (double)intCanHaul / (double)intTotalResource);

                        village.Clay -= returnTroop.Clay;
                        village.Wood -= returnTroop.Wood;
                        village.Iron -= returnTroop.Iron;
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

                foreach (Stationed station in village.StationedTroops)
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
