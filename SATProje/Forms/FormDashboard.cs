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
    public partial class FormDashboard : Form
    {
        public FormDashboard()
        {
            InitializeComponent();

        }

        public MySqlConnection conn =
            new MySqlConnection("Server=165.22.205.60;username=test;Database=projects;password='DB!smyo55';");

        static MySqlDataReader dr;
        MySqlCommand cmd;
        MySqlDataAdapter da;
        DataSet ds;


        private void FormProduct_Load(object sender, EventArgs e)
        {
            griddoldur();
            label4.Text = "";


        }

        void griddoldur()
        {
            try
            {
                da = new MySqlDataAdapter("SELECT id, note, baslik, tarih FROM notes WHERE durum = '1';", conn);
                ds = new DataSet();
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
                conn.Close();

            }
            catch (MySqlException ex)
            {
                string hata = ex.Message;
                MessageBox.Show("Veri Tabanıyla Bağlantı Kurulurken Hata Oluştu. Hata Kodu 1", "Hata Penceresi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conn.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (textBox1.Text == "" || textBox2.Text == "")
            {
                MessageBox.Show("* Zorunlu Alanları Boş Geçemezsiniz.", "Boş Alan Hatası", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    conn.Open();
                    string sorgu = "INSERT INTO notes (note,baslik,tarih,durum, onem) values (@p1,@p2,@p3,@p4,@p5)";
                    cmd = new MySqlCommand(sorgu, conn);
                    cmd.Parameters.AddWithValue("@p1", textBox2.Text);
                    cmd.Parameters.AddWithValue("@p2", textBox1.Text);
                    cmd.Parameters.AddWithValue("@p3", dateTimePicker1.Value.ToString("yyyy-MM-dd"));
                    cmd.Parameters.AddWithValue("@p4", "1");
                    cmd.Parameters.AddWithValue("@p5", label4.Text);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Not kaydedildi", "Bilgilendirme Penceresi", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                }
                catch (MySqlException ex)
                {
                    string hata = ex.Message;
                    MessageBox.Show("Veri Tabanıyla Bağlantı Kurulurken Hata Oluştu. Hata Kodu 1", "Hata Penceresi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    conn.Close();

                    griddoldur();

                }
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            string onem;
            if (checkBox1.Checked == true)
            {
                onem = "1";
                label4.Text = onem;
            }
            else
            {
                onem = "0";
                label4.Text = onem;
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (textBox3.Text != "")
                {
                    (dataGridView1.DataSource as DataTable).DefaultView.RowFilter =
                        string.Format("note LIKE '{0}%' OR baslik LIKE '{0}%'", textBox3.Text);
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

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            label3.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBox1.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            dateTimePicker1.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("Update notes set durum=0 where id=@p1", conn);
                cmd.Parameters.AddWithValue("@p1", label4.Text);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Not Silindi.", "Bilgilendirme Penceresi", MessageBoxButtons.OK, MessageBoxIcon.Information);

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

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            conn.Open();
            da = new MySqlDataAdapter("SELECT * FROM notes WHERE durum = '0';", conn);
            ds = new DataSet();
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            conn.Close();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            conn.Open();
            da = new MySqlDataAdapter("SELECT * FROM notes;", conn);
            ds = new DataSet();
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            conn.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            griddoldur();

        }
    }
}
