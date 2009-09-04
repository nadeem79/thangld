using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using NHibernate;
using beans;

public partial class administrator_change_staff_permission : System.Web.UI.Page
{

    protected StaffGroup StaffGroup
    {
        get;
        set;
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack)
            return;

        RadTreeNode parentNode = ((administrator_administrator)this.Master).Menu.FindNodeByValue(beans.JobEnum.StaffGroupManagement.ToString());
        parentNode.Expanded = true;
        RadTreeNode childNode = parentNode.Nodes.FindNodeByValue("List");
        if (childNode != null)
            childNode.ImageUrl = "images/map_e.png";

        ISession session = (ISession)Context.Items[Constant.NHibernateSessionSign];
        Player staff = session.Load<Player>(Session[Constant.StaffUserSessionSign]);

        int groupId = 0;
        if (!int.TryParse(Request["group"], out groupId))
        {
            Response.Redirect("staff_groups.aspx", true);
            return;
        }

        this.StaffGroup = session.Get<StaffGroup>(groupId);
        if (this.StaffGroup == null)
        {
            Response.Redirect("staff_groups.aspx", true);
            return;
        }

        this.txtGroupName.Text = this.StaffGroup.Name;

        Permission numeric = (from permission in this.StaffGroup.Permissions
                              where permission.Job == JobEnum.NumericSettings.ToString()
                              select permission).SingleOrDefault<Permission>();
        this.chkNumeric.Checked = (numeric != null);

        Permission text = (from permission in this.StaffGroup.Permissions
                              where permission.Job == JobEnum.TextSettings.ToString()
                              select permission).SingleOrDefault<Permission>();
        this.chkText.Checked = (text != null);

        Permission restart = (from permission in this.StaffGroup.Permissions
                              where permission.Job == JobEnum.RestartServer.ToString()
                              select permission).SingleOrDefault<Permission>();
        this.chkRestartServer.Checked = (restart != null);

        Permission staffManagement = (from permission in this.StaffGroup.Permissions
                                      where permission.Job == JobEnum.StaffGroupManagement.ToString()
                                      select permission).SingleOrDefault<Permission>();
        this.chkStaffManagement.Checked = (staffManagement != null);
        this.txtStaffPrivilege.Text = this.chkStaffManagement.Checked ? staffManagement.Privilage : "";

        Permission memberManagement = (from permission in this.StaffGroup.Permissions
                                       where permission.Job == JobEnum.MemberManagement.ToString()
                                       select permission).SingleOrDefault<Permission>();
        this.chkMemberManagement.Checked = (memberManagement != null);
        this.txtMemberPrivilege.Text = this.chkMemberManagement.Checked ? memberManagement.Privilage : "";
        
    }

    protected void bttnChange_Click(object sender, EventArgs e)
    {
        ISession session = (ISession)Context.Items[Constant.NHibernateSessionSign];
        Player staff = session.Load<Player>(Session[Constant.StaffUserSessionSign]);
        int groupId = int.Parse(Request["group"]);
        

        IList<Permission> permissions = new List<Permission>();

        if (this.chkNumeric.Checked)
            permissions.Add(new Permission(JobEnum.NumericSettings, ""));
        if (this.chkText.Checked)
            permissions.Add(new Permission(JobEnum.TextSettings, ""));
        if (this.chkRestartServer.Checked)
            permissions.Add(new Permission(JobEnum.RestartServer, ""));
        if (this.chkStaffManagement.Checked)
            permissions.Add(new Permission(JobEnum.StaffGroupManagement, this.txtStaffPrivilege.Text));
        if (this.chkStaffManagement.Checked)
            permissions.Add(new Permission(JobEnum.MemberManagement, this.txtMemberPrivilege.Text));

        ServicesList.StaffManagementService.SetStaffGroupPermission(staff, groupId, permissions, session);

    }
}
