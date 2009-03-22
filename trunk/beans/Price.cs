using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace beans
{
    public class Price
    {
        int wood, iron, clay;
        int time;

        public int Wood
        {
            get { return this.wood; }
        }

        public int Iron
        {
            get { return this.iron; }
        }

        public int Clay
        {
            get { return this.clay; }
        }

        public int BuildTime
        {
            get { return this.time; }
        }

        public Price(int time, int wood, int clay, int iron)
        {
            this.iron = iron;
            this.clay = clay;
            this.wood = wood;
            this.time = time;
        }

    }
}
