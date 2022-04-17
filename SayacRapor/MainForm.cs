using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using System.Reflection;
using ClosedXML.Excel;

namespace SayacRapor
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }
        Stopwatch st = new Stopwatch();
        ArrayList colNames = new ArrayList();
        ArrayList colDate = new ArrayList();
        ArrayList colKWH = new ArrayList();
        ArrayList listIlkIsım = new ArrayList();
        ArrayList listIlkKWH = new ArrayList();
        DataTable sayacTable = new DataTable();
        DataTable gunlukTable = new DataTable();
        double oncekiKWH = 0, bugunKWH;
        string isim = "xxx";
        string oncekiGun;
        string ilkGunString;
        string startDate, endDate;
        int sayi;
        DateTime ilkGunDateTime, startZaman, endZaman;
        TimeSpan zaman;
        public static string conString = "Data Source=DESKTOP-VJMT9PK\\SQLEXPRESS;Initial Catalog=Sayaclar;User ID=sa;Password=a123456*";

        private void Form1_Load(object sender, EventArgs e)
        {
            this.AutoScroll = true;
            startDate = DateTime.Now.ToString("yyyy-MM") + "-01";
            endDate = DateTime.Now.ToString("yyyy-MM-dd");
            datePickerStart.Value = DateTime.Parse(DateTime.Now.ToString("yyyy-MM") + "-01");
            ilkGunString = datePickerStart.Value.AddDays(-1).ToString("yyyy-MM-dd");
            ilkGunDateTime = datePickerStart.Value;
            startZaman = datePickerStart.Value;
            endZaman = datePickerEnd.Value;
            zaman = endZaman - startZaman;
            sayi = zaman.Days + 1;
            sayacGetirIndexOF(startDate, endDate);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ilkGunString = datePickerStart.Value.AddDays(-1).ToString("yyyy-MM-dd");
            ilkGunDateTime = datePickerStart.Value;
            startZaman = datePickerStart.Value;
            endZaman = datePickerEnd.Value;
            zaman = endZaman - startZaman;
            sayi = zaman.Days + 1;
            startDate = datePickerStart.Value.ToString("yyyy-MM-dd");
            endDate = datePickerEnd.Value.ToString("yyyy-MM-dd");
            sayacGetirIndexOF(startDate, endDate);
        }
        public void veriGetir(string sDate, string eDate)
        {
            st.Start();
            SqlConnection con = new SqlConnection(conString);
            colNames.Clear();
            colDate.Clear();
            dataViewSayac.Rows.Clear();
            dataViewSayac.Refresh();
            dataViewGunluk.Rows.Clear();
            dataViewSayac.Refresh();
            //Bağlantı açık değilse bağlantıyı açıyoruz.
            if (con.State != ConnectionState.Open)
            {
                con.Open();
            }
            //Seçilen tarih aralığında SQL sorgumuzu oluşturuyoruz.
            try
            {
                string kayit = "Select ISIM,KWH,TARIH,SAAT From SAYAC_BILGISI WHERE TARIH >= '" + sDate + "' AND TARIH <= '" + eDate + "' AND KWH <> 0 ORDER BY ISIM, TARIH";
                SqlCommand komut = new SqlCommand(kayit, con);
                SqlDataAdapter da = new SqlDataAdapter(komut);
                DataTable dt = new DataTable();
                da.Fill(dt);

                //SQL Sorgusundan dönen verileri kolon ve tarih olarak kullanmak için array list'e aktarma.
                foreach (DataRow row in dt.Rows)
                {
                    if (colNames.IndexOf(row["ISIM"].ToString()) == -1)
                    {
                        colNames.Add(row["ISIM"].ToString());
                    }
                    if (colDate.IndexOf(row["TARIH"].ToString()) == -1)
                    {
                        colDate.Add(row["TARIH"].ToString());
                    }
                }

                colNames.Sort();
                colDate.Sort();
                int i = 1;
                //dataGridView kolonlarını oluşturma.
                foreach (string colName in colNames)
                {
                    dataViewSayac.ColumnCount = colNames.Count + 1;
                    dataViewGunluk.ColumnCount = colNames.Count + 1;
                    dataViewSayac.Columns[0].Name = "TARIH";
                    dataViewGunluk.Columns[0].Name = "TARIH";
                    dataViewSayac.Columns[i].Name = colName;
                    dataViewGunluk.Columns[i].Name = colName;
                    i++;
                }
                i = 0;
                //Çekilen tarihleri dataGridView'e ekleme.
                foreach (string tarih in colDate)
                {
                    dataViewSayac.Rows.Add(tarih);
                    dataViewGunluk.Rows.Add(tarih);
                }

                DateTime Gun = datePickerStart.Value.AddDays(-1);
                //dataGridView içerisine KWH değerlerini kolon ismine ve tarihe göre kontrol ederek yerleştirme.
                foreach (DataRow row in dt.Rows)
                {
                    if (isim != row["ISIM"].ToString())
                    {
                        isim = row["ISIM"].ToString();
                        Gun = datePickerStart.Value.AddDays(-1);
                        oncekiGun = Gun.ToString("yyyy-MM-dd");
                        oncekiKWH = 0;
                    }
                    string gunlukString = "Select * From SAYAC_BILGISI WHERE TARIH = '" + oncekiGun + "' AND ISIM = '" + row["ISIM"] + "' AND KWH <> 0";
                    SqlCommand gunlukCommand = new SqlCommand(gunlukString, con);
                    SqlDataAdapter gunlukAdapter = new SqlDataAdapter(gunlukCommand);
                    DataTable gunlukTable = new DataTable();
                    gunlukAdapter.Fill(gunlukTable);
                    isim = row["ISIM"].ToString();
                    try
                    {
                        oncekiKWH = Convert.ToDouble(gunlukTable.Rows[0]["KWH"]);
                    }
                    catch (Exception ex)
                    {

                    }

                    for (int k = 0; k < dataViewSayac.Rows.Count - 1; k++)
                    {
                        if (oncekiGun == row["TARIH"].ToString() && sDate != eDate)
                        {
                            break;
                        }
                        if (row["KWH"].ToString() != "")
                        {
                            if (dataViewSayac.Rows[k].Cells[row["ISIM"].ToString()].Value == null && dataViewGunluk.Rows[k].Cells[row["ISIM"].ToString()].Value == null)
                            {
                                if (dataViewSayac.Rows[k].Cells[0].Value.Equals(row["TARIH"]) && dataViewGunluk.Rows[k].Cells[0].Value.Equals(row["TARIH"]))
                                {
                                    dataViewSayac.Rows[k].Cells[row["ISIM"].ToString()].Value = row["KWH"].ToString();
                                    bugunKWH = Convert.ToDouble(row["KWH"]);
                                    double gunlukTuketim = Math.Round((bugunKWH - oncekiKWH), 3);
                                    dataViewGunluk.Rows[k].Cells[row["ISIM"].ToString()].Value = Math.Abs(gunlukTuketim);
                                    oncekiGun = row["TARIH"].ToString();
                                    oncekiKWH = Convert.ToDouble(row["KWH"]);
                                    isim = row["ISIM"].ToString();
                                    break;
                                }
                            }
                        }
                    }
                }
                oncekiKWH = 0;
                isim = "xxx";
                //Bağlantı kapalı değilse bağlantıyı kapatıyoruz.
                if (con.State != ConnectionState.Closed)
                {
                    con.Close();
                }

                TimeSpan time = new TimeSpan();
                time = datePickerStart.Value - datePickerEnd.Value;
                int sayi = Math.Abs(time.Days);
                panel1.Height = 75;
                panel2.Height = 75;
                panel3.Height = 200;
                for (int k = 0; k <= sayi; k++)
                {
                    panel1.Height += 25;
                    panel2.Height += 25;
                    panel3.Height += 55;
                }
                panel2.Location = new Point(panel2.Location.X, panel1.Location.Y + panel1.Height + 25);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            st.Stop();
            listBox1.Items.Add("Veri Getir Süre: " + st.ElapsedMilliseconds);
        }
        void sayacGetir(string sDate, string eDate)
        {
            st.Restart();
            SqlConnection con = new SqlConnection(conString);
            //dataGridTemizle();
            //Bağlantı açık değilse bağlantıyı açıyoruz.
            if (con.State != ConnectionState.Open)
            {
                con.Open();
            }
            string dinamikIsim = "";
            string dinamikTarih = "";
            string kolonString = "SELECT DISTINCT ISIM From SAYAC_BILGISI WHERE TARIH >= '" + sDate + "' AND TARIH <= '" + eDate + "' AND KWH <> 0";
            string tarihString = "SELECT DISTINCT TARIH From SAYAC_BILGISI WHERE TARIH >= '" + sDate + "' AND TARIH <= '" + eDate + "' AND KWH <> 0";
            string fullString = "SELECT * From SAYAC_BILGISI WHERE TARIH >= '" + sDate + "' AND TARIH <= '" + eDate + "' AND KWH <> 0 ORDER BY ISIM,TARIH";
            SqlCommand kolonCommand = new SqlCommand(kolonString, con);
            SqlDataReader kolonReader = kolonCommand.ExecuteReader();
            DataTable sayacTable = new DataTable();
            DataTable gunlukTable = new DataTable();
            dataViewGunluk.Rows.Clear();
            dataViewSayac.Rows.Clear();
            sayacTable.Clear();
            sayacTable.Columns.Clear();
            gunlukTable.Clear();
            gunlukTable.Columns.Clear();
            sayacTable.Columns.Add("TARIH");
            gunlukTable.Columns.Add("TARIH");
            while (kolonReader.Read())
            {
                sayacTable.Columns.Add(kolonReader["ISIM"].ToString());
                gunlukTable.Columns.Add(kolonReader["ISIM"].ToString());
            }
            kolonReader.Close();

            SqlCommand tarihCommand = new SqlCommand(tarihString, con);
            SqlDataReader tarihReader = tarihCommand.ExecuteReader();
            while (tarihReader.Read())
            {
                DataRow row = sayacTable.NewRow();
                DataRow row2 = gunlukTable.NewRow();
                row["TARIH"] = tarihReader["TARIH"].ToString();
                row2["TARIH"] = tarihReader["TARIH"].ToString();
                sayacTable.Rows.Add(row);
                gunlukTable.Rows.Add(row2);
            }
            tarihReader.Close();
            int s1 = 0, s2 = 1;
            /*for (int i = 0; i < sayacTable.Rows.Count; i++)
            {
                for (int j = 0; j < sayacTable.Columns.Count; j++)
            {*/
            st.Stop();
            listBox1.Items.Add("Foreach Öncesi: " + st.ElapsedMilliseconds);
            st.Restart();
            foreach (DataColumn col in sayacTable.Columns)
            {
                if (col.ColumnName != "TARIH")
                {
                    dinamikIsim = col.ColumnName.ToString();
                    foreach (DataRow row in sayacTable.Rows)
                    {
                        dinamikTarih = row["TARIH"].ToString();
                        string dinamikString = "SELECT TOP 1 ISIM,KWH From SAYAC_BILGISI WHERE TARIH = '" + dinamikTarih + "' AND ISIM = '" + dinamikIsim + "' AND KWH <> 0";
                        string ilkGunKWHString = "SELECT TOP 1 KWH FROM SAYAC_BILGISI WHERE TARIH = '" + ilkGunString + "' AND ISIM = '" + dinamikIsim + "'AND KWH <> 0";
                        SqlCommand dinamikCommand = new SqlCommand(dinamikString, con);
                        SqlCommand ilkGunCommand = new SqlCommand(ilkGunKWHString, con);

                        if (oncekiKWH == 0 || isim != dinamikIsim)
                        {
                            SqlDataReader ilkGunReader = ilkGunCommand.ExecuteReader();
                            while (ilkGunReader.Read())
                            {
                                oncekiKWH = Convert.ToDouble(ilkGunReader["KWH"]);
                                break;
                            }
                            ilkGunReader.Close();
                        }
                        SqlDataReader dinamikReader = dinamikCommand.ExecuteReader();

                        if (dinamikReader.Read() == true && s1 < sayacTable.Rows.Count)
                        {

                            sayacTable.Rows[s1][s2] = dinamikReader["KWH"].ToString();
                            gunlukTable.Rows[s1][s2] = dinamikReader["KWH"].ToString();
                            bugunKWH = Convert.ToDouble(dinamikReader["KWH"]);
                            double gunlukTuketim = Math.Round((bugunKWH - oncekiKWH), 3);
                            gunlukTable.Rows[s1][s2] = Math.Abs(gunlukTuketim);
                            oncekiKWH = Convert.ToDouble(dinamikReader["KWH"]);
                            isim = dinamikReader["ISIM"].ToString();
                        }
                        else if (dinamikReader.Read() == false && s1 < sayacTable.Rows.Count)
                        {
                            sayacTable.Rows[s1][s2] = "";
                        }
                        s1++;
                        dinamikReader.Close();
                        if (dinamikTarih == eDate)
                            break;
                    }
                    s2++;
                    s1 = 0;
                }
            }
            s2 = 1;
            dataViewSayac.DataSource = sayacTable;
            dataViewGunluk.DataSource = gunlukTable;
            if (con.State != ConnectionState.Closed)
            {
                con.Close();
            }
            st.Stop();
            listBox1.Items.Add("Foreach : " + st.ElapsedMilliseconds);
        }
        void sayacGetirFor(string sDate, string eDate)
        {
            st.Reset();
            st.Restart();
            SqlConnection con = new SqlConnection(conString);
            //dataGridTemizle();
            //Bağlantı açık değilse bağlantıyı açıyoruz.
            if (con.State != ConnectionState.Open)
            {
                con.Open();
            }
            string dinamikIsim = "";
            string dinamikTarih = "";
            string tarihString = "SELECT DISTINCT TARIH From SAYAC_BILGISI WHERE TARIH >= '" + sDate + "' AND TARIH <= '" + eDate + "' AND KWH <> 0";
            string fullString = "SELECT * From SAYAC_BILGISI WHERE TARIH >= '" + sDate + "' AND TARIH <= '" + eDate + "' AND KWH <> 0 ORDER BY ISIM,TARIH";
            DataTable sayacTable = new DataTable();
            DataTable gunlukTable = new DataTable();
            sayacTable.Clear();
            sayacTable.Columns.Clear();
            gunlukTable.Clear();
            gunlukTable.Columns.Clear();
            sayacTable.Columns.Add("TARIH");
            gunlukTable.Columns.Add("TARIH");

            SqlCommand tarihCommand = new SqlCommand(tarihString, con);
            SqlDataReader tarihReader = tarihCommand.ExecuteReader();
            while (tarihReader.Read())
            {
                colDate.Add(tarihReader["TARIH"].ToString());
                DataRow tarihSayacRow = sayacTable.NewRow();
                DataRow tarihGunlukRow = gunlukTable.NewRow();
                tarihSayacRow["TARIH"] = tarihReader["TARIH"].ToString();
                tarihGunlukRow["TARIH"] = tarihReader["TARIH"].ToString();
                sayacTable.Rows.Add(tarihSayacRow);
                gunlukTable.Rows.Add(tarihGunlukRow);
            }
            tarihReader.Close();

            string sayacString = "Select * From SAYAC_AYAR ORDER BY sayac_isim";
            SqlCommand sayacCommand = new SqlCommand(sayacString, con);
            SqlDataReader sayacReader = sayacCommand.ExecuteReader();
            while (sayacReader.Read())
            {
                sayacTable.Columns.Add(sayacReader["sayac_isim"].ToString());
                gunlukTable.Columns.Add(sayacReader["sayac_isim"].ToString());
            }
            sayacReader.Close();
            int s1 = 0, s2 = 1;
            /*for (int i = 0; i < sayacTable.Rows.Count; i++)
            {
                for (int j = 0; j < sayacTable.Columns.Count; j++)
            {*/
            st.Stop();
            listBox1.Items.Add("For Öncesi: " + st.ElapsedMilliseconds);
            st.Restart();
            DataRow row = sayacTable.NewRow();
            for (int i = 0; i < sayacTable.Rows.Count; i++)
            {
                dinamikTarih = colDate[i].ToString();
                ilkGunDateTime = ilkGunDateTime.AddDays(1);
                for (int j = 1; j < sayacTable.Columns.Count; j++)
                {
                    Boolean skip = false;
                    string oncekiDinamikGun = ilkGunDateTime.AddDays(-1).ToString("yyyy-MM-dd");
                    dinamikIsim = sayacTable.Columns[j].ToString();
                    string ilkGunKWHString = "SELECT TOP 1 KWH FROM SAYAC_BILGISI WHERE TARIH = '" + oncekiDinamikGun + "' AND ISIM = '" + dinamikIsim + "'";
                    SqlCommand ilkGunCommand = new SqlCommand(ilkGunKWHString, con);
                    SqlDataReader ilkGunReader = ilkGunCommand.ExecuteReader();
                    if (ilkGunReader.Read())
                    {
                        oncekiKWH = Convert.ToDouble(ilkGunReader["KWH"]);
                    }
                    else
                    {
                        skip = true;
                    }

                    ilkGunReader.Close();
                    if (skip == false)
                    {
                        string dinamikString = "SELECT TOP 1 ISIM,KWH From SAYAC_BILGISI WHERE TARIH = '" + dinamikTarih + "' AND ISIM = '" + dinamikIsim + "' AND KWH <> 0";
                        SqlCommand dinamikCommand = new SqlCommand(dinamikString, con);
                        SqlDataReader dinamikReader = dinamikCommand.ExecuteReader();
                        while (dinamikReader.Read())
                        {
                            sayacTable.Rows[i][j] = dinamikReader["KWH"].ToString();
                            bugunKWH = Convert.ToDouble(dinamikReader["KWH"]);
                            double gunlukTuketim = Math.Round((bugunKWH - oncekiKWH), 3);
                            gunlukTable.Rows[i][j] = Math.Abs(gunlukTuketim);
                            isim = dinamikReader["ISIM"].ToString();
                            break;
                        }
                        dinamikReader.Close();
                    }

                }

            }

            dataViewSayac.DataSource = sayacTable;
            dataViewGunluk.DataSource = gunlukTable;
            if (con.State != ConnectionState.Closed)
            {
                con.Close();
            }
            st.Stop();
            listBox1.Items.Add("For : " + st.ElapsedMilliseconds);
        }
        void sayacGetirIndexOF(string sDate, string eDate)
        {
            listBox1.Items.Clear();
            listBox2.Items.Clear();
            dataGridTemizle();
            st.Reset();
            st.Restart();
            SqlConnection con = new SqlConnection(conString);
            //dataGridTemizle();
            //Bağlantı açık değilse bağlantıyı açıyoruz.
            if (con.State != ConnectionState.Open)
            {
                con.Open();
            }
            string dinamikIsim = "";
            string dinamikTarih = "";
            string tarihString = "SELECT DISTINCT TARIH From SAYAC_BILGISI WHERE TARIH >= '" + sDate + "' AND TARIH <= '" + eDate + "' AND KWH <> 0";
            string fullString = "SELECT * From SAYAC_BILGISI WHERE TARIH >= '" + sDate + "' AND TARIH <= '" + eDate + "' AND KWH <> 0 ORDER BY ISIM,TARIH";
            sayacTable.Columns.Add("TARIH");
            gunlukTable.Columns.Add("TARIH");

            //Tarih aralığı tabloya eklendi.
            SqlCommand tarihCommand = new SqlCommand(tarihString, con);
            SqlDataReader tarihReader = tarihCommand.ExecuteReader();
            while (tarihReader.Read())
            {
                colDate.Add(tarihReader["TARIH"].ToString());
                DataRow tarihSayacRow = sayacTable.NewRow();
                DataRow tarihGunlukRow = gunlukTable.NewRow();
                tarihSayacRow["TARIH"] = tarihReader["TARIH"].ToString();
                tarihGunlukRow["TARIH"] = tarihReader["TARIH"].ToString();
            }
            tarihReader.Close();

            //Sayaç isimleri tabloya eklendi.
            string sayacString = "Select * From SAYAC_AYAR ORDER BY sayac_isim";
            SqlCommand sayacCommand = new SqlCommand(sayacString, con);
            SqlDataReader sayacReader = sayacCommand.ExecuteReader();
            while (sayacReader.Read())
            {
                sayacTable.Columns.Add(sayacReader["sayac_isim"].ToString());
                gunlukTable.Columns.Add(sayacReader["sayac_isim"].ToString());
            }
            sayacReader.Close();

            st.Stop();
            listBox1.Items.Add("For Öncesi: " + st.ElapsedMilliseconds);
            st.Restart();

            //KWH verileri tabloya eklendi.
            for (int i = 0; i < colDate.Count; i++)
            {
                oncekiGun = ilkGunDateTime.AddDays(-1).ToString("yyyy-MM-dd");
                string oncekiGunString = "SELECT * From SAYAC_BILGISI WHERE TARIH = '" + oncekiGun + "' AND KWH <> 0";
                SqlCommand oncekiGunCommand = new SqlCommand(oncekiGunString, con);
                SqlDataReader oncekiGunReader = oncekiGunCommand.ExecuteReader();
                listIlkIsım.Clear();
                listIlkKWH.Clear();
                while (oncekiGunReader.Read())
                {
                    listIlkIsım.Add(oncekiGunReader["ISIM"]);
                    listIlkKWH.Add(oncekiGunReader["KWH"]);
                }
                oncekiGunReader.Close();

                DataRow sayacRow = sayacTable.NewRow();
                DataRow gunlukRow = gunlukTable.NewRow();
                dinamikTarih = colDate[i].ToString();
                string dinamikString = "SELECT * From SAYAC_BILGISI WHERE TARIH = '" + dinamikTarih + "' AND KWH <> 0";
                SqlCommand dinamikCommand = new SqlCommand(dinamikString, con);
                SqlDataReader dinamikReader = dinamikCommand.ExecuteReader();
                sayacRow["TARIH"] = dinamikTarih;
                gunlukRow["TARIH"] = dinamikTarih;
                while (dinamikReader.Read())
                {
                    string indexName = dinamikReader["ISIM"].ToString();
                    string indexTarih = dinamikReader["TARIH"].ToString();
                    double KWH = Convert.ToDouble(dinamikReader["KWH"]);
                    int nameIndex = sayacTable.Columns.IndexOf(indexName);
                    int tarihIndex = colDate.IndexOf(indexTarih) + 1;
                    if (listIlkIsım.IndexOf(indexName) != -1)
                    {
                        oncekiKWH = Convert.ToDouble(listIlkKWH[listIlkIsım.IndexOf(indexName)]);
                    }
                    else
                    {
                        oncekiKWH = 0;
                    }

                    if (nameIndex != -1)
                    {
                        double gunlukTuketim = Math.Round((KWH - oncekiKWH), 3);
                        sayacRow[indexName] = KWH;
                        gunlukRow[indexName] = gunlukTuketim;
                    }
                    else
                    {
                        if (listBox2.Items.IndexOf(indexName) == -1)
                            listBox2.Items.Add(indexName);
                    }
                    KWH = 0;
                }
                sayacTable.Rows.Add(sayacRow);
                gunlukTable.Rows.Add(gunlukRow);
                dinamikReader.Close();
                ilkGunDateTime = ilkGunDateTime.AddDays(1);
            }
            st.Stop();
            listBox1.Items.Add("For : " + st.ElapsedMilliseconds);
            st.Restart();
            dataViewSayac.DataSource = sayacTable;
            dataViewGunluk.DataSource = gunlukTable;
            if (con.State != ConnectionState.Closed)
            {
                con.Close();
            }
            st.Stop();
            listBox1.Items.Add("For Sonrası : " + st.ElapsedMilliseconds);
        }

        /*
        void sayacGetir2(string sDate, string eDate)
        {
            st.Restart();
            SqlConnection con = new SqlConnection(conString);
            //dataGridTemizle();
            //Bağlantı açık değilse bağlantıyı açıyoruz.
            if (con.State != ConnectionState.Open)
            {
                con.Open();
            }

            string dinamikIsim = "";
            string dinamikTarih = "";
            string kolonString = "SELECT DISTINCT ISIM From SAYAC_BILGISI WHERE TARIH >= '" + sDate + "' AND TARIH <= '" + eDate + "' AND KWH <> 0";
            string tarihString = "SELECT DISTINCT TARIH From SAYAC_BILGISI WHERE TARIH >= '" + sDate + "' AND TARIH <= '" + eDate + "' AND KWH <> 0";
            string fullString = "SELECT * From SAYAC_BILGISI WHERE TARIH >= '" + sDate + "' AND TARIH <= '" + eDate + "' AND KWH <> 0 ORDER BY ISIM,TARIH";
            SqlCommand kolonCommand = new SqlCommand(kolonString, con);
            SqlDataReader kolonReader = kolonCommand.ExecuteReader();
            DataTable sayacTable = new DataTable();
            sayacTable.Columns.Clear();
            sayacTable.Clear();
            gunlukTable.Columns.Clear();
            gunlukTable.Clear();
            sayacTable.Columns.Add("TARIH");
            gunlukTable.Columns.Add("TARIH");
            while (kolonReader.Read())
            {
                sayacTable.Columns.Add(kolonReader["ISIM"].ToString());
                gunlukTable.Columns.Add(kolonReader["ISIM"].ToString());
            }
            kolonReader.Close();

            SqlCommand tarihCommand = new SqlCommand(tarihString, con);
            SqlDataReader tarihReader = tarihCommand.ExecuteReader();
            while (tarihReader.Read())
            {
                DataRow row = sayacTable.NewRow();
                DataRow row2 = gunlukTable.NewRow();
                row["TARIH"] = tarihReader["TARIH"].ToString();
                row2["TARIH"] = tarihReader["TARIH"].ToString();
                sayacTable.Rows.Add(row);
                gunlukTable.Rows.Add(row2);
            }
            tarihReader.Close();
            for (int i = 1; i < sayacTable.Columns.Count; i++)
            {
                for (int j = 0; j < sayacTable.Rows.Count; j++)
                {
                    dinamikIsim = sayacTable.Columns[i].ColumnName.ToString();
                    dinamikTarih = sayacTable.Rows[j][0].ToString();
                    string dinamikString = "SELECT TOP 1 KWH From SAYAC_BILGISI WHERE TARIH = '" + dinamikTarih + "' AND ISIM = '" + dinamikIsim + "' AND KWH <> 0";

                    SqlCommand dinamikCommand = new SqlCommand(dinamikString, con);
                    SqlDataReader dinamikReader = dinamikCommand.ExecuteReader();
                    if (dinamikReader.Read() == true)
                    {
                        sayacTable.Rows[j][i] = dinamikReader["KWH"].ToString();
                        gunlukTable.Rows[j][i] = dinamikReader["KWH"].ToString();
                        bugunKWH = Convert.ToDouble(dinamikReader["KWH"]);
                        double gunlukTuketim = Math.Round((bugunKWH - oncekiKWH), 3);
                        gunlukTable.Rows[s1][s2] = Math.Abs(gunlukTuketim);
                        oncekiKWH = Convert.ToDouble(dinamikReader["KWH"]);
                    }
                    else
                    {
                        sayacTable.Rows[j][i] = "";
                        gunlukTable.Rows[j][i] = "";
                    }
                    dinamikReader.Close();
                }
            }


            dataViewSayac.DataSource = sayacTable;
            dataViewGunluk.DataSource = gunlukTable;
            if (con.State != ConnectionState.Closed)
            {
                con.Close();
            }
            st.Stop();
            listBox1.Items.Add("Sayaç Getir2 Süre: " + st.ElapsedMilliseconds);

        }

        void sayacGetir3(string sDate, string eDate)
        {
            st.Restart();
            SqlConnection con = new SqlConnection(conString);
            //dataGridTemizle();
            //Bağlantı açık değilse bağlantıyı açıyoruz.
            if (con.State != ConnectionState.Open)
            {
                con.Open();
            }
            string tarihString2 = "Select DISTINCT TARIH From SAYAC_BILGISI WHERE TARIH >= '" + sDate + "' AND TARIH <= '" + eDate + "' AND KWH <> 0";
            SqlCommand tarihCommand2 = new SqlCommand(tarihString2, con);
            SqlDataReader tarihReader2 = tarihCommand2.ExecuteReader();
            while (tarihReader2.Read())
            {
                colDate.Add(tarihReader2["TARIH"].ToString());
            }
            tarihReader2.Close();

            string dinamikIsim = "";
            string dinamikTarih = "";
            string kolonString = "SELECT DISTINCT ISIM From SAYAC_BILGISI WHERE TARIH >= '" + sDate + "' AND TARIH <= '" + eDate + "' AND KWH <> 0";
            string tarihString = "SELECT DISTINCT TARIH From SAYAC_BILGISI WHERE TARIH >= '" + sDate + "' AND TARIH <= '" + eDate + "' AND KWH <> 0";
            string fullString = "SELECT * From SAYAC_BILGISI WHERE TARIH >= '" + sDate + "' AND TARIH <= '" + eDate + "' AND KWH <> 0 ORDER BY ISIM,TARIH";
            SqlCommand kolonCommand = new SqlCommand(kolonString, con);
            SqlDataReader kolonReader = kolonCommand.ExecuteReader();
            DataTable sayacTable = new DataTable();
            sayacTable.Columns.Clear();
            sayacTable.Clear();
            gunlukTable.Columns.Clear();
            gunlukTable.Clear();
            sayacTable.Columns.Add("TARIH");
            gunlukTable.Columns.Add("TARIH");
            while (kolonReader.Read())
            {
                sayacTable.Columns.Add(kolonReader["ISIM"].ToString());
                gunlukTable.Columns.Add(kolonReader["ISIM"].ToString());
            }
            kolonReader.Close();
            
            SqlCommand tarihCommand = new SqlCommand(tarihString, con);
            SqlDataReader tarihReader = tarihCommand.ExecuteReader();
            while (tarihReader.Read())
            {
                DataRow row = sayacTable.NewRow();
                DataRow row2 = gunlukTable.NewRow();
                row["TARIH"] = tarihReader["TARIH"].ToString();
                row2["TARIH"] = tarihReader["TARIH"].ToString();
                sayacTable.Rows.Add(row);
                gunlukTable.Rows.Add(row2);
            }
            tarihReader.Close();
            
            SqlCommand fullCommand = new SqlCommand(fullString, con);
            SqlDataAdapter fullAdapter = new SqlDataAdapter(fullCommand);
            DataTable newTable = new DataTable();
            fullAdapter.Fill(newTable);
            for (int i = 0; i < colDate.Count; i++)
            {
                for (int j = 1; j < sayacTable.Columns.Count; j++)
                {
                    dinamikIsim = sayacTable.Columns[j].ColumnName.ToString();
                    dinamikTarih = colDate[i].ToString();
                    string dinamikString = "SELECT TOP 1 KWH From SAYAC_BILGISI WHERE TARIH = '" + dinamikTarih + "' AND ISIM = '" + dinamikIsim + "' AND KWH <> 0";
                    SqlCommand dinamikCommand = new SqlCommand(dinamikString, con);
                    SqlDataReader dinamikReader = dinamikCommand.ExecuteReader();
                    while (dinamikReader.Read())
                    {
                        colKWH.Add(dinamikReader["KWH"].ToString());
                    }
                    if (dinamikReader.Read() == false)
                    {
                        colKWH.Add("");
                    }
                    dinamikReader.Close();
                    bugunKWH = Convert.ToDouble(dinamikReader["KWH"]);
                    double gunlukTuketim = Math.Round((bugunKWH - oncekiKWH), 3);
                    gunlukTable.Rows[s1][s2] = Math.Abs(gunlukTuketim);
                    oncekiKWH = Convert.ToDouble(dinamikReader["KWH"]);
                }
                DataRow row = sayacTable.NewRow();
                int o = 0;
                for (int j = 1; j < sayacTable.Columns.Count; j++)
                {
                    string isim = sayacTable.Columns[j].ColumnName.ToString();
                    row[isim] = colKWH[o].ToString();
                    o++;
                }
                row["TARIH"] = dinamikTarih;
                sayacTable.Rows.Add(row);
            }


            dataViewSayac.DataSource = sayacTable;
            dataViewGunluk.DataSource = gunlukTable;
            if (con.State != ConnectionState.Closed)
            {
                con.Close();
            }

            st.Stop();
            listBox1.Items.Add("Sayaç Getir3 Süre: " + st.ElapsedMilliseconds);
        }

        void sayacGetir4(string sDate, string eDate)
        {
            st.Restart();
            string rowString = "SELECT * From SAYAC_BILGISI WHERE TARIH >= '" + sDate + "' AND TARIH <= '" + eDate + "' AND KWH <> 0 ORDER BY ISIM,TARIH";

            SqlConnection con = new SqlConnection(conString);
            //dataGridTemizle();
            //Bağlantı açık değilse bağlantıyı açıyoruz.
            if (con.State != ConnectionState.Open)
            {
                con.Open();
            }
            string tarihString2 = "Select DISTINCT TARIH From SAYAC_BILGISI WHERE TARIH >= '" + sDate + "' AND TARIH <= '" + eDate + "' AND KWH <> 0";
            SqlCommand tarihCommand2 = new SqlCommand(tarihString2, con);
            SqlDataReader tarihReader2 = tarihCommand2.ExecuteReader();
            while (tarihReader2.Read())
            {
                colDate.Add(tarihReader2["TARIH"].ToString());
            }
            tarihReader2.Close();
            string sayacString = "Select * From SAYAC_AYAR ORDER BY sayac_isim";
            SqlCommand sayacCommand = new SqlCommand(sayacString, con);
            SqlDataReader sayacReader = sayacCommand.ExecuteReader();
            DataTable sayacTable = new DataTable();
            sayacTable.Columns.Add("TARIH");
            while (sayacReader.Read())
            {
                sayacTable.Columns.Add(sayacReader["sayac_isim"].ToString());
            }
            sayacReader.Close();

            SqlCommand rowCommand = new SqlCommand(rowString, con);
            SqlDataAdapter rowAdapter = new SqlDataAdapter(rowCommand);
            DataTable rowTable = new DataTable();
            rowAdapter.Fill(rowTable);
            for (int j = 1; j <= sayi; j++)
            {
                string tarih = colDate[j - 1].ToString();
                string dinamikString = "SELECT ISIM,TARIH,KWH From SAYAC_BILGISI WHERE TARIH = '" + tarih + "' AND KWH <> 0 ORDER BY ISIM, TARIH";
                SqlCommand dinamikCommand = new SqlCommand(dinamikString, con);
                SqlDataReader dinamikReader = dinamikCommand.ExecuteReader();
                DataRow row = sayacTable.NewRow();
                int o = 0;
                string isim2 = "";
                int m = 1;
                while (dinamikReader.Read())
                {
                tekrar:
                    if (m < sayacTable.Columns.Count)
                        isim2 = sayacTable.Columns[m].ColumnName.ToString();
                    else
                        m = 1;
                    if (colDate[o].ToString() == dinamikReader[1].ToString() && isim2 == dinamikReader[0].ToString())
                    {
                        row[isim2] = dinamikReader[2].ToString();
                        o++;
                    }
                    else
                    {
                        m++;
                        goto tekrar;
                    }
                    m++;
                }
                if (dinamikReader.Read() == false)
                {
                    row[isim2] = "";
                }
                row["TARIH"] = tarih;
                sayacTable.Rows.Add(row);
                dinamikReader.Close();
                bugunKWH = Convert.ToDouble(dinamikReader["KWH"]);
                double gunlukTuketim = Math.Round((bugunKWH - oncekiKWH), 3);
                gunlukTable.Rows[s1][s2] = Math.Abs(gunlukTuketim);
                oncekiKWH = Convert.ToDouble(dinamikReader["KWH"]);
            }


            dataViewSayac.DataSource = sayacTable;
            dataViewGunluk.DataSource = gunlukTable;
            if (con.State != ConnectionState.Closed)
            {
                con.Close();
            }
            st.Stop();
            listBox1.Items.Add("Sayaç Getir4 Süre: " + st.ElapsedMilliseconds);

        }
*/

        void dataGridTemizle()
        {
            listBox1.Items.Clear();
            dataViewSayac.DataSource = null;
            dataViewGunluk.DataSource = null;
            colNames.Clear();
            colDate.Clear();
            sayacTable.Clear();
            gunlukTable.Clear();
            sayacTable.Columns.Clear();
            gunlukTable.Columns.Clear();
            dataViewSayac.Rows.Clear();
            dataViewGunluk.Rows.Clear();
            dataViewSayac.Refresh();
            dataViewSayac.Refresh();
        }

        private void datePickerStart_ValueChanged(object sender, EventArgs e)
        {
            DateTime startDate = datePickerStart.Value;
            DateTime endDate = datePickerEnd.Value;
            if (startDate > endDate)
            {
                datePickerEnd.Value = DateTime.Now;
            }
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();

            //Total aktarma
            foreach (DataGridViewColumn column in dataViewSayac.Columns)
            {
                dt.Columns.Add(column.HeaderText, column.ValueType);
            }
            foreach (DataGridViewRow row in dataViewSayac.Rows)
            {
                dt.Rows.Add();
                foreach (DataGridViewCell cell in row.Cells)
                {
                    dt.Rows[dt.Rows.Count - 1][cell.ColumnIndex] = cell.Value;
                }
            }

            dt.Rows.Add();
            //Günlük aktarma
            foreach (DataGridViewColumn column in dataViewGunluk.Columns)
            {
                dt.Rows[dt.Rows.Count - 1][column.Index] = column.Name;
            }
            dt.Rows.Add();

            foreach (DataGridViewRow row in dataViewGunluk.Rows)
            {
                foreach (DataGridViewCell cell in row.Cells)
                {
                    dt.Rows[dt.Rows.Count - 1][cell.ColumnIndex] = cell.Value;
                }
                dt.Rows.Add();
            }

            string username = Environment.UserName;
            //Excel çıktı ayarları.
            string folderPath = "C:\\Users\\" + username + "\\Desktop\\";
            string folderName = "Sayaç Tüketim " + startDate + " - " + endDate + ".xlsx";
            if (!System.IO.Directory.Exists(folderPath))
            {
                System.IO.Directory.CreateDirectory(folderPath);
            }
            using (XLWorkbook wb = new XLWorkbook())
            {
                wb.Worksheets.Add(dt, "Customers");
                wb.SaveAs(folderPath + folderName);
            }
            MessageBox.Show("Dosya masaüstüne kaydedildi.");
        }

        private void dataViewSayac_Scroll(object sender, ScrollEventArgs e)
        {
            dataViewGunluk.FirstDisplayedScrollingColumnIndex = dataViewSayac.FirstDisplayedScrollingColumnIndex;
            dataViewGunluk.FirstDisplayedScrollingRowIndex = dataViewSayac.FirstDisplayedScrollingRowIndex;
        }

        private void dataViewGunluk_Scroll(object sender, ScrollEventArgs e)
        {
            dataViewSayac.FirstDisplayedScrollingColumnIndex = dataViewGunluk.FirstDisplayedScrollingColumnIndex;
            dataViewSayac.FirstDisplayedScrollingRowIndex = dataViewGunluk.FirstDisplayedScrollingRowIndex;
        }

        private void dataViewSayac_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int row = dataViewSayac.CurrentCell.RowIndex;
            int cell = dataViewSayac.CurrentCell.ColumnIndex;
            dataViewGunluk.CurrentCell = dataViewGunluk.Rows[row].Cells[cell];
        }

        private void dataViewGunluk_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int row = dataViewGunluk.CurrentCell.RowIndex;
            int cell = dataViewGunluk.CurrentCell.ColumnIndex;
            dataViewSayac.CurrentCell = dataViewSayac.Rows[row].Cells[cell];
        }

        private void dataViewSayac_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            MessageBox.Show("Girdi");
        }
        private void dataViewSayac_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            MessageBox.Show("Değişti");
        }

        private void ayarlarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SayacSettings frm = new SayacSettings();
            frm.Show();
        }
    }
}
