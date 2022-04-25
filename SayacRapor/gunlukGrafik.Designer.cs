namespace SayacRapor
{
    partial class gunlukGrafik
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
            System.Windows.Forms.DataVisualization.Charting.LineAnnotation lineAnnotation2 = new System.Windows.Forms.DataVisualization.Charting.LineAnnotation();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series5 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series6 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title2 = new System.Windows.Forms.DataVisualization.Charting.Title();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.checkFanOrt = new System.Windows.Forms.CheckBox();
            this.checkToplamOrt = new System.Windows.Forms.CheckBox();
            this.checkMotorOrt = new System.Windows.Forms.CheckBox();
            this.checkIsiticiOrt = new System.Windows.Forms.CheckBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.checkToplam = new System.Windows.Forms.CheckBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbMakine = new System.Windows.Forms.ComboBox();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.etiketleriGösterGizleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toplamGösterGizleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ısıtıcıGösterGizleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.motorGösterGizleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fanGösterGizleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox2.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.panel2);
            this.groupBox2.Controls.Add(this.panel1);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.cmbMakine);
            this.groupBox2.Location = new System.Drawing.Point(12, 30);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Size = new System.Drawing.Size(1795, 138);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
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
            this.panel2.TabIndex = 23;
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
            this.panel1.TabIndex = 22;
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
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 16);
            this.label2.TabIndex = 11;
            this.label2.Text = "Makine:";
            // 
            // cmbMakine
            // 
            this.cmbMakine.FormattingEnabled = true;
            this.cmbMakine.Location = new System.Drawing.Point(75, 20);
            this.cmbMakine.Name = "cmbMakine";
            this.cmbMakine.Size = new System.Drawing.Size(220, 24);
            this.cmbMakine.TabIndex = 10;
            this.cmbMakine.SelectedIndexChanged += new System.EventHandler(this.cmbMakine_SelectedIndexChanged);
            // 
            // chart1
            // 
            lineAnnotation2.AxisXName = "areaSayac\\rX";
            lineAnnotation2.Height = 5D;
            lineAnnotation2.LineWidth = 2;
            lineAnnotation2.Name = "lineOrtalama";
            lineAnnotation2.Width = 151D;
            lineAnnotation2.X = 5D;
            lineAnnotation2.Y = 90D;
            lineAnnotation2.YAxisName = "areaSayac\\rY";
            this.chart1.Annotations.Add(lineAnnotation2);
            chartArea2.AlignmentOrientation = ((System.Windows.Forms.DataVisualization.Charting.AreaAlignmentOrientations)((System.Windows.Forms.DataVisualization.Charting.AreaAlignmentOrientations.Vertical | System.Windows.Forms.DataVisualization.Charting.AreaAlignmentOrientations.Horizontal)));
            chartArea2.Area3DStyle.Rotation = 90;
            chartArea2.IsSameFontSizeForAllAxes = true;
            chartArea2.Name = "areaSayac";
            this.chart1.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.chart1.Legends.Add(legend2);
            this.chart1.Location = new System.Drawing.Point(12, 173);
            this.chart1.Name = "chart1";
            series4.ChartArea = "areaSayac";
            series4.Legend = "Legend1";
            series4.Name = "Series1";
            series5.ChartArea = "areaSayac";
            series5.Legend = "Legend1";
            series5.Name = "Series2";
            series6.ChartArea = "areaSayac";
            series6.Legend = "Legend1";
            series6.Name = "Series3";
            this.chart1.Series.Add(series4);
            this.chart1.Series.Add(series5);
            this.chart1.Series.Add(series6);
            this.chart1.Size = new System.Drawing.Size(400, 650);
            this.chart1.TabIndex = 10;
            this.chart1.Text = "chart1";
            title2.Name = "Title1";
            this.chart1.Titles.Add(title2);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.menuStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.etiketleriGösterGizleToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(335, 30);
            this.menuStrip1.TabIndex = 11;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // etiketleriGösterGizleToolStripMenuItem
            // 
            this.etiketleriGösterGizleToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toplamGösterGizleToolStripMenuItem,
            this.ısıtıcıGösterGizleToolStripMenuItem,
            this.motorGösterGizleToolStripMenuItem,
            this.fanGösterGizleToolStripMenuItem});
            this.etiketleriGösterGizleToolStripMenuItem.Name = "etiketleriGösterGizleToolStripMenuItem";
            this.etiketleriGösterGizleToolStripMenuItem.Size = new System.Drawing.Size(175, 24);
            this.etiketleriGösterGizleToolStripMenuItem.Text = "Etiketleri Göster / Gizle";
            // 
            // toplamGösterGizleToolStripMenuItem
            // 
            this.toplamGösterGizleToolStripMenuItem.Name = "toplamGösterGizleToolStripMenuItem";
            this.toplamGösterGizleToolStripMenuItem.Size = new System.Drawing.Size(236, 26);
            this.toplamGösterGizleToolStripMenuItem.Text = "Toplam Göster / Gizle";
            this.toplamGösterGizleToolStripMenuItem.Click += new System.EventHandler(this.toplamGösterGizleToolStripMenuItem_Click);
            // 
            // ısıtıcıGösterGizleToolStripMenuItem
            // 
            this.ısıtıcıGösterGizleToolStripMenuItem.Name = "ısıtıcıGösterGizleToolStripMenuItem";
            this.ısıtıcıGösterGizleToolStripMenuItem.Size = new System.Drawing.Size(236, 26);
            this.ısıtıcıGösterGizleToolStripMenuItem.Text = "Isıtıcı Göster / Gizle";
            this.ısıtıcıGösterGizleToolStripMenuItem.Click += new System.EventHandler(this.ısıtıcıGösterGizleToolStripMenuItem_Click);
            // 
            // motorGösterGizleToolStripMenuItem
            // 
            this.motorGösterGizleToolStripMenuItem.Name = "motorGösterGizleToolStripMenuItem";
            this.motorGösterGizleToolStripMenuItem.Size = new System.Drawing.Size(236, 26);
            this.motorGösterGizleToolStripMenuItem.Text = "Motor Göster / Gizle";
            this.motorGösterGizleToolStripMenuItem.Click += new System.EventHandler(this.motorGösterGizleToolStripMenuItem_Click);
            // 
            // fanGösterGizleToolStripMenuItem
            // 
            this.fanGösterGizleToolStripMenuItem.Name = "fanGösterGizleToolStripMenuItem";
            this.fanGösterGizleToolStripMenuItem.Size = new System.Drawing.Size(236, 26);
            this.fanGösterGizleToolStripMenuItem.Text = "Fan Göster / Gizle";
            this.fanGösterGizleToolStripMenuItem.Click += new System.EventHandler(this.fanGösterGizleToolStripMenuItem_Click);
            // 
            // gunlukGrafik
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1882, 799);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "gunlukGrafik";
            this.Text = "Sayaç Günlük Grafik Raporu";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.gunlukGrafik_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbMakine;
        private System.Windows.Forms.CheckBox checkToplam;
        private System.Windows.Forms.CheckBox checkBox3;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.CheckBox checkFanOrt;
        private System.Windows.Forms.CheckBox checkMotorOrt;
        private System.Windows.Forms.CheckBox checkIsiticiOrt;
        private System.Windows.Forms.CheckBox checkToplamOrt;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem etiketleriGösterGizleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toplamGösterGizleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ısıtıcıGösterGizleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem motorGösterGizleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fanGösterGizleToolStripMenuItem;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
    }
}