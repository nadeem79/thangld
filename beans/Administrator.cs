using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace beans
{
    public class Administrator
    {
        public int ID
        {
            get;
            set;
        }

        public string Username
        {
            get;
            set;
        }

        public string Password
        {
            get;
            set;
        }

        public string Name
        {
            get;
            set;
        }

        public DateTime Birthdate
        {
            get;
            set;
        }

        public beans.Sex Gender
        {
            get;
            set;
        }

        public string Email
        {
            get;
            set;
        }

        public Administrator Authentication()
        {
            throw new System.NotImplementedException();
        }

        public void ChangeGroupInfo(Group g, NHibernate.ISession session)
        {
            throw new System.NotImplementedException();
        }

        public void ChangePlayerInfo(Player player, NHibernate.ISession session)
        {
            throw new System.NotImplementedException();
        }

        public void DeleteShoutboxItem(ShoutboxData item, NHibernate.ISession session)
        {
            throw new System.NotImplementedException();
        }

        public Administrator CreateNewAdministratorMember(NHibernate.ISession session)
        {
            throw new System.NotImplementedException();
        }

        public void ChangeAdministratorInfo(Administrator admin, NHibernate.ISession session)
        {
            throw new System.NotImplementedException();
        }
    }
}
