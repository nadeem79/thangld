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
        
        private int iron, clay, wood;
        private MoveType type;
        
        #endregion

        #region Properties
       

        public virtual int Wood
        {
          get { return wood; }
          set { wood = value; }
        }

        public virtual int Clay
        {
          get { return clay; }
          set { clay = value; }
        }

        public virtual int Iron
        {
          get { return iron; }
          set { iron = value; }
        }
        #endregion

        #region Constructors
        public SendResource()
        {

        }

        #endregion

        #region Methods

        public override void effect(ISession session)
        {
            this.To.Clay += this.Clay;
            this.To.Wood += this.Wood;
            this.To.Iron += this.Iron;
        }

        #endregion
    }
}
