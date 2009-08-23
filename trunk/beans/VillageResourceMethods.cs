using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;

namespace beans
{
    public class VillageResourceMethods
    {
        public Village Village
        {
            get;
            set;
        }
        public virtual int ProductPerHour(ResourcesType type)
        {
            int level = 0;
            switch (type)
            {
                case ResourcesType.Clay:
                    level = this.Village.VillageBuildingData.ClayPit;
                    break;
                case ResourcesType.Wood:
                    level = this.Village.VillageBuildingData.TimberCamp;
                    break;
                case ResourcesType.Iron:
                    level = this.Village.VillageBuildingData.IronMine;
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
                    level = this.Village.VillageBuildingData.ClayPit;
                    break;
                case ResourcesType.Wood:
                    level = this.Village.VillageBuildingData.TimberCamp;
                    break;
                case ResourcesType.Iron:
                    level = this.Village.VillageBuildingData.IronMine;
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
            this.Village.VillageResourceData.Clay += (int)(time * this.ProductPerHour(ResourcesType.Clay));
            this.Village.VillageResourceData.Wood += (int)(time * this.ProductPerHour(ResourcesType.Wood));
            this.Village.VillageResourceData.Iron += (int)(time * this.ProductPerHour(ResourcesType.Iron));

            if (this.Village.VillageResourceData.Clay > this.Village.MaxResources)
                this.Village.VillageResourceData.Clay = this.Village.MaxResources;
            if (this.Village.VillageResourceData.Wood > this.Village.MaxResources)
                this.Village.VillageResourceData.Wood = this.Village.MaxResources;
            if (this.Village.VillageResourceData.Iron > this.Village.MaxResources)
                this.Village.VillageResourceData.Iron = this.Village.MaxResources;
        }
        public virtual int TimeTillFullWarehouse(DateTime from, ResourcesType type)
        {
            int canStore = this.Village.MaxResources - this.Village[type];
            return (int)(canStore * this.SecondPerResourceUnit(type));
        }

        public virtual SendResource CreateSendResource(ISession session,
                                                int x,
                                                int y,
                                                int clay,
                                                int wood,
                                                int iron)
        {
            if (x == this.Village.X && y == this.Village.Y)
                throw new Exception("Nhập toạ độ");

            if ((clay + wood + iron) == 0)
                throw new Exception("Nhập một loại tài nguyên");

            if ((clay > this.Village.VillageResourceData.Clay) ||
            (wood > this.Village.VillageResourceData.Wood) ||
            (iron > this.Village.VillageResourceData.Iron))
                throw new Exception("Không đủ tài nguyên");

            Village toVillage = Village.GetVillageByCoordinate(x, y, session);
            if (toVillage == null)
                throw new Exception("Toạ độ không tồn tại");

            if (this.Village.VillageBuildingData.Merchant < SendResource.CalculateMerchant(wood, clay, iron))
                throw new Exception("Không đủ thương nhân");

            SendResource sendResource = new SendResource();
            sendResource.Clay = clay;
            sendResource.Iron = iron;
            sendResource.Wood = wood;
            sendResource.Merchant = (int)Math.Ceiling((double)(clay + iron + wood)/1000);

            sendResource.StartingTime = DateTime.Now;
            sendResource.LandingTime = Map.LandingTime(TroopType.Merchant, this.Village, toVillage, sendResource.StartingTime);
            sendResource.FromVillage = this.Village;
            sendResource.ToVillage = toVillage;

            return sendResource;
        }
    }
}
