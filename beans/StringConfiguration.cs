using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using NHibernate.Linq;

namespace beans
{
    public class StringConfiguration
    {
        public string Key
        {
            get;
            set;
        }
        public string Value
        {
            get;
            set;
        }

        public static StringConfiguration GetItem(string key, ISession session)
        {
            return (from stringConfiguration in session.Linq<StringConfiguration>()
                    where stringConfiguration.Key.Equals(key, StringComparison.OrdinalIgnoreCase)
                    select stringConfiguration).SingleOrDefault<StringConfiguration>();
        }
    }
}
