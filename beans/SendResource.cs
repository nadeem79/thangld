using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using System.Data;

namespace beans
{
    public class SendResource:MovingCommand
    {

        public static int CalculateMerchant(int wood, int clay, int iron)
        {
            double result = (double)(wood + clay + iron) / 1000;
            return (int)Math.Ceiling(result);
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
            this.ToVillage.VillageResourceData.Clay += this.Clay;
            this.ToVillage.VillageResourceData.Wood += this.Wood;
            this.ToVillage.VillageResourceData.Iron += this.Iron;

            Return r = new Return();
            r.Merchant = this.Merchant;
            r.FromVillage = this.ToVillage;
            r.ToVillage = this.FromVillage;
            r.StartingTime = this.LandingTime;
            r.LandingTime = Map.LandingTime(TroopType.Merchant, r.FromVillage, r.ToVillage, r.StartingTime);

            SendResourceReport report = new SendResourceReport();
            report.Time = this.LandingTime;
            report.Title = String.Format("{0} gửi tài nguyên đến {1} ({2}|{3})", this.FromVillage.Player.Username, this.ToVillage.Name, this.ToVillage.X.ToString("000"), this.ToVillage.Y.ToString("000"));
            report.Unread = true;
            report.Owner = this.ToVillage.Player;
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

            ITransaction trans = null;
            try
            {
                trans = session.BeginTransaction(IsolationLevel.ReadUncommitted);
                session.Save(r);
                session.Delete(this);
                trans.Commit();
            }
            catch
            {
                if (trans != null)
                    trans.Rollback();
            }
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

            int merchantNeeded = SendResource.CalculateMerchant(this.Wood, this.Clay, this.Iron);

            if (this.FromVillage.VillageBuildingData.Merchant < merchantNeeded)
                throw new Exception("Không đủ thương nhân");

            this.FromVillage.VillageResourceData.Clay -= this.Clay;
            this.FromVillage.VillageResourceData.Wood -= this.Wood;
            this.FromVillage.VillageResourceData.Iron -= this.Iron;
            this.FromVillage.VillageBuildingData.Merchant -= merchantNeeded;

            ITransaction trans = null;
            try
            {
                trans = session.BeginTransaction(IsolationLevel.ReadUncommitted);
                session.BeginTransaction(IsolationLevel.ReadCommitted);
                session.Save(this);
                session.Update(this.FromVillage.VillageResourceData);
                session.Update(this.FromVillage.VillageBuildingData);
                trans.Commit();
            }
            catch
            {
                if (trans != null)
                    trans.Rollback();
            }
        }
    }
}
