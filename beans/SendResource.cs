using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using Antlr.StringTemplate;

namespace beans
{
    public class SendResource:MovingCommand
    {

        public static int CalculateMerchant(int wood, int clay, int iron)
        {
            double merchant = (wood + clay + iron) / 1000;
            return Convert.ToInt32(merchant);
        }

        public override MoveType Type
        {
            get { return MoveType.SendResources; }
        }
        public virtual int Wood
        {
            get;
            set;
        }
        public virtual int Clay
        {
            get;
            set;
        }
        public virtual int Iron
        {
            get;
            set;
        }
        public virtual int Merchant
        {
            get;
            set;
        }


        public override MovingCommand Effect(ISession session)
        {
            this.ToVillage.Update(this.LandingTime, session);
            this.ToVillage.VillageResourceData.Clay += this.Clay;
            this.ToVillage.VillageResourceData.Wood += this.Wood;
            this.ToVillage.VillageResourceData.Iron += this.Iron;

            Return r = new Return();
            r.Merchant = (int)Math.Round((double)((this.Clay + this.Wood + this.Iron) / 1000), MidpointRounding.AwayFromZero);
            r.FromVillage = this.ToVillage;
            r.ToVillage = this.FromVillage;
            r.StartingTime = DateTime.Now;
            r.LandingTime = DateTime.Now + (DateTime.Now - this.StartingTime);

            SendResourceReport report = new SendResourceReport();
            report.Time = this.LandingTime;
            report.Title = String.Format("{0} gửi tài nguyên đến {1} ({2}|{3})", this.FromVillage.Player.Username, this.ToVillage.Name, this.ToVillage.X.ToString("000"), this.ToVillage.Y.ToString("000"));
            report.Unread = true;
            report.Owner = this.FromVillage.Player;
            report.Clay = this.Clay;
            report.Wood = this.Wood;
            report.Iron = this.Iron;
            report.FromVillage = this.FromVillage;
            report.FromPlayer = this.FromVillage.Player;
            report.ToVillage = this.ToVillage;
            report.ToPlayer = this.ToVillage.Player;

            session.Update(this.ToVillage.VillageResourceData);
            session.Save(r);
            session.Delete(this);
            session.Save(report);

            return r;
            
        }

        public override MovingCommand Cancel(ISession session)
        {
            Return r = new Return();
            r.Wood = this.Wood;
            r.Clay = this.Clay;
            r.Iron = this.Iron;
            r.FromVillage = this.ToVillage;
            r.ToVillage = this.FromVillage;
            r.StartingTime = DateTime.Now;
            r.LandingTime = DateTime.Now + (DateTime.Now - this.StartingTime);

            session.Save(r);
            session.Delete(this);

            return r;
        }


        public override void Save(ISession session)
        {
            if ((this.Clay + this.Wood + this.Iron) == 0)
                throw new Exception("Nhập một loại tài nguyên");

            if ((this.Clay > this.FromVillage.VillageResourceData.Clay) ||
            (this.Wood > this.FromVillage.VillageResourceData.Wood) ||
            (this.Iron > this.FromVillage.VillageResourceData.Iron))
                throw new Exception("Không đủ tài nguyên");

            if (this.ToVillage == null)
                throw new Exception("Nhập điểm đến");

            if (this.ToVillage.AvailableMerchant(session) < SendResource.CalculateMerchant(this.Wood, this.Clay, this.Iron))
                throw new Exception("Không đủ thương nhân");

            this.FromVillage.VillageResourceData.Clay -= this.Clay;
            this.FromVillage.VillageResourceData.Wood -= this.Wood;
            this.FromVillage.VillageResourceData.Iron -= this.Iron;

            session.Save(this);
            session.Update(this.FromVillage.VillageResourceData);
        }
    }
}
