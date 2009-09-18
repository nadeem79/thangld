using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace beans.Services
{
    public class LogService
    {
        internal LogService()
        {
            this.SystemLoggers = new List<ISystemLogger>();
        }

        public IList<ISystemLogger> SystemLoggers
        {
            get;
            private set;
        }

        public void Log(string username, string message)
        {
            foreach (ISystemLogger logger in this.SystemLoggers)
                logger.Log(username, message);
        }
        public void LogException(Exception ex)
        {
            foreach (ISystemLogger logger in this.SystemLoggers)
                logger.LogException(ex);
        }
    }
}
