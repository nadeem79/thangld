using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;

namespace beans
{
    public class TribalWarsEngine
    {
        protected static void CalculateResearchValue()
        {
            Research.AttackValuesDictionary.Clear();
            Research.DefenseValuesDictionary.Clear();
            Research.SpeedValuesDictionary.Clear();

            double percentAttackIncrease = Configuration.TribalWarsConfiguration.GetNumericConfigurationItem("Research.percent_attack_increase").Value;
            double percentDefenseIncrease = Configuration.TribalWarsConfiguration.GetNumericConfigurationItem("Research.percent_defense_increase").Value;
            double percentSpeedIncrease = Configuration.TribalWarsConfiguration.GetNumericConfigurationItem("Research.percent_speed_increase").Value;
            int maxResearchLevel = (int)Configuration.TribalWarsConfiguration.GetNumericConfigurationItem("Research.Common.max_level").Value;

            double attackIncrease = percentAttackIncrease, defenseIncrease = percentDefenseIncrease, speedIncrease = percentSpeedIncrease;
            
            for (int i = 1; i <= maxResearchLevel; i++)
            {
                attackIncrease += attackIncrease * percentAttackIncrease;
                defenseIncrease += defenseIncrease * percentDefenseIncrease;
                speedIncrease += speedIncrease * percentSpeedIncrease;
                Research.AttackValuesDictionary.Add(i, attackIncrease);
                Research.DefenseValuesDictionary.Add(i, defenseIncrease);
                Research.SpeedValuesDictionary.Add(i, speedIncrease);
            }
        }

