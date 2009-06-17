using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using NHibernate.Linq;
using NHibernate.Criterion;

namespace beans
{
    public partial class Village
    {

        public int GetIncomingAttackCount(ISession session)
        {

            return (from attack in session.Linq<Attack>()
                    where attack.To == this
                    select attack).Count();

        }
        public int GetIncomingSupportCount(ISession session)
        {
            return (from support in session.Linq<Support>()
                    where support.To == this
                    select support).Count();
        }

        public List<MovingCommand> GetTroopMovement(ISession session)
        {
            return (from movement in session.Linq<MovingCommand>()
                    where (movement.From == this || movement.To == this)
                    && movement.LandingTime > this.LastUpdate
                    orderby movement.LandingTime ascending
                    select movement).ToList();
        }

        public List<MovingCommand> GetTroopMovement(DateTime time, ISession session)
        {
            return (from movement in session.Linq<MovingCommand>()
                    where (movement.From == this || movement.To == this)
                    && movement.LandingTime < time
                    && movement.LandingTime > this.LastUpdate
                    orderby movement.LandingTime ascending
                    select movement).ToList();
        }

    }
}