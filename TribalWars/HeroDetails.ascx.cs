using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NHibernate;
using beans;
using System.Collections;
using System.IO;

public partial class HeroDetails : System.Web.UI.UserControl
{
    public beans.Village Village
    {
        get;
        set;
    }
    protected beans.Hero Hero
    {
        get;
        set;
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        ISession session = (ISession)Context.Items[Constant.NHibernateSessionSign];

        int heroId = 0;
        if (!int.TryParse(Request["hero"], out heroId))
        {
            this.pHeroNotFound.Visible = true;
            this.pHeroDetais.Visible = false;
            return;
        }

        this.Hero = session.Get<Hero>(heroId);
        if (this.Hero == null || this.Hero.Owner.ID != (int)Session[Constant.NormalUserSessionSign])
        {
            this.pHeroNotFound.Visible = true;
            this.pHeroDetais.Visible = false;
            return;
        }

        this.pHeroDetais.Visible = true;
        this.pHeroNotFound.Visible = false;

        this.aDeleteAvatar.Visible = this.Hero.Avatar;
        this.txtName.Text = this.Hero.Name;
        this.txtPersonalText.Text = this.Hero.Biography;
    }

    protected void bttnChangePlayerProfile_Click(object sender, EventArgs e)
    {
        ISession session = (ISession)Context.Items[Constant.NHibernateSessionSign];
        this.Hero.Biography = this.txtPersonalText.Text;

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
                if (!Functions.UploadImage(fileAvatar.FileContent, Server.MapPath("~/data/images/heroes/") + this.Hero.ID.ToString() + ".jpg"))
                    this.lblAvatarError.Text = "Có lỗi khi upload ảnh. Vui lòng thử lại sau vài phút";
                else
                {
                    this.Hero.Avatar = true;
                    this.aDeleteAvatar.Visible = true;
                }
            }
        }

        session.Update(this.Hero);
    }

    protected void aDeleteAvatar_Click(object sender, EventArgs e)
    {
        ISession session = (ISession)Context.Items[Constant.NHibernateSessionSign];
        this.Hero.Avatar = false;
        if (File.Exists(Server.MapPath("~/data/images/heroes/") + this.Hero.ID.ToString() + ".jpg"))
            File.Delete(Server.MapPath("~/data/images/heroes/") + this.Hero.ID.ToString() + ".jpg");
        session.Update(this.Hero);
        this.aDeleteAvatar.Visible = false;
    }
}
