using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Collections;

namespace SayacRapor
{
    public partial class SayacSettings : Form
    {
        public SayacSettings()
        {
            InitializeComponent();
        }
        bool adminMode = true;
        string sayacIsim, eskiBilgi, yeniBilgi, kolonIsim;
        int sayacSira, sayacMin, sayacExtra, sayacCarpan, id;
        bool sayacMotorMu;
        SqlConnection con = new SqlConnection(MainForm.conString);
        public ArrayList hataliVeriler = new ArrayList();
        public ArrayList eksikKolonlar = new ArrayList();
        private void dataViewSettings_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string updateString = "";
            if (e.ColumnIndex == dataViewSettings.Columns["sayac_motor"].Index && e.RowIndex != -1)
            {
                int col = dataViewSettings.Columns["sayac_motor"].Index;
                int row = dataViewSettings.CurrentCell.RowIndex;
                string kolonIsim = dataViewSettings.Columns[col].Name;
                int id = Convert.ToInt16(dataViewSettings.Rows[row].Cells["id"].Value);
                bool sayacMotor = Convert.ToBoolean(dataViewSettings[col,row].Value);
                if (kolonIsim == "sayac_motor")
                {
                    if (sayacMotor == false)
                        updateString = "UPDATE SAYAC_AYAR SET sayac_motor = 1 WHERE id = @id";
                    else
                        updateString = "UPDATE SAYAC_AYAR SET sayac_motor = 0 WHERE id = @id";
                }

                SqlCommand updateCommand = new SqlCommand(updateString, con);
                updateCommand.Parameters.Add(new SqlParameter("id", id));
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

        private void SayacSettings_Load(object sender, EventArgs e)
        {
            veriGetir();
            ekstraTuketimGetir();
            sayacIsimGetir();
            listEksikEkle();
            listHataliEkle();
        }

        private void listHataliEkle()
        {
            for (int i = 0; i < hataliVeriler.Count; i++)
            {
                listHatali.Items.Add(hataliVeriler[i]);
            }
        }

        private void listEksikEkle()
        {
            for (int i = 0; i < eksikKolonlar.Count; i++)
            {
                listEksik.Items.Add(eksikKolonlar[i]);
            }
        }

        private void btnSayacSil_Click(object sender, EventArgs e)
        {
            int row = Convert.ToInt32(dataViewSettings.CurrentCell.RowIndex);
            int col = Convert.ToInt32(dataViewSettings.CurrentCell.ColumnIndex);
            int id = Convert.ToInt16(dataViewSettings.Rows[row].Cells["id"].Value);
            string isim = dataViewSettings.Rows[row].Cells["sayac_isim"].Value.ToString();

            string deleteString = "DELETE FROM SAYAC_AYAR WHERE id = @id";
            SqlCommand deleteCommand = new SqlCommand(deleteString, con);
            deleteCommand.Parameters.Add(new SqlParameter("id", id));

            if (con.State != ConnectionState.Open)
            {
                con.Open();
            }
            DialogResult silmeOnayi = new DialogResult();
            silmeOnayi = MessageBox.Show(isim + " sayacını silmek istiyor musunuz?", "Sayaç silme onayı", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(silmeOnayi == DialogResult.Yes)
            {
                deleteCommand.ExecuteNonQuery();
                MessageBox.Show("Silme işlemi başarılı.");
            }
            if (con.State != ConnectionState.Closed)
            {
                con.Close();
            }
            veriGetir();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string insertString = "INSERT INTO SAYAC_AYAR (sayac_isim, sayac_carpan, sayac_min_tuketim, sayac_ekstra_tuketim, sayac_sira, sayac_motor, sayac_id, makine_adi) VALUES ('','','','','','','','')";
            SqlCommand insertCommand = new SqlCommand(insertString, con);
            if (con.State != ConnectionState.Open)
            {
                con.Open();
            }
            insertCommand.ExecuteNonQuery();
            if (con.State != ConnectionState.Closed)
            {
                con.Close();
            }
            veriGetir();
            dataViewSettings.FirstDisplayedScrollingRowIndex = dataViewSettings.RowCount - 1;
            dataViewSettings[1, dataViewSettings.RowCount - 1].Selected = true;
        }

        private void buttonEkstraBitir_Click(object sender, EventArgs e)
        {
            int rowIndex = dataViewEkstra.CurrentCell.RowIndex;
            int ekstraId = Convert.ToInt32(dataViewEkstra.Rows[rowIndex].Cells["id"].Value);
            string bitisTarihi = dateTimeBitis2.Value.ToString("yyyy-MM-dd");
            string updateString = "UPDATE SAYAC_EKSTRA SET bitis_tarihi = '" + bitisTarihi + "' WHERE id = '" + ekstraId + "'";
            SqlCommand updateCommand = new SqlCommand(updateString, con);
            con.Open();
            updateCommand.ExecuteNonQuery();
            con.Close();
            ekstraTuketimGetir();
        }

        private void btnSayacEkle_Click(object sender, EventArgs e)
        {
            if(txtSayacIsım.Text != "")
            {
                sayacSira = Convert.ToInt32(txtSayacSira.Value);
                sayacIsim = txtSayacIsım.Text;
                if (txtSayacMin.Text != "")
                {
                    if(SayiMi(txtSayacMin.Text))
                    {
                        sayacMin = Convert.ToInt32(txtSayacMin.Text);
                    }else
                    {
                        MessageBox.Show("Sayaç minimum tüketim değeri sayısal değil.");
                    }
                }
                if (txtSayacExtra.Text != "")
                {
                    if (SayiMi(txtSayacExtra.Text))
                    {
                        sayacExtra = Convert.ToInt32(txtSayacExtra.Text);
                    }else
                    {
                        MessageBox.Show("Sayaç ekstra tüketim değeri sayısal değil.");
                    }
                }
                if (txtSayacCarpan.Text != "")
                {
                    if (SayiMi(txtSayacCarpan.Text))
                    {
                        sayacCarpan = Convert.ToInt32(txtSayacCarpan.Text);
                    }else
                    {
                        MessageBox.Show("Sayaç sayac çarpan değeri sayısal değil.");
                    }
                }
                if(txtSayacMin.Text == "" || txtSayacExtra.Text == "" || txtSayacCarpan.Text == "")
                {
                    DialogResult dialog = new DialogResult();
                    dialog = MessageBox.Show("Minimum, Sayaç Çarpan ve Ekstra tüketim girmeden kayıt eklemek istiyor musunuz?", "Sayaç Ekle", MessageBoxButtons.YesNo);
                    if (dialog == DialogResult.Yes && SayiMi(txtSayacMin.Text) == true && SayiMi(txtSayacExtra.Text) == true && SayiMi(txtSayacCarpan.Text))
                    {
                        sayacEkle();
                        veriGetir();
                        temizle();
                    }
                }
                else if(SayiMi(txtSayacMin.Text) == true && SayiMi(txtSayacExtra.Text) == true && SayiMi(txtSayacCarpan.Text))
                {
                    sayacEkle();
                    veriGetir();
                    temizle();
                }
            }
            else
            {
                MessageBox.Show("Sayaç ismini giriniz.");
            }
        }

        private void radioTumu_CheckedChanged(object sender, EventArgs e)
        {
            ekstraTuketimGetir();
        }

        private void radioAktif_CheckedChanged(object sender, EventArgs e)
        {
            ekstraTuketimGetir();
        }

        private void buttonEkstraBaslat_Click(object sender, EventArgs e)
        {
            string baslangicTarihi = dateTimeBaslangic.Value.ToString("yyyy-MM-dd");
            string bitisTarihi = dateTimeBitis.Value.ToString("yyyy-MM-dd");
            string sayacIsim = cmbSayac.Text;
            decimal ekstraTuketim = Convert.ToDecimal(txtEkstraKWH.Text);
            decimal ekstraDec = Convert.ToDecimal(ekstraTuketim);
            string ekstraInsert;
            if(checkBitis.Checked)
            {
                ekstraInsert = "INSERT INTO SAYAC_EKSTRA (baslangic_tarihi, bitis_tarihi, sayac_isim, ekstra_tuketim) VALUES (@baslangicTarihi,@bitisTarihi,@sayacIsim,@ekstraTuketim)";
                SqlCommand ekstraCommand = new SqlCommand(ekstraInsert, con);
                ekstraCommand.Parameters.Add(new SqlParameter("baslangicTarihi", baslangicTarihi));
                ekstraCommand.Parameters.Add(new SqlParameter("bitisTarihi", bitisTarihi));
                ekstraCommand.Parameters.Add(new SqlParameter("sayacIsim", sayacIsim));
                ekstraCommand.Parameters.Add(new SqlParameter("ekstraTuketim", ekstraDec));
                con.Open();
                ekstraCommand.ExecuteNonQuery();
                con.Close();
            }
            else
            {
                ekstraInsert = "INSERT INTO SAYAC_EKSTRA (baslangic_tarihi, sayac_isim, ekstra_tuketim) VALUES (@baslangicTarihi,@sayacIsim,@ekstraTuketim)";
                SqlCommand ekstraCommand = new SqlCommand(ekstraInsert, con);
                ekstraCommand.Parameters.Add(new SqlParameter("baslangicTarihi", baslangicTarihi));
                ekstraCommand.Parameters.Add(new SqlParameter("sayacIsim", sayacIsim));
                ekstraCommand.Parameters.Add(new SqlParameter("ekstraTuketim", ekstraDec));
                con.Open();
                ekstraCommand.ExecuteNonQuery();
                con.Close();
            }

            ekstraTuketimGetir();
            MessageBox.Show("Ekstra tüketim ekleme başarılı.");
            checkBitis.Checked = false;
            radioTumu.Checked = true;
            cmbSayac.Text = "";
            txtEkstraKWH.Clear();
        }

        private void dataViewSettings_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (adminMode)
            {
                int rowIndex = dataViewSettings.CurrentCell.RowIndex;
                int colIndex = dataViewSettings.CurrentCell.ColumnIndex;
                kolonIsim = dataViewSettings.Columns[colIndex].Name;
                id = Convert.ToInt16(dataViewSettings.Rows[rowIndex].Cells["id"].Value);
                if (dataViewSettings[colIndex,rowIndex].Value.ToString() != "")
                {
                    eskiBilgi = dataViewSettings[colIndex, rowIndex].ToString();
                }
                else
                {
                    eskiBilgi = "";
                }
            }
        }

        private void checkBitis_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBitis.Checked)
                dateTimeBitis.Enabled = true;
            else
                dateTimeBitis.Enabled = false;
        }

        private void btnEkstraSil_Click(object sender, EventArgs e)
        {
            int row = Convert.ToInt32(dataViewEkstra.CurrentCell.RowIndex);
            int col = Convert.ToInt32(dataViewEkstra.CurrentCell.ColumnIndex);
            int id = Convert.ToInt16(dataViewEkstra.Rows[row].Cells["id"].Value);
            string isim = dataViewEkstra.Rows[row].Cells["sayac_isim"].Value.ToString();

            string deleteString = "DELETE FROM SAYAC_EKSTRA WHERE id = @id";
            SqlCommand deleteCommand = new SqlCommand(deleteString, con);
            deleteCommand.Parameters.Add(new SqlParameter("id", id));

            if (con.State != ConnectionState.Open)
            {
                con.Open();
            }
            DialogResult silmeOnayi = new DialogResult();
            silmeOnayi = MessageBox.Show(isim + " ekstra tüketimi silmek istiyor musunuz?", "Ekstra Tüketim Silme Onayı", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (silmeOnayi == DialogResult.Yes)
            {
                deleteCommand.ExecuteNonQuery();
                MessageBox.Show("Silme işlemi başarılı.");
            }
            if (con.State != ConnectionState.Closed)
            {
                con.Close();
            }
            ekstraTuketimGetir();
        }

        private void dataViewSettings_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (adminMode && e.ColumnIndex != dataViewSettings.Columns["sayac_motor"].Index)
            {
                int rowIndex2 = dataViewSettings.CurrentCell.RowIndex;
                int colIndex2 = dataViewSettings.CurrentCell.ColumnIndex;
                string kolonIsim2 = dataViewSettings.Columns[colIndex2].Name;
                int id2 = Convert.ToInt16(dataViewSettings.Rows[rowIndex2].Cells["id"].Value);
                if (dataViewSettings[colIndex2, rowIndex2].Value.ToString() != "")
                {
                    yeniBilgi = dataViewSettings[colIndex2, rowIndex2].Value.ToString();
                }
                if (kolonIsim == kolonIsim2 && id == id2 && eskiBilgi != yeniBilgi)
                {
                    try
                    {
                        string updateString = "";
                        //Update işlemleri
                        if (kolonIsim2 == "sayac_isim")
                            updateString = "UPDATE SAYAC_AYAR SET sayac_isim = @yeniBilgi WHERE id = @id2";
                        else if(kolonIsim2 == "sayac_carpan")
                            updateString = "UPDATE SAYAC_AYAR SET sayac_carpan = @yeniBilgi WHERE id = @id2";
                        else if(kolonIsim2 == "sayac_min_tuketim")
                            updateString = "UPDATE SAYAC_AYAR SET sayac_min_tuketim = @yeniBilgi WHERE id = @id2";
                        else if(kolonIsim2 == "sayac_ekstra_tuketim")
                            updateString = "UPDATE SAYAC_AYAR SET sayac_ekstra_tuketim = @yeniBilgi WHERE id = @id2";
                        else if(kolonIsim2 == "sayac_sira")
                            updateString = "UPDATE SAYAC_AYAR SET sayac_sira = @yeniBilgi WHERE id = @id2";
                        else if(kolonIsim2 == "sayac_id")
                            updateString = "UPDATE SAYAC_AYAR SET sayac_id= @yeniBilgi WHERE id = @id2";
                        else if(kolonIsim2 == "makine_adi")
                            updateString = "UPDATE SAYAC_AYAR SET makine_adi = @yeniBilgi WHERE id = @id2";
                        else if (kolonIsim2 == "sayac_motor")
                        {
                            updateString = "UPDATE SAYAC_AYAR SET sayac_motor = @yeniBilgi WHERE id = @id2";
                            if (yeniBilgi == "False")
                                yeniBilgi = "0";
                            else
                                yeniBilgi = "1";
                        }

                        SqlCommand updateCommand = new SqlCommand(updateString, con);
                        updateCommand.Parameters.Add(new SqlParameter("yeniBilgi", yeniBilgi));
                        updateCommand.Parameters.Add(new SqlParameter("kolonIsmi1", kolonIsim2));
                        updateCommand.Parameters.Add(new SqlParameter("id2", id2));
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

        void sayacEkle()
        {

            if (radioIsitici.Checked)
            {
                sayacMotorMu = false;
            }
            else
            {
                sayacMotorMu = true;
            }
            if (con.State != ConnectionState.Open)
            {
                con.Open();
            }
            try
            {
                string insertQuery = "INSERT INTO SAYAC_AYAR (sayac_isim, sayac_carpan, sayac_min_tuketim, sayac_ekstra_tuketim, sayac_sira, sayac_motor) VALUES ('" + sayacIsim + "', '" + sayacCarpan + "', '" + sayacMin + "', '" + sayacExtra + "', '" + sayacSira + "', '" + sayacMotorMu + "')";
                SqlCommand insertCommand = new SqlCommand(insertQuery, con);
                insertCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Bir hata oluştu: " + ex);

            }
            if (con.State != ConnectionState.Closed)
            {
                con.Close();
            }
            MessageBox.Show("Sayaç kaydı başarılı.");
        }
        
        void veriGetir()
        {
            try
            {
                DataTable sayacAyarTable = new DataTable();
                sayacAyarTable.Clear();
                if (con.State != ConnectionState.Open)
                {
                    con.Open();
                }
                string selectString = "Select * From SAYAC_AYAR";
                SqlCommand command = new SqlCommand(selectString, con);
                SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
                dataAdapter.Fill(sayacAyarTable);
                dataViewSettings.DataSource = sayacAyarTable;
                if (con.State != ConnectionState.Closed)
                {
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Zaman aşımı." + ex);
            }
        }

        void temizle()
        {
            txtSayacCarpan.Clear();
            txtSayacExtra.Clear();
            txtSayacIsım.Clear();
            txtSayacMin.Clear();
        }
        bool SayiMi(string text)
        {
            foreach (char chr in text)
            {
                if (!Char.IsNumber(chr)) return false;
            }
            return true;
        }
        void ekstraTuketimGetir()
        {
            DataTable ekstraTable = new DataTable();
            ekstraTable.Clear();
            if (con.State != ConnectionState.Open)
            {
                con.Open();
            }
            string dateNow = DateTime.Now.ToString("yyyy-MM-dd");
            string ekstraString = "";
            if (radioTumu.Checked)
                ekstraString = "SELECT * FROM SAYAC_EKSTRA ORDER BY baslangic_tarihi,bitis_tarihi";
            else if (radioAktif.Checked)
                ekstraString = "SELECT * FROM SAYAC_EKSTRA WHERE bitis_tarihi >= '" + dateNow + "' OR bitis_tarihi IS NULL ORDER BY bitis_tarihi,baslangic_tarihi";
            SqlCommand ekstraCommand = new SqlCommand(ekstraString, con);
            SqlDataAdapter ekstraAdapter = new SqlDataAdapter(ekstraCommand);
            ekstraAdapter.Fill(ekstraTable);
            dataViewEkstra.DataSource = ekstraTable;
            if (con.State != ConnectionState.Closed)
            {
                con.Close();
            }
        }
        void sayacIsimGetir()
        {
            con.Open();
            cmbSayac.Items.Clear();
            string sayacString = "SELECT sayac_isim FROM SAYAC_AYAR ORDER BY sayac_isim";
            SqlCommand sayacCommand = new SqlCommand(sayacString, con);
            SqlDataReader sayacReader = sayacCommand.ExecuteReader();
            while(sayacReader.Read())
            {
                cmbSayac.Items.Add(sayacReader["sayac_isim"].ToString());
            }
            con.Close();
        }
    }
}
