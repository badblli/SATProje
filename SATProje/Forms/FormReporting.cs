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
    public partial class FormReporting : Form
    {
        public FormReporting()
        {
            InitializeComponent();
        }

        public MySqlConnection conn = new MySqlConnection("Server=165.22.205.60;username=test;Database=projects;password='DB!smyo55';");
        static MySqlDataReader dr;
        MySqlCommand cmd;
        MySqlDataAdapter da;
        DataSet ds;

        void griddoldur()
        {
            conn.Open();
            da = new MySqlDataAdapter("SELECT id, urunAdi, ureticiFirma, urunTuru, urunSatisFiyat, urunAdet FROM products WHERE urunDurum = '1';", conn);
            ds = new DataSet();
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;

            da = new MySqlDataAdapter("SELECT	id, urunAdi, satilanUrunAdet, urunTuru, musteriAdSoyad, satisTarihi, toplamUcret FROM sales WHERE satisDurum = '1';", conn);
            ds = new DataSet();
            DataTable dt2 = new DataTable();
            da.Fill(dt2);
            dataGridView2.DataSource = dt2;

            conn.Close();
        }

        private void FormReporting_Load(object sender, EventArgs e)
        {
            vericek();
            vericek2();
            griddoldur();
            label8.Text = "";

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

        private void vericek2()
        {

            conn.Open();
            cmd = new MySqlCommand("SELECT musteriAd, musteriSoyad FROM customers", conn);
            dr = cmd.ExecuteReader();
           
            while (dr.Read())
            {
                string musteri = dr["musteriAd"].ToString();
                string musteris = dr["musteriSoyad"].ToString();
                string mbilg = musteri + " " + musteris;
                comboBox3.Items.Add(mbilg);
            }
            conn.Close();
        }



        private void comboBox3_StyleChanged(object sender, EventArgs e)
        {

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            double toplam = 0;
            double fiyat = Convert.ToDouble(TxtSatisFiyat.Text);
            double numeric = Convert.ToDouble(numericUpDown1.Value);
            toplam = fiyat * numeric;
            txtToplamUcret.Text = toplam.ToString();
        }




        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            string aranan = txtUrunAdi.Text.Trim().ToUpper();
            for (int i = 0; i <= dataGridView1.Rows.Count - 1; i++)
            {
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    foreach (DataGridViewCell cell in dataGridView1.Rows[i].Cells)
                    {
                        if (cell.Value != null)
                        {
                            if (cell.Value.ToString().ToUpper() == aranan)
                            {
                                cell.Style.BackColor = Color.DarkTurquoise;
                                break;
                            }
                        }
                    }
                }
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            label8.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            txtUrunAdi.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            TxtFirma.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            comboBox1.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            //numericUpDown1.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            TxtSatisFiyat.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            label9.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int adet = 0;
            adet = Convert.ToInt32(numericUpDown1.Text);
            int StokAdet;
            StokAdet = Convert.ToInt32(label9.Text);
            int kalanStok;
            kalanStok = StokAdet - adet;

            conn.Open();
            MySqlCommand cmd3 = new MySqlCommand("select urunAdet from products where id=@p1", conn);
            cmd3.Parameters.AddWithValue("@p1", label8.Text);
            MySqlDataReader dr3 = cmd3.ExecuteReader();
            while (dr3.Read())
            {
                StokAdet = int.Parse(dr3[0].ToString());
                label9.Text = StokAdet.ToString();
            }
            conn.Close();
            if (StokAdet >= adet)
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("insert into sales (urunAdi,satilanUrunAdet,urunTuru,musteriAdSoyad,satisTarihi,toplamUcret,urunSatisFiyat, satisDurum) values (@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8)", conn);
                cmd.Parameters.AddWithValue("@p1", txtUrunAdi.Text);
                cmd.Parameters.AddWithValue("@p2", numericUpDown1.Text);
                cmd.Parameters.AddWithValue("@p3", comboBox1.Text);
                cmd.Parameters.AddWithValue("@p4", comboBox3.Text);
                cmd.Parameters.AddWithValue("@p5", dateTimePicker1.Value.ToString("yyyy-MM-dd"));
                cmd.Parameters.AddWithValue("@p6", txtToplamUcret.Text);
                cmd.Parameters.AddWithValue("@p7", TxtSatisFiyat.Text);
                cmd.Parameters.AddWithValue("@p8", "1");
                cmd.ExecuteNonQuery();

                MySqlCommand cmd2 = new MySqlCommand("Update products set urunAdet=@p1 where id=@p2", conn);
                cmd2.Parameters.AddWithValue("@p1", kalanStok);
                cmd2.Parameters.AddWithValue("@p2", label8.Text);
                cmd2.ExecuteNonQuery();
                conn.Close();


                MessageBox.Show("Satış İşlemi Başarılı", "Bilgilendirme Penceresi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                griddoldur();
            }
            else
            {
                MessageBox.Show("Yeterli Stok Yok. Stok Güncelleyin!!!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);


            }
            // textbox boş dolu kontrol et try catch ekle
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}

