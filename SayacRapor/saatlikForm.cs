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
    public partial class saatlikForm : Form
    {
        ArrayList ekstraBaslangic = new ArrayList();
        ArrayList ekstraBitis = new ArrayList();
        ArrayList ekstraSayac = new ArrayList();
        ArrayList ekstraKWH = new ArrayList();
        ArrayList minimumTuketim = new ArrayList();
        ArrayList ortalamaBolen = new ArrayList();
        ArrayList gunlukToplam = new ArrayList();
        ArrayList gunlukOrtalama = new ArrayList();
        ArrayList renklendirCol = new ArrayList();
        ArrayList sonrakiEksikCol = new ArrayList();
        ArrayList renklendirRow = new ArrayList();
        ArrayList sonrakiEksikRow = new ArrayList();
        ArrayList colNames = new ArrayList();
        ArrayList colDate = new ArrayList();
        ArrayList colHour = new ArrayList();
        ArrayList colKWH = new ArrayList();
        ArrayList multipleCell = new ArrayList();
        ArrayList multipleCol = new ArrayList();
        ArrayList hataliVeriler = new ArrayList();
        ArrayList eksikKolonlar = new ArrayList();
        ArrayList makineListesi = new ArrayList();
        DataTable sayacTable = new DataTable();
        DataTable yedekTable = new DataTable();
        DataTable saatlikTable = new DataTable();
        DataTable kwhList = new DataTable();
        DataTable hamVeriler = new DataTable();
        decimal KWH1 = 0, eskiKWH, yeniKWH;
        string startDate, endDate, ilkGunString, anlikTarih, sayacIsim, tarih, dinamikTarih;
        int haftaSayisi, gunSayisi, rowSayi = 0, saatSayisi, oncekiSaat;
        public bool sifreDogru = false, insertMode = true, veriYapistir = false, veriSil = false;
        public bool adminMode = false;
        bool gecenAySonGunEklendi = false;
        DateTime ilkGunDateTime, startZaman, endZaman, tarihKontrol;
        TimeSpan zaman;
        string baslangicSaati, bitisSaati;



        int genislik;
        string isitici, motor, fan;

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

        private void checkToplamOrt_CheckedChanged(object sender, EventArgs e)
        {
            grafikOlustur();
        }

        private void checkIsiticiOrt_CheckedChanged(object sender, EventArgs e)
        {
            grafikOlustur();
        }

        private void checkMotorOrt_CheckedChanged(object sender, EventArgs e)
        {
            grafikOlustur();
        }

        bool sayac = false;
        bool gunluk = false;
        private void dataViewSayac_Scroll(object sender, ScrollEventArgs e)
        {
            if (gunluk)
            {
                gunluk = false;
            }
            else
            {
                if (e.ScrollOrientation == ScrollOrientation.HorizontalScroll)
                {
                    dataViewSaatlik.HorizontalScrollingOffset = e.NewValue;
                }
                else
                {
                    sayac = true;
                    if (e.NewValue != 0)
                        dataViewSaatlik.FirstDisplayedScrollingRowIndex = e.NewValue;
                    else
                        dataViewSaatlik.FirstDisplayedScrollingRowIndex = e.NewValue + 1;
                }
            }
        }

        private void dataViewSaatlik_Scroll(object sender, ScrollEventArgs e)
        {
            if (sayac)
            {
                sayac = false;
            }
            else
            {
                if (e.ScrollOrientation == ScrollOrientation.HorizontalScroll)
                {
                    dataViewSayac.HorizontalScrollingOffset = e.NewValue; // Me.DataGridView1.HorizontalScrollingOffset
                }
                else
                {
                    gunluk = true;
                    dataViewSayac.FirstDisplayedScrollingRowIndex = e.NewValue;
                }
            }
        }

        private void datePickerStart_ValueChanged(object sender, EventArgs e)
        {
            DateTime startDate = datePickerStart.Value;
            DateTime endDate = datePickerEnd.Value;
            if (startDate >= endDate)
            {
                datePickerEnd.Value = DateTime.Now;
            }
            basla();
        }

        private void datePickerEnd_ValueChanged(object sender, EventArgs e)
        {
            DateTime startDate = datePickerStart.Value;
            DateTime endDate = datePickerEnd.Value;
            if (startDate >= endDate)
            {
                datePickerStart.Value = datePickerEnd.Value;
            }
            basla();
        }

        private void checkFanOrt_CheckedChanged(object sender, EventArgs e)
        {
            grafikOlustur();
        }

        private void btnOtomatikDoldur_Click(object sender, EventArgs e)
        {
            //Otomatik doldur
            multipleCell.Clear();
            multipleCol.Clear();
            int indexBaslangic, indexBitis, indexAktif, indexMaksimum, indexKolon;
            double degerBaslangic, degerBitis, degerOnceki;
            int bolen = 1;
            foreach (DataGridViewCell cell in dataViewSayac.SelectedCells)
            {
                if (multipleCell.IndexOf(cell.RowIndex) == -1)
                    multipleCell.Add(cell.RowIndex);

                if (multipleCol.IndexOf(cell.ColumnIndex) == -1)
                    multipleCol.Add(cell.ColumnIndex);

                if (Convert.ToInt32(multipleCol[0]) == cell.ColumnIndex)
                    bolen++;
            }
            multipleCell.Sort();
            multipleCol.Sort();

            for (int i = 0; i < multipleCol.Count; i++)
            {
                try
                {
                    indexKolon = Convert.ToInt32(multipleCol[i]);
                    for (int k = 0; k < multipleCell.Count; k++)
                    {
                        indexMaksimum = Convert.ToInt32(multipleCell.Count - 1);
                        indexBaslangic = Convert.ToInt32(multipleCell[0]) - 1;
                        indexBitis = Convert.ToInt32(multipleCell[indexMaksimum]) + 1;
                        indexAktif = Convert.ToInt32(multipleCell[k]);

                        degerBaslangic = Convert.ToDouble(sayacTable.Rows[indexBaslangic][indexKolon]);
                        degerOnceki = Convert.ToDouble(sayacTable.Rows[indexAktif - 1][indexKolon]);
                        degerBitis = Convert.ToDouble(sayacTable.Rows[indexBitis][indexKolon]);
                        Decimal eskiKWHDec;
                        double hesaplananDeger = Math.Round(((degerBitis - degerBaslangic) / bolen) + degerOnceki, 3);
                        if (sayacTable.Rows[indexAktif][indexKolon].ToString() == "")
                            eskiKWHDec = -1;
                        else
                            eskiKWHDec = Convert.ToDecimal(sayacTable.Rows[indexAktif][indexKolon]);
                        Decimal yeniKWHDec = Convert.ToDecimal(hesaplananDeger);
                        sayacTable.Rows[indexAktif][indexKolon] = hesaplananDeger;

                        string tmpIsim = sayacTable.Columns[indexKolon].ColumnName;
                        string tmpTarih = sayacTable.Rows[indexAktif]["TARIH"].ToString();
                        string eskiSaatAralik1 = sayacTable.Rows[indexAktif]["SAAT"].ToString();
                        string eskiSaatAralik2 = sayacTable.Rows[indexAktif+1]["SAAT"].ToString();
                        TimeSpan eskiSaat = new TimeSpan(int.Parse(eskiSaatAralik1.Substring(0, 2)), 00, 01);
                        {
                            if (eskiKWHDec == -1)
                            {
                                string saatDakika = eskiSaat.Hours + ":" + eskiSaat.Minutes + ":" + eskiSaat.Seconds;
                                string insertString = "INSERT INTO SAYAC_SAATLIK (ISIM, KWH, TARIH, SAAT) VALUES (@sayacIsim, @yeniKWH, @tarih, @saat)";
                                SqlCommand insertCommand = new SqlCommand(insertString, con);
                                insertCommand.Parameters.Add("@sayacIsim", SqlDbType.VarChar).Value = tmpIsim;
                                insertCommand.Parameters.Add("@tarih", SqlDbType.VarChar).Value = tmpTarih;
                                insertCommand.Parameters.Add("@yeniKWH", SqlDbType.Decimal).Value = yeniKWHDec;
                                insertCommand.Parameters.Add("@saat", SqlDbType.Time).Value = saatDakika;
                                if (con.State != ConnectionState.Open)
                                    con.Open();
                                insertCommand.ExecuteNonQuery();
                                if (con.State != ConnectionState.Closed)
                                    con.Close();
                            }
                            else
                            {
                                string saatDakika = eskiSaat.Hours + ":" + eskiSaat.Minutes + ":" + eskiSaat.Seconds;
                                string updateString = "UPDATE SAYAC_SAATLIK SET KWH = @yeniKWH, SAAT = @saat WHERE ISIM = @sayacIsim AND TARIH = @tarih AND KWH = @eskiKWH AND SAAT >= @saatAralik1 AND SAAT <= @saatAralik2";
                                SqlCommand updateCommand = new SqlCommand(updateString, con);
                                updateCommand.Parameters.Add("@sayacIsim", SqlDbType.VarChar).Value = tmpIsim;
                                updateCommand.Parameters.Add("@tarih", SqlDbType.VarChar).Value = tmpTarih;
                                updateCommand.Parameters.Add("@yeniKWH", SqlDbType.Decimal).Value = yeniKWHDec;
                                updateCommand.Parameters.Add("@eskiKWH", SqlDbType.Decimal).Value = eskiKWHDec;
                                updateCommand.Parameters.Add("@saat", SqlDbType.Time).Value = saatDakika;
                                updateCommand.Parameters.Add("@saatAralik1", SqlDbType.Time).Value = eskiSaatAralik1;
                                updateCommand.Parameters.Add("@saatAralik2", SqlDbType.Time).Value = eskiSaatAralik2;
                                if (con.State != ConnectionState.Open)
                                    con.Open();
                                updateCommand.ExecuteNonQuery();
                                if (con.State != ConnectionState.Closed)
                                    con.Close();
                            }
                        }  
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hata: " + ex);
                }
            }
        }

        private void düzenlemeyiAçKapatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Font defaultFont = SystemFonts.DefaultFont;
            if (adminMode)
            {
                adminMode = false;
                dataViewSayac.EditMode = DataGridViewEditMode.EditProgrammatically;
                statusLabel.ForeColor = Color.Green;
                statusLabel.Font = new Font(defaultFont.FontFamily, defaultFont.Size);
                statusLabel.Text = "Düzenleme modu kapalı.";
                btnOtomatikDoldur.Visible = false;
                timer1.Start();
            }
            else
            {
                passwordForm pwf = new passwordForm();
                pwf.ShowDialog();
                sifreDogru = pwf.sifreDogru;
                if (sifreDogru)
                {
                    adminMode = true;
                    dataViewSayac.EditMode = DataGridViewEditMode.EditOnKeystrokeOrF2;
                    statusLabel.ForeColor = Color.Red;
                    statusLabel.Font = new Font(defaultFont.FontFamily, defaultFont.Size, FontStyle.Bold);
                    statusLabel.Text = "Düzenleme modu açık.";
                    btnOtomatikDoldur.Visible = true;
                    MessageBox.Show("Yapacağınız işlemler direkt olarak veritabanını etkileyecektir.", "Dikkat", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    sifreDogru = false;
                    veriYapistir = false;
                }
            }

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Interval = 10000;
            statusLabel.Text = "";
        }

        int indexIsitici, indexMotor, indexFan, indexOrt;
        double isiticiOrt = 0, toplamOrt = 0, motorOrt = 0, fanOrt = 0;
        string makineAdi = "";
        bool toplamGG = true, isiticiGG = true, motorGG = true, fanGG = true;
        ArrayList isimList = new ArrayList();
        SqlConnection con = new SqlConnection(MainForm.conString);
        public saatlikForm()
        {
            InitializeComponent();
        }

        private void saatlikForm_Load(object sender, EventArgs e)
        {
            makineAdlari();
            datePickerStart.Value = datePickerEnd.Value.AddDays(-2);
            cmbMakine.Text = "DLH3/1";
            basla();
        }

        private void cmbMakine_SelectedIndexChanged(object sender, EventArgs e)
        {
            basla();
        }
        void basla()
        {
            startZaman = datePickerStart.Value;
            tarihKontrol = startZaman;
            tarihKontrol = new DateTime(tarihKontrol.Year, tarihKontrol.Month, tarihKontrol.Day, 00, 00, 00);
            string startDateSTR = datePickerStart.Value.ToString("yyyy-MM-dd");
            string endDateSTR = datePickerEnd.Value.ToString("yyyy-MM-dd");
            gizle();
            sayacGetir();
            grafikOlustur();
            int xLokasyon = panel1.Width + panel1.Location.X + 10;
            panel2.Location = new Point(xLokasyon, panel1.Location.Y);
        }
        void makineAdlari()
        {
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
        void grafikOlustur()
        {
            DataTable saatlikGrafikVerileri = new DataTable();
            saatlikGrafikVerileri.Clear();
            saatlikGrafikVerileri.Columns.Clear();
            saatlikGrafikVerileri = saatlikTable.Copy();
            if (saatlikGrafikVerileri.Rows.Count > 0)
            {
                saatlikGrafikVerileri.Rows[saatlikGrafikVerileri.Rows.Count - 1].Delete();
                saatlikGrafikVerileri.Rows[0].Delete();
            }
            saatlikGrafikVerileri.AcceptChanges();
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
                indexIsitici = saatlikGrafikVerileri.Columns.IndexOf(isitici);
                indexMotor = saatlikGrafikVerileri.Columns.IndexOf(motor);
                indexFan = saatlikGrafikVerileri.Columns.IndexOf(fan);
                indexOrt = saatlikGrafikVerileri.Rows.Count - 1;
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
                chart1.BorderlineColor = Color.Black;

                toplamOrt = 0; isiticiOrt = 0; motorOrt = 0; fanOrt = 0;
                double toplamDeger = 0, isiticiDeger = 0, motorDeger = 0, fanDeger = 0;
                for (int i = 0; i < saatlikGrafikVerileri.Rows.Count - 1; i++)
                {
                    string tarih = saatlikGrafikVerileri.Rows[i][0].ToString();
                    string saat = saatlikGrafikVerileri.Rows[i][1].ToString();
                    if (indexIsitici != -1)
                    {
                        if (saatlikGrafikVerileri.Rows[i][indexIsitici].ToString() != "")
                        {
                            isiticiDeger = Convert.ToDouble(saatlikGrafikVerileri.Rows[i][indexIsitici]);
                            isiticiOrt = Convert.ToDouble(saatlikGrafikVerileri.Rows[indexOrt][indexIsitici]);
                            if (checkBox1.Checked)
                            {
                                DataPoint dp = new DataPoint();
                                dp.AxisLabel = tarih + " - " + saat;
                                dp.XValue = i;
                                dp.YValues = new double[] { isiticiDeger };
                                if (isiticiGG)
                                    dp.Label = isiticiDeger.ToString();
                                else
                                    dp.Label = "";
                                dp.LabelAngle = 90;
                                dp.LabelBackColor = Color.White;
                                chart1.Series["Isitici"].Points.Add(dp);

                            }
                        }
                    }
                    if (indexMotor != -1)
                    {
                        if (saatlikGrafikVerileri.Rows[i][indexMotor].ToString() != "")
                        {
                            motorDeger = Convert.ToDouble(saatlikGrafikVerileri.Rows[i][indexMotor]);
                            motorOrt = Convert.ToDouble(saatlikGrafikVerileri.Rows[indexOrt][indexMotor]);
                            if (checkBox2.Checked)
                            {
                                DataPoint dp2 = new DataPoint();
                                dp2.AxisLabel = tarih + " - " + saat;
                                dp2.LabelAngle = 45;
                                dp2.XValue = i;
                                dp2.YValues = new double[] { motorDeger };
                                if (motorGG)
                                    dp2.Label = motorDeger.ToString();
                                else
                                    dp2.Label = "";
                                dp2.LabelBackColor = Color.White;
                                chart1.Series["Motor"].Points.Add(dp2);
                            }
                        }
                    }
                    if (indexFan != -1)
                    {
                        if (saatlikGrafikVerileri.Rows[i][indexFan].ToString() != "")
                        {
                            fanDeger = Convert.ToDouble(saatlikGrafikVerileri.Rows[i][indexFan]);
                            fanOrt = Convert.ToDouble(saatlikGrafikVerileri.Rows[indexOrt][indexFan]);
                            if (checkBox3.Checked)
                            {
                                DataPoint dp3 = new DataPoint();
                                dp3.AxisLabel = tarih + " - " + saat;
                                dp3.LabelAngle = 45;
                                dp3.XValue = i;
                                dp3.YValues = new double[] { fanDeger };
                                if (fanGG)
                                    dp3.Label = fanDeger.ToString();
                                else
                                    dp3.Label = "";
                                dp3.LabelBackColor = Color.White;
                                chart1.Series["Fan"].Points.Add(dp3);
                            }
                        }
                    }
                    toplamOrt = isiticiOrt + motorOrt + fanOrt;
                    if (checkToplam.Checked)
                    {

                        toplamDeger = isiticiDeger + motorDeger + fanDeger;
                        DataPoint dp4 = new DataPoint();
                        dp4.AxisLabel = tarih + " - " + saat;
                        dp4.LabelAngle = 45;
                        dp4.XValue = i;
                        dp4.YValues = new double[] { toplamDeger };
                        if (toplamGG)
                            dp4.Label = toplamDeger.ToString();
                        else
                            dp4.Label = "";
                        dp4.LabelBackColor = Color.White;
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
                for (int i = 0; i < saatlikGrafikVerileri.Rows.Count - 1; i++)
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
                chart1.Width += (genislik * 45);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
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
        void sayacGetir()
        {
            ayar();
            rowSayi = 0;
            dataGridTemizle();
            //Bağlantı açık değilse bağlantıyı açıyoruz.
            if (con.State != ConnectionState.Open)
            {
                con.Open();
            }
            aktifEkstraTuketimGetir();
            sayacTable.Columns.Add("TARIH");
            saatlikTable.Columns.Add("TARIH");
            sayacTable.Columns.Add("SAAT");
            saatlikTable.Columns.Add("SAAT");

            //Tarih aralığı tabloya eklendi.
            DateTime gun = startZaman;
            for (int a = 0; a < gunSayisi; a++)
            {
                string tmpTarih = gun.AddDays(a).ToString("yyyy-MM-dd");
                colDate.Add(tmpTarih);
            }
            for (int a = 0; a <= 23; a++)
            {
                string tmpSaat;
                if (a < 10)
                    tmpSaat = "0" + a + ":00:00";
                else
                    tmpSaat = a + ":00:00";

                colHour.Add(tmpSaat);
            }


            //Sayaç isimleri tabloya eklendi.

            kwhList.Clear();
            kwhList.Columns.Clear();
            dataViewSaatlik.DataSource = null;
            dataViewSayac.DataSource = null;
            saatlikTable.Clear();
            saatlikTable.Columns.Clear();
            makineListesi.Clear();
            kwhList.Columns.Add("TARIH");
            kwhList.Columns.Add("SAAT");
            makineAdi = cmbMakine.Text;
            if (con.State != ConnectionState.Open)
            {
                con.Open();
            }
            string sayacIsimString = "Select * From SAYAC_AYAR WHERE makine_adi = '" + makineAdi + "'  ORDER BY sayac_sira";
            SqlCommand sayacIsimCommand = new SqlCommand(sayacIsimString, con);
            SqlDataReader sayacIsimReader = sayacIsimCommand.ExecuteReader();
            int i = 0;
            saatlikTable.Columns.Add("TARIH");
            saatlikTable.Columns.Add("SAAT");
            while (sayacIsimReader.Read())
            {
                if (saatlikTable.Columns.IndexOf(sayacIsimReader["sayac_isim"].ToString()) == -1)
                {
                    sayacTable.Columns.Add(sayacIsimReader["sayac_isim"].ToString());
                    kwhList.Columns.Add(sayacIsimReader["sayac_isim"].ToString());
                    saatlikTable.Columns.Add(sayacIsimReader["sayac_isim"].ToString());
                    makineListesi.Add(sayacIsimReader["sayac_isim"].ToString());
                    gunlukOrtalama.Add(0);
                    gunlukToplam.Add(0);
                    ortalamaBolen.Add(0);
                }

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
                if (i > 0)
                {
                    checkToplam.Visible = true;
                    checkToplamOrt.Visible = true;
                }
                i++;
                minimumTuketim.Add(sayacIsimReader["sayac_min_tuketim"]);
            }
            sayacIsimReader.Close();

            DataRow carpanRow = saatlikTable.NewRow();
            carpanRow[0] = "Çarpanlar:";
            sayacIsimReader = sayacIsimCommand.ExecuteReader();
            while (sayacIsimReader.Read())
            {
                string indexName = sayacIsimReader["sayac_isim"].ToString();
                carpanRow[indexName] = sayacIsimReader["sayac_carpan"];
            }
            saatlikTable.Rows.Add(carpanRow);
            sayacIsimReader.Close();
            con.Close();



            //KWH verileri tabloya eklendi.
            for (int b = 0; b < 1; b++) //colDate.Count
            {
                string ilkGUNStr = startZaman.ToString("yyyy-MM-dd");
                string sonGUNStr = endZaman.ToString("yyyy-MM-dd");
                if (con.State != ConnectionState.Open)
                {
                    con.Open();
                }
                baslangicSaati = "00:00:00";
                bitisSaati = "23:59:59";
                hamVeriler.Clear();
                hamVeriler.Columns.Clear();
                for (int k = 0; k < makineListesi.Count; k++)
                {
                    string fullString = "SELECT ISIM, KWH, TARIH, SAAT From SAYAC_SAATLIK WHERE TARIH >= '" + ilkGUNStr + "' AND TARIH <= '" + sonGUNStr + "' AND SAAT >= '" + baslangicSaati + "' AND SAAT <= '" + bitisSaati + "' AND ISIM = '" + makineListesi[k] + "' AND KWH <> 0 ORDER BY TARIH,SAAT";
                    SqlCommand fullCommand = new SqlCommand(fullString, con);
                    SqlDataAdapter fullAdapter = new SqlDataAdapter();
                    fullAdapter.SelectCommand = fullCommand;
                    fullAdapter.Fill(hamVeriler);

                    TimeSpan saatKontrol = new TimeSpan(int.Parse(baslangicSaati.Substring(0, 2)), 00, 00);

                    while (tarihKontrol <= endZaman)
                    {
                        for (int n = 0; n < colHour.Count; n++)
                        {
                            if (hamVeriler.Rows.Count == 0)
                                break;
                            DateTime ilkSatirTarihi = Convert.ToDateTime(hamVeriler.Rows[0]["TARIH"]);
                            string ilkSatirTarihSTR = hamVeriler.Rows[0]["TARIH"].ToString();
                            string ilkSatirSaatSTR = hamVeriler.Rows[0]["SAAT"].ToString();
                            TimeSpan ilkSatirSaati = new TimeSpan(int.Parse(ilkSatirSaatSTR.Substring(0, 2)), int.Parse(ilkSatirSaatSTR.Substring(3, 2)), int.Parse(ilkSatirSaatSTR.Substring(6, 2)));
                            int tmpSaat = int.Parse(colHour[n].ToString().Substring(0, 2));
                            int bitisSaat = int.Parse(hamVeriler.Rows[hamVeriler.Rows.Count - 1]["SAAT"].ToString().Substring(0, 2));
                            string sonTarih = hamVeriler.Rows[hamVeriler.Rows.Count - 1]["TARIH"].ToString();
                            DateTime bitisTarihi = new DateTime(int.Parse(sonTarih.Substring(0, 4)), int.Parse(sonTarih.Substring(5, 2)), int.Parse(sonTarih.Substring(8, 2)), 00, 00, 00);
                            DataRow bosKwhRow = kwhList.NewRow();
                            bosKwhRow["TARIH"] = tarihKontrol.ToString("yyyy-MM-dd");
                            bosKwhRow["SAAT"] = colHour[n];
                            while (tarihKontrol == ilkSatirTarihi && int.Parse(ilkSatirSaatSTR.Substring(0, 2)) < tmpSaat)
                            {
                                hamVeriler.Rows[0].Delete();
                                hamVeriler.AcceptChanges();
                                if (hamVeriler.Rows.Count == 0)
                                    break;
                                ilkSatirSaatSTR = hamVeriler.Rows[0]["SAAT"].ToString();
                                ilkSatirTarihi = Convert.ToDateTime(hamVeriler.Rows[0]["TARIH"]);
                            }
                            if (hamVeriler.Rows.Count == 0)
                                break;
                            if (tarihKontrol == ilkSatirTarihi && int.Parse(ilkSatirSaatSTR.Substring(0, 2)) == tmpSaat)
                            {
                                bosKwhRow["SAAT"] = hamVeriler.Rows[0]["SAAT"].ToString();
                                string ilkSatirIsim = hamVeriler.Rows[0]["ISIM"].ToString();
                                string ilkSatirKWH = hamVeriler.Rows[0]["KWH"].ToString();
                                bosKwhRow[ilkSatirIsim] = ilkSatirKWH;
                                hamVeriler.Rows[0].Delete();
                                hamVeriler.AcceptChanges();
                            }
                            kwhList.Rows.Add(bosKwhRow);
                            if (tarihKontrol == endZaman && tmpSaat > bitisSaat)
                                break;
                            if (hamVeriler.Rows.Count == 0)
                                break;
                        }
                        tarihKontrol = tarihKontrol.AddDays(1);
                    }
                    if (tarihKontrol >= endZaman && hamVeriler.Rows.Count > 0)
                    {
                        for (int n = 0; n < kwhList.Rows.Count; n++)
                        {
                            if (hamVeriler.Rows.Count == 0)
                                break;
                            DateTime ilkSatirTarihi = Convert.ToDateTime(hamVeriler.Rows[0]["TARIH"]);
                            string ilkSatirTarihSTR = hamVeriler.Rows[0]["TARIH"].ToString();
                            string ilkSatirSaatSTR = hamVeriler.Rows[0]["SAAT"].ToString();
                            TimeSpan ilkSatirSaati = new TimeSpan(int.Parse(ilkSatirSaatSTR.Substring(0, 2)), int.Parse(ilkSatirSaatSTR.Substring(3, 2)), int.Parse(ilkSatirSaatSTR.Substring(6, 2)));
                            int bitisSaat = int.Parse(hamVeriler.Rows[hamVeriler.Rows.Count - 1]["SAAT"].ToString().Substring(0, 2));
                            string sonTarih = hamVeriler.Rows[hamVeriler.Rows.Count - 1]["TARIH"].ToString();
                            DateTime bitisTarihi = new DateTime(int.Parse(sonTarih.Substring(0, 4)), int.Parse(sonTarih.Substring(5, 2)), int.Parse(sonTarih.Substring(8, 2)), 00, 00, 00);

                            DataRow row = kwhList.Rows[n];
                            while (row["TARIH"].ToString() == ilkSatirTarihSTR && int.Parse(row["SAAT"].ToString().Substring(0, 2)) > int.Parse(ilkSatirSaatSTR.Substring(0, 2)))
                            {
                                hamVeriler.Rows[0].Delete();
                                hamVeriler.AcceptChanges();
                                if (hamVeriler.Rows.Count == 0)
                                    break;
                                ilkSatirSaatSTR = hamVeriler.Rows[0]["SAAT"].ToString();
                                ilkSatirTarihi = Convert.ToDateTime(hamVeriler.Rows[0]["TARIH"]);
                            }
                            if (hamVeriler.Rows.Count == 0)
                                break;
                            if (row["TARIH"].ToString() == ilkSatirTarihSTR && row["SAAT"].ToString().Substring(0,2) == ilkSatirSaatSTR.Substring(0,2))
                            {
                                string tarih = row["TARIH"].ToString();
                                string saat = row["SAAT"].ToString();
                                string ilkSatirIsim = hamVeriler.Rows[0]["ISIM"].ToString();
                                string ilkSatirKWH = hamVeriler.Rows[0]["KWH"].ToString();
                                row["TARIH"] = tarih;
                                row["SAAT"] = saat;
                                row[ilkSatirIsim] = ilkSatirKWH;
                                hamVeriler.Rows[0].Delete();
                                hamVeriler.AcceptChanges();
                            }
                            if (hamVeriler.Rows.Count == 0)
                                break;
                        }
                        hamVeriler.Clear();
                        hamVeriler.Columns.Clear();
                    }
                }


                    /*

                TimeSpan saatKontrol = new TimeSpan(int.Parse(baslangicSaati.Substring(0,2)), 00, 00);
                hamVeriler.DefaultView.Sort = "TARIH, SAAT ASC";
                hamVeriler = hamVeriler.DefaultView.ToTable();
                int s = makineListesi.Count;
                
                for (int l = 0; l < hamVeriler.Rows.Count; l=l+s)
                {
                    string kwhIsim = hamVeriler.Rows[l][0].ToString(), kwhKWH = "0";
                    string kwhTarih = hamVeriler.Rows[l][2].ToString();
                    string kwhSaat = hamVeriler.Rows[l][3].ToString();
                    DataRow kwhRow = kwhList.NewRow();

                    for (int p = 0; p < makineListesi.Count; p++)
                    {
                        try
                        {
                            kwhIsim = hamVeriler.Rows[l + p][0].ToString();
                            kwhKWH = hamVeriler.Rows[l + p][1].ToString();
                        }
                        catch
                        {

                        }
                        kwhRow[kwhIsim] = kwhKWH;
                    }
                    string h = kwhSaat.Substring(0, 2);
                    DateTime anlikTrh = Convert.ToDateTime(anlikTarih);
                    while(tarihKontrol <= anlikTrh)
                    {
                        for(int m = 0; m<24;m++)
                        {
                            DataRow bosKWHRow = kwhList.NewRow();
                            bosKWHRow["TARIH"] = tarihKontrol.ToString("yyyy-MM-dd");
                            string tmpSaat;
                            if (saatKontrol.Hours < 10)
                                tmpSaat = "0" + saatKontrol.Hours + ":00:00";
                            else
                                tmpSaat = saatKontrol.Hours + ":00:00";
                            bosKWHRow["SAAT"] = tmpSaat;
                            saatKontrol = new TimeSpan(saatKontrol.Hours + 1, 00, 00);
                            kwhList.Rows.Add(bosKWHRow);
                        }
                        tarihKontrol = tarihKontrol.AddDays(1);
                    }
                    kwhRow["TARIH"] = kwhTarih;
                    //kwhSaat = h + ":00:00";
                    kwhRow["SAAT"] = kwhSaat;
                    kwhList.Rows.Add(kwhRow);
                    saatKontrol = new TimeSpan(saatKontrol.Hours + 1, 00, 00);
                }

                    */

                int donguSayisi = kwhList.Rows.Count;
                for (int l = 0; l < donguSayisi; l++)
                {
                    DataRow sayacRow = sayacTable.NewRow();
                    DataRow saatlikRow = saatlikTable.NewRow();
                    for (int k = 2; k < kwhList.Columns.Count; k++)
                    {
                        int carpan;
                        decimal KWH2;
                        string bugunIsim;
                        bugunIsim = kwhList.Columns[k].ToString();
                        baslangicSaati = kwhList.Rows[l]["SAAT"].ToString();
                        anlikTarih = kwhList.Rows[l]["TARIH"].ToString();

                        int nameIndex = kwhList.Columns.IndexOf(bugunIsim);
                        if (kwhList.Rows[l][nameIndex].ToString() != "")
                            KWH1 = Convert.ToDecimal(kwhList.Rows[l][nameIndex]);
                        else
                        {
                            KWH1 = 0;/*
                        sonrakiEksikCol.Add(nameIndex);
                        //
                        if (nameIndex != -1)
                        {
                            renklendirCol.Add(nameIndex);
                            if (hataliVeriler.IndexOf(bugunIsim) == -1)
                                hataliVeriler.Add(bugunIsim);
                        }*/
                        }
                        if(kwhList.Rows.Count > l + 1)
                            if (kwhList.Rows[l + 1][nameIndex].ToString() != "")
                                KWH2 = Convert.ToDecimal(kwhList.Rows[l + 1][nameIndex]);
                            else
                                KWH2 = KWH1;
                        else
                            KWH2 = KWH1;

                        if (saatlikTable.Columns.IndexOf(bugunIsim) != -1)
                            carpan = Convert.ToInt32(saatlikTable.Rows[0][bugunIsim]);
                        else
                            carpan = 1;

                        if (nameIndex != -1)
                        {
                            decimal saatlikTuketim = Math.Round((KWH2 - KWH1) * carpan, 3);
                            if (KWH1 != 0)
                                sayacRow[bugunIsim] = KWH1;
                            if (KWH2 == saatlikTuketim / carpan)
                                saatlikTuketim = 0;
                            if (ekstraSayac.IndexOf(bugunIsim) != -1)
                            {
                                for (int j = 0; j < ekstraSayac.Count; j++)
                                {
                                    if (ekstraSayac[j].ToString() == bugunIsim)
                                    {
                                        if (Convert.ToDateTime(ekstraBaslangic[j]) <= Convert.ToDateTime(anlikTarih) && Convert.ToDateTime(ekstraBitis[j]) >= Convert.ToDateTime(anlikTarih))
                                        {
                                            if (anlikTarih != endDate)
                                                saatlikTuketim += (Convert.ToInt32(ekstraKWH[j])/24);

                                            if (saatlikTuketim < 0)
                                                saatlikTuketim = 0;
                                        }
                                    }
                                }
                            }
                            KWH2 = KWH1;
                            saatlikRow[bugunIsim] = saatlikTuketim;
                            if (saatlikTuketim < 0)
                            {
                                /*
                                renklendirCol.Add(nameIndex);
                                if (hataliVeriler.IndexOf(bugunIsim) == -1)
                                    hataliVeriler.Add(bugunIsim);
                                */
                            }
                        }
                        else
                        {
                            if (eksikKolonlar.IndexOf(bugunIsim) == -1)
                                eksikKolonlar.Add(bugunIsim);
                        }
                        KWH2 = KWH1;
                    }
                    sayacRow["TARIH"] = anlikTarih;
                    saatlikRow["TARIH"] = anlikTarih;
                    sayacRow["SAAT"] = baslangicSaati;
                    saatlikRow["SAAT"] = baslangicSaati;
                    sayacTable.Rows.Add(sayacRow);
                    saatlikTable.Rows.Add(saatlikRow);
                    rowSayi++;
                }
                if (con.State != ConnectionState.Closed)
                    con.Close();
            }
            ilkGunDateTime = ilkGunDateTime.AddDays(1);

            for (int c = 2; c < saatlikTable.Columns.Count; c++)
            {
                for (int l = 2; l < saatlikTable.Rows.Count; l++)
                {
                    if (saatlikTable.Rows[l][c].ToString() != "")
                    {
                        decimal hucreDegeri = Convert.ToDecimal(saatlikTable.Rows[l][c]);
                        if(hucreDegeri > 0)
                        {
                            gunlukOrtalama[c - 2] = Math.Round(Convert.ToDecimal(gunlukOrtalama[c - 2]) + hucreDegeri, 3);
                            ortalamaBolen[c - 2] = Convert.ToInt16(ortalamaBolen[c - 2]) + 1;
                        }
                        gunlukToplam[c - 2] = Convert.ToDecimal(gunlukToplam[c - 2]) + hucreDegeri;
                    }
                }
            }



            DataRow gunlukOrt = saatlikTable.NewRow();
            DataRow gunlukTop = saatlikTable.NewRow();
            gunlukOrt[0] = "Ortalama:";
            gunlukTop[0] = "Toplam:";
            for (int d = 0; d < saatlikTable.Columns.Count - 2; d++)
            {
                decimal gOrt = Convert.ToDecimal(gunlukOrtalama[d]);
                int bol = Convert.ToInt16(ortalamaBolen[d]);
                try
                {
                    gunlukOrt[d + 2] = Math.Round((gOrt / bol), 3);
                }
                catch
                {
                    gunlukOrt[d + 2] = 0;
                }
            }
            saatlikTable.Rows.Add(gunlukOrt);
            for (int k = 0; k < saatlikTable.Columns.Count - 2; k++)
            {
                gunlukTop[k + 2] = Math.Round(Convert.ToDouble(gunlukToplam[k]), 3);
            }
            saatlikTable.Rows.Add(gunlukTop);
            dataViewSayac.DataSource = sayacTable;
            dataViewSaatlik.DataSource = saatlikTable;
            if (con.State != ConnectionState.Closed)
            {
                con.Close();
            }
            FreezeBand(dataViewSaatlik.Rows[0]);
            dataViewSaatlik.Columns["TARIH"].Frozen = true;
            dataViewSayac.Columns["TARIH"].Frozen = true;

            for (int e = 0; e < renklendirRow.Count; e++)
            {
                int row = Convert.ToInt16(renklendirRow[e]);
                int col = Convert.ToInt16(renklendirCol[e]);
                dataViewSaatlik[col, row].Style.BackColor = Color.DarkRed;
            }
            for (int f = 0; f < sonrakiEksikRow.Count; f++)
            {
                int row = Convert.ToInt16(sonrakiEksikRow[f]);
                int col = Convert.ToInt16(sonrakiEksikCol[f]);
                try
                {
                    dataViewSayac[col, row].Style.BackColor = Color.Goldenrod;
                }
                catch
                { }
            }
            DataGridViewCellStyle renk = new DataGridViewCellStyle();
            DataGridViewCellStyle renk2 = new DataGridViewCellStyle();

            for (int g = 0; g < dataViewSayac.Columns.Count; g++)
            {
                dataViewSayac.Columns[g].SortMode = DataGridViewColumnSortMode.NotSortable;
                dataViewSaatlik.Columns[g].SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            int ortIndex = dataViewSaatlik.Rows[rowSayi + 1].Cells["TARIH"].RowIndex;
            int topIndex = dataViewSaatlik.Rows[rowSayi + 2].Cells["TARIH"].RowIndex;
            renk.BackColor = Color.YellowGreen;
            dataViewSaatlik.Rows[ortIndex].DefaultCellStyle = renk;
            dataViewSaatlik.Rows[topIndex].DefaultCellStyle = renk;
            //double toplam180 = 0, toplam580 = 0, toplam880 = 0;
            //toplam180 = Convert.ToDouble(dataViewSaatlik.Rows[topIndex].Cells["180"].Value);
            //toplam580 = Convert.ToDouble(dataViewSaatlik.Rows[topIndex].Cells["580"].Value);
            //toplam880 = Convert.ToDouble(dataViewSaatlik.Rows[topIndex].Cells["880"].Value);
            //double enduktif = 0, kapasitif = 0;
            //enduktif = Math.Round(toplam580 / toplam180 * 100, 3);
            //kapasitif = Math.Round(toplam880 / toplam180 * 100, 3);
            /*if (enduktif > 20)
                lblEnduktif.ForeColor = Color.Red;
            else
                lblEnduktif.ForeColor = Color.Green;

            if (kapasitif > 15)
                lblKapasitif.ForeColor = Color.Red;
            else
                lblKapasitif.ForeColor = Color.Green;

            lblEnduktif.Text = "580/180 = " + enduktif;
            lblKapasitif.Text = "880/180 = " + kapasitif;*/
            renk2.BackColor = Color.Aquamarine;
            dataViewSaatlik.Columns[0].DefaultCellStyle = renk2;
            dataViewSayac.Columns[0].DefaultCellStyle = renk2;
            dataViewSaatlik.ColumnHeadersDefaultCellStyle = renk2;
            dataViewSayac.ColumnHeadersDefaultCellStyle = renk2;
            dataViewSaatlik.EnableHeadersVisualStyles = false;
            dataViewSayac.EnableHeadersVisualStyles = false;
            if (hataliVeriler.Count > 1)
            {
                //toolHatali.Visible = true;
                //timer2.Start();
            }
            if (eksikKolonlar.Count > 1)
            {
                //toolEksik.Visible = true;
                //timer2.Start();
            }
            //timer3.Start();
            //timer3.Enabled = true;
            yedekTable.Clear();
            yedekTable.Columns.Clear();
            yedekTable = sayacTable.Copy();
        }
        void dataGridTemizle()
        {
            eksikKolonlar.Clear();
            hataliVeriler.Clear();
            minimumTuketim.Clear();
            ortalamaBolen.Clear();
            gunlukToplam.Clear();
            gunlukOrtalama.Clear();
            renklendirCol.Clear();
            renklendirRow.Clear();
            sonrakiEksikCol.Clear();
            sonrakiEksikRow.Clear();
            colNames.Clear();
            colDate.Clear();
            colKWH.Clear();
            colHour.Clear();
            multipleCell.Clear();
            multipleCol.Clear();
            kwhList.Clear();
            kwhList.Columns.Clear();
            dataViewSayac.DataSource = null;
            dataViewSaatlik.DataSource = null;
            colNames.Clear();
            colDate.Clear();
            sayacTable.Clear();
            yedekTable.Clear();
            saatlikTable.Clear();
            sayacTable.Columns.Clear();
            yedekTable.Columns.Clear();
            saatlikTable.Columns.Clear();
            dataViewSayac.Rows.Clear();
            dataViewSaatlik.Rows.Clear();
            dataViewSayac.Refresh();
            dataViewSayac.Refresh();
        }
        void aktifEkstraTuketimGetir()
        {
            ekstraBaslangic.Clear();
            ekstraSayac.Clear();
            ekstraKWH.Clear();
            ekstraBitis.Clear();
            string ekstraString = "SELECT * FROM SAYAC_EKSTRA";
            SqlCommand ekstraCommand = new SqlCommand(ekstraString, con);
            SqlDataReader ekstraReader = ekstraCommand.ExecuteReader();
            while (ekstraReader.Read())
            {
                ekstraBaslangic.Add(ekstraReader["baslangic_tarihi"]);
                if (ekstraReader["bitis_tarihi"].ToString() != "")
                    ekstraBitis.Add(ekstraReader["bitis_tarihi"]);
                else
                    ekstraBitis.Add(DateTime.Now.ToString("yyyy-MM-dd"));
                ekstraSayac.Add(ekstraReader["sayac_isim"]);
                ekstraKWH.Add(ekstraReader["ekstra_tuketim"]);
            }
            ekstraReader.Close();
        }
        void ayar()
        {
            haftaSayisi = 1;
            ilkGunString = datePickerStart.Value.AddDays(-1).ToString("yyyy-MM-dd");
            ilkGunDateTime = datePickerStart.Value;
            startZaman = datePickerStart.Value;
            endZaman = datePickerEnd.Value;
            zaman = endZaman - startZaman;
            gunSayisi = zaman.Days + 1;
            int numberOfDays = (endZaman - startZaman).Days;
            for (int days = 0; days < numberOfDays; days++)
            {
                DateTime date = startZaman.AddDays(days);
                if (date.DayOfWeek == DayOfWeek.Monday)
                    haftaSayisi++;
            }
            if (saatSayisi == 0)
                saatSayisi = 24;
        }
        private static void FreezeBand(DataGridViewBand band)
        {
            band.Frozen = true;
            DataGridViewCellStyle style = new DataGridViewCellStyle();
            style.BackColor = Color.DarkGray;
            band.DefaultCellStyle = style;
        }

    }
}
