using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Security.Cryptography;
using System.IO;
using NHibernate;
using NHibernate.Criterion;
using System.Text.RegularExpressions;
using System.Collections;
using NHibernate.Type;
using NHibernate.UserTypes;
using NHibernate.Linq;
using System.Data;

namespace beans
{

    

    public partial class Player:IdentityObject
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
        public virtual IList<Village> Villages
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
        public virtual UserType Type
        {
            get;
            set;
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
        public bool GraphicalVillage
        {
            get;
            set;
        }
        public bool ShowBuildingLevel
        {
            get;
            set;
        }
        public double Point
        {
            get;
            set;
        }
        public Group Group
        {
            get;
            set;
        }
        public string TribeTitle
        {
            get;
            set;
        }
        public TribePermission TribePermission
        {
            get;
            set;
        }
        public IList<TribeInvite> Invites
        {
            get;
            set;
        }
        #endregion

        #region Constructors
        #endregion

        #region Static Member
        public static int Authentication(string username, string password, ISession session)
        {
            IQuery query = session.CreateQuery("select user.ID from Player as user where user.Username=:username and user.Password=:password");
            query.SetString("username", username);
            query.SetString("password", password);
            IList<int> lst = query.List<int>();
            if (lst.Count == 0)
                return -1;
            return lst[0];

        }
        public static Player GetPlayerByID(int id, ISession session)
        {
            return session.Load<Player>(id);
        }

        public static Village CheckVillage(int user, int village, ISession session)
        {
            IQuery query = session.CreateQuery("from Village v left join fetch v.Owner u where v.ID=:village_id and u.ID=:user_id");
            query.SetInt32("village_id", village);
            query.SetInt32("user_id", user);

            return query.UniqueResult<Village>();

        }


        #endregion

        #region Methods

        public override string ToString()
        {
            return this.Username;
        }

        #region Village Methods
        public MovingCommand GetCommand(int command_id, ISession session)
        {
            
            ICriteria criteria = session.CreateCriteria(typeof(MovingCommand));
            criteria.Add(Expression.Eq("ID", command_id));
            IList<MovingCommand> lstCommand = criteria.List<MovingCommand>();
            if (lstCommand.Count == 0)
                return null;

            MovingCommand command = lstCommand[0];
            if (command.FromVillage.Player != this && command.ToVillage.Player != this)
                return null;


            return command;
        }

        public Report GetReport(int report_id, ISession session)
        {
            //ICriteria criteria = session.CreateCriteria(typeof(Report));
            //criteria.Add(Expression.Eq("Owner", this));
            //criteria.Add(Expression.Eq("ID", report_id));
            //IList<Report> lstReport = criteria.List<Report>();
            //if (lstReport.Count == 0)
            //    return null;
            //return lstReport[0];
            Report report = (from r in session.Linq<Report>()
                             where r.ID == report_id
                             && r.Owner == this
                             select r).SingleOrDefault<Report>();
            if (report == null)
                return null;
            if (report.Unread)
            {
                report.Unread = false;
                session.Update(report);
            }
            return report;
        }

        public IList<Report> GetReports(int page, ISession session, params ReportType[] types)
        {

            ICriteria criteria;
            criteria = session.CreateCriteria(typeof(Report));
            
            //if (type!=ReportType.All)
            //    criteria.Add(Expression.Eq("Type", type));
            criteria.Add(Expression.Eq("Owner", this));
            if (types.Length > 0)
            {
                //Expression firstExpression = Re
                AbstractCriterion restrictions = Expression.Sql(string.Format("this_.type={0}", (int)types[0]));
                for (int i = 1; i < types.Length; i++)
                    restrictions = Expression.Sql(string.Format("this_.type={0}", (int)types[i]));
                criteria.Add(restrictions);
            }

            criteria.AddOrder(Order.Desc("ID"));
            criteria.SetMaxResults(40);
            criteria.SetFirstResult(page * 40);
            return criteria.List<Report>();
        }

        public int GetUnreadReportCount(ISession session)
        {
            return (from report in session.Linq<Report>()
                    where report.Owner == this
                    && report.Unread
                    select report).Count();
        }

        public Mail GetMailDetail(int Mail_id, ISession session)
        {
            Mail mail = (from m in session.Linq<Mail>()
                         where m.ID==Mail_id
                         && ((m.From == this && !m.SenderDelete)
                         || (m.To == this && !m.ReceiverDelete))
                         select m).SingleOrDefault<Mail>();

            if (mail == null)
                return null;

            if (mail.Unread && mail.To == this)
            {
                ITransaction trans = null;
                try
                {
                    trans = session.BeginTransaction(IsolationLevel.ReadUncommitted);
                    mail.Unread = false;
                    session.Update(mail);
                    trans.Commit();
                }
                catch (Exception ex)
                {
                    if (trans != null)
                        trans.Rollback();
                }
            }

            return mail;

        }

        public void DeleteMail(int mailId, ISession session)
        {
            Mail m = this.GetMailDetail(mailId, session);
            if (m.To == this)
                m.ReceiverDelete = true;
            else
                m.SenderDelete = true;

            if (m.SenderDelete && m.ReceiverDelete)
                session.Delete(m);
            else
                session.Update(m);
        }

        public void DeleteMail(Mail mail, ISession session)
        {
            if (mail.From != this && mail.To != this)
                return;
            if (mail.To == this)
                mail.ReceiverDelete = true;
            else
                mail.SenderDelete = true;

            if (mail.SenderDelete && mail.ReceiverDelete)
                session.Delete(mail);
            else
                session.Update(mail);
        }

        public IList<Mail> GetMailFromMe(int page, ISession session)
        {
            return (from mail in session.Linq<Mail>()
                    where mail.From == this
                    && !mail.SenderDelete
                    orderby mail.ID descending
                    select mail).Skip(page * 40).Take(40).ToList<Mail>();
        }
        public IList<Mail> GetMailToMe(int page, ISession session)
        {
            return (from mail in session.Linq<Mail>()
                    where mail.To == this
                    && !mail.ReceiverDelete
                    orderby mail.ID descending
                    select mail).Skip(page * 40).Take(40).ToList<Mail>();
        }

        public Mail SendMail(string receiverName,String title, String detail,  ISession session)
        {

            Player receiver = (from player in session.Linq<Player>()
                               where player.Username == receiverName
                               && player != this
                               select player).SingleOrDefault<Player>();

            if (receiver == null)
                throw new TribalWarsException("Người chơi không tồn tại");

            Mail mail = new Mail();
            mail.Detail = detail;
            mail.From = this;
            mail.ReceiverDelete = false;
            mail.SenderDelete = false;
            mail.Time = DateTime.Now;
            mail.Title = title;
            mail.To = receiver;
            mail.Unread = true;

            session.Save(mail);
            return mail;
        }
        
        public void Update(DateTime time, ISession session)
        {
            if (this.Villages.Count == 0)
            {
                Village village = Village.CreateVillage(session);
                village.Player = this;
                this.Villages.Add(village);
                village.LastUpdate = time;
                village.Name = "Thành phố " + this.Username;
                //session.Save(village);
                village.Save(session);
                return;
            }
            foreach (Village village in this.Villages)
                village.VillageCommonMethods.UpdateVillage(time, session);
        }

        public virtual Village GetVillage(int ID)
        {
            var village = new List<Village>(this.Villages).FindAll(delegate(Village v) { return v.ID == ID; });
            if (village.Count == 0)
                return null;
            return village[0];

        }

        public virtual int GetVillageCount(ISession session)
        {

            return (from village in session.Linq<Village>()
                    where village.Player == this
                    select village).Count<Village>();
        }
        #endregion



        #endregion


        public int GetIncomingAttackCount(ISession session)
        {
            return (from attack in session.Linq<Attack>()
                    where attack.ToVillage.Player == this
                    select attack).Count();
        }
        public int GetIncomingSupportCount(ISession session)
        {
            return (from support in session.Linq<Support>()
                    where support.ToVillage.Player == this
                    select support).Count();
        }
    }
}
