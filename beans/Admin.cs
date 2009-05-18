using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;
using System.IO;
using NHibernate;
using NHibernate.Criterion;
using System.Text.RegularExpressions;
using System.Collections;
using System.Linq;
using NHibernate.Type;
using Antlr.StringTemplate;

namespace beans
{
   public class Admin:IdentityObject
    {
        #region Variable
        private string username;
        private string password;
        private string email;
        #endregion

        #region Properties
        public virtual DateTime Birthdate
        {
            get;
            set;
        }
        public virtual Sex Gender
        {
            get;
            set;
        }
        public virtual string Username
        {
            get { return username; }
            set 
            {
                if (!String.IsNullOrEmpty(value))
                    username = value;
                else
                    throw new ArgumentException("Tên đăng nhập không được rỗng");
            }
        }
        public virtual string Password
        {
            get { return this.password; }
            set 
            {
                if (!String.IsNullOrEmpty(value))
                    this.password = value;
                else
                    throw new ArgumentException("Mật khẩu không được rỗng");
            }
        }
        public virtual string Yahoo
        {
            get;
            set;
        }
        public virtual string Address
        {
            get;
            set;
        }
        public virtual string Skype
        {
            get;
            set;
        }
        public virtual string Msn
        {
            get;
            set;
        }
        public virtual string Email
        {
            get
            {
                return this.email;
            }
            set
            {
                if (String.IsNullOrEmpty(value))
                    throw new ArgumentException("Email không được rỗng");
                int nFirstAT = value.IndexOf('@');
                int nLastAT = value.LastIndexOf('@');

                if ((nFirstAT > 0) && (nLastAT == nFirstAT) && (nFirstAT < (value.Length - 1)))
                {
                    if (Regex.IsMatch(value, @"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"))
                        email = value;
                }
                else
                    throw new ArgumentException("Email phải đúng định dạng xxx@xxx.xxx");
            }
        }
        public virtual string Description
        {
            get;
            set;
        }
        public virtual bool Avatar
        {
            get;
            set;
        }
        #endregion

        #region Static Member
        public static int Authentication(string username, string password, ISession session)
        {
            IQuery query = session.CreateQuery("select admin.ID from admin where admin.Username=:username and admin.Password=:password");
            query.SetString("username", username);
            query.SetString("password", password);
            IList<int> lst = query.List<int>();
            if (lst.Count == 0)
                return -1;
            return lst[0];

        }
        public static Player GetPlayerID(string Receiver, ISession session)
        {
            IQuery query = session.CreateQuery("select *.* from Player as user where user.Username=:Receiver");
            query.SetString("Receiver", Receiver);
            IList<Player> lst = query.List<Player>();
            if (lst.Count == 0)
                return null;
            return lst[0];

        }

        #endregion
        #region Methods
        public IList<Player> GetUserlist(int page, ISession session)
        {
            ICriteria criteria = session.CreateCriteria(typeof(Player));
            criteria.AddOrder(Order.Desc("ID"));
            criteria.SetMaxResults(40);
            criteria.SetFirstResult(page * 40);
            return criteria.List<Player>();
        }
        #endregion  

    }
}
