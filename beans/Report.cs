using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NVelocity;
using NVelocity.App;
using NVelocity.Context;
using Commons.Collections;
using System.IO;


namespace beans
{
    public class Report:IdentityObject
    {
        public Player Owner
        {
            get;
            set;
        }
        public DateTime Time
        {
            get;
            set;
        }
        public ReportType Type
        {
            get;
            set;
        }
        public string Title
        {
            get;
            set;
        }
        public Text Description
        {
            get;
            set;
        }
        public bool Unread
        {
            get;
            set;
        }

        public void SetAttackReport(AttackReport report)
        {
            this.Type = ReportType.Attack;
            this.Title = string.Format("{0} tấn công {1} ({2}|{3})", report.From.Owner.Username, report.To.Name, report.To.X.ToString("000"), report.To.Y.ToString("000"));
            this.Unread = true;

            

            VelocityEngine velocity = new VelocityEngine();
            ExtendedProperties props = new ExtendedProperties();
            velocity.Init(props);
            Template template = velocity.GetTemplate(@"Templates/AttackReport.txt");

            VelocityContext context = new VelocityContext();
            context.Put("report", this);
            context.Put("attack", report);

            StringWriter writer = new StringWriter();
            template.Merge(context, writer);

            this.Description.Description = writer.GetStringBuilder().ToString();

        }

        public Report()
        {
            this.Description = new Text();
        }
    }
}
