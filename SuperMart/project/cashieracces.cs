using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace project
{
    public partial class cashieracces : Form
    {
        public cashieracces()
        {
            InitializeComponent();
        }

        private void loginbutton_Click(object sender, EventArgs e)
        {
            CashierLogIn();
        }

        private void cashieracces_Load(object sender, EventArgs e)
        {

        }
        public void CashierLogIn()
        {
            cashier cs = new cashier();
            if (cs.user == username.Text && cs.pass == password.Text)
            {
                cashiercontrols cc = new cashiercontrols();
                cc.Show();
            }
            else
            {
                MessageBox.Show("AccessDenied");
            }

        }

        private void username_TextChanged(object sender, EventArgs e)
        {

        }
    }
    class cashier
    {
        public string user = "cashier1";
        public string pass = "456";
    }
}
