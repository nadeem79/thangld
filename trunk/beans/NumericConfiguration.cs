using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using NHibernate.Linq;

namespace beans
{
    public class NumericConfiguration
    {
        public string Key
        {
            get;
            set;
        }
        public double Value
        {
            get;
            set;
        }

        public static NumericConfiguration GetItem(string key, ISession session)
        {
            return (from numericConfiguration in session.Linq<NumericConfiguration>()
                    where numericConfiguration.Key.Equals(key, StringComparison.OrdinalIgnoreCase)
                    select numericConfiguration).SingleOrDefault<NumericConfiguration>();
        }
    }
}
