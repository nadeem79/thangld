using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;

namespace beans
{
    public class Group
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
        public int ID
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
        #endregion

        #region Methods
        public override string ToString()
        {
            return this.Tag;
        }
        #endregion
    }
}
