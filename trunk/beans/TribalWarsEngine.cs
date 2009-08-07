using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;

namespace beans
{
    public class TribalWarsEngine
    {
        public static void Start(ISession session)
        {
            Configuration.TribalWarsConfiguration.LoadData(session);
        }

        public static void Stop()
        {

        }
    }
}
