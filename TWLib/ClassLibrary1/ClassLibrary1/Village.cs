using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassLibrary1
{
    


    public class Village
    {
        #region Variables

        private int id;
        private int x;
        private int y;
        private string name;
        private User owner;
        private int wood;
        private int iron;
        private int clay;
        private int headquarter;
        private int barracks;
        private int stable;
        private int workshop;
        private int academy;
        private int smithy;
        private int rally;
        private int market;
        private int timberCamp;
        private int clayPit;
        private int ironMine;
        private int farm;
        private int warehouse;
        private int hidingPlace;
        private int wall;
        private int points;
        private DateTime lastUpdate;

        
        #endregion

        #region Properties
        public DateTime LastUpdate
        {
            get { return lastUpdate; }
            set { lastUpdate = value; }
        }
        public int Points
        {
            get { return points; }
            set { points = value; }
        }
        public int Wall
        {
            get { return wall; }
            set { wall = value; }
        }

        public int HidingPlace
        {
            get { return hidingPlace; }
            set { hidingPlace = value; }
        }

        public int Warehouse
        {
            get { return warehouse; }
            set { warehouse = value; }
        }

        public int Farm
        {
            get { return farm; }
            set { farm = value; }
        }

        public int IronMine
        {
            get { return ironMine; }
            set { ironMine = value; }
        }

        public int ClayPit
        {
            get { return clayPit; }
            set { clayPit = value; }
        }


        public int TimberCamp
        {
            get { return timberCamp; }
            set { timberCamp = value; }
        }


        public int Market
        {
            get { return market; }
            set { market = value; }
        }

        public int Rally
        {
            get { return rally; }
            set { rally = value; }
        }

        public int Smithy
        {
            get { return smithy; }
            set { smithy = value; }
        }


        public int Academy
        {
            get { return academy; }
            set { academy = value; }
        }

        public int Workshop
        {
            get { return workshop; }
            set { workshop = value; }
        }

        public int Stable
        {
            get { return stable; }
            set { stable = value; }
        }

        public int Barracks
        {
            get { return barracks; }
            set { barracks = value; }
        }

        public int Headquarter
        {
            get { return headquarter; }
            set { headquarter = value; }
        }


        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        public int X
        {
            get { return x; }
            set { x = value; }
        }
        public int Y
        {
            get { return y; }
            set { y = value; }
        }
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        

        public User Owner
        {
            get { return owner; }
            set { owner = value; }
        }
        public int Wood 
        { 
            get 
            {
                return this.wood;
            } 

            set
            {
                this.wood = value;
            } 
        
        }
        public int Clay 
        { 
            get
            {
                return this.clay;
            }
            set
            {
                this.clay = value;
            }
        }
        public int Iron
        {
            get
            {
                return this.iron;
            }
            set
            {
                this.iron = value;
            }
        }
        #endregion

        #region Constructors
        public Village() { }
        public Village(int id):this()
        {
            this.id = id;

        }
        #endregion

        #region Methods

        #endregion
    }
}
