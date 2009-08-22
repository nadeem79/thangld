using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace beans
{
    public class DefenseOtherReport : Report
    {


        public override ReportType Type
        {
            get { return ReportType.DefenseOther; }
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

        public virtual int SpearDead
        {
            get;
            set;
        }
        public virtual int AxeDead
        {
            get;
            set;
        }
        public virtual int SwordDead
        {
            get;
            set;
        }
        public virtual int ScoutDead
        {
            get;
            set;
        }
        public virtual int LightCavalryDead
        {
            get;
            set;
        }
        public virtual int HeavyCavalryDead
        {
            get;
            set;
        }
        public virtual int RamDead
        {
            get;
            set;
        }
        public virtual int CatapultDead
        {
            get;
            set;
        }
        public virtual int NobleDead
        {
            get;
            set;
        }
    }
}
