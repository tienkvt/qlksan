namespace QuanLyKhachSan._2._1
{
    partial class BaoCaoKH
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
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.QLKSDataSet = new QuanLyKhachSan._2._1.QLKSDataSet();
            this.KHACH_HANGBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.KHACH_HANGTableAdapter = new QuanLyKhachSan._2._1.QLKSDataSetTableAdapters.KHACH_HANGTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.QLKSDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.KHACH_HANGBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.KHACH_HANGBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "QuanLyKhachSan._2._1.KhachHang.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(719, 494);
            this.reportViewer1.TabIndex = 0;
            // 
            // QLKSDataSet
            // 
            this.QLKSDataSet.DataSetName = "QLKSDataSet";
            this.QLKSDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // KHACH_HANGBindingSource
            // 
            this.KHACH_HANGBindingSource.DataMember = "KHACH_HANG";
            this.KHACH_HANGBindingSource.DataSource = this.QLKSDataSet;
            // 
            // KHACH_HANGTableAdapter
            // 
            this.KHACH_HANGTableAdapter.ClearBeforeFill = true;
            // 
            // BaoCaoKH
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(719, 494);
            this.Controls.Add(this.reportViewer1);
            this.Name = "BaoCaoKH";
            this.Text = "BaoCaoKH";
            this.Load += new System.EventHandler(this.BaoCaoKH_Load);
            ((System.ComponentModel.ISupportInitialize)(this.QLKSDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.KHACH_HANGBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource KHACH_HANGBindingSource;
        private QLKSDataSet QLKSDataSet;
        private QLKSDataSetTableAdapters.KHACH_HANGTableAdapter KHACH_HANGTableAdapter;
    }
}
