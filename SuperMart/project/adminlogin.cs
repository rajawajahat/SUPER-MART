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
    public partial class adminlogin : Form
    {
        public adminlogin()
        {
            InitializeComponent();
        }

        private void adminlogin_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            MANAGER M = new MANAGER();
            if (textBox1.Text==M.username && textBox2.Text==M.password)
            {
                admincontrols ac = new admincontrols();
                ac.Show();
             

            }
            else
            {
                MessageBox.Show("ACCESS DENIED");    
            }
            
            
        }
        class MANAGER
        {
            public string username="manager1";
            public string password="123";

           /* public string USERNAME
            {
                get
                {
                    return username;

                }
                set
                {
                    username = value;
                }
            }

                       */

        }
   
    }
}
