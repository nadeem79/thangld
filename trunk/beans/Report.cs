using System;
using Antlr.StringTemplate;


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

            StringTemplateGroup group = new StringTemplateGroup("attack");
            StringTemplate temp = new StringTemplate(group, reports.Attack);

            temp.SetAttribute("title", this.Title);
            temp.SetAttribute("time", this.Time.ToString("hh:mm:ss:'<span class=\"hidden\">'fff'</span>' 'ngày' dd/MM/yyyy"));
            temp.SetAttribute("success", report.SuccessAttack);
            temp.SetAttribute("luck", report.Luck.ToString("0.00"));
            temp.SetAttribute("winning", (report.SuccessAttack)?"Bên tấn công":"Bên phòng thủ");

            temp.SetAttribute("attacker_name", report.From.Owner.Username);
            temp.SetAttribute("attacker_id", report.From.Owner.ID);
            temp.SetAttribute("attacker_village_name", report.From.Name);
            temp.SetAttribute("attacker_village_id", report.From.ID);
            temp.SetAttribute("attacker_village_x", report.From.X.ToString("000"));
            temp.SetAttribute("attacker_village_y", report.From.Y.ToString("000"));
            temp.SetAttribute("SpearSent", (report.SpearSent > 0) ? report.SpearSent.ToString() : string.Format("<span class='hidden'>{0}</span>", report.SpearSent));
            temp.SetAttribute("SwordSent", (report.SwordSent > 0) ? report.SwordSent.ToString() : string.Format("<span class='hidden'>{0}</span>", report.SwordSent));
            temp.SetAttribute("AxeSent", (report.AxeSent > 0) ? report.AxeSent.ToString() : string.Format("<span class='hidden'>{0}</span>", report.AxeSent));
            temp.SetAttribute("ScoutSent", (report.ScoutSent > 0) ? report.ScoutSent.ToString() : string.Format("<span class='hidden'>{0}</span>", report.ScoutSent));
            temp.SetAttribute("LightSent", (report.LightSent > 0) ? report.LightSent.ToString() : string.Format("<span class='hidden'>{0}</span>", report.LightSent));
            temp.SetAttribute("HeavySent", (report.HeavySent > 0) ? report.HeavySent.ToString() : string.Format("<span class='hidden'>{0}</span>", report.HeavySent));
            temp.SetAttribute("RamSent", (report.RamSent > 0) ? report.RamSent.ToString() : string.Format("<span class='hidden'>{0}</span>", report.RamSent));
            temp.SetAttribute("CatapultSent", (report.CatapultSent > 0) ? report.CatapultSent.ToString() : string.Format("<span class='hidden'>{0}</span>", report.CatapultSent));
            temp.SetAttribute("NobleSent", (report.NobleSent > 0) ? report.NobleSent.ToString() : string.Format("<span class='hidden'>{0}</span>", report.NobleSent));
            temp.SetAttribute("SpearRemaint", (report.SpearSent - report.SpearSurvived > 0) ? (report.SpearSent - report.SpearReturnt).ToString() : string.Format("<span class='hidden'>{0}</span>", report.SpearSent - report.SpearReturnt));
            temp.SetAttribute("SwordRemaint", (report.SwordSent - report.SwordSurvived > 0) ? (report.SwordSent - report.SwordReturnt).ToString() : string.Format("<span class='hidden'>{0}</span>", report.SwordSent - report.SwordReturnt));
            temp.SetAttribute("AxeRemaint", (report.AxeSent - report.AxeSurvived > 0) ? (report.AxeSent - report.AxeReturnt).ToString() : string.Format("<span class='hidden'>{0}</span>", report.AxeSent - report.AxeReturnt));
            temp.SetAttribute("ScoutRemaint", (report.ScoutSent - report.ScoutSurvived > 0) ? (report.ScoutSent - report.ScoutReturnt).ToString() : string.Format("<span class='hidden'>{0}</span>", report.ScoutSent - report.ScoutReturnt));
            temp.SetAttribute("LightRemaint", (report.LightSent - report.LightSurvived > 0) ? (report.LightSent - report.LightReturnt).ToString() : string.Format("<span class='hidden'>{0}</span>", report.LightSent - report.LightReturnt));
            temp.SetAttribute("HeavyRemaint", (report.HeavySent - report.HeavySurvived > 0) ? (report.HeavySent - report.HeavyReturnt).ToString() : string.Format("<span class='hidden'>{0}</span>", report.HeavySent - report.HeavyReturnt));
            temp.SetAttribute("RamRemaint", (report.RamSent - report.RamSurvived > 0) ? (report.RamSent - report.RamReturnt).ToString() : string.Format("<span class='hidden'>{0}</span>", report.RamSent - report.RamReturnt));
            temp.SetAttribute("CatapultRemaint", (report.CatapultSent - report.CatapultSurvived > 0) ? (report.CatapultSent - report.CatapultReturnt).ToString() : string.Format("<span class='hidden'>{0}</span>", report.CatapultSent - report.CatapultReturnt));
            temp.SetAttribute("NobleRemaint", (report.NobleSent - report.NobleSurvived > 0) ? (report.NobleSent - report.NobleReturnt).ToString() : string.Format("<span class='hidden'>{0}</span>", report.NobleSent - report.NobleReturnt));

            temp.SetAttribute("defender_name", report.To.Owner.Username);
            temp.SetAttribute("defender_id", report.To.Owner.ID);
            temp.SetAttribute("defender_village_name", report.To.Name);
            temp.SetAttribute("defender_village_id", report.To.ID);
            temp.SetAttribute("defender_village_x", report.To.X.ToString("000"));
            temp.SetAttribute("defender_village_y", report.To.Y.ToString("000"));
            temp.SetAttribute("SpearDefense", (report.SpearDefense>0)?report.SpearDefense.ToString():string.Format("<span class='hidden'>{0}</span>", report.SpearDefense));
            temp.SetAttribute("SwordDefense", (report.SwordDefense>0)?report.SwordDefense.ToString():string.Format("<span class='hidden'>{0}</span>", report.SwordDefense));
            temp.SetAttribute("AxeDefense", (report.AxeDefense>0)?report.AxeDefense.ToString():string.Format("<span class='hidden'>{0}</span>", report.AxeDefense));
            temp.SetAttribute("ScoutDefense", (report.ScoutDefense>0)?report.ScoutDefense.ToString():string.Format("<span class='hidden'>{0}</span>", report.ScoutDefense));
            temp.SetAttribute("LightDefense", (report.LightDefense>0)?report.LightDefense.ToString():string.Format("<span class='hidden'>{0}</span>", report.LightDefense));
            temp.SetAttribute("HeavyDefense", (report.HeavyDefense>0)?report.HeavyDefense.ToString():string.Format("<span class='hidden'>{0}</span>", report.HeavyDefense));
            temp.SetAttribute("RamDefense", (report.RamDefense>0)?report.RamDefense.ToString():string.Format("<span class='hidden'>{0}</span>", report.RamDefense));
            temp.SetAttribute("CatapultDefense", (report.CatapultDefense>0)?report.CatapultDefense.ToString():string.Format("<span class='hidden'>{0}</span>", report.CatapultDefense));
            temp.SetAttribute("NobleDefense", (report.NobleDefense>0)?report.NobleDefense.ToString():string.Format("<span class='hidden'>{0}</span>", report.NobleDefense));
            temp.SetAttribute("SpearSurvived", (report.SpearDefense - report.SpearSurvived > 0) ? (report.SpearDefense - report.SpearSurvived).ToString() : string.Format("<span class='hidden'>{0}</span>", report.SpearDefense - report.SpearSurvived));
            temp.SetAttribute("SwordSurvived", (report.SwordDefense - report.SwordSurvived > 0) ? (report.SwordDefense - report.SwordSurvived).ToString() : string.Format("<span class='hidden'>{0}</span>", report.SwordDefense - report.SwordSurvived));
            temp.SetAttribute("AxeSurvived", (report.AxeDefense - report.AxeSurvived > 0) ? (report.AxeDefense - report.AxeSurvived).ToString() : string.Format("<span class='hidden'>{0}</span>", report.AxeDefense - report.AxeSurvived));
            temp.SetAttribute("ScoutSurvived", (report.ScoutDefense - report.ScoutSurvived > 0) ? (report.ScoutDefense - report.ScoutSurvived).ToString() : string.Format("<span class='hidden'>{0}</span>", report.ScoutDefense - report.ScoutSurvived));
            temp.SetAttribute("LightSurvived", (report.LightDefense - report.LightSurvived > 0) ? (report.LightDefense - report.LightSurvived).ToString() : string.Format("<span class='hidden'>{0}</span>", report.LightDefense - report.LightSurvived));
            temp.SetAttribute("HeavySurvived", (report.HeavyDefense - report.HeavySurvived > 0) ? (report.HeavyDefense - report.HeavySurvived).ToString() : string.Format("<span class='hidden'>{0}</span>", report.HeavyDefense - report.HeavySurvived));
            temp.SetAttribute("RamSurvived", (report.RamDefense - report.RamSurvived > 0) ? (report.RamDefense - report.RamSurvived).ToString() : string.Format("<span class='hidden'>{0}</span>", report.RamDefense - report.RamSurvived));
            temp.SetAttribute("CatapultSurvived", (report.CatapultDefense - report.CatapultSurvived > 0) ? (report.CatapultDefense - report.CatapultSurvived).ToString() : string.Format("<span class='hidden'>{0}</span>", report.CatapultDefense - report.CatapultSurvived));
            temp.SetAttribute("NobleSurvived", (report.NobleDefense - report.NobleSurvived > 0) ? (report.NobleDefense - report.NobleSurvived).ToString() : string.Format("<span class='hidden'>{0}</span>", report.NobleDefense - report.NobleSurvived));

            temp.SetAttribute("Clay", report.Clay);
            temp.SetAttribute("Wood", report.Wood);
            temp.SetAttribute("Iron", report.Iron);

            this.Description.Description = temp.ToString();

        }

        public Report()
        {
            this.Description = new Text();
        }
    }
}
