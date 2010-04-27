using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using beans;

/// <summary>
/// Summary description for LanguageFunctions
/// </summary>
public class LanguageFunctions
{
    private LanguageFunctions()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public static string BuildingToString(BuildingType building)
    {
        switch (building)
        {
            case BuildingType.NoBuiding:
                return "";
            case BuildingType.Headquarter:
                return Configuration.TribalWarsConfiguration.GetStringConfigurationItem("Building.capital_headquarter").Value;
            case BuildingType.Barracks:
                return Configuration.TribalWarsConfiguration.GetStringConfigurationItem("Building.capital_barrack").Value;
            case BuildingType.Stable:
                return Configuration.TribalWarsConfiguration.GetStringConfigurationItem("Building.capital_stable").Value;
            case BuildingType.Workshop:
                return Configuration.TribalWarsConfiguration.GetStringConfigurationItem("Building.capital_workshop").Value;
            case BuildingType.Academy:
                return Configuration.TribalWarsConfiguration.GetStringConfigurationItem("Building.capital_academy").Value;
            case BuildingType.Smithy:
                return Configuration.TribalWarsConfiguration.GetStringConfigurationItem("Building.capital_smithy").Value;
            case BuildingType.Rally:
                return Configuration.TribalWarsConfiguration.GetStringConfigurationItem("Building.capital_rally").Value;
            case BuildingType.Market:
                return Configuration.TribalWarsConfiguration.GetStringConfigurationItem("Building.capital_market").Value;
            case BuildingType.TimberCamp:
                return Configuration.TribalWarsConfiguration.GetStringConfigurationItem("Building.capital_timber_camp").Value;
            case BuildingType.ClayPit:
                return Configuration.TribalWarsConfiguration.GetStringConfigurationItem("Building.capital_clay_pit").Value;
            case BuildingType.IronMine:
                return Configuration.TribalWarsConfiguration.GetStringConfigurationItem("Building.capital_iron_mine").Value;
            case BuildingType.Farm:
                return Configuration.TribalWarsConfiguration.GetStringConfigurationItem("Building.capital_farm").Value;
            case BuildingType.Warehouse:
                return Configuration.TribalWarsConfiguration.GetStringConfigurationItem("Building.capital_warehouse").Value;
            case BuildingType.HidingPlace:
                return Configuration.TribalWarsConfiguration.GetStringConfigurationItem("Building.capital_hiding_place").Value;
            case BuildingType.Wall:
                return Configuration.TribalWarsConfiguration.GetStringConfigurationItem("Building.capital_wall").Value;
            default:
                return "";
        }
    }
}
