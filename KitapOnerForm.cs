using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace AcarAkademiRehberlik
{
    public partial class KitapOnerForm : Form
    {
       
       
        private Dbo_acarEntities ent = new Dbo_acarEntities();
        private int selectedStudentId;
        public KitapOnerForm(int studentId)
        {
            InitializeComponent();
            this.selectedStudentId = studentId;
            TanimliKaynaklariGetir();
            

        }
       
        private void KitapOnerForm_Load(object sender, EventArgs e)
        {
            StyleListBox(lbxSecilenKaynaklar);
            StyleCheckedListBox(clbTanimliKaynaklar);
            StyleButton(btnKaynakAra);
            StyleButton(btnKaynakOner);
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
                    comboBox.FlatStyle = FlatStyle.Standard;
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
        public static void StyleCheckedListBox(CheckedListBox checkedListBox)
        {
            checkedListBox.BorderStyle = BorderStyle.None;
            checkedListBox.BackColor = Color.FromArgb(240, 240, 240);
            checkedListBox.ForeColor = Color.FromArgb(40, 40, 40);
            checkedListBox.Font = new Font("Segoe UI", 10, FontStyle.Regular);
            checkedListBox.ItemHeight = 25;
            checkedListBox.DrawMode = DrawMode.OwnerDrawFixed;
            checkedListBox.DrawItem += new DrawItemEventHandler(CheckedListBox_DrawItem);
        }

        private static void CheckedListBox_DrawItem(object sender, DrawItemEventArgs e)
        {
            CheckedListBox checkedListBox = sender as CheckedListBox;
            if (e.Index < 0) return;

            bool isSelected = (e.State & DrawItemState.Selected) == DrawItemState.Selected;
            bool isChecked = checkedListBox.GetItemChecked(e.Index);

            Color backgroundColor = isSelected ? Color.FromArgb(234, 92, 47) : Color.FromArgb(240, 240, 240);
            Color textColor = isSelected ? Color.FromArgb(234, 92, 47) : Color.FromArgb(20, 25, 72);
            Color checkBoxColor = isChecked ? Color.FromArgb(20, 25, 72) : Color.FromArgb(240, 240, 240);

            e.Graphics.FillRectangle(new SolidBrush(backgroundColor), e.Bounds);

            Rectangle checkBoxRectangle = new Rectangle(e.Bounds.Location.X + 1, e.Bounds.Location.Y + 4, 16, 16);
            ControlPaint.DrawCheckBox(e.Graphics, checkBoxRectangle, isChecked ? ButtonState.Checked : ButtonState.Normal);

            Rectangle textRectangle = new Rectangle(e.Bounds.Location.X + 20, e.Bounds.Location.Y, e.Bounds.Width - 20, e.Bounds.Height);
            e.Graphics.DrawString(checkedListBox.Items[e.Index].ToString(), e.Font, new SolidBrush(textColor), textRectangle);

            e.DrawFocusRectangle();
        }
        public static void StyleButton(Button btn)
        {
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.BackColor = Color.FromArgb(24, 54, 80);
            btn.ForeColor = Color.White;
            btn.Font = new System.Drawing.Font("Segoe UI", 10, FontStyle.Bold);
            btn.FlatAppearance.MouseOverBackColor = Color.FromArgb(20, 25, 72);
            btn.FlatAppearance.MouseDownBackColor = Color.FromArgb(14, 49, 69);

        }
        public static void StyleListBox(ListBox listBox)
        {
            listBox.BorderStyle = BorderStyle.None;
            listBox.BackColor = Color.FromArgb(247, 247, 247);
            listBox.ForeColor = Color.FromArgb(40, 40, 40);
            listBox.Font = new Font("Segoe UI", 10, FontStyle.Regular);
            listBox.ItemHeight = 25;
            listBox.DrawMode = DrawMode.OwnerDrawFixed;
            listBox.DrawItem += new DrawItemEventHandler(ListBox_DrawItem);
        }

        private static void ListBox_DrawItem(object sender, DrawItemEventArgs e)
        {
            ListBox listBox = sender as ListBox;
            if (e.Index < 0) return;

            bool isSelected = (e.State & DrawItemState.Selected) == DrawItemState.Selected;

            Color backgroundColor = isSelected ? Color.FromArgb(57, 162, 228) : Color.FromArgb(240, 240, 240);
            Color textColor = isSelected ? Color.White : Color.FromArgb(40, 40, 40);

            e.Graphics.FillRectangle(new SolidBrush(backgroundColor), e.Bounds);
            e.Graphics.DrawString(listBox.Items[e.Index].ToString(), e.Font, new SolidBrush(textColor), e.Bounds);

            e.DrawFocusRectangle();
        }
        internal void TanimliKaynaklariGetir()
        {
            var kitaplar = ent.Book.ToList();

            // CheckedListBox kontrolüne veri kaynağını bağla
            clbTanimliKaynaklar.DataSource = kitaplar;
            clbTanimliKaynaklar.DisplayMember = "bookName"; // Kitap adını göster
            clbTanimliKaynaklar.ValueMember = "book_id"; // Kitap kimliğini değer olarak kullan
        }

        private void clbTanimliKaynaklar_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            var selectedBook = clbTanimliKaynaklar.Items[e.Index] as Book;

            if (selectedBook == null) return;

            // Eğer kitap işaretleniyorsa
            if (e.NewValue == CheckState.Checked)
            {
                lbxSecilenKaynaklar.Items.Add(selectedBook.bookName);
            }
            // Eğer kitap işaret kaldırılıyorsa
            else if (e.NewValue == CheckState.Unchecked)
            {
                lbxSecilenKaynaklar.Items.Remove(selectedBook.bookName);
            }
        }

        private void btnKaynakOner_Click(object sender, EventArgs e)
        {
            var selectedBooks = clbTanimliKaynaklar.CheckedItems.Cast<Book>().ToList();
            bool kitapVarMi = false;
            var existingBooks = new List<string>();

            foreach (var book in selectedBooks)
            {
                // Aynı kitabın aynı öğrenciye önerilip önerilmediğini kontrol et
                var existingRecommendation = ent.Meeting_Book_Recommendation
                                                .FirstOrDefault(r => r.student_id == selectedStudentId && r.book_id == book.book_id);
                if (existingRecommendation != null)
                {
                    kitapVarMi = true;
                    existingBooks.Add(book.bookName);
                }
            }

            if (kitapVarMi)
            {
                string booksList = string.Join(", ", existingBooks);
                MessageBox.Show($"Bu öğrenciye seçtiğiniz kaynağı/kaynakları daha önce önerdiniz. Öğrenciye zaten önerilmiş olan kitaplar: {booksList}.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                foreach (var book in selectedBooks)
                {
                    var recommendation = new Meeting_Book_Recommendation
                    {
                        student_id = selectedStudentId,
                        book_id = book.book_id
                    };

                    ent.Meeting_Book_Recommendation.Add(recommendation);
                }

                ent.SaveChanges();
                MessageBox.Show("Kitap önerisi başarıyla eklendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
        }

        private void btnKaynakAra_Click(object sender, EventArgs e)
        {
            var selectedExamArea = cbxKitapAlan.SelectedItem?.ToString();
            var selectedBookType = cbxKitapTuru.SelectedItem?.ToString();
            var selectedBookClass = cbxKitapDers.SelectedItem?.ToString();

            var filteredBooks = ent.Book.AsQueryable();

            if (!string.IsNullOrEmpty(selectedExamArea))
            {
                filteredBooks = filteredBooks.Where(b => b.examArea == selectedExamArea);
            }

            if (!string.IsNullOrEmpty(selectedBookType))
            {
                filteredBooks = filteredBooks.Where(b => b.bookType == selectedBookType);
            }

            if (!string.IsNullOrEmpty(selectedBookClass))
            {
                filteredBooks = filteredBooks.Where(b => b.bookClass == selectedBookClass);
            }

            var filteredBookList = filteredBooks.ToList();
            clbTanimliKaynaklar.DataSource = filteredBookList;
            clbTanimliKaynaklar.DisplayMember = "name";
            clbTanimliKaynaklar.ValueMember = "book_id";

            // Eğer hiç kitap bulunamadıysa, DataSource'u boş listeyle güncelle
            if (!filteredBookList.Any())
            {
                clbTanimliKaynaklar.DataSource = new List<Book>();
            }
        }

        private void lblTumKaynaklar_Click(object sender, EventArgs e)
        {
            TanimliKaynaklariGetir();
        }
    }
    }
    

