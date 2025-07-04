using DevExpress.XtraReports.UI;
using ProductSalesReportingTool.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;

namespace ProductSalesReportingTool.AnalystReport
{
    public partial class ProductSales : DevExpress.XtraReports.UI.XtraReport
    {
        public XRLabel lblDateRange;

        public ProductSales()
        {
            InitializeComponent();

            ReportHeaderBand reportHeader = FindBand(typeof(ReportHeaderBand)) as ReportHeaderBand;
            if (reportHeader == null)
            {
                reportHeader = new ReportHeaderBand();
                this.Bands.Add(reportHeader);
                reportHeader.HeightF = 100;
            }

            // Find Unicode-friendly font for Khmer support
            string unicodeFontName = FindUnicodeFontForKhmer();

            // title label 
            if (reportHeader.Controls.Count == 0)
            {
                XRLabel titleLabel = new XRLabel();
                titleLabel.Text = "Product Sales Report";
                titleLabel.Font = new DevExpress.Drawing.DXFont(unicodeFontName, 16F, (DevExpress.Drawing.DXFontStyle)FontStyle.Bold);
                titleLabel.LocationF = new DevExpress.Utils.PointFloat(0, 10);
                titleLabel.SizeF = new System.Drawing.SizeF(650, 30);
                titleLabel.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
                reportHeader.Controls.Add(titleLabel);
            }

            // Add date range label
            lblDateRange = new XRLabel();
            lblDateRange.Text = "Date Range: ";
            lblDateRange.Font = new DevExpress.Drawing.DXFont(unicodeFontName, 10F, (float)FontStyle.Regular);
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

                if (lblDateRange != null)
                {
                    lblDateRange.Text = $"Date Range: {startDate:yyyy-MM-dd} to {endDate:yyyy-MM-dd}";
                }
                if (GroupHeader1 != null)
                {
                    GroupHeader1.GroupFields.Clear();
                    GroupHeader1.GroupFields.Add(new GroupField("ProductCode"));
                }

                // Apply Unicode font to all text elements in the report
                ApplyUnicodeFontsToReport();

                // Set date format
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

        // Method to find an appropriate Unicode font for Khmer support
        private string FindUnicodeFontForKhmer()
        {
            string[] preferredFonts = {
                "Khmer OS",
                "Khmer OS System",
                "Khmer OS Content",
                "Noto Sans Khmer",
                "Arial Unicode MS",
                "Segoe UI",
                "Microsoft Sans Serif",  
                "Arial"                  
            };

            // Get installed fonts
            using (InstalledFontCollection fonts = new InstalledFontCollection())
            {
                foreach (string fontName in preferredFonts)
                {
                    if (IsFontInstalled(fontName, fonts))
                    {
                        return fontName;
                    }
                }
            }

            // no fonts found, return a default system font
            return "Microsoft Sans Serif";
        }

        // Check if a font is installed
        private bool IsFontInstalled(string fontName, InstalledFontCollection fonts)
        {
            foreach (FontFamily family in fonts.Families)
            {
                if (family.Name.Equals(fontName, StringComparison.OrdinalIgnoreCase))
                {
                    return true;
                }
            }
            return false;
        }

        // Apply Unicode fonts to all text elements in the report
        private void ApplyUnicodeFontsToReport()
        {
            try
            {
                string unicodeFontName = FindUnicodeFontForKhmer();

                foreach (Band band in this.Bands)
                {
                    ApplyUnicodeFontToBandControls(band, unicodeFontName);
                }

                // Log the font being used
                System.IO.Directory.CreateDirectory("logs");
                System.IO.File.AppendAllText("logs/report_info.txt",
                    $"Using font for Unicode/Khmer support: {unicodeFontName}\r\n");
            }
            catch (Exception ex)
            {
                System.IO.Directory.CreateDirectory("logs");
                System.IO.File.AppendAllText("logs/errors.txt",
                    $"Error applying Unicode fonts: {ex.Message}\r\n{ex.StackTrace}\r\n");
            }
        }

        // Apply Unicode font to all controls in a band
        private void ApplyUnicodeFontToBandControls(Band band, string fontName)
        {
            foreach (XRControl control in band.Controls)
            {
                if (control is XRLabel label)
                {
                    try
                    {
                        float size = label.Font.Size;
                        FontStyle style = (FontStyle)label.Font.Style;
                        label.Font = new DevExpress.Drawing.DXFont(fontName, size, (DevExpress.Drawing.DXFontStyle)style);
                    }
                    catch (Exception ex)
                    {
                        // Fallback to a safe font if there's an issue
                        label.Font = new DevExpress.Drawing.DXFont("Microsoft Sans Serif", label.Font.Size);
                        System.IO.File.AppendAllText("logs/errors.txt",
                            $"Error applying font to label: {ex.Message}\r\n");
                    }
                }
                else if (control is XRTable table)
                {
                    foreach (XRTableRow row in table.Rows)
                    {
                        foreach (XRTableCell cell in row.Cells)
                        {
                            try
                            {
                                // Use DevExpress's font handling for table cells too
                                float size = cell.Font.Size;
                                FontStyle style = (FontStyle)cell.Font.Style;
                                cell.Font = new DevExpress.Drawing.DXFont(fontName, size, (DevExpress.Drawing.DXFontStyle)style);
                            }
                            catch (Exception ex)
                            {
                                // Fallback to a safe font if there's an issue
                                cell.Font = new DevExpress.Drawing.DXFont("Microsoft Sans Serif", cell.Font.Size);
                                System.IO.File.AppendAllText("logs/errors.txt",
                                    $"Error applying font to cell: {ex.Message}\r\n");
                            }
                        }
                    }
                }
            }
        }
    }
}