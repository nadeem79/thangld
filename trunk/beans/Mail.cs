using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace beans
{
    public class Mail : IdentityObject
    {
        public virtual Player From
        {
            get;
            set;
        }
        public virtual Player To
        {
            get;
            set;
        }
        public virtual DateTime Time
        {
            get;
            set;
        }

        public virtual string Title
        {
            get;
            set;
        }
        public virtual string Detail
        {
            get;
            set;
        }
        public virtual bool Unread
        {
            get;
            set;
        }
        public virtual bool SenderDelete
        {
            get;
            set;
        }
        public virtual bool ReceiverDelete
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