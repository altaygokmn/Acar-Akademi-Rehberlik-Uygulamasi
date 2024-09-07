using ClosedXML.Excel;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.ComponentModel;

using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using LicenseContext = OfficeOpenXml.LicenseContext;


namespace AcarAkademiRehberlik
{
    public partial class OgrenciIslemleriForm : Form
    {
     //   private Dbo_acarEntities ent = new Dbo_acarEntities();
        private Dbo_acarRehberlikAkademiModel ent = new Dbo_acarRehberlikAkademiModel();
        private int teacherId;
        public OgrenciIslemleriForm(int id)
        {
            InitializeComponent();
            this.teacherId = id;
            LoadStudentData();
            ExcelPackage.LicenseContext = LicenseContext.Commercial;
        }

        private void btnGeriDon_Click(object sender, EventArgs e)
        {
            RehberlikOgretmeniAnaForm rehberlikOgretmeniAnaForm = new RehberlikOgretmeniAnaForm(teacherId);
            rehberlikOgretmeniAnaForm.Show();
            this.Hide();
        }

        private void OgrenciIslemleriForm_Load(object sender, EventArgs e)
        {
            StyleButton(btnGeriDon);
            StyleButton(btnOgrenciDuzenle);
            StyleButton(btnOgrenciEkle);
            StyleButton(btnOgrenciSil);
            StyleButton(btnDosyadanOgrenciEkle);
            StyleDataGridView(dgwOgrencilerim);
            ApplyModernStyle(this);
            LoadUniqueClassValues();
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
                //else if (c is ComboBox comboBox)
                //{
                //     comboBox.FlatStyle = FlatStyle.Flat;
                //    comboBox.BackColor = Color.White;
                //    comboBox.ForeColor = Color.Black;
                //    comboBox.Font = new Font("Segoe UI", 10);
                //    comboBox.DropDownStyle = ComboBoxStyle.DropDownList;
                //    comboBox.Enabled = true;

                //    // Custom border radius for ComboBox
                //    comboBox.Paint += (s, e) =>
                //    {
                //        e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                //        using (Pen p = new Pen(Color.Gray, 1))
                //        {
                //            GraphicsPath path = new GraphicsPath();
                //            path.AddArc(new Rectangle(0, 0, 10, 10), 180, 90);
                //            path.AddArc(new Rectangle(comboBox.Width - 11, 0, 10, 10), -90, 90);
                //            path.AddArc(new Rectangle(comboBox.Width - 11, comboBox.Height - 11, 10, 10), 0, 90);
                //            path.AddArc(new Rectangle(0, comboBox.Height - 11, 10, 10), 90, 90);
                //            path.CloseFigure();
                //            comboBox.Region = new Region(path);
                //            e.Graphics.DrawPath(p, path);
                //            comboBox.Enabled = true;
                //        }
                //    };
                //}
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
        private void LoadStudentData()
        {
            var students = ent.Student
                .Where(s => s.teacher_id == teacherId)
                .Select(s => new
                {
                    s.student_id,
                    s.homework_id,
                    s.name,
                    s.@class,
                    s.school,
                    s.phoneNumber,
                    s.yksScore,
                    s.tytScore,
                    s.aytScore,
                    s.msuScore,
                    s.purpose,
                    s.parent1Name,
                    s.parent1ParentalCloseness,
                    s.parent1PhoneNumber,
                    s.parent2Name,
                    s.parent2ParentalCloseness,
                    s.parent2PhoneNumber
                }).ToList();

            dgwOgrencilerim.DataSource = students;
        }
        private void LoadUniqueClassValues()
        {
            // Get distinct class values from Student table
            var uniqueClasses = ent.Student
                                   .Select(s => s.@class)
                                   .Distinct()
                                   .ToList();

            // Add each unique class value to cbxSinif
            foreach (var classValue in uniqueClasses)
            {
                cbxSinif.Items.Add(classValue);
            }
        }

        private void tbxOgrenciAra_TextChanged(object sender, EventArgs e)
        {
            int.TryParse(tbxOgrenciAra.Text, out int studentId);

            var students = ent.Student
                .Where(s => s.teacher_id == teacherId && (studentId == 0 || s.student_id == studentId))
                .Select(s => new
                {
                    s.student_id,
                    s.homework_id,
                    s.name,
                    s.@class,
                    s.school,
                    s.phoneNumber,
                    s.yksScore,
                    s.tytScore,
                    s.aytScore,
                    s.msuScore,
                    s.purpose,
                    s.parent1Name,
                    s.parent1ParentalCloseness,
                    s.parent1PhoneNumber,
                    s.parent2Name,
                    s.parent2ParentalCloseness,
                    s.parent2PhoneNumber
                }).ToList();

            dgwOgrencilerim.DataSource = students;
        }

        private void dgwOgrencilerim_SelectionChanged(object sender, EventArgs e)
        {
            if (dgwOgrencilerim.SelectedRows.Count > 0)
            {
                var selectedRow = dgwOgrencilerim.SelectedRows[0];

                tbxOgrenciNumarasi.Text = selectedRow.Cells["student_id"].Value == null ? string.Empty : selectedRow.Cells["student_id"].Value.ToString();
                tbxOdevNumarasi.Text = selectedRow.Cells["homework_id"].Value == null ? string.Empty : selectedRow.Cells["homework_id"].Value.ToString();
                tbxOgrenciAdSoyad.Text = selectedRow.Cells["name"].Value == null ? string.Empty : selectedRow.Cells["name"].Value.ToString();
                cbxSinif.Text = selectedRow.Cells["sinif"].Value == null ? string.Empty : selectedRow.Cells["sinif"].Value.ToString();
                tbxOgrenciOkul.Text = selectedRow.Cells["school"].Value == null ? string.Empty : selectedRow.Cells["school"].Value.ToString();
                tbxOgrenciTelefon.Text = selectedRow.Cells["phoneNumber"].Value == null ? string.Empty : selectedRow.Cells["phoneNumber"].Value.ToString();
                tbxOgrenciYksSiralama.Text = selectedRow.Cells["yksScore"].Value == null ? string.Empty : selectedRow.Cells["yksScore"].Value.ToString();
                tbxOgrenciTytNeti.Text = selectedRow.Cells["tytScore"].Value == null ? string.Empty : selectedRow.Cells["tytScore"].Value.ToString();
                tbxOgrenciAytNeti.Text = selectedRow.Cells["aytScore"].Value == null ? string.Empty : selectedRow.Cells["aytScore"].Value.ToString();
                tbxOgrenciMsuNeti.Text = selectedRow.Cells["msuScore"].Value == null ? string.Empty : selectedRow.Cells["msuScore"].Value.ToString();
                tbxOgrenciHedef.Text = selectedRow.Cells["purpose"].Value == null ? string.Empty : selectedRow.Cells["purpose"].Value.ToString();
                tbxVeli1AdSoyad.Text = selectedRow.Cells["parent1Name"].Value == null ? string.Empty : selectedRow.Cells["parent1Name"].Value.ToString();
                tbxVeli1Yakinlik.Text = selectedRow.Cells["parent1ParentalCloseness"].Value == null ? string.Empty : selectedRow.Cells["parent1ParentalCloseness"].Value.ToString();
                tbxVeli1Telefon.Text = selectedRow.Cells["parent1PhoneNumber"].Value == null ? string.Empty : selectedRow.Cells["parent1PhoneNumber"].Value.ToString();
                tbxVeli2AdSoyad.Text = selectedRow.Cells["parent2Name"].Value == null ? string.Empty : selectedRow.Cells["parent2Name"].Value.ToString();
                tbxVeli2Yakinlik.Text = selectedRow.Cells["parent2ParentalCloseness"].Value == null ? string.Empty : selectedRow.Cells["parent2ParentalCloseness"].Value.ToString();
                tbxVeli2Telefon.Text = selectedRow.Cells["parent2PhoneNumber"].Value == null ? string.Empty : selectedRow.Cells["parent2PhoneNumber"].Value.ToString();
            }
        }


        private void btnOgrenciEkle_Click(object sender, EventArgs e)
        {
            if (!TumAlanlariKontrolEt()) return;

            int studentId = int.Parse(tbxOgrenciNumarasi.Text);
            var existingStudent = ent.Student.FirstOrDefault(s => s.student_id == studentId);

            if (existingStudent != null)
            {
                MessageBox.Show("Bu öğrenci numarasına sahip bir öğrenci zaten mevcut.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                var newStudent = new Student
                {
                    student_id = studentId,
                    homework_id = float.Parse(tbxOdevNumarasi.Text),
                    name = tbxOgrenciAdSoyad.Text,
                    @class = cbxSinif.Text,
                    school = tbxOgrenciOkul.Text,
                    phoneNumber = tbxOgrenciTelefon.Text,
                    yksScore = float.Parse(tbxOgrenciYksSiralama.Text),
                    tytScore = float.Parse(tbxOgrenciTytNeti.Text),
                    aytScore = float.Parse(tbxOgrenciAytNeti.Text),
                    msuScore = float.Parse(tbxOgrenciMsuNeti.Text),
                    purpose = tbxOgrenciHedef.Text,
                    parent1Name = tbxVeli1AdSoyad.Text,
                    parent1ParentalCloseness = tbxVeli1Yakinlik.Text,
                    parent1PhoneNumber = tbxVeli1Telefon.Text,
                    parent2Name = tbxVeli2AdSoyad.Text,
                    parent2ParentalCloseness = tbxVeli2Yakinlik.Text,
                    parent2PhoneNumber = tbxVeli2Telefon.Text,
                    teacher_id = teacherId
                };

                ent.Student.Add(newStudent);
                ent.SaveChanges();
                LoadStudentData();
                IslemSonrasiTextBoxTemizle();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Öğrenci eklenirken bir hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnOgrenciDuzenle_Click(object sender, EventArgs e)
        {
            if (!TumAlanlariKontrolEt()) return;

            int studentId = int.Parse(tbxOgrenciNumarasi.Text);
            var student = ent.Student.FirstOrDefault(s => s.student_id == studentId);

            if (student == null)
            {
                MessageBox.Show("Bu öğrenci numarasına sahip bir öğrenci bulunamadı.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                student.homework_id = float.Parse(tbxOdevNumarasi.Text);
                student.name = tbxOgrenciAdSoyad.Text;
                student.@class = cbxSinif.Text;
                student.school = tbxOgrenciOkul.Text;
                student.phoneNumber = tbxOgrenciTelefon.Text;
                student.yksScore = float.Parse(tbxOgrenciYksSiralama.Text);
                student.tytScore = float.Parse(tbxOgrenciTytNeti.Text);
                student.aytScore = float.Parse(tbxOgrenciAytNeti.Text);
                student.msuScore = float.Parse(tbxOgrenciMsuNeti.Text);
                student.purpose = tbxOgrenciHedef.Text;
                student.parent1Name = tbxVeli1AdSoyad.Text;
                student.parent1ParentalCloseness = tbxVeli1Yakinlik.Text;
                student.parent1PhoneNumber = tbxVeli1Telefon.Text;
                student.parent2Name = tbxVeli2AdSoyad.Text;
                student.parent2ParentalCloseness = tbxVeli2Yakinlik.Text;
                student.parent2PhoneNumber = tbxVeli2Telefon.Text;

                ent.SaveChanges();
                LoadStudentData();
                IslemSonrasiTextBoxTemizle();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Öğrenci düzenlenirken bir hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnOgrenciSil_Click(object sender, EventArgs e)
        {
            if (!TumAlanlariKontrolEt()) return;

            int studentId = int.Parse(tbxOgrenciNumarasi.Text);
            var student = ent.Student.FirstOrDefault(s => s.student_id == studentId);

            if (student == null)
            {
                MessageBox.Show("Bu öğrenci numarasına sahip bir öğrenci bulunamadı.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                var meetings = ent.Meeting.Where(m => m.student_id == studentId).ToList();

                // İlgili Meeting kayıtlarını sil
                foreach (var meeting in meetings)
                {
                    ent.Meeting.Remove(meeting);
                }
                var attendances = ent.Attendance.Where(a => a.student_id == studentId).ToList();
                foreach (var attendance in attendances)
                {
                    ent.Attendance.Remove(attendance);
                }
                // İlişkili kayıtları sil
                var relatedRecords = ent.Meeting_Book_Recommendation.Where(m => m.student_id == studentId).ToList();
                foreach (var record in relatedRecords)
                {
                    ent.Meeting_Book_Recommendation.Remove(record);
                }

                // Öğrenci kaydını sil
                ent.Student.Remove(student);
                ent.SaveChanges();
                LoadStudentData();
                IslemSonrasiTextBoxTemizle();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Öğrenci silinirken bir hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool TumAlanlariKontrolEt()
        {
            if (string.IsNullOrWhiteSpace(tbxOgrenciNumarasi.Text) ||
                string.IsNullOrWhiteSpace(tbxOdevNumarasi.Text) ||
                string.IsNullOrWhiteSpace(tbxOgrenciAdSoyad.Text) ||
                string.IsNullOrWhiteSpace(cbxSinif.Text) ||
                string.IsNullOrWhiteSpace(tbxOgrenciOkul.Text) ||
                string.IsNullOrWhiteSpace(tbxOgrenciTelefon.Text) ||
                string.IsNullOrWhiteSpace(tbxOgrenciYksSiralama.Text) ||
                string.IsNullOrWhiteSpace(tbxOgrenciTytNeti.Text) ||
                string.IsNullOrWhiteSpace(tbxOgrenciMsuNeti.Text) ||
                string.IsNullOrWhiteSpace(tbxOgrenciHedef.Text) ||
                string.IsNullOrWhiteSpace(tbxVeli1AdSoyad.Text) ||
                string.IsNullOrWhiteSpace(tbxVeli1Yakinlik.Text) ||
                string.IsNullOrWhiteSpace(tbxVeli1Telefon.Text) ||
                string.IsNullOrWhiteSpace(tbxVeli2AdSoyad.Text) ||
                string.IsNullOrWhiteSpace(tbxVeli2Yakinlik.Text) ||
                string.IsNullOrWhiteSpace(tbxVeli2Telefon.Text))
            {
                MessageBox.Show("Tüm alanlar doldurulmalıdır.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }


        private void tbxOgrenciNumarasi_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true; // Tuşun işlenmesini durdur
            }
        }

        private void tbxOgrenciTelefon_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true; // Tuşun işlenmesini durdur
            }
        }

        private void tbxOgrenciYksSiralama_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true; // Tuşun işlenmesini durdur
            }
        }

        private void tbxOgrenciTytNeti_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true; // Tuşun işlenmesini durdur
            }
        }

        private void tbxOgrenciAytNeti_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true; // Tuşun işlenmesini durdur
            }
        }

        private void tbxOgrenciMsuNeti_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true; // Tuşun işlenmesini durdur
            }
        }

        private void tbxVeli1Telefon_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true; // Tuşun işlenmesini durdur
            }
        }

