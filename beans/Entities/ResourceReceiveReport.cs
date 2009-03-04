using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace beans
{
    public class ResourceReceiveReport:Report
    {
        #region Variables
        private int iron, wood, clay;
        private Village from, to;
        #endregion

        #region Properties

        public virtual Village From
        {
            get { return this.from; }
            set { this.from = value; }
        }

        public virtual Village To
        {
            get { return this.to; }
            set { this.to = value; }
        }

        public virtual int Iron
        {
            get { return this.iron; }
            set { this.iron = value; }
        }

        public virtual int Wood
        {
            get { return this.wood; }
            set { this.wood = value; }
        }

        public virtual int Clay
        {
            get { return this.clay; }
            set { this.clay = value; }
        }

        public override ReportType Type
        {
            get { return ReportType.ResourceReceive; }
        }
        #endregion

    }

}
