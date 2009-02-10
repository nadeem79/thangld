using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Beans
{
    public class User
    {
        #region Variable
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

        public List<Village> Villages
        {
            get { return villages; }
            set { villages = value; }
        }

        public string Username
        {
            get { return username; }
            set { username = value; }
        }

        #endregion

        #region Constructors
        public User()
        {
            this.villages = new List<Village>();
        }

        public User(string username):this()
        {
            this.username = username;

        }
        #endregion
    }
}
