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

using NHibernate;
using beans;
using System.IO;
using System.Drawing;

public partial class UserProfile : System.Web.UI.UserControl
{

    protected Player player;

    protected void Page_Load(object sender, EventArgs e)
    {
        this.Page.Form.Attributes.Add("onsubmit", "tinyMCE.triggerSave();");
        this.Page.Form.Enctype = "multipart/form-data";

        ISession session = NHibernateHelper.CreateSession();
        this.player = session.Load<Player>(Session["user"]);
        session.Close();

        this.aDeleteAvatar.Visible = this.player.Avatar;
        if (!Page.IsPostBack)
        {

            for (int i = 1; i <= 30; i++)
                this.cbDay.Items.Add(new ListItem(i.ToString("00"), i.ToString()));
            for (int i = 2005; i >= 1950; i--)
                this.cbYear.Items.Add(new ListItem(i.ToString(), i.ToString()));



            this.txtAddress.Text = this.player.Address;
            this.txtPersonalText.Content = this.player.Description;
            if (this.player.Gender == Sex.Nam)
                this.rdoMale.Checked = true;
            else
                this.rdoMale.Checked = false;


            this.cbDay.SelectedIndex = this.player.Birthdate.Day - 1;
            this.cbMonth.SelectedIndex = this.player.Birthdate.Month - 1;
            this.cbYear.SelectedIndex = 2005 - this.player.Birthdate.Year;
            this.txtSkype.Text = this.player.Skype;
            this.txtYahoo.Text = this.player.Yahoo;
        }
    }

    protected void aDeleteAvatar_Click(object sender, EventArgs e)
    {
        ISession session = NHibernateHelper.CreateSession();
        this.player = session.Load<Player>(Session["user"]);
        this.player.Avatar = false;
        if (File.Exists(Server.MapPath("~/data/images/members/") + this.player.ID.ToString() + ".jpg"))
            File.Delete(Server.MapPath("~/data/images/members/") + this.player.ID.ToString() + ".jpg");
        ITransaction trans = session.BeginTransaction(IsolationLevel.ReadCommitted);
        session.Update(this.player);
        trans.Commit();
        session.Close();
    }

    protected void bttnChangePlayerProfile_Click(object sender, EventArgs e)
    {
        ISession session = NHibernateHelper.CreateSession();
        this.player = session.Load<Player>(Session["user"]);

        this.player.Yahoo = this.txtYahoo.Text;
        this.player.Skype = this.txtSkype.Text;
        this.player.Address = this.txtAddress.Text;
        this.player.Description = this.txtPersonalText.Content;
        this.player.Birthdate = new DateTime(int.Parse(this.cbYear.SelectedValue), int.Parse(this.cbMonth.SelectedValue), int.Parse(this.cbDay.SelectedValue));
        if (this.rdoMale.Checked)
            this.player.Gender = Sex.Nam;
        else
            this.player.Gender = Sex.Nữ;

        ArrayList lstExtension = new ArrayList();
        lstExtension.Add(".jpg");
        lstExtension.Add(".gif");
        lstExtension.Add(".png");
        lstExtension.Add(".jpeg");

        if (this.fileAvatar.HasFile)
        {
            string filename = fileAvatar.FileName;
            if (!lstExtension.Contains(Path.GetExtension(filename).ToLower()))
                this.lblAvatarError.Text = "Sai định dạng file ảnh";
            else
            {
                if (!Functions.UploadImage(fileAvatar.FileContent, Server.MapPath("~/data/images/members/") + this.player.ID.ToString() + ".jpg"))
                    this.lblAvatarError.Text = "Có lỗi khi upload ảnh. Vui lòng thử lại sau vài phút";
                else
                    this.player.Avatar = true;
            }
        }

        ITransaction trans = session.BeginTransaction(IsolationLevel.ReadCommitted);
        session.Update(this.player);
        trans.Commit();
        session.Close();
    }
}
