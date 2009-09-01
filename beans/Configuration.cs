using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using NHibernate.Linq;

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
            stringConfiguration = new Dictionary<string, StringConfiguration>();
            numericConfiguration = new Dictionary<string, NumericConfiguration>();
        }

        private Dictionary<string, StringConfiguration> stringConfiguration;
        private Dictionary<string, NumericConfiguration> numericConfiguration;

        public Dictionary<string, StringConfiguration> StringConfiguration
        {
            get
            {
                return this.stringConfiguration;
            }
        }
        public Dictionary<string, NumericConfiguration> NumericConfiguration
        {
            get
            {
                return this.numericConfiguration;
            }
        }

        public NumericConfiguration GetNumericConfigurationItem(string key)
        {
            if (this.NumericConfiguration.ContainsKey(key))
                return this.NumericConfiguration[key];

            NumericConfiguration config = new NumericConfiguration();
            config.Key = key;
            config.Value = 0;

            return config;

        }
        public StringConfiguration GetStringConfigurationItem(string key)
        {
            return this.GetStringConfigurationItem(key, false);
        }
        public StringConfiguration GetStringConfigurationItem(string key, bool isDebugging)
        {
            if (this.StringConfiguration.ContainsKey(key))
                return this.StringConfiguration[key];

            StringConfiguration config = new StringConfiguration();
            config.Key = key;

            if (isDebugging)
                config.Value = string.Format("Không tìm thấy key {0}", key);
            else
                config.Value = "";

            return config;
        } 

        public void LoadData(ISession session)
        {

            this.StringConfiguration.Clear();
            this.NumericConfiguration.Clear();

            IList<StringConfiguration> stringConfigurations = (from stringConfiguration in session.Linq<StringConfiguration>()
                                                               select stringConfiguration).ToList<StringConfiguration>();
            foreach (StringConfiguration stringConfiguration in stringConfigurations)
                this.StringConfiguration.Add(stringConfiguration.Key, stringConfiguration);

            IList<NumericConfiguration> numericConfigurations = (from numericConfiguration in session.Linq<NumericConfiguration>()
                                                                 select numericConfiguration).ToList<NumericConfiguration>();
            foreach (NumericConfiguration numericConfiguration in numericConfigurations)
                this.NumericConfiguration.Add(numericConfiguration.Key, numericConfiguration);
        }
        public void InsertOrUpdateConfiguration(NumericConfiguration numericConfiguration, ISession session)
        {
            if (this.NumericConfiguration.ContainsKey(numericConfiguration.Key))
                session.Update(numericConfiguration);

            session.Save(numericConfiguration);
        }
        public void InsertOrUpdateConfiguration(StringConfiguration stringConfiguration, ISession session)
        {
            if (this.NumericConfiguration.ContainsKey(stringConfiguration.Key))
                session.Update(stringConfiguration);

            session.Save(stringConfiguration);
        }
    }
}
