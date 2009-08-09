using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using NHibernate.Linq;
using NHibernate.Criterion;

namespace beans
{
    public class Group:IdentityObject
    {
        #region Variables

        #endregion

        #region Properties
        public IList<Group> Enemies
        {
            get;
            set;
        }
        public IList<Group> Naps
        {
            get;
            set;
        }

        public IList<Group> Allies
        {
            get;
            set;
        }
        public IList<Player> Members
        {
            get;
            set;
        }
        public string Name
        {
            get;
            set;
        }
        public string Tag
        {
            get;
            set;
        }
        public string Description
        {
            get;
            set;
        }
        public string Introduction
        {
            get;
            set;
        }
        public IList<TribeInvite> Invites
        {
            get;
            set;
        }
        public bool Avatar
        {
            get;
            set;
        }

        #endregion

        #region Constructors
        public Group()
        {
            this.Enemies = new List<Group>();
            this.Allies = new List<Group>();
            this.Naps = new List<Group>();
            this.Members = new List<Player>();
        }
        #endregion

        #region Static Methods
        public static Group GetGroupByTagName(string tag, ISession session)
        {
            ICriteria criteria = session.CreateCriteria(typeof(Group));
            criteria.Add(Expression.Eq("Tag", tag));
            IList<Group> lst = criteria.List<Group>();
            if (lst.Count > 0)
                return lst[0];

            return null;
        }
        #endregion

        #region Methods
        public override string ToString()
        {
            return this.Tag;
        }

        public void GetDiplomateInfo(ISession session)
        {
            IList<TribeRelation> diplomateInfo = (from tribeDiplomate in session.Linq<TribeRelation>()
                                                  where tribeDiplomate.CurrentTribe == this
                                                  select tribeDiplomate).ToList<TribeRelation>();

            this.Allies = (from relation in diplomateInfo
                           where relation.Diplomacy == TribeDiplomate.Ally
                           select relation.DiplomaticTribe).ToList<Group>();
            this.Enemies = (from relation in diplomateInfo
                           where relation.Diplomacy == TribeDiplomate.Enemy
                           select relation.DiplomaticTribe).ToList<Group>();
            this.Naps = (from relation in diplomateInfo
                           where relation.Diplomacy == TribeDiplomate.NAP
                           select relation.DiplomaticTribe).ToList<Group>();

        }
        public void GetMembers(ISession session)
        {
            this.Members = (from player in session.Linq<Player>()
                            where player.Group == this
                            orderby player.Point descending
                            select player).ToList<Player>();
        }
        #endregion
    }
}