        private void tbxVeli2Telefon_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true; // Tuşun işlenmesini durdur
            }
        }

        private void tbxOgrenciAdSoyad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true; // Tuşun işlenmesini durdur
            }
        }

        private void tbxVeli1AdSoyad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true; // Tuşun işlenmesini durdur
            }
        }

        private void tbxVeli2AdSoyad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true; // Tuşun işlenmesini durdur
            }
        }

        private void tbxVeli1Yakinlik_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true; // Tuşun işlenmesini durdur
            }
        }

        private void tbxVeli2Yakinlik_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true; // Tuşun işlenmesini durdur
            }
        }
        private void IslemSonrasiTextBoxTemizle()
        {
            tbxOgrenciAdSoyad.Clear();
            tbxOgrenciAytNeti.Clear();
            tbxOgrenciHedef.Clear();
            tbxOgrenciMsuNeti.Clear();
            tbxOgrenciNumarasi.Clear();
            tbxOgrenciOkul.Clear();
            cbxSinif.SelectedIndex = -1;
            tbxOdevNumarasi.Clear();
            tbxOgrenciTelefon.Clear();
            tbxOgrenciTytNeti.Clear();
            tbxOgrenciYksSiralama.Clear();
            tbxVeli1AdSoyad.Clear();
            tbxVeli1Telefon.Clear();
            tbxVeli1Yakinlik.Clear();
            tbxVeli2AdSoyad.Clear();
            tbxVeli2Telefon.Clear();
            tbxVeli2Yakinlik.Clear();


        }

        private void lblTextBoxTemizle_Click(object sender, EventArgs e)
        {
            IslemSonrasiTextBoxTemizle();
        }

        private void btnDosyadanOgrenciEkle_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Excel Files|*.xls;*.xlsx",
                Title = "Öğrenci Bilgilerini İçeren Excel Dosyasını Seçin"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;
                DataTable dt = ReadExcelFile(filePath);
                AddStudentsToDatabase(dt);
            }
        }
        private DataTable ReadExcelFile(string filePath)
        {
            using (var workbook = new XLWorkbook(filePath))
            {
                var worksheet = workbook.Worksheet(1);
                var dataTable = new DataTable();

                bool firstRow = true;
                foreach (var row in worksheet.RowsUsed())
                {
                    if (firstRow)
                    {
                        foreach (var cell in row.Cells())
                        {
                            dataTable.Columns.Add(cell.Value.ToString());
                        }
                        firstRow = false;
                    }
                    else
                    {
                        dataTable.Rows.Add();
                        int i = 0;
                        foreach (var cell in row.Cells())
                        {
                            dataTable.Rows[dataTable.Rows.Count - 1][i] = cell.Value.ToString();
                            i++;
                        }
                    }
                }
                return dataTable;
            }
        }

        private void AddStudentsToDatabase(DataTable dt)
        {
            foreach (DataRow row in dt.Rows)
            {
                if (row["Öğrenci Numarası"] != null && row["Öğrenci Adı"] != null && row["Sınıf"] != null)
                {
                    string studentNumberStr = row["Öğrenci Numarası"].ToString();
                    string studentName = row["Öğrenci Adı"].ToString();
                    string studentClass = row["Sınıf"].ToString();
                    string teacherIdStr = row["Rehber Öğretmen Numarası"]?.ToString();
                    string parent1Name = row["1. Veli Adı"]?.ToString();
                    string parent1PhoneNumber = row["1. Veli Telefon Numarası"]?.ToString();
                    string parent2Name = row["2. Veli Adı"]?.ToString();
                    string parent2PhoneNumber = row["2. Veli Telefon Numarası"]?.ToString();

                    // Convert student number to integer
                    if (!int.TryParse(studentNumberStr, out int studentNumber))
                    {
                        MessageBox.Show($"Geçersiz öğrenci numarası: {studentNumberStr}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        continue;
                    }

                    // Convert teacherId to integer
                    int? teacherId = string.IsNullOrEmpty(teacherIdStr) ? (int?)null : int.Parse(teacherIdStr);

                    // Check if teacher exists if teacherId is provided
                    if (teacherId.HasValue)
                    {
                        var existingTeacher = ent.Teacher.SingleOrDefault(t => t.teacher_id == teacherId.Value);
                        if (existingTeacher == null)
                        {
                            MessageBox.Show($"Öğretmen numarası {teacherId.Value} mevcut değil.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            continue; // Skip to the next student
                        }
                    }

                    // Check if student number already exists
                    var existingStudent = ent.Student.SingleOrDefault(s => s.student_id == studentNumber);
                    if (existingStudent != null)
                    {
                        MessageBox.Show($"Öğrenci numarası {studentNumber} zaten mevcut.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        continue; // Skip to the next student
                    }

                    var newStudent = new Student
                    {
                        student_id = studentNumber,
                        name = studentName,
                        @class = studentClass,
                        teacher_id = teacherId,
                        parent1Name = parent1Name,
                        parent1PhoneNumber = parent1PhoneNumber,
                        parent2Name = parent2Name,
                        parent2PhoneNumber = parent2PhoneNumber
                    };

                    ent.Student.Add(newStudent);
                }
            }

            ent.SaveChanges();
            MessageBox.Show("Geçerli öğrenciler eklendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LoadStudentData(); // DataGridView'i güncellemek için
        }

        private void tbxOdevNumarasi_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true; // Tuşun işlenmesini durdur
            }
        }
    }
}
