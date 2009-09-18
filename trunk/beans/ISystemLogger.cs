using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace beans
{
    public interface ISystemLogger
    {
        void Log(string username, string message);
        void LogException(Exception exc);
    }
}
