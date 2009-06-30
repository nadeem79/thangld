using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace beans
{
    public class DefenseReport:Report
    {

        #region Properties

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

        public virtual int SpearReturnt
        {
            get;
            set;
        }
        public virtual int AxeReturnt
        {
            get;
            set;
        }
        public virtual int SwordReturnt
        {
            get;
            set;
        }
        public virtual int ScoutReturnt
        {
            get;
            set;
        }
        public virtual int LightCavalryReturnt
        {
            get;
            set;
        }
        public virtual int HeavyCavalryReturnt
        {
            get;
            set;
        }
        public virtual int RamReturnt
        {
            get;
            set;
        }
        public virtual int CatapultReturnt
        {
            get;
            set;
        }
        public virtual int NobleReturnt
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

        public virtual int SpearSurvived
        {
            get;
            set;
        }
        public virtual int AxeSurvived
        {
            get;
            set;
        }
        public virtual int SwordSurvived
        {
            get;
            set;
        }
        public virtual int ScoutSurvived
        {
            get;
            set;
        }
        public virtual int LightCavalrySurvived
        {
            get;
            set;
        }
        public virtual int HeavyCavalrySurvived
        {
            get;
            set;
        }
        public virtual int RamSurvived
        {
            get;
            set;
        }
        public virtual int CatapultSurvived
        {
            get;
            set;
        }
        public virtual int NobleSurvived
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

        public ReportType Type
        {
            get { return ReportType.Defense; }
        }

        #endregion

    }
}
