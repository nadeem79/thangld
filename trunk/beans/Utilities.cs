using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace beans
{
    public class Utilities
    {
        public static bool IsGreaterThenZero(params int[] arguments)
        {
            int sum = 0;
            foreach (int i in arguments)
            {
                if (i < 0)
                    return false;
                sum += i;
            }
            return (sum > 0);
        }
    }
}
