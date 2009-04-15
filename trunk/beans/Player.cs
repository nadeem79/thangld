﻿using System;
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
        public int Point
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

        #region Methods
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
            if (command.From.Owner != this && command.To.Owner != this)
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
            switch (type)
            {
                case ReportType.Attack:
                    criteria = session.CreateCriteria(typeof(AttackReport));
                    break;
                case ReportType.Defense:
                    criteria = session.CreateCriteria(typeof(DefenseReport));
                    break;
                case ReportType.DefenseOther:
                    criteria = session.CreateCriteria(typeof(DefenseOtherReport));
                    break;
                case ReportType.InviteToTribe:
                    criteria = session.CreateCriteria(typeof(InviteToTribeReport));
                    break;
                case ReportType.OfferAccepted:
                    criteria = session.CreateCriteria(typeof(OfferAcceptedReport));
                    break;
                case ReportType.ResourceReceive:
                    criteria = session.CreateCriteria(typeof(ResourceReceiveReport));
                    break;
                case ReportType.Support:
                    criteria = session.CreateCriteria(typeof(SupportReport));
                    break;
                case ReportType.SupportWithdawal:
                    criteria = session.CreateCriteria(typeof(SupportWithdawalReport));
                    break;
                default:
                    criteria = session.CreateCriteria(typeof(Report));
                    break;
            }
            
            criteria.Add(Expression.Eq("Owner", this));
            criteria.AddOrder(Order.Desc("ID"));
            criteria.SetMaxResults(40);
            criteria.SetFirstResult(page * 40);
            return criteria.List<Report>();
        }

        public void Update(DateTime time, ISession session)
        {
            if (this.Villages.Count == 0)
            {
                Village village = Village.CreateVillage(session);
                village.Owner = this;
                this.Villages.Add(village);
                village.LastUpdate = time;
                village.Name = "Thành phố " + this.Username;
                session.Save(village);
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
            IQuery query = session.CreateQuery("select count(v.ID) from Village v where v.Owner.ID=:userID");
            query.SetInt32("userID", this.ID);
            IList lst = query.List();
            if (lst.Count == 0)
                return 0;
            Int64 i = (long)lst[0];
            return (Int32)i;
        }
        #endregion

        #endregion
    }
}
