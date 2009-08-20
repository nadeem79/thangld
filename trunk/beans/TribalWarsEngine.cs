using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;

namespace beans
{
    public class TribalWarsEngine
    {

        protected static void CalculateResearchPrice()
        {
            ResearchPrice attackResearchPrice = new ResearchPrice( "Attack",
                                                                        (int)Configuration.TribalWarsConfiguration.GetNumericConfigurationItem("Research.Attack.time").Value,
                                                                        (int)Configuration.TribalWarsConfiguration.GetNumericConfigurationItem("Research.Attack.wood").Value,
                                                                        (int)Configuration.TribalWarsConfiguration.GetNumericConfigurationItem("Research.Attack.clay").Value,
                                                                        (int)Configuration.TribalWarsConfiguration.GetNumericConfigurationItem("Research.Attack.iron").Value,
                                                                        1);
            ResearchPrice defenseResearchPrice = new ResearchPrice("Defense",
                                                                        (int)Configuration.TribalWarsConfiguration.GetNumericConfigurationItem("Research.Defense.time").Value,
                                                                        (int)Configuration.TribalWarsConfiguration.GetNumericConfigurationItem("Research.Defense.wood").Value,
                                                                        (int)Configuration.TribalWarsConfiguration.GetNumericConfigurationItem("Research.Defense.clay").Value,
                                                                        (int)Configuration.TribalWarsConfiguration.GetNumericConfigurationItem("Research.Defense.iron").Value, 
                                                                        1);
            ResearchPrice speedResearchPrice = new ResearchPrice("Speed",
                                                                        (int)Configuration.TribalWarsConfiguration.GetNumericConfigurationItem("Research.Speed.time").Value,
                                                                        (int)Configuration.TribalWarsConfiguration.GetNumericConfigurationItem("Research.Speed.wood").Value,
                                                                        (int)Configuration.TribalWarsConfiguration.GetNumericConfigurationItem("Research.Speed.clay").Value,
                                                                        (int)Configuration.TribalWarsConfiguration.GetNumericConfigurationItem("Research.Speed.iron").Value, 
                                                                        1);
            
            int maxResearchLevel = (int)Configuration.TribalWarsConfiguration.GetNumericConfigurationItem("Research.Common.max_level").Value;
            int maxSmithyLevel = (int)Configuration.TribalWarsConfiguration.GetNumericConfigurationItem("Building.Smithy.max_level").Value;
            double percentResourceIncrease = Configuration.TribalWarsConfiguration.GetNumericConfigurationItem("Research.Common.percent_resource_increase").Value;
            double percentTimeIncrease = Configuration.TribalWarsConfiguration.GetNumericConfigurationItem("Research.Common.percent_time_decrease").Value;
            int attackType = (int)ResearchType.Attack, defenseType = (int)ResearchType.Defense, speedType = (int)ResearchType.Speed, key = 0, tmp = 0;
            
            Research.ResearchPrices.Clear();

            for (int researchLevel = 1; researchLevel <= maxResearchLevel; researchLevel++)
            {
                int woodForAttack = attackResearchPrice.Wood + (int)(attackResearchPrice.Wood * percentResourceIncrease);
                int clayForAttack = attackResearchPrice.Clay + (int)(attackResearchPrice.Clay * percentResourceIncrease);
                int ironForAttack = attackResearchPrice.Iron + (int)(attackResearchPrice.Iron * percentResourceIncrease);

                int woodForDefense = defenseResearchPrice.Wood + (int)(defenseResearchPrice.Wood * percentResourceIncrease);
                int clayForDefense = defenseResearchPrice.Clay + (int)(defenseResearchPrice.Clay * percentResourceIncrease);
                int ironForDefense = defenseResearchPrice.Iron + (int)(defenseResearchPrice.Iron * percentResourceIncrease);

                int woodForSpeed = speedResearchPrice.Wood + (int)(speedResearchPrice.Wood * percentResourceIncrease);
                int clayForSpeed = speedResearchPrice.Clay + (int)(speedResearchPrice.Clay * percentResourceIncrease);
                int ironForSpeed = speedResearchPrice.Iron + (int)(speedResearchPrice.Iron * percentResourceIncrease);

                for (int smithyLevel = 1; smithyLevel <= maxSmithyLevel; smithyLevel++)
                {
                     tmp = (researchLevel * 1000) + (smithyLevel * 1000000);

                    key = attackType + tmp;
                    Research.ResearchPrices.Add(key, attackResearchPrice);
                    key = defenseType + tmp;
                    Research.ResearchPrices.Add(key, defenseResearchPrice);
                    key = speedType + tmp;
                    Research.ResearchPrices.Add(key, speedResearchPrice);

                    attackResearchPrice = new ResearchPrice("Attack", attackResearchPrice.Time - (int)(attackResearchPrice.Time * percentTimeIncrease), woodForAttack, clayForAttack, ironForAttack, researchLevel);
                    defenseResearchPrice = new ResearchPrice("Defense", defenseResearchPrice.Time - (int)(defenseResearchPrice.Time * percentTimeIncrease), woodForDefense, clayForDefense, ironForDefense, researchLevel);
                    speedResearchPrice = new ResearchPrice("Speed", speedResearchPrice.Time - (int)(speedResearchPrice.Time * percentTimeIncrease), woodForSpeed, clayForSpeed, ironForSpeed, researchLevel);
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
        }

        public static void Stop()
        {

        }
    }
}
