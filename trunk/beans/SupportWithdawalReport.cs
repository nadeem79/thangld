using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace beans
{
    public class SupportWithdawalReport : Report
    {
        private Village from, to;
        private int spearSent, swordSent, axeSent, scoutSent, lightSent, heavySent, ramSent, catapultSent, nobleSent;

        #region Properties


        public override ReportType Type
        {
            get { return ReportType.SupportWithdawal; }
        }

        public virtual Village From
        {
            get { return this.from; }
            set { this.from = value; }
        }

        public virtual Village To
        {
            get { return this.to; }
            set { this.to = value; }
        }

        public virtual int Spear
        {
            get { return spearSent; }
            set { spearSent = value; }
        }

        public virtual int Sword
        {
            get { return swordSent; }
            set { swordSent = value; }
        }

        public virtual int Axe
        {
            get { return axeSent; }
            set { axeSent = value; }
        }

        public virtual int Scout
        {
            get { return scoutSent; }
            set { scoutSent = value; }
        }

        public virtual int Light
        {
            get { return lightSent; }
            set { lightSent = value; }
        }

        public virtual int Heavy
        {
            get { return heavySent; }
            set { heavySent = value; }
        }

        public virtual int Ram
        {
            get { return ramSent; }
            set { ramSent = value; }
        }

        public virtual int Catapult
        {
            get { return catapultSent; }
            set { catapultSent = value; }
        }

        public virtual int Noble
        {
            get { return nobleSent; }
            set { nobleSent = value; }
        }
        #endregion

    }
}
