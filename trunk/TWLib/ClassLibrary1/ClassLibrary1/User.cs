using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassLibrary1
{
    public class User
    {
        #region Variable
        private int id;
        private string username;
        private List<Village> villages;
        private Group tribe;
        private Sex gender;
        private DateTime birthdate;
        #endregion

        #region Properties
        public DateTime Birthdate
        {
            get { return birthdate; }
            set { birthdate = value; }
        }

        public Sex Gender
        {
            get { return gender; }
            set { gender = value; }
        }

        public Group Tribe
        {
            get { return tribe;}
            set { tribe = value; }
        }

        public List<Village> AVillages
        {
            get { return aVillages; }
            set { aVillages = value; }
        }

        public string Username
        {
            get { return username; }
            set { username = value; }
        }

        public int ID
        {
            get { return id; }
            set { id = value; }
        }
        #endregion

        #region Constructors
        public User()
        {
            this.villages = new List<Village>();
        }

        public User(int id):this()
        {
            this.id = id;

        }
        #endregion
    }
}
