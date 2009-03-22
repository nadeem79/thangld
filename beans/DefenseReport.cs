using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace beans
{
    public class DefenseReport:Report
    {

        #region Variables
        private Village from, to;
        private int spearSent, swordSent, axeSent, scoutSent, lightSent, heavySent, ramSent, catapultSent, nobleSent;
        private int spearReturnt, swordReturnt, axeReturnt, scoutReturnt, lightReturnt, heavyReturnt, ramReturnt, catapultReturnt, nobleReturnt;
        private int spearDefense, swordDefense, axeDefense, scoutDefense, lightDefense, heavyDefense, ramDefense, catapultDefense, nobleDefense;
        private int spearSurvived, swordSurvived, axeSurvived, scoutSurvived, lightSurvived, heavySurvived, ramSurvived, catapultSurvived, nobleSurvived;
        private int wood, clay, iron;
        private BuildingType building;
        private int wallAfter, wallBefore, buildingAfter, buildingBefore, loyalAfter, loyalBefore;
        private bool successAttack;
        private double morale, luck;
        #endregion

        #region Properties

        public Village From
        {
            get { return this.from; }
            set { this.from = value; }
        }

        public Village To
        {
            get { return this.to; }
            set { this.to = value; }
        }

        public virtual int SpearSent
        {
            get { return this.spearSent; }
            set { this.spearSent = value; }
        }
        public virtual int AxeSent
        {
            get { return this.axeSent; }
            set { this.axeSent = value; }
        }
        public virtual int SwordSent
        {
            get { return this.swordSent; }
            set { this.swordSent = value; }
        }
        public virtual int ScoutSent
        {
            get { return this.scoutSent; }
            set { this.scoutSent = value; }
        }
        public virtual int LightSent
        {
            get { return this.lightSent; }
            set { this.lightSent = value; }
        }
        public virtual int HeavySent
        {
            get { return this.heavySent; }
            set { this.heavySent = value; }
        }
        public virtual int RamSent
        {
            get { return this.ramSent; }
            set { this.ramSent = value; }
        }
        public virtual int CatapultSent
        {
            get { return this.catapultSent; }
            set { this.catapultSent = value; }
        }
        public virtual int NobleSent
        {
            get { return this.nobleSent; }
            set { this.nobleSent = value; }
        }

        public virtual int SpearReturnt
        {
            get { return this.spearReturnt; }
            set { this.spearReturnt = value; }
        }
        public virtual int AxeReturnt
        {
            get { return this.axeReturnt; }
            set { this.axeReturnt = value; }
        }
        public virtual int SwordReturnt
        {
            get { return this.swordReturnt; }
            set { this.swordReturnt = value; }
        }
        public virtual int ScoutReturnt
        {
            get { return this.scoutReturnt; }
            set { this.scoutReturnt = value; }
        }
        public virtual int LightReturnt
        {
            get { return this.lightReturnt; }
            set { this.lightReturnt = value; }
        }
        public virtual int HeavyReturnt
        {
            get { return this.heavyReturnt; }
            set { this.heavyReturnt = value; }
        }
        public virtual int RamReturnt
        {
            get { return this.ramReturnt; }
            set { this.ramReturnt = value; }
        }
        public virtual int CatapultReturnt
        {
            get { return this.catapultReturnt; }
            set { this.catapultReturnt = value; }
        }
        public virtual int NobleReturnt
        {
            get { return this.nobleReturnt; }
            set { this.nobleReturnt = value; }
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

        public virtual int Wood
        {
            get { return this.wood; }
            set { this.wood = value; }
        }

        public virtual int Clay
        {
            get { return this.clay; }
            set { this.clay = value; }
        }

        public virtual int Iron
        {
            get { return this.iron; }
            set { this.iron = value; }
        }

        public virtual BuildingType Building
        {
            get { return this.building; }
            set { this.building = value; }
        }

        public virtual int WallAfter
        {
            get { return wallAfter; }
            set { this.wallAfter = value; }
        }

        public virtual int WallBefore
        {
            get { return this.wallBefore; }
            set { this.wallBefore = value; }
        }

        public virtual int BuildingAfter
        {
            get { return this.buildingAfter; }
            set { this.buildingAfter = value; }
        }

        public virtual int BuildingBefore
        {
            get { return this.buildingBefore; }
            set { this.buildingBefore = value; }
        }

        public virtual int LoyalAfter
        {
            get { return this.loyalAfter; }
            set { this.loyalAfter = value; }
        }

        public virtual int LoyalBefore
        {
            get { return this.loyalBefore; }
            set { this.loyalBefore = value; }
        }

        public virtual bool SuccessAttack
        {
            get { return this.successAttack; }
            set { this.successAttack = value; }
        }

        public virtual double Morale
        {
            get { return this.morale; }
            set { this.morale = value; }
        }

        public virtual double Luck
        {
            get { return this.luck; }
            set { this.luck = value; }
        }

        public override ReportType Type
        {
            get { return ReportType.Attack; }
        }

        #endregion


        #region Constructors
        #endregion
    }
}
