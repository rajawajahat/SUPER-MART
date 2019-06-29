using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;

using System.Data.SqlClient;

namespace project
{
    public partial class cashiercontrols : Form
    {
       

        public cashiercontrols()
        {
            InitializeComponent();
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }
        class order
        {
            public int pricePerproduct;
            public double Quantity;
            public double priceFull;
            public double Total = 0;
            public double sum = 0;
            public static double sumE = 0;
            public static int qstock = 0;
        }
        private void BILL_ID_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            reterveProductFromDataBase();  
        }
        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            try
            {
                int qty = 0;
                string qstock = "";
                int qStock = 0;
                qty = Convert.ToInt32(textBox5.Text);
                SqlConnection con = new SqlConnection("Data Source=LAPTOP-P2B09MCU\\SQLEXPRESS;Initial Catalog=TESTDB;Integrated Security=True");
                con.Open();
                SqlDataAdapter sd = new SqlDataAdapter("select * from product where productID ='" + textBox2.Text + "'", con);
                DataTable dt = new DataTable();
                sd.Fill(dt);
                qstock = dt.Rows[0][2].ToString();
                //MessageBox.Show(qstock);
                qStock = Convert.ToInt32(qstock);
                if (qStock >= qty)
                {

                    SqlConnection con1 = new SqlConnection(@"Data Source=LAPTOP-P2B09MCU\SQLEXPRESS;Initial Catalog=TESTDB;Integrated Security=True");
                    SqlCommand cmd = new SqlCommand("update product set quantity= quantity-" + qty + " WHERE productID='" + Convert.ToInt32(textBox2.Text) + "'", con1);
                    con1.Open();
                    cmd.ExecuteNonQuery();
                    con1.Close();
                }
                else
                {
                    MessageBox.Show("The product is out of stock ");
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(  ex.Message);
            }

            getfullprice();
        }
        DataTable table = new DataTable();
        private void cashiercontrols_Load(object sender, EventArgs e)
        {
            //panel3.Hide();
            panel2.Hide();
            billingHiding();
            GridViewAdding();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            order oq = new order();
            oq.Total = Convert.ToInt32(textBox6.Text);

            //table.Columns.(oq.Total + oq.Total);
            table.Rows.Add(textBox2.Text, textBox4.Text, textBox3.Text, textBox5.Text, textBox6.Text);
            //table.Rows.Add(textBox6.Text + textBox6.Text);

            dataGridView1.DataSource = table;
            //dataGridView1.Rows[row.Index].Cells[1].Value=(dataGridView1.Rows[row.Index])+(dataGridView1.Rows[row.Index]);
        }

        private void GRAND_Click(object sender, EventArgs e)
        {
            CalGrandTotal();
                       // MessageBox.Show(Convert.ToString(order.sumE));
        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {
            CalRefundAmount();
        }

        private void button2_Click(object sender, EventArgs e)
        {
           getInserted();
           getInserted1();
           autoBillId();
             //dataGridView1.Rows.Clear();
         }       
        private void button3_Click(object sender, EventArgs e)
        {
           /* cry.Load(@"C:\Users\haris ali\Desktop\project - Copy\project\CrystalReport2.rpt");
            SqlConnection con = new SqlConnection(@"Data Source=LAPTOP-P2B09MCU\SQLEXPRESS;Initial Catalog=TESTDB;Integrated Security=True");
            SqlDataAdapter sda = new SqlDataAdapter("RESERVED1", con);
            sda.SelectCommand.CommandType = System.Data.CommandType.StoredProcedure;
            DataSet st = new System.Data.DataSet();
            sda.Fill(st, "DATASS");
            cry.SetDataSource(st);
            crystalReportViewer1.ReportSource = cry;*/
            //new REPORTVIEWER(dateTimePicker1.Value.ToString()).ShowDialog();
            new REPORTVIEWER(dateTimePicker1.Value.ToString()).ShowDialog();
            //cs.Load();
            //cs.Show();
           // MessageBox.Show("CASHIER");
            

        }

        private void pRODUCTINFORMATIONToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //HiddenBillingDetails();
            //panel2.Show();
            billingHiding();
            panel2.Show();
            
        }

        public void HiddenBillingDetails()
        {
            panel1.Hide();dataGridView1.Hide();GRAND.Hide();button2.Hide();
            button3.Hide(); textBox8.Hide(); textBox9.Hide(); textBox7.Hide();
            label6.Hide(); label7.Hide(); label8.Hide();
        }
        public void getInserted()
        {
            SqlConnection con = new SqlConnection(@"Data Source=LAPTOP-P2B09MCU\SQLEXPRESS;Initial Catalog=TESTDB;Integrated Security=True");
            for (int i = 0; i < dataGridView1.RowCount - 1; i++)
            {
                SqlCommand cmd = new SqlCommand(@"INSERT INTO reserved (billId,productId,descript,price,quantity,pricefull,totalAmount,Refund)VALUES('" + textBox1.Text + "','" + dataGridView1.Rows[i].Cells[0].Value + "','" + dataGridView1.Rows[i].Cells[1].Value + "','" + dataGridView1.Rows[i].Cells[2].Value + "' ,'" + dataGridView1.Rows[i].Cells[3].Value + "','" + dataGridView1.Rows[i].Cells[4].Value + "','" + textBox7.Text + "','" + textBox8.Text + "')", con);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

            }
        }
        public void CalRefundAmount()
        {
            order ot = new order();
            //double cat=0;
            //cat=catching(double sum);
            double refund;
            refund = Convert.ToDouble(textBox9.Text);
            // MessageBox.Show(Convert.ToString(order.sumE));
            // refund = Convert.ToDouble(textBox9.Text);
            refund = refund - order.sumE;

            textBox8.Text = Convert.ToString(refund);
        }
        public void CalGrandTotal()
        {
            //int sum=0;
            int i;
            // double sumE;

            order ot = new order();
            for (i = 0; i < dataGridView1.Rows.Count; ++i)
            {
                ot.sum += Convert.ToInt32(dataGridView1.Rows[i].Cells[4].Value);
            }
            //ot.sumE = ot.sum;
            // MessageBox.Show(Convert.ToString(ot.sumE));
            //catching(ot.sum);

            textBox7.Text = Convert.ToString(ot.sum);
            order.sumE = Convert.ToDouble(textBox7.Text);

        }
        public void getfullprice()
        {
            try
            {
                order od = new order();
                od.Quantity = Convert.ToDouble(textBox5.Text);
                od.pricePerproduct = Convert.ToInt32(textBox3.Text);
                od.priceFull = od.Quantity * od.pricePerproduct;
                textBox6.Text = Convert.ToString(od.priceFull);
            }
            catch (Exception ex)
            {
                Console.WriteLine("error" + ex.Message);
            }
        }
        public void reterveProductFromDataBase()
        {
            try
            {
                SqlConnection con = new SqlConnection("Data Source=LAPTOP-P2B09MCU\\SQLEXPRESS;Initial Catalog=TESTDB;Integrated Security=True");
                con.Open();
                SqlDataAdapter sd = new SqlDataAdapter("select * from product where productID ='" + textBox2.Text + "'", con);
                DataTable dt = new DataTable();
                sd.Fill(dt);
                textBox4.Text = dt.Rows[0][1].ToString();
                textBox3.Text = dt.Rows[0][3].ToString();
                con.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("error: " + ex.Message);
            }
        }
        public void autoBillId()
        {
            int q = Convert.ToInt32(textBox1.Text);
            q++;
            textBox1.Text = Convert.ToString(q);
        }
        public void GridViewAdding()
        {
            table.Columns.Add("productID", typeof(int));
            table.Columns.Add("DESCRIPTION", typeof(string));
            table.Columns.Add("PRICEPERPRODUCT", typeof(string));
            table.Columns.Add("QUANTITY", typeof(int));
            table.Columns.Add("PRICEFULL", typeof(int));
            dataGridView1.DataSource = table;
        }
        public void getInserted1()
        {
            SqlConnection con = new SqlConnection(@"Data Source=LAPTOP-P2B09MCU\SQLEXPRESS;Initial Catalog=TESTDB;Integrated Security=True");
            for (int i = 0; i < dataGridView1.RowCount - 1; i++)
            {
                SqlCommand cmd = new SqlCommand(@"INSERT INTO salesperday (productId,descrip,price,quantity,pricefull,datetime)VALUES('" + dataGridView1.Rows[i].Cells[0].Value + "','" + dataGridView1.Rows[i].Cells[1].Value + "','" + dataGridView1.Rows[i].Cells[2].Value + "' ,'" + dataGridView1.Rows[i].Cells[3].Value + "','" + dataGridView1.Rows[i].Cells[4].Value + "','" + dateTimePicker1.Value.ToString() + "')", con);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

            }
        }
        public void billingHiding()
        {
            panel1.Hide();
            dataGridView1.Hide();
            button2.Hide();
            button3.Hide();
            GRAND.Hide();
            textBox7.Hide();
            textBox9.Hide();
            textBox8.Hide();
            label6.Hide();
            label8.Hide();
            label7.Hide();
        }
        public void billingShowing()
        {
            panel1.Show();
            dataGridView1.Show();
            button2.Show();
            button3.Show();
            GRAND.Show();
            textBox7.Show();
            textBox9.Show();
            textBox8.Show();
            label6.Show();
            label8.Show();
            label7.Show();
        }
     
        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }
        //SECOND OPTION PRODUCT INFORMATION
        private void button4_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection("Data Source=LAPTOP-P2B09MCU\\SQLEXPRESS;Initial Catalog=TESTDB;Integrated Security=True"))
            {
                con.Open();
                SqlDataAdapter sda = new SqlDataAdapter("Select * from product where descrip='" + textBox10.Text + "'", con);
                DataTable da = new DataTable();
                sda.Fill(da);
                dataGridView2.DataSource = da;

            }

        }
        //EXIT APPLICATION OPTION
        private void eXITAPPLICATIONToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show("are you sure you want to exit ?", "EXIT", MessageBoxButtons.YesNo);
            if(dialog== DialogResult.Yes)
            {
                DialogResult dialog1=MessageBox.Show("BEFORE GOINT OUT FROM THIS APPLICATION WOULD YOU LIKE TO KNOW THE SKILLS AND FORMATION PROCESS OF THIS PROJECT?","EXIT",MessageBoxButtons.YesNo);
                if (dialog1 == DialogResult.Yes)
                {
                    FEEDBACK fb = new FEEDBACK();
                    fb.Show();
                }
                else
                {
                    Application.Exit();
                }
            }
            else
            {
                return;
            }
           // MessageBox.Show("ARE YOU SURE YOU WANT TO EXIT APPLICATION");
            
        }
        class qh { 
            public int qtyValue = 0;}

        private void bILLINGToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel2.Hide();
            billingShowing();
            //panel3.Hide();
           
        }

        private void lOGOUTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1 CS = new Form1();
            CS.Show();
        }

        }

    }

