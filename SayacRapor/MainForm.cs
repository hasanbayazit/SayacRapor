﻿using System;
using System.Data;
using System.Collections;
using System.Configuration;
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
        string dinamikTarih;
        ArrayList ekstraBaslangic = new ArrayList();
        ArrayList ekstraBitis = new ArrayList();
        ArrayList ekstraSayac = new ArrayList();
        ArrayList ekstraKWH = new ArrayList();
        ArrayList minimumTuketim = new ArrayList();
        ArrayList ortalamaBolen = new ArrayList();
        ArrayList gunlukToplam = new ArrayList();
        ArrayList gunlukOrtalama = new ArrayList();
        ArrayList renklendirCol = new ArrayList();
        ArrayList renklendirRow = new ArrayList();
        ArrayList colNames = new ArrayList();
        ArrayList colDate = new ArrayList();
        ArrayList colKWH = new ArrayList();
        ArrayList listIlkIsım = new ArrayList();
        ArrayList multipleCell = new ArrayList();
        ArrayList multipleCol = new ArrayList();
        ArrayList listIlkKWH = new ArrayList();
        DataTable sayacTable = new DataTable();
        DataTable gunlukTable = new DataTable();
        double oncekiKWH = 0;
        string oncekiGun;
        string ilkGunString;
        string startDate, endDate;
        int haftaSayisi, sayi;
        int rowSayi = 0;

        Boolean adminMode = false;
        string sayacIsim, tarih;
        double eskiKWH, yeniKWH;
        Boolean insertMode = true;
        DateTime ilkGunDateTime, startZaman, endZaman;
        TimeSpan zaman;
        /*public static string conString = "Data Source=DESKTOP-VJMT9PK\\SQLEXPRESS;Initial Catalog=SayaclarTest;User ID=sa;Password=a123456*";*/
        string serverIP, tabloAdi, userID, password;
        public static string conString;
        SqlConnection con;

        private void Form1_Load(object sender, EventArgs e)
        {
            progressBar.Visible = true;
            progressBar.Minimum = 0;
            progressBar.Maximum = 100;
            progressBar.Value = 0;
            groupBox2.Width = Screen.PrimaryScreen.Bounds.Width - 50;
            panel3.Width = Screen.PrimaryScreen.Bounds.Width - 50;
            listBox3.Location = new Point(listBox2.Location.X - listBox3.Width - 5, listBox2.Location.Y);
            listBox1.Location = new Point(listBox3.Location.X - listBox1.Width - 5 ,listBox2.Location.Y);
            settingsYukle();
            conString = "Data Source=" + serverIP + ";Initial Catalog=" + tabloAdi + ";User ID=" + userID + ";Password=" + password;
            con = new SqlConnection(conString);
            try
            {
                con.Open();
                gunlukGrafik gGrafikForm = new gunlukGrafik();
                this.AutoScroll = true;
                startDate = DateTime.Now.ToString("yyyy-MM") + "-01";
                endDate = DateTime.Now.ToString("yyyy-MM-dd");
                datePickerStart.Value = DateTime.Parse(DateTime.Now.ToString("yyyy-MM") + "-01");
                ayar();
                sayacGetir(startDate, endDate);
            }
            catch(Exception ex)
            {
                MessageBox.Show("Sunucuya bağlanılamadı.\n" +ex);
                con.Close();
            }
        }

        private void settingsYukle()
        {
            serverIP = Settings.Default.serverIP;
            tabloAdi = Settings.Default.tabloAdi;
            userID = Settings.Default.userID;
            password = Settings.Default.password;
            progressBar.Value = 10;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            startDate = datePickerStart.Value.ToString("yyyy-MM-dd");
            endDate = datePickerEnd.Value.ToString("yyyy-MM-dd");
            ayar();
            sayacGetir(startDate, endDate);
        }

        public void sayacGetir(string sDate, string eDate)
        {
            rowSayi = 0;
            minimumTuketim.Clear();
            ortalamaBolen.Clear();
            gunlukToplam.Clear();
            gunlukOrtalama.Clear();
            renklendirCol.Clear();
            renklendirRow.Clear();
            listBox1.Items.Clear();
            listBox2.Items.Clear();
            listBox3.Items.Clear();
            dataGridTemizle();
            st.Reset();
            st.Restart();
            //dataGridTemizle();
            //Bağlantı açık değilse bağlantıyı açıyoruz.
            if (con.State != ConnectionState.Open)
            {
                con.Open();
            }
            aktifEkstraTuketimGetir();
            sayacTable.Columns.Add("TARIH");
            gunlukTable.Columns.Add("TARIH");

            //Tarih aralığı tabloya eklendi.
            DateTime gun = startZaman;
            for (int i = 0; i<sayi; i++)
            {
                string tmpTarih = gun.AddDays(i).ToString("yyyy-MM-dd");
                colDate.Add(tmpTarih);
                rowSayi++;
            }
            progressBar.Value = 30;

            //Sayaç isimleri tabloya eklendi.
            string sayacString = "Select * From SAYAC_AYAR ORDER BY sayac_sira";
            SqlCommand sayacCommand = new SqlCommand(sayacString, con);
            SqlDataReader sayacReader = sayacCommand.ExecuteReader();
            while (sayacReader.Read())
            {
                sayacTable.Columns.Add(sayacReader["sayac_isim"].ToString());
                gunlukTable.Columns.Add(sayacReader["sayac_isim"].ToString());
                minimumTuketim.Add(sayacReader["sayac_min_tuketim"]);
                gunlukOrtalama.Add(0);
                gunlukToplam.Add(0);
                ortalamaBolen.Add(0);
            }
            sayacReader.Close();
            sayacReader = sayacCommand.ExecuteReader();
            DataRow carpanRow = gunlukTable.NewRow();
            carpanRow[0] = "Çarpanlar:";
            while (sayacReader.Read())
            {
                string indexName = sayacReader["sayac_isim"].ToString();
                carpanRow[indexName] = sayacReader["sayac_carpan"];
            }
            gunlukTable.Rows.Add(carpanRow);

            sayacReader.Close();



            progressBar.Value = 50;
            st.Stop();
            listBox1.Items.Add("For Öncesi: " + st.ElapsedMilliseconds);
            st.Restart();

            //KWH verileri tabloya eklendi.
            for (int i = 0; i < colDate.Count; i++)
            {
                oncekiGun = ilkGunDateTime.AddDays(-1).ToString("yyyy-MM-dd");
                string oncekiGunString = "SELECT * From SAYAC_BILGISI WHERE TARIH = '" + oncekiGun + "' AND KWH <> 0 ORDER BY KWH ASC";
                SqlCommand oncekiGunCommand = new SqlCommand(oncekiGunString, con);
                SqlDataReader oncekiGunReader = oncekiGunCommand.ExecuteReader();
                listIlkIsım.Clear();
                listIlkKWH.Clear();
                while (oncekiGunReader.Read())
                {
                    if(listIlkIsım.IndexOf(oncekiGunReader["ISIM"]) == -1)
                    {
                        listIlkIsım.Add(oncekiGunReader["ISIM"]);
                        listIlkKWH.Add(oncekiGunReader["KWH"]);
                    }
                }
                oncekiGunReader.Close();

                DataRow sayacRow = sayacTable.NewRow();
                DataRow gunlukRow = gunlukTable.NewRow();
                dinamikTarih = colDate[i].ToString();
                string dinamikString = "SELECT * From SAYAC_BILGISI WHERE TARIH = '" + dinamikTarih + "' AND KWH <> 0 ORDER BY KWH DESC";
                SqlCommand dinamikCommand = new SqlCommand(dinamikString, con);
                SqlDataReader dinamikReader = dinamikCommand.ExecuteReader();
                sayacRow["TARIH"] = dinamikTarih;
                gunlukRow["TARIH"] = dinamikTarih;
                while (dinamikReader.Read())
                {
                    int carpan;
                    string indexName = dinamikReader["ISIM"].ToString();
                    string indexTarih = dinamikReader["TARIH"].ToString();
                    if (gunlukTable.Columns.IndexOf(indexName) != -1)
                        carpan = Convert.ToInt32(gunlukTable.Rows[0][indexName]);
                    else
                        carpan = 1;
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
                        //
                        if(nameIndex != -1)
                        {
                            renklendirCol.Add(nameIndex);
                            renklendirRow.Add(tarihIndex);
                            if(listBox3.Items.IndexOf(indexName) == -1)
                                listBox3.Items.Add(indexName);
                        }
                    }

                    if (nameIndex != -1)
                    {
                        double gunlukTuketim = Math.Round(((KWH - oncekiKWH)*carpan), 3);
                        sayacRow[indexName] = KWH;
                        if (ekstraSayac.IndexOf(indexName) != -1)
                        {
                            for (int j = 0; j < ekstraSayac.Count; j++)
                            {
                                if(ekstraSayac[j].ToString() == indexName)
                                {
                                    if(Convert.ToDateTime(ekstraBaslangic[j]) <= Convert.ToDateTime(indexTarih) && Convert.ToDateTime(ekstraBitis[j]) >= Convert.ToDateTime(indexTarih))
                                    {
                                        gunlukTuketim += Convert.ToDouble(ekstraKWH[j]);
                                    }
                                }
                            }
                        }
                        gunlukRow[indexName] = gunlukTuketim;
                        if(gunlukTuketim < 0)
                        {
                            renklendirCol.Add(nameIndex);
                            renklendirRow.Add(tarihIndex);
                            if (listBox3.Items.IndexOf(indexName) == -1)
                                listBox3.Items.Add(indexName);
                        }
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
            progressBar.Value = 80;
            st.Stop();
            listBox1.Items.Add("For : " + st.ElapsedMilliseconds);
            st.Restart();

            for(int i = 1; i<gunlukTable.Columns.Count; i++)
            {
                for (int l = 1; l < gunlukTable.Rows.Count; l++) 
                {
                    if(gunlukTable.Rows[l][i].ToString() != "")
                    {
                        double hucreDegeri = Convert.ToDouble(gunlukTable.Rows[l][i]);
                        if (hucreDegeri >= Convert.ToDouble(minimumTuketim[i - 1]))
                        {
                            gunlukOrtalama[i - 1] = Convert.ToDouble(gunlukOrtalama[i - 1]) + hucreDegeri;
                            ortalamaBolen[i - 1] = Convert.ToInt16(ortalamaBolen[i - 1]) + 1;
                        }
                        gunlukToplam[i - 1] = Convert.ToDouble(gunlukToplam[i - 1]) + hucreDegeri;
                    }
                }
            }



            DataRow gunlukOrt = gunlukTable.NewRow();
            DataRow gunlukTop = gunlukTable.NewRow();
            gunlukOrt[0] = "Ortalama:";
            gunlukTop[0] = "Toplam:";
            for (int i = 0; i < gunlukTable.Columns.Count-1; i++)
            {
                double gOrt = Convert.ToDouble(gunlukOrtalama[i]);
                int bol = Convert.ToInt16(ortalamaBolen[i]);
                gunlukOrt[i+1] = Math.Round(gOrt  / bol,3);
            }
            gunlukTable.Rows.Add(gunlukOrt);
            for (int k = 0; k < gunlukTable.Columns.Count-1; k++)
            {
                gunlukTop[k+1] = Math.Round(Convert.ToDouble(gunlukToplam[k]),3);
            }
            gunlukTable.Rows.Add(gunlukTop);
            sayacTable.Rows.Add();
            sayacTable.Rows.Add();
            dataViewSayac.DataSource = sayacTable;
            dataViewGunluk.DataSource = gunlukTable;
            if (con.State != ConnectionState.Closed)
            {
                con.Close();
            }
            st.Stop();
            listBox1.Items.Add("For Sonrası : " + st.ElapsedMilliseconds);
            FreezeBand(dataViewGunluk.Rows[0]);
            for(int i = 0; i<renklendirRow.Count;i++)
            {
                int row = Convert.ToInt16(renklendirRow[i]);
                int col = Convert.ToInt16(renklendirCol[i]);
                dataViewGunluk[col, row].Style.BackColor = Color.Red;
            }
            DataGridViewCellStyle renk = new DataGridViewCellStyle();

            for (int i = 0; i < dataViewSayac.Columns.Count; i++)
            {
                dataViewSayac.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
                dataViewGunluk.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
                int w = dataViewSayac.Columns[i].Width;
                dataViewGunluk.Columns[i].Width = w;
            }

            int ortIndex = dataViewGunluk.Rows[rowSayi+1].Cells["TARIH"].RowIndex;
            int topIndex = dataViewGunluk.Rows[rowSayi+2].Cells["TARIH"].RowIndex;
            renk.BackColor = Color.YellowGreen;
            dataViewGunluk.Rows[ortIndex].DefaultCellStyle = renk;
            dataViewGunluk.Rows[topIndex].DefaultCellStyle = renk;
            progressBar.Value = 90;
            panelBoyut();
        }

        void dataGridTemizle()
        {
            minimumTuketim.Clear();
            ortalamaBolen.Clear();
            gunlukToplam.Clear();
            gunlukOrtalama.Clear();
            renklendirCol.Clear();
            renklendirRow.Clear();
            colNames.Clear();
            colDate.Clear();
            colKWH.Clear();
            listIlkIsım.Clear();
            multipleCell.Clear();
            multipleCol.Clear();
            listIlkKWH.Clear();
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

        void ayar()
        {
            haftaSayisi = 1;
            ilkGunString = datePickerStart.Value.AddDays(-1).ToString("yyyy-MM-dd");
            ilkGunDateTime = datePickerStart.Value;
            startZaman = datePickerStart.Value;
            endZaman = datePickerEnd.Value;
            zaman = endZaman - startZaman;
            sayi = zaman.Days + 1;
            int numberOfDays = (endZaman - startZaman).Days;
            for (int days = 0; days < numberOfDays; days++)
            {
                DateTime date = startZaman.AddDays(days);
                if (date.DayOfWeek == DayOfWeek.Monday)
                    haftaSayisi++;
            }
            progressBar.Value = 20;
        }

        private void datePickerStart_ValueChanged(object sender, EventArgs e)
        {
            DateTime startDate = datePickerStart.Value;
            DateTime endDate = datePickerEnd.Value;
            if (startDate >= endDate)
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
                    dataViewGunluk.HorizontalScrollingOffset = e.NewValue;
                }
                else
                {
                    sayac = true;
                    if(e.NewValue != 0)
                        dataViewGunluk.FirstDisplayedScrollingRowIndex = e.NewValue;
                    else
                        dataViewGunluk.FirstDisplayedScrollingRowIndex = e.NewValue+1;
                }
            }


        }

        private void dataViewGunluk_Scroll(object sender, ScrollEventArgs e)
        {
            if(sayac)
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

        private void açıkKapatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Font defaultFont = SystemFonts.DefaultFont;
            if (adminMode)
            {
                adminMode = false;
                açıkKapatToolStripMenuItem.Text = "(Kapalı) - Aç";
                dataViewSayac.EditMode = DataGridViewEditMode.EditProgrammatically;
                statusLabel.ForeColor = Color.Green;
                statusLabel.Font = new Font(defaultFont.FontFamily, defaultFont.Size);
                statusLabel.Text = "Edit mod kapalı.";
                btnOtomatikDoldur.Visible = false;
                timer1.Start();
            }
            else if(!adminMode)
            {
                adminMode = true;
                açıkKapatToolStripMenuItem.Text = "(Açık) - Kapat";
                dataViewSayac.EditMode = DataGridViewEditMode.EditOnF2;
                statusLabel.ForeColor = Color.Red;
                statusLabel.Font = new Font(defaultFont.FontFamily, defaultFont.Size, FontStyle.Bold);
                statusLabel.Text = "Edit mod açık.";
                btnOtomatikDoldur.Visible = true;
                MessageBox.Show("Yapacağınız işlemler direkt olarak veritabanını etkileyecektir.", "Dikkat" ,MessageBoxButtons.OK ,MessageBoxIcon.Warning);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Interval = 10000;
            statusLabel.Text = "";
            progressBar.Visible = false;
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
                        if (eskiKWHDec == -1)
                        {
                            string insertString = "INSERT INTO SAYAC_BILGISI (ISIM, KWH, TARIH, SAAT) VALUES ('" + tmpIsim + "', @yeniKWH, '" + tmpTarih + "', '8')";
                            SqlCommand insertCommand = new SqlCommand(insertString, con);
                            insertCommand.Parameters.Add(new SqlParameter("yeniKWH", yeniKWHDec));
                            if (con.State != ConnectionState.Open)
                                con.Open();
                            insertCommand.ExecuteNonQuery();
                            if (con.State != ConnectionState.Closed)
                                con.Close();
                        }
                        else
                        {
                            string updateString = "UPDATE SAYAC_BILGISI SET KWH = @yeniKWH WHERE ISIM = '" + tmpIsim + "' AND TARIH = '" + tmpTarih + "' AND KWH = '"+eskiKWHDec+"'";
                            SqlCommand updateCommand = new SqlCommand(updateString, con);
                            updateCommand.Parameters.Add(new SqlParameter("yeniKWH", yeniKWHDec));
                            updateCommand.Parameters.Add(new SqlParameter("eskiKWH", eskiKWHDec));
                            if (con.State != ConnectionState.Open)
                                con.Open();
                            updateCommand.ExecuteNonQuery();
                            if (con.State != ConnectionState.Closed)
                                con.Close();
                        }
                        
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hata: " + ex);
                }
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

        private void dataViewSayac_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int row = dataViewSayac.CurrentCell.RowIndex;
            int cell = dataViewSayac.CurrentCell.ColumnIndex;
            dataViewGunluk.CurrentCell = dataViewGunluk.Rows[row+1].Cells[cell];
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataViewGunluk_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int row = dataViewGunluk.CurrentCell.RowIndex;
            if (row == 0)
                row = 1;
            int cell = dataViewGunluk.CurrentCell.ColumnIndex;
            try
            {
                dataViewSayac.CurrentCell = dataViewSayac.Rows[row-1].Cells[cell];
            }
            catch (Exception ex)
            {

            }
        }

        private void haftalıkGrafikToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool stop = false;
            while(!stop)
            {
                DateTime date = startZaman;
                if (date.DayOfWeek == DayOfWeek.Monday)
                    stop = true;
                else
                    startZaman = startZaman.AddDays(-1);
            }
            haftalikGrafik hGrafikFrom = new haftalikGrafik();
            hGrafikFrom.Show();
        }

        private void günlükGrafikToolStripMenuItem_Click(object sender, EventArgs e)
        {
            gunlukGrafik gGrafikForm = new gunlukGrafik();
            gGrafikForm.gelenTablo = gunlukTable;
            gGrafikForm.Show();
        }

        private void dataViewSayac_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            try
            {
                if (adminMode)
                {
                    int rowIndex = dataViewSayac.CurrentCell.RowIndex;
                    int colIndex = dataViewSayac.CurrentCell.ColumnIndex;
                    sayacIsim = dataViewSayac.Columns[colIndex].Name;
                    tarih = dataViewSayac.Rows[rowIndex].Cells["TARIH"].Value.ToString();
                    if (dataViewSayac.Rows[rowIndex].Cells[sayacIsim].Value.ToString() != "")
                    {
                        eskiKWH = Convert.ToDouble(dataViewSayac.Rows[rowIndex].Cells[sayacIsim].Value);
                        insertMode = false;
                    }
                    else
                    {
                        insertMode = true;
                        eskiKWH = -1;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void dataViewSayac_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if(adminMode)
            {
                int rowIndex2 = dataViewSayac.CurrentCell.RowIndex;
                int colIndex2 = dataViewSayac.CurrentCell.ColumnIndex;
                string sayacIsim2 = dataViewSayac.Columns[colIndex2].Name;
                string tarih2 = dataViewSayac.Rows[rowIndex2].Cells["TARIH"].Value.ToString();
                if (dataViewSayac.Rows[rowIndex2].Cells[sayacIsim].Value.ToString() != "")
                {
                    yeniKWH = Convert.ToDouble(dataViewSayac.Rows[rowIndex2].Cells[sayacIsim].Value);
                }
                if (sayacIsim == sayacIsim2 && tarih == tarih2 && eskiKWH != yeniKWH)
                {
                    //İsim ve tarih aynı ve hücre değişmiş.
                    if (insertMode)
                    {
                        //İnsert işlemleri
                        Decimal yeniKWHDec = Convert.ToDecimal(yeniKWH);
                        string insertString = "INSERT INTO SAYAC_BILGISI (ISIM, KWH, TARIH, SAAT) VALUES ('" + sayacIsim2+ "', @yeniKWH, '" + tarih2+"', '8')";
                        SqlCommand insertCommand = new SqlCommand(insertString, con);
                        insertCommand.Parameters.Add(new SqlParameter("yeniKWH", yeniKWHDec));
                        if (con.State != ConnectionState.Open)
                        {
                            con.Open();
                        }
                        insertCommand.ExecuteNonQuery();
                        if(con.State != ConnectionState.Closed)
                        {
                            con.Close();
                        }
                    }
                    else
                    {
                        try
                        {
                            //Update işlemleri
                            Decimal yeniKWHDec = Convert.ToDecimal(yeniKWH);
                            Decimal eskiKWHDec = Convert.ToDecimal(eskiKWH);
                            string updateString = "UPDATE SAYAC_BILGISI SET KWH = @yeniKWH WHERE ISIM = '" + sayacIsim2 + "' AND TARIH = '" + tarih2 + "' AND KWH = @eskiKWH";
                            SqlCommand updateCommand = new SqlCommand(updateString, con);
                            updateCommand.Parameters.Add(new SqlParameter("yeniKWH", yeniKWHDec));
                            updateCommand.Parameters.Add(new SqlParameter("eskiKWH", eskiKWHDec));
                            if (con.State != ConnectionState.Open)
                            {
                                con.Open();
                            }
                            updateCommand.ExecuteNonQuery();
                            if (con.State != ConnectionState.Closed)
                            {
                                con.Close();
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Hata: " + ex);
                        }
                        
                    }
                }
            }
        }

        private static void FreezeBand(DataGridViewBand band)
        {
            band.Frozen = true;
            DataGridViewCellStyle style = new DataGridViewCellStyle();
            style.BackColor = Color.DarkGray;
            band.DefaultCellStyle = style;
        }

        private void ayarlarToolStripMenuItem_Click(object sender, EventArgs e)
        {

            FormCollection fc = Application.OpenForms;
            foreach (Form frm in fc)
            {
                if (frm.Name == "SayacSettings")
                {
                    frm.Activate();
                    return;
                }
            }

            SayacSettings sayacSettings = new SayacSettings();
            sayacSettings.Show();
            /*
            SayacSettings sayacSettings = new SayacSettings();
            if (Application.OpenForms["SayacSettings"] != null)
            {
                sayacSettings.Activate();
            }
            else
            {
                sayacSettings.Show();
            }*/
        }

        void panelBoyut()
        {
            panel2.Location = new Point(panel1.Location.X, panel1.Location.Y + panel1.Height + 100);
            panel3.Height = panel1.Height + panel2.Height + 10;
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
            while(ekstraReader.Read())
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
