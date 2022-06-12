using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace SATProje
{
    public partial class Form1 : Form
    {

        public MySqlConnection conn = new MySqlConnection("Server=165.22.205.60;username=test;Database=projects;password='DB!smyo55';");
        static MySqlDataReader dr;
        MySqlCommand cmd;
        MySqlDataAdapter da;
        DataSet ds;


        int sayac = 0;

        private Button currentButton;
        private Random random;
        private int tempIndex;
        private Form activeForm;
        public Form1()
        {
            //ilk degerler atanıyor//
            InitializeComponent();
            random = new Random();

            //child form görünülürlüğü kapat
            btnCloseChildForm.Visible = false;
            //child form görünülürlüğü kapat

            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;

            //ilk degerler atanıyor//
        }

        //Özelleştirilmiş Windows Bar için.//
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd,int wMsg,int wParam,int lParam);
        //Özelleştirilmiş Windows Bar için.//
       

        private void ActivateButton(object btnSender)
        {
            //btnSender null değilse yani buton gönderildiyse if'e gir
            if (btnSender != null)
            {
            //btnSender null değilse yani buton gönderildiyse if'e gir
                if (currentButton != (Button)btnSender)
                {
                    //Bütün butonları varsayılan ilk haline döndürür//
                    DisableButton();
                    //Bütün butonları varsayılan ilk haline döndürür//

                    //SelectThemeColor() metodu listeden rastgele bir değer alır.
                    //Color color = SelectThemeColor();
                    //SelectThemeColor() metodu listeden rastgele bir değer alır.

                    //parametre olarak verilen butonu current buttona atar. ÖRN: currentButton = btnProduct
                    currentButton = (Button)btnSender;
                    //parametre olarak verilen butonu current buttona atar. ÖRN: currentButton = btnProduct

                    //parametre olarak verilen butona arkaplan rengi verir. (Bu renk yukarıda SelectThemeColor() metodundan alınmıştı)
                    //.BackColor = color;
                    //parametre olarak verilen butona arkaplan rengi verir. (Bu renk yukarıda SelectThemeColor() metodundan alınmıştı)

                    //parametre olarak verilen butona yazı rengi beyaz verir
                    currentButton.ForeColor = Color.White;
                    //parametre olarak verilen butona yazı rengi beyaz verir

                    //parametre olarak verilen butona font özellikleri verilir
                    currentButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
                    //parametre olarak verilen butona font özellikleri verilir

                    //panelTitleBar'a arkaplan rengi veriliyor
                    //panelTitleBar.BackColor = color;
                    //panelTitleBar'a arkaplan rengi veriliyor

                    //color ile verdiğimiz rengi double parametresi ile başka renkleri dönüştürür
                    //panelLogo.BackColor = ThemeColor.ChangeColorBrightness(color, -0.3);
                    //color ile verdiğimiz rengi double parametresi ile başka renkleri dönüştürür

                    //primaryColor'a color'daki rengi atar//
                    //ThemeColor.PrimaryColor = color;
                    //primaryColor'a color'daki rengi atar//

                    //SecondaryColor'a color renginden double parametresi ile üretilen rengi atar.
                    //ThemeColor.SecondaryColor = ThemeColor.ChangeColorBrightness(color, -0.3);
                    //SecondaryColor'a color renginden double parametresi ile üretilen rengi atar.

                    //Formun içindeki formu kapatmak için kullandığımız butonu gösterir(true)
                    btnCloseChildForm.Visible = true;
                    //Formun içindeki formu kapatmak için kullandığımız butonu gösterir(true)
                }
            }
        }
        private void DisableButton()
        {
            //Genel işlevi butonları varsayılan hale getirmek (ActivateButton metodunda bu method çağırıldıktan sonra ilgili butona (ActivateButton metodunda) renk font gibi atamalar yapılır.)

            //PanelMenu içindeki controlleri gezer//
            foreach (Control previousButton in panelMenu.Controls)
            {
            //PanelMenu içindeki controlleri gezer//

                //panelMenu içindeki butonları bulur//
                if (previousButton.GetType() == typeof(Button))//tipi buton ise if'e girer
                {
                //panelMenu içindeki butonları bulur//

                    //butonlara varsayılan değerlerini verir
                    previousButton.BackColor = Color.FromArgb(105, 105, 105);//Arkaplan rengi verir
                    previousButton.ForeColor = Color.Gainsboro;//Yazı rengi verir
                    //butonlara varsayılan değerlerini verir
                }
            }
        }

        private void OpenChildForm(Form childForm,object btnSender)
        {
            if (activeForm != null)
            {
                activeForm.Close();
            }
            //parametre olarak verilen butonu işler (renk font vesaire atamalarını yapar)
            ActivateButton(btnSender);
            //parametre olarak verilen butonu işler (renk font vesaire atamalarını yapar)


            activeForm = childForm;
            childForm.TopLevel = false;
            
            //childformun borderlarını kaldırır
            childForm.FormBorderStyle = FormBorderStyle.None;
            //childformun borderlarını kaldırır

            //child formu yayar (bulunduğu kontrolü sarar)
            childForm.Dock = DockStyle.Fill;
            //child formu yayar (bulunduğu kontrolü sarar)

            //bu formun panelDesktopPane controllerine childForm'u ekle
            this.panelDesktopPane.Controls.Add(childForm);
            //bu formun panelDesktopPane controllerine childForm'u ekle


            this.panelDesktopPane.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
            lblTitle.Text = childForm.Text;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            toplamUrun();
            toplamGubre();
            ToplamSatis();
            MusteriSayi();
            toplamIlac();
            bildirimler();
            biten();
            ToplamSatisFiyat();
            ToplamKar();

            timer1.Start();
            timer1.Enabled = true;
        }

        public void bildirimler()
        {
            conn.Open();
            MySqlCommand cmd = new MySqlCommand("SELECT COUNT(*) FROM notes WHERE durum = '1' AND onem='1'", conn);
            MySqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                label13.Text = dr[0].ToString();
            }
            conn.Close();

        }

        public void toplamUrun()
        {
            conn.Open();
            MySqlCommand cmd = new MySqlCommand("SELECT COUNT(*) FROM products WHERE urunDurum = '1'", conn);
            MySqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                label4.Text = dr[0].ToString();
            }
            conn.Close();
        }

        public void toplamGubre()
        {
            string toplamGubre = "";
            conn.Open();
            MySqlCommand cmd = new MySqlCommand("SELECT COUNT(*) FROM products WHERE urunTuru = 'Gübre' and urunDurum = '1'", conn);
            MySqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                label7.Text = dr[0].ToString() + " Adet";
            }
            conn.Close();

        }

        public void toplamIlac()
        {
            conn.Open();
            MySqlCommand cmd = new MySqlCommand("SELECT COUNT(*) FROM products WHERE urunTuru = 'İlaç' and urunDurum = '1'", conn);
            MySqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                label9.Text = dr[0].ToString() + " Adet";
            }
            conn.Close();

        }

        void ToplamSatis()
        {
            conn.Open();
            MySqlCommand cmd = new MySqlCommand("select COUNT(id) from sales where satisDurum =1", conn);
            MySqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                label12.Text = dr[0].ToString();
            }
            conn.Close();
            //fiyatları tabloya ekle
        }

        void ToplamSatisFiyat()
        {
            conn.Open();
            MySqlCommand cmd = new MySqlCommand("select sum(toplamUcret) from sales where satisDurum =1", conn);
            MySqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                label20.Text = dr[0].ToString();
            }
            conn.Close();
            //fiyatları tabloya ekle
        }

        void ToplamKar()
        {
            conn.Open();
            MySqlCommand cmd = new MySqlCommand("select sum(urunSatisFiyat - urunAlisFiyat) from products where urunDurum =1", conn);
            MySqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                //label27.Text = dr[0].ToString();
            }
            conn.Close();
            //fiyatları tabloya ekle
        }

        void MusteriSayi()
        {
            conn.Open();
            MySqlCommand cmd = new MySqlCommand("Select count(*) from customers where musteriDurum=1", conn);
            MySqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                label5.Text = dr[0].ToString();
            }
            conn.Close();
        }



        void biten()
        {
            conn.Open();
            MySqlCommand cmd4 = new MySqlCommand("select COUNT(urunAdet) from products where urunDurum=1 AND urunAdet=0", conn);
            MySqlDataReader dr = cmd4.ExecuteReader();
            while (dr.Read())
            {
                //StokAdet = int.Parse(dr3[0].ToString());
                label23.Text = dr[0].ToString();
            }
            conn.Close ();
        }

        private void btnProduct_Click(object sender, EventArgs e)
        {
            //formun içinde'ki child form açıksa kapat
            if (activeForm != null)
            {
                activeForm.Close();
            }
            //formun içinde'ki child form açıksa kapat

            //
            Reset();
        }

        private void btnOrders_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.FormProducts(), sender);
        }

        private void btnCustomer_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.FormCustomer(), sender);
        }

        private void btnReporting_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.FormReporting(), sender);
        }



        private void btnsettings_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.FormSettings(), sender);
        }

        private void btnCloseChildForm_Click(object sender, EventArgs e)
        {
            //formun içinde'ki child form açıksa kapat
            if (activeForm!= null)
            {
                activeForm.Close();
            }
            //formun içinde'ki child form açıksa kapat

            //
            Reset();
        }

        private void Reset()
        {
            //Varsayılan değerlere döner (Default)

            //Butonları varsayılan haline getirir.
            DisableButton();
            //Butonları varsayılan haline getirir.

            lblTitle.Text = "ANALİZ";

            //panellerin renkleri atanır.
            panelTitleBar.BackColor = Color.FromArgb(0,150,136);
            panelLogo.BackColor = Color.FromArgb(39, 39, 58);
            //panellerin renkleri atanır.


            currentButton = null;

            //form içinde ki child form'un görünülürlüğü kapatılır.
            btnCloseChildForm.Visible = false;
            //form içinde ki child form'un görünülürlüğü kapatılır.

            //Varsayılan değerlere döner (Default)
        }

        private void panelTitleBar_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle,0x112,0xf012,0);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Uygulamayı Kapatmak İstiyor Musunuz ?", "Bilgilendirme Penceresi", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void btnMaximize_Click(object sender, EventArgs e)
        {
            //Pencere normal konumdayken if'e gir
            if (WindowState==FormWindowState.Normal)
            {
                //Pencereyi kapla (maximize);
                this.WindowState = FormWindowState.Maximized;
            }
            else
            {
                //Maximizedeyken tekrar tıklarsak normala döner
                this.WindowState=FormWindowState.Normal;
            }
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            //Pencereyi görev çubuğuna indirir
            this.WindowState = FormWindowState.Minimized;
        }

        private void panelDesktopPane_Paint(object sender, PaintEventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            sayac++;
            timer1.Interval = 500;
            if (label13.Text == "0")
            {
                label13.Text = "";
                label11.Text += " bulunamadı.";
            }
            if (sayac % 1 == 0)
            {
                label13.ForeColor = Color.LightSeaGreen;
            }
            if (sayac % 2 == 0)
            {
                label13.ForeColor = Color.Black;
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.badblli.me/");
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/badblli/SATProje/blob/master/README.md");
        }



        private void button2_Click(object sender, EventArgs e)
        {
            string bitenStok;
            label27.Text = "";
            bitenStok = label27.Text;
            conn.Open();
            MySqlCommand biten = new MySqlCommand("select urunAdi from products where urunDurum=1 AND urunAdet=0", conn);
            //MySqlCommand azalan = new MySqlCommand("select urunAdet from products where urunDurum=1 AND urunAdet<20", conn);
            MySqlDataReader dr = biten.ExecuteReader();
            while (dr.Read())
            {
                //StokAdet = int.Parse(dr3[0].ToString());
                bitenStok += dr[0].ToString() + "\n";
            }
            conn.Close();
            MessageBox.Show("Stokta kalmayan ürünler;" + "\n"+
                "-------------------------------------"+ "\n" + bitenStok.ToString());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.FormDashboard(), sender);
            try
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("Update notes set durum=0 where durum=1", conn);
                //cmd.Parameters.AddWithValue("@p1", label4.Text);
                cmd.ExecuteNonQuery();
                //MessageBox.Show("Not Silindi.", "Bilgilendirme Penceresi", MessageBoxButtons.OK, MessageBoxIcon.Information);

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

        private void button3_Click(object sender, EventArgs e)
        {
            Form2 fr = new Form2();
            fr.Show();
            this.Hide();
        }

        private void panelLogo_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.FormDashboard(), sender);
        }
    }
}
