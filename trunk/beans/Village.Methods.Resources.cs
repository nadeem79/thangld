using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;

namespace beans
{
    public partial class Village
    {

        public virtual int ProductPerHour(ResourcesType type)
        {
            int level = 0;
            switch (type)
            {
                case ResourcesType.Clay:
                    level = this.VillageBuildingData.ClayPit;
                    break;
                case ResourcesType.Wood:
                    level = this.VillageBuildingData.TimberCamp;
                    break;
                case ResourcesType.Iron:
                    level = this.VillageBuildingData.IronMine;
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
        public virtual double SecondPerResourceUnit(ResourcesType type)
        {

            int level = 0;
            switch (type)
            {
                case ResourcesType.Clay:
                    level = this.VillageBuildingData.ClayPit;
                    break;
                case ResourcesType.Wood:
                    level = this.VillageBuildingData.TimberCamp;
                    break;
                case ResourcesType.Iron:
                    level = this.VillageBuildingData.IronMine;
                    break;
                default:
                    break;
            }

            double production = this.ProductPerHour(type);
            if (production == 0)
                return double.MaxValue;
            return (double)3600 / production;
        }
        public virtual void UpdateResources(DateTime from, DateTime to)
        {
            TimeSpan span = to - from;
            double time = span.TotalHours;
            this.VillageResourceData.Clay += (int)(time * this.ProductPerHour(ResourcesType.Clay));
            this.VillageResourceData.Wood += (int)(time * this.ProductPerHour(ResourcesType.Wood));
            this.VillageResourceData.Iron += (int)(time * this.ProductPerHour(ResourcesType.Iron));

            if (this.VillageResourceData.Clay > this.MaxResources)
                this.VillageResourceData.Clay = this.MaxResources;
            if (this.VillageResourceData.Wood > this.MaxResources)
                this.VillageResourceData.Wood = this.MaxResources;
            if (this.VillageResourceData.Iron > this.MaxResources)
                this.VillageResourceData.Iron = this.MaxResources;
        }
        public virtual int TimeTillFullWarehouse(DateTime from, ResourcesType type)
        {
            int canStore = this.MaxResources - this[type];
            return (int)(canStore * this.SecondPerResourceUnit(type));
        }

        public virtual SendResource CreateSendResource(ISession session,
                                                int x,
                                                int y,
                                                int clay,
                                                int wood,
                                                int iron)
        {
            if (x == this.X && y == this.Y)
                throw new Exception("Nhập toạ độ");

            if ((clay + wood + iron) == 0)
                throw new Exception("Nhập một loại tài nguyên");

            if ((clay > this.VillageResourceData.Clay) ||
            (wood > this.VillageResourceData.Wood) ||
            (iron > this.VillageResourceData.Iron))
                throw new Exception("Không đủ tài nguyên");

            Village toVillage = Village.GetVillageByCoordinate(x, y, session);
            if (toVillage == null)
                throw new Exception("Toạ độ không tồn tại");

            if (this.Merchant < SendResource.CalculateMerchant(wood, clay, iron))
                throw new Exception("Không đủ thương nhân");

            SendResource sendResource = new SendResource();
            sendResource.Clay = clay;
            sendResource.Iron = iron;
            sendResource.Wood = wood;

            sendResource.StartingTime = DateTime.Now;
            sendResource.LandingTime = Map.LandingTime(TroopType.Merchant, this, toVillage, sendResource.StartingTime);
            sendResource.FromVillage = this;
            sendResource.ToVillage = toVillage;

            return sendResource;
        }
    }
}
