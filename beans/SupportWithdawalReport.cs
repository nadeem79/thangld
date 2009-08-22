using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace beans
{
    public class SupportWithdawalReport : Report
    {

        public override ReportType Type
        {
            get { return ReportType.SupportWithdawal; }
        }

        public virtual Village FromVillage
        {
            get;
            set;
        }

        public virtual Player FromPlayer
        {
            get;
            set;
        }

        public virtual Village OriginalVillage
        {
            get;
            set;
        }

        public virtual Player OriginalPlayer
        {
            get;
            set;
        }

        public virtual int Spear
        {
            get;
            set;
        }

        public virtual int Sword
        {
            get;
            set;
        }

        public virtual int Axe
        {
            get;
            set;
        }

        public virtual int Scout
        {
            get;
            set;
        }

        public virtual int LightCavalry
        {
            get;
            set;
        }

        public virtual int HeavyCavalry
        {
            get;
            set;
        }

        public virtual int Ram
        {
            get;
            set;
        }

        public virtual int Catapult
        {
            get;
            set;
        }

        public virtual int Noble
        {
            get;
            set;
        }

    }
}
