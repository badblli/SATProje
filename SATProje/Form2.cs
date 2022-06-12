using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data;
using MySql.Data.MySqlClient;
//using MySql.Data;

namespace SATProje
{
    public partial class Form2 : Form
    {
        public MySqlConnection conn = new MySqlConnection("Server=165.22.205.60;username=test;Database=projects;password='DB!smyo55';");
        static MySqlDataReader dr;
        MySqlCommand cmd;
        MySqlDataAdapter da;
        public Form2()
        {
            InitializeComponent();
        }



        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (TxtSifre.PasswordChar.ToString() == "\0")
            {
                TxtSifre.PasswordChar = char.Parse("●");
                label4.Text = "  Göster";
            }
            else
            {
                TxtSifre.PasswordChar = char.Parse("\0");
                label4.Text = "  Gizle";
            }
        }

        private void pictureBox2_Click_1(object sender, EventArgs e)
        {
            if (TxtSifre.PasswordChar.ToString() == "\0")
            {
                TxtSifre.PasswordChar = char.Parse("●");
                label5.Text = "  Göster";
            }
            else
            {
                TxtSifre.PasswordChar = char.Parse("\0");
                label5.Text = "  Gizle";
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {
            if (TxtSifre.PasswordChar.ToString() == "\0")
            {
                TxtSifre.PasswordChar = char.Parse("●");
                label5.Text = "  Göster";
            }
            else
            {
                TxtSifre.PasswordChar = char.Parse("\0");
                label5.Text = "  Gizle";
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Uygulamayı Kapatmak İstiyor Musunuz ?", "Bilgilendirme Penceresi", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            //Pencereyi görev çubuğuna indirir
            this.WindowState = FormWindowState.Minimized;
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void BtnGiris_Click(object sender, EventArgs e)
        {
            try
            {
                string user = TxtKullaniciAdi.Text;
                string pass = TxtSifre.Text;
                if (TxtKullaniciAdi.Text.Trim() != "" && TxtSifre.Text.Trim() != "")
                {

                    conn.Open();
                    MySqlCommand cmd2 = new MySqlCommand("select * from admin where kullaniciAdi=@p1 and kullaniciSifre=@p2 ", conn);
                    cmd2.Parameters.AddWithValue("@p1", TxtKullaniciAdi.Text);
                    cmd2.Parameters.AddWithValue("@p2", TxtSifre.Text);
                    MySqlDataReader dr = cmd2.ExecuteReader();
                    if (dr.Read())
                    {
                        Form1 fr = new Form1();
                        fr.Show();
                        this.Hide();
                    }

                }

            }

            catch (Exception)
            {
                MessageBox.Show("Kullanıcı adı veya Parola Hatalı");
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.badblli.me/");
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/badblli/SATProje");
        }
    }
}
