using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class CustomControls_SendResource : System.Web.UI.UserControl
{

    public NHibernate.ISession Session
    {
        get;
        set;
    }
    public beans.Village Village
    {
        get;
        set;
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        this.lblAvailableMerchant.Text = this.Village.MerchantAvailable(this.Session).ToString();
    }

    protected void bttnSend_Click(object sender, EventArgs e)
    {
        int clay = 0, wood = 0, iron = 0, x = 0, y = 0;

        int.TryParse(this.txtClay.Text, out clay);
        int.TryParse(this.txtWood.Text, out wood);
        int.TryParse(this.txtIron.Text, out iron);

        if (!(int.TryParse(this.txtX.Text, out x) && int.TryParse(this.txtY.Text, out y)))
        {
            ScriptManager.RegisterStartupScript(bttnSend, bttnSend.GetType(), "ShowException", "jQuery.facebox('Nhập toạ độ thành phố');", true);
            return;
        }

        if ((clay + wood + iron) <= 0 || wood < 0 || clay < 0 || iron < 0)
        {
            ScriptManager.RegisterStartupScript(bttnSend, bttnSend.GetType(), "ShowException", "jQuery.facebox('Nhập tài nguyên');", true);
            return;
        }

        int village_id = beans.Village.CheckVillage(x, y, this.Session);

        if (village_id <= 0)
        {
            ScriptManager.RegisterStartupScript(bttnSend, bttnSend.GetType(), "ShowException", String.Format("jQuery.facebox('Thành phố không tồn tại ở toạ độ ({0}|{1})');", x.ToString("000"), y.ToString("000")), true);
            return;
        }

        
        
    }
}
