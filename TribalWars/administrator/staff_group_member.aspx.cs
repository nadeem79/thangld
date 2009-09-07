using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using beans;
using NHibernate;
using Telerik.Web.UI;

public partial class administrator_staff_group_member : System.Web.UI.Page
{
    protected StaffGroup StaffGroup
    {
        get;
        set;
    }

    protected void Page_Load(object sender, EventArgs e)
    {

        RadTreeNode parentNode = ((administrator_administrator)this.Master).Menu.FindNodeByValue(beans.JobEnum.StaffGroupManagement.ToString());
        parentNode.Expanded = true;
        RadTreeNode childNode = parentNode.Nodes.FindNodeByValue("List");
        if (childNode != null)
            childNode.ImageUrl = "images/map_e.png";

        

        int groupId = 0;
        if (!int.TryParse(Request["group"], out groupId))
        {
            Response.Redirect("staff_groups.aspx", true);
            return;
        }
        ISession session = (ISession)Context.Items[Constant.NHibernateSessionSign];
        Player staff = session.Load<Player>(Session[Constant.StaffUserSessionSign]);
        this.StaffGroup = session.Get<StaffGroup>(groupId);
        if (this.StaffGroup == null)
        {
            Response.Redirect("staff_groups.aspx", true);
            return;
        }

        if (IsPostBack)
            return;
        
        this.rptGroupStaffs.DataSource = ServicesList.StaffManagementService.GetStaffGroupMembers(staff, this.StaffGroup, session);
        this.rptGroupStaffs.DataBind();
    }

    protected void rptGroupStaffs_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "DismissStaff")
        {
            ISession session = (ISession)Context.Items[Constant.NHibernateSessionSign];
            Player staff = session.Load<Player>(Session[Constant.StaffUserSessionSign]);

            int staffID = 0;
            if (!int.TryParse(e.CommandArgument.ToString(), out staffID))
                return;

            if (staffID == (int)Session[Constant.StaffUserSessionSign])
                return;

            Player currentStaff = session.Load<Player>(staffID);

            ServicesList.StaffManagementService.RemoveMemberFromStaffGroup(staff, currentStaff, this.StaffGroup, session);
            this.rptGroupStaffs.DataSource = ServicesList.StaffManagementService.GetStaffGroupMembers(staff, this.StaffGroup, session);
            this.rptGroupStaffs.DataBind();
        }
    }

    protected void bttnAddStaff_Click(object sender, EventArgs e)
    {
        ISession session = (ISession)Context.Items[Constant.NHibernateSessionSign];
        Player staff = session.Load<Player>(Session[Constant.StaffUserSessionSign]);

        ServicesList.StaffManagementService.AddMemberToStaffGroup(staff, this.txtNewStaffName.Text, this.StaffGroup, session);

        this.rptGroupStaffs.DataSource = ServicesList.StaffManagementService.GetStaffGroupMembers(staff, this.StaffGroup, session);
        this.rptGroupStaffs.DataBind();
    }
}
