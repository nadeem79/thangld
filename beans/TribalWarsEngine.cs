using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;

namespace beans
{
    public class TribalWarsEngine
    {
        public static void Start(ISession session)
        {
            Configuration.TribalWarsConfiguration.LoadData(session);

            #region Tiền xây quân
            Recruit.pSpear = new Price(  "Spear",
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
            Recruit.pCatapult = new Price(  "Catapult",
                                            (int)Configuration.TribalWarsConfiguration.GetNumericConfigurationItem("Recruit.catapult_build_time").Value,
                                            (int)Configuration.TribalWarsConfiguration.GetNumericConfigurationItem("Recruit.catapult_wood").Value,
                                            (int)Configuration.TribalWarsConfiguration.GetNumericConfigurationItem("Recruit.catapult_clay").Value,
                                            (int)Configuration.TribalWarsConfiguration.GetNumericConfigurationItem("Recruit.catapult_iron").Value,
                                            Configuration.TribalWarsConfiguration.GetNumericConfigurationItem("Recruit.catapult_population").Value);
            Recruit.pNoble = new Price("Noble", 9860, 28000, 30000, 25000, 100);

            #endregion

            #region Tính thương nhân
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

            #endregion

        }

        public static void Stop()
        {

        }
    }
}
