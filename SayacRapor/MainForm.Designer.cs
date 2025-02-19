﻿namespace SayacRapor
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
            this.components = new System.ComponentModel.Container();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblKapasitif = new System.Windows.Forms.Label();
            this.lblEnduktif = new System.Windows.Forms.Label();
            this.btnVerileriYapistir = new System.Windows.Forms.Button();
            this.btnOtomatikDoldur = new System.Windows.Forms.Button();
            this.btnExcel = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.datePickerStart = new System.Windows.Forms.DateTimePicker();
            this.btn_VeriGetir = new System.Windows.Forms.Button();
            this.datePickerEnd = new System.Windows.Forms.DateTimePicker();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dataViewSayac = new System.Windows.Forms.DataGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dataViewGunluk = new System.Windows.Forms.DataGridView();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.ayarlarToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.düzenlemeyiAçKapatToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sayaçAyarlarıToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.grafikMenüsüToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.günlükGrafikToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.haftalıkGrafikToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saatlikVerilerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel3 = new System.Windows.Forms.Panel();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.statusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.progressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.toolHatali = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolEksik = new System.Windows.Forms.ToolStripStatusLabel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.sayaclarDataSet = new SayacRapor.SayaclarDataSet();
            this.sayaclarDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.timer3 = new System.Windows.Forms.Timer(this.components);
            this.groupBox2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataViewSayac)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataViewGunluk)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sayaclarDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sayaclarDataSetBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.lblKapasitif);
            this.groupBox2.Controls.Add(this.lblEnduktif);
            this.groupBox2.Controls.Add(this.btnVerileriYapistir);
            this.groupBox2.Controls.Add(this.btnOtomatikDoldur);
            this.groupBox2.Controls.Add(this.btnExcel);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.datePickerStart);
            this.groupBox2.Controls.Add(this.btn_VeriGetir);
            this.groupBox2.Controls.Add(this.datePickerEnd);
            this.groupBox2.Location = new System.Drawing.Point(15, 32);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Size = new System.Drawing.Size(1538, 80);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            // 
            // lblKapasitif
            // 
            this.lblKapasitif.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblKapasitif.AutoSize = true;
            this.lblKapasitif.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblKapasitif.ForeColor = System.Drawing.Color.Black;
            this.lblKapasitif.Location = new System.Drawing.Point(1345, 44);
            this.lblKapasitif.Name = "lblKapasitif";
            this.lblKapasitif.Size = new System.Drawing.Size(56, 25);
            this.lblKapasitif.TabIndex = 17;
            this.lblKapasitif.Text = "0000";
            // 
            // lblEnduktif
            // 
            this.lblEnduktif.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblEnduktif.AutoSize = true;
            this.lblEnduktif.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEnduktif.ForeColor = System.Drawing.Color.Black;
            this.lblEnduktif.Location = new System.Drawing.Point(1345, 16);
            this.lblEnduktif.Name = "lblEnduktif";
            this.lblEnduktif.Size = new System.Drawing.Size(56, 25);
            this.lblEnduktif.TabIndex = 16;
            this.lblEnduktif.Text = "0000";
            // 
            // btnVerileriYapistir
            // 
            this.btnVerileriYapistir.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVerileriYapistir.Location = new System.Drawing.Point(921, 19);
            this.btnVerileriYapistir.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnVerileriYapistir.Name = "btnVerileriYapistir";
            this.btnVerileriYapistir.Size = new System.Drawing.Size(121, 53);
            this.btnVerileriYapistir.TabIndex = 13;
            this.btnVerileriYapistir.Text = "Verileri Yapıştır";
            this.btnVerileriYapistir.UseVisualStyleBackColor = true;
            this.btnVerileriYapistir.Visible = false;
            this.btnVerileriYapistir.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // btnOtomatikDoldur
            // 
            this.btnOtomatikDoldur.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOtomatikDoldur.Location = new System.Drawing.Point(794, 19);
            this.btnOtomatikDoldur.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnOtomatikDoldur.Name = "btnOtomatikDoldur";
            this.btnOtomatikDoldur.Size = new System.Drawing.Size(121, 53);
            this.btnOtomatikDoldur.TabIndex = 11;
            this.btnOtomatikDoldur.Text = "Otomatik Doldur";
            this.btnOtomatikDoldur.UseVisualStyleBackColor = true;
            this.btnOtomatikDoldur.Visible = false;
            this.btnOtomatikDoldur.Click += new System.EventHandler(this.btnOtomatikDoldur_Click);
            // 
            // btnExcel
            // 
            this.btnExcel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExcel.Location = new System.Drawing.Point(667, 19);
            this.btnExcel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnExcel.Name = "btnExcel";
            this.btnExcel.Size = new System.Drawing.Size(121, 53);
            this.btnExcel.TabIndex = 7;
            this.btnExcel.Text = "Excel\'e Aktar";
            this.btnExcel.UseVisualStyleBackColor = true;
            this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 16);
            this.label1.TabIndex = 5;
            this.label1.Text = "Tarih Aralığı: ";
            // 
            // datePickerStart
            // 
            this.datePickerStart.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.datePickerStart.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.datePickerStart.Location = new System.Drawing.Point(128, 21);
            this.datePickerStart.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.datePickerStart.Name = "datePickerStart";
            this.datePickerStart.Size = new System.Drawing.Size(200, 22);
            this.datePickerStart.TabIndex = 1;
            this.datePickerStart.ValueChanged += new System.EventHandler(this.datePickerStart_ValueChanged);
            // 
            // btn_VeriGetir
            // 
            this.btn_VeriGetir.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_VeriGetir.Location = new System.Drawing.Point(540, 19);
            this.btn_VeriGetir.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_VeriGetir.Name = "btn_VeriGetir";
            this.btn_VeriGetir.Size = new System.Drawing.Size(121, 53);
            this.btn_VeriGetir.TabIndex = 0;
            this.btn_VeriGetir.Text = "Verileri Getir";
            this.btn_VeriGetir.UseVisualStyleBackColor = true;
            this.btn_VeriGetir.Click += new System.EventHandler(this.button1_Click);
            // 
            // datePickerEnd
            // 
            this.datePickerEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.datePickerEnd.Location = new System.Drawing.Point(334, 21);
            this.datePickerEnd.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.datePickerEnd.Name = "datePickerEnd";
            this.datePickerEnd.Size = new System.Drawing.Size(200, 22);
            this.datePickerEnd.TabIndex = 4;
            this.datePickerEnd.ValueChanged += new System.EventHandler(this.datePickerEnd_ValueChanged);
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.dataViewSayac);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1535, 470);
            this.panel1.TabIndex = 12;
            // 
            // dataViewSayac
            // 
            this.dataViewSayac.AllowUserToAddRows = false;
            this.dataViewSayac.AllowUserToDeleteRows = false;
            this.dataViewSayac.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dataViewSayac.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataViewSayac.Cursor = System.Windows.Forms.Cursors.Default;
            this.dataViewSayac.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataViewSayac.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataViewSayac.Location = new System.Drawing.Point(0, 0);
            this.dataViewSayac.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataViewSayac.Name = "dataViewSayac";
            this.dataViewSayac.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.dataViewSayac.RowTemplate.Height = 24;
            this.dataViewSayac.Size = new System.Drawing.Size(1535, 470);
            this.dataViewSayac.TabIndex = 7;
            this.dataViewSayac.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dataViewSayac_CellBeginEdit);
            this.dataViewSayac.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataViewSayac_CellMouseClick);
            this.dataViewSayac.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataViewSayac_CellValueChanged);
            this.dataViewSayac.Scroll += new System.Windows.Forms.ScrollEventHandler(this.dataViewSayac_Scroll);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dataViewGunluk);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 508);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1535, 470);
            this.panel2.TabIndex = 13;
            // 
            // dataViewGunluk
            // 
            this.dataViewGunluk.AllowUserToAddRows = false;
            this.dataViewGunluk.AllowUserToDeleteRows = false;
            this.dataViewGunluk.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dataViewGunluk.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataViewGunluk.Cursor = System.Windows.Forms.Cursors.Default;
            this.dataViewGunluk.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataViewGunluk.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataViewGunluk.Location = new System.Drawing.Point(0, 0);
            this.dataViewGunluk.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataViewGunluk.Name = "dataViewGunluk";
            this.dataViewGunluk.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.dataViewGunluk.RowTemplate.Height = 24;
            this.dataViewGunluk.Size = new System.Drawing.Size(1535, 470);
            this.dataViewGunluk.TabIndex = 8;
            this.dataViewGunluk.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataViewGunluk_CellMouseClick);
            this.dataViewGunluk.Scroll += new System.Windows.Forms.ScrollEventHandler(this.dataViewGunluk_Scroll);
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ayarlarToolStripMenuItem1,
            this.grafikMenüsüToolStripMenuItem,
            this.saatlikVerilerToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(5, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(1423, 28);
            this.menuStrip1.TabIndex = 14;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // ayarlarToolStripMenuItem1
            // 
            this.ayarlarToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.düzenlemeyiAçKapatToolStripMenuItem,
            this.sayaçAyarlarıToolStripMenuItem});
            this.ayarlarToolStripMenuItem1.Name = "ayarlarToolStripMenuItem1";
            this.ayarlarToolStripMenuItem1.Size = new System.Drawing.Size(70, 24);
            this.ayarlarToolStripMenuItem1.Text = "Ayarlar";
            // 
            // düzenlemeyiAçKapatToolStripMenuItem
            // 
            this.düzenlemeyiAçKapatToolStripMenuItem.Name = "düzenlemeyiAçKapatToolStripMenuItem";
            this.düzenlemeyiAçKapatToolStripMenuItem.Size = new System.Drawing.Size(252, 26);
            this.düzenlemeyiAçKapatToolStripMenuItem.Text = "Düzenlemeyi Aç / Kapat";
            this.düzenlemeyiAçKapatToolStripMenuItem.Click += new System.EventHandler(this.açıkKapatToolStripMenuItem_Click);
            // 
            // sayaçAyarlarıToolStripMenuItem
            // 
            this.sayaçAyarlarıToolStripMenuItem.Name = "sayaçAyarlarıToolStripMenuItem";
            this.sayaçAyarlarıToolStripMenuItem.Size = new System.Drawing.Size(252, 26);
            this.sayaçAyarlarıToolStripMenuItem.Text = "Sayaç Ayarları";
            this.sayaçAyarlarıToolStripMenuItem.Click += new System.EventHandler(this.ayarlarToolStripMenuItem_Click);
            // 
            // grafikMenüsüToolStripMenuItem
            // 
            this.grafikMenüsüToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.günlükGrafikToolStripMenuItem,
            this.haftalıkGrafikToolStripMenuItem});
            this.grafikMenüsüToolStripMenuItem.Name = "grafikMenüsüToolStripMenuItem";
            this.grafikMenüsüToolStripMenuItem.Size = new System.Drawing.Size(117, 24);
            this.grafikMenüsüToolStripMenuItem.Text = "Grafik Menüsü";
            // 
            // günlükGrafikToolStripMenuItem
            // 
            this.günlükGrafikToolStripMenuItem.Name = "günlükGrafikToolStripMenuItem";
            this.günlükGrafikToolStripMenuItem.Size = new System.Drawing.Size(187, 26);
            this.günlükGrafikToolStripMenuItem.Text = "Günlük Grafik";
            this.günlükGrafikToolStripMenuItem.Click += new System.EventHandler(this.günlükGrafikToolStripMenuItem_Click);
            // 
            // haftalıkGrafikToolStripMenuItem
            // 
            this.haftalıkGrafikToolStripMenuItem.Name = "haftalıkGrafikToolStripMenuItem";
            this.haftalıkGrafikToolStripMenuItem.Size = new System.Drawing.Size(187, 26);
            this.haftalıkGrafikToolStripMenuItem.Text = "Haftalık Grafik";
            this.haftalıkGrafikToolStripMenuItem.Click += new System.EventHandler(this.haftalıkGrafikToolStripMenuItem_Click);
            // 
            // saatlikVerilerToolStripMenuItem
            // 
            this.saatlikVerilerToolStripMenuItem.Name = "saatlikVerilerToolStripMenuItem";
            this.saatlikVerilerToolStripMenuItem.Size = new System.Drawing.Size(113, 24);
            this.saatlikVerilerToolStripMenuItem.Text = "Saatlik Veriler";
            this.saatlikVerilerToolStripMenuItem.Click += new System.EventHandler(this.saatlikVerilerToolStripMenuItem_Click);
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.AutoScroll = true;
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.panel2);
            this.panel3.Controls.Add(this.panel1);
            this.panel3.Location = new System.Drawing.Point(16, 116);
            this.panel3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1537, 980);
            this.panel3.TabIndex = 15;
            this.panel3.Paint += new System.Windows.Forms.PaintEventHandler(this.panel3_Paint);
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusLabel,
            this.progressBar,
            this.toolHatali,
            this.toolEksik});
            this.statusStrip1.Location = new System.Drawing.Point(0, 1096);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 19, 0);
            this.statusStrip1.Size = new System.Drawing.Size(1423, 26);
            this.statusStrip1.TabIndex = 16;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // statusLabel
            // 
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(0, 20);
            // 
            // progressBar
            // 
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(100, 18);
            // 
            // toolHatali
            // 
            this.toolHatali.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolHatali.ForeColor = System.Drawing.Color.Firebrick;
            this.toolHatali.Name = "toolHatali";
            this.toolHatali.Size = new System.Drawing.Size(457, 28);
            this.toolHatali.Text = "Hatalı veri bulundu. Sayaç ayarlarını kontrol edin.";
            this.toolHatali.Visible = false;
            // 
            // toolEksik
            // 
            this.toolEksik.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolEksik.ForeColor = System.Drawing.Color.Firebrick;
            this.toolEksik.Name = "toolEksik";
            this.toolEksik.Size = new System.Drawing.Size(470, 28);
            this.toolEksik.Text = "Eksik kolon bulundu. Sayaç ayarlarını kontrol edin.";
            this.toolEksik.Visible = false;
            // 
            // timer1
            // 
            this.timer1.Interval = 7000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // timer2
            // 
            this.timer2.Interval = 7000;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // sayaclarDataSet
            // 
            this.sayaclarDataSet.DataSetName = "SayaclarDataSet";
            this.sayaclarDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // sayaclarDataSetBindingSource
            // 
            this.sayaclarDataSetBindingSource.DataSource = this.sayaclarDataSet;
            this.sayaclarDataSetBindingSource.Position = 0;
            // 
            // timer3
            // 
            this.timer3.Tick += new System.EventHandler(this.timer3_Tick);
            // 
            // MainForm
            // 
            this.AcceptButton = this.btn_VeriGetir;
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1444, 875);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.menuStrip1);
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "MainForm";
            this.Text = "Sayaç Raporu v1.1.0.0";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyUp);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataViewSayac)).EndInit();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataViewGunluk)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sayaclarDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sayaclarDataSetBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.BindingSource sayaclarDataSetBindingSource;
        private SayaclarDataSet sayaclarDataSet;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker datePickerStart;
        private System.Windows.Forms.Button btn_VeriGetir;
        private System.Windows.Forms.DateTimePicker datePickerEnd;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dataViewSayac;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dataViewGunluk;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnExcel;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel statusLabel;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button btnOtomatikDoldur;
        private System.Windows.Forms.ToolStripMenuItem grafikMenüsüToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem günlükGrafikToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem haftalıkGrafikToolStripMenuItem;
        private System.Windows.Forms.ToolStripProgressBar progressBar;
        private System.Windows.Forms.Button btnVerileriYapistir;
        private System.Windows.Forms.ToolStripMenuItem ayarlarToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem düzenlemeyiAçKapatToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sayaçAyarlarıToolStripMenuItem;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.Label lblKapasitif;
        private System.Windows.Forms.Label lblEnduktif;
        private System.Windows.Forms.Timer timer3;
        private System.Windows.Forms.ToolStripStatusLabel toolHatali;
        private System.Windows.Forms.ToolStripStatusLabel toolEksik;
        private System.Windows.Forms.ToolStripMenuItem saatlikVerilerToolStripMenuItem;
    }
}

