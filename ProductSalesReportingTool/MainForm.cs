using ProductSalesReportingTool.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProductSalesReportingTool
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dtpStart_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dtpEnd_ValueChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnGenerateReport_Click(object sender, EventArgs e)
        {
            DateTime startDate = dtpStart.Value.Date;
            DateTime endDate = dtpEnd.Value.Date;

            var service = new DatabaseService();
            var sales = service.GetSales(startDate, endDate);

            if(sales.Count == 0)
            {
                MessageBox.Show("Sale Not Found!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var report = new SaleReport();
            report.SetDataSource(sales);

            new ReportPrintToo(report).ShoePreviewDialog();

        }
    }
}
