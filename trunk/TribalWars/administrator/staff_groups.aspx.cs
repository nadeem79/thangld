using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using NHibernate;
using beans;

public partial class administrator_staff_groups : System.Web.UI.Page
{

    

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

        

        IList<StaffGroup> staffGroups = ServicesList.StaffManagementService.GetStaffGroups(staff, session);

        this.rptStaffGroups.DataSource = staffGroups;
        this.rptStaffGroups.DataBind();

    }

    protected void bttnCreateNewStaffGroup_Click(object sender, EventArgs e)
    {
        if (this.txtGroupName.Text == string.Empty)
            return;

        ISession session = (ISession)Context.Items[Constant.NHibernateSessionSign];
        Player staff = session.Load<Player>(Session[Constant.StaffUserSessionSign]);

        try
        {
            ServicesList.StaffManagementService.CreateStaffGroup(staff, this.txtGroupName.Text, new List<Permission>(), session);
            IList<StaffGroup> staffGroups = ServicesList.StaffManagementService.GetStaffGroups(staff, session);
            this.rptStaffGroups.DataSource = staffGroups;
            this.rptStaffGroups.DataBind();
            this.lblError.Text = "";
        }
        catch (Exception ex)
        {
            this.lblError.Text = ex.Message;
        }
    }
    protected void rptStaffGroups_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "DeleteStaffGroup")
        {
            int staffGroupId = 0;
            if (!int.TryParse(e.CommandArgument.ToString(), out staffGroupId))
                return;

            ISession session = (ISession)Context.Items[Constant.NHibernateSessionSign];
            try
            {
                Player staff = session.Load<Player>(Session[Constant.StaffUserSessionSign]);
                ServicesList.StaffManagementService.DeleteStaffGroup(staff, staffGroupId, session);
                this.lblError.Text = "";
            }
            catch (Exception ex)
            {
                this.lblError.Text = ex.Message;
            }
        }
    }
}
