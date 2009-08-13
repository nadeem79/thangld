using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Lib1280;

namespace _1280
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            
            //MessageBox.Show(LoginUtility.GetTokenKey("df.thangld@gmail.com", "meocondethuong"));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(LoginUtility.Register("edguuofgduefysewaeirfug", "rtgery@grsd.heae", "hytrtrtyr", "grtytrt").ToString());
        }
    }
}
