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

            if (sales.Count == 0)
            {
                MessageBox.Show("No sales found!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // For debugging purposes, log some information about the data
                System.IO.Directory.CreateDirectory("logs");
                System.IO.File.WriteAllText("logs/report_data.txt",
                    $"Report generated at: {DateTime.Now:yyyy-MM-dd HH:mm:ss}\n" +
                    $"Date range: {startDate:yyyy-MM-dd} to {endDate:yyyy-MM-dd}\n" +
                    $"Number of records: {sales.Count}\n\n" +
                    string.Join("\n", sales.Select(s =>
                        $"{s.SaleDate:yyyy-MM-dd} | {s.ProductCode} | {s.ProductName} | {s.Quantity} | ${s.UnitPrice:0.00} | ${s.Total:0.00}")));

                var report = new AnalystReport.ProductSales();
                report.SetDataSource(sales, startDate, endDate);

                // Show the report preview
                DevExpress.XtraReports.UI.ReportPrintTool printTool = new DevExpress.XtraReports.UI.ReportPrintTool(report);
                printTool.ShowPreviewDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error generating report: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                System.IO.File.AppendAllText("logs/errors.txt", ex.Message + Environment.NewLine);
            }
        }

        private void headText_Click(object sender, EventArgs e)
        {

        }
    }
}
