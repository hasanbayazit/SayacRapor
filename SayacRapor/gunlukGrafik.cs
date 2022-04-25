using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace SayacRapor
{
    public partial class gunlukGrafik : Form
    {
        public gunlukGrafik()
        {
            InitializeComponent();
        }
        int genislik;
        public DataTable gelenTablo = new DataTable();
        public int haftaSayisi;
        string isitici, motor, fan;
        int indexIsitici, indexMotor, indexFan, indexOrt;
        double isiticiOrt = 0, toplamOrt = 0, motorOrt = 0, fanOrt = 0;
        string makineAdi = "";
        bool toplamGG = true, isiticiGG = true, motorGG = true, fanGG = true;
        DataTable gunlukSayacGrafikVerileri = new DataTable();
        
        public ArrayList makineIsimleri = new ArrayList();
        SqlConnection con = new SqlConnection(MainForm.conString);

        private void ısıtıcıGösterGizleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!isiticiGG)
                isiticiGG = true;
            else
                isiticiGG = false;
            grafikOlustur();
        }

        private void motorGösterGizleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!motorGG)
                motorGG = true;
            else
                motorGG = false;
            grafikOlustur();
        }

        private void fanGösterGizleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!fanGG)
                fanGG = true;
            else
                fanGG = false;
            grafikOlustur();
        }

        private void gunlukGrafik_Load(object sender, EventArgs e)
        {
            gunlukSayacGrafikVerileri.Clear();
            gunlukSayacGrafikVerileri.Columns.Clear();
            gunlukSayacGrafikVerileri = gelenTablo.Copy();
            if (gunlukSayacGrafikVerileri.Rows.Count > 0)
            {
                gunlukSayacGrafikVerileri.Rows[gunlukSayacGrafikVerileri.Rows.Count - 1].Delete();
                gunlukSayacGrafikVerileri.Rows[0].Delete();
            }
            gunlukSayacGrafikVerileri.AcceptChanges();
            con.Open();
            string makineString = "Select DISTINCT makine_adi From SAYAC_AYAR ";
            SqlCommand makineCommand = new SqlCommand(makineString, con);
            SqlDataReader makineReader = makineCommand.ExecuteReader();
            while (makineReader.Read())
            {
                cmbMakine.Items.Add(makineReader[0]);
            }
            makineReader.Close();
            con.Close();
        }

        private void cmbMakine_SelectedIndexChanged(object sender, EventArgs e)
        {
            gizle();
            makineAdi = cmbMakine.SelectedItem.ToString();
            con.Open();
            string sayacIsimString = "Select id,sayac_isim From SAYAC_AYAR WHERE makine_adi = '"+makineAdi+ "'  ORDER BY id";
            SqlCommand sayacIsimCommand = new SqlCommand(sayacIsimString, con);
            SqlDataReader sayacIsimReader = sayacIsimCommand.ExecuteReader();
            int i = 0;
            while (sayacIsimReader.Read())
            {
                if (i == 0)
                {
                    checkBox1.Visible = true;
                    checkIsiticiOrt.Visible = true;
                    checkBox1.Text = sayacIsimReader["sayac_isim"].ToString();
                }
                else if (i == 1) 
                {
                    checkBox2.Visible = true;
                    checkMotorOrt.Visible = true;
                    checkBox2.Text = sayacIsimReader["sayac_isim"].ToString();
                }
                else if (i == 2)
                {
                    checkBox3.Visible = true;
                    checkFanOrt.Visible = true;
                    checkBox3.Text = sayacIsimReader["sayac_isim"].ToString();
                }
                if(i>0)
                {
                    checkToplam.Visible = true;
                    checkToplamOrt.Visible = true;
                }
                i++;
            }
            sayacIsimReader.Close();
            con.Close();
            grafikOlustur();
            int xLokasyon = panel1.Width + panel1.Location.X + 10;
            panel2.Location = new Point(xLokasyon, panel1.Location.Y);
        }

        private void toplamGösterGizleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!toplamGG)
                toplamGG = true;
            else
                toplamGG = false;
            grafikOlustur();
        }

        private void checkToplam_CheckedChanged(object sender, EventArgs e)
        {
            grafikOlustur();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            grafikOlustur();
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            grafikOlustur();
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            grafikOlustur();
        }

        private void checkFanOrt_CheckedChanged(object sender, EventArgs e)
        {
            grafikOlustur();
        }

        private void checkMotorOrt_CheckedChanged(object sender, EventArgs e)
        {
            grafikOlustur();
        }

        private void checkIsiticiOrt_CheckedChanged(object sender, EventArgs e)
        {
            grafikOlustur();
        }

        private void checkToplamOrt_CheckedChanged(object sender, EventArgs e)
        {
            grafikOlustur();
        }

        void gizle()
        {
            checkBox1.Visible = false;
            checkBox2.Visible = false;
            checkBox3.Visible = false;
            checkToplam.Visible = false;
            checkIsiticiOrt.Visible = false;
            checkMotorOrt.Visible = false;
            checkFanOrt.Visible = false;
            checkToplamOrt.Visible = false;
        }

        void grafikOlustur()
        {
            genislik = 1;
            try
            {
                if (checkBox1.Visible == false)
                {
                    checkBox1.Checked = false;
                    checkIsiticiOrt.Checked = false;
                }
                if (checkBox2.Visible == false)
                {
                    checkBox2.Checked = false;
                    checkMotorOrt.Checked = false;
                }
                if (checkBox3.Visible == false)
                {
                    checkBox3.Checked = false;
                    checkFanOrt.Checked = false;
                }
                if (checkToplam.Visible == false)
                {
                    checkToplam.Checked = false;
                    checkToplamOrt.Checked = false;
                }
                isitici = checkBox1.Text;
                motor = checkBox2.Text;
                fan = checkBox3.Text;
                indexIsitici = gunlukSayacGrafikVerileri.Columns.IndexOf(isitici);
                indexMotor = gunlukSayacGrafikVerileri.Columns.IndexOf(motor);
                indexFan = gunlukSayacGrafikVerileri.Columns.IndexOf(fan);
                indexOrt = gunlukSayacGrafikVerileri.Rows.Count - 1;
                chart1.ChartAreas.Clear();
                chart1.ChartAreas.Add("areaSayac");
                chart1.Width = 400;
                chart1.Series.Clear();
                chart1.Series.Add("Toplam");
                chart1.Series.Add("Isitici");
                chart1.Series.Add("Motor");
                chart1.Series.Add("Fan");
                chart1.Series.Add("Toplam Ortalama");
                chart1.Series.Add("Isıtıcı Ortalama");
                chart1.Series.Add("Motor Ortalama");
                chart1.Series.Add("Fan Ortalama");
                toplamOrt = 0; isiticiOrt = 0; motorOrt = 0; fanOrt = 0;
                double toplamDeger = 0, isiticiDeger = 0, motorDeger = 0, fanDeger = 0;
                for (int i = 0; i < gunlukSayacGrafikVerileri.Rows.Count - 1; i++)
                {
                    string tarih = gunlukSayacGrafikVerileri.Rows[i][0].ToString();
                    if (indexIsitici != -1)
                    {
                        if (gunlukSayacGrafikVerileri.Rows[i][indexIsitici].ToString() != "")
                        {
                            isiticiDeger = Convert.ToDouble(gunlukSayacGrafikVerileri.Rows[i][indexIsitici]);
                            isiticiOrt = Convert.ToDouble(gunlukSayacGrafikVerileri.Rows[indexOrt][indexIsitici]);
                            if (checkBox1.Checked)
                            {
                                DataPoint dp = new DataPoint();
                                dp.AxisLabel = tarih.ToString();
                                dp.XValue = i;
                                dp.YValues = new double[] { isiticiDeger };
                                if (isiticiGG)
                                    dp.Label = isiticiDeger.ToString();
                                else
                                    dp.Label = "";
                                dp.LabelAngle = 90;
                                chart1.Series["Isitici"].Points.Add(dp);
                            }
                        }
                    }
                    if (indexMotor != -1)
                    {
                        if (gunlukSayacGrafikVerileri.Rows[i][indexMotor].ToString() != "")
                        {
                            motorDeger = Convert.ToDouble(gunlukSayacGrafikVerileri.Rows[i][indexMotor]);
                            motorOrt = Convert.ToDouble(gunlukSayacGrafikVerileri.Rows[indexOrt][indexMotor]);
                            if (checkBox2.Checked)
                            {
                                DataPoint dp2 = new DataPoint();
                                dp2.AxisLabel = tarih.ToString();
                                dp2.LabelAngle = 45;
                                dp2.XValue = i;
                                dp2.YValues = new double[] { motorDeger };
                                if (motorGG)
                                    dp2.Label = motorDeger.ToString();
                                else
                                    dp2.Label = "";
                                chart1.Series["Motor"].Points.Add(dp2);
                            }
                        }
                    }
                    if (indexFan != -1)
                    {
                        if (gunlukSayacGrafikVerileri.Rows[i][indexFan].ToString() != "")
                        {
                            fanDeger = Convert.ToDouble(gunlukSayacGrafikVerileri.Rows[i][indexFan]);
                            fanOrt = Convert.ToDouble(gunlukSayacGrafikVerileri.Rows[indexOrt][indexFan]);
                            if (checkBox3.Checked)
                            {
                                DataPoint dp3 = new DataPoint();
                                dp3.AxisLabel = tarih.ToString();
                                dp3.LabelAngle = 45;
                                dp3.XValue = i;
                                dp3.YValues = new double[] { fanDeger };
                                if (fanGG)
                                    dp3.Label = fanDeger.ToString();
                                else
                                    dp3.Label = "";
                                chart1.Series["Fan"].Points.Add(dp3);
                            }
                        }
                    }
                    toplamOrt = isiticiOrt + motorOrt + fanOrt;
                    if (checkToplam.Checked)
                    {

                        toplamDeger = isiticiDeger + motorDeger + fanDeger;
                        DataPoint dp4 = new DataPoint();
                        dp4.AxisLabel = tarih.ToString();
                        dp4.LabelAngle = 45;
                        dp4.XValue = i;
                        dp4.YValues = new double[] { toplamDeger };
                        if (toplamGG)
                            dp4.Label = toplamDeger.ToString();
                        else
                            dp4.Label = "";
                        chart1.Series["Toplam"].Points.Add(dp4);
                    }
                    genislik += 1;
                    chart1.ChartAreas["areaSayac"].AxisX.IsLabelAutoFit = true;
                    chart1.ChartAreas["areaSayac"].AxisX.LabelAutoFitStyle = LabelAutoFitStyles.LabelsAngleStep90;
                    chart1.ChartAreas["areaSayac"].AxisX.LabelStyle.Enabled = true;
                    chart1.ChartAreas["areaSayac"].AxisX.Interval = 1;
                    checkToplamOrt.Text = makineAdi + " Ortalama: " + toplamOrt;
                    checkIsiticiOrt.Text = isitici + " Ortalama: " + isiticiOrt;
                    checkMotorOrt.Text = motor + " Ortalama: " + motorOrt;
                    checkFanOrt.Text = fan + " Ortalama: " + fanOrt;
                    toplamDeger = 0;
                    fanDeger = 0;
                    motorDeger = 0;
                    isiticiDeger = 0;
                }
                for (int i = 0; i < gunlukSayacGrafikVerileri.Rows.Count - 1; i++)
                {
                    if (checkIsiticiOrt.Checked)
                    {
                        chart1.Series["Isıtıcı Ortalama"].ChartType = SeriesChartType.Line;
                        chart1.Series["Isıtıcı Ortalama"].Color = Color.Black;
                        chart1.Series["Isıtıcı Ortalama"].BorderWidth = 2;
                        DataPoint dp6 = new DataPoint();
                        dp6.LabelAngle = 45;
                        dp6.XValue = i;
                        dp6.YValues = new double[] { isiticiOrt };
                        chart1.Series["Isıtıcı Ortalama"].Points.Add(dp6);
                    }
                    if (checkMotorOrt.Checked)
                    {
                        chart1.Series["Motor Ortalama"].ChartType = SeriesChartType.Line;
                        chart1.Series["Motor Ortalama"].Color = Color.Black;
                        chart1.Series["Motor Ortalama"].BorderWidth = 2;
                        DataPoint dp7 = new DataPoint();
                        dp7.LabelAngle = 45;
                        dp7.XValue = i;
                        dp7.YValues = new double[] { motorOrt };
                        chart1.Series["Motor Ortalama"].Points.Add(dp7);
                    }
                    if (checkFanOrt.Checked)
                    {
                        chart1.Series["Fan Ortalama"].ChartType = SeriesChartType.Line;
                        chart1.Series["Fan Ortalama"].Color = Color.Black;
                        chart1.Series["Fan Ortalama"].BorderWidth = 2;
                        DataPoint dp8 = new DataPoint();
                        dp8.LabelAngle = 45;
                        dp8.XValue = i;
                        dp8.YValues = new double[] { fanOrt };
                        chart1.Series["Fan Ortalama"].Points.Add(dp8);
                    }
                    if (checkToplamOrt.Checked)
                    {
                        chart1.Series["Toplam Ortalama"].ChartType = SeriesChartType.Line;
                        chart1.Series["Toplam Ortalama"].Color = Color.Black;
                        chart1.Series["Toplam Ortalama"].BorderWidth = 2;
                        DataPoint dp9 = new DataPoint();
                        dp9.LabelAngle = 45;
                        dp9.XValue = i;
                        dp9.YValues = new double[] { toplamOrt };
                        chart1.Series["Toplam Ortalama"].Points.Add(dp9);
                    }
                }
                chart1.Width += (genislik * 50);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
