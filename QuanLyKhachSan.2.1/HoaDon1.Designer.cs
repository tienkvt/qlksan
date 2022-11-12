namespace QuanLyKhachSan._2._1
{
    partial class HoaDon1
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource2 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource3 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource4 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource5 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource6 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.HOA_DONBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.HoaDon = new QuanLyKhachSan._2._1.HoaDon();
            this.CHI_TIET_HOA_DONBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.PHIEU_NHAN_PHONGBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.KHACH_HANGBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.DICH_VUBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.DANH_SACH_SU_DUNG_DICH_VUBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.HOA_DONTableAdapter = new QuanLyKhachSan._2._1.HoaDonTableAdapters.HOA_DONTableAdapter();
            this.CHI_TIET_HOA_DONTableAdapter = new QuanLyKhachSan._2._1.HoaDonTableAdapters.CHI_TIET_HOA_DONTableAdapter();
            this.PHIEU_NHAN_PHONGTableAdapter = new QuanLyKhachSan._2._1.HoaDonTableAdapters.PHIEU_NHAN_PHONGTableAdapter();
            this.KHACH_HANGTableAdapter = new QuanLyKhachSan._2._1.HoaDonTableAdapters.KHACH_HANGTableAdapter();
            this.DICH_VUTableAdapter = new QuanLyKhachSan._2._1.HoaDonTableAdapters.DICH_VUTableAdapter();
            this.DANH_SACH_SU_DUNG_DICH_VUTableAdapter = new QuanLyKhachSan._2._1.HoaDonTableAdapters.DANH_SACH_SU_DUNG_DICH_VUTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.HOA_DONBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.HoaDon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CHI_TIET_HOA_DONBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PHIEU_NHAN_PHONGBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.KHACH_HANGBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DICH_VUBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DANH_SACH_SU_DUNG_DICH_VUBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // HOA_DONBindingSource
            // 
            this.HOA_DONBindingSource.DataMember = "HOA_DON";
            this.HOA_DONBindingSource.DataSource = this.HoaDon;
            // 
            // HoaDon
            // 
            this.HoaDon.DataSetName = "HoaDon";
            this.HoaDon.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // CHI_TIET_HOA_DONBindingSource
            // 
            this.CHI_TIET_HOA_DONBindingSource.DataMember = "CHI_TIET_HOA_DON";
            this.CHI_TIET_HOA_DONBindingSource.DataSource = this.HoaDon;
            // 
            // PHIEU_NHAN_PHONGBindingSource
            // 
            this.PHIEU_NHAN_PHONGBindingSource.DataMember = "PHIEU_NHAN_PHONG";
            this.PHIEU_NHAN_PHONGBindingSource.DataSource = this.HoaDon;
            // 
            // KHACH_HANGBindingSource
            // 
            this.KHACH_HANGBindingSource.DataMember = "KHACH_HANG";
            this.KHACH_HANGBindingSource.DataSource = this.HoaDon;
            // 
            // DICH_VUBindingSource
            // 
            this.DICH_VUBindingSource.DataMember = "DICH_VU";
            this.DICH_VUBindingSource.DataSource = this.HoaDon;
            // 
            // DANH_SACH_SU_DUNG_DICH_VUBindingSource
            // 
            this.DANH_SACH_SU_DUNG_DICH_VUBindingSource.DataMember = "DANH_SACH_SU_DUNG_DICH_VU";
            this.DANH_SACH_SU_DUNG_DICH_VUBindingSource.DataSource = this.HoaDon;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.HOA_DONBindingSource;
            reportDataSource2.Name = "DataSet2";
            reportDataSource2.Value = this.CHI_TIET_HOA_DONBindingSource;
            reportDataSource3.Name = "DataSet3";
            reportDataSource3.Value = this.PHIEU_NHAN_PHONGBindingSource;
            reportDataSource4.Name = "DataSet4";
            reportDataSource4.Value = this.KHACH_HANGBindingSource;
            reportDataSource5.Name = "DataSet5";
            reportDataSource5.Value = this.DICH_VUBindingSource;
            reportDataSource6.Name = "DataSet6";
            reportDataSource6.Value = this.DANH_SACH_SU_DUNG_DICH_VUBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource2);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource3);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource4);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource5);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource6);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "QuanLyKhachSan._2._1.HoaDon.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(513, 511);
            this.reportViewer1.TabIndex = 0;
            // 
            // HOA_DONTableAdapter
            // 
            this.HOA_DONTableAdapter.ClearBeforeFill = true;
            // 
            // CHI_TIET_HOA_DONTableAdapter
            // 
            this.CHI_TIET_HOA_DONTableAdapter.ClearBeforeFill = true;
            // 
            // PHIEU_NHAN_PHONGTableAdapter
            // 
            this.PHIEU_NHAN_PHONGTableAdapter.ClearBeforeFill = true;
            // 
            // KHACH_HANGTableAdapter
            // 
            this.KHACH_HANGTableAdapter.ClearBeforeFill = true;
            // 
            // DICH_VUTableAdapter
            // 
            this.DICH_VUTableAdapter.ClearBeforeFill = true;
            // 
            // DANH_SACH_SU_DUNG_DICH_VUTableAdapter
            // 
            this.DANH_SACH_SU_DUNG_DICH_VUTableAdapter.ClearBeforeFill = true;
            // 
            // HoaDon1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(513, 511);
            this.Controls.Add(this.reportViewer1);
            this.Name = "HoaDon1";
            this.Text = "Báo Cáo Hóa Đơn";
            this.Load += new System.EventHandler(this.HoaDon1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.HOA_DONBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.HoaDon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CHI_TIET_HOA_DONBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PHIEU_NHAN_PHONGBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.KHACH_HANGBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DICH_VUBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DANH_SACH_SU_DUNG_DICH_VUBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource HOA_DONBindingSource;
        private HoaDon HoaDon;
        private System.Windows.Forms.BindingSource CHI_TIET_HOA_DONBindingSource;
        private System.Windows.Forms.BindingSource PHIEU_NHAN_PHONGBindingSource;
        private System.Windows.Forms.BindingSource KHACH_HANGBindingSource;
        private System.Windows.Forms.BindingSource DICH_VUBindingSource;
        private System.Windows.Forms.BindingSource DANH_SACH_SU_DUNG_DICH_VUBindingSource;
        private HoaDonTableAdapters.HOA_DONTableAdapter HOA_DONTableAdapter;
        private HoaDonTableAdapters.CHI_TIET_HOA_DONTableAdapter CHI_TIET_HOA_DONTableAdapter;
        private HoaDonTableAdapters.PHIEU_NHAN_PHONGTableAdapter PHIEU_NHAN_PHONGTableAdapter;
        private HoaDonTableAdapters.KHACH_HANGTableAdapter KHACH_HANGTableAdapter;
        private HoaDonTableAdapters.DICH_VUTableAdapter DICH_VUTableAdapter;
        private HoaDonTableAdapters.DANH_SACH_SU_DUNG_DICH_VUTableAdapter DANH_SACH_SU_DUNG_DICH_VUTableAdapter;
    }
}