using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
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
            this.txtPersonalText.Text = this.player.Description;
            if (this.player.Gender == Sex.Nam)
                this.rdoMale.Checked = true;
            else
                this.rdoMale.Checked = false;


            this.cbDay.SelectedIndex = this.player.Birthdate.Day - 1;
            this.cbMonth.SelectedIndex = this.player.Birthdate.Month - 1;
            this.cbYear.SelectedIndex = 2005 - this.player.Birthdate.Year;
        }
    }

    protected void aDeleteAvatar_Click(object sender, EventArgs e)
    {
        ISession session = NHibernateHelper.CreateSession();
        this.player = session.Load<Player>(Session["user"]);
        this.player.Avatar = false;
        if (File.Exists(Server.MapPath("~/data/images/") + this.player.ID.ToString() + ".jpg"))
            File.Delete(Server.MapPath("~/data/images/") + this.player.ID.ToString() + ".jpg");
        ITransaction trans = session.BeginTransaction(IsolationLevel.ReadCommitted);
        session.Update(this.player);
        trans.Commit();
        session.Close();
    }

    protected void bttnChangePlayerProfile_Click(object sender, EventArgs e)
    {
        ISession session = NHibernateHelper.CreateSession();
        this.player = session.Load<Player>(Session["user"]);

        this.player.Address = this.txtAddress.Text;
        this.player.Description = this.txtPersonalText.Text;
        this.player.Birthdate = new DateTime(int.Parse(this.cbYear.SelectedValue), int.Parse(this.cbMonth.SelectedValue), int.Parse(this.cbDay.SelectedValue));
        if (this.rdoMale.Checked)
            this.player.Gender = Sex.Nam;
        else
            this.player.Gender = Sex.Nữ;

        if (this.fileAvatar.HasFile)
        {
            System.Drawing.Image avatar = null;
            string filename = fileAvatar.FileName;
            if (!Path.GetExtension(filename).ToLower().Equals(".jpg"))
                this.lblAvatarError.Text = "Định dạng file ảnh phải là jpg";
            else if (fileAvatar.PostedFile.ContentLength > 131072)
                this.lblAvatarError.Text = "Dung lượng ảnh không được vượt quá 120 kBytes";
            else
            {
                avatar = new Bitmap(fileAvatar.FileContent);
                if (avatar.Width > 240)
                    this.lblAvatarError.Text = "Chiều dài không được vượt quá 240 pixel";
                else if (avatar.Height > 180)
                    this.lblAvatarError.Text = "Chiều cao không được vượt quá 180 pixel";
                if (!this.lblAvatarError.Text.Equals(string.Empty))
                {
                    avatar.Dispose();
                    avatar = null;
                }
            }

            if (avatar != null)
            {
                if (File.Exists(Server.MapPath("~/data/images/") + this.player.ID.ToString() + ".jpg"))
                    File.Delete(Server.MapPath("~/data/images/") + this.player.ID.ToString() + ".jpg");
                avatar.Save(Server.MapPath("~/data/images/") + this.player.ID.ToString() + ".jpg");
                this.player.Avatar = true;
            }

        }
        ITransaction trans = session.BeginTransaction(IsolationLevel.ReadCommitted);
        session.Update(this.player);
        trans.Commit();
        session.Close();
    }
}