        protected static void CalculateResearchPrice()
        {

            int baseAttackTime = (int)Configuration.TribalWarsConfiguration.GetNumericConfigurationItem("Research.Attack.time").Value;
            int baseAttackWood = (int)Configuration.TribalWarsConfiguration.GetNumericConfigurationItem("Research.Attack.wood").Value;
            int baseAttackClay = (int)Configuration.TribalWarsConfiguration.GetNumericConfigurationItem("Research.Attack.clay").Value;
            int baseAttackIron = (int)Configuration.TribalWarsConfiguration.GetNumericConfigurationItem("Research.Attack.iron").Value;

            int baseDefenseTime = (int)Configuration.TribalWarsConfiguration.GetNumericConfigurationItem("Research.Defense.time").Value;
            int baseDefenseWood = (int)Configuration.TribalWarsConfiguration.GetNumericConfigurationItem("Research.Defense.wood").Value;
            int baseDefenseClay = (int)Configuration.TribalWarsConfiguration.GetNumericConfigurationItem("Research.Defense.clay").Value;
            int baseDefenseIron = (int)Configuration.TribalWarsConfiguration.GetNumericConfigurationItem("Research.Defense.iron").Value;

            int baseSpeedTime = (int)Configuration.TribalWarsConfiguration.GetNumericConfigurationItem("Research.Speed.time").Value;
            int baseSpeedWood = (int)Configuration.TribalWarsConfiguration.GetNumericConfigurationItem("Research.Speed.wood").Value;
            int baseSpeedClay = (int)Configuration.TribalWarsConfiguration.GetNumericConfigurationItem("Research.Speed.clay").Value;
            int baseSpeedIron = (int)Configuration.TribalWarsConfiguration.GetNumericConfigurationItem("Research.Speed.iron").Value;


            ResearchPrice attackResearchPrice = new ResearchPrice("Attack cấp 1 smithy 1",
                                                                        (int)Configuration.TribalWarsConfiguration.GetNumericConfigurationItem("Research.Attack.time").Value,
                                                                        (int)Configuration.TribalWarsConfiguration.GetNumericConfigurationItem("Research.Attack.wood").Value,
                                                                        (int)Configuration.TribalWarsConfiguration.GetNumericConfigurationItem("Research.Attack.clay").Value,
                                                                        (int)Configuration.TribalWarsConfiguration.GetNumericConfigurationItem("Research.Attack.iron").Value,
                                                                        1);
            ResearchPrice defenseResearchPrice = new ResearchPrice("Defense cấp 1 smithy 1",
                                                                        (int)Configuration.TribalWarsConfiguration.GetNumericConfigurationItem("Research.Defense.time").Value,
                                                                        (int)Configuration.TribalWarsConfiguration.GetNumericConfigurationItem("Research.Defense.wood").Value,
                                                                        (int)Configuration.TribalWarsConfiguration.GetNumericConfigurationItem("Research.Defense.clay").Value,
                                                                        (int)Configuration.TribalWarsConfiguration.GetNumericConfigurationItem("Research.Defense.iron").Value, 
                                                                        1);
            ResearchPrice speedResearchPrice = new ResearchPrice("Speed cấp 1 smithy 1",
                                                                        (int)Configuration.TribalWarsConfiguration.GetNumericConfigurationItem("Research.Speed.time").Value,
                                                                        (int)Configuration.TribalWarsConfiguration.GetNumericConfigurationItem("Research.Speed.wood").Value,
                                                                        (int)Configuration.TribalWarsConfiguration.GetNumericConfigurationItem("Research.Speed.clay").Value,
                                                                        (int)Configuration.TribalWarsConfiguration.GetNumericConfigurationItem("Research.Speed.iron").Value, 
                                                                        1);
            
            int maxResearchLevel = (int)Configuration.TribalWarsConfiguration.GetNumericConfigurationItem("Research.Common.max_level").Value;
            int maxSmithyLevel = (int)Configuration.TribalWarsConfiguration.GetNumericConfigurationItem("Building.Smithy.max_level").Value;
            double percentResourceIncrease = Configuration.TribalWarsConfiguration.GetNumericConfigurationItem("Research.Common.percent_resource_increase").Value;
            double percentTimeIncrease = Configuration.TribalWarsConfiguration.GetNumericConfigurationItem("Research.Common.percent_time_increase").Value;
            double percentTimeDecrease = Configuration.TribalWarsConfiguration.GetNumericConfigurationItem("Research.Common.percent_time_decrease").Value;
            int attackType = (int)ResearchType.Attack, defenseType = (int)ResearchType.Defense, speedType = (int)ResearchType.Speed, key = 0, tmp = 0;
            
            Research.ResearchPrices.Clear();

            for (int researchLevel = 1; researchLevel < maxResearchLevel; researchLevel++)
            {
                if (researchLevel > 1)
                {
                    baseAttackTime += (int)(baseAttackTime * percentTimeIncrease);
                    baseAttackWood += (int)(baseAttackWood * percentResourceIncrease);
                    baseAttackClay += (int)(baseAttackClay * percentResourceIncrease);
                    baseAttackIron += (int)(baseAttackIron * percentResourceIncrease);

                    baseDefenseTime += (int)(baseDefenseTime * percentTimeIncrease);
                    baseDefenseWood += (int)(baseDefenseWood * percentResourceIncrease);
                    baseDefenseClay += (int)(baseDefenseClay * percentResourceIncrease);
                    baseDefenseIron += (int)(baseDefenseIron * percentResourceIncrease);

                    baseSpeedTime += (int)(baseSpeedTime * percentTimeIncrease);
                    baseSpeedWood += (int)(baseSpeedWood * percentResourceIncrease);
                    baseSpeedClay += (int)(baseSpeedClay * percentResourceIncrease);
                    baseSpeedIron += (int)(baseSpeedIron * percentResourceIncrease);
                }

                int speedTime = baseSpeedTime, attackTime = baseAttackTime, defenseTime = baseDefenseTime;
                for (int smithy = 1; smithy < maxSmithyLevel; smithy++)
                {
                    speedTime -= (int)(speedTime * percentTimeDecrease);
                    attackTime -= (int)(attackTime * percentTimeDecrease);
                    defenseTime -= (int)(defenseTime * percentTimeDecrease);
                    attackResearchPrice = new ResearchPrice(string.Format("Attack cấp {0} smithy {1}", researchLevel, smithy), attackTime, baseAttackWood, baseDefenseClay, baseDefenseIron, researchLevel);
                    defenseResearchPrice = new ResearchPrice(string.Format("Defense cấp {0} smithy {1}", researchLevel, smithy), defenseTime, baseDefenseWood, baseDefenseClay, baseDefenseIron, researchLevel);
                    speedResearchPrice = new ResearchPrice(string.Format("Speed cấp {0} smithy {1}", researchLevel, smithy), speedTime, baseSpeedWood, baseSpeedClay, baseSpeedIron, researchLevel);
                    tmp = (researchLevel * 1000) + (smithy * 1000000);
                    key = attackType + tmp;
                    Research.ResearchPrices.Add(key, attackResearchPrice);
                    key = defenseType + tmp;
                    Research.ResearchPrices.Add(key, defenseResearchPrice);
                    key = speedType + tmp;
                    Research.ResearchPrices.Add(key, speedResearchPrice);
                }
            }
        }
        protected static void CalculateMerchant()
        {
            VillageBuildingData.MerchantCountDictionary.Clear();

            int maxMarketLevel = (int)Configuration.TribalWarsConfiguration.GetNumericConfigurationItem("Building.max_market_level").Value;
            double percentMerchantPerLevel = Configuration.TribalWarsConfiguration.GetNumericConfigurationItem("Building.percent_merchant_per_level").Value;
            VillageBuildingData.MerchantCountDictionary.Add(0, 0);
            VillageBuildingData.MerchantCountDictionary.Add(1, 1);

            int merchant = 1;

            for (int i = 2; i <= maxMarketLevel; i++)
            {
                merchant += (int)Math.Ceiling(merchant * percentMerchantPerLevel);
                VillageBuildingData.MerchantCountDictionary.Add(i, merchant);
            }
        }
        protected static void CalculateTroopPrice()
        {
            
            Recruit.pSpear = new Price("Spear",
                                                    (int)Configuration.TribalWarsConfiguration.GetNumericConfigurationItem("Recruit.spear_build_time").Value,
                                                    (int)Configuration.TribalWarsConfiguration.GetNumericConfigurationItem("Recruit.spear_wood").Value,
                                                    (int)Configuration.TribalWarsConfiguration.GetNumericConfigurationItem("Recruit.spear_clay").Value,
                                                    (int)Configuration.TribalWarsConfiguration.GetNumericConfigurationItem("Recruit.spear_iron").Value,
                                                    Configuration.TribalWarsConfiguration.GetNumericConfigurationItem("Recruit.spear_population").Value);
            Recruit.pSword = new Price("Sword",
                                                    (int)Configuration.TribalWarsConfiguration.GetNumericConfigurationItem("Recruit.sword_build_time").Value,
                                                    (int)Configuration.TribalWarsConfiguration.GetNumericConfigurationItem("Recruit.sword_wood").Value,
                                                    (int)Configuration.TribalWarsConfiguration.GetNumericConfigurationItem("Recruit.sword_clay").Value,
                                                    (int)Configuration.TribalWarsConfiguration.GetNumericConfigurationItem("Recruit.sword_iron").Value,
                                                    Configuration.TribalWarsConfiguration.GetNumericConfigurationItem("Recruit.sword_population").Value);
            Recruit.pAxe = new Price("Axe",
                                                    (int)Configuration.TribalWarsConfiguration.GetNumericConfigurationItem("Recruit.axe_build_time").Value,
                                                    (int)Configuration.TribalWarsConfiguration.GetNumericConfigurationItem("Recruit.axe_wood").Value,
                                                    (int)Configuration.TribalWarsConfiguration.GetNumericConfigurationItem("Recruit.axe_clay").Value,
                                                    (int)Configuration.TribalWarsConfiguration.GetNumericConfigurationItem("Recruit.axe_iron").Value,
                                                    Configuration.TribalWarsConfiguration.GetNumericConfigurationItem("Recruit.axe_population").Value);
            Recruit.pScout = new Price("Scout",
                                                    (int)Configuration.TribalWarsConfiguration.GetNumericConfigurationItem("Recruit.scout_build_time").Value,
                                                    (int)Configuration.TribalWarsConfiguration.GetNumericConfigurationItem("Recruit.scout_wood").Value,
                                                    (int)Configuration.TribalWarsConfiguration.GetNumericConfigurationItem("Recruit.scout_clay").Value,
                                                    (int)Configuration.TribalWarsConfiguration.GetNumericConfigurationItem("Recruit.scout_iron").Value,
                                                    Configuration.TribalWarsConfiguration.GetNumericConfigurationItem("Recruit.scout_population").Value);
            Recruit.pLightCavalry = new Price("Light Cavalry",
                                                    (int)Configuration.TribalWarsConfiguration.GetNumericConfigurationItem("Recruit.light_cavalry_build_time").Value,
                                                    (int)Configuration.TribalWarsConfiguration.GetNumericConfigurationItem("Recruit.light_cavalry_wood").Value,
                                                    (int)Configuration.TribalWarsConfiguration.GetNumericConfigurationItem("Recruit.light_cavalry_clay").Value,
                                                    (int)Configuration.TribalWarsConfiguration.GetNumericConfigurationItem("Recruit.light_cavalry_iron").Value,
                                                    Configuration.TribalWarsConfiguration.GetNumericConfigurationItem("Recruit.light_cavalry_population").Value);
            Recruit.pHeavyCavalry = new Price("Heavy Cavalry",
                                                    (int)Configuration.TribalWarsConfiguration.GetNumericConfigurationItem("Recruit.heavy_cavalry_build_time").Value,
                                                    (int)Configuration.TribalWarsConfiguration.GetNumericConfigurationItem("Recruit.heavy_cavalry_wood").Value,
                                                    (int)Configuration.TribalWarsConfiguration.GetNumericConfigurationItem("Recruit.heavy_cavalry_clay").Value,
                                                    (int)Configuration.TribalWarsConfiguration.GetNumericConfigurationItem("Recruit.heavy_cavalry_iron").Value,
                                                    Configuration.TribalWarsConfiguration.GetNumericConfigurationItem("Recruit.heavy_cavalry_population").Value);
            Recruit.pRam = new Price("Ram",
                                                    (int)Configuration.TribalWarsConfiguration.GetNumericConfigurationItem("Recruit.ram_build_time").Value,
                                                    (int)Configuration.TribalWarsConfiguration.GetNumericConfigurationItem("Recruit.ram_wood").Value,
                                                    (int)Configuration.TribalWarsConfiguration.GetNumericConfigurationItem("Recruit.ram_clay").Value,
                                                    (int)Configuration.TribalWarsConfiguration.GetNumericConfigurationItem("Recruit.ram_iron").Value,
                                                    Configuration.TribalWarsConfiguration.GetNumericConfigurationItem("Recruit.ram_population").Value);
            Recruit.pCatapult = new Price("Catapult",
                                            (int)Configuration.TribalWarsConfiguration.GetNumericConfigurationItem("Recruit.catapult_build_time").Value,
                                            (int)Configuration.TribalWarsConfiguration.GetNumericConfigurationItem("Recruit.catapult_wood").Value,
                                            (int)Configuration.TribalWarsConfiguration.GetNumericConfigurationItem("Recruit.catapult_clay").Value,
                                            (int)Configuration.TribalWarsConfiguration.GetNumericConfigurationItem("Recruit.catapult_iron").Value,
                                            Configuration.TribalWarsConfiguration.GetNumericConfigurationItem("Recruit.catapult_population").Value);
            Recruit.pNoble = new Price("Noble", 9860, 28000, 30000, 25000, 100);
        }

        public static void Start(ISession session)
        {
            Configuration.TribalWarsConfiguration.LoadData(session);
            
            CalculateMerchant();
            CalculateResearchPrice();
            CalculateTroopPrice();
            CalculateResearchValue();
            ServicesList.LogService.Log("", "Hệ thống start");
        }

        public static void Stop()
        {

        }
    }
}
