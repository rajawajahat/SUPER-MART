using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace project
{
    public partial class admincontrols : Form
    {
        public admincontrols()
        {
            InitializeComponent();
        }

        private void aDDCASHIERDETAILSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //label16.Show();
            //textBox15.Show();
            panel2.Hide();
            panel3.Hide();
            panel6.Hide();
            panel1.Show();
            
        }

        private void admincontrols_Load(object sender, EventArgs e)
        {
            panel2.Hide();
            panel3.Hide();
            panel5.Hide();
            panel6.Hide();

            panel1.Hide();

            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            EnterCashierDetails();
        }

        private void vIEWCASHIERINFOToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel1.Hide();
            panel2.Hide();
            panel6.Hide();
            panel3.Show();
                   
        }

        private void aDDPRODUCTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //label16.Hide();
            //textBox15.Hide();
            //textBox4.Hide();
            panel1.Hide();
                       panel3.Hide();
                       panel6.Hide();
                       panel2.Show();
                       //panel1.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SearchCashierDetail();
        }

        private void PRODUCTBUTTON_Click(object sender, EventArgs e)
        {
            EnterProductDetails();
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void sALESPERDAYToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel6.Show();
            panel1.Hide();
            panel2.Hide();
            panel3.Hide();
            panel5.Show();
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
           
        }

        private void button4_Click(object sender, EventArgs e)
        {
            TotalSales();
                        //totalSum = Convert.ToInt32(textBox7.Text);
        }
        public void SalesPerDay()
        {
            using (SqlConnection con = new SqlConnection("Data Source=LAPTOP-P2B09MCU\\SQLEXPRESS;Initial Catalog=TESTDB;Integrated Security=True"))
            {
                con.Open();
                SqlDataAdapter sda = new SqlDataAdapter("Select * from salesperday where CAST(datetime AS Date) ='" + dateTimePicker2.Value.ToString()/*textBox9.Text*/ + "'", con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                dataGridView2.DataSource = dt;

            }
        }
        public void TotalSales()
        {
            int i;
            // double sumE;

            // order ot = new order();
            int totalSum = 0;
            for (i = 0; i < dataGridView2.Rows.Count; ++i)
            {
                totalSum += Convert.ToInt32(dataGridView2.Rows[i].Cells[4].Value);
            }
            //ot.sumE = ot.sum;
            // MessageBox.Show(Convert.ToString(ot.sumE));
            //catching(ot.sum);

            textBox9.Text = Convert.ToString(totalSum);

        }
        public void SearchCashierDetail()
        {
            SqlConnection con = new SqlConnection("Data Source=LAPTOP-P2B09MCU\\SQLEXPRESS;Initial Catalog=TESTDB;Integrated Security=True");
            SqlDataAdapter da = new SqlDataAdapter("Select * from cashier1 where ID='" + textBox10.Text + "'", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            textBox10.Text = dt.Rows[0][0].ToString();
            textBox11.Text = dt.Rows[0][1].ToString();
            textBox12.Text = dt.Rows[0][2].ToString();
            textBox13.Text = dt.Rows[0][3].ToString();
            textBox14.Text = dt.Rows[0][4].ToString();
        }
        public void EnterProductDetails()
        {
            SqlConnection con = new SqlConnection("Data Source=LAPTOP-P2B09MCU\\SQLEXPRESS;Initial Catalog=TESTDB;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "insert into product values('" + textBox8.Text + "','" + textBox7.Text + "','" + textBox6.Text + "','" + textBox5.Text + "')";
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public void EnterCashierDetails()
        {
            SqlConnection con = new SqlConnection("Data Source=LAPTOP-P2B09MCU\\SQLEXPRESS;Initial Catalog=TESTDB;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "insert into cashier1 values('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox15.Text + "','" + textBox3.Text + "','" + textBox4.Text + "')";
            cmd.ExecuteNonQuery();
            con.Close();
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            SalesPerDay();
        }

        private void eXITAPPLICATIONToolStripMenuItem_Click(object sender, EventArgs e)
        {
            admincontrols ac = new admincontrols();
            ac.Hide();
            Form1 al = new Form1();
            al.Show();
        }

        private void eXITAPPLICATIONToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }
            
        }
    }

