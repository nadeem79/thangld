using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using NHibernate.Linq;

namespace beans
{
    public partial class Player
    {
        public static int StaffAuthentication(string username, string password, ISession session)
        {
            return (from staff in session.Linq<Player>()
                    where (staff.Type == UserType.Administrator || staff.Type == UserType.Moderator)
                    && staff.Username == username
                    && staff.Password == password
                    select staff.ID).SingleOrDefault<int>();
        }


    }
}
