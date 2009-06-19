using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Antlr.StringTemplate;
using NHibernate;
using NHibernate.Linq;

namespace beans
{
    public class Attack : MovingCommand
    {

        #region Properties
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
        #endregion

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

            session.Save(this);

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

            ITransaction transaction = session.BeginTransaction();
            try
            {
                session.Delete(this);
                session.Save(returnTroop);
                transaction.Commit();
            }
            catch
            {
                transaction.Rollback();
            }

            return returnTroop;
        }

        public override MovingCommand Effect(ISession session)
        {
            #region Data Declaration
            StringTemplateGroup group = new StringTemplateGroup("attack");
            StringTemplate temp = new StringTemplate(group, reports.Attack);
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

            Return returnTroop;
            Report attackSideReport, defenseSideReport;

            IList<Station> stations;
            IList<Village> villages;
            #region

            this.ToVillage.Update(this.LandingTime, session);

            #region Report
            attackSideReport = new Report();
            attackSideReport.Time = this.LandingTime;
            attackSideReport.Owner = this.FromVillage.Player;
            attackSideReport.Type = ReportType.Attack;
            attackSideReport.Title = string.Format("{0} tấn công {1} ({2}|{3})", this.FromVillage.Player.Username, this.ToVillage.Name, this.ToVillage.X.ToString("000"), this.ToVillage.Y.ToString("000"));

            defenseSideReport = new Report();
            defenseSideReport.Time = this.LandingTime;
            defenseSideReport.Owner = this.ToVillage.Player;
            defenseSideReport.Type = ReportType.Defense;
            defenseSideReport.Title = attackSideReport.Title;

            temp.SetAttribute("title", attackSideReport.Title);
            temp.SetAttribute("time", attackSideReport.Time.ToString("hh:mm:ss:'<span class=\"hidden\">'fff'</span>' 'ngày' dd/MM/yyyy"));

            temp.SetAttribute("attacker_name", this.FromVillage.Player.Username);
            temp.SetAttribute("attacker_id", this.FromVillage.Player.ID);
            temp.SetAttribute("attacker_village_name", this.FromVillage.Name);
            temp.SetAttribute("attacker_village_id", this.FromVillage.ID);
            temp.SetAttribute("attacker_village_x", this.FromVillage.X.ToString("000"));
            temp.SetAttribute("attacker_village_y", this.FromVillage.Y.ToString("000"));
            temp.SetAttribute("defender_name", this.ToVillage.Player.Username);
            temp.SetAttribute("defender_id", this.ToVillage.Player.ID);
            temp.SetAttribute("defender_village_name", this.ToVillage.Name);
            temp.SetAttribute("defender_village_id", this.ToVillage.ID);
            temp.SetAttribute("defender_village_x", this.ToVillage.X.ToString("000"));
            temp.SetAttribute("defender_village_y", this.ToVillage.Y.ToString("000"));

            temp.SetAttribute("SpearSent", (this.Spear > 0) ? this.Spear.ToString() : "<span class='hidden'>0</span>");
            temp.SetAttribute("SwordSent", (this.Sword > 0) ? this.Sword.ToString() : "<span class='hidden'>0</span>");
            temp.SetAttribute("AxeSent", (this.Axe > 0) ? this.Axe.ToString() : "<span class='hidden'>0</span>");
            temp.SetAttribute("ScoutSent", (this.Scout > 0) ? this.Scout.ToString() : "<span class='hidden'>0</span>");
            temp.SetAttribute("LightSent", (this.LightCavalry > 0) ? this.LightCavalry.ToString() : "<span class='hidden'>0</span>");
            temp.SetAttribute("HeavySent", (this.HeavyCavalry > 0) ? this.HeavyCavalry.ToString() : "<span class='hidden'>0</span>");
            temp.SetAttribute("RamSent", (this.Ram > 0) ? this.Ram.ToString() : "<span class='hidden'>0</span>");
            temp.SetAttribute("CatapultSent", (this.Catapult > 0) ? this.Catapult.ToString() : "<span class='hidden'>0</span>");
            temp.SetAttribute("NobleSent", (this.Noble > 0) ? this.Noble.ToString() : "<span class='hidden'>0</span>");

            temp.SetAttribute("SpearDefense", (this.ToVillage.VillageTroopData.SpearInVillage > 0) ? this.ToVillage.VillageTroopData.SpearInVillage.Value.ToString() : "<span class='hidden'>0</span>");
            temp.SetAttribute("SwordDefense", (this.ToVillage.VillageTroopData.SwordInVillage > 0) ? this.ToVillage.VillageTroopData.SwordInVillage.Value.ToString() : "<span class='hidden'>0</span>");
            temp.SetAttribute("AxeDefense", (this.ToVillage.VillageTroopData.AxeInVillage > 0) ? this.ToVillage.VillageTroopData.AxeInVillage.Value.ToString() : "<span class='hidden'>0</span>");
            temp.SetAttribute("ScoutDefense", (this.ToVillage.VillageTroopData.ScoutInVillage > 0) ? this.ToVillage.VillageTroopData.ScoutInVillage.Value.ToString() : "<span class='hidden'>0</span>");
            temp.SetAttribute("LightDefense", (this.ToVillage.VillageTroopData.LightCavalryInVillage > 0) ? this.ToVillage.VillageTroopData.LightCavalryInVillage.Value.ToString() : "<span class='hidden'>0</span>");
            temp.SetAttribute("HeavyDefense", (this.ToVillage.VillageTroopData.HeavyCavalryInVillage > 0) ? this.ToVillage.VillageTroopData.HeavyCavalryInVillage.Value.ToString() : "<span class='hidden'>0</span>");
            temp.SetAttribute("RamDefense", (this.ToVillage.VillageTroopData.RamInVillage > 0) ? this.ToVillage.VillageTroopData.RamInVillage.Value.ToString() : "<span class='hidden'>0</span>");
            temp.SetAttribute("CatapultDefense", (this.ToVillage.VillageTroopData.CatapultInVillage > 0) ? this.ToVillage.VillageTroopData.CatapultInVillage.Value.ToString() : "<span class='hidden'>0</span>");
            temp.SetAttribute("NobleDefense", (this.ToVillage.VillageTroopData.NobleInVillage > 0) ? this.ToVillage.VillageTroopData.NobleInVillage.Value.ToString() : "<span class='hidden'>0</span>");

            temp.SetAttribute("loyal_before", this.ToVillage.Loyal.ToString("000"));
            temp.SetAttribute("building", BuildingTypeFactory.ToString(this.Building));
            temp.SetAttribute("building_before", this.ToVillage[this.Building]);

            #endregion

            Random r = new Random();
            luck = 0.3 * (2 * r.NextDouble() - 1);
            long infantryAttack = this.Spear * 10 + this.Sword * 25 + this.Axe * 40 + this.Noble * 30;
            long cavalryAttack = this.LightCavalry * 130 + this.HeavyCavalry * 150;
            long totalAttack = infantryAttack + cavalryAttack;

            double pInfantry = (double)infantryAttack / (double)totalAttack;
            double pCavalry = (double)cavalryAttack / (double)totalAttack;

            long infantryDefense = this.ToVillage.VillageTroopData.SpearInVillage.Value * 15 + this.ToVillage.VillageTroopData.SwordInVillage.Value * 50 + this.ToVillage.VillageTroopData.AxeInVillage.Value * 10 + this.ToVillage.VillageTroopData.LightCavalryInVillage.Value * 30 + this.ToVillage.VillageTroopData.HeavyCavalryInVillage.Value * 200 + this.ToVillage.VillageTroopData.NobleInVillage.Value * 100;
            long cavalryDefense = this.ToVillage.VillageTroopData.SpearInVillage.Value * 45 + this.ToVillage.VillageTroopData.SwordInVillage.Value * 15 + this.ToVillage.VillageTroopData.AxeInVillage.Value * 5 + this.ToVillage.VillageTroopData.LightCavalryInVillage.Value * 40 + this.ToVillage.VillageTroopData.HeavyCavalryInVillage.Value * 80 + this.ToVillage.VillageTroopData.NobleInVillage.Value * 50;
            long totalDefense = (long)(infantryDefense * pInfantry + cavalryDefense * pCavalry) + 100;

            totalAttack = (totalAttack / totalDefense) * totalAttack;
            totalAttack += (long)(totalAttack * luck);

            bool successAttack = (totalAttack > totalDefense);
            if (successAttack) // quân tấn công thắng
            {
                ratio = 1 - ((double)totalDefense / (double)totalAttack);

                spearLostInAttackSide = (int)Math.Round(this.Spear.Value * (1 - ratio));
                swordLostInAttackSide = (int)Math.Round(this.Sword.Value * (1 - ratio));
                axeLostInAttackSide = (int)Math.Round(this.Axe.Value * (1 - ratio));
                lightCavalryLostInAttackSide = (int)Math.Round(this.LightCavalry.Value * (1 - ratio));
                heavyCavalryLostInAttackSide = (int)Math.Round(this.HeavyCavalry.Value * (1 - ratio));
                ramLostInAttackSide = (int)Math.Round(this.Ram.Value * (1 - ratio));
                catapultLostInAttackSide = (int)Math.Round(this.Catapult.Value * (1 - ratio));
                nobleLostInAttackSide = (int)Math.Round(this.Noble.Value * (1 - ratio));

                spearLostInDefenseSide = this.FromVillage.VillageTroopData.SpearInVillage.Value;
                swordLostInDefenseSide = this.FromVillage.VillageTroopData.SwordInVillage.Value;
                axeLostInDefenseSide = this.FromVillage.VillageTroopData.AxeInVillage.Value;
                lightCavalryLostInDefenseSide = this.FromVillage.VillageTroopData.LightCavalryInVillage.Value;
                heavyCavalryLostInDefenseSide = this.FromVillage.VillageTroopData.HeavyCavalryInVillage.Value;
                ramLostInDefenseSide = this.FromVillage.VillageTroopData.RamInVillage.Value;
                catapultLostInDefenseSide = this.FromVillage.VillageTroopData.CatapultInVillage.Value;
                nobleLostInDefenseSide = this.FromVillage.VillageTroopData.NobleInVillage.Value;

                this.FromVillage.VillageTroopData.SpearOfVillage -= spearLostInAttackSide;
                this.FromVillage.VillageTroopData.SwordOfVillage -= spearLostInAttackSide;
                this.FromVillage.VillageTroopData.AxeOfVillage -= spearLostInAttackSide;
                this.FromVillage.VillageTroopData.LightCavalryOfVillage -= lightCavalryLostInAttackSide;
                this.FromVillage.VillageTroopData.HeavyCavalryOfVillage -= heavyCavalryLostInAttackSide;
                this.FromVillage.VillageTroopData.RamOfVillage -= ramLostInAttackSide;
                this.FromVillage.VillageTroopData.CatapultOfVillage -= catapultLostInAttackSide;
                this.FromVillage.VillageTroopData.NobleOfVillage -= nobleLostInAttackSide;

                this.ToVillage.VillageTroopData.SpearOfVillage = this.ToVillage.VillageTroopData.Spear = 0;
                this.ToVillage.VillageTroopData.SwordOfVillage = this.ToVillage.VillageTroopData.Sword = 0;
                this.ToVillage.VillageTroopData.AxeOfVillage = this.ToVillage.VillageTroopData.Axe = 0;
                this.ToVillage.VillageTroopData.LightCavalryOfVillage = this.ToVillage.VillageTroopData.LightCavalry = 0;
                this.ToVillage.VillageTroopData.HeavyCavalryOfVillage = this.ToVillage.VillageTroopData.HeavyCavalry = 0;
                this.ToVillage.VillageTroopData.RamOfVillage = this.ToVillage.VillageTroopData.Ram = 0;
                this.ToVillage.VillageTroopData.CatapultOfVillage = this.ToVillage.VillageTroopData.Catapult = 0;
                this.ToVillage.VillageTroopData.NobleOfVillage = this.ToVillage.VillageTroopData.Noble = 0;

                villages = (from village in context.Villages
                            join station in context.Stations on village equals station.InVillage
                            select village).ToList<Village>();

                foreach (Village village in villages)
                    village.Update(this.LandingTime.Value, context);

                stations = (from station in context.Stations
                            where station.InVillage == this.ToVillage
                            select station).ToList<Station>();

                foreach (Station station in stations)
                {
                    station.FromVillage.VillageTroopData.SpearOfVillage -= station.Spear.Value;
                    station.FromVillage.VillageTroopData.SwordOfVillage -= station.Sword.Value;
                    station.FromVillage.VillageTroopData.AxeOfVillage -= station.Axe.Value;
                    station.FromVillage.VillageTroopData.ScoutOfVillage -= station.Scout.Value;
                    station.FromVillage.VillageTroopData.LightCavalryOfVillage -= station.LightCavalry.Value;
                    station.FromVillage.VillageTroopData.HeavyCavalryOfVillage -= station.HeavyCavalry.Value;
                    station.FromVillage.VillageTroopData.RamOfVillage -= station.Ram.Value;
                    station.FromVillage.VillageTroopData.CatapultOfVillage -= station.Catapult.Value;
                    station.FromVillage.VillageTroopData.NobleOfVillage -= station.Noble.Value;

                    context.Stations.DeleteOnSubmit(station);

                    #region Viết báo cáo

                    #endregion
                }

                if (this.Noble > 0)
                    this.ToVillage.Loyal -= (r.Next(15) + 20);

                #region Report
                temp.SetAttribute("SpearRemaint", (spearLostInAttackSide > 0) ? spearLostInAttackSide.ToString() : "<span class='hidden'>0</span>");
                temp.SetAttribute("SwordRemaint", (swordLostInAttackSide > 0) ? swordLostInAttackSide.ToString() : "<span class='hidden'>0</span>");
                temp.SetAttribute("AxeRemaint", (axeLostInAttackSide > 0) ? axeLostInAttackSide.ToString() : "<span class='hidden'>0</span>");
                temp.SetAttribute("ScoutRemaint", (scoutLostInAttackSide > 0) ? scoutLostInAttackSide.ToString() : "<span class='hidden'>0</span>");
                temp.SetAttribute("LightRemaint", (lightCavalryLostInAttackSide > 0) ? lightCavalryLostInAttackSide.ToString() : "<span class='hidden'>0</span>");
                temp.SetAttribute("HeavyRemaint", (heavyCavalryLostInAttackSide > 0) ? heavyCavalryLostInAttackSide.ToString() : "<span class='hidden'>0</span>");
                temp.SetAttribute("RamRemaint", (ramLostInAttackSide > 0) ? ramLostInAttackSide.ToString() : "<span class='hidden'>0</span>");
                temp.SetAttribute("CatapultRemaint", (catapultLostInAttackSide > 0) ? catapultLostInAttackSide.ToString() : "<span class='hidden'>0</span>");
                temp.SetAttribute("NobleRemaint", (nobleLostInAttackSide > 0) ? nobleLostInAttackSide.ToString() : "<span class='hidden'>0</span>");

                temp.SetAttribute("SpearSurvived", (spearLostInDefenseSide > 0) ? spearLostInDefenseSide.ToString() : "<span class='hidden'>0</span>");
                temp.SetAttribute("SwordSurvived", (swordLostInDefenseSide > 0) ? swordLostInDefenseSide.ToString() : "<span class='hidden'>0</span>");
                temp.SetAttribute("AxeSurvived", (axeLostInDefenseSide > 0) ? axeLostInDefenseSide.ToString() : "<span class='hidden'>0</span>");
                temp.SetAttribute("ScoutSurvived", (scoutLostInDefenseSide > 0) ? scoutLostInDefenseSide.ToString() : "<span class='hidden'>0</span>");
                temp.SetAttribute("LightSurvived", (lightCavalryLostInDefenseSide > 0) ? lightCavalryLostInDefenseSide.ToString() : "<span class='hidden'>0</span>");
                temp.SetAttribute("HeavySurvived", (heavyCavalryLostInDefenseSide > 0) ? heavyCavalryLostInDefenseSide.ToString() : "<span class='hidden'>0</span>");
                temp.SetAttribute("RamSurvived", (ramLostInDefenseSide > 0) ? ramLostInDefenseSide.ToString() : "<span class='hidden'>0</span>");
                temp.SetAttribute("CatapultSurvived", (catapultLostInDefenseSide > 0) ? catapultLostInDefenseSide.ToString() : "<span class='hidden'>0</span>");
                temp.SetAttribute("NobleSurvived", (nobleLostInDefenseSide > 0) ? nobleLostInDefenseSide.ToString() : "<span class='hidden'>0</span>");

                temp.SetAttribute("success", true);
                temp.SetAttribute("luck", luck.ToString("0.00"));
                temp.SetAttribute("winning", "Bên tấn công");
                temp.SetAttribute("loyal_after", this.ToVillage.Loyal.Value.ToString("000"));
                temp.SetAttribute("building_after", this.ToVillage[this.Building]);
                #endregion

                if (this.ToVillage.Loyal <= 0)
                {
                    this.ToVillage.Player.Point -= this.ToVillage.Point;
                    this.FromVillage.Player.Point += this.ToVillage.Point;
                    this.ToVillage.Player = this.FromVillage.Player;
                    this.ToVillage.Loyal = 25;

                    villages = (from village in context.Villages
                                join station in context.Stations on village equals station.FromVillage
                                select village).ToList<Village>();

                    foreach (Village village in villages)
                        village.Update(this.LandingTime.Value, context);

                    stations = (from station in context.Stations
                                where station.FromVillage == this.ToVillage
                                select station).ToList<Station>();

                    foreach (Station station in stations)
                    {
                        station.FromVillage.VillageTroopData.SpearOfVillage -= station.Spear.Value;
                        station.FromVillage.VillageTroopData.SwordOfVillage -= station.Sword.Value;
                        station.FromVillage.VillageTroopData.AxeOfVillage -= station.Axe.Value;
                        station.FromVillage.VillageTroopData.ScoutOfVillage -= station.Scout.Value;
                        station.FromVillage.VillageTroopData.LightCavalryOfVillage -= station.LightCavalry.Value;
                        station.FromVillage.VillageTroopData.HeavyCavalryOfVillage -= station.HeavyCavalry.Value;
                        station.FromVillage.VillageTroopData.RamOfVillage -= station.Ram.Value;
                        station.FromVillage.VillageTroopData.CatapultOfVillage -= station.Catapult.Value;
                        station.FromVillage.VillageTroopData.NobleOfVillage -= station.Noble.Value;

                        context.Stations.DeleteOnSubmit(station);
                    }

                    stations = (from station in context.Stations
                                where station.FromVillage == this.ToVillage
                                select station).ToList<Station>();

                    foreach (Station station in stations)
                    {
                        station.InVillage.Update(this.LandingTime.Value, context);
                        context.Stations.DeleteOnSubmit(station);
                    }

                    Station newStation = new Station();
                    newStation.InVillage = this.ToVillage;
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
                    this.ToVillage.VillageTroopData.ScoutInVillage = this.Scout - scoutLostInAttackSide;
                    this.ToVillage.VillageTroopData.LightCavalryInVillage = this.LightCavalry - lightCavalryLostInAttackSide;
                    this.ToVillage.VillageTroopData.HeavyCavalryInVillage = this.HeavyCavalry - heavyCavalryLostInAttackSide;
                    this.ToVillage.VillageTroopData.RamInVillage = this.Ram - ramLostInAttackSide;
                    this.ToVillage.VillageTroopData.CatapultInVillage = this.Catapult - catapultLostInAttackSide;
                    this.ToVillage.VillageTroopData.NobleInVillage = this.Noble - nobleLostInAttackSide;

                    context.Stations.InsertOnSubmit(newStation);

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

                    int intCanHaul = this.Spear.Value * 25 + this.Sword.Value * 15 + this.Axe.Value * 10 + this.LightCavalry.Value * 80 + this.HeavyCavalry.Value;
                    int intTotalResource = this.ToVillage.VillageResourceData.Iron.Value + this.ToVillage.VillageResourceData.Clay.Value + this.ToVillage.VillageResourceData.Wood.Value;

                    if (intTotalResource <= intCanHaul)
                    {
                        returnTroop.Clay = this.ToVillage.VillageResourceData.Clay.Value;
                        returnTroop.Wood = this.ToVillage.VillageResourceData.Wood.Value;
                        returnTroop.Iron = this.ToVillage.VillageResourceData.Iron.Value;

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

                    context.Movements.InsertOnSubmit(returnTroop);

                    temp.SetAttribute("Clay", returnTroop.Clay > 0 ? String.Format("<img src=\"images/lehm.png\" />{0}", returnTroop.Clay) : "");
                    temp.SetAttribute("Iron", returnTroop.Clay > 0 ? String.Format("<img src=\"images/eisen.png\" />{0}", returnTroop.Iron) : "");
                    temp.SetAttribute("Wood", returnTroop.Clay > 0 ? String.Format("<img src=\"images/holz.png\" />{0}", returnTroop.Wood) : "");

                    #endregion
                }

            }
            else
            {
                if (totalAttack == 0)
                    totalAttack = 1;
                ratio = 1 - ((double)totalAttack / (double)totalDefense);

                spearLostInAttackSide = this.Spear.Value;
                swordLostInAttackSide = this.Sword.Value;
                axeLostInAttackSide = this.Axe.Value;
                lightCavalryLostInAttackSide = this.LightCavalry.Value;
                scoutLostInAttackSide = this.Scout.Value;
                heavyCavalryLostInAttackSide = this.HeavyCavalry.Value;
                ramLostInAttackSide = this.Ram.Value;
                catapultLostInAttackSide = this.Catapult.Value;
                nobleLostInAttackSide = this.Noble.Value;

                spearLostInDefenseSide = this.FromVillage.VillageTroopData.SpearInVillage.Value;
                swordLostInDefenseSide = this.FromVillage.VillageTroopData.SwordInVillage.Value;
                axeLostInDefenseSide = this.FromVillage.VillageTroopData.AxeInVillage.Value;
                lightCavalryLostInDefenseSide = this.FromVillage.VillageTroopData.LightCavalryInVillage.Value;
                heavyCavalryLostInDefenseSide = this.FromVillage.VillageTroopData.HeavyCavalryInVillage.Value;
                ramLostInDefenseSide = this.FromVillage.VillageTroopData.RamInVillage.Value;
                catapultLostInDefenseSide = this.FromVillage.VillageTroopData.CatapultInVillage.Value;
                nobleLostInDefenseSide = this.FromVillage.VillageTroopData.NobleInVillage.Value;

                this.FromVillage.VillageTroopData.SpearOfVillage -= this.Spear;
                this.FromVillage.VillageTroopData.SwordOfVillage -= this.Sword;
                this.FromVillage.VillageTroopData.AxeOfVillage -= this.Axe;
                this.FromVillage.VillageTroopData.LightCavalryOfVillage -= this.LightCavalry;
                this.FromVillage.VillageTroopData.ScoutOfVillage -= this.Scout;
                this.FromVillage.VillageTroopData.HeavyCavalryOfVillage -= this.HeavyCavalry;
                this.FromVillage.VillageTroopData.RamOfVillage -= this.Ram;
                this.FromVillage.VillageTroopData.CatapultOfVillage -= this.Catapult;
                this.FromVillage.VillageTroopData.NobleOfVillage -= this.Noble;

                this.ToVillage.VillageTroopData.SpearInVillage -= spearLostInDefenseSide;
                this.ToVillage.VillageTroopData.SpearInVillage -= swordLostInDefenseSide;
                this.ToVillage.VillageTroopData.SpearInVillage -= axeLostInDefenseSide;
                this.ToVillage.VillageTroopData.SpearInVillage -= scoutLostInDefenseSide;
                this.ToVillage.VillageTroopData.SpearInVillage -= lightCavalryLostInDefenseSide;
                this.ToVillage.VillageTroopData.SpearInVillage -= heavyCavalryLostInDefenseSide;
                this.ToVillage.VillageTroopData.SpearInVillage -= ramLostInDefenseSide;
                this.ToVillage.VillageTroopData.SpearInVillage -= catapultLostInDefenseSide;
                this.ToVillage.VillageTroopData.SpearInVillage -= nobleLostInDefenseSide;

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

                stations = (from station in context.Stations
                            where station.InVillage == this.ToVillage
                            select station).ToList<Station>();

                foreach (Station station in stations)
                {
                    station.Spear = (int)Math.Round(station.Spear.Value * ratio);
                    station.Sword = (int)Math.Round(station.Sword.Value * ratio);
                    station.Axe = (int)Math.Round(station.Axe.Value * ratio);
                    station.LightCavalry = (int)Math.Round(station.LightCavalry.Value * ratio);
                    station.Scout = (int)Math.Round(station.Scout.Value * ratio);
                    station.HeavyCavalry = (int)Math.Round(station.HeavyCavalry.Value * ratio);
                    station.Ram = (int)Math.Round(station.Ram.Value * ratio);
                    station.Catapult = (int)Math.Round(station.Catapult.Value * ratio);
                    station.Noble = (int)Math.Round(station.Noble.Value * ratio);

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

            attackSideReport.SetAttackReport(attack);
            defenseSideReport.Title = attackSideReport.Title;

            defenseSideReport.Description = attackSideReport.Description;

            session.Update(this.To);
            session.Update(this.From);
            session.Update(this.To.Owner);
            session.Update(this.From.Owner);

            session.Save(attackSideReport);
            session.Save(defenseSideReport);

            session.Delete(this);
        }
    
        public override MoveType  Type
        {
            get { return MoveType.Attack; }
        }

        public override MovingCommand Effect(ISession session)
        {
 	        throw new NotImplementedException();
        }

        public override MovingCommand Cancel(ISession session)
        {
 	        throw new NotImplementedException();
        }
    }
}
