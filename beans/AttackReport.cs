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

        public virtual int SpearSent
        {
            get;
            set;
        }
        public virtual int AxeSent
        {
            get;
            set;
        }
        public virtual int SwordSent
        {
            get;
            set;
        }
        public virtual int ScoutSent
        {
            get;
            set;
        }
        public virtual int LightCavalrySent
        {
            get;
            set;
        }
        public virtual int HeavyCavalrySent
        {
            get;
            set;
        }
        public virtual int RamSent
        {
            get;
            set;
        }
        public virtual int CatapultSent
        {
            get;
            set;
        }
        public virtual int NobleSent
        {
            get;
            set;
        }

        public virtual int SpearAttackDead
        {
            get;
            set;
        }
        public virtual int AxeAttackDead
        {
            get;
            set;
        }
        public virtual int SwordAttackDead
        {
            get;
            set;
        }
        public virtual int ScoutAttackDead
        {
            get;
            set;
        }
        public virtual int LightCavalryAttackDead
        {
            get;
            set;
        }
        public virtual int HeavyCavalryAttackDead
        {
            get;
            set;
        }
        public virtual int RamAttackDead
        {
            get;
            set;
        }
        public virtual int CatapultAttackDead
        {
            get;
            set;
        }
        public virtual int NobleAttackDead
        {
            get;
            set;
        }

        public virtual int SpearDefense
        {
            get;
            set;
        }
        public virtual int AxeDefense
        {
            get;
            set;
        }
        public virtual int SwordDefense
        {
            get;
            set;
        }
        public virtual int ScoutDefense
        {
            get;
            set;
        }
        public virtual int LightCavalryDefense
        {
            get;
            set;
        }
        public virtual int HeavyCavalryDefense
        {
            get;
            set;
        }
        public virtual int RamDefense
        {
            get;
            set;
        }
        public virtual int CatapultDefense
        {
            get;
            set;
        }
        public virtual int NobleDefense
        {
            get;
            set;
        }

        public virtual int SpearDefenseDead
        {
            get;
            set;
        }
        public virtual int AxeDefenseDead
        {
            get;
            set;
        }
        public virtual int SwordDefenseDead
        {
            get;
            set;
        }
        public virtual int ScoutDefenseDead
        {
            get;
            set;
        }
        public virtual int LightCavalryDefenseDead
        {
            get;
            set;
        }
        public virtual int HeavyCavalryDefenseDead
        {
            get;
            set;
        }
        public virtual int RamDefenseDead
        {
            get;
            set;
        }
        public virtual int CatapultDefenseDead
        {
            get;
            set;
        }
        public virtual int NobleDefenseDead
        {
            get;
            set;
        }

        public virtual int Wood
        {
            get;
            set;
        }
        public virtual int Clay
        {
            get;
            set;
        }
        public virtual int Iron
        {
            get;
            set;
        }

        public virtual BuildingType Building
        {
            get;
            set;
        }
        public virtual int WallAfter
        {
            get;
            set;
        }
        public virtual int WallBefore
        {
            get;
            set;
        }
        public virtual int BuildingAfter
        {
            get;
            set;
        }
        public virtual int BuildingBefore
        {
            get;
            set;
        }
        public virtual int LoyalAfter
        {
            get;
            set;
        }
        public virtual int LoyalBefore
        {
            get;
            set;
        }
        public virtual bool SuccessAttack
        {
            get;
            set;
        }
        public virtual double Morale
        {
            get;
            set;
        }
        public virtual double Luck
        {
            get;
            set;
        }
        public virtual Village FromVillage
        {
            get;
            set;
        }
        public virtual Village ToVillage
        {
            get;
            set;
        }

        public virtual Player FromPlayer
        {
            get;
            set;
        }
        public virtual Player ToPlayer
        {
            get;
            set;
        }
    }
}
