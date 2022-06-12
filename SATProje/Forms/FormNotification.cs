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
using System.Net.Mail;
using System.Net;

namespace SATProje.Forms
{
    public partial class FormNotification : Form
    {
        public FormNotification()
        {
            InitializeComponent();
        }

        public MySqlConnection conn = new MySqlConnection("Server=165.22.205.60;username=test;Database=projects;password='DB!smyo55';");
        static MySqlDataReader dr;
        MySqlCommand cmd;
        MySqlDataAdapter da;
        DataSet ds;

        private void FormNotification_Load(object sender, EventArgs e)
        {
            griddoldur();
            label9.Text ="";
        }

        void griddoldur()
        {
            conn.Open();
            da = new MySqlDataAdapter("SELECT * FROM notifications WHERE durum = '1';", conn);
            ds = new DataSet();
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            conn.Close();
        }



        private void button1_Click(object sender, EventArgs e)
        {
            SmtpClient sc = new SmtpClient();
            sc.Port = 465;
            sc.EnableSsl = true;
            sc.Host = "smtp.titan.email";
            

            string kime = TxtAliciEmail.Text;
            string konu = TxtKonu.Text;
            string icerik = ("Değerli Müşterimiz " + TxtAlici.Text + ", \n göndermiş olduğunuz destek mesajına geri dönüş yapmaktayız. \n"
                + Environment.NewLine
                + Environment.NewLine
                + "\n"
                + "\n"
                + TxtYanit.Text + "\n");


            sc.Credentials = new NetworkCredential("info@badblli.codes", "yds3DpUisl");
            MailMessage mail = new MailMessage();
            mail.From = new MailAddress(TxtAliciEmail.Text);
            mail.To.Add(kime);
            mail.To.Add(TxtAliciEmail.Text);
            //mail.CC.Add("alici3@mail.com");
            //mail.CC.Add("alici4@mail.com");
            mail.Subject = konu;
            mail.IsBodyHtml = true;
            mail.Body = icerik;
           //ail.Attachments.Add(new Attachment(DosyaYolu));
            sc.Send(mail);


            conn.Open();
            MySqlCommand cmd = new MySqlCommand("Update notifications set Durum=0 where id=@p1", conn);
            cmd.Parameters.AddWithValue("@p1", label9.Text);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Destek Talebi yanıtlandı", "Bilgilendirme Penceresi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            conn.Close();
            griddoldur();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            conn.Open();
            da = new MySqlDataAdapter("SELECT * FROM notifications WHERE durum = '1';", conn);
            ds = new DataSet();
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            conn.Close();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            conn.Open();
            da = new MySqlDataAdapter("SELECT * FROM notifications WHERE durum = '0';", conn);
            ds = new DataSet();
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            conn.Close();
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            conn.Open();
            da = new MySqlDataAdapter("SELECT * FROM notifications;", conn);
            ds = new DataSet();
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            conn.Close();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            TxtAliciEmail.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            TxtAlici.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            txtGonderilen.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            label9.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
        }
    }
}
