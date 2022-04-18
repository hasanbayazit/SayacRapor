﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

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
            if (con.State != ConnectionState.Open)
            {
                con.Open();
            }
            string selectString = "Select * From SAYAC_AYAR";
            SqlCommand command = new SqlCommand(selectString, con);
            SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
            DataTable dataTable = new DataTable();
            dataAdapter.Fill(dataTable);
            dataViewSettings.DataSource = dataTable;
            if (con.State != ConnectionState.Closed)
            {
                con.Close();
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
    }
}
