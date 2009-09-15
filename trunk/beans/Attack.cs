using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using NHibernate.Linq;
using System.Data;

namespace beans
{
    public class Attack : MovingCommand
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
        public virtual BuildingType Building
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
                throw new TribalWarsException("Không đủ quân");

            if (this.Hero != null)
            {
                if (!this.FromVillage.Heroes.Contains(this.Hero))
                    throw new TribalWarsException("Không tồn tại hero trong thành phố");
                else if (this.FromVillage.MainHero == this.Hero)
                    throw new TribalWarsException("Không thể đưa chủ thành đi tấn công");
            }
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
            this.FromVillage.VillageTroopData.LightCavalryInVillage -= this.LightCavalry;
            this.FromVillage.VillageTroopData.HeavyCavalryInVillage -= this.HeavyCavalry;
            this.FromVillage.VillageTroopData.RamInVillage -= this.Ram;
            this.FromVillage.VillageTroopData.CatapultInVillage -= this.Catapult;
            this.FromVillage.VillageTroopData.NobleInVillage -= this.Noble;
            if (this.Hero != null)
            {
                this.FromVillage.Heroes.Remove(this.Hero);
                this.Hero.InVillage = null;
                this.Hero.InMovingCommand = this;
                session.Update(this.Hero);
            }
            
            this.FromVillage.MovingCommandsFromMe.Add(this);
            this.ToVillage.MovingCommandsToMe.Add(this);
            
