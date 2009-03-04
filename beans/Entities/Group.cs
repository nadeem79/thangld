using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace beans
{
    public class Group
    {
        #region Variables
        private int id;
        private string tag;
        private string name;
        private string description;
        private string introduction;
        private List<User> inviteList;
        private List<User> members;
        private List<Group> allies;
        private List<Group> naps;
        private List<Group> enemies;

        #endregion

        #region Properties
        public virtual List<Group> Enemies
        {
            get { return enemies; }
            set { enemies = value; }
        }

        public virtual List<Group> Naps
        {
            get { return naps; }
            set { naps = value; }
        }

        public virtual List<Group> Allies
        {
            get { return allies; }
            private set { allies = value; }
        }

        public virtual List<User> Members
        {
            get { return members; }
            private set { members = value; }
        }
        

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public virtual int ID
        {
            get { return id; }
            set { id = value; }
        }

        public virtual string Tag
        {
            get { return this.tag; }
            set { this.tag = value; }
        }

        public virtual string Description
        {
            get { return this.description; }
            set { this.description = value; }
        }

        public virtual string Introduction
        {
            get { return this.introduction; }
            set { this.introduction = value; }
        }

        #endregion

        #region Constructors
        public Group()
        {
            this.allies = new List<Group>();
            this.enemies = new List<Group>();
            this.naps = new List<Group>();
            this.members = new List<User>();
            this.inviteList = new List<User>();
        }

        #endregion

        #region Methods

        #endregion
    }
}
