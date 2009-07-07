using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace beans
{
    public class TimeComparer:IComparer<MovingCommand>
    {
        #region IComparer<MovingCommand> Members

        public int Compare(MovingCommand x, MovingCommand y)
        {
            return (x.LandingTime - y.LandingTime).Milliseconds;
        }

        #endregion
    }
}
