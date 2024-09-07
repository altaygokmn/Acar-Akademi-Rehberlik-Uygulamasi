using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AcarAkademiRehberlik
{
    public partial class SekreterGirisForm : Form
    {
        private Dbo_acarakademirehberlikAppEntities ent = new Dbo_acarakademirehberlikAppEntities();
        public SekreterGirisForm()
        {
            InitializeComponent();
            this.KeyPreview = true; // Formun KeyPreview özelliğini true yap
            this.KeyDown += new KeyEventHandler(btnGiris_KeyDown);
        }

        private void SekreterGirisForm_Load(object sender, EventArgs e)
        {
            StyleButton(btnGeriDon);
            StyleButton(btnGiris);
            btnGiris.FlatAppearance.MouseOverBackColor = Color.FromArgb(4, 3, 36);
        }
        public static void StyleButton(Button btn)
        {
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.BackColor = Color.FromArgb(24, 54, 80);
            btn.ForeColor = Color.White;
            btn.Font = new System.Drawing.Font("Segoe UI", 10, FontStyle.Bold);
            btn.FlatAppearance.MouseOverBackColor = Color.FromArgb(234, 92, 47);
            btn.FlatAppearance.MouseDownBackColor = Color.FromArgb(30, 100, 140);

        }

        private void btnGeriDon_Click(object sender, EventArgs e)
        {
            GirisForm girisForm = new GirisForm();
            girisForm.Show();
            this.Hide();
        }

        private void btnGiris_Click(object sender, EventArgs e)
        {
            string secretaryId = tbxSekreterId.Text;
            string password = tbxSekreterSifre.Text;

            // Secretary tablosundaki secretary_id ve password alanlarını kontrol et
            var secretary = ent.Secretary.FirstOrDefault(s => s.secretary_id.ToString() == secretaryId);

            if (secretary == null)
            {
                // Secretary_id bulunamadı
                MessageBox.Show($"Kullanıcı adı yanlış. {secretaryId} bulunamadı.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (secretary.password != password)
            {
                // Şifre uyuşmuyor
                MessageBox.Show("Yanlış şifre.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                // Giriş başarılı
                SekreterAnaForm anaForm = new SekreterAnaForm();
                anaForm.Show();
                this.Hide(); // Bu formu gizle
            }
        }

        private void btnGiris_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                btnGiris_Click(sender, e); // Enter tuşuna basıldığında btnGiris_Click metodunu çağır

            }
        }
    }
}
