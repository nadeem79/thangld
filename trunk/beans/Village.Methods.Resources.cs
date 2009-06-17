using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;

namespace beans
{
    public partial class Village
    {

        public int ProductPerHour(ResourcesType type)
        {
            int level = 0;
            switch (type)
            {
                case ResourcesType.Clay:
                    level = this.Buildings.ClayPit;
                    break;
                case ResourcesType.Wood:
                    level = this.Buildings.TimberCamp;
                    break;
                case ResourcesType.Iron:
                    level = this.Buildings.IronMine;
                    break;
                default:
                    break;
            }

            if (level == 0)
                return 0;
            int result = 20;
            for (int i = 0; i < level; i++)
                result += (int)(result * 0.2);
            return result;
        }
        public double SecondPerResourceUnit(ResourcesType type)
        {

            int level = 0;
            switch (type)
            {
                case ResourcesType.Clay:
                    level = this.Buildings.ClayPit;
                    break;
                case ResourcesType.Wood:
                    level = this.Buildings.TimberCamp;
                    break;
                case ResourcesType.Iron:
                    level = this.Buildings.IronMine;
                    break;
                default:
                    break;
            }

            double production = this.ProductPerHour(type);
            if (production == 0)
                return double.MaxValue;
            return (double)3600 / production;
        }
        public void UpdateResources(DateTime from, DateTime to)
        {
            TimeSpan span = to - from;
            double time = span.TotalHours;
            this.Resources.Clay += (int)(time * this.ProductPerHour(ResourcesType.Clay));
            this.Resources.Wood += (int)(time * this.ProductPerHour(ResourcesType.Wood));
            this.Resources.Iron += (int)(time * this.ProductPerHour(ResourcesType.Iron));

            if (this.Resources.Clay > this.MaxResources)
                this.Resources.Clay = this.MaxResources;
            if (this.Resources.Wood > this.MaxResources)
                this.Resources.Wood = this.MaxResources;
            if (this.Resources.Iron > this.MaxResources)
                this.Resources.Iron = this.MaxResources;
        }
        public int TimeTillFullWarehouse(DateTime from, ResourcesType type)
        {
            int canStore = this.MaxResources - this[type];
            return (int)(canStore * this.SecondPerResourceUnit(type));
        }

    }
}
