namespace SayacRapor
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
            this.sayaclarDataSet = new SayacRapor.SayaclarDataSet();
            this.sayaclarDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnOtomatikDoldur = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.listBox2 = new System.Windows.Forms.ListBox();
            this.btnExcel = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.datePickerStart = new System.Windows.Forms.DateTimePicker();
            this.btn_VeriGetir = new System.Windows.Forms.Button();
            this.datePickerEnd = new System.Windows.Forms.DateTimePicker();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dataViewSayac = new System.Windows.Forms.DataGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dataViewGunluk = new System.Windows.Forms.DataGridView();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.ayarlarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.yöneticiModuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.açıkKapatToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel3 = new System.Windows.Forms.Panel();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.statusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.sayaclarDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sayaclarDataSetBindingSource)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataViewSayac)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataViewGunluk)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
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
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.btnOtomatikDoldur);
            this.groupBox2.Controls.Add(this.listBox1);
            this.groupBox2.Controls.Add(this.listBox2);
            this.groupBox2.Controls.Add(this.btnExcel);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.datePickerStart);
            this.groupBox2.Controls.Add(this.btn_VeriGetir);
            this.groupBox2.Controls.Add(this.datePickerEnd);
            this.groupBox2.Location = new System.Drawing.Point(15, 32);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Size = new System.Drawing.Size(1245, 100);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            // 
            // btnOtomatikDoldur
            // 
            this.btnOtomatikDoldur.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOtomatikDoldur.Location = new System.Drawing.Point(588, 21);
            this.btnOtomatikDoldur.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnOtomatikDoldur.Name = "btnOtomatikDoldur";
            this.btnOtomatikDoldur.Size = new System.Drawing.Size(121, 73);
            this.btnOtomatikDoldur.TabIndex = 11;
            this.btnOtomatikDoldur.Text = "Otomatik Doldur";
            this.btnOtomatikDoldur.UseVisualStyleBackColor = true;
            this.btnOtomatikDoldur.Click += new System.EventHandler(this.btnOtomatikDoldur_Click);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 16;
            this.listBox1.Location = new System.Drawing.Point(764, 25);
            this.listBox1.Margin = new System.Windows.Forms.Padding(4);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(241, 68);
            this.listBox1.TabIndex = 10;
            // 
            // listBox2
            // 
            this.listBox2.FormattingEnabled = true;
            this.listBox2.ItemHeight = 16;
            this.listBox2.Location = new System.Drawing.Point(1015, 25);
            this.listBox2.Margin = new System.Windows.Forms.Padding(4);
            this.listBox2.Name = "listBox2";
            this.listBox2.Size = new System.Drawing.Size(241, 68);
            this.listBox2.TabIndex = 9;
            // 
            // btnExcel
            // 
            this.btnExcel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExcel.Location = new System.Drawing.Point(461, 21);
            this.btnExcel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnExcel.Name = "btnExcel";
            this.btnExcel.Size = new System.Drawing.Size(121, 73);
            this.btnExcel.TabIndex = 7;
            this.btnExcel.Text = "Excel\'e Aktar";
            this.btnExcel.UseVisualStyleBackColor = true;
            this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(47, 74);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 16);
            this.label2.TabIndex = 6;
            this.label2.Text = "Bitiş Tarihi:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 16);
            this.label1.TabIndex = 5;
            this.label1.Text = "Başlangıç Tarihi:";
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
            this.btn_VeriGetir.Location = new System.Drawing.Point(333, 21);
            this.btn_VeriGetir.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_VeriGetir.Name = "btn_VeriGetir";
            this.btn_VeriGetir.Size = new System.Drawing.Size(121, 73);
            this.btn_VeriGetir.TabIndex = 0;
            this.btn_VeriGetir.Text = "Verileri Getir";
            this.btn_VeriGetir.UseVisualStyleBackColor = true;
            this.btn_VeriGetir.Click += new System.EventHandler(this.button1_Click);
            // 
            // datePickerEnd
            // 
            this.datePickerEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.datePickerEnd.Location = new System.Drawing.Point(128, 71);
            this.datePickerEnd.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.datePickerEnd.Name = "datePickerEnd";
            this.datePickerEnd.Size = new System.Drawing.Size(200, 22);
            this.datePickerEnd.TabIndex = 4;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.dataViewSayac);
            this.panel1.Location = new System.Drawing.Point(3, 2);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1234, 400);
            this.panel1.TabIndex = 12;
            // 
            // dataViewSayac
            // 
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
            this.dataViewSayac.Size = new System.Drawing.Size(1234, 400);
            this.dataViewSayac.TabIndex = 7;
            this.dataViewSayac.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dataViewSayac_CellBeginEdit);
            this.dataViewSayac.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataViewSayac_CellMouseClick);
            this.dataViewSayac.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataViewSayac_CellValueChanged);
            this.dataViewSayac.Scroll += new System.Windows.Forms.ScrollEventHandler(this.dataViewSayac_Scroll);
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.Controls.Add(this.dataViewGunluk);
            this.panel2.Location = new System.Drawing.Point(3, 407);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1234, 450);
            this.panel2.TabIndex = 13;
            // 
            // dataViewGunluk
            // 
            this.dataViewGunluk.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataViewGunluk.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataViewGunluk.Cursor = System.Windows.Forms.Cursors.Default;
            this.dataViewGunluk.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataViewGunluk.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataViewGunluk.Location = new System.Drawing.Point(0, 0);
            this.dataViewGunluk.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataViewGunluk.Name = "dataViewGunluk";
            this.dataViewGunluk.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.dataViewGunluk.RowTemplate.Height = 24;
            this.dataViewGunluk.Size = new System.Drawing.Size(1234, 450);
            this.dataViewGunluk.TabIndex = 8;
            this.dataViewGunluk.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataViewGunluk_CellMouseClick);
            this.dataViewGunluk.Scroll += new System.Windows.Forms.ScrollEventHandler(this.dataViewGunluk_Scroll);
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ayarlarToolStripMenuItem,
            this.yöneticiModuToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(5, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(1445, 28);
            this.menuStrip1.TabIndex = 14;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // ayarlarToolStripMenuItem
            // 
            this.ayarlarToolStripMenuItem.Name = "ayarlarToolStripMenuItem";
            this.ayarlarToolStripMenuItem.Size = new System.Drawing.Size(116, 24);
            this.ayarlarToolStripMenuItem.Text = "Sayaç Ayarları";
            this.ayarlarToolStripMenuItem.Click += new System.EventHandler(this.ayarlarToolStripMenuItem_Click);
            // 
            // yöneticiModuToolStripMenuItem
            // 
            this.yöneticiModuToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.açıkKapatToolStripMenuItem});
            this.yöneticiModuToolStripMenuItem.Name = "yöneticiModuToolStripMenuItem";
            this.yöneticiModuToolStripMenuItem.Size = new System.Drawing.Size(118, 24);
            this.yöneticiModuToolStripMenuItem.Text = "Yönetici Modu";
            // 
            // açıkKapatToolStripMenuItem
            // 
            this.açıkKapatToolStripMenuItem.Name = "açıkKapatToolStripMenuItem";
            this.açıkKapatToolStripMenuItem.Size = new System.Drawing.Size(175, 26);
            this.açıkKapatToolStripMenuItem.Text = "(Kapalı) - Aç";
            this.açıkKapatToolStripMenuItem.Click += new System.EventHandler(this.açıkKapatToolStripMenuItem_Click);
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.AutoScroll = true;
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.panel2);
            this.panel3.Controls.Add(this.panel1);
            this.panel3.Location = new System.Drawing.Point(15, 137);
            this.panel3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1244, 862);
            this.panel3.TabIndex = 15;
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusLabel});
            this.statusStrip1.Location = new System.Drawing.Point(0, 999);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 19, 0);
            this.statusStrip1.Size = new System.Drawing.Size(1445, 22);
            this.statusStrip1.TabIndex = 16;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // statusLabel
            // 
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(0, 16);
            // 
            // timer1
            // 
            this.timer1.Interval = 7000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1466, 870);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "MainForm";
            this.Text = "Sayaç Raporu";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.sayaclarDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sayaclarDataSetBindingSource)).EndInit();
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
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.BindingSource sayaclarDataSetBindingSource;
        private SayaclarDataSet sayaclarDataSet;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker datePickerStart;
        private System.Windows.Forms.Button btn_VeriGetir;
        private System.Windows.Forms.DateTimePicker datePickerEnd;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dataViewSayac;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dataViewGunluk;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem ayarlarToolStripMenuItem;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnExcel;
        private System.Windows.Forms.ListBox listBox2;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.ToolStripMenuItem yöneticiModuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem açıkKapatToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel statusLabel;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button btnOtomatikDoldur;
    }
}

