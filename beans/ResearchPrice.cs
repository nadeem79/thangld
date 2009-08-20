using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace beans
{
    public class ResearchPrice
    {
        private int _wood;
        private int _clay;
        private int _iron;
        private int _time;
        private string _name;

        public int Wood
        {
            get { return this._wood; }
        }
        public int Clay
        {
            get { return this._clay; }
        }
        public int Iron
        {
            get { return this._iron; }
        }
        public int Time
        {
            get { return this._time; }
        }
        public string Name
        {
            get { return this._name; }
        }

        public override string ToString()
        {
            return this._name;
        }

        public ResearchPrice(string name, int time, int wood, int clay, int iron)
        {
            this._name = name;
            this._time = time;
            this._wood = wood;
            this._clay = clay;
            this._iron = iron;
        }

    }
}
