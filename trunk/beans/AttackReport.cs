using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace beans
{
    public class AttackReport:Report
    {

        public override ReportType Type
        {
            get
            {
                return ReportType.Attack;
            }

        }

        public  int SpearSent
        {
            get;
            set;
        }
        public  int AxeSent
        {
            get;
            set;
        }
        public  int SwordSent
        {
            get;
            set;
        }
        public  int ScoutSent
        {
            get;
            set;
        }
        public  int LightCavalrySent
        {
            get;
            set;
        }
        public int HeavyCavalrySent
        {
            get;
            set;
        }
        public  int RamSent
        {
            get;
            set;
        }
        public  int CatapultSent
        {
            get;
            set;
        }
        public  int NobleSent
        {
            get;
            set;
        }

        public  int SpearAttackDead
        {
            get;
            set;
        }
        public  int AxeAttackDead
        {
            get;
            set;
        }
        public  int SwordAttackDead
        {
            get;
            set;
        }
        public  int ScoutAttackDead
        {
            get;
            set;
        }
        public int LightCavalryAttackDead
        {
            get;
            set;
        }
        public int HeavyCavalryAttackDead
        {
            get;
            set;
        }
        public  int RamAttackDead
        {
            get;
            set;
        }
        public  int CatapultAttackDead
        {
            get;
            set;
        }
        public  int NobleAttackDead
        {
            get;
            set;
        }

        public  int SpearDefense
        {
            get;
            set;
        }
        public  int AxeDefense
        {
            get;
            set;
        }
        public  int SwordDefense
        {
            get;
            set;
        }
        public  int ScoutDefense
        {
            get;
            set;
        }
        public int LightCavalryDefense
        {
            get;
            set;
        }
        public int HeavyCavalryDefense
        {
            get;
            set;
        }
        public  int RamDefense
        {
            get;
            set;
        }
        public  int CatapultDefense
        {
            get;
            set;
        }
        public  int NobleDefense
        {
            get;
            set;
        }

        public  int SpearDefenseDead
        {
            get;
            set;
        }
        public  int AxeDefenseDead
        {
            get;
            set;
        }
        public  int SwordDefenseDead
        {
            get;
            set;
        }
        public  int ScoutDefenseDead
        {
            get;
            set;
        }
        public int LightCavalryDefenseDead
        {
            get;
            set;
        }
        public int HeavyCavalryDefenseDead
        {
            get;
            set;
        }
        public  int RamDefenseDead
        {
            get;
            set;
        }
        public  int CatapultDefenseDead
        {
            get;
            set;
        }
        public  int NobleDefenseDead
        {
            get;
            set;
        }

        public  int Wood
        {
            get;
            set;
        }
        public  int Clay
        {
            get;
            set;
        }
        public  int Iron
        {
            get;
            set;
        }

        public  BuildingType Building
        {
            get;
            set;
        }
        public  int WallAfter
        {
            get;
            set;
        }
        public  int WallBefore
        {
            get;
            set;
        }
        public  int BuildingAfter
        {
            get;
            set;
        }
        public  int BuildingBefore
        {
            get;
            set;
        }
        public  double LoyalAfter
        {
            get;
            set;
        }
        public double LoyalBefore
        {
            get;
            set;
        }
        public  bool SuccessAttack
        {
            get;
            set;
        }
        public  double Morale
        {
            get;
            set;
        }
        public  double Luck
        {
            get;
            set;
        }
        public Village FromVillage
        {
            get;
            set;
        }
        public Village ToVillage
        {
            get;
            set;
        }

        public Player FromPlayer
        {
            get;
            set;
        }
        public Player ToPlayer
        {
            get;
            set;
        }
    }
}
