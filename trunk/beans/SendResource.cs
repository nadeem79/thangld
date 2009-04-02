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
            if ((this.Clay > this.From.Clay) || (this.Wood > this.From.Wood) || (this.Iron > this.From.Iron))
                throw new Exception("Không đủ tài nguyên");

            this.From.Clay -= this.Clay;
            this.From.Wood -= this.Wood;
            this.From.Iron -= this.Iron;
            session.Save(this);
            session.Update(this.From);
        }

        public override void effect(ISession session)
        {
            this.To.Clay += this.Clay;
            this.To.Wood += this.Wood;
            this.To.Iron += this.Iron;
        }

        #endregion
    }
}
