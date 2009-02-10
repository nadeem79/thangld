using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Beans
{
    public class Attack
    {
        #region Variables
        private int id;
        private Village from;
        private Village to;
        private User fromPlayer;
        private User toPlayer;
        private MoveType type = MoveType.Attack;
        private DateTime startingTime;
        private DateTime landingTime;
        
        private BuildingType building;

        private int scoutSent;
        private int spearSent;
        private int swordSent;
        private int axeSent;
        private int lightSent;
        private int heavySent;
        private int ramSent;
        private int catapultSent;
        private int nobleSent;
        private int wallBefore;
        private int buildingBefore;
        private int loyalBefore;

        private int spearReturnt;
        private int swordReturnt;
        private int axeReturnt;
        private int scoutReturnt;
        private int lightReturnt;
        private int heavyReturnt;
        private int ramReturnt;
        private int catapultReturnt;
        private int nobleReturnt;
        private int wallAfter;
        private int buildingAfter;
        private int loyalAfter;
        private int iron;
        private int clay;
        private int wood;
        
        #endregion

        #region Properties
        public int ID
        {
            get { return id; }
            set { id = value; }
        }

        public Village From
        {
            get { return from; }
            set { from = value; }
        }

        public Village To
        {
            get { return to; }
            set { to = value; }
        }

        public User FromPlayer
        {
            get { return fromPlayer; }
            set { fromPlayer = value; }
        }

        public User ToPlayer
        {
            get { return toPlayer; }
            set { toPlayer = value; }
        }

        public MoveType Type
        {
            get { return type; }
            set { type = value; }
        }

        public DateTime StartingTime
        {
            get { return startingTime; }
            set { startingTime = value; }
        }

        public BuildingType Building
        {
            get { return building; }
            set { building = value; }
        }

        public int SpearSent
        {
            get { return spearSent; }
            set { spearSent = value; }
        }

        public int SwordSent
        {
            get { return swordSent; }
            set { swordSent = value; }
        }

        public int AxeSent
        {
            get { return axeSent; }
            set { axeSent = value; }
        }

        public int ScoutSent
        {
            get { return scoutSent; }
            set { scoutSent = value; }
        }

        public int LightSent
        {
            get { return lightSent; }
            set { lightSent = value; }
        }

        public int HeavySent
        {
            get { return heavySent; }
            set { heavySent = value; }
        }

        public int RamSent
        {
            get { return ramSent; }
            set { ramSent = value; }
        }

        public int CatapultSent
        {
            get { return catapultSent; }
            set { catapultSent = value; }
        }

        public int NobleSent
        {
            get { return nobleSent; }
            set { nobleSent = value; }
        }

        public DateTime LandingTime
        {
            get
            {
                //if (landingTime!=null)
                return landingTime;

            }
            set { landingTime = value; }
        }

        public int WallBefore
        {
            get { return wallBefore; }
            set { wallBefore = value; }
        }

        public int BuildingBefore
        {
            get { return buildingBefore; }
            set { buildingBefore = value; }
        }

        public int LoyalBefore
        {
            get { return loyalBefore; }
            set { loyalBefore = value; }
        }

        public int SpearReturnt
        {
            get { return spearReturnt; }
            set { spearReturnt = value; }
        }

        public int SwordReturnt
        {
            get { return swordReturnt; }
            set { swordReturnt = value; }
        }

        public int AxeReturnt
        {
            get { return axeReturnt; }
            set { axeReturnt = value; }
        }

        public int ScoutReturnt
        {
            get { return scoutReturnt; }
            set { scoutReturnt = value; }
        }

        public int LightReturnt
        {
            get { return lightReturnt; }
            set { lightReturnt = value; }
        }

        public int HeavyReturnt
        {
            get { return heavyReturnt; }
            set { heavyReturnt = value; }
        }

        public int RamReturnt
        {
            get { return ramReturnt; }
            set { ramReturnt = value; }
        }

        public int CatapultReturnt
        {
            get { return catapultReturnt; }
            set { catapultReturnt = value; }
        }


        public int NobleReturnt
        {
            get { return nobleReturnt; }
            set { nobleReturnt = value; }
        }


        public int WallAfter
        {
            get { return wallAfter; }
            set { wallAfter = value; }
        }

        public int LoyalAfter
        {
            get { return loyalAfter; }
            set { loyalAfter = value; }
        }

        public int BuildingAfter
        {
            get { return buildingAfter; }
            set { buildingAfter = value; }
        }

        public int Iron
        {
            get { return iron; }
            set { iron = value; }
        }

        public int Clay
        {
            get { return clay; }
            set { clay = value; }
        }

        public int Wood
        {
            get { return wood; }
            set { wood = value; }
        }
        #endregion

        #region Constructors
        public Attack()
        {

        }

        public Attack(int ID)
            : this()
        {

        }
        #endregion
    }
}
