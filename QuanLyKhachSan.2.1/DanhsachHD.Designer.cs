
namespace QuanLyKhachSan._2._1
{
    partial class DanhsachHD
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DanhsachHD));
            this.qLKSDataSet = new QuanLyKhachSan._2._1.QLKSDataSet();
            this.cHITIETHOADONBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.cHI_TIET_HOA_DONTableAdapter = new QuanLyKhachSan._2._1.QLKSDataSetTableAdapters.CHI_TIET_HOA_DONTableAdapter();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.qlksDataSet1 = new QuanLyKhachSan._2._1.QLKSDataSet();
            this.chI_TIET_HOA_DONTableAdapter1 = new QuanLyKhachSan._2._1.QLKSDataSetTableAdapters.CHI_TIET_HOA_DONTableAdapter();
            this.colMaHoaDon = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMaPhong = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMaSuDungDVu = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMaChinhSach = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPhuThu = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTienPhong = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTienDichVu = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGiamGiaKH = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colHinhThucThanhToan = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSoNgay = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colThanhTien = new DevExpress.XtraGrid.Columns.GridColumn();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.btnThoat = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.qLKSDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cHITIETHOADONBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qlksDataSet1)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // qLKSDataSet
            // 
            this.qLKSDataSet.DataSetName = "QLKSDataSet";
            this.qLKSDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // cHITIETHOADONBindingSource
            // 
            this.cHITIETHOADONBindingSource.DataMember = "CHI_TIET_HOA_DON";
            this.cHITIETHOADONBindingSource.DataSource = this.qLKSDataSet;
            // 
            // cHI_TIET_HOA_DONTableAdapter
            // 
            this.cHI_TIET_HOA_DONTableAdapter.ClearBeforeFill = true;
            // 
            // gridControl1
            // 
            this.gridControl1.DataMember = "CHI_TIET_HOA_DON";
            this.gridControl1.DataSource = this.qlksDataSet1;
            this.gridControl1.Location = new System.Drawing.Point(13, 93);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(908, 281);
            this.gridControl1.TabIndex = 0;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colMaHoaDon,
            this.colMaPhong,
            this.colMaSuDungDVu,
            this.colMaChinhSach,
            this.colPhuThu,
            this.colTienPhong,
            this.colTienDichVu,
            this.colGiamGiaKH,
            this.colHinhThucThanhToan,
            this.colSoNgay,
            this.colThanhTien});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // qlksDataSet1
            // 
            this.qlksDataSet1.DataSetName = "QLKSDataSet";
            this.qlksDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // chI_TIET_HOA_DONTableAdapter1
            // 
            this.chI_TIET_HOA_DONTableAdapter1.ClearBeforeFill = true;
            // 
            // colMaHoaDon
            // 
            this.colMaHoaDon.AppearanceHeader.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold);
            this.colMaHoaDon.AppearanceHeader.Options.UseFont = true;
            this.colMaHoaDon.Caption = "Mã Hóa Đơn ";
            this.colMaHoaDon.FieldName = "MaHoaDon";
            this.colMaHoaDon.Name = "colMaHoaDon";
            this.colMaHoaDon.Visible = true;
            this.colMaHoaDon.VisibleIndex = 0;
            this.colMaHoaDon.Width = 77;
            // 
            // colMaPhong
            // 
            this.colMaPhong.AppearanceHeader.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold);
            this.colMaPhong.AppearanceHeader.Options.UseFont = true;
            this.colMaPhong.Caption = "Mã Phòng";
            this.colMaPhong.FieldName = "MaPhong";
            this.colMaPhong.Name = "colMaPhong";
            this.colMaPhong.Visible = true;
            this.colMaPhong.VisibleIndex = 1;
            this.colMaPhong.Width = 77;
            // 
            // colMaSuDungDVu
            // 
            this.colMaSuDungDVu.AppearanceHeader.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold);
            this.colMaSuDungDVu.AppearanceHeader.Options.UseFont = true;
            this.colMaSuDungDVu.Caption = "Mã Sử Dụng DVu";
            this.colMaSuDungDVu.FieldName = "MaSuDungDVu";
            this.colMaSuDungDVu.Name = "colMaSuDungDVu";
            this.colMaSuDungDVu.Visible = true;
            this.colMaSuDungDVu.VisibleIndex = 2;
            this.colMaSuDungDVu.Width = 77;
            // 
            // colMaChinhSach
            // 
            this.colMaChinhSach.AppearanceHeader.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold);
            this.colMaChinhSach.AppearanceHeader.Options.UseFont = true;
            this.colMaChinhSach.Caption = "Mã Chính Sách";
            this.colMaChinhSach.FieldName = "MaChinhSach";
            this.colMaChinhSach.Name = "colMaChinhSach";
            this.colMaChinhSach.Visible = true;
            this.colMaChinhSach.VisibleIndex = 3;
            this.colMaChinhSach.Width = 93;
            // 
            // colPhuThu
            // 
            this.colPhuThu.AppearanceHeader.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold);
            this.colPhuThu.AppearanceHeader.Options.UseFont = true;
            this.colPhuThu.Caption = "Phụ Thu";
            this.colPhuThu.FieldName = "PhuThu";
            this.colPhuThu.Name = "colPhuThu";
            this.colPhuThu.Visible = true;
            this.colPhuThu.VisibleIndex = 4;
            this.colPhuThu.Width = 74;
            // 
            // colTienPhong
            // 
            this.colTienPhong.AppearanceHeader.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold);
            this.colTienPhong.AppearanceHeader.Options.UseFont = true;
            this.colTienPhong.Caption = "Tiền Phòng";
            this.colTienPhong.FieldName = "TienPhong";
            this.colTienPhong.Name = "colTienPhong";
            this.colTienPhong.Visible = true;
            this.colTienPhong.VisibleIndex = 5;
            this.colTienPhong.Width = 74;
            // 
            // colTienDichVu
            // 
            this.colTienDichVu.AppearanceHeader.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold);
            this.colTienDichVu.AppearanceHeader.Options.UseFont = true;
            this.colTienDichVu.Caption = "Tiền Dịch Vụ";
            this.colTienDichVu.FieldName = "TienDichVu";
            this.colTienDichVu.Name = "colTienDichVu";
            this.colTienDichVu.Visible = true;
            this.colTienDichVu.VisibleIndex = 6;
            this.colTienDichVu.Width = 74;
            // 
            // colGiamGiaKH
            // 
            this.colGiamGiaKH.AppearanceHeader.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold);
            this.colGiamGiaKH.AppearanceHeader.Options.UseFont = true;
            this.colGiamGiaKH.Caption = "Giảm Giá KH";
            this.colGiamGiaKH.FieldName = "GiamGiaKH";
            this.colGiamGiaKH.Name = "colGiamGiaKH";
            this.colGiamGiaKH.Visible = true;
            this.colGiamGiaKH.VisibleIndex = 7;
            this.colGiamGiaKH.Width = 74;
            // 
            // colHinhThucThanhToan
            // 
            this.colHinhThucThanhToan.AppearanceHeader.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold);
            this.colHinhThucThanhToan.AppearanceHeader.Options.UseFont = true;
            this.colHinhThucThanhToan.Caption = "Hình Thức Thanh Toán ";
            this.colHinhThucThanhToan.FieldName = "HinhThucThanhToan";
            this.colHinhThucThanhToan.Name = "colHinhThucThanhToan";
            this.colHinhThucThanhToan.Visible = true;
            this.colHinhThucThanhToan.VisibleIndex = 8;
            this.colHinhThucThanhToan.Width = 116;
            // 
            // colSoNgay
            // 
            this.colSoNgay.AppearanceHeader.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold);
            this.colSoNgay.AppearanceHeader.Options.UseFont = true;
            this.colSoNgay.Caption = "Số Ngày";
            this.colSoNgay.FieldName = "SoNgay";
            this.colSoNgay.Name = "colSoNgay";
            this.colSoNgay.Visible = true;
            this.colSoNgay.VisibleIndex = 9;
            this.colSoNgay.Width = 53;
            // 
            // colThanhTien
            // 
            this.colThanhTien.AppearanceHeader.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold);
            this.colThanhTien.AppearanceHeader.Options.UseFont = true;
            this.colThanhTien.Caption = "Thành Tiền ";
            this.colThanhTien.FieldName = "ThanhTien";
            this.colThanhTien.Name = "colThanhTien";
            this.colThanhTien.Visible = true;
            this.colThanhTien.VisibleIndex = 10;
            this.colThanhTien.Width = 64;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel2.ColumnCount = 8;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5.294117F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 94.70588F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 114F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 155F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 182F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 240F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 97F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 111F));
            this.tableLayoutPanel2.Controls.Add(this.btnThoat, 7, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(13, 52);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(908, 35);
            this.tableLayoutPanel2.TabIndex = 34;
            // 
            // labelControl1
            // 
            this.labelControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Appearance.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Appearance.Options.UseForeColor = true;
            this.labelControl1.Location = new System.Drawing.Point(333, 12);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(236, 29);
            this.labelControl1.TabIndex = 35;
            this.labelControl1.Text = "Danh Sách Hóa Đơn";
            // 
            // btnThoat
            // 
            this.btnThoat.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnThoat.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThoat.Appearance.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnThoat.Appearance.Options.UseFont = true;
            this.btnThoat.Appearance.Options.UseForeColor = true;
            this.btnThoat.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
            this.btnThoat.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnThoat.ImageOptions.Image")));
            this.btnThoat.Location = new System.Drawing.Point(810, 3);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(83, 29);
            this.btnThoat.TabIndex = 22;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // DanhsachHD
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(933, 383);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.tableLayoutPanel2);
            this.Controls.Add(this.gridControl1);
            this.MinimizeBox = false;
            this.Name = "DanhsachHD";
            this.Text = "DanhsachHD";
            this.Load += new System.EventHandler(this.DanhsachHD_Load);
            ((System.ComponentModel.ISupportInitialize)(this.qLKSDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cHITIETHOADONBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qlksDataSet1)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private QLKSDataSet qLKSDataSet;
        private System.Windows.Forms.BindingSource cHITIETHOADONBindingSource;
        private QLKSDataSetTableAdapters.CHI_TIET_HOA_DONTableAdapter cHI_TIET_HOA_DONTableAdapter;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private QLKSDataSet qlksDataSet1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn colMaHoaDon;
        private DevExpress.XtraGrid.Columns.GridColumn colMaPhong;
        private DevExpress.XtraGrid.Columns.GridColumn colMaSuDungDVu;
        private DevExpress.XtraGrid.Columns.GridColumn colMaChinhSach;
        private DevExpress.XtraGrid.Columns.GridColumn colPhuThu;
        private DevExpress.XtraGrid.Columns.GridColumn colTienPhong;
        private DevExpress.XtraGrid.Columns.GridColumn colTienDichVu;
        private DevExpress.XtraGrid.Columns.GridColumn colGiamGiaKH;
        private DevExpress.XtraGrid.Columns.GridColumn colHinhThucThanhToan;
        private DevExpress.XtraGrid.Columns.GridColumn colSoNgay;
        private DevExpress.XtraGrid.Columns.GridColumn colThanhTien;
        private QLKSDataSetTableAdapters.CHI_TIET_HOA_DONTableAdapter chI_TIET_HOA_DONTableAdapter1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.SimpleButton btnThoat;
    }
}