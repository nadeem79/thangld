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

        #region Methods

        public override void Effect(ISession session)
        {
            this.To.Update(this.LandingTime, session);
            this.To.Resources.Clay += this.Clay;
            this.To.Resources.Wood += this.Wood;
            this.To.Resources.Iron += this.Iron;

            Return r = new Return();
            r.Merchant = (int)Math.Round((double)((this.Clay + this.Wood + this.Iron) / 1000), MidpointRounding.AwayFromZero);
            r.From = this.To;
            r.To = this.From;
            r.StartTime = DateTime.Now;
            r.LandingTime = DateTime.Now + (DateTime.Now - this.StartTime);

            Report to = this.WriteReport();
            to.Owner = this.To.Owner;

            Report from = this.WriteReport();
            from.Time = this.LandingTime;
            from.Title = String.Format("{0} gửi tài nguyên đến {1} ({2}|{3})", this.From.Owner.Username, this.To.Name, this.To.X.ToString("000"), this.To.Y.ToString("000"));
            from.Type = ReportType.ResourceReceive;
            from.Unread = true;
            from.Owner = this.From.Owner;
            from.Description.Description = to.Description.Description;

            session.Save(r);
            session.Delete(this);
            session.Save(from);
            session.Save(to);
            
        }

        public override void Cancel(ISession session)
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
        }

        #endregion

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

            this.FromVillage.VillageResourceData.Clay -= this.Clay;
            this.FromVillage.VillageResourceData.Wood -= this.Wood;
            this.FromVillage.VillageResourceData.Iron -= this.Iron;

            session.Save(this);
            session.Update(this.FromVillage.VillageResourceData);
        }
    }
}
