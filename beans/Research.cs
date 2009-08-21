using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using NHibernate.Criterion;

namespace beans
{

    public class Research:IdentityObject
    {
        #region Static Members

        protected static Dictionary<int, ResearchPrice> _dictionary = new Dictionary<int,ResearchPrice>();
        public static Dictionary<int, ResearchPrice> ResearchPrices
        {
            get { return Research._dictionary; }
        }

        public static ResearchPrice GetPrice(ResearchType type, int level, int smithy)
        {
            int key = (int)type + (level * 1000) + (smithy * 1000000);
            return Research.ResearchPrices[key];
        }

        public static Research GetResearchById(int id, ISession session)
        {
            return session.Get<Research>(id);
        }
        #endregion

        #region Properties
        public virtual Village Village
        {
            get;
            set;
        }
        public virtual ResearchType Type
        {
            get;
            set;
        }
        public virtual int Level
        {
            get;
            set;
        }
        public virtual DateTime Start
        {
            get;
            set;
        }
        public virtual DateTime End
        {
            get;
            set;
        }
        #endregion

        #region Methods
        public virtual bool Expense(DateTime time)
        {
            return time > this.End;

        }
        #endregion
    }

    
}
