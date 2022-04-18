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
        ArrayList multipleCell = new ArrayList();
        ArrayList listIlkKWH = new ArrayList();
        DataTable sayacTable = new DataTable();
        DataTable gunlukTable = new DataTable();
        double oncekiKWH = 0;
        string oncekiGun;
        string ilkGunString;
        string startDate, endDate;
        int sayi;
        //string dbName = "Sayaclar";
        string dbName = "SayaclarTest";

        Boolean adminMode = false;
        string sayacIsim, tarih;
        double eskiKWH, yeniKWH;
        Boolean insertMode = true;
        DateTime ilkGunDateTime, startZaman, endZaman;
        TimeSpan zaman;
        //public static string conString = "Data Source=DESKTOP-VJMT9PK\\SQLEXPRESS;Initial Catalog=Sayaclar;User ID=sa;Password=a123456*";
        public static string conString = "Data Source=192.168.2.123;Initial Catalog=SayaclarTest;User ID=sa;Password=a123456*";
        SqlConnection con = new SqlConnection(conString);

        private void Form1_Load(object sender, EventArgs e)
        {
            this.AutoScroll = true;
            startDate = DateTime.Now.ToString("yyyy-MM") + "-01";
            endDate = DateTime.Now.ToString("yyyy-MM-dd");
            datePickerStart.Value = DateTime.Parse(DateTime.Now.ToString("yyyy-MM") + "-01");
            ayar();
            sayacGetir(startDate, endDate);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            startDate = datePickerStart.Value.ToString("yyyy-MM-dd");
            endDate = datePickerEnd.Value.ToString("yyyy-MM-dd");
            ayar();
            sayacGetir(startDate, endDate);
        }

        void sayacGetir(string sDate, string eDate)
        {
            listBox1.Items.Clear();
            listBox2.Items.Clear();
            dataGridTemizle();
            st.Reset();
            st.Restart();
            //dataGridTemizle();
            //Bağlantı açık değilse bağlantıyı açıyoruz.
            if (con.State != ConnectionState.Open)
            {
                con.Open();
            }
            string dinamikIsim = "";
            string dinamikTarih = "";
            string tarihString = "SELECT DISTINCT TARIH From SAYAC_BILGISI WHERE TARIH >= '" + sDate + "' AND TARIH <= '" + eDate + "' AND KWH <> 0 ORDER BY TARIH";
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
            string sayacString = "Select * From SAYAC_AYAR ORDER BY sayac_sira";
            SqlCommand sayacCommand = new SqlCommand(sayacString, con);
            SqlDataReader sayacReader = sayacCommand.ExecuteReader();
            while (sayacReader.Read())
            {
                sayacTable.Columns.Add(sayacReader["sayac_isim"].ToString());
                gunlukTable.Columns.Add(sayacReader["sayac_isim"].ToString());
            }
            sayacReader.Close();
            sayacReader = sayacCommand.ExecuteReader();
            DataRow carpanRow = gunlukTable.NewRow();
            while (sayacReader.Read())
            {
                string indexName = sayacReader["sayac_isim"].ToString();
                carpanRow[indexName] = sayacReader["sayac_carpan"];
            }
            sayacTable.Rows.Add();
            gunlukTable.Rows.Add(carpanRow);

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
                    }

                    if (nameIndex != -1)
                    {
                        double gunlukTuketim = Math.Round(((KWH - oncekiKWH)*carpan), 3);
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

        void ayar()
        {
            ilkGunString = datePickerStart.Value.AddDays(-1).ToString("yyyy-MM-dd");
            ilkGunDateTime = datePickerStart.Value;
            startZaman = datePickerStart.Value;
            endZaman = datePickerEnd.Value;
            zaman = endZaman - startZaman;
            sayi = zaman.Days + 1;
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

        private void açıkKapatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Font defaultFont = SystemFonts.DefaultFont;
            if (açıkKapatToolStripMenuItem.Text == "(Açık) - Kapat")
            {
                adminMode = false;
                açıkKapatToolStripMenuItem.Text = "(Kapalı) - Aç";
                dataViewSayac.EditMode = DataGridViewEditMode.EditProgrammatically;
                statusLabel.ForeColor = Color.Green;
                statusLabel.Font = new Font(defaultFont.FontFamily, defaultFont.Size);
                statusLabel.Text = "Edit mod kapalı.";
                timer1.Start();
            }
            else if(açıkKapatToolStripMenuItem.Text == "(Kapalı) - Aç")
            {
                adminMode = true;
                açıkKapatToolStripMenuItem.Text = "(Açık) - Kapat";
                dataViewSayac.EditMode = DataGridViewEditMode.EditOnF2;
                statusLabel.ForeColor = Color.Red;
                statusLabel.Font = new Font(defaultFont.FontFamily, defaultFont.Size, FontStyle.Bold);
                statusLabel.Text = "Edit mod açık.";
                MessageBox.Show("Yapacağınız işlemler direkt olarak veritabanını etkileyecektir.", "Dikkat" ,MessageBoxButtons.OK ,MessageBoxIcon.Warning);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Interval = 10000;
            statusLabel.Text = "";
        }

        private void btnOtomatikDoldur_Click(object sender, EventArgs e)
        {

        }

        private void dataViewSayac_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int row = dataViewSayac.CurrentCell.RowIndex;
            int cell = dataViewSayac.CurrentCell.ColumnIndex;
            dataViewGunluk.CurrentCell = dataViewGunluk.Rows[row].Cells[cell];
        }

        private void dataViewGunluk_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int row = dataViewGunluk.CurrentCell.RowIndex;
            int cell = dataViewGunluk.CurrentCell.ColumnIndex;
            dataViewSayac.CurrentCell = dataViewSayac.Rows[row].Cells[cell];
        }

        private void dataViewSayac_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if(adminMode)
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
                        //Update işlemleri
                        Decimal yeniKWHDec = Convert.ToDecimal(yeniKWH);
                        Decimal eskiKWHDec = Convert.ToDecimal(eskiKWH);
                        string updateString = "UPDATE SAYAC_BILGISI SET KWH = @yeniKWH WHERE ISIM = '"+sayacIsim2+"' AND TARIH = '"+tarih2+"' AND KWH = @eskiKWH";
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
                }
            }
        }

        private void ayarlarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SayacSettings frm = new SayacSettings();
            frm.Show();
        }
    }
}
