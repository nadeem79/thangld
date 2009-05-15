using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using NHibernate.Criterion;

namespace beans
{
    public class WriteMail : IdentityObject
    {
        public int From
        {
            get;
            set;
        }
        public int To
        {
            get;
            set;
        }
        public DateTime Time
        {
            get;
            set;
        }

        public string Title
        {
            get;
            set;
        }
        public string Detail
        {
            get;
            set;
        }
        public bool Unread
        {
            get;
            set;
        }
        public bool SenderDelete
        {
            get;
            set;
        }
        public bool ReceiverDelete
        {
            get;
            set;
        }

        #region Static Member
        public static int GetPlayerID(string Receiver, ISession session)
        {
            IQuery query = session.CreateQuery("select user.ID from Player as user where user.Username=:Receiver");
            query.SetString("Receiver", Receiver);
            IList<int> lst = query.List<int>();
            if (lst.Count == 0)
                return -1 ;
            return lst[0];

        }
        #endregion;
    }
}