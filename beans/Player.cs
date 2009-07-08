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
using Antlr.StringTemplate;
using NHibernate.UserTypes;
using NHibernate.Linq;

namespace beans
{

    

    public class Player:IdentityObject
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
        public static Player GetPlayerID(string Receiver, ISession session)
        {
            IQuery query = session.CreateQuery("select *.* from Player as user where user.Username=:Receiver");
            query.SetString("Receiver", Receiver);
            IList<Player> lst = query.List<Player>();
            if (lst.Count == 0)
                return null;
            return lst[0];

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

        #region Tribe Methods
        public void CreateTribe(string tag, string name, ISession session)
        {
            beans.Group group = new Group();
            group.Tag = tag;
            group.Name = name;
            group.Description = "";
            this.Group = group;
            this.TribePermission = TribePermission.Duke;
            session.Save(group);
            session.Update(this);
        }
        public void DisbandTribe(ISession session)
        {
            if (this.Group == null && this.TribePermission != beans.TribePermission.Duke)
                return;
            foreach (TribeInvite invite in this.Group.Invites)
                session.Delete(invite);
            foreach (Player member in this.Group.Members)
            {
                member.Group = null;
                session.Update(member);
            }
            session.Delete(this.Group);
        }
        public void DismissPlayer(Player player, ISession session)
        {
            if (player.Group == this.Group || ((this.TribePermission & TribePermission.DismissPlayer) == TribePermission.DismissPlayer))
                return;

            player.Group = null;
            session.Update(player);
        }
        public void ChangeDescription(string description, ISession session)
        {
            if ((this.TribePermission & TribePermission.DiplomateOfficer) == 0)
                return;
            this.Group.Description = description;
            session.Update(this.Group);
        }
        public void SetDiplomacy(Group group, TribeDiplomate diplomacy, ISession session)
        {
            if ((this.TribePermission & TribePermission.DiplomateOfficer) != TribePermission.DiplomateOfficer)
                return;
            if (this.Group == group)
                return;

            if (diplomacy == TribeDiplomate.NoRelation)
            {
                object[] objects = {this.Group, group};
                NHibernate.Type.IType[] types = {NHibernate.NHibernateUtil.GuessType(typeof(Group)),  NHibernate.NHibernateUtil.GuessType(typeof(Group))};
                session.Delete(" from TribeRelation r where r.CurrentTribe=:current and r.DiplomaticTribe=:tribe", objects, types);
                return;
            }

            TribeRelation relation = new TribeRelation();
            relation.CurrentTribe = this.Group;
            relation.DiplomaticTribe = group;
            relation.Diplomacy = diplomacy;
            session.Save(relation);
        }
        public IList<Error> SetMemberPrivilageAndTitle(Player player, TribePermission permission, string title, ISession session)
        {
            IList<Error> lstError = new List<Error>();
            if (this.Group != player.Group)
            {
                lstError.Add(new Error("Không có quyền truy cập chức năng này"));
                return lstError;
            }
            if ((this.TribePermission & TribePermission.Baron) != TribePermission.Baron)
            {
                lstError.Add(new Error("Không có quyền truy cập chức năng này"));
                return lstError;
            }
                
            if ((int)player.TribePermission>(int)this.TribePermission)
            {
                lstError.Add(new Error("Không có quyền thay đổi thông tin thành viên này"));
                return lstError;
            }
            if (permission==beans.TribePermission.Duke&&this.TribePermission!=beans.TribePermission.Duke)
            {
                lstError.Add(new Error("Không có quyền truy cập chức năng này"));
                return lstError;
            }

            player.TribePermission = permission;
            player.TribeTitle = title;

            return lstError;
        }

        public IList<Error> InvitePlayer(string name, ISession session)
        {
            IList<Error> lstError = new List<Error>();

            ICriteria criteriaGetPlayer = session.CreateCriteria(typeof(Player));
            criteriaGetPlayer.Add(Expression.Eq("Username", name));
            Player player = criteriaGetPlayer.UniqueResult <Player>();
            if (player==null)
            {
                lstError.Add(new Error("Người chơi không tồn tại"));
                return lstError;
            }
            if ((this.TribePermission & TribePermission.Inviter) != TribePermission.Inviter)
            {
                lstError.Add(new Error("Không có quyền truy cập chức năng này"));
                return lstError;
            }
            if (this.Group == player.Group)
            {
                lstError.Add(new Error("Người chơi đã là thành viên của nhóm"));
                return lstError;
            }

            ICriteria criteriaGetInvited = session.CreateCriteria(typeof (TribeInvite));
            criteriaGetInvited.Add(Expression.Eq("Player", player));
            criteriaGetInvited.Add(Expression.Eq("Group", this.Group));
            TribeInvite invited = criteriaGetInvited.UniqueResult<TribeInvite>(); 

            if (invited!=null)
            {
                lstError.Add(new Error("Thành viên đã được mời tham gia nhóm"));
                return lstError;
            }

            TribeInvite invite = new TribeInvite();
            invite.Player = player;
            invite.Group = this.Group;
            invite.Inviter = this;
            invite.Time = DateTime.Now;



            InviteReport inviteReport = new InviteReport();
            inviteReport.Time = invite.Time;
            inviteReport.Title = String.Format("{0} mời gia nhập bang hội {1}", this.Username, this.Group.Name);
            inviteReport.Unread = true;
            inviteReport.Owner = player;
            invite.Inviter = this;
            invite.Group = this.Group;

            session.Save(invite);
            session.Save(inviteReport);

            return lstError;
        }
        #endregion

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
            ICriteria criteria = session.CreateCriteria(typeof(Report));
            criteria.Add(Expression.Eq("Owner", this));
            criteria.Add(Expression.Eq("ID", report_id));
            IList<Report> lstReport = criteria.List<Report>();
            if (lstReport.Count == 0)
                return null;
            return lstReport[0];
        }

        public IList<Report> GetReport(ReportType type, int page, ISession session)
        {

            ICriteria criteria;
            criteria = session.CreateCriteria(typeof(Report));
            if (type!=ReportType.All)
                criteria.Add(Expression.Eq("Type", type));
            criteria.Add(Expression.Eq("Owner", this));
            criteria.AddOrder(Order.Desc("ID"));
            criteria.SetMaxResults(40);
            criteria.SetFirstResult(page * 40);
            return criteria.List<Report>();
        }
        public Mail GetMailDetail(int Mail_id, ISession session)
        {
            ICriteria criteria = session.CreateCriteria(typeof(Mail));
            criteria.Add(Expression.Eq("ID", Mail_id));
            IList<Mail> lstMail = criteria.List<Mail>();
            if (lstMail.Count == 0)
                return null;
            return lstMail[0];
        }
        public IList<Mail> GetMailSend(int page, ISession session)
        {
            ICriteria criteria = session.CreateCriteria(typeof(Mail));
            criteria.Add(Expression.Eq("From", this));
            criteria.Add(Expression.Eq("SenderDelete", false));
            criteria.AddOrder(Order.Desc("ID"));
            criteria.SetMaxResults(40);
            criteria.SetFirstResult(page * 40);
            return criteria.List<Mail>();
        }
        public IList<Mail> GetMailReviece(int page, ISession session)
        {
            ICriteria criteria = session.CreateCriteria(typeof(Mail));
            criteria.Add(Expression.Eq("To", this));
            criteria.Add(Expression.Eq("ReceiverDelete", false));
            criteria.AddOrder(Order.Desc("ID"));
            criteria.SetMaxResults(40);
            criteria.SetFirstResult(page * 40);
            return criteria.List<Mail>();
        }
        public Boolean SendMail(int Receiver,String Title, String Detail,  ISession session)
        {
            WriteMail send = new WriteMail();
            send.From = this.ID;
            send.To = Receiver;
            send.Time = DateTime.Now;
            send.Title = Title;
            send.Detail = Detail;
            send.Unread = true;
            send.ReceiverDelete = false;
            send.SenderDelete = false;
            session.Save(send);
            session.Update(this);
            return true;
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
                village.Update(time, session);
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

            //IQuery query = session.CreateQuery("select count(v.ID) from Village v where v.Player=:user");
            //query.SetEntity("user", this);
            //IList lst = query.List();
            //if (lst.Count == 0)
            //    return 0;
            //Int64 i = (long)lst[0];
            //return (Int32)i;
        }
        #endregion

        #endregion
    }
}
