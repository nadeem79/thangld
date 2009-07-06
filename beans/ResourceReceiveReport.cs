using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace beans
{
    public class ResourceReceiveReport:Report
    {

        public virtual Village FromVillage
        {
            get;
            set;
        }

        public virtual Village ToVillage
        {
            get;
            set;
        }

        public Player FromPlayer
        {
            get;
            set;
        }
        public Player ToPlayer
        {
            get;
            set;
        }

        public virtual int Iron
        {
            get;
            set;
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

        public override ReportType Type
        {
            get { return ReportType.ResourceReceive; }
        }

    }

}
