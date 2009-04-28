using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace beans
{
    public class MailDetail:Mail
    {
       
        public Player From
        {
            get;
            set;
        }
        public DateTime Time
        {
            get;
            set;
        }

        public string Title
        {
            get;
            set;
        }
        public string Detail
        {
            get;
            set;
        }
    }
}
