using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using beans.Services;

namespace beans
{
    public class ServicesList
    {
        protected static SecurityService securityService = new SecurityService();
        protected static ConfigurationService configurationService = new ConfigurationService();

        public static SecurityService SecurityService
        {
            get { return ServicesList.securityService; }
        }
        public static ConfigurationService ConfigurationService
        {
            get { return ServicesList.configurationService; }
        }
    }
}
