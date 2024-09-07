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
    public partial class SekreterForm : Form
    {
        private Dbo_acarakademirehberlikAppEntities ent = new Dbo_acarakademirehberlikAppEntities();
        public SekreterForm()
        {
            InitializeComponent();
            
        }

        private void SekreterForm_Load(object sender, EventArgs e)
        {
            
            ApplyModernStyle(this);
            InitializeDataGridView();
            StyleButton(btnKaydet);
            StyleDataGridView(dgwKayitlar);
            StyleButton(btnGeriDon);
            label1.Font = new Font("Segoe UI", 8, FontStyle.Regular);


        }









        private void InitializeDataGridView()
        {
            // DataGridView sütunlarını ekleyin
            dgwKayitlar.Columns.Add("StudentNumberColumn", "Öğrenci Numarası");
            dgwKayitlar.Columns.Add("StudentNameColumn", "Öğrenci Adı");
            dgwKayitlar.Columns.Add("DateColumn", "Tarih");
            //dgwKayitlar.Columns.Add("StatusColumn", "Durum");
            dgwKayitlar.Columns.Add("DetailsColumn", "Gelmeme Sebebi");

            // DataGridView'e boş bir satır ekleyin
            dgwKayitlar.Rows.Add();

            // DataGridView'de CellValueChanged olayını tanımlayın
            dgwKayitlar.CellValueChanged += dgwKayitlar_CellValueChanged;
            dgwKayitlar.EditingControlShowing += dgwKayitlar_EditingControlShowing;
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
                    label.Font = new Font("Segoe UI", 13, FontStyle.Regular);
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
                        series.Font = new System.Drawing.Font("Segoe UI", 10);
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

        private void dgwKayitlar_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgwKayitlar.Columns["StudentNumberColumn"].Index)
            {
                // Öğrenci Numarası girildiğinde, öğrenci adını otomatik olarak doldurun
                string studentNumber = dgwKayitlar.Rows[e.RowIndex].Cells["StudentNumberColumn"].Value?.ToString();
                var student = ent.Student.FirstOrDefault(s => s.student_id.ToString() == studentNumber);
                if (student != null)
                {
                    dgwKayitlar.Rows[e.RowIndex].Cells["StudentNameColumn"].Value = student.name;
                }
            }

            // Yeni bir satır ekleyin
            if (e.RowIndex == dgwKayitlar.Rows.Count - 1 && dgwKayitlar.Rows[e.RowIndex].Cells["StudentNumberColumn"].Value != null)
            {
                dgwKayitlar.Rows.Add();
            }
        }

        private void dgwKayitlar_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (dgwKayitlar.CurrentCell.ColumnIndex == dgwKayitlar.Columns["StudentNumberColumn"].Index)
            {
                // Öğrenci Numarası hücresine girildiğinde, tarihi bugünün tarihi olarak ayarlayın
                e.Control.TextChanged -= Control_TextChanged;
                e.Control.TextChanged += Control_TextChanged;
            }
        }
        private void Control_TextChanged(object sender, EventArgs e)
        {
            TextBox txt = sender as TextBox;
            if (txt != null)
            {
                int rowIndex = dgwKayitlar.CurrentCell.RowIndex;
                dgwKayitlar.Rows[rowIndex].Cells["DateColumn"].Value = DateTime.Now.ToString("dd.MM.yyyy");
            }
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            bool hasError = false; // Hata durumu için bayrak

            foreach (DataGridViewRow row in dgwKayitlar.Rows)
            {
                if (row.Cells["StudentNumberColumn"].Value != null && row.Cells["StudentNameColumn"].Value != null && row.Cells["DateColumn"].Value != null)
                {
                    string studentNumber = row.Cells["StudentNumberColumn"].Value.ToString();
                    string studentName = row.Cells["StudentNameColumn"].Value.ToString();
                    DateTime date = DateTime.ParseExact(row.Cells["DateColumn"].Value.ToString(), "dd.MM.yyyy", null);
                    string status = "Yok";
                    string details = row.Cells["DetailsColumn"].Value?.ToString();

                    // Öğrencinin mevcut olup olmadığını kontrol et
                    if (int.TryParse(studentNumber, out int studentId))
                    {
                        var student = ent.Student.FirstOrDefault(s => s.student_id == studentId);
                        if (string.IsNullOrWhiteSpace(studentName))
                        {
                            // Öğrenci bulunamadı
                            MessageBox.Show($"Öğrenci numarası {studentNumber} olan öğrenci bulunamadı.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            hasError = true;
                            continue; // Bir sonraki satıra geç
                        }

                        // Öğrencinin belirli bir tarih için zaten bir kaydı olup olmadığını kontrol et
                        var existingAttendance = ent.Attendance.FirstOrDefault(a => a.student_id == studentId && a.attendance_date == date);
                        if (existingAttendance != null)
                        {
                            // Zaten yoklama alınmış
                            MessageBox.Show($"Öğrenci numarası {studentNumber} olan öğrenci için {date:dd.MM.yyyy} tarihinde zaten yoklama alınmış.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            hasError = true;
                            continue; // Bir sonraki satıra geç
                        }

                        var attendance = new Attendance
                        {
                            student_id = studentId,
                            attendance_date = date,
                            attendance_status = status,
                            attendance_details = details
                        };

                        ent.Attendance.Add(attendance);
                    }
                    else
                    {
                        // Öğrenci numarası geçerli bir tamsayı değil
                        MessageBox.Show($"Geçersiz öğrenci numarası: {studentNumber}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        hasError = true;
                        continue; // Bir sonraki satıra geç
                    }
                }
            }

            // Eğer herhangi bir hata oluşmamışsa, değişiklikleri veritabanına kaydet
            if (!hasError)
            {
                ent.SaveChanges();
                MessageBox.Show("Geçerli kayıtlar başarıyla eklendi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Bazı kayıtlar eklenmedi. Hataları kontrol edin.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            // DataGridView'i temizleyin ve yeni bir satır ekleyin
            dgwKayitlar.Rows.Clear();
            dgwKayitlar.Rows.Add();
        }

        private void btnGeriDon_Click(object sender, EventArgs e)
        {
            SekreterAnaForm sekreterAnaForm = new SekreterAnaForm();
            sekreterAnaForm.Show();
            this.Hide();
        }
    }
}

