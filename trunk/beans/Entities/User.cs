using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;
using System.IO;
using NHibernate;
using NHibernate.Criterion;
using System.Text.RegularExpressions;
using System.Collections;

namespace beans
{
    public class User:IdentityObject
    {
        #region Variable
        private byte[] KEY = ASCIIEncoding.ASCII.GetBytes("Thu Hương dễ thương");
        private string username;
        private IList<Village> villages;
        private Group tribe;
        private Sex gender;
        private DateTime birthdate;
        private string yahoo;
        private string skype;
        private string avatar;
        private string address;
        private string password;

        public virtual string Address
        {
            get { return address; }
            set { address = value; }
        }

        public virtual string Skype
        {
            get { return skype; }
            set { skype = value; }
        }
        private string msn;

        public virtual string Msn
        {
            get { return msn; }
            set { msn = value; }
        }
        private string email;

        public virtual string Email
        {
            get { return email; }
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
        private string description;

        public virtual string Description
        {
            get { return description; }
            set { description = value; }
        }

        public virtual string Avatar
        {
            get { return avatar; }
            set { avatar = value; }
        }
        #endregion

        #region Properties
        public virtual DateTime Birthdate
        {
            get { return birthdate; }
            set { birthdate = value; }
        }

        public virtual Sex Gender
        {
            get { return gender; }
            set { gender = value; }
        }

        public virtual Group Tribe
        {
            get { return tribe;}
            set { tribe = value; }
        }

        public virtual IList<Village> Villages
        {
            get { return villages; }
            set { villages = value; }
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
            get { return this.yahoo; }
            set { this.yahoo = value; }
        }


        #endregion

        #region Constructors
        public User()
        {
            this.villages = new List<Village>();
        }
        #endregion

        #region Methods
        public static int Authentication(string username, string password, ISession session)
        {
            

            //DESCryptoServiceProvider cryptoProvider = new DESCryptoServiceProvider();
            //MemoryStream memoryStream = new MemoryStream();
            //CryptoStream cryptoStream = new CryptoStream(memoryStream,
            //    cryptoProvider.CreateEncryptor(KEY, KEY), CryptoStreamMode.Write);
            //StreamWriter writer = new StreamWriter(cryptoStream);
            //writer.Write(password);
            //writer.Flush();
            //cryptoStream.FlushFinalBlock();
            //writer.Flush();
            //password = Convert.ToBase64String(memoryStream.GetBuffer(), 0, (int)memoryStream.Length);

            IQuery query = session.CreateQuery("select user.ID from User as user where user.Username=:username and user.Password=:password");
            query.SetString("username", username);
            query.SetString("password", password);
            return ((int)query.List()[0]);

        }
        #endregion

        #region Methods

        public void Update(DateTime time, ISession session)
        {
            if (this.Villages.Count == 0)
            {
                Village village = Village.CreateVillage(session);
                village.Owner = this;
                this.Villages.Add(village);
                village.LastUpdate = time;
                session.Save(village);
            }
            foreach (Village village in this.Villages)
                village.Update(time, session);
        }

        public virtual Village GetVillage(int ID, ISession session)
        {
            ICriteria criteria = session.CreateCriteria(typeof(Village));
            criteria.Add(Expression.Eq("Owner", this));
            criteria.Add(Expression.Eq("ID", ID));
            IList<Village> list = criteria.List<Village>();
            if (list.Count == 0)
                return null;
            return list[0];
        }

        public virtual int GetVillageCount(ISession session)
        {
            IQuery query = session.CreateQuery("select count(v.ID) from Village v where v.Owner.ID=:userID");
            query.SetInt32("userID", this.ID);
            IList lst = query.List();
            if (lst.Count == 0)
                return 0;
            Int64 i = (long)lst[0];
            return (Int32)i;
        }

        #endregion
    }
}
