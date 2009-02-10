using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Beans
{
    public class Group
    {
        #region Variables
        private int id;
        private string name;
        private List<User> members;
        private List<Group> allies;
        private List<Group> naps;
        private List<Group> enemies;

        
        
        #endregion

        #region Properties
        public List<Group> Enemies
        {
            get { return enemies; }
            set { enemies = value; }
        }

        public List<Group> Naps
        {
            get { return naps; }
            set { naps = value; }
        }

        public List<Group> Allies
        {
            get { return allies; }
            private set { allies = value; }
        }

        public List<User> Members
        {
            get { return members; }
            private set { members = value; }
        }
        

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public int ID
        {
            get { return id; }
            set { id = value; }
        }
        #endregion

        #region Constructors
        public Group()
        {
            this.allies = new List<Group>();
            this.enemies = new List<Group>();
            this.naps = new List<Group>();
            this.members = new List<User>();
        }

        public Group(int id):this()
        {
            this.id = id;
        }
        #endregion

        #region Methods

        #endregion
    }
}
