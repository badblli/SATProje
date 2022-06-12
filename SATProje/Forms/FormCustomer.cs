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


namespace SATProje.Forms
{
    public partial class FormCustomer : Form
    {
        public FormCustomer()
        {
            InitializeComponent();
        }

        public MySqlConnection conn = new MySqlConnection("Server=165.22.205.60;username=test;Database=projects;password='DB!smyo55';");
        static MySqlDataReader dr;
        MySqlCommand cmd;
        MySqlDataAdapter da;
        DataSet ds;


        private void FormCustomer_Load(object sender, EventArgs e)
        {
            griddoldur();
            label5.Text = "";
        }


        void griddoldur()
        {
            try
            {
                da = new MySqlDataAdapter("SELECT * FROM customers WHERE musteriDurum = '1';", conn);
                ds = new DataSet();
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
                conn.Close();

            }
            catch (MySqlException ex)
            {
                string hata = ex.Message;
                MessageBox.Show("Veri Tabanıyla Bağlantı Kurulurken Hata Oluştu. Hata Kodu 1", "Hata Penceresi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conn.Close();
            }
        }



        private void button4_Click(object sender, EventArgs e)
        {
            if(TxtAdi.Text == "" || TxtSoyadi.Text == "" || maskedTextBox1.Text == "" || TxtEmail.Text == "" || TxtAdres.Text == "")
            {
                MessageBox.Show("* Zorunlu Alanları Boş Geçemezsiniz.", "Boş Alan Hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    conn.Open();
                    string sorgu = "INSERT INTO customers (musteriAd,musteriSoyad,musteriTelefon, musteriEmail,musteriAdres, musteriKayitTarih, musteriDurum) values (@p1,@p2,@p3,@p4,@p5, @p6, @p7)";
                    cmd = new MySqlCommand(sorgu, conn);
                    cmd.Parameters.AddWithValue("@p1", TxtAdi.Text);
                    cmd.Parameters.AddWithValue("@p2", TxtSoyadi.Text);
                    cmd.Parameters.AddWithValue("@p3", maskedTextBox1.Text);
                    cmd.Parameters.AddWithValue("@p4", TxtEmail.Text);
                    cmd.Parameters.AddWithValue("@p5", TxtAdres.Text);
                    cmd.Parameters.AddWithValue("@p6", DtpKayitTarih.Value.ToString("yyyy-MM-dd"));
                    cmd.Parameters.AddWithValue("@p7", "1");
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Müşteri Kaydı Yapıldı", "Bilgilendirme Penceresi", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                catch (MySqlException ex)
                {
                    string hata = ex.Message;
                    MessageBox.Show("Veri Tabanıyla Bağlantı Kurulurken Hata Oluştu. Hata Kodu 1", "Hata Penceresi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    conn.Close();

                    griddoldur();

                }
            }
        }


        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("Update customers set musteriDurum=0 where id=@p1", conn);
                cmd.Parameters.AddWithValue("@p1", label5.Text);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Müşteri Bilgileri Kaldırıldı", "Bilgilendirme Penceresi", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (MySqlException ex)
            {
                string hata = ex.Message;
                MessageBox.Show("Veri Tabanıyla Bağlantı Kurulurken Hata Oluştu. Hata Kodu 1", "Hata Penceresi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conn.Close();
                griddoldur();

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("Update customers set musteriAd=@p1, musteriSoyad=@p2, 	musteriTelefon=@p3,musteriEmail=@p4,musteriAdres=@p5,musteriKayitTarih=@p6 where id=@p7 and musteriDurum='1'", conn);
                cmd.Parameters.AddWithValue("@p1", TxtAdi.Text);
                cmd.Parameters.AddWithValue("@p2", TxtSoyadi.Text);
                cmd.Parameters.AddWithValue("@p3", maskedTextBox1.Text);
                cmd.Parameters.AddWithValue("@p4", TxtEmail.Text);
                cmd.Parameters.AddWithValue("@p5", TxtAdres.Text);
                cmd.Parameters.AddWithValue("@p6", DtpKayitTarih.Value.ToString("yyyy-MM-dd")); 
                cmd.Parameters.AddWithValue("@p7", label5.Text);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Müşteri Güncelleme İşlemi Başarıyla Gerçekleşti.", "Bilgilendirme Penceresi", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (MySqlException ex)
            {
                string hata = ex.Message;
                MessageBox.Show("Veri Tabanıyla Bağlantı Kurulurken Hata Oluştu. Hata Kodu 1", "Hata Penceresi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conn.Close();

                griddoldur();

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            TxtAdi.Text = "";
            TxtAdres.Text = "";
            TxtEmail.Text = "";
            TxtSoyadi.Text = "";
            DtpKayitTarih.Text = "";
            maskedTextBox1.Text = "";
            radioButton3.Checked = false;
            radioButton4.Checked = false;
            griddoldur();
        }

        private void maskedTextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar >= 47 && (int)e.KeyChar <= 58)
            {
                e.Handled = false;
            }
            else if ((int)e.KeyChar == 8)
            {
                e.Handled = false;
            }
            else
            {
                MessageBox.Show("Telefon numaranızı giriniz! Örneğin; 555 444 3322");
                e.Handled = true;
            }
        }


        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            conn.Open();
            da = new MySqlDataAdapter("SELECT * FROM customers WHERE musteriDurum = '0';", conn);
            ds = new DataSet();
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            conn.Close();
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            griddoldur();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            label5.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            TxtAdi.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            TxtSoyadi.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            maskedTextBox1.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            TxtEmail.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            TxtAdres.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            DtpKayitTarih.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
        }


        private void label31_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text != "")
                {
                    (dataGridView1.DataSource as DataTable).DefaultView.RowFilter =
                    string.Format("musteriAd LIKE '{0}%' OR musteriSoyad LIKE '{0}%'", textBox1.Text);
                }
                else
                {
                    griddoldur();
                }
            }
            catch (MySqlException ex)
            {
                string hata = ex.Message;
                MessageBox.Show("Bir hata ile karşılaşıldı.", "Hata Penceresi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }





        /*
          private void textBox5_TextChanged(object sender, EventArgs e)  // ARAMA YAPMA
        {
            con = new MySqlConnection("Provider=Microsoft.ACE.Oledb.12.0;Data Source=okul.accdb");
            da = new MySqlDataAdapter("SElect *from ogrenci where ogr_ad like '"+textBox5.Text+"%'", con);
            ds = new DataSet();
            con.Open();
            da.Fill(ds, "ogrenci");
            dataGridView1.DataSource = ds.Tables["ogrenci"];
            con.Close();
        }*/
    }
}
