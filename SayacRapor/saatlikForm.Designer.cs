namespace SayacRapor
{
    partial class saatlikForm
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
            System.Windows.Forms.DataVisualization.Charting.LineAnnotation lineAnnotation9 = new System.Windows.Forms.DataVisualization.Charting.LineAnnotation();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea9 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend9 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series25 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series26 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series27 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title9 = new System.Windows.Forms.DataVisualization.Charting.Title();
            this.cmbMakine = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.datePickerEnd = new System.Windows.Forms.DateTimePicker();
            this.panel1 = new System.Windows.Forms.Panel();
            this.checkToplam = new System.Windows.Forms.CheckBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.checkFanOrt = new System.Windows.Forms.CheckBox();
            this.checkToplamOrt = new System.Windows.Forms.CheckBox();
            this.checkMotorOrt = new System.Windows.Forms.CheckBox();
            this.checkIsiticiOrt = new System.Windows.Forms.CheckBox();
            this.datePickerStart = new System.Windows.Forms.DateTimePicker();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnOtomatikDoldur = new System.Windows.Forms.Button();
            this.dataViewSayac = new System.Windows.Forms.DataGridView();
            this.dataViewSaatlik = new System.Windows.Forms.DataGridView();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.statusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.ayarlarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.düzenlemeyiAçKapatToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panel3 = new System.Windows.Forms.Panel();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataViewSayac)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataViewSaatlik)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbMakine
            // 
            this.cmbMakine.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cmbMakine.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbMakine.FormattingEnabled = true;
            this.cmbMakine.Location = new System.Drawing.Point(75, 20);
            this.cmbMakine.Name = "cmbMakine";
            this.cmbMakine.Size = new System.Drawing.Size(220, 24);
            this.cmbMakine.TabIndex = 10;
            this.cmbMakine.SelectedIndexChanged += new System.EventHandler(this.cmbMakine_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 16);
            this.label2.TabIndex = 11;
            this.label2.Text = "Makine:";
            // 
            // datePickerEnd
            // 
            this.datePickerEnd.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.datePickerEnd.Location = new System.Drawing.Point(192, 50);
            this.datePickerEnd.Name = "datePickerEnd";
            this.datePickerEnd.Size = new System.Drawing.Size(103, 22);
            this.datePickerEnd.TabIndex = 25;
            this.datePickerEnd.ValueChanged += new System.EventHandler(this.datePickerEnd_ValueChanged);
            // 
            // panel1
            // 
            this.panel1.AutoSize = true;
            this.panel1.Controls.Add(this.checkToplam);
            this.panel1.Controls.Add(this.checkBox2);
            this.panel1.Controls.Add(this.checkBox1);
            this.panel1.Controls.Add(this.checkBox3);
            this.panel1.Location = new System.Drawing.Point(301, 20);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(101, 110);
            this.panel1.TabIndex = 26;
            // 
            // checkToplam
            // 
            this.checkToplam.AutoSize = true;
            this.checkToplam.Location = new System.Drawing.Point(3, 4);
            this.checkToplam.Name = "checkToplam";
            this.checkToplam.Size = new System.Drawing.Size(76, 20);
            this.checkToplam.TabIndex = 15;
            this.checkToplam.Text = "Toplam";
            this.checkToplam.UseVisualStyleBackColor = true;
            this.checkToplam.Visible = false;
            this.checkToplam.CheckedChanged += new System.EventHandler(this.checkToplam_CheckedChanged);
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(3, 55);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(95, 20);
            this.checkBox2.TabIndex = 13;
            this.checkBox2.Text = "checkBox2";
            this.checkBox2.UseVisualStyleBackColor = true;
            this.checkBox2.Visible = false;
            this.checkBox2.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Checked = true;
            this.checkBox1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox1.Location = new System.Drawing.Point(3, 29);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(95, 20);
            this.checkBox1.TabIndex = 12;
            this.checkBox1.Text = "checkBox1";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.Visible = false;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // checkBox3
            // 
            this.checkBox3.AutoSize = true;
            this.checkBox3.Location = new System.Drawing.Point(3, 81);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(95, 20);
            this.checkBox3.TabIndex = 14;
            this.checkBox3.Text = "checkBox3";
            this.checkBox3.UseVisualStyleBackColor = true;
            this.checkBox3.Visible = false;
            this.checkBox3.CheckedChanged += new System.EventHandler(this.checkBox3_CheckedChanged);
            // 
            // panel2
            // 
            this.panel2.AutoSize = true;
            this.panel2.Controls.Add(this.checkFanOrt);
            this.panel2.Controls.Add(this.checkToplamOrt);
            this.panel2.Controls.Add(this.checkMotorOrt);
            this.panel2.Controls.Add(this.checkIsiticiOrt);
            this.panel2.Location = new System.Drawing.Point(406, 20);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(200, 110);
            this.panel2.TabIndex = 27;
            // 
            // checkFanOrt
            // 
            this.checkFanOrt.AutoSize = true;
            this.checkFanOrt.Location = new System.Drawing.Point(3, 82);
            this.checkFanOrt.Name = "checkFanOrt";
            this.checkFanOrt.Size = new System.Drawing.Size(153, 20);
            this.checkFanOrt.TabIndex = 19;
            this.checkFanOrt.Text = "Fan Ortalama Göster";
            this.checkFanOrt.UseVisualStyleBackColor = true;
            this.checkFanOrt.Visible = false;
            this.checkFanOrt.CheckedChanged += new System.EventHandler(this.checkFanOrt_CheckedChanged);
            // 
            // checkToplamOrt
            // 
            this.checkToplamOrt.AutoSize = true;
            this.checkToplamOrt.Location = new System.Drawing.Point(3, 4);
            this.checkToplamOrt.Name = "checkToplamOrt";
            this.checkToplamOrt.Size = new System.Drawing.Size(177, 20);
            this.checkToplamOrt.TabIndex = 16;
            this.checkToplamOrt.Text = "Toplam Ortalama Göster";
            this.checkToplamOrt.UseVisualStyleBackColor = true;
            this.checkToplamOrt.Visible = false;
            this.checkToplamOrt.CheckedChanged += new System.EventHandler(this.checkToplamOrt_CheckedChanged);
            // 
            // checkMotorOrt
            // 
            this.checkMotorOrt.AutoSize = true;
            this.checkMotorOrt.Location = new System.Drawing.Point(3, 56);
            this.checkMotorOrt.Name = "checkMotorOrt";
            this.checkMotorOrt.Size = new System.Drawing.Size(164, 20);
            this.checkMotorOrt.TabIndex = 18;
            this.checkMotorOrt.Text = "Motor Ortalama Göster";
            this.checkMotorOrt.UseVisualStyleBackColor = true;
            this.checkMotorOrt.Visible = false;
            this.checkMotorOrt.CheckedChanged += new System.EventHandler(this.checkMotorOrt_CheckedChanged);
            // 
            // checkIsiticiOrt
            // 
            this.checkIsiticiOrt.AutoSize = true;
            this.checkIsiticiOrt.Location = new System.Drawing.Point(3, 30);
            this.checkIsiticiOrt.Name = "checkIsiticiOrt";
            this.checkIsiticiOrt.Size = new System.Drawing.Size(159, 20);
            this.checkIsiticiOrt.TabIndex = 17;
            this.checkIsiticiOrt.Text = "Isıtıcı Ortalama Göster";
            this.checkIsiticiOrt.UseVisualStyleBackColor = true;
            this.checkIsiticiOrt.Visible = false;
            this.checkIsiticiOrt.CheckedChanged += new System.EventHandler(this.checkIsiticiOrt_CheckedChanged);
            // 
            // datePickerStart
            // 
            this.datePickerStart.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.datePickerStart.Location = new System.Drawing.Point(75, 50);
            this.datePickerStart.Name = "datePickerStart";
            this.datePickerStart.Size = new System.Drawing.Size(103, 22);
            this.datePickerStart.TabIndex = 28;
            this.datePickerStart.ValueChanged += new System.EventHandler(this.datePickerStart_ValueChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.btnOtomatikDoldur);
            this.groupBox2.Controls.Add(this.datePickerStart);
            this.groupBox2.Controls.Add(this.panel2);
            this.groupBox2.Controls.Add(this.panel1);
            this.groupBox2.Controls.Add(this.datePickerEnd);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.cmbMakine);
            this.groupBox2.Location = new System.Drawing.Point(12, 11);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Size = new System.Drawing.Size(1388, 136);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            // 
            // btnOtomatikDoldur
            // 
            this.btnOtomatikDoldur.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOtomatikDoldur.Location = new System.Drawing.Point(612, 19);
            this.btnOtomatikDoldur.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnOtomatikDoldur.Name = "btnOtomatikDoldur";
            this.btnOtomatikDoldur.Size = new System.Drawing.Size(157, 111);
            this.btnOtomatikDoldur.TabIndex = 31;
            this.btnOtomatikDoldur.Text = "Otomatik Doldur";
            this.btnOtomatikDoldur.UseVisualStyleBackColor = true;
            this.btnOtomatikDoldur.Visible = false;
            this.btnOtomatikDoldur.Click += new System.EventHandler(this.btnOtomatikDoldur_Click);
            // 
            // dataViewSayac
            // 
            this.dataViewSayac.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataViewSayac.Location = new System.Drawing.Point(12, 152);
            this.dataViewSayac.Name = "dataViewSayac";
            this.dataViewSayac.RowHeadersWidth = 51;
            this.dataViewSayac.RowTemplate.Height = 24;
            this.dataViewSayac.Size = new System.Drawing.Size(606, 470);
            this.dataViewSayac.TabIndex = 12;
            this.dataViewSayac.Scroll += new System.Windows.Forms.ScrollEventHandler(this.dataViewSayac_Scroll);
            // 
            // dataViewSaatlik
            // 
            this.dataViewSaatlik.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataViewSaatlik.Location = new System.Drawing.Point(12, 628);
            this.dataViewSaatlik.Name = "dataViewSaatlik";
            this.dataViewSaatlik.RowHeadersWidth = 51;
            this.dataViewSaatlik.RowTemplate.Height = 24;
            this.dataViewSaatlik.Size = new System.Drawing.Size(606, 470);
            this.dataViewSaatlik.TabIndex = 13;
            this.dataViewSaatlik.Scroll += new System.Windows.Forms.ScrollEventHandler(this.dataViewSaatlik_Scroll);
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusLabel});
            this.statusStrip1.Location = new System.Drawing.Point(0, 1153);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1412, 22);
            this.statusStrip1.TabIndex = 14;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // statusLabel
            // 
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(0, 16);
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ayarlarToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1412, 30);
            this.menuStrip1.TabIndex = 15;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // ayarlarToolStripMenuItem
            // 
            this.ayarlarToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.düzenlemeyiAçKapatToolStripMenuItem});
            this.ayarlarToolStripMenuItem.Name = "ayarlarToolStripMenuItem";
            this.ayarlarToolStripMenuItem.Size = new System.Drawing.Size(70, 26);
            this.ayarlarToolStripMenuItem.Text = "Ayarlar";
            // 
            // düzenlemeyiAçKapatToolStripMenuItem
            // 
            this.düzenlemeyiAçKapatToolStripMenuItem.Name = "düzenlemeyiAçKapatToolStripMenuItem";
            this.düzenlemeyiAçKapatToolStripMenuItem.Size = new System.Drawing.Size(252, 26);
            this.düzenlemeyiAçKapatToolStripMenuItem.Text = "Düzenlemeyi Aç / Kapat";
            this.düzenlemeyiAçKapatToolStripMenuItem.Click += new System.EventHandler(this.düzenlemeyiAçKapatToolStripMenuItem_Click);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.AutoScroll = true;
            this.panel3.Controls.Add(this.chart1);
            this.panel3.Location = new System.Drawing.Point(624, 152);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(776, 946);
            this.panel3.TabIndex = 16;
            // 
            // chart1
            // 
            lineAnnotation9.AxisXName = "areaSayac\\rX";
            lineAnnotation9.Height = 5D;
            lineAnnotation9.LineWidth = 2;
            lineAnnotation9.Name = "lineOrtalama";
            lineAnnotation9.Width = 151D;
            lineAnnotation9.X = 5D;
            lineAnnotation9.Y = 90D;
            lineAnnotation9.YAxisName = "areaSayac\\rY";
            this.chart1.Annotations.Add(lineAnnotation9);
            this.chart1.BorderSkin.PageColor = System.Drawing.Color.DarkGray;
            chartArea9.AlignmentOrientation = ((System.Windows.Forms.DataVisualization.Charting.AreaAlignmentOrientations)((System.Windows.Forms.DataVisualization.Charting.AreaAlignmentOrientations.Vertical | System.Windows.Forms.DataVisualization.Charting.AreaAlignmentOrientations.Horizontal)));
            chartArea9.Area3DStyle.Rotation = 90;
            chartArea9.IsSameFontSizeForAllAxes = true;
            chartArea9.Name = "areaSayac";
            chartArea9.Position.Auto = false;
            chartArea9.Position.Height = 89.11073F;
            chartArea9.Position.Width = 77.3459F;
            chartArea9.Position.X = 3F;
            chartArea9.Position.Y = 7.889268F;
            this.chart1.ChartAreas.Add(chartArea9);
            legend9.ForeColor = System.Drawing.Color.IndianRed;
            legend9.Name = "Legend1";
            this.chart1.Legends.Add(legend9);
            this.chart1.Location = new System.Drawing.Point(3, 3);
            this.chart1.Name = "chart1";
            series25.ChartArea = "areaSayac";
            series25.LabelBackColor = System.Drawing.Color.Gray;
            series25.Legend = "Legend1";
            series25.Name = "Series1";
            series26.ChartArea = "areaSayac";
            series26.Legend = "Legend1";
            series26.Name = "Series2";
            series27.ChartArea = "areaSayac";
            series27.Legend = "Legend1";
            series27.Name = "Series3";
            this.chart1.Series.Add(series25);
            this.chart1.Series.Add(series26);
            this.chart1.Series.Add(series27);
            this.chart1.Size = new System.Drawing.Size(770, 863);
            this.chart1.TabIndex = 12;
            this.chart1.Text = "chart1";
            title9.ForeColor = System.Drawing.Color.IndianRed;
            title9.Name = "Title1";
            this.chart1.Titles.Add(title9);
            // 
            // saatlikForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1412, 1175);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.dataViewSaatlik);
            this.Controls.Add(this.dataViewSayac);
            this.Controls.Add(this.groupBox2);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "saatlikForm";
            this.Text = "Saatlik Sayaç Verileri";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.saatlikForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataViewSayac)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataViewSaatlik)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DateTimePicker da;
        private System.Windows.Forms.ComboBox cmbMakine;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker datePickerEnd;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckBox checkToplam;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.CheckBox checkBox3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.CheckBox checkFanOrt;
        private System.Windows.Forms.CheckBox checkToplamOrt;
        private System.Windows.Forms.CheckBox checkMotorOrt;
        private System.Windows.Forms.CheckBox checkIsiticiOrt;
        private System.Windows.Forms.DateTimePicker datePickerStart;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dataViewSayac;
        private System.Windows.Forms.DataGridView dataViewSaatlik;
        private System.Windows.Forms.Button btnOtomatikDoldur;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel statusLabel;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem ayarlarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem düzenlemeyiAçKapatToolStripMenuItem;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
    }
}