using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace project
{
    public partial class FEEDBACK : Form
    {
        public FEEDBACK()
        {
            InitializeComponent();
        }

        private void FEEDBACK_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            ReviewSubmission();
        }
        public void ReviewSubmission()
        {
            string add = "test_File.txt";
            StreamWriter sw = new StreamWriter(add);
            sw.WriteLine(label6.Text + "" + textBox1.Text);
            sw.WriteLine(label8.Text + "" + textBox3.Text);
            sw.WriteLine(label7.Text + "" + textBox2.Text);
            sw.Close();
            MessageBox.Show("WE WILL SURELY LOOK YOU REVIEW  APPLICATION IS CLOSING NOW");
            Application.Exit();
        }
    }
}
