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

        double pInfantry = (double)infantryAttack / (double)totalAttack;
        double pCavalry = (double)cavalryAttack / (double)totalAttack;
        double pBow = (double)bowAttack / (double)totalAttack;

        int infantryDefense = dSpear * 15 + dSword * 50 + dAxe * 10 + dBowman * 50 + dLight * 30 + dMounted * 40 + dHeavy * 200 + dNoble * 100;
        int cavalryDefense = dSpear * 45 + dSword * 15 + dAxe * 5 + dBowman * 40 + dLight * 40 + dMounted * 30 + dHeavy * 80 + dNoble * 50;
        int bowDefense = dSpear * 20 + dSword * 40 + dAxe * 10 + dBowman * 5 + dLight * 30 + dMounted * 50 + dHeavy * 180 + dNoble * 35;
        int totalDefense = (int)(infantryDefense * pInfantry + cavalryDefense * pCavalry + bowDefense * pBow) + 100;

        totalAttack = (totalAttack / totalDefense)*totalAttack;

        double ratio;
        if (totalAttack > totalDefense)
        {
            ratio = (double)totalDefense / (double)totalAttack;

            spear = aSpear - (int)(aSpear * ratio);
            sword = aSword - (int)(aSword * ratio);
            axe = aAxe - (int)(aAxe * ratio);
            bowman = aBowman - (int)(aBowman * ratio);
            light = aLight - (int)(aLight * ratio);
            heavy = aHeavy - (int)(aHeavy * ratio);
            mounted = aMounted - (int)(aMounted * ratio);
            ram = aRam - (int)(aRam * ratio);
            catapult = aCatapult - (int)(aCatapult * ratio);
            noble = aNoble - (int)(aNoble * ratio);
            scout = aScout - (int)(aScout * ratio);

            return true;
        }
        else
        {
            ratio = totalAttack * (totalDefense - totalAttack) / totalAttack;

            spear = dSpear - (int)(dSpear * ratio);
            sword = dSword - (int)(dSword * ratio);
            axe = dAxe - (int)(dAxe * ratio);
            bowman = dBowman - (int)(dBowman * ratio);
            light = dLight - (int)(dLight * ratio);
            heavy = dHeavy - (int)(dHeavy * ratio);
            mounted = dMounted - (int)(dMounted * ratio);
            ram = dRam - (int)(dRam * ratio);
            catapult = dCatapult - (int)(dCatapult * ratio);
            noble = dNoble - (int)(dNoble * ratio);
            scout = aScout - (int)(dScout * ratio);
            
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