            session.Save(this);
            session.Update(this.FromVillage);
            session.Update(this.ToVillage);


        }

        public override MovingCommand Cancel(ISession session)
        {
            Return returnTroop = new Return();
            returnTroop.Spear = this.Spear;
            returnTroop.Sword = this.Sword;
            returnTroop.Axe = this.Axe;
            returnTroop.Scout = this.Scout;
            returnTroop.LightCavalry = this.LightCavalry;
            returnTroop.HeavyCavalry = this.HeavyCavalry;
            returnTroop.Ram = this.Ram;
            returnTroop.Catapult = this.Catapult;
            returnTroop.Noble = this.Noble;

            returnTroop.StartingTime = returnTroop.LandingTime = DateTime.Now;
            returnTroop.LandingTime += (DateTime.Now - this.StartingTime);

            this.FromVillage.MovingCommandsFromMe.Remove(this);
            this.FromVillage.MovingCommandsToMe.Add(returnTroop);
            this.ToVillage.MovingCommandsToMe.Remove(this);
            this.ToVillage.MovingCommandsFromMe.Add(returnTroop);
            if (this.Hero != null)
            {
                this.Hero.InMovingCommand = returnTroop;
                returnTroop.Hero = this.Hero;
                session.Update(this.Hero);
                this.Hero = null;
            }

            session.Delete(this);
            session.Save(returnTroop);
            session.Update(this.ToVillage);
            session.Update(this.FromVillage);

            return returnTroop;
        }

        ///<summary>
        /// Chưa xử lý trường hợp có catapult
        ///</summary>
        ///<remarks>
        /// This is a test.
        ///</remarks>
        public override MovingCommand Effect(ISession session)
        {


            #region Data Declaration


            double luck, ratio;
            int spearLostInAttackSide;
            int swordLostInAttackSide;
            int axeLostInAttackSide;
            int scoutLostInAttackSide;
            int lightCavalryLostInAttackSide;
            int heavyCavalryLostInAttackSide;
            int ramLostInAttackSide;
            int catapultLostInAttackSide;
            int nobleLostInAttackSide;

            int spearLostInDefenseSide;
            int swordLostInDefenseSide;
            int axeLostInDefenseSide;
            int scoutLostInDefenseSide;
            int lightCavalryLostInDefenseSide;
            int heavyCavalryLostInDefenseSide;
            int ramLostInDefenseSide;
            int catapultLostInDefenseSide;
            int nobleLostInDefenseSide;

            Configuration config = Configuration.TribalWarsConfiguration;
            double spearDamage = config.GetNumericConfigurationItem("Unit.spear_damage").Value;
            double swordDamage = config.GetNumericConfigurationItem("Unit.sword_damage").Value;
            double axeDamage = config.GetNumericConfigurationItem("Unit.axe_damage").Value;
            double lightCavalryDamage = config.GetNumericConfigurationItem("Unit.light_cavalry_damage").Value;
            double heavyCavalryDamage = config.GetNumericConfigurationItem("Unit.heavy_cavalry_damage").Value;
            double scoutDamage = config.GetNumericConfigurationItem("Unit.scout_damage").Value;
            double ramDamage = config.GetNumericConfigurationItem("Unit.ram_damage").Value;
            double catapultDamage = config.GetNumericConfigurationItem("Unit.catapult_damage").Value;
            double nobleDamage = config.GetNumericConfigurationItem("Unit.noble_damage").Value;

            double spearInfantryDefense = config.GetNumericConfigurationItem("Unit.spear_infantry_defense").Value;
            double swordInfantryDefense = config.GetNumericConfigurationItem("Unit.sword_infantry_defense").Value;
            double axeInfantryDefense = config.GetNumericConfigurationItem("Unit.axe_infantry_defense").Value;
            double lightCavalryInfantryDefense = config.GetNumericConfigurationItem("Unit.light_cavalry_infantry_defense").Value;
            double heavyCavalryInfantryDefense = config.GetNumericConfigurationItem("Unit.heavy_cavalry_infantry_defense").Value;
            double scoutInfantryDefense = config.GetNumericConfigurationItem("Unit.scout_infantry_defense").Value;
            double ramInfantryDefense = config.GetNumericConfigurationItem("Unit.ram_infantry_defense").Value;
            double catapultInfantryDefense = config.GetNumericConfigurationItem("Unit.catapult_infantry_defense").Value;
            double nobleInfantryDefense = config.GetNumericConfigurationItem("Unit.noble_infantry_defense").Value;

            double spearCavalryDefense = config.GetNumericConfigurationItem("Unit.spear_cavalry_defense").Value;
            double swordCavalryDefense = config.GetNumericConfigurationItem("Unit.sword_cavalry_defense").Value;
            double axeCavalryDefense = config.GetNumericConfigurationItem("Unit.axe_cavalry_defense").Value;
            double lightCavalryCavalryDefense = config.GetNumericConfigurationItem("Unit.light_cavalry_cavalry_defense").Value;
            double heavyCavalryCavalryDefense = config.GetNumericConfigurationItem("Unit.heavy_cavalry_cavalry_defense").Value;
            double scoutCavalryDefense = config.GetNumericConfigurationItem("Unit.scout_cavalry_defense").Value;
            double ramCavalryDefense = config.GetNumericConfigurationItem("Unit.ram_cavalry_defense").Value;
            double catapultCavalryDefense = config.GetNumericConfigurationItem("Unit.catapult_cavalry_defense").Value;
            double nobleCavalryDefense = config.GetNumericConfigurationItem("Unit.noble_cavalry_defense").Value;

            double spearHaul = config.GetNumericConfigurationItem("Unit.spear_can_haul").Value;
            double swordHaul = config.GetNumericConfigurationItem("Unit.sword_can_haul").Value;
            double axeHaul = config.GetNumericConfigurationItem("Unit.axe_can_haul").Value;
            double lightCavalryHaul = config.GetNumericConfigurationItem("Unit.light_cavalry_can_haul").Value;
            double heavyCavalryHaul = config.GetNumericConfigurationItem("Unit.heavy_cavalry_can_haul").Value;

            Return returnTroop = null;
            AttackReport attackReport;
            DefenseReport defenseReport;

            IList<Station> stations;
            //IList<Village> villages;
            #endregion


            #region Report
            attackReport = new AttackReport();
            attackReport.Time = this.LandingTime;
            attackReport.Owner = this.FromVillage.Player;
            attackReport.Title = string.Format("{0} tấn công {1} ({2}|{3})", this.FromVillage.Player.Username, this.ToVillage.Name, this.ToVillage.X.ToString("000"), this.ToVillage.Y.ToString("000"));
            defenseReport = new DefenseReport();
            defenseReport.Time = this.LandingTime;
            defenseReport.Owner = this.ToVillage.Player;
            defenseReport.Title = attackReport.Title;

            attackReport.FromVillage = this.FromVillage;
            attackReport.FromPlayer = this.FromVillage.Player;
            attackReport.ToVillage = this.ToVillage;
            attackReport.ToPlayer = this.ToVillage.Player;
            defenseReport.FromVillage = this.FromVillage;
            defenseReport.FromPlayer = this.FromVillage.Player;
            defenseReport.ToVillage = this.ToVillage;
            defenseReport.ToPlayer = this.ToVillage.Player;

            attackReport.SpearSent = this.Spear;
            attackReport.SwordSent = this.Sword;
            attackReport.AxeSent = this.Axe;
            attackReport.ScoutSent = this.Scout;
            attackReport.LightCavalrySent = this.LightCavalry;
            attackReport.HeavyCavalrySent = this.HeavyCavalry;
            attackReport.RamSent = this.Ram;
            attackReport.CatapultSent = this.Catapult;
            attackReport.NobleSent = this.Noble;
            defenseReport.SpearSent = this.Spear;
            defenseReport.SwordSent = this.Sword;
            defenseReport.AxeSent = this.Axe;
            defenseReport.ScoutSent = this.Scout;
            defenseReport.LightCavalrySent = this.LightCavalry;
            defenseReport.HeavyCavalrySent = this.HeavyCavalry;
            defenseReport.RamSent = this.Ram;
            defenseReport.CatapultSent = this.Catapult;
            defenseReport.NobleSent = this.Noble;

            attackReport.SpearDefense = this.ToVillage.VillageTroopData.SpearInVillage;
            attackReport.SwordDefense = this.ToVillage.VillageTroopData.SwordInVillage;
            attackReport.AxeDefense = this.ToVillage.VillageTroopData.AxeInVillage;
            attackReport.ScoutDefense = this.ToVillage.VillageTroopData.ScoutInVillage;
            attackReport.LightCavalryDefense = this.ToVillage.VillageTroopData.LightCavalryInVillage;
            attackReport.HeavyCavalryDefense = this.ToVillage.VillageTroopData.HeavyCavalryInVillage;
            attackReport.RamDefense = this.ToVillage.VillageTroopData.RamInVillage;
            attackReport.CatapultDefense = this.ToVillage.VillageTroopData.CatapultInVillage;
            attackReport.NobleDefense = this.ToVillage.VillageTroopData.NobleInVillage;
            defenseReport.SpearDefense = this.ToVillage.VillageTroopData.SpearInVillage;
            defenseReport.SwordDefense = this.ToVillage.VillageTroopData.SwordInVillage;
            defenseReport.AxeDefense = this.ToVillage.VillageTroopData.AxeInVillage;
            defenseReport.ScoutDefense = this.ToVillage.VillageTroopData.ScoutInVillage;
            defenseReport.LightCavalryDefense = this.ToVillage.VillageTroopData.LightCavalryInVillage;
            defenseReport.HeavyCavalryDefense = this.ToVillage.VillageTroopData.HeavyCavalryInVillage;
            defenseReport.RamDefense = this.ToVillage.VillageTroopData.RamInVillage;
            defenseReport.CatapultDefense = this.ToVillage.VillageTroopData.CatapultInVillage;
            defenseReport.NobleDefense = this.ToVillage.VillageTroopData.NobleInVillage;

            attackReport.LoyalBefore = (int)this.ToVillage.Loyal;
            attackReport.Building = this.Building;
            attackReport.BuildingBefore = this.ToVillage[this.Building];
            attackReport.WallBefore = this.ToVillage[BuildingType.Wall];
            defenseReport.LoyalBefore = (int)this.ToVillage.Loyal;
            defenseReport.Building = this.Building;
            defenseReport.BuildingBefore = this.ToVillage[this.Building];
            defenseReport.WallBefore = this.ToVillage[BuildingType.Wall];

            #endregion
            int attackBonus = this.FromVillage.VillageResearchData.Attack;
            int defenseBonus = this.ToVillage.VillageResearchData.Defense;
            int attackLevel = this.FromVillage.VillageResearchData.Attack + ((this.Hero==null)?0:this.Hero.Attack);
            int defenseLevel = this.ToVillage.VillageResearchData.Defense +((this.ToVillage.MainHero==null)?0:this.ToVillage.MainHero.Defense);

            Random r = new Random();
            luck = 0.3 * (2 * r.NextDouble() - 1);
            double infantryAttack = this.Spear * spearDamage + this.Sword * swordDamage + this.Axe * axeDamage + this.Noble * nobleDamage;
            double cavalryAttack = this.LightCavalry * lightCavalryDamage + this.HeavyCavalry * heavyCavalryDamage;
            double totalAttack = infantryAttack + cavalryAttack;
            totalAttack += totalAttack * Research.AttackValuesDictionary[attackLevel];
            double scoutAttack = this.Scout * scoutDamage;
            scoutAttack += scoutAttack * Research.AttackValuesDictionary[attackLevel];
            double ramAttack = this.Ram * ramDamage;
            ramAttack += ramAttack * Research.AttackValuesDictionary[attackLevel];

            double pInfantry = (double)infantryAttack / (double)totalAttack;
            double pCavalry = (double)cavalryAttack / (double)totalAttack;
            

            double infantryDefense = this.ToVillage.VillageTroopData.SpearInVillage * spearInfantryDefense + this.ToVillage.VillageTroopData.SwordInVillage * swordInfantryDefense + this.ToVillage.VillageTroopData.AxeInVillage * axeInfantryDefense + this.ToVillage.VillageTroopData.LightCavalryInVillage * lightCavalryInfantryDefense + this.ToVillage.VillageTroopData.HeavyCavalryInVillage * heavyCavalryInfantryDefense + this.ToVillage.VillageTroopData.NobleInVillage * nobleInfantryDefense;
            double cavalryDefense = this.ToVillage.VillageTroopData.SpearInVillage * spearCavalryDefense + this.ToVillage.VillageTroopData.SwordInVillage * swordCavalryDefense + this.ToVillage.VillageTroopData.AxeInVillage * axeCavalryDefense + this.ToVillage.VillageTroopData.LightCavalryInVillage * lightCavalryCavalryDefense + this.ToVillage.VillageTroopData.HeavyCavalryInVillage * heavyCavalryCavalryDefense + this.ToVillage.VillageTroopData.NobleInVillage * nobleCavalryDefense;
            double scoutDefense = this.ToVillage[TroopType.Scout] * scoutCavalryDefense;
            scoutDefense += scoutDefense * Research.DefenseValuesDictionary[defenseLevel];
            double wallDefense = 0;
            for (int i = 1; i <= this.ToVillage.VillageBuildingData.Wall; i++)
            {
                wallDefense += Build.GetPrice(BuildingType.Wall, i, 1).BuildTime;
                wallDefense /= 100000;
            }
            wallDefense += wallDefense * Research.DefenseValuesDictionary[defenseLevel];
            double totalDefense = (long)(infantryDefense * pInfantry + cavalryDefense * pCavalry) + this.ToVillage.VillageBuildingData.BasicDefense + 1;
            totalDefense += totalDefense * this.ToVillage.VillageBuildingData.Fortified;
            totalDefense += totalDefense * Research.DefenseValuesDictionary[defenseLevel];
            
            double luckHeroes = luck;
            if (this.Hero != null)
                luckHeroes += 0.001 * this.Hero.Luck;
            if (this.ToVillage.MainHero != null)
                luckHeroes -= 0.001 * this.ToVillage.MainHero.Luck;

            scoutAttack += (long)(scoutAttack * luckHeroes);
            totalAttack += (long)(totalAttack * luckHeroes);
            ramAttack += (long)(ramAttack * luckHeroes);
            if (totalAttack > totalDefense)
            {
                totalAttack = ((totalAttack - totalDefense) / (totalAttack) + 1) * totalAttack;
                ramDamage = ((totalAttack - totalDefense) / (totalAttack) + 1) * ramDamage;
            }
            else
            {
                totalDefense = ((totalDefense - totalAttack) / (totalDefense) + 1) * totalDefense;
                ramDamage = ((totalDefense - totalAttack) / (totalDefense) + 1) * ramDamage;
            }
            //totalAttack = (totalAttack / totalDefense) * totalAttack;

            if (this.Ram > 0)
            {
                bool change = false;
                double damaged = wallDefense - ramAttack;
                double hp = 0;
                for (int i = 1; i <= this.ToVillage[BuildingType.Wall]; i++)
                {
                    hp += Build.GetPrice(BuildingType.Wall, i, 1).BuildTime;
                    if (hp > damaged)
                    {
                        if (this.ToVillage.VillageBuildingData.Wall != (i - 1))
                        {
                            this.ToVillage.VillageBuildingData.Wall = i - 1;
                            change = true;
                        }
                        break;
                    }
                    //if (this.)
                }

                defenseReport.WallAfter = this.ToVillage[BuildingType.Wall];
                attackReport.WallAfter = this.ToVillage[BuildingType.Wall];

                if (change)
                {
                    
                    totalAttack = infantryAttack + cavalryAttack;
                    totalAttack += totalAttack * Research.AttackValuesDictionary[attackLevel];
                    totalDefense = (long)(infantryDefense * pInfantry + cavalryDefense * pCavalry) + this.ToVillage.VillageBuildingData.BasicDefense + 1;
                    totalDefense += totalDefense * this.ToVillage.VillageBuildingData.Fortified;
                    totalDefense += totalDefense * Research.DefenseValuesDictionary[defenseLevel];

                    if (totalAttack > totalDefense)
                        totalAttack = ((totalAttack - totalDefense) / (totalAttack) + 1) * totalAttack;
                    else
                        totalDefense = ((totalDefense - totalAttack) / (totalDefense) + 1) * totalDefense;
                }

            }

            bool successAttack = (totalAttack > totalDefense);

            attackReport.Luck = luck;
            attackReport.SuccessAttack = successAttack;
            defenseReport.Luck = luck;
            defenseReport.SuccessAttack = successAttack;

            if (scoutAttack > scoutDefense)
                scoutLostInAttackSide = (int)Math.Round(this.Scout * ((scoutAttack - scoutDefense) / scoutAttack));
            else if (scoutAttack < scoutDefense)
                scoutLostInAttackSide = this.Scout - (int)Math.Round(this.Scout * ((scoutDefense - scoutAttack) / scoutDefense));
            else
                scoutLostInAttackSide = (int)Math.Round(0.5 * this.Scout);

            if (successAttack) // quân tấn công thắng
            {
                #region Quân tấn công thắng
                ratio = 1 - ((double)totalDefense / (double)totalAttack);

                spearLostInAttackSide = (int)Math.Round(this.Spear * (1 - ratio));
                swordLostInAttackSide = (int)Math.Round(this.Sword * (1 - ratio));
                axeLostInAttackSide = (int)Math.Round(this.Axe * (1 - ratio));
                lightCavalryLostInAttackSide = (int)Math.Round(this.LightCavalry * (1 - ratio));
                heavyCavalryLostInAttackSide = (int)Math.Round(this.HeavyCavalry * (1 - ratio));
                ramLostInAttackSide = (int)Math.Round(this.Ram * (1 - ratio));
                catapultLostInAttackSide = (int)Math.Round(this.Catapult * (1 - ratio));
                nobleLostInAttackSide = (int)Math.Round(this.Noble * (1 - ratio));
                

                spearLostInDefenseSide = this.ToVillage.VillageTroopData.SpearInVillage;
                swordLostInDefenseSide = this.ToVillage.VillageTroopData.SwordInVillage;
                axeLostInDefenseSide = this.ToVillage.VillageTroopData.AxeInVillage;
                lightCavalryLostInDefenseSide = this.ToVillage.VillageTroopData.LightCavalryInVillage;
                heavyCavalryLostInDefenseSide = this.ToVillage.VillageTroopData.HeavyCavalryInVillage;
                ramLostInDefenseSide = this.ToVillage.VillageTroopData.RamInVillage;
                catapultLostInDefenseSide = this.ToVillage.VillageTroopData.CatapultInVillage;
                scoutLostInDefenseSide = this.ToVillage.VillageTroopData.ScoutInVillage;
                nobleLostInDefenseSide = this.ToVillage.VillageTroopData.NobleInVillage;

                this.FromVillage.VillageTroopData.SpearOfVillage -= spearLostInAttackSide;
                this.FromVillage.VillageTroopData.SwordOfVillage -= swordLostInAttackSide;
                this.FromVillage.VillageTroopData.AxeOfVillage -= axeLostInAttackSide;
                this.FromVillage.VillageTroopData.ScoutOfVillage -= scoutLostInAttackSide;
                this.FromVillage.VillageTroopData.LightCavalryOfVillage -= lightCavalryLostInAttackSide;
                this.FromVillage.VillageTroopData.HeavyCavalryOfVillage -= heavyCavalryLostInAttackSide;
                this.FromVillage.VillageTroopData.RamOfVillage -= ramLostInAttackSide;
                this.FromVillage.VillageTroopData.CatapultOfVillage -= catapultLostInAttackSide;
                this.FromVillage.VillageTroopData.NobleOfVillage -= nobleLostInAttackSide;
                
                this.ToVillage.VillageTroopData.SpearOfVillage -= this.ToVillage.VillageTroopData.Spear;
                this.ToVillage.VillageTroopData.SwordOfVillage -= this.ToVillage.VillageTroopData.Sword;
                this.ToVillage.VillageTroopData.AxeOfVillage -= this.ToVillage.VillageTroopData.Axe;
                this.ToVillage.VillageTroopData.ScoutOfVillage -= this.ToVillage.VillageTroopData.Scout;
                this.ToVillage.VillageTroopData.LightCavalryOfVillage -= this.ToVillage.VillageTroopData.LightCavalry;
                this.ToVillage.VillageTroopData.HeavyCavalryOfVillage -= this.ToVillage.VillageTroopData.HeavyCavalry;
                this.ToVillage.VillageTroopData.RamOfVillage -= this.ToVillage.VillageTroopData.Ram;
                this.ToVillage.VillageTroopData.CatapultOfVillage -= this.ToVillage.VillageTroopData.Catapult;
                this.ToVillage.VillageTroopData.NobleOfVillage -= this.ToVillage.VillageTroopData.Noble;

                this.ToVillage.VillageTroopData.SpearInVillage = this.ToVillage.VillageTroopData.Spear = 0;
                this.ToVillage.VillageTroopData.SwordInVillage = this.ToVillage.VillageTroopData.Sword = 0;
                this.ToVillage.VillageTroopData.AxeInVillage = this.ToVillage.VillageTroopData.Axe = 0;
                this.ToVillage.VillageTroopData.ScoutInVillage = this.ToVillage.VillageTroopData.Scout = 0;
                this.ToVillage.VillageTroopData.LightCavalryInVillage = this.ToVillage.VillageTroopData.LightCavalry = 0;
                this.ToVillage.VillageTroopData.HeavyCavalryInVillage = this.ToVillage.VillageTroopData.HeavyCavalry = 0;
                this.ToVillage.VillageTroopData.RamInVillage = this.ToVillage.VillageTroopData.Ram = 0;
                this.ToVillage.VillageTroopData.CatapultInVillage = this.ToVillage.VillageTroopData.Catapult = 0;
                this.ToVillage.VillageTroopData.NobleInVillage = this.ToVillage.VillageTroopData.Noble = 0;

                foreach (Station station in this.ToVillage.StationsAtMe) //xoá tất cả station đang đóng ở thành phố đó
                {
                    station.AtVillage.VillageCommonMethods.UpdateVillage(this.LandingTime, session, false);
                    DefenseOtherReport defenseOtherReport = new DefenseOtherReport();
                    defenseOtherReport.Owner = station.FromVillage.Player;
                    defenseOtherReport.Time = this.LandingTime;
                    defenseOtherReport.Unread = true;
                    defenseOtherReport.Title = String.Format("Quân hỗ trợ của bạn từ {0} ở {1} bị tấn công", station.FromVillage.Name, station.AtVillage.Name);
                    defenseOtherReport.FromVillage = station.FromVillage;
                    defenseOtherReport.FromPlayer = this.FromVillage.Player;
                    defenseOtherReport.ToVillage = this.ToVillage;
                    defenseOtherReport.ToPlayer = this.ToVillage.Player;

                    defenseOtherReport.SpearDefense = station.Spear;
                    defenseOtherReport.SwordDefense = station.Sword;
                    defenseOtherReport.AxeDefense = station.Axe;
                    defenseOtherReport.ScoutDefense = station.Scout;
                    defenseOtherReport.LightCavalryDefense = station.LightCavalry;
                    defenseOtherReport.HeavyCavalryDefense = station.HeavyCavalry;
                    defenseOtherReport.RamDefense = station.Ram;
                    defenseOtherReport.CatapultDefense = station.Catapult;
                    defenseOtherReport.NobleDefense = station.Noble;

                    defenseOtherReport.SpearDead = station.Spear;
                    defenseOtherReport.SwordDead = station.Sword;
                    defenseOtherReport.AxeDead = station.Axe;
                    defenseOtherReport.ScoutDead = station.Scout;
                    defenseOtherReport.LightCavalryDead = station.LightCavalry;
                    defenseOtherReport.HeavyCavalryDead = station.HeavyCavalry;
                    defenseOtherReport.RamDead = station.Ram;
                    defenseOtherReport.CatapultDead = station.Catapult;
                    defenseOtherReport.NobleDead = station.Noble;

                    station.FromVillage.VillageTroopData.SpearOfVillage -= station.Spear;
                    station.FromVillage.VillageTroopData.SwordOfVillage -= station.Sword;
                    station.FromVillage.VillageTroopData.AxeOfVillage -= station.Axe;
                    station.FromVillage.VillageTroopData.ScoutOfVillage -= station.Scout;
                    station.FromVillage.VillageTroopData.LightCavalryOfVillage -= station.LightCavalry;
                    station.FromVillage.VillageTroopData.HeavyCavalryOfVillage -= station.HeavyCavalry;
                    station.FromVillage.VillageTroopData.RamOfVillage -= station.Ram;
                    station.FromVillage.VillageTroopData.CatapultOfVillage -= station.Catapult;
                    station.FromVillage.VillageTroopData.NobleOfVillage -= station.Noble;

                    station.FromVillage.StationsFromMe.Remove(station);

                    session.Update(station.FromVillage);
                    session.Save(defenseOtherReport);
                }
                this.ToVillage.StationsAtMe.Clear();
                //session.Delete("from Station station where station.AtVillage = :village", this.ToVillage, NHibernate.NHibernateUtil.Entity(typeof(Village)));
                IQuery queryDeleteStationAtMe = session.CreateQuery("delete from Station station where station.AtVillage = :village");
                queryDeleteStationAtMe.SetEntity("village", this.ToVillage);
                queryDeleteStationAtMe.ExecuteUpdate();
                if (this.Noble > 0)
                    this.ToVillage.Loyal -= (r.Next(15) + 20);

                if (this.ToVillage.Loyal <= 0)
                {
                    this.ToVillage.Player.Point -= this.ToVillage.Points;
                    this.FromVillage.Player.Point += this.ToVillage.Points;
                    this.ToVillage.Player = this.FromVillage.Player;
                    this.ToVillage.Loyal = 25;

                    stations = (from station in session.Linq<Station>()
                                where station.FromVillage == this.ToVillage
                                select station).ToList<Station>();

                    foreach (Station station in this.ToVillage.StationsFromMe)
                    {
                        station.AtVillage.VillageCommonMethods.UpdateVillage(this.LandingTime, session, false);

                        station.FromVillage.VillageTroopData.SpearOfVillage -= station.Spear;
                        station.FromVillage.VillageTroopData.SwordOfVillage -= station.Sword;
                        station.FromVillage.VillageTroopData.AxeOfVillage -= station.Axe;
                        station.FromVillage.VillageTroopData.ScoutOfVillage -= station.Scout;
                        station.FromVillage.VillageTroopData.LightCavalryOfVillage -= station.LightCavalry;
                        station.FromVillage.VillageTroopData.HeavyCavalryOfVillage -= station.HeavyCavalry;
                        station.FromVillage.VillageTroopData.RamOfVillage -= station.Ram;
                        station.FromVillage.VillageTroopData.CatapultOfVillage -= station.Catapult;
                        station.FromVillage.VillageTroopData.NobleOfVillage -= station.Noble;

                        station.AtVillage.StationsAtMe.Remove(station);
                        session.Update(station.FromVillage);

                    }
                    this.ToVillage.StationsFromMe.Clear();
                    IQuery queryDeleteStationFromMe = session.CreateQuery("delete from Station station where station.FromVillage = :village");
                    queryDeleteStationFromMe.SetEntity("village", this.ToVillage);
                    queryDeleteStationFromMe.ExecuteUpdate();

                    Station newStation = new Station();
                    newStation.AtVillage = this.ToVillage;
                    newStation.FromVillage = this.FromVillage;
                    newStation.Spear = this.Spear;
                    newStation.Sword = this.Sword;
                    newStation.Axe = this.Sword;
                    newStation.Scout = this.Scout;
                    newStation.LightCavalry = this.LightCavalry;
                    newStation.HeavyCavalry = this.HeavyCavalry;
                    newStation.Ram = this.Ram;
                    newStation.Catapult = this.Catapult;
                    newStation.Noble = this.Noble;

                    this.ToVillage.VillageTroopData.SpearInVillage = this.Spear - spearLostInAttackSide;
                    this.ToVillage.VillageTroopData.SwordInVillage = this.Sword - swordLostInAttackSide;
                    this.ToVillage.VillageTroopData.AxeInVillage = this.Axe - axeLostInAttackSide;
                    //this.ToVillage.VillageTroopData.ScoutInVillage = this.Scout - scoutLostInAttackSide;
                    this.ToVillage.VillageTroopData.LightCavalryInVillage = this.LightCavalry - lightCavalryLostInAttackSide;
                    this.ToVillage.VillageTroopData.HeavyCavalryInVillage = this.HeavyCavalry - heavyCavalryLostInAttackSide;
                    this.ToVillage.VillageTroopData.RamInVillage = this.Ram - ramLostInAttackSide;
                    this.ToVillage.VillageTroopData.CatapultInVillage = this.Catapult - catapultLostInAttackSide;
                    this.ToVillage.VillageTroopData.NobleInVillage = this.Noble - nobleLostInAttackSide;

                    this.ToVillage.StationsAtMe.Add(newStation);
                    this.FromVillage.StationsFromMe.Add(newStation);
                    session.Save(newStation);


                }
                else
                {
                    #region Quân thắng trận trở về

                    returnTroop = new Return();
                    returnTroop.FromVillage = this.ToVillage;
                    returnTroop.ToVillage = this.FromVillage;
                    returnTroop.Spear = this.Spear - spearLostInAttackSide;
                    returnTroop.Sword = this.Sword - swordLostInAttackSide;
                    returnTroop.Axe = this.Axe - axeLostInAttackSide;
                    returnTroop.Scout = this.Scout - scoutLostInAttackSide;
                    returnTroop.LightCavalry = this.LightCavalry - lightCavalryLostInAttackSide;
                    returnTroop.HeavyCavalry = this.HeavyCavalry - heavyCavalryLostInAttackSide;
                    returnTroop.Ram = this.Ram - ramLostInAttackSide;
                    returnTroop.Catapult = this.Catapult - catapultLostInAttackSide;
                    returnTroop.Noble = this.Noble - nobleLostInAttackSide;
                    returnTroop.StartingTime = this.LandingTime;

                    returnTroop.LandingTime = this.LandingTime + (this.LandingTime - this.StartingTime);

                    int intCanHaul = (int)(this.Spear * spearHaul + this.Sword * swordHaul + this.Axe * axeHaul + this.LightCavalry * lightCavalryHaul + this.HeavyCavalry * heavyCavalryHaul);
                    int intTotalResource = this.ToVillage.VillageResourceData.Iron + this.ToVillage.VillageResourceData.Clay + this.ToVillage.VillageResourceData.Wood;

                    if (intTotalResource <= intCanHaul)
                    {
                        returnTroop.Clay = this.ToVillage.VillageResourceData.Clay;
                        returnTroop.Wood = this.ToVillage.VillageResourceData.Wood;
                        returnTroop.Iron = this.ToVillage.VillageResourceData.Iron;

                        this.ToVillage.VillageResourceData.Clay = this.ToVillage.VillageResourceData.Wood = this.ToVillage.VillageResourceData.Iron = 0;
                    }
                    else
                    {
                        returnTroop.Clay = (int)((double)this.ToVillage.VillageResourceData.Clay * (double)intCanHaul / (double)intTotalResource);
                        returnTroop.Wood = (int)((double)this.ToVillage.VillageResourceData.Wood * (double)intCanHaul / (double)intTotalResource);
                        returnTroop.Iron = (int)((double)this.ToVillage.VillageResourceData.Iron * (double)intCanHaul / (double)intTotalResource);

                        this.ToVillage.VillageResourceData.Clay -= returnTroop.Clay;
                        this.ToVillage.VillageResourceData.Wood -= returnTroop.Wood;
                        this.ToVillage.VillageResourceData.Iron -= returnTroop.Iron;
                    }
                    this.ToVillage.MovingCommandsFromMe.Add(returnTroop);
                    this.FromVillage.MovingCommandsToMe.Add(returnTroop);
                    session.Save(returnTroop);

                    attackReport.Wood = returnTroop.Wood;
                    attackReport.Clay = returnTroop.Clay;
                    attackReport.Iron = returnTroop.Iron;
                    defenseReport.Wood = returnTroop.Wood;
                    defenseReport.Clay = returnTroop.Clay;
                    defenseReport.Iron = returnTroop.Iron;

                    #endregion
                }
                #endregion
            }
            else // quân tấn công thua
            {
                #region Quân tấn công thua
                if (totalAttack == 0)
                    totalAttack = 1;
                ratio = 1 - ((double)totalAttack / (double)totalDefense);

                spearLostInAttackSide = this.Spear;
                swordLostInAttackSide = this.Sword;
                axeLostInAttackSide = this.Axe;
                lightCavalryLostInAttackSide = this.LightCavalry;
                //scoutLostInAttackSide = this.Scout;
                heavyCavalryLostInAttackSide = this.HeavyCavalry;
                ramLostInAttackSide = this.Ram;
                catapultLostInAttackSide = this.Catapult;
                nobleLostInAttackSide = this.Noble;

                spearLostInDefenseSide = (int)(this.FromVillage.VillageTroopData.SpearInVillage * ratio);
                swordLostInDefenseSide = (int)(this.FromVillage.VillageTroopData.SwordInVillage * ratio);
                axeLostInDefenseSide = (int)(this.FromVillage.VillageTroopData.AxeInVillage * ratio);
                scoutLostInDefenseSide = (int)(this.FromVillage.VillageTroopData.ScoutInVillage * ratio);
                lightCavalryLostInDefenseSide = (int)(this.FromVillage.VillageTroopData.LightCavalryInVillage * ratio);
                heavyCavalryLostInDefenseSide = (int)(this.FromVillage.VillageTroopData.HeavyCavalryInVillage * ratio);
                ramLostInDefenseSide = (int)(this.FromVillage.VillageTroopData.RamInVillage * ratio);
                catapultLostInDefenseSide = (int)(this.FromVillage.VillageTroopData.CatapultInVillage * ratio);
                nobleLostInDefenseSide = (int)(this.FromVillage.VillageTroopData.NobleInVillage * ratio);

                this.FromVillage.VillageTroopData.SpearOfVillage -= this.Spear;
                this.FromVillage.VillageTroopData.SwordOfVillage -= this.Sword;
                this.FromVillage.VillageTroopData.AxeOfVillage -= this.Axe;
                this.FromVillage.VillageTroopData.LightCavalryOfVillage -= this.LightCavalry;
                this.FromVillage.VillageTroopData.ScoutOfVillage -= scoutLostInAttackSide;
                this.FromVillage.VillageTroopData.HeavyCavalryOfVillage -= this.HeavyCavalry;
                this.FromVillage.VillageTroopData.RamOfVillage -= this.Ram;
                this.FromVillage.VillageTroopData.CatapultOfVillage -= this.Catapult;
                this.FromVillage.VillageTroopData.NobleOfVillage -= this.Noble;

                this.ToVillage.VillageTroopData.SpearInVillage -= spearLostInDefenseSide;
                this.ToVillage.VillageTroopData.SwordInVillage -= swordLostInDefenseSide;
                this.ToVillage.VillageTroopData.AxeInVillage -= axeLostInDefenseSide;
                this.ToVillage.VillageTroopData.ScoutInVillage -= scoutLostInDefenseSide;
                this.ToVillage.VillageTroopData.LightCavalryInVillage -= lightCavalryLostInDefenseSide;
                this.ToVillage.VillageTroopData.HeavyCavalryInVillage -= heavyCavalryLostInDefenseSide;
                this.ToVillage.VillageTroopData.RamInVillage -= ramLostInDefenseSide;
                this.ToVillage.VillageTroopData.CatapultInVillage -= catapultLostInDefenseSide;
                this.ToVillage.VillageTroopData.NobleInVillage -= nobleLostInDefenseSide;

                int spearOfVillageLost = (int)Math.Round(this.ToVillage.VillageTroopData.Spear * (1 - ratio));
                int swordOfVillageLost = (int)Math.Round(this.ToVillage.VillageTroopData.Sword * (1 - ratio));
                int axeOfVillageLost = (int)Math.Round(this.ToVillage.VillageTroopData.Axe * (1 - ratio));
                int scoutOfVillageLost = (int)Math.Round(this.ToVillage.VillageTroopData.Scout * (1 - ratio));
                int lightCavalryOfVillageLost = (int)Math.Round(this.ToVillage.VillageTroopData.LightCavalry * (1 - ratio));
                int heavyCavalryOfVillageLost = (int)Math.Round(this.ToVillage.VillageTroopData.HeavyCavalry * (1 - ratio));
                int ramOfVillageLost = (int)Math.Round(this.ToVillage.VillageTroopData.Ram * (1 - ratio));
                int catapultOfVillageLost = (int)Math.Round(this.ToVillage.VillageTroopData.Catapult * (1 - ratio));
                int nobleOfVillageLost = (int)Math.Round(this.ToVillage.VillageTroopData.Noble * (1 - ratio));

                this.ToVillage.VillageTroopData.Spear -= spearOfVillageLost;
                this.ToVillage.VillageTroopData.Sword -= swordOfVillageLost;
                this.ToVillage.VillageTroopData.Axe -= axeOfVillageLost;
                this.ToVillage.VillageTroopData.LightCavalry -= lightCavalryOfVillageLost;
                this.ToVillage.VillageTroopData.Scout -= scoutOfVillageLost;
                this.ToVillage.VillageTroopData.HeavyCavalry -= heavyCavalryOfVillageLost;
                this.ToVillage.VillageTroopData.Ram -= ramOfVillageLost;
                this.ToVillage.VillageTroopData.Catapult -= catapultOfVillageLost;
                this.ToVillage.VillageTroopData.Noble -= nobleOfVillageLost;

                this.ToVillage.VillageTroopData.SpearOfVillage -= spearOfVillageLost;
                this.ToVillage.VillageTroopData.SwordOfVillage -= swordOfVillageLost;
                this.ToVillage.VillageTroopData.AxeOfVillage -= axeOfVillageLost;
                this.ToVillage.VillageTroopData.LightCavalryOfVillage -= lightCavalryOfVillageLost;
                this.ToVillage.VillageTroopData.ScoutOfVillage -= scoutOfVillageLost;
                this.ToVillage.VillageTroopData.HeavyCavalryOfVillage -= heavyCavalryOfVillageLost;
                this.ToVillage.VillageTroopData.RamOfVillage -= ramOfVillageLost;
                this.ToVillage.VillageTroopData.CatapultOfVillage -= catapultOfVillageLost;
                this.ToVillage.VillageTroopData.NobleOfVillage -= nobleOfVillageLost;

                if (scoutLostInAttackSide < this.Scout)
                {
                    returnTroop = new Return();
                    returnTroop.FromVillage = this.ToVillage;
                    returnTroop.ToVillage = this.FromVillage;
                    returnTroop.Scout = this.Scout - scoutLostInAttackSide;
                    returnTroop.StartingTime = this.LandingTime;
                    returnTroop.LandingTime = this.LandingTime + (this.LandingTime - this.StartingTime);

                    this.ToVillage.MovingCommandsFromMe.Add(returnTroop);
                    this.FromVillage.MovingCommandsToMe.Add(returnTroop);
                    session.Save(returnTroop);
                }

                foreach (Station station in this.ToVillage.StationsAtMe)
                {
                    DefenseOtherReport defenseOtherReport = null;
                    if (station.FromVillage.Player != this.ToVillage.Player)
                    {
                        defenseOtherReport = new DefenseOtherReport();
                        defenseOtherReport.SpearDefense = station.Spear;
                        defenseOtherReport.SwordDefense = station.Sword;
                        defenseOtherReport.AxeDefense = station.Axe;
                        defenseOtherReport.ScoutDefense = station.Scout;
                        defenseOtherReport.LightCavalryDefense = station.LightCavalry;
                        defenseOtherReport.HeavyCavalryDefense = station.HeavyCavalry;
                        defenseOtherReport.RamDefense = station.Ram;
                        defenseOtherReport.CatapultDefense = station.Catapult;
                        defenseOtherReport.NobleDefense = station.Noble;
                    }

                    int spearDead = (int)Math.Round(station.Spear * (1 - ratio));
                    int swordDead = (int)Math.Round(station.Sword * (1 - ratio));
                    int axeDead = (int)Math.Round(station.Axe * (1 - ratio));
                    int scoutDead = (int)Math.Round(station.Scout * (1 - ratio));
                    int lightCavalryDead = (int)Math.Round(station.LightCavalry * (1 - ratio));
                    int heavyCavalryDead = (int)Math.Round(station.HeavyCavalry * (1 - ratio));
                    int ramDead = (int)Math.Round(station.Ram * (1 - ratio));
                    int catapultDead = (int)Math.Round(station.Catapult * (1 - ratio));
                    int nobleDead = (int)Math.Round(station.Noble * (1 - ratio));

                    station.Spear -= spearDead;
                    station.Sword -= swordDead;
                    station.Axe -= axeDead;
                    station.LightCavalry -= scoutDead;
                    station.Scout -= lightCavalryDead;
                    station.HeavyCavalry -= heavyCavalryDead;
                    station.Ram -= ramDead;
                    station.Catapult -= catapultDead;
                    station.Noble -= nobleDead;

                    if (Utilities.IsGreaterThenZero(station.Spear,
                                                        station.Sword,
                                                        station.Axe,
                                                        station.Scout,
                                                        station.LightCavalry,
                                                        station.HeavyCavalry,
                                                        station.Ram,
                                                        station.Catapult,
                                                        station.Noble))
                        session.Update(station);
                    else
                    {
                        station.AtVillage.StationsAtMe.Remove(station);
                        station.FromVillage.StationsFromMe.Remove(station);
                        session.Delete(station);
                        session.Update(station.FromVillage);
                    }

                    #region tạo report
                    if (station.FromVillage.Player != this.ToVillage.Player)
                    {
                        defenseOtherReport.Time = this.LandingTime;
                        defenseOtherReport.Owner = station.FromVillage.Player;
                        defenseOtherReport.Title = "Quân phòng thủ của bạn ở " + this.ToVillage.Name + "(" + this.ToVillage.X.ToString() + "|" + this.ToVillage.Y.ToString() + ") bị tấn công";

                        defenseOtherReport.FromPlayer = station.FromVillage.Player;
                        defenseOtherReport.FromVillage = station.FromVillage;
                        defenseOtherReport.ToPlayer = station.AtVillage.Player;
                        defenseOtherReport.ToVillage = station.AtVillage;

                        defenseOtherReport.SpearDefense = station.Spear;
                        defenseOtherReport.SwordDefense = station.Sword;
                        defenseOtherReport.AxeDefense = station.Axe;
                        defenseOtherReport.ScoutDefense = station.Scout;
                        defenseOtherReport.LightCavalryDefense = station.LightCavalry;
                        defenseOtherReport.HeavyCavalryDefense = station.HeavyCavalry;
                        defenseOtherReport.RamDefense = station.Ram;
                        defenseOtherReport.CatapultDefense = station.Catapult;
                        defenseOtherReport.NobleDefense = station.Noble;

                        defenseOtherReport.SpearDead = spearDead;
                        defenseOtherReport.SwordDead = swordDead;
                        defenseOtherReport.AxeDead = axeDead;
                        defenseOtherReport.ScoutDead = scoutDead;
                        defenseOtherReport.LightCavalryDead = lightCavalryDead;
                        defenseOtherReport.HeavyCavalryDead = heavyCavalryDead;
                        defenseOtherReport.RamDead = ramDead;
                        defenseOtherReport.CatapultDead = catapultDead;
                        defenseOtherReport.NobleDead = nobleDead;

                        session.Save(defenseOtherReport);
                    }
                    #endregion



                }
                #endregion
            }

            attackReport.SpearAttackDead = spearLostInAttackSide;
            attackReport.SwordAttackDead = swordLostInAttackSide;
            attackReport.AxeAttackDead = axeLostInAttackSide;
            //attackReport.ScoutAttackDead = scoutLostInAttackSide;
            attackReport.LightCavalryAttackDead = lightCavalryLostInAttackSide;
            attackReport.HeavyCavalryAttackDead = heavyCavalryLostInAttackSide;
            attackReport.RamAttackDead = ramLostInAttackSide;
            attackReport.CatapultAttackDead = catapultLostInAttackSide;
            attackReport.NobleAttackDead = nobleLostInAttackSide;
            attackReport.SpearDefenseDead = spearLostInDefenseSide;
            attackReport.SwordDefenseDead = swordLostInDefenseSide;
            attackReport.AxeDefenseDead = axeLostInDefenseSide;
            attackReport.ScoutDefenseDead = scoutLostInDefenseSide = 0;
            attackReport.LightCavalryDefenseDead = lightCavalryLostInDefenseSide;
            attackReport.HeavyCavalryDefenseDead = heavyCavalryLostInDefenseSide;
            attackReport.RamDefenseDead = ramLostInDefenseSide;
            attackReport.CatapultDefenseDead = catapultLostInDefenseSide;
            attackReport.NobleDefenseDead = nobleLostInDefenseSide;

            defenseReport.SpearAttackDead = spearLostInAttackSide;
            defenseReport.SwordAttackDead = swordLostInAttackSide;
            defenseReport.AxeAttackDead = axeLostInAttackSide;
            //defenseReport.ScoutAttackDead = scoutLostInAttackSide;
            defenseReport.LightCavalryAttackDead = lightCavalryLostInAttackSide;
            defenseReport.HeavyCavalryAttackDead = heavyCavalryLostInAttackSide;
            defenseReport.RamAttackDead = ramLostInAttackSide;
            defenseReport.CatapultAttackDead = catapultLostInAttackSide;
            defenseReport.NobleAttackDead = nobleLostInAttackSide;
            defenseReport.SpearDefenseDead = spearLostInDefenseSide;
            defenseReport.SwordDefenseDead = swordLostInDefenseSide;
            defenseReport.AxeDefenseDead = axeLostInDefenseSide;
            defenseReport.ScoutDefenseDead = scoutLostInDefenseSide;
            defenseReport.LightCavalryDefenseDead = lightCavalryLostInDefenseSide;
            defenseReport.HeavyCavalryDefenseDead = heavyCavalryLostInDefenseSide;
            defenseReport.RamDefenseDead = ramLostInDefenseSide;
            defenseReport.CatapultDefenseDead = catapultLostInDefenseSide;
            defenseReport.NobleDefenseDead = nobleLostInDefenseSide;

            attackReport.LoyalAfter = (int)this.ToVillage.Loyal;
            attackReport.BuildingAfter = this.ToVillage[this.Building];
            defenseReport.LoyalAfter = (int)this.ToVillage.Loyal;
            defenseReport.BuildingAfter = this.ToVillage[this.Building];

            this.FromVillage.LastUpdate = this.ToVillage.LastUpdate = this.LandingTime;

            session.Update(this.ToVillage.Player);
            session.Update(this.FromVillage.Player);

            session.Save(attackReport);
            session.Save(defenseReport);

            this.ToVillage.MovingCommandsToMe.Remove(this);
            this.FromVillage.MovingCommandsFromMe.Remove(this);
            session.Delete(this);

            return returnTroop;
        }
    
        public override MoveType Type
        {
            get { return MoveType.Attack; }
        }
    }
}