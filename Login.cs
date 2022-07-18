using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Library_Management_System
{
    public partial class Form1 : Form
    {
        Admin admin = new Admin();
        public Form1()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string passwd = "admin";
            string username = "admin";
            if(passwd == txtPasswword.Text && username == txtUsername.Text)
            {
                admin.ShowDialog();
            }
            this.btnCancel_Click(this, null);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            txtUsername.Clear();
            txtPasswword.Clear();
        }
    }
}
