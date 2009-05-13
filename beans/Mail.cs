using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace beans
{
    public class Mail : IdentityObject
    {
        public Player From
        {
            get;
            set;
        }
        public Player To
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
        public bool Unread
        {
            get;
            set;
        }
        public bool SenderDelete
        {
            get;
            set;
        }
        public bool ReceiverDelete
        {
            get;
            set;
        }

        public override string ToString()
        {
            return this.Title;
        }
    }
}