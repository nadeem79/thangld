using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace beans
{
    public class DefenseOtherReport : Report
    {

        #region Variables

        private int spearDefense, swordDefense, axeDefense, scoutDefense, lightDefense, heavyDefense, ramDefense, catapultDefense, nobleDefense;
        private int spearSurvived, swordSurvived, axeSurvived, scoutSurvived, lightSurvived, heavySurvived, ramSurvived, catapultSurvived, nobleSurvived;
        #endregion

        #region Properties

        public override ReportType Type
        {
            get { return ReportType.DefenseOther; }
        }

        public virtual int SpearDefense
        {
            get { return this.spearDefense; }
            set { this.spearDefense = value; }
        }
        public virtual int AxeDefense
        {
            get { return this.axeDefense; }
            set { this.axeDefense = value; }
        }
        public virtual int SwordDefense
        {
            get { return this.swordDefense; }
            set { this.swordDefense = value; }
        }
        public virtual int ScoutDefense
        {
            get { return this.scoutDefense; }
            set { this.scoutDefense = value; }
        }
        public virtual int LightDefense
        {
            get { return this.lightDefense; }
            set { this.lightDefense = value; }
        }
        public virtual int HeavyDefense
        {
            get { return this.heavyDefense; }
            set { this.heavyDefense = value; }
        }
        public virtual int RamDefense
        {
            get { return this.ramDefense; }
            set { this.ramDefense = value; }
        }
        public virtual int CatapultDefense
        {
            get { return this.catapultDefense; }
            set { this.catapultDefense = value; }
        }
        public virtual int NobleDefense
        {
            get { return this.nobleDefense; }
            set { this.nobleDefense = value; }
        }

        public virtual int SpearSurvived
        {
            get { return this.spearSurvived; }
            set { this.spearSurvived = value; }
        }
        public virtual int AxeSurvived
        {
            get { return this.axeSurvived; }
            set { this.axeSurvived = value; }
        }
        public virtual int SwordSurvived
        {
            get { return this.swordSurvived; }
            set { this.swordSurvived = value; }
        }
        public virtual int ScoutSurvived
        {
            get { return this.scoutSurvived; }
            set { this.scoutSurvived = value; }
        }
        public virtual int LightSurvived
        {
            get { return this.lightSurvived; }
            set { this.lightSurvived = value; }
        }
        public virtual int HeavySurvived
        {
            get { return this.heavySurvived; }
            set { this.heavySurvived = value; }
        }
        public virtual int RamSurvived
        {
            get { return this.ramSurvived; }
            set { this.ramSurvived = value; }
        }
        public virtual int CatapultSurvived
        {
            get { return this.catapultSurvived; }
            set { this.catapultSurvived = value; }
        }
        public virtual int NobleSurvived
        {
            get { return this.nobleSurvived; }
            set { this.nobleSurvived = value; }
        }
        #endregion


        public DefenseOtherReport()
        {
            
        }
    }
}
