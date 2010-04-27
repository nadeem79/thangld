using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

public partial class confirm_attack : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        FileStream fileStream = new FileStream(Server.MapPath("~/abc.txt"), FileMode.Append, FileAccess.Write);

        StreamWriter writer = new StreamWriter(fileStream, System.Text.Encoding.UTF8);

        writer.Write(DateTime.Now.ToString("dd/MM/yyyy hh:mm - "));

        writer.Write("ghrdgr");

        writer.Close();
        fileStream.Close();
    }
}
