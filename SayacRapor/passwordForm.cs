using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SayacRapor
{
    public partial class passwordForm : Form
    {
        public passwordForm()
        {
            InitializeComponent();
        }
        public bool sifreDogru = false;

        private void button1_Click(object sender, EventArgs e)
        {
            string pass = textBox1.Text.Trim();
            if (pass == "1233")
            {
                sifreDogru = true;
                Close();
            }
            else
            {
                MessageBox.Show("Şifre hatalı.");
                textBox1.Clear();
                sifreDogru = false;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            sifreDogru = false;
            Close();
        }

        private void passwordForm_Load(object sender, EventArgs e)
        {
            textBox1.Select();
        }
    }
}
