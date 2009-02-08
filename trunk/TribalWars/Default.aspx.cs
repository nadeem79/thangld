using System;
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
using System.IO;
using System.Collections;

public partial class _Default : System.Web.UI.Page 
{
    int i = 0;
    void a()
    {
        string[] info = File.ReadAllLines(@"d:\village.txt");
        Hashtable ht = new Hashtable();

        foreach (string tmp in info)
        {
            char[] pattern = { ',' };
            string[] arr = tmp.Split(pattern);
            ht.Add(arr[2] + "|" + arr[3], arr[0]);
        }

        char[] pattern2 = { ' ' };

        string[] villages = "494|769 494|772 492|766 485|761 490|765 481|770 498|777 501|779 498|784 508|771 510|775 509|774 509|777 510|778 513|784 508|782 508|783 509|785 517|784 520|784 504|798 500|797 509|797 498|795 499|792 497|795 502|801 498|803 501|771 498|766 498|772".Split(pattern2);
        string id_list = "";
        foreach (string tmp in villages)
            if (ht.ContainsKey(tmp))
                id_list += ht[tmp] + " ";

        this.Label1.Text = id_list;
    }
    
    protected void Page_Load(object sender, EventArgs e)
    {
        
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        this.i++;
        this.Label1.Text = this.i.ToString();
    }
}

