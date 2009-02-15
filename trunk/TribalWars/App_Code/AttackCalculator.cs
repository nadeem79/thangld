using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

/// <summary>
/// Summary description for AttackCalculator
/// </summary>
public class AttackCalculator
{

    public static bool attack(
        int aSpear,  int aSword,  int aAxe,  int aBowman,  int aLight,  int aScout,  int aHeavy,  int aMounted,  int aRam,  int aCatapult,  int aNoble,
        int dSpear,  int dSword,  int dAxe,  int dBowman,  int dLight,  int dScout,  int dHeavy,  int dMounted,  int dRam,  int dCatapult,  int dNoble,
        out int spear, out int sword, out int axe, out int bowman, out int light, out int scout, out int heavy, out int mounted, out int ram, out int catapult, out int noble)
    {
        int infantryAttack = aSpear * 10 + aSword * 25 + aAxe * 40 + aNoble * 30;
        int cavalryAttack = aLight * 130 + aHeavy * 150;
        int bowAttack = aBowman * 15 + dMounted * 120;
        int totalAttack = infantryAttack + cavalryAttack + bowAttack;

        double pInfantry = infantryAttack / totalAttack;
        double pCavalry = cavalryAttack / totalAttack;
        double pBow = bowAttack / totalAttack;

        int infantryDefense = dSpear * 15 + dSword * 50 + dAxe * 10 + dBowman * 50 + dLight * 30 + dMounted * 40 + dHeavy * 200 + dNoble * 100;
        int cavalryDefense = dSpear * 45 + dSword * 15 + dAxe * 5 + dBowman * 40 + dLight * 40 + dMounted * 30 + dHeavy * 80 + dNoble * 50;
        int bowDefense = dSpear * 20 + dSword * 40 + dAxe * 10 + dBowman * 5 + dLight * 30 + dMounted * 50 + dHeavy * 180 + dNoble * 35;
        int totalDefense = (int)(infantryDefense * pInfantry + cavalryDefense * pCavalry + bowDefense * pBow);

        totalAttack = (totalAttack / totalDefense)*totalAttack;

        double ratio;
        if (totalAttack > totalDefense)
        {
            ratio = totalAttack * (totalAttack - totalDefense) / totalDefense;

            spear = (int)(aSpear * ratio);
            sword = (int)(aSword * ratio);
            axe = (int)(aAxe * ratio);
            bowman = (int)(aBowman * ratio);
            
            light = (int)(aLight * ratio);
            heavy = (int)(aHeavy * ratio);
            mounted = (int)(aMounted * ratio);
            ram = (int)(aRam * ratio);
            catapult = (int)(aCatapult * ratio);
            noble = (int)(aNoble * ratio);
            scout = (int)(aScout * ratio);

            return true;
        }
        else
        {
            ratio = totalAttack * (totalDefense - totalAttack) / totalAttack;

            spear = (int)(dSpear * ratio);
            sword = (int)(dSword * ratio);
            axe = (int)(dAxe * ratio);
            bowman = (int)(dBowman * ratio);
            light = (int)(dLight * ratio);
            heavy = (int)(dHeavy * ratio);
            mounted = (int)(dMounted * ratio);
            ram = (int)(dRam * ratio);
            catapult = (int)(dCatapult * ratio);
            noble = (int)(dNoble * ratio);
            scout = dScout;
            
            return false;
        }
    }

    public AttackCalculator()
    {
        //
        // TODO: Add constructor logic here
        //
    }
}
