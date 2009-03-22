using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace beans
{
    public class AttackReport:Report
    {
        public AttackReport() { }

        public override ReportType Type
        {
            get { return ReportType.Attack; }
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
        public  int LightSent
        {
            get;
            set;
        }
        public  int HeavySent
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

        public  int SpearReturnt
        {
            get;
            set;
        }
        public  int AxeReturnt
        {
            get;
            set;
        }
        public  int SwordReturnt
        {
            get;
            set;
        }
        public  int ScoutReturnt
        {
            get;
            set;
        }
        public  int LightReturnt
        {
            get;
            set;
        }
        public  int HeavyReturnt
        {
            get;
            set;
        }
        public  int RamReturnt
        {
            get;
            set;
        }
        public  int CatapultReturnt
        {
            get;
            set;
        }
        public  int NobleReturnt
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
        public  int LightDefense
        {
            get;
            set;
        }
        public  int HeavyDefense
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

        public  int SpearSurvived
        {
            get;
            set;
        }
        public  int AxeSurvived
        {
            get;
            set;
        }
        public  int SwordSurvived
        {
            get;
            set;
        }
        public  int ScoutSurvived
        {
            get;
            set;
        }
        public  int LightSurvived
        {
            get;
            set;
        }
        public  int HeavySurvived
        {
            get;
            set;
        }
        public  int RamSurvived
        {
            get;
            set;
        }
        public  int CatapultSurvived
        {
            get;
            set;
        }
        public  int NobleSurvived
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
        public  int LoyalAfter
        {
            get;
            set;
        }
        public  int LoyalBefore
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
        public Village From
        {
            get;
            set;
        }
        public Village To
        {
            get;
            set;
        }
    }
}
