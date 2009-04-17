using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;

namespace beans
{
    public class SendResource:MovingCommand
    {
        #region Variables
        

        
        #endregion

        #region Properties
        public override MoveType Type
        {
            get { return MoveType.SendResources; }
        }
        public virtual int Wood
        {
            get;
            set;
        }
        public virtual int Clay
        {
            get;
            set;
        }
        public virtual int Iron
        {
            get;
            set;
        }
        #endregion

        #region Constructors
        public SendResource()
        {

        }

        #endregion

        #region Methods

        public override void save(ISession session)
        {
            if ((this.Clay > this.From.Resources.Clay) || (this.Wood > this.From.Resources.Wood) || (this.Iron > this.From.Resources.Iron))
                throw new Exception("Không đủ tài nguyên");

            this.From.Resources.Clay -= this.Clay;
            this.From.Resources.Wood -= this.Wood;
            this.From.Resources.Iron -= this.Iron;
            session.Save(this);
            session.Update(this.From);
        }

        public override void effect(ISession session)
        {
            this.To.Resources.Clay += this.Clay;
            this.To.Resources.Wood += this.Wood;
            this.To.Resources.Iron += this.Iron;
        }

        public override void cancel(ISession session)
        {
            Return r = new Return();
            r.Wood = this.Wood;
            r.Clay = this.Clay;
            r.Iron = this.Iron;

            session.Save(r);
            session.Delete(this);
        }

        #endregion
    }
}
