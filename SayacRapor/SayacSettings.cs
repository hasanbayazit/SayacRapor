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

namespace SayacRapor
{
    public partial class SayacSettings : Form
    {
        public SayacSettings()
        {
            InitializeComponent();
        }

        string sayacIsim;
        int sayacSira, sayacMin, sayacExtra, maksSira = 0, sayacCarpan;
        bool sayacMotorMu;
        SqlConnection con = new SqlConnection(MainForm.conString);
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
            SqlDataReader dataReader = command.ExecuteReader(CommandBehavior.CloseConnection);

            if (dataReader.Read())
            {
                maksSira = dataTable.AsEnumerable().Max(r => r.Field<int>("sayac_sira"));
            }
            txtSayacSira.Value = maksSira + 1;
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
