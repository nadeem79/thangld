using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Lib1280;
using System.Web;

namespace _1280
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void registerButton_Click(object sender, EventArgs e)
        {
            LoginUtility.Register(this.nicknameTextBox.Text, this.emailTextBox.Text, this.nameTextBox.Text, this.passwordTextBox.Text);
            MessageBox.Show("Đăng ký thành công");
        }

        private void getTokenKeyTextBox_Click(object sender, EventArgs e)
        {
            MessageBox.Show(LoginUtility.GetTokenKey(this.emailTextBox.Text, this.passwordTextBox.Text));
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
