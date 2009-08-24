using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate.Criterion;
using NHibernate;
using NHibernate.Linq;
using System.Data;

namespace beans
{
    partial class Player
    {
        public virtual void CreateTribe(string tag, string name, ISession session)
        {
            beans.Group group = new Group();
            group.Tag = tag;
            group.Name = name;
            group.Description = "";
            group.Introduction = "";
            this.Group = group;
            this.TribePermission = TribePermission.Duke;
            session.Save(group);
            session.Update(this);
        }
        public virtual void DisbandTribe(ISession session)
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
        public virtual void DismissPlayer(Player player, ISession session)
        {
            if (player.Group == this.Group || ((this.TribePermission & TribePermission.DismissPlayer) == TribePermission.DismissPlayer))
                return;

            player.Group = null;
            session.Update(player);
        }
        public virtual void ChangeDescription(string description, ISession session)
        {
            if ((this.TribePermission & TribePermission.DiplomateOfficer) == 0)
                return;
            this.Group.Description = description;
            session.Update(this.Group);
        }
        public virtual void SetDiplomacy(Group tribe, TribeDiplomate diplomacy, ISession session)
        {
            if ((this.TribePermission & TribePermission.DiplomateOfficer) != TribePermission.DiplomateOfficer)
                return;
            if (this.Group == tribe)
                return;

            if (diplomacy == TribeDiplomate.NoRelation)
            {
                object[] objects = { this.Group, tribe };
                NHibernate.Type.IType[] types = { NHibernate.NHibernateUtil.GuessType(typeof(Group)), NHibernate.NHibernateUtil.GuessType(typeof(Group)) };
                session.Delete(" from TribeRelation r where r.CurrentTribe=:current and r.DiplomaticTribe=:tribe", objects, types);
                return;
            }

            TribeRelation oldRelation = (from tribeRelation in session.Linq<TribeRelation>()
                                         where tribeRelation.CurrentTribe == this.Group
                                         && tribeRelation.DiplomaticTribe == tribe
                                         select tribeRelation).SingleOrDefault<TribeRelation>();

            if (oldRelation != null)
                return;

            TribeRelation relation = new TribeRelation();
            relation.CurrentTribe = this.Group;
            relation.DiplomaticTribe = tribe;
            relation.Diplomacy = diplomacy;
            session.Save(relation);
        }
        public virtual IList<Error> SetMemberPrivilageAndTitle(Player player, TribePermission permission, string title, ISession session)
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

            if ((int)player.TribePermission > (int)this.TribePermission)
            {
                lstError.Add(new Error("Không có quyền thay đổi thông tin thành viên này"));
                return lstError;
            }
            if (permission == beans.TribePermission.Duke && this.TribePermission != beans.TribePermission.Duke)
            {
                lstError.Add(new Error("Không có quyền truy cập chức năng này"));
                return lstError;
            }

            player.TribePermission = permission;
            player.TribeTitle = title;

            return lstError;
        }

        public virtual IList<Error> InvitePlayer(string name, ISession session)
        {
            IList<Error> lstError = new List<Error>();

            Player player = (from p in session.Linq<Player>()
                             where p.Username == name
                             select p).SingleOrDefault<Player>();
            
            if (player == null)
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

            ICriteria criteriaGetInvited = session.CreateCriteria(typeof(TribeInvite));
            criteriaGetInvited.Add(Expression.Eq("Player", player));
            criteriaGetInvited.Add(Expression.Eq("Group", this.Group));
            TribeInvite invited = criteriaGetInvited.UniqueResult<TribeInvite>();

            if (invited != null)
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
            inviteReport.Group = this.Group;
            inviteReport.Inviter = this;
            invite.Inviter = this;
            invite.Group = this.Group;
                session.Save(invite);
                session.Save(inviteReport);
                return lstError;
            
        }

        public virtual bool CheckPrivilage(TribePermission privilage)
        {
            return ((this.TribePermission & privilage) == privilage);
        }
    }
}
