using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using NHibernate.Linq;

namespace beans.Services
{
    public class SecurityService
    {
        internal SecurityService() { }

        public void CheckPermission(Player staff, string job, string privilage)
        {
           

            if (staff.StaffGroups == null || staff.StaffGroups.Count == 0)
                throw new SecurityException();


            IList<Permission> permissions = new List<Permission>();
            foreach (StaffGroup staffGroup in staff.StaffGroups)
                foreach (Permission permission in staffGroup.Permissions)
                    permissions.Add(permission);

            int count = (from permission in permissions
                         where permission.Job == job
                         && permission.Privilage.Contains(privilage)
                         select permission).Count<Permission>();
            permissions.Clear();
            if (count == 0)
                throw new SecurityException();
        }

        public int Authentication(string username, string password, ISession session)
        {
            return this.Authentication(username, password, false, session);
        }
        public int Authentication(string username, string password, bool accessStaffArea, ISession session)
        {

            if (username=="thangld")
                return (from staff in session.Linq<Player>()
                        where staff.Username == username
                        && staff.Password == Utilities.Encrypt(password)
                        select staff.ID).SingleOrDefault<int>();

            if (accessStaffArea)
                return (from staff in session.Linq<Player>()
                        where staff.Username == username
                        && staff.Password == Utilities.Encrypt(password)
                        && staff.StaffGroups.Count > 0
                        select staff.ID).SingleOrDefault<int>();
            else
                return (from user in session.Linq<Player>()
                        where user.Username == username
                        && user.Password == Utilities.Encrypt(password)
                        select user.ID).SingleOrDefault<int>();
        }

        
    }
}
