namespace ProductSalesReportingTool
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dtpStart = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpEnd = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.btnGenerateReport = new System.Windows.Forms.Button();
            this.headText = new System.Windows.Forms.Label();
            this.btnExportPdf = new System.Windows.Forms.Button();
            this.txtProductFilter = new System.Windows.Forms.TextBox();
            this.lblProductFilter = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // dtpStart
            // 
            this.dtpStart.CalendarTrailingForeColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.dtpStart.CustomFormat = "yyyy-MM-dd";
            this.dtpStart.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpStart.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpStart.Location = new System.Drawing.Point(369, 108);
            this.dtpStart.Name = "dtpStart";
            this.dtpStart.Size = new System.Drawing.Size(221, 25);
            this.dtpStart.TabIndex = 0;
            this.dtpStart.ValueChanged += new System.EventHandler(this.dtpStart_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(239, 108);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 23);
            this.label1.TabIndex = 1;
            this.label1.Text = "Start Date";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // dtpEnd
            // 
            this.dtpEnd.CustomFormat = "yyyy-MM-dd";
            this.dtpEnd.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpEnd.Location = new System.Drawing.Point(369, 160);
            this.dtpEnd.Name = "dtpEnd";
            this.dtpEnd.Size = new System.Drawing.Size(221, 25);
            this.dtpEnd.TabIndex = 2;
            this.dtpEnd.ValueChanged += new System.EventHandler(this.dtpEnd_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(239, 162);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 23);
            this.label2.TabIndex = 3;
            this.label2.Text = "End Date";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnGenerateReport
            // 
            this.btnGenerateReport.BackColor = System.Drawing.Color.LimeGreen;
            this.btnGenerateReport.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGenerateReport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGenerateReport.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGenerateReport.ForeColor = System.Drawing.Color.White;
            this.btnGenerateReport.Location = new System.Drawing.Point(309, 258);
            this.btnGenerateReport.Name = "btnGenerateReport";
            this.btnGenerateReport.Size = new System.Drawing.Size(246, 44);
            this.btnGenerateReport.TabIndex = 4;
            this.btnGenerateReport.Text = "Generate Report";
            this.btnGenerateReport.UseVisualStyleBackColor = false;
            this.btnGenerateReport.Click += new System.EventHandler(this.btnGenerateReport_Click);
            // 
            // headText
            // 
            this.headText.AutoSize = true;
            this.headText.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.headText.ForeColor = System.Drawing.SystemColors.MenuText;
            this.headText.Location = new System.Drawing.Point(257, 38);
            this.headText.Name = "headText";
            this.headText.Size = new System.Drawing.Size(356, 32);
            this.headText.TabIndex = 5;
            this.headText.Text = "Here is the Sales Report Tool";
            this.headText.Click += new System.EventHandler(this.headText_Click);
            // 
            // btnExportPdf
            // 
            this.btnExportPdf.BackColor = System.Drawing.Color.LightCoral;
            this.btnExportPdf.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExportPdf.ForeColor = System.Drawing.Color.White;
            this.btnExportPdf.Location = new System.Drawing.Point(309, 319);
            this.btnExportPdf.Name = "btnExportPdf";
            this.btnExportPdf.Size = new System.Drawing.Size(246, 44);
            this.btnExportPdf.TabIndex = 6;
            this.btnExportPdf.Text = "Export PDF ";
            this.btnExportPdf.UseVisualStyleBackColor = false;
            this.btnExportPdf.Click += new System.EventHandler(this.btnExportPdf_Click);
            // 
            // txtProductFilter
            // 
            this.txtProductFilter.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtProductFilter.Location = new System.Drawing.Point(369, 207);
            this.txtProductFilter.Name = "txtProductFilter";
            this.txtProductFilter.Size = new System.Drawing.Size(221, 25);
            this.txtProductFilter.TabIndex = 6;
            // 
            // lblProductFilter
            // 
            this.lblProductFilter.AutoSize = true;
            this.lblProductFilter.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProductFilter.ForeColor = System.Drawing.Color.Transparent;
            this.lblProductFilter.Location = new System.Drawing.Point(239, 207);
            this.lblProductFilter.Name = "lblProductFilter";
            this.lblProductFilter.Size = new System.Drawing.Size(127, 23);
            this.lblProductFilter.TabIndex = 7;
            this.lblProductFilter.Text = "Product Filter";
            this.lblProductFilter.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Highlight;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblProductFilter);
            this.Controls.Add(this.txtProductFilter);
            this.Controls.Add(this.btnExportPdf);
            this.Controls.Add(this.headText);
            this.Controls.Add(this.btnGenerateReport);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dtpEnd);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dtpStart);
            this.ForeColor = System.Drawing.SystemColors.Highlight;
            this.Name = "MainForm";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dtpStart;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpEnd;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnGenerateReport;
        private System.Windows.Forms.Label headText;
        private System.Windows.Forms.Button btnExportPdf;
        private System.Windows.Forms.TextBox txtProductFilter;
        private System.Windows.Forms.Label lblProductFilter;
    }
}

