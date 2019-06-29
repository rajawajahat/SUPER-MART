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
//ReportDocument cry = new ReportDocument();
using System.Data.SqlClient;
namespace project
{
    public partial class REPORTVIEWER : Form
    {
        ReportDocument cry = new ReportDocument();
        //ReportDocument cry = new ReportDocument();
        private string p;
      /*  public REPORTVIEWER()
        {
            InitializeComponent();
        }*/

        public REPORTVIEWER(string p)
        {
            // TODO: Complete member initialization
            this.p = p;
            InitializeComponent();
        }

        private void REPORTVIEWER_Load(object sender, EventArgs e)
        {
            //MessageBox.Show("REPORT");
            MessageBox.Show(p);
            CrystalReport2 ob = new CrystalReport2();
            ob.SetParameterValue("DATETIME", p);
            crystalReportViewer1.ReportSource = ob;
           // crystalReportViewer1.Refresh();
            GetInserted();

                       

        }
        public void GetInserted()
        {
            cry.Load(@"C:\Users\haris ali\Desktop\project - Copy\project\CrystalReport2.rpt");
            SqlConnection con = new SqlConnection(@"Data Source=LAPTOP-P2B09MCU\SQLEXPRESS;Initial Catalog=TESTDB;Integrated Security=True");
            SqlDataAdapter sda = new SqlDataAdapter("RESERVED1", con);
            
            sda.SelectCommand.CommandType = System.Data.CommandType.StoredProcedure;
            sda.SelectCommand.Parameters.Add("@billid", System.Data.SqlDbType.Int).Value = 1;
            DataSet st = new System.Data.DataSet();
            sda.Fill(st, "DATASS");
            cry.SetDataSource(st);
            crystalReportViewer1.ReportSource = cry;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            cry.Load(@"C:\Users\haris ali\Desktop\project - Copy\project\CrystalReport2.rpt");
            SqlConnection con = new SqlConnection(@"Data Source=LAPTOP-P2B09MCU\SQLEXPRESS;Initial Catalog=TESTDB;Integrated Security=True");
            SqlDataAdapter sda = new SqlDataAdapter("RESERVED1", con);

            sda.SelectCommand.CommandType = System.Data.CommandType.StoredProcedure;
            sda.SelectCommand.Parameters.Add("@billid", System.Data.SqlDbType.Int).Value = textBox1.Text;
            DataSet st = new System.Data.DataSet();
            sda.Fill(st, "DATASS");
            cry.SetDataSource(st);
            crystalReportViewer1.ReportSource = cry;

        }
    }
}
