using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;

namespace beans
{

    public enum ConfigurationType
    {
        String,
        Numeric
    }

    public class Configuration
    {

        private static Configuration configuration = new Configuration();
        public static Configuration TribalWarsConfiguration
        {
            get { return Configuration.configuration; }
        }

        protected Configuration()
        {
            stringConfiguration = new Dictionary<string, string>();
            numericConfiguration = new Dictionary<string, double>();
        }

        private Dictionary<string, string> stringConfiguration;
        private Dictionary<string, double> numericConfiguration;

        public Dictionary<string, string> StringConfiguration
        {
            get
            {
                return this.stringConfiguration;
            }
        }
        public Dictionary<string, double> NumericConfiguration
        {
            get
            {
                return this.numericConfiguration;
            }
        }

        public object GetItem(string key, ConfigurationType type, ISession session)
        {
            switch (type)
            {
                case ConfigurationType.Numeric:
                    if (this.NumericConfiguration.ContainsKey(key))
                        return this.NumericConfiguration[key];

                    beans.NumericConfiguration numericConfiguration = beans.NumericConfiguration.GetItem(key, session);
                    if (object.Equals(numericConfiguration, null))
                        return null;
                    return numericConfiguration.Value;
                    
                case ConfigurationType.String:
                    if (this.StringConfiguration.ContainsKey(key))
                        return this.StringConfiguration[key];

                    beans.StringConfiguration stringConfiguration = beans.StringConfiguration.GetItem(key, session);
                    if (object.Equals(stringConfiguration, null))
                        return null;
                    return stringConfiguration.Value;
                    break;
                default:
                    return null;
            }
        }
    }
}
