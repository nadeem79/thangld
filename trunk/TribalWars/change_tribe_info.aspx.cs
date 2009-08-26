using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using beans;
using NHibernate;
using System.Data;
using System.IO;
using System.Drawing;

public partial class change_tribe_info : System.Web.UI.Page
{

    protected Group group;

    protected void Page_Load(object sender, EventArgs e)
    {

        if (Session["user"] == null)
        {
            this.pCannotChange.Visible = true;
            this.pCanChange.Visible = false;
            
            return;
        }

        ISession session = (ISession)Context.Items[Constant.NHibernateSessionSign];

        Player player = session.Get<Player>(Session["user"]);
        if ((player.TribePermission & TribePermission.ChangeTribeDescription) != TribePermission.ChangeTribeDescription)
        {
            this.pCannotChange.Visible = true;
            this.pCanChange.Visible = false;
            return;
        }
        this.pCannotChange.Visible = false;
        this.pCanChange.Visible = true;
        this.group = player.Group;
        if (!this.group.Avatar)
            this.aDeleteAvatar.Visible = false;
        else
        {
            this.aDeleteAvatar.Visible = true;
            this.imgAvatar.ImageUrl = @"~/data/images/tribe/" + this.group.ID.ToString() + ".jpg";
        }

        if (!IsPostBack)
        {
            this.txtName.Text = this.group.Name;
            this.txtTag.Text = this.group.Tag;
            this.txtDescription.Content = this.group.Description;
        }
    }

    protected void aDeleteAvatar_Click(object sender, EventArgs e)
    {
        this.error.Text = "1";
        try
        {
            this.group.Avatar = false;
            if (File.Exists(Server.MapPath("~/data/images/tribe/") + this.group.ID.ToString() + ".jpg"))
                File.Delete(Server.MapPath("~/data/images/tribe/") + this.group.ID.ToString() + ".jpg");
            ISession session = (ISession)Context.Items[Constant.NHibernateSessionSign];
            session.Update(this.group);
            this.imgAvatar.ImageUrl = "";
            this.aDeleteAvatar.Visible = false;
        }
        catch (Exception ex)
        {
            this.error.Text = ex.Message;
        }
    }

    protected void bttnChangeTribeInfo_Click(object sender, EventArgs e)
    {
        try
        {
            this.group.Tag = this.txtTag.Text;
            this.group.Name = this.txtName.Text;
            this.group.Description = this.txtDescription.Content;
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
                    if (File.Exists(Server.MapPath("~/data/images/tribe/") + this.group.ID.ToString() + ".jpg"))
                        File.Delete(Server.MapPath("~/data/images/tribe/") + this.group.ID.ToString() + ".jpg");
                    avatar.Save(Server.MapPath("~/data/images/tribe/") + this.group.ID.ToString() + ".jpg");
                    this.group.Avatar = true;
                }

            }

            ISession session = (ISession)Context.Items[Constant.NHibernateSessionSign];
            session.Update(this.group);
        }
        catch (Exception ex)
        {
            this.error.Text = ex.Message;
        }
    }
}
