namespace SayacRapor
{
    partial class haftalikGrafik
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
            System.Windows.Forms.DataVisualization.Charting.LineAnnotation lineAnnotation2 = new System.Windows.Forms.DataVisualization.Charting.LineAnnotation();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series5 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series6 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title2 = new System.Windows.Forms.DataVisualization.Charting.Title();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnGrafikOlustur = new System.Windows.Forms.Button();
            this.datePickerEnd = new System.Windows.Forms.DateTimePicker();
            this.datePickerStart = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbMakine = new System.Windows.Forms.ComboBox();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.etiketleriGösterGizleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.maksimumGösterGizleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ortalamaGösterGizleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.minimumGösterGizleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.progressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.btnGrafikOlustur);
            this.groupBox2.Controls.Add(this.datePickerEnd);
            this.groupBox2.Controls.Add(this.datePickerStart);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.cmbMakine);
            this.groupBox2.Location = new System.Drawing.Point(12, 44);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Size = new System.Drawing.Size(1386, 96);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            // 
            // btnGrafikOlustur
            // 
            this.btnGrafikOlustur.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGrafikOlustur.Location = new System.Drawing.Point(301, 20);
            this.btnGrafikOlustur.Name = "btnGrafikOlustur";
            this.btnGrafikOlustur.Size = new System.Drawing.Size(152, 68);
            this.btnGrafikOlustur.TabIndex = 26;
            this.btnGrafikOlustur.Text = "Grafik Oluştur";
            this.btnGrafikOlustur.UseVisualStyleBackColor = true;
            this.btnGrafikOlustur.Click += new System.EventHandler(this.btnGrafikOlustur_Click);
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
            // datePickerStart
            // 
            this.datePickerStart.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.datePickerStart.Location = new System.Drawing.Point(75, 50);
            this.datePickerStart.Name = "datePickerStart";
            this.datePickerStart.Size = new System.Drawing.Size(103, 22);
            this.datePickerStart.TabIndex = 24;
            this.datePickerStart.ValueChanged += new System.EventHandler(this.datePickerStart_ValueChanged);
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
            this.cmbMakine.SelectedIndexChanged += new System.EventHandler(this.cmbMakine_SelectedIndexChanged_1);
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
            this.chart1.Location = new System.Drawing.Point(12, 145);
            this.chart1.Name = "chart1";
            series4.ChartArea = "areaSayac";
            series4.Legend = "Legend1";
            series4.Name = "Max";
            series5.ChartArea = "areaSayac";
            series5.Legend = "Legend1";
            series5.Name = "Ort";
            series6.ChartArea = "areaSayac";
            series6.Legend = "Legend1";
            series6.Name = "Min";
            this.chart1.Series.Add(series4);
            this.chart1.Series.Add(series5);
            this.chart1.Series.Add(series6);
            this.chart1.Size = new System.Drawing.Size(400, 650);
            this.chart1.TabIndex = 11;
            this.chart1.Text = "chart1";
            title2.Name = "Title1";
            this.chart1.Titles.Add(title2);
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.etiketleriGösterGizleToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1494, 28);
            this.menuStrip1.TabIndex = 12;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // etiketleriGösterGizleToolStripMenuItem
            // 
            this.etiketleriGösterGizleToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.maksimumGösterGizleToolStripMenuItem,
            this.ortalamaGösterGizleToolStripMenuItem,
            this.minimumGösterGizleToolStripMenuItem});
            this.etiketleriGösterGizleToolStripMenuItem.Name = "etiketleriGösterGizleToolStripMenuItem";
            this.etiketleriGösterGizleToolStripMenuItem.Size = new System.Drawing.Size(175, 24);
            this.etiketleriGösterGizleToolStripMenuItem.Text = "Etiketleri Göster / Gizle";
            // 
            // maksimumGösterGizleToolStripMenuItem
            // 
            this.maksimumGösterGizleToolStripMenuItem.Name = "maksimumGösterGizleToolStripMenuItem";
            this.maksimumGösterGizleToolStripMenuItem.Size = new System.Drawing.Size(258, 26);
            this.maksimumGösterGizleToolStripMenuItem.Text = "Maksimum Göster / Gizle";
            this.maksimumGösterGizleToolStripMenuItem.Click += new System.EventHandler(this.maksimumGösterGizleToolStripMenuItem_Click);
            // 
            // ortalamaGösterGizleToolStripMenuItem
            // 
            this.ortalamaGösterGizleToolStripMenuItem.Name = "ortalamaGösterGizleToolStripMenuItem";
            this.ortalamaGösterGizleToolStripMenuItem.Size = new System.Drawing.Size(258, 26);
            this.ortalamaGösterGizleToolStripMenuItem.Text = "Ortalama Göster / Gizle";
            this.ortalamaGösterGizleToolStripMenuItem.Click += new System.EventHandler(this.ortalamaGösterGizleToolStripMenuItem_Click);
            // 
            // minimumGösterGizleToolStripMenuItem
            // 
            this.minimumGösterGizleToolStripMenuItem.Name = "minimumGösterGizleToolStripMenuItem";
            this.minimumGösterGizleToolStripMenuItem.Size = new System.Drawing.Size(258, 26);
            this.minimumGösterGizleToolStripMenuItem.Text = "Minimum Göster / Gizle";
            this.minimumGösterGizleToolStripMenuItem.Click += new System.EventHandler(this.minimumGösterGizleToolStripMenuItem_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.progressBar});
            this.statusStrip1.Location = new System.Drawing.Point(0, 795);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1494, 23);
            this.statusStrip1.TabIndex = 13;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // progressBar
            // 
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(100, 15);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // haftalikGrafik
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1494, 818);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "haftalikGrafik";
            this.Text = "Sayaç Haftalık Grafik Raporu";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.haftalikGrafik_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbMakine;
        private System.Windows.Forms.DateTimePicker datePickerEnd;
        private System.Windows.Forms.DateTimePicker datePickerStart;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.Button btnGrafikOlustur;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem etiketleriGösterGizleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem maksimumGösterGizleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ortalamaGösterGizleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem minimumGösterGizleToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripProgressBar progressBar;
        private System.Windows.Forms.Timer timer1;
    }
}