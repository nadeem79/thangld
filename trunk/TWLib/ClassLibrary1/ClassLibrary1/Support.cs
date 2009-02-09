using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TWLib
{
    public class Support
    {
        #region Variables
        private int id;
        private Village from;
        private Village to;
        private User fromPlayer;
        private User toPlayer;
        private MoveType type;
        private DateTime startingTime;
        private DateTime landingTime;
        private bool stationed = false;

        private int scoutSent;
        private int spearSent;
        private int swordSent;
        private int axeSent;
        private int lightSent;
        private int heavySent;
        private int ramSent;
        private int catapultSent;
        private int nobleSent;
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

        public DateTime LandingTime
        {
            get
            {
                //if (landingTime!=null)
                return landingTime;

            }
            set { landingTime = value; }
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

        public bool Stationed
        {
            get { return stationed; }
            set { stationed = value; }
        }
        #endregion

        #region Constructors
        public Support()
        {

        }

        public Support(int ID)
            : this()
        {

        }
        #endregion
    }
}
