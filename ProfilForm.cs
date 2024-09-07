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
    public partial class ProfilForm : Form
    {
        private Dbo_acarEntities ent = new Dbo_acarEntities();
        private int teacherId;
        public ProfilForm(int id)
        {
            InitializeComponent();
            this.KeyPreview = true;

            this.KeyDown += new KeyEventHandler(ProfilForm_KeyDown);
            this.teacherId = id;
        }

        private void btnGeriDon_Click(object sender, EventArgs e)
        {
            RehberlikOgretmeniAnaForm rehberlikOgretmeniAnaForm = new RehberlikOgretmeniAnaForm(teacherId);
            rehberlikOgretmeniAnaForm.Show();
            this.Hide();
        }

        private void ProfilForm_Load(object sender, EventArgs e)
        {
            StyleButton(btnGeriDon);
            StyleButton(btnSifreDegistir);
            StyleButton(btnMesajGuncelleFormAc);
            ApplyModernStyle(this);
            // Öğretmen bilgilerini al
            var ogretmen = ent.Teacher.FirstOrDefault(t => t.teacher_id == teacherId);

            if (ogretmen != null)
            {
                lblRehberOgretmenNumarasi.Text = ogretmen.teacher_id.ToString();
                lblAdSoyad.Text = ogretmen.name;

                // Öğrenci sayısını hesapla
                int ogrenciSayisi = ent.Student.Count(s => s.teacher_id == teacherId);
                lblOgrenciSayisi.Text = ogrenciSayisi.ToString();
            }
            else
            {
                MessageBox.Show("Öğretmen bilgileri alınamadı.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (ogretmen.role == 0)
            {
                btnMesajGuncelleFormAc.Visible = false;
            }
        }
        public static void StyleButton(Button btn)
        {
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.BackColor = Color.FromArgb(234, 92, 47);
            btn.ForeColor = Color.White;
            btn.Font = new System.Drawing.Font("Segoe UI", 10, FontStyle.Bold);
            btn.FlatAppearance.MouseOverBackColor = Color.FromArgb(189,78,23);
            btn.FlatAppearance.MouseDownBackColor = Color.FromArgb(30, 100, 140);

        }
        public void ApplyModernStyle(Control control)
        {
            foreach (Control c in control.Controls)
            {
                if (c is TextBox textBox)
                {
                    textBox.BorderStyle = BorderStyle.None;
                    textBox.BackColor = Color.White;
                    textBox.ForeColor = Color.Black;
                    textBox.Font = new Font("Segoe UI", 10);
                    textBox.Padding = new Padding(5);
                    textBox.Height = 30;
                    textBox.BorderStyle = BorderStyle.FixedSingle;

                    // Custom border radius for TextBox
                    textBox.Paint += (s, e) =>
                    {
                        e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                        using (Pen p = new Pen(Color.Gray, 1))
                        {
                            GraphicsPath path = new GraphicsPath();
                            path.AddArc(new Rectangle(0, 0, 10, 10), 180, 90);
                            path.AddArc(new Rectangle(textBox.Width - 11, 0, 10, 10), -90, 90);
                            path.AddArc(new Rectangle(textBox.Width - 11, textBox.Height - 11, 10, 10), 0, 90);
                            path.AddArc(new Rectangle(0, textBox.Height - 11, 10, 10), 90, 90);
                            path.CloseFigure();
                            textBox.Region = new Region(path);
                            e.Graphics.DrawPath(p, path);
                        }
                    };
                }
                else if (c is Label label)
                {
                    label.ForeColor = Color.White;
                    label.Font = new Font("Segoe UI", 12, FontStyle.Regular);
                }
                else if (c is ComboBox comboBox)
                {
                    comboBox.FlatStyle = FlatStyle.Flat;
                    comboBox.BackColor = Color.White;
                    comboBox.ForeColor = Color.Black;
                    comboBox.Font = new Font("Segoe UI", 10);
                    comboBox.DropDownStyle = ComboBoxStyle.DropDownList;

                    // Custom border radius for ComboBox
                    comboBox.Paint += (s, e) =>
                    {
                        e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                        using (Pen p = new Pen(Color.Gray, 1))
                        {
                            GraphicsPath path = new GraphicsPath();
                            path.AddArc(new Rectangle(0, 0, 10, 10), 180, 90);
                            path.AddArc(new Rectangle(comboBox.Width - 11, 0, 10, 10), -90, 90);
                            path.AddArc(new Rectangle(comboBox.Width - 11, comboBox.Height - 11, 10, 10), 0, 90);
                            path.AddArc(new Rectangle(0, comboBox.Height - 11, 10, 10), 90, 90);
                            path.CloseFigure();
                            comboBox.Region = new Region(path);
                            e.Graphics.DrawPath(p, path);
                        }
                    };
                }
                else if (c is Chart chart)
                {
                    chart.BackColor = Color.White;
                    chart.ChartAreas[0].BackColor = Color.White;
                    chart.ChartAreas[0].BorderWidth = 0;
                    chart.ChartAreas[0].BorderColor = Color.White;

                    foreach (var axis in chart.ChartAreas[0].Axes)
                    {
                        axis.LabelStyle.ForeColor = Color.Black;
                        axis.LineColor = Color.Gray;
                        axis.MajorGrid.LineColor = Color.LightGray;
                        axis.TitleFont = new Font("Segoe UI", 10);
                    }

                    foreach (var series in chart.Series)
                    {
                        series.Font = new Font("Segoe UI", 10);
                        series.LabelForeColor = Color.Black;
                        series.Color = Color.FromArgb(234, 92, 47); // Customize color
                    }
                }
                else
                {
                    ApplyModernStyle(c);
                }
            }
        }
        private void btnSifreDegistir_Click(object sender, EventArgs e)
        {
            string eskiSifre = tbxEskiSifre.Text.Trim();
            string yeniSifre = tbxYeniSifre.Text.Trim();
            string yeniSifreTekrar = tbxYeniSifre2.Text.Trim();

            if (string.IsNullOrEmpty(eskiSifre) || string.IsNullOrEmpty(yeniSifre) || string.IsNullOrEmpty(yeniSifreTekrar))
            {
                MessageBox.Show("Lütfen tüm alanları doldurunuz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var ogretmen = ent.Teacher.FirstOrDefault(t => t.teacher_id == teacherId);

            if (ogretmen != null && ogretmen.password == eskiSifre)
            {
                if (yeniSifre == yeniSifreTekrar)
                {
                    ogretmen.password = yeniSifre;
                    ent.SaveChanges();
                    MessageBox.Show("Şifre başarıyla değiştirildi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Yeni şifreler birbirleriyle eşleşmiyor.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Eski şifre yanlış. Lütfen tekrar deneyin.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ProfilForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSifreDegistir.PerformClick();
            }
        }

        private void btnMesajGuncelleFormAc_Click(object sender, EventArgs e)
        {
            AdminMesajiEkleForm adminMesajiEkleForm = new AdminMesajiEkleForm();
            adminMesajiEkleForm.Show();
        }
    }
}
