using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;

namespace beans
{
    public class RecruitHero:IdentityObject
    {
        public virtual Hero Hero
        {
            get;
            set;
        }
        public virtual Player Owner
        {
            get;
            set;
        }
        public virtual DateTime StartingTime
        {
            get;
            set;
        }
        public virtual DateTime FinishTime
        {
            get;
            set;
        }
        public virtual bool IsResurrection 
        {
            get;
            set;
        }
        public virtual void Expire(DateTime time, ISession session)
        {
            if (time < this.FinishTime)
                return;

            this.Hero.Owner = this.Owner;
            this.Hero.InVillage = this.Owner.MainVillage;
            if (this.Owner.MainVillage.MainHero == null)
            {
                this.Owner.MainVillage.MainHero = this.Hero;
                session.Update(this.Owner.MainVillage);
            }

            this.Hero.IsRecruiting = false;
            this.Hero.IsDead = false;
            session.Update(this.Hero);
            session.Delete(this);
        }


    }
}
