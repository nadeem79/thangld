using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TWLib
{
    public class Movement
    {
        #region Variables
        private int id;
        private int nobleSent;
        private Village from;
        private Village to;
        private User fromPlayer;
        private User toPlayer;
        private MoveType type;
        private DateTime start;
        private BuildingType building;
        private bool hide;
        private int woodSent;
        private int claySent;
        private int scoutSent;
        private int spearSent;
        private int swordSent;
        private int axeSent;
        private int lightSent;
        private int catapultSent;
        private int heavySent;
        private int ramSent;

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
        
        public DateTime Start
        {
            get { return start; }
            set { start = value; }
        }
        
        public BuildingType Building
        {
            get { return building; }
            set { building = value; }
        }
        
        public bool Hide
        {
            get { return hide; }
            set { hide = value; }
        }
        
        public int WoodSent
        {
            get { return woodSent; }
            set { woodSent = value; }
        }
        
        public int ClaySent
        {
            get { return claySent; }
            set { claySent = value; }
        }
        private int ironSent;

        public int IronSent
        {
            get { return ironSent; }
            set { ironSent = value; }
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
        #endregion

        #region Constructors
        public Movement()
        {

        }

        public Movement(int ID):this()
        {

        }

        #endregion

    }
}
