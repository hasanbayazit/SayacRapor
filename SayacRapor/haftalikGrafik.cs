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
    public partial class haftalikGrafik : Form
    {
        public haftalikGrafik()
        {
            InitializeComponent();
        }
        ArrayList ekstraBaslangic = new ArrayList();
        ArrayList ekstraBitis = new ArrayList();
        ArrayList ekstraSayac = new ArrayList();
        ArrayList ekstraKWH = new ArrayList();
        ArrayList haftaIsimleri = new ArrayList();
        ArrayList haftalikTuketim = new ArrayList();
        DateTime startDate, endDate, haftalikBaslangic, haftalikBitis;
        DataTable grafikTable = new DataTable();
        DataTable sayaclar = new DataTable();
        int haftaSayisi, genislik, ortalamaBolen;
        bool maxGG = true, minGG = true, ortGG = true;

        private void datePickerStart_ValueChanged(object sender, EventArgs e)
        {
            DateTime startDate = datePickerStart.Value;
            DateTime endDate = datePickerEnd.Value;
            if (startDate >= endDate)
            {
                datePickerEnd.Value = DateTime.Now;
            }
        }

        private void datePickerEnd_ValueChanged(object sender, EventArgs e)
        {
            DateTime startDate = datePickerStart.Value;
            DateTime endDate = datePickerEnd.Value;
            if (startDate >= endDate)
            {
                datePickerStart.Value = datePickerEnd.Value;
            }
        }

        string sayacAdi = "";
        SqlConnection con = new SqlConnection(MainForm.conString);
        double sayacCarpan, sayacMinTuketim, haftalikOrt;
        double ilkKWH;

        private void maksimumGösterGizleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!maxGG)
                maxGG = true;
            else
                maxGG = false;
            grafikOlustur();
        }

        private void ortalamaGösterGizleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!ortGG)
                ortGG = true;
            else
                ortGG = false;
            grafikOlustur();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Interval = 10000;
            progressBar.Visible = false;
        }

        private void minimumGösterGizleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!minGG)
                minGG = true;
            else
                minGG = false;
            grafikOlustur();
        }

        private void cmbMakine_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            int sayacIndex = cmbMakine.SelectedIndex;
            sayacAdi = cmbMakine.Text;
            if(sayacAdi == sayaclar.Rows[sayacIndex][0].ToString())
            {
                sayacCarpan = Convert.ToDouble(sayaclar.Rows[sayacIndex][1]);
                sayacMinTuketim = Convert.ToDouble(sayaclar.Rows[sayacIndex][2]);
            }
        }
        private void btnGrafikOlustur_Click(object sender, EventArgs e)
        {
            if(cmbMakine.Text != "")
            {
                haftaSayisiHesapla();
                haftaBasiHesapla();
                haftaVerileriHesapla(startDate, endDate);
                grafikOlustur();
            }
            else
            {
                MessageBox.Show("Sayaç seçimi yapılmadı.", "Sayaç Seçin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void haftalikGrafik_Load(object sender, EventArgs e)
        {
            con.Open();
            string sayacString = "Select sayac_isim, sayac_carpan, sayac_min_tuketim From SAYAC_AYAR ORDER BY sayac_isim";
            SqlCommand sayacCommand = new SqlCommand(sayacString, con);
            SqlDataReader sayacReader = sayacCommand.ExecuteReader();
            sayaclar.Columns.Add("sayac_isim");
            sayaclar.Columns.Add("sayac_carpan");
            sayaclar.Columns.Add("sayac_min_tuketim");
            while (sayacReader.Read())
            {
                DataRow row = sayaclar.NewRow();
                cmbMakine.Items.Add(sayacReader["sayac_isim"]);
                row["sayac_isim"] = sayacReader["sayac_isim"].ToString();
                row["sayac_carpan"] = sayacReader["sayac_carpan"].ToString();
                row["sayac_min_tuketim"] = sayacReader["sayac_min_tuketim"].ToString();
                sayaclar.Rows.Add(row);
            }
            sayacReader.Close();
            con.Close();
        }
        void haftaSayisiHesapla()
        {
            haftaSayisi = 1;
            startDate = datePickerStart.Value;
            endDate = datePickerEnd.Value;
            int numberOfDays = (endDate - startDate).Days;
            for (int days = 0; days < numberOfDays; days++)
            {
                DateTime date = startDate.AddDays(days);
                if (date.DayOfWeek == DayOfWeek.Monday)
                    haftaSayisi++;
            }
        }
        void haftaBasiHesapla()
        {
            int numberOfDays = (endDate - startDate).Days;
            bool stop = false;
            while (!stop)
            {
                DateTime date = startDate;
                if (date.DayOfWeek == DayOfWeek.Monday)
                    stop = true;
                else
                    startDate = startDate.AddDays(-1);
            }
            stop = false;
            while(!stop)
            {
                DateTime date = endDate;
                if (date.DayOfWeek == DayOfWeek.Sunday)
                    stop = true;
                else
                    endDate = endDate.AddDays(1);
            }
        }
        void haftaVerileriHesapla(DateTime sDay, DateTime eDay)
        {
            progressBar.Visible = true;
            progressBar.Minimum = 0;
            progressBar.Maximum = 100;
            progressBar.Value = 0;
            grafikTable.Clear();
            grafikTable.Columns.Clear();
            haftalikBaslangic = sDay;
            haftalikBitis = sDay.AddDays(6);

            ortalamaBolen = 0;
            haftalikOrt = 0;

            //Bağlantı açık değilse bağlantıyı açıyoruz.
            if (con.State != ConnectionState.Open)
                con.Open();

            string haftalikBaslaStr, haftalikBitisStr;
            grafikTable.Columns.Add("Hafta Sayısı");
            grafikTable.Columns.Add("Başlangıç Tarihi");
            grafikTable.Columns.Add("Bitiş Tarihi");
            grafikTable.Columns.Add("Ortalama");
            grafikTable.Columns.Add("Minimum");
            grafikTable.Columns.Add("Maximum");


            //Hafta sayısını tabloya ekle>>
            for (int l = 1; l <= haftaSayisi; l++)
            {
                haftaIsimleri.Add(l + ". Hafta");
            }
            //Hafta sayısını tabloya ekle<<

            progressBar.Value = 20;
            try
            {
                aktifEkstraTuketimGetir();
                for (int i = 1; i <= haftaSayisi; i++)
                {
                    haftalikTuketim.Clear();
                    haftalikOrt = 0;
                    ortalamaBolen = 0;
                    haftalikBaslaStr = haftalikBaslangic.ToString("yyyy-MM-dd");
                    haftalikBitisStr = haftalikBitis.ToString("yyyy-MM-dd");
                    DateTime oncekiGunDT = haftalikBaslangic;

                    for (int k = 0; k <= 6; k++)
                    {
                        string oncekiGun = oncekiGunDT.AddDays(-1).ToString("yyyy-MM-dd");
                        string oncekiGunString = "SELECT * From SAYAC_BILGISI WHERE ISIM = '" + sayacAdi + "' AND TARIH = '" + oncekiGun + "' AND KWH <> 0 ORDER BY KWH ASC";
                        SqlCommand oncekiGunCommand = new SqlCommand(oncekiGunString, con);
                        SqlDataReader oncekiGunReader = oncekiGunCommand.ExecuteReader();
                        ilkKWH = 0;
                        while (oncekiGunReader.Read())
                        {
                            ilkKWH = Convert.ToDouble(oncekiGunReader["KWH"]);
                            break;
                        }
                        oncekiGunReader.Close();
                        string dinamikTarih = haftalikBaslangic.AddDays(k).ToString("yyyy-MM-dd");
                        string dinamikString = "SELECT * From SAYAC_BILGISI WHERE ISIM = '" + sayacAdi + "' AND TARIH = '" + dinamikTarih + "' AND KWH <> 0 ORDER BY KWH ASC";
                        SqlCommand dinamikCommand = new SqlCommand(dinamikString, con);
                        SqlDataReader dinamikReader = dinamikCommand.ExecuteReader();
                        while (dinamikReader.Read())
                        {
                            double KWH = Convert.ToDouble(dinamikReader["KWH"]);
                            double gunlukTuketim = Math.Round(((KWH - ilkKWH) * sayacCarpan), 3);
                            if (ekstraSayac.IndexOf(sayacAdi) != -1)
                            {
                                if (ekstraSayac.IndexOf(sayacAdi) != -1)
                                {
                                    for (int j = 0; j < ekstraSayac.Count; j++)
                                    {
                                        if (ekstraSayac[j].ToString() == sayacAdi)
                                        {
                                            if (Convert.ToDateTime(ekstraBaslangic[j]) <= Convert.ToDateTime(dinamikTarih) && Convert.ToDateTime(ekstraBitis[j]) >= Convert.ToDateTime(dinamikTarih))
                                            {
                                                gunlukTuketim += Convert.ToDouble(ekstraKWH[j]);
                                            }
                                        }
                                    }
                                }
                            }
                            
                            if (gunlukTuketim >= sayacMinTuketim)
                            {
                                haftalikOrt = haftalikOrt + gunlukTuketim;
                                ortalamaBolen++;
                                haftalikTuketim.Add(gunlukTuketim);
                            }
                            KWH = 0;
                            break;
                        }
                        dinamikReader.Close();
                        oncekiGunDT = oncekiGunDT.AddDays(1);
                    }

                    haftalikTuketim.Sort();

                    DataRow haftalikRow = grafikTable.NewRow();
                    haftalikRow[0] = i;
                    haftalikRow[1] = haftalikBaslaStr;
                    haftalikRow[2] = haftalikBitisStr;
                    haftalikRow[3] = Math.Round(haftalikOrt / ortalamaBolen, 3);
                    try
                    {
                        haftalikRow[4] = haftalikTuketim[0];
                        haftalikRow[5] = haftalikTuketim[haftalikTuketim.Count - 1];
                    }
                    catch (Exception ex)
                    {
                        haftalikRow[4] = 0;
                        haftalikRow[5] = 0;
                    }
                    grafikTable.Rows.Add(haftalikRow);

                    if (haftalikBitis.AddDays(7) < endDate)
                    {
                        haftalikBaslangic = haftalikBaslangic.AddDays(7);
                        haftalikBitis = haftalikBitis.AddDays(7);
                    }
                    else
                    {
                        haftalikBaslangic = haftalikBaslangic.AddDays(7);
                        haftalikBitis = endDate;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Veri bulunamadı.\n\n\n\n!"+ex);
            }

            progressBar.Value = 60;
        }
        void grafikOlustur()
        {
            genislik = 1;
            try
            {
                chart1.Titles.Clear();
                chart1.Titles.Add(sayacAdi);

                chart1.Series.Clear();
                chart1.ChartAreas.Clear();
                chart1.ChartAreas.Add("areaSayac");
                chart1.Series.Add("Max");
                chart1.Series.Add("Ort");
                chart1.Series.Add("Min");
                chart1.Width = 400;
                for (int i = 1; i <= grafikTable.Rows.Count; i++)
                {
                    double ortDeger = Convert.ToDouble(grafikTable.Rows[i - 1][3]);
                    double minDeger = Convert.ToDouble(grafikTable.Rows[i - 1][4]);
                    double maxDeger = Convert.ToDouble(grafikTable.Rows[i - 1][5]);
                    DataPoint dp = new DataPoint();
                    dp.AxisLabel = i + ". Hafta\n" + grafikTable.Rows[i - 1][1] + " - " + grafikTable.Rows[i - 1][2];
                    dp.XValue = i - 1;
                    dp.YValues = new double[] { maxDeger };
                    if (maxGG)
                        dp.Label = maxDeger.ToString();
                    else
                        dp.Label = "";
                    dp.LabelAngle = 90;
                    chart1.Series["Max"].Points.Add(dp);

                    DataPoint dp2 = new DataPoint();
                    dp2.AxisLabel = i + ". Hafta";
                    dp2.LabelAngle = 45;
                    dp2.XValue = i - 1;
                    dp2.YValues = new double[] { minDeger };
                    if (minGG)
                        dp2.Label = minDeger.ToString();
                    else
                        dp2.Label = "";
                    chart1.Series["Min"].Points.Add(dp2);

                    DataPoint dp3 = new DataPoint();
                    dp3.AxisLabel = i + ". Hafta";
                    dp3.LabelAngle = 45;
                    dp3.XValue = i - 1;
                    dp3.YValues = new double[] { ortDeger };
                    if (ortGG)
                        dp3.Label = ortDeger.ToString();
                    else
                        dp3.Label = "";
                    chart1.Series["Ort"].Points.Add(dp3);

                    genislik += 1;
                    chart1.ChartAreas["areaSayac"].AxisX.IsLabelAutoFit = true;
                    chart1.ChartAreas["areaSayac"].AxisX.LabelAutoFitStyle = LabelAutoFitStyles.LabelsAngleStep90;
                    chart1.ChartAreas["areaSayac"].AxisX.LabelStyle.Enabled = true;
                    chart1.ChartAreas["areaSayac"].AxisX.Interval = 1;
                }
                chart1.Width += (genislik * 80);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            progressBar.Value = 100;
            timer1.Start();
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
    }
}
