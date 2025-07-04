using ProductSalesReportingTool.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ProductSalesReportingTool
{
    public partial class MainForm : Form
    {
        // Add this field declaration at the class level to store the current report
        private AnalystReport.ProductSales currentReport;

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
            string productFilter = txtProductFilter.Text.Trim();

            var service = new DatabaseService();
            var sales = service.GetSales(startDate, endDate);

            if (sales.Count == 0)
            {
                MessageBox.Show("No sales found!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            // Apply product filter if provided
            if (!string.IsNullOrEmpty(productFilter))
            {
                sales = sales.Where(s =>
                    s.ProductName.IndexOf(productFilter, StringComparison.OrdinalIgnoreCase) >= 0 ||
                    s.ProductCode.IndexOf(productFilter, StringComparison.OrdinalIgnoreCase) >= 0
                ).ToList();

                if (sales.Count == 0)
                {
                    MessageBox.Show($"No sales found matching filter: '{productFilter}'", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
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

                // Store the report in the class-level variable for later use
                currentReport = new AnalystReport.ProductSales();
                currentReport.SetDataSource(sales, startDate, endDate);

                // Show the report preview
                DevExpress.XtraReports.UI.ReportPrintTool printTool = new DevExpress.XtraReports.UI.ReportPrintTool(currentReport);
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

        private void btnExportPdf_Click(object sender, EventArgs e)
        {
            try
            {
                if (currentReport == null)
                {
                    MessageBox.Show("Please generate a report first.", "No Report Available",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                SaveFileDialog saveFileDialog = new SaveFileDialog
                {
                    Filter = "PDF files (*.pdf)|*.pdf",
                    Title = "Export Report to PDF",
                    FileName = $"SalesReport_{DateTime.Now:yyyyMMdd}",
                    DefaultExt = "pdf"
                };

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // Export the report to PDF
                    currentReport.ExportToPdf(saveFileDialog.FileName);

                    MessageBox.Show($"Report successfully exported to:\n{saveFileDialog.FileName}",
                        "Export Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Optional: Open the PDF after export
                    if (MessageBox.Show("Do you want to open the exported PDF?", "Open File",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        System.Diagnostics.Process.Start(saveFileDialog.FileName);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error exporting PDF: {ex.Message}", "Export Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                // Log the error
                Directory.CreateDirectory("logs");
                File.AppendAllText("logs/errors.txt",
                    $"PDF Export Error: {DateTime.Now}\r\n{ex.Message}\r\n{ex.StackTrace}\r\n\r\n");
            }
        }
    }
}