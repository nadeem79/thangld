using System;
using System.Collections;
using System.Configuration;
using System.Data;

using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

using beans;
using NHibernate;
using System.IO;
using System.Drawing;
using Telerik.Web.UI;

public partial class TribeProfile : System.Web.UI.UserControl
{

    protected Group tribe;
    protected Village village;
    public Group Tribe
    {
        get { return this.tribe; }
        set { this.tribe = value; }
    }
    public Village Village
    {
        get { return this.village; }
        set { this.village = value; }
    }



    protected void Page_Load(object sender, EventArgs e)
    {

        ISession session = NHibernateHelper.CreateSession();
        Player player = session.Get<Player>(Session["user"]);
        if ((player.TribePermission & TribePermission.ChangeTribeDescription) != TribePermission.ChangeTribeDescription)
        {
            this.pChangeDescription.Visible = false;
            this.pChangeInfo.Visible = false;
            session.Close();
            return;
        }
        
        session.Close();
        this.tribe = player.Group;
        if (!IsPostBack)
        {
            this.txtDescription.Content = this.tribe.Description;
            this.txtName.Text = this.tribe.Name;
            this.txtTag.Text = this.tribe.Tag;
            if (this.tribe.Avatar)
                imgAvatar.ImageUrl = @"data/images/tribe/" + this.tribe.ID.ToString() + ".jpg";
            else
                this.aDeleteAvatar.Visible = false;
        }
    }



    protected void bttnChangeTribeInfo_Click(object sender, EventArgs e)
    {
        this.tribe.Tag = this.txtTag.Text;
        this.tribe.Name = this.txtName.Text;
        this.tribe.Description = this.txtDescription.Content;

        if (this.fileAvatar.HasFile)
        {
            ArrayList lstExtension = new ArrayList();
            lstExtension.Add(".jpg");
            lstExtension.Add(".gif");
            lstExtension.Add(".png");
            lstExtension.Add(".jpeg");
            string filename = fileAvatar.FileName;
            if (!lstExtension.Contains(Path.GetExtension(filename).ToLower()))
                this.lblAvatarError.Text = "Định dạng file ảnh phải là jpg";
            else if (!Functions.UploadImage(fileAvatar.FileContent, Server.MapPath("~/data/images/tribe/") + this.tribe.ID.ToString() + ".jpg"))
                this.lblAvatarError.Text = "File không đúng định dạng. Vui lòng thử lại với ảnh khác";
            else
                this.tribe.Avatar = true;
        }

        ISession session = NHibernateHelper.CreateSession();
        ITransaction trans = session.BeginTransaction(IsolationLevel.ReadCommitted);
        session.Update(this.tribe);
        trans.Commit();
        session.Close();
        Response.Redirect("tribe.aspx?id=" + this.village.ID.ToString(), true);
    }

    protected void aDeleteAvatar_Click(object sender, EventArgs e)
    {
        this.tribe.Avatar = false;
        if (File.Exists(Server.MapPath("~/data/images/tribe/") + this.tribe.ID.ToString() + ".jpg"))
            File.Delete(Server.MapPath("~/data/images/tribe/") + this.tribe.ID.ToString() + ".jpg");
        ISession session = NHibernateHelper.CreateSession();
        ITransaction trans = session.BeginTransaction(IsolationLevel.ReadCommitted);
        session.Update(this.tribe);
        trans.Commit();
        session.Close();
        Response.Redirect("tribe.aspx?id=" + this.village.ID.ToString(), true);
    }

}
