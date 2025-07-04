using DevExpress.XtraReports.UI;
using ProductSalesReportingTool.Models; // Add this import
using System;
using System.Collections;
using System.Collections.Generic; // Add this import
using System.ComponentModel;
using System.Drawing;
using System.Linq;

namespace ProductSalesReportingTool.AnalystReport
{
    public partial class ProductSales : DevExpress.XtraReports.UI.XtraReport
    {
        public XRLabel lblDateRange;

        public ProductSales()
        {
            InitializeComponent();

            // Find or create a report header if it doesn't exist
            ReportHeaderBand reportHeader = FindBand(typeof(ReportHeaderBand)) as ReportHeaderBand;
            if (reportHeader == null)
            {
                reportHeader = new ReportHeaderBand();
                this.Bands.Add(reportHeader);
                reportHeader.HeightF = 100;
            }

            // Add title label if needed
            if (reportHeader.Controls.Count == 0)
            {
                XRLabel titleLabel = new XRLabel();
                titleLabel.Text = "Product Sales Report";
                titleLabel.Font = new Font("Arial", 16F, FontStyle.Bold);
                titleLabel.LocationF = new DevExpress.Utils.PointFloat(0, 10);
                titleLabel.SizeF = new System.Drawing.SizeF(650, 30);
                titleLabel.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
                reportHeader.Controls.Add(titleLabel);
            }

            // Add date range label
            lblDateRange = new XRLabel();
            lblDateRange.Text = "Date Range: ";
            lblDateRange.Font = new Font("Arial", 10F, FontStyle.Regular);
            lblDateRange.LocationF = new DevExpress.Utils.PointFloat(0, 50);
            lblDateRange.SizeF = new System.Drawing.SizeF(650, 23);
            lblDateRange.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            reportHeader.Controls.Add(lblDateRange);
        }

        // Add this method to set the data source
        public void SetDataSource(List<SaleDto> sales, DateTime startDate, DateTime endDate)
        {
            try
            {
                var groupedSales = sales.OrderBy(s => s.ProductCode).ToList();
                // Set the data source
                this.DataSource = sales;
                this.DataMember = "";

                // Set the date range text with updated format dd/MM/yyyy
                if (lblDateRange != null)
                {
                    lblDateRange.Text = $"Date Range: {startDate:yyyy-MM-dd} to {endDate:yyyy-MM-dd}";
                }
                if (GroupHeader1 != null)
                {
                    // Clear any existing group fields
                    GroupHeader1.GroupFields.Clear();

                    // Add ProductCode as the group field
                    GroupHeader1.GroupFields.Add(new GroupField("ProductCode"));
                }
                // Find the date column in the detail band and update its format
                foreach (var control in Detail.Controls)
                {
                    if (control is XRTableCell cell && cell.ExpressionBindings.Any(e => e.PropertyName == "Text" && e.Expression.Contains("SaleDate")))
                    {
                        cell.TextFormatString = "{0:yyyy-MM-dd}";
                    }
                }

                // Create the document
                this.CreateDocument();
            }
            catch (Exception ex)
            {
                System.IO.Directory.CreateDirectory("logs");
                System.IO.File.AppendAllText("logs/errors.txt",
                    $"Error in SetDataSource: {ex.Message}\r\n{ex.StackTrace}\r\n");
                throw;
            }
        }

        // Helper method to find a band by type
        private Band FindBand(Type bandType)
        {
            foreach (Band band in this.Bands)
            {
                if (band.GetType() == bandType)
                    return band;
            }
            return null;
        }
    }
}