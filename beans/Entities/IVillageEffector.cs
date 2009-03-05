using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace beans
{
    public interface IVillageEffector
    {
        void effect(NHibernate.ISession session);
    }
}
