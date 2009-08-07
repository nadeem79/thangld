using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;
using System.IO;
using NHibernate;
using NHibernate.Criterion;
using System.Text.RegularExpressions;
using System.Collections;
using System.Linq;
using NHibernate.Linq;
using Antlr.StringTemplate;

namespace beans
{
    public partial class Admin : Player
    {
        public Admin GetByID(ISession session, int id)
        {
            return session.Get<Admin>(id);
        }

    }
}
