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
    public partial class KaynakForm : Form
    {
        private Dbo_acarEntities ent = new Dbo_acarEntities();
        private int teacherId;
        public KaynakForm(int id)
        {
            InitializeComponent();
            this.teacherId = id;
        }

        private void btnGeriDon_Click(object sender, EventArgs e)
        {
            RehberlikOgretmeniAnaForm rehberlikOgretmeniAnaForm = new RehberlikOgretmeniAnaForm(teacherId);
            rehberlikOgretmeniAnaForm.Show();
            this.Hide();
        }
        private void LoadBooks()
        {
            using (var context = new Dbo_acarEntities())
            {
                var books = context.Book.Select(b => new
                {
                    b.book_id,
                    b.bookName,
                    b.examArea,
                    b.bookType,
                    b.author,
                    b.bookClass
                }).ToList();

                dgwKaynaklar.DataSource = books;
                dgwKaynaklar.Columns["book_id"].Visible = false;
            }
        }
        private void KaynakForm_Load(object sender, EventArgs e)
        {
            LoadBooks();
            StyleDataGridView(dgwKaynaklar);
            StyleButton(btnGeriDon);
            StyleButton(btnKaynakEkle);
            StyleButton(btnKaynakSil);
            ApplyModernStyle(this);
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
                    label.ForeColor = Color.Black;
                    label.Font = new Font("Segoe UI", 10, FontStyle.Regular);
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
        public static void StyleDataGridView(DataGridView dgv)
        {
            // Genel ayarlar
            dgv.BorderStyle = BorderStyle.None;
            dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(238, 239, 249);
            dgv.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgv.DefaultCellStyle.SelectionBackColor = Color.FromArgb(234, 92, 47);
            dgv.DefaultCellStyle.SelectionForeColor = Color.White;
            dgv.BackgroundColor = Color.White;

            dgv.EnableHeadersVisualStyles = false;
            dgv.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(20, 25, 72);
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;

            // Kolon genişliği ve hizalama
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgv.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dgv.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

            // Satır ayarları
            dgv.RowTemplate.Height = 40;
            dgv.RowHeadersVisible = false;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            // Grid çizgilerini kaldırma
            dgv.CellBorderStyle = DataGridViewCellBorderStyle.None;
            dgv.GridColor = Color.White;

            // Alternatif satır rengi
            dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(238, 239, 249);

            // Satır yüksekliği ve yazı tipi
            dgv.RowTemplate.Height = 40;
            dgv.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 10);

            // Kenarlık ayarları
            dgv.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgv.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 11, FontStyle.Bold);

            // Başlıkların hizalanması
            dgv.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }
        private void btnKaynakEkle_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbxKaynakAdi.Text) || string.IsNullOrWhiteSpace(tbxYayincilik.Text) || cbxAlan.SelectedItem == null || cbxKaynakTuru.SelectedItem == null || cbxDers.SelectedItem == null)
            {
                MessageBox.Show("Lütfen tüm alanları doldurun.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (var context = new Dbo_acarEntities())
            {
                var newBook = new Book
                {
                    bookName = tbxKaynakAdi.Text,
                    examArea = cbxAlan.SelectedItem.ToString(),
                    bookType = cbxKaynakTuru.SelectedItem.ToString(),
                    author = tbxYayincilik.Text,
                    bookClass = cbxDers.SelectedItem.ToString()
                };

                context.Book.Add(newBook);
                context.SaveChanges();
            }

            LoadBooks();
            MessageBox.Show("Kitap başarıyla eklendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnKaynakSil_Click(object sender, EventArgs e)
        {
            if (dgwKaynaklar.SelectedRows.Count > 0)
            {
                var selectedRow = dgwKaynaklar.SelectedRows[0];
                int bookId = Convert.ToInt32(selectedRow.Cells["book_id"].Value);

                using (var context = new Dbo_acarEntities())
                {
                    // First, delete related Meeting_Book_Recommendation records
                    var relatedRecommendations = context.Meeting_Book_Recommendation
                                                        .Where(mbr => mbr.book_id == bookId)
                                                        .ToList();
                    context.Meeting_Book_Recommendation.RemoveRange(relatedRecommendations);

                    // Then, delete the Book record
                    var bookToRemove = context.Book.Find(bookId);
                    if (bookToRemove != null)
                    {
                        context.Book.Remove(bookToRemove);
                    }

                    context.SaveChanges();
                }

                LoadBooks();
                MessageBox.Show("Kitap başarıyla silindi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Lütfen silinecek kitabı seçin.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
