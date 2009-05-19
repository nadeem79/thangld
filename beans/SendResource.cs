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
        #region Variables
        

        
        #endregion

        #region Properties
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
        #endregion

        #region Constructors
        public SendResource()
        {

        }

        #endregion

        public static SendResource PrepareSendingResources(ISession session, Village from, int coordinateX, int coordinateY, int wood, int clay, int iron)
        {

            if (coordinateX == from.X && coordinateY == from.Y)
                throw new Exception("Nhập toạ độ");

            if (wood < 0 || clay < 0 || iron < 0 || (wood + clay + iron) == 0)
                throw new Exception("Nhập tài nguyên");

            if (wood > from.Resources.Wood || clay > from.Resources.Clay || iron > from.Resources.Iron)
                throw new Exception("Không đủ tài nguyên");

            if (Math.Round((double)((wood+clay+iron)/1000), MidpointRounding.AwayFromZero)>from.Buildings.Merchant)
                throw new Exception("Không đủ thương nhân");

            int village_id = Village.CheckVillage(coordinateX, coordinateY, session);
            if (village_id <= 0)
                throw new Exception(String.Format("Thành phố không tồn tại ở toạ độ ({0}|{1})", coordinateX.ToString("000"), coordinateY.ToString("000")));

            Village to = session.Get<Village>(village_id);

            SendResource sendResource = new SendResource();
            sendResource.Wood = wood;
            sendResource.Clay = clay;
            sendResource.Iron = iron;
            sendResource.From = from;
            sendResource.To = to;
            sendResource.StartTime = DateTime.Now;
            sendResource.LandingTime = Map.LandingTime(TroopType.Merchant, from, to, DateTime.Now);

            from.Resources.Wood -= wood;
            from.Resources.Clay -= clay;
            from.Resources.Iron -= iron;

            session.Update(from);
            session.Save(sendResource);

            return sendResource;

        }

        #region Methods

        protected Report WriteReport()
        {
            Report report = new Report();
            report.Time = this.LandingTime;
            report.Title = String.Format("{0} gửi tài nguyên đến {1} ({2}|{3})", this.From.Owner.Username, this.To.Name, this.To.X.ToString("000"), this.To.Y.ToString("000"));
            report.Type = ReportType.ResourceReceive;
            report.Unread = true;

            StringTemplateGroup group = new StringTemplateGroup("attack");
            StringTemplate temp = new StringTemplate(group, reports.ResourceReceive);

            temp.SetAttribute("from_id", this.From.Owner.ID);
            temp.SetAttribute("from_name", this.From.Owner.Username);
            temp.SetAttribute("from_village_id", this.From.ID);
            temp.SetAttribute("from_village_x", this.From.X.ToString("000"));
            temp.SetAttribute("from_village_y", this.From.Y.ToString("000"));
            temp.SetAttribute("from_village_name", this.From.Name);

            temp.SetAttribute("to_id", this.To.Owner.ID);
            temp.SetAttribute("to_name", this.To.Owner.Username);
            temp.SetAttribute("to_village_id", this.To.ID);
            temp.SetAttribute("to_village_x", this.To.X.ToString("000"));
            temp.SetAttribute("to_village_y", this.To.Y.ToString("000"));
            temp.SetAttribute("to_village_name", this.To.Name);

            if (this.Wood > 0)
                temp.SetAttribute("wood", String.Format("<img src='images/holz.png' alt='Wood' title='Wood' /> {0}", this.Wood));
            else
                temp.SetAttribute("wood", "");

            if (this.Clay > 0)
                temp.SetAttribute("clay", String.Format("<img src='images/lehm.png' alt='Clay' title='Clay' /> {0}", this.Clay));
            else
                temp.SetAttribute("clay", "");

            if (this.Iron > 0)
                temp.SetAttribute("iron", String.Format("<img src='images/eisen.png' alt='Iron' title='Iron' /> {0}", this.Iron));
            else
                temp.SetAttribute("iron", "");

            report.Description.Description = temp.ToString();
            return report;
        }

        public override void effect(ISession session)
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

        public override void cancel(ISession session)
        {
            Return r = new Return();
            r.Wood = this.Wood;
            r.Clay = this.Clay;
            r.Iron = this.Iron;
            r.From = this.To;
            r.To = this.From;
            r.StartTime = DateTime.Now;
            r.LandingTime = DateTime.Now + (DateTime.Now - this.StartTime);

            session.Save(r);
            session.Delete(this);
        }

        #endregion

        public override void save(ISession session)
        {
            throw new NotImplementedException();
        }
    }
}
