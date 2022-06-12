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
    public partial class FormProducts : Form
    {
        public FormProducts()
        {
            InitializeComponent();
        }

        public MySqlConnection conn = new MySqlConnection("Server=165.22.205.60;username=test;Database=projects;password='DB!smyo55';");
        static MySqlDataReader dr;
        MySqlCommand cmd;
        MySqlDataAdapter da;
        DataSet ds;
        object secilenUrunTuru;

        private void FormOrders_Load(object sender, EventArgs e)
        {
            griddoldur();
            vericek();
            label11.Text = "";
        }

       

        void griddoldur()
        {
            try
            {

                da = new MySqlDataAdapter("SELECT id,urunAdi, ureticiFirma, urunTuru, urunAlisFiyat, urunSatisFiyat, urunAdet, urunAlimTarih, urunResim, urunAciklama FROM products WHERE urunDurum = '1';", conn);
                ds = new DataSet();
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;

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
            conn.Open();
            string sorgu = "INSERT INTO products (urunAdi, ureticiFirma,urunTuru,urunAlisFiyat,urunSatisFiyat,urunAdet,urunAlimTarih,urunResim,urunDurum,urunAciklama) values (@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9,@p10)";
            cmd = new MySqlCommand(sorgu, conn);
            cmd.Parameters.AddWithValue("@p1", TxtUrunAdi.Text);
            cmd.Parameters.AddWithValue("@p2", TxtUreticiFirma.Text);
            cmd.Parameters.AddWithValue("@p3", comboBox1.Text);
            cmd.Parameters.AddWithValue("@p4", TxtUrunAlisFiyat.Text);
            cmd.Parameters.AddWithValue("@p5", TxtUrunSatisFiyat.Text);
            cmd.Parameters.AddWithValue("@p6", numericUpDown1.Text);
            cmd.Parameters.AddWithValue("@p7", DtpAlimTarihi.Value.ToString("yyyy-MM-dd"));
            cmd.Parameters.AddWithValue("@p8", TxtUrunResim.Text);
            cmd.Parameters.AddWithValue("@p9", "1");
            cmd.Parameters.AddWithValue("@p10", TxtUrunAciklama.Text);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Ürün Kaydı Yapıldı", "Bilgilendirme Penceresi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            griddoldur();

        }

        private void btnUrunResim_Click(object sender, EventArgs e)
        {
            OpenFileDialog dosya = new OpenFileDialog();
            dosya.Filter = "Resim Dosyası |*.jpg;*.nef;*.png |  Tüm Dosyalar |*.*";
            dosya.ShowDialog();
            string dosyayolu = dosya.FileName;
            TxtUrunResim.Text = dosyayolu;
            pictureBox1.ImageLocation = dosyayolu;
        }


        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("Update products set urunAdi=@p1, ureticiFirma=@p2, urunTuru=@p3,urunAlisFiyat=@p4,urunSatisFiyat=@p5,urunAdet=@p6,urunAlimTarih=@p7,urunResim=@p8,urunDurum=@p9,urunAciklama=@p10 where id=@p11 and urunDurum='1'", conn);
                cmd.Parameters.AddWithValue("@p1", TxtUrunAdi.Text);
                cmd.Parameters.AddWithValue("@p2", TxtUreticiFirma.Text);
                cmd.Parameters.AddWithValue("@p3", comboBox1.Text);
                cmd.Parameters.AddWithValue("@p4", TxtUrunAlisFiyat.Text);
                cmd.Parameters.AddWithValue("@p5", TxtUrunSatisFiyat.Text);
                cmd.Parameters.AddWithValue("@p6", numericUpDown1.Text);
                cmd.Parameters.AddWithValue("@p7", DtpAlimTarihi.Value.ToString("yyyy-MM-dd"));
                cmd.Parameters.AddWithValue("@p8", TxtUrunResim.Text);
                cmd.Parameters.AddWithValue("@p9", "1");
                cmd.Parameters.AddWithValue("@p10", TxtUrunAciklama.Text);
                cmd.Parameters.AddWithValue("@p11", label11.Text);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Ürün Güncelleme İşlemi Başarıyla Gerçekleşti.", "Bilgilendirme Penceresi", MessageBoxButtons.OK, MessageBoxIcon.Information);


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

     

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("Update products set urunDurum=0 where id=@p1", conn);
                cmd.Parameters.AddWithValue("@p1", label11.Text);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Ürün Bilgileri Kaldırıldı", "Bilgilendirme Penceresi", MessageBoxButtons.OK, MessageBoxIcon.Information);

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
            TxtUrunAdi.Text = "";
            TxtUreticiFirma.Text = "";
            TxtUrunAlisFiyat.Text = "";
            TxtUrunSatisFiyat.Text = "";
            TxtUrunResim.Text = "";
            comboBox1.Text = "Seçiniz";
            numericUpDown1.ResetText();
            DtpAlimTarihi.Text = "";
            griddoldur();

        }

        private void vericek()
        {
            conn.Open();
            cmd = new MySqlCommand("SELECT distinct urunTuru FROM products", conn);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                comboBox1.Items.Add(dr["urunTuru"]);
            }
            conn.Close();
        }

        private void TxtUrunAlisFiyat_KeyPress(object sender, KeyPressEventArgs e)
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
                MessageBox.Show("Fiyat değerlendirilmesi için sadece sayı giriniz!");
                e.Handled = true;
            }
        }

        private void TxtUrunSatisFiyat_KeyPress(object sender, KeyPressEventArgs e)
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
                MessageBox.Show("Fiyat değerlendirilmesi için sadece sayı giriniz!");
                e.Handled = true;
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            conn.Open();
            da = new MySqlDataAdapter("SELECT * FROM products WHERE urunDurum = '1' and urunTuru = 'İlaç';", conn);
            ds = new DataSet();
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            conn.Close();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            conn.Open();
            da = new MySqlDataAdapter("SELECT * FROM products WHERE urunDurum = '1' and urunTuru = 'Gübre';", conn);
            ds = new DataSet();
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            conn.Close();
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            conn.Open();
            da = new MySqlDataAdapter("SELECT * FROM products WHERE urunDurum = '0';", conn);
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

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            conn.Open();
            da = new MySqlDataAdapter("SELECT DISTINCT ureticiFirma FROM products WHERE urunDurum = '1';", conn);
            ds = new DataSet();
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            conn.Close();
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            label11.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            TxtUrunAdi.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            TxtUreticiFirma.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();

            comboBox1.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();

            TxtUrunAlisFiyat.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();

            TxtUrunSatisFiyat.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            numericUpDown1.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();

            DtpAlimTarihi.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();

            TxtUrunResim.Text = dataGridView1.CurrentRow.Cells[8].Value.ToString();
            pictureBox1.ImageLocation = dataGridView1.CurrentRow.Cells[8].Value.ToString();
            TxtUrunAciklama.Text = dataGridView1.CurrentRow.Cells[9].Value.ToString();

            int alis, satis, kar, adet;
            alis = Convert.ToInt32(TxtUrunAlisFiyat.Text);
            satis = Convert.ToInt32(TxtUrunSatisFiyat.Text);
            adet = Convert.ToInt32(numericUpDown1.Text);
            kar = Convert.ToInt32((satis * adet) - (alis * adet));
            label28.Text = kar.ToString();
            if (kar > 0)
            {
                label28.ForeColor = Color.Green;
            }
            if (kar < 0)
            {
                label28.ForeColor = Color.Red;
            }
            if (kar == 0)
            {
                label28.ForeColor = Color.Orange;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text != "")
                {
                    conn.Open();
                    da = new MySqlDataAdapter("SELECT * FROM products WHERE urunAdi like '%" + textBox1.Text + "%'", conn);
                    ds = new DataSet();
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dataGridView1.DataSource = dt;
                    conn.Close();
                }
            }
            catch (MySqlException ex)
            {
                string hata = ex.Message;
                MessageBox.Show("Bulunamadı. Hata Kodu 1", "Hata Penceresi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conn.Close();

                griddoldur();
                textBox1.Text = "";

            }

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text != "")
                {
                    (dataGridView1.DataSource as DataTable).DefaultView.RowFilter =
                    string.Format("urunAdi LIKE '{0}%'", textBox1.Text);
                }
                else{
                    griddoldur();
                }
            }
            catch (MySqlException ex)
            {
                string hata = ex.Message;
                MessageBox.Show("Bir hata ile karşılaşıldı.", "Hata Penceresi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
