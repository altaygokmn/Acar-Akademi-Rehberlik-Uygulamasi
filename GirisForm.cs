using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace AcarAkademiRehberlik
{
    public partial class GirisForm : Form
    {
       
        public GirisForm()
        {
            InitializeComponent();
            this.KeyPreview = true; // Formun KeyPreview özelliğini true yap
            this.KeyDown += new KeyEventHandler(GirisForm_KeyDown);
        }
        Dbo_acarEntities ent = new Dbo_acarEntities();
        private void GirisForm_Load(object sender, EventArgs e)
        {
            StyleButton(btnGiris);
            StyleButton(btnSekreterGiris);
        }

        private void btnGiris_Click(object sender, EventArgs e)
        {
            string kullaniciAdiText = tbxKullaniciAdi.Text.Trim();
            string sifre = tbxSifre.Text.Trim();

            // Alanların boş olup olmadığını kontrol et
            if (string.IsNullOrEmpty(kullaniciAdiText) || string.IsNullOrEmpty(sifre))
            {
                MessageBox.Show("Lütfen alanları doldurunuz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Kullanıcı adını integer'a dönüştür
            if (!int.TryParse(kullaniciAdiText, out int kullaniciAdi))
            {
                MessageBox.Show("Geçersiz kullanıcı adı.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Kullanıcı adı ile eşleşen öğretmeni bul
            var ogretmen = ent.Teacher.FirstOrDefault(t => t.teacher_id == kullaniciAdi);

            // Eğer öğretmen bulunamazsa
            if (ogretmen == null)
            {
                MessageBox.Show("Böyle bir öğretmen bulunmuyor.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Şifreyi kontrol et
            if (ogretmen.password != sifre)
            {
                MessageBox.Show("Şifreniz yanlış.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            
            RehberlikOgretmeniAnaForm anaForm = new RehberlikOgretmeniAnaForm(ogretmen.teacher_id);
            anaForm.Show();        
            this.Hide();
            ProfilForm profilForm = new ProfilForm(ogretmen.teacher_id);
            
        }

        private void GirisForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true; // Enter tuşuna basıldığında beep sesini engellemek için
                btnGiris.PerformClick();   // Enter tuşuna basıldığında btnGiris düğmesine tıklanmasını sağlar
            }
        }

        

        public static void StyleButton(Button btn)
        {
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.BackColor = Color.FromArgb(24, 54, 80);
            btn.ForeColor = Color.White;
            btn.Font = new System.Drawing.Font("Segoe UI", 10, FontStyle.Bold);
            btn.FlatAppearance.MouseOverBackColor = Color.FromArgb(13, 16, 44);
            btn.FlatAppearance.MouseDownBackColor = Color.FromArgb(30, 100, 140);

        }

     

        private void btnSekreterGiris_Click(object sender, EventArgs e)
        {
            SekreterGirisForm sekreterGirisForm = new SekreterGirisForm();
            sekreterGirisForm.Show();
            this.Hide();
        }
    }
    }


