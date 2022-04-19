namespace SayacRapor
{
    partial class SayacSettings
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabSayacGoruntule = new System.Windows.Forms.TabPage();
            this.btnSayacSil = new System.Windows.Forms.Button();
            this.dataViewSettings = new System.Windows.Forms.DataGridView();
            this.tabSayacEkle = new System.Windows.Forms.TabPage();
            this.txtSayacCarpan = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.radioIsitici = new System.Windows.Forms.RadioButton();
            this.radioMotor = new System.Windows.Forms.RadioButton();
            this.txtSayacSira = new System.Windows.Forms.NumericUpDown();
            this.btnSayacEkle = new System.Windows.Forms.Button();
            this.txtSayacExtra = new System.Windows.Forms.TextBox();
            this.txtSayacMin = new System.Windows.Forms.TextBox();
            this.txtSayacIsım = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabSayacGoruntule.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataViewSettings)).BeginInit();
            this.tabSayacEkle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtSayacSira)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabSayacGoruntule);
            this.tabControl1.Controls.Add(this.tabSayacEkle);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(975, 615);
            this.tabControl1.TabIndex = 0;
            // 
            // tabSayacGoruntule
            // 
            this.tabSayacGoruntule.Controls.Add(this.button1);
            this.tabSayacGoruntule.Controls.Add(this.btnSayacSil);
            this.tabSayacGoruntule.Controls.Add(this.dataViewSettings);
            this.tabSayacGoruntule.Location = new System.Drawing.Point(4, 25);
            this.tabSayacGoruntule.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabSayacGoruntule.Name = "tabSayacGoruntule";
            this.tabSayacGoruntule.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabSayacGoruntule.Size = new System.Drawing.Size(967, 586);
            this.tabSayacGoruntule.TabIndex = 0;
            this.tabSayacGoruntule.Text = "Sayacları Görüntüle";
            this.tabSayacGoruntule.UseVisualStyleBackColor = true;
            // 
            // btnSayacSil
            // 
            this.btnSayacSil.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSayacSil.Location = new System.Drawing.Point(743, 514);
            this.btnSayacSil.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSayacSil.Name = "btnSayacSil";
            this.btnSayacSil.Size = new System.Drawing.Size(195, 42);
            this.btnSayacSil.TabIndex = 1;
            this.btnSayacSil.Text = "Seçilen Sayacı Sil";
            this.btnSayacSil.UseVisualStyleBackColor = true;
            this.btnSayacSil.Click += new System.EventHandler(this.btnSayacSil_Click);
            // 
            // dataViewSettings
            // 
            this.dataViewSettings.AllowUserToAddRows = false;
            this.dataViewSettings.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataViewSettings.Location = new System.Drawing.Point(5, 6);
            this.dataViewSettings.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataViewSettings.Name = "dataViewSettings";
            this.dataViewSettings.RowHeadersWidth = 51;
            this.dataViewSettings.RowTemplate.Height = 24;
            this.dataViewSettings.Size = new System.Drawing.Size(931, 502);
            this.dataViewSettings.TabIndex = 0;
            this.dataViewSettings.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dataViewSettings_CellBeginEdit);
            this.dataViewSettings.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataViewSettings_CellContentClick);
            this.dataViewSettings.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataViewSettings_CellValueChanged);
            // 
            // tabSayacEkle
            // 
            this.tabSayacEkle.Controls.Add(this.txtSayacCarpan);
            this.tabSayacEkle.Controls.Add(this.label5);
            this.tabSayacEkle.Controls.Add(this.radioIsitici);
            this.tabSayacEkle.Controls.Add(this.radioMotor);
            this.tabSayacEkle.Controls.Add(this.txtSayacSira);
            this.tabSayacEkle.Controls.Add(this.btnSayacEkle);
            this.tabSayacEkle.Controls.Add(this.txtSayacExtra);
            this.tabSayacEkle.Controls.Add(this.txtSayacMin);
            this.tabSayacEkle.Controls.Add(this.txtSayacIsım);
            this.tabSayacEkle.Controls.Add(this.label4);
            this.tabSayacEkle.Controls.Add(this.label3);
            this.tabSayacEkle.Controls.Add(this.label2);
            this.tabSayacEkle.Controls.Add(this.label1);
            this.tabSayacEkle.Location = new System.Drawing.Point(4, 25);
            this.tabSayacEkle.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabSayacEkle.Name = "tabSayacEkle";
            this.tabSayacEkle.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabSayacEkle.Size = new System.Drawing.Size(967, 586);
            this.tabSayacEkle.TabIndex = 1;
            this.tabSayacEkle.Text = "Sayaç Ekle";
            this.tabSayacEkle.UseVisualStyleBackColor = true;
            // 
            // txtSayacCarpan
            // 
            this.txtSayacCarpan.Location = new System.Drawing.Point(380, 82);
            this.txtSayacCarpan.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtSayacCarpan.Name = "txtSayacCarpan";
            this.txtSayacCarpan.Size = new System.Drawing.Size(211, 22);
            this.txtSayacCarpan.TabIndex = 2;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(277, 86);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(96, 16);
            this.label5.TabIndex = 12;
            this.label5.Text = "Sayaç Çarpan:";
            // 
            // radioIsitici
            // 
            this.radioIsitici.AutoSize = true;
            this.radioIsitici.Location = new System.Drawing.Point(380, 167);
            this.radioIsitici.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.radioIsitici.Name = "radioIsitici";
            this.radioIsitici.Size = new System.Drawing.Size(102, 20);
            this.radioIsitici.TabIndex = 5;
            this.radioIsitici.TabStop = true;
            this.radioIsitici.Text = "Isıtıcı Sayacı";
            this.radioIsitici.UseVisualStyleBackColor = true;
            // 
            // radioMotor
            // 
            this.radioMotor.AutoSize = true;
            this.radioMotor.Location = new System.Drawing.Point(496, 167);
            this.radioMotor.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.radioMotor.Name = "radioMotor";
            this.radioMotor.Size = new System.Drawing.Size(107, 20);
            this.radioMotor.TabIndex = 6;
            this.radioMotor.TabStop = true;
            this.radioMotor.Text = "Motor Sayacı";
            this.radioMotor.UseVisualStyleBackColor = true;
            // 
            // txtSayacSira
            // 
            this.txtSayacSira.Location = new System.Drawing.Point(380, 28);
            this.txtSayacSira.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtSayacSira.Name = "txtSayacSira";
            this.txtSayacSira.Size = new System.Drawing.Size(211, 22);
            this.txtSayacSira.TabIndex = 1;
            // 
            // btnSayacEkle
            // 
            this.btnSayacEkle.Location = new System.Drawing.Point(380, 208);
            this.btnSayacEkle.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSayacEkle.Name = "btnSayacEkle";
            this.btnSayacEkle.Size = new System.Drawing.Size(211, 78);
            this.btnSayacEkle.TabIndex = 7;
            this.btnSayacEkle.Text = "Sayaç Ekle";
            this.btnSayacEkle.UseVisualStyleBackColor = true;
            this.btnSayacEkle.Click += new System.EventHandler(this.btnSayacEkle_Click);
            // 
            // txtSayacExtra
            // 
            this.txtSayacExtra.Location = new System.Drawing.Point(380, 139);
            this.txtSayacExtra.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtSayacExtra.Name = "txtSayacExtra";
            this.txtSayacExtra.Size = new System.Drawing.Size(211, 22);
            this.txtSayacExtra.TabIndex = 4;
            // 
            // txtSayacMin
            // 
            this.txtSayacMin.Location = new System.Drawing.Point(380, 111);
            this.txtSayacMin.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtSayacMin.Name = "txtSayacMin";
            this.txtSayacMin.Size = new System.Drawing.Size(211, 22);
            this.txtSayacMin.TabIndex = 3;
            // 
            // txtSayacIsım
            // 
            this.txtSayacIsım.Location = new System.Drawing.Point(380, 55);
            this.txtSayacIsım.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtSayacIsım.Name = "txtSayacIsım";
            this.txtSayacIsım.Size = new System.Drawing.Size(211, 22);
            this.txtSayacIsım.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(272, 142);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(102, 16);
            this.label4.TabIndex = 3;
            this.label4.Text = "Ekstra Tüketim: ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(295, 30);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "Sayaç Sıra: ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(292, 114);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Min Tüketim:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(299, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Sayaç İsim:";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(542, 514);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(195, 42);
            this.button1.TabIndex = 2;
            this.button1.Text = "Yeni Satır Ekle";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // SayacSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(975, 615);
            this.Controls.Add(this.tabControl1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "SayacSettings";
            this.Text = "Sayaç Ayarları";
            this.Load += new System.EventHandler(this.SayacSettings_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabSayacGoruntule.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataViewSettings)).EndInit();
            this.tabSayacEkle.ResumeLayout(false);
            this.tabSayacEkle.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtSayacSira)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabSayacGoruntule;
        private System.Windows.Forms.TabPage tabSayacEkle;
        private System.Windows.Forms.Button btnSayacSil;
        private System.Windows.Forms.DataGridView dataViewSettings;
        private System.Windows.Forms.Button btnSayacEkle;
        private System.Windows.Forms.TextBox txtSayacExtra;
        private System.Windows.Forms.TextBox txtSayacMin;
        private System.Windows.Forms.TextBox txtSayacIsım;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown txtSayacSira;
        private System.Windows.Forms.RadioButton radioIsitici;
        private System.Windows.Forms.RadioButton radioMotor;
        private System.Windows.Forms.TextBox txtSayacCarpan;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button1;
    }
}