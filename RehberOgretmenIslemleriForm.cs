using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace AcarAkademiRehberlik
{
    public partial class RehberOgretmenIslemleriForm : Form
    {
        private Dbo_acarakademirehberlikAppEntities ent = new Dbo_acarakademirehberlikAppEntities();
        private int teacherId;
        public RehberOgretmenIslemleriForm(int id)
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
        private void RehberOgretmenIslemleriForm_Load(object sender, EventArgs e)
        {
            LoadTeachers();
            StyleButton(btnGeriDon);
            StyleButton(btnRehberOgretmenEkle);
            StyleButton(btnRehberOgretmenGuncelle);
            StyleButton(btnRehberOgretmenSil);
            StyleDataGridView(dgwRehberOgretmenler);
            StyleDataGridView(dgwRehberOgretmenSec);
            StyleDataGridView(dgwOgrenciSec);
            ApplyModernStyle(this);
            StyleDataGridView(dgwSekreterler);
            StyleButton(btnGeriDon2);
            StyleButton(btnSekreterEkle);
            StyleButton(btnSekreterGuncelle);
            StyleButton(btnSekreterSil);
            LoadSecretaries();
            StyleButton(btnOgrenciTasi);
            StyleButton(btnTumGorusmeleriSil);
            StyleButton(btnTumOgrencileriSil);
            LoadStudents();
            StyleButton(btnGeriDon1);



        }
        private void LoadTeachers()
        {
            using (var context = new Dbo_acarEntities())
            {
                var teachers = context.Teacher.Select(t => new
                {
                    t.teacher_id,
                    t.name,
                    t.password,
                    t.role,
                    RoleText = t.role == 0 ? "Yok" : "Var"
                }).ToList();

                dgwRehberOgretmenler.DataSource = teachers;
                dgwRehberOgretmenSec.DataSource = teachers;
                dgwRehberOgretmenler.Columns["teacher_id"].HeaderText = "Öğretmen Numarası";
                dgwRehberOgretmenler.Columns["name"].HeaderText = "Ad Soyad";
                dgwRehberOgretmenler.Columns["password"].HeaderText = "Şifre";
                dgwRehberOgretmenler.Columns["RoleText"].HeaderText = "Yetki";
                dgwRehberOgretmenSec.Columns["teacher_id"].HeaderText = "Öğretmen Numarası";
                dgwRehberOgretmenSec.Columns["name"].HeaderText = "Ad Soyad";
                dgwRehberOgretmenSec.Columns["password"].Visible= false;
                dgwRehberOgretmenSec.Columns["role"].Visible = false;
                dgwRehberOgretmenler.Columns["role"].Visible = false;
            }
        }
        private void LoadStudents()
        {
            using (var context = new Dbo_acarEntities())
            {
                var students = context.Student.Select(s => new
                {
                    s.student_id,
                    s.name,
                    s.@class,
                    TeacherName = context.Teacher.FirstOrDefault(t => t.teacher_id == s.teacher_id).name
                }).ToList();

                dgwOgrenciSec.DataSource = students;
                dgwOgrenciSec.Columns["student_id"].HeaderText = "Öğrenci Numarası";
                dgwOgrenciSec.Columns["studentName"].HeaderText = "Ad Soyad";
                dgwOgrenciSec.Columns["class"].HeaderText = "Sınıf";
                dgwOgrenciSec.Columns["TeacherName"].HeaderText = "Rehber Öğretmen";

            }
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
   

        

        

        private void dgwRehberOgretmenler_SelectionChanged(object sender, EventArgs e)
        {
            if (dgwRehberOgretmenler.SelectedRows.Count > 0)
            {
                var selectedRow = dgwRehberOgretmenler.SelectedRows[0];
                tbxRehberOgretmenNumarasi.Text = selectedRow.Cells["teacher_id"].Value.ToString();
                tbxRehberOgretmenAdSoyad.Text = selectedRow.Cells["name"].Value.ToString();
                tbxRehberOgretmenSifre.Text = selectedRow.Cells["password"].Value.ToString();
                chbxYetki.Checked = Convert.ToInt32(selectedRow.Cells["role"].Value) == 1;
            }
        }

        private void tbxRehberOgretmenNumarasi_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true; // Tuşun işlenmesini durdur
            }
        }

        private void tbxRehberOgretmenAdSoyad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetterOrDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true; // Tuşun işlenmesini durdur
            }
        }

        private void btnGeriDon2_Click(object sender, EventArgs e)
        {
            RehberlikOgretmeniAnaForm rehberlikOgretmeniAnaForm = new RehberlikOgretmeniAnaForm(teacherId);
            rehberlikOgretmeniAnaForm.Show();
            this.Hide();
        }

        private void btnSekreterEkle_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbxSekreterNumarasi.Text) ||
                string.IsNullOrWhiteSpace(tbxName.Text) ||
                string.IsNullOrWhiteSpace(tbxPassword.Text))
            {
                MessageBox.Show("Lütfen tüm alanları doldurun.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int secretaryId;
            if (!int.TryParse(tbxSekreterNumarasi.Text, out secretaryId))
            {
                MessageBox.Show("Sekreter numarası geçerli bir sayı olmalıdır.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Aynı secretary_id'ye sahip bir kayıt olup olmadığını kontrol et
            var existingSecretary = ent.Secretary.FirstOrDefault(s => s.secretary_id == secretaryId);
            if (existingSecretary != null)
            {
                MessageBox.Show($"Sekreter numarası {secretaryId} olan bir kayıt zaten mevcut.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Yeni sekreter oluştur
            var newSecretary = new Secretary
            {
                secretary_id = secretaryId,
                name = tbxName.Text,
                password = tbxPassword.Text
            };

            // Yeni sekreteri veritabanına ekle
            ent.Secretary.Add(newSecretary);
            ent.SaveChanges();

            // DataGridView'i güncelle
            LoadSecretaries();
            ClearInputs();

            MessageBox.Show("Sekreter başarıyla eklendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void ClearInputs()
        {
            tbxSekreterNumarasi.Clear();
            tbxName.Clear();
            tbxPassword.Clear();
        }

        private void btnSekreterSil_Click(object sender, EventArgs e)
        {
            if (dgwSekreterler.SelectedRows.Count == 0)
            {
                MessageBox.Show("Lütfen silmek istediğiniz sekreteri seçin.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int selectedId = int.Parse(dgwSekreterler.SelectedRows[0].Cells["SecretaryIdColumn"].Value.ToString());

            // Silinecek sekreteri bul
            var secretaryToDelete = ent.Secretary.FirstOrDefault(s => s.secretary_id == selectedId);

            if (secretaryToDelete != null)
            {
                ent.Secretary.Remove(secretaryToDelete);
                ent.SaveChanges();

                // DataGridView'i güncelle
                LoadSecretaries();
                ClearInputs();

                MessageBox.Show("Sekreter başarıyla silindi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Sekreter bulunamadı.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSekreterGuncelle_Click(object sender, EventArgs e)
        {
            if (dgwSekreterler.SelectedRows.Count == 0)
            {
                MessageBox.Show("Lütfen güncellemek istediğiniz sekreteri seçin.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int selectedId = int.Parse(dgwSekreterler.SelectedRows[0].Cells["SecretaryIdColumn"].Value.ToString());

            // Güncellenecek sekreteri bul
            var secretaryToUpdate = ent.Secretary.FirstOrDefault(s => s.secretary_id == selectedId);

            if (secretaryToUpdate != null)
            {
                secretaryToUpdate.name = tbxName.Text;
                secretaryToUpdate.password = tbxPassword.Text;

                ent.SaveChanges();

                // DataGridView'i güncelle
                LoadSecretaries();
                ClearInputs();

                MessageBox.Show("Sekreter başarıyla güncellendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Sekreter bulunamadı.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void LoadSecretaries()
        {
            dgwSekreterler.Rows.Clear();

            var secretaries = ent.Secretary.ToList();
            foreach (var secretary in secretaries)
            {
                dgwSekreterler.Rows.Add(secretary.secretary_id, secretary.name, secretary.password);
            }
        }

        private void dgwSekreterler_SelectionChanged(object sender, EventArgs e)
        {
            if (dgwSekreterler.SelectedRows.Count > 0)
            {
                var selectedRow = dgwSekreterler.SelectedRows[0];
                tbxSekreterNumarasi.Text = selectedRow.Cells["SecretaryIdColumn"].Value.ToString();
                tbxName.Text = selectedRow.Cells["NameColumn"].Value.ToString();
                tbxPassword.Text = selectedRow.Cells["PasswordColumn"].Value.ToString();
            }
        }

        private void dgwRehberOgretmenler_SelectionChanged_1(object sender, EventArgs e)
        {
            if (dgwRehberOgretmenler.SelectedRows.Count > 0)
            {
                var selectedRow = dgwRehberOgretmenler.SelectedRows[0];
                tbxRehberOgretmenNumarasi.Text = selectedRow.Cells["teacher_id"].Value.ToString();
                tbxRehberOgretmenAdSoyad.Text = selectedRow.Cells["name"].Value.ToString();
                tbxRehberOgretmenSifre.Text = selectedRow.Cells["password"].Value.ToString();
                chbxYetki.Checked = Convert.ToInt32(selectedRow.Cells["role"].Value) == 1;
            }
        }

        private void lblOgretmenTextBoxTemizle_Click(object sender, EventArgs e)
        {
            tbxRehberOgretmenAdSoyad.Clear();
            tbxRehberOgretmenNumarasi.Clear();
            tbxRehberOgretmenSifre.Clear();
            
        }

        private void lblSekTbxTemizle_Click(object sender, EventArgs e)
        {
            tbxSekreterNumarasi.Clear();
            tbxName.Clear();
            tbxPassword.Clear();
        }

        private void btnRehberOgretmenEkle_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbxRehberOgretmenNumarasi.Text) || string.IsNullOrWhiteSpace(tbxRehberOgretmenAdSoyad.Text) || string.IsNullOrWhiteSpace(tbxRehberOgretmenSifre.Text))
            {
                MessageBox.Show("Lütfen tüm alanları doldurun.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (var context = new Dbo_acarEntities())
            {
                var newTeacher = new Teacher
                {
                    teacher_id = int.Parse(tbxRehberOgretmenNumarasi.Text),
                    name = tbxRehberOgretmenAdSoyad.Text,
                    password = tbxRehberOgretmenSifre.Text,
                    role = chbxYetki.Checked ? 1 : 0
                };

                context.Teacher.Add(newTeacher);
                context.SaveChanges();
            }

            LoadTeachers();
            MessageBox.Show("Öğretmen başarıyla eklendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnRehberOgretmenGuncelle_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbxRehberOgretmenNumarasi.Text) || string.IsNullOrWhiteSpace(tbxRehberOgretmenAdSoyad.Text) || string.IsNullOrWhiteSpace(tbxRehberOgretmenSifre.Text))
            {
                MessageBox.Show("Lütfen tüm alanları doldurun.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (var context = new Dbo_acarEntities())
            {
                int teacherId = int.Parse(tbxRehberOgretmenNumarasi.Text);
                var teacherToUpdate = context.Teacher.Find(teacherId);

                if (teacherToUpdate != null)
                {
                    teacherToUpdate.name = tbxRehberOgretmenAdSoyad.Text;
                    teacherToUpdate.password = tbxRehberOgretmenSifre.Text;
                    teacherToUpdate.role = chbxYetki.Checked ? 1 : 0;
                    context.SaveChanges();
                    MessageBox.Show("Öğretmen başarıyla güncellendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Bu öğretmen numarası bulunamadı.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            LoadTeachers();
        }

        private void btnRehberOgretmenSil_Click(object sender, EventArgs e)
        {

            // Öğretmen ID'sini al
            int teacherId = int.Parse(tbxRehberOgretmenNumarasi.Text);

            // Öğretmen kaydını veritabanından bul
            var teacherToDelete = ent.Teacher.SingleOrDefault(t => t.teacher_id == teacherId);
            if (teacherToDelete == null)
            {
                MessageBox.Show("Öğretmen bulunamadı.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // İlgili tüm Meeting kayıtlarını sil
            var meetingsToDelete = ent.Meeting.Where(m => m.teacher_id == teacherId).ToList();
            ent.Meeting.RemoveRange(meetingsToDelete);

            // İlgili tüm Student kayıtlarını güncelle
            var studentsToUpdate = ent.Student.Where(s => s.teacher_id == teacherId).ToList();
            foreach (var student in studentsToUpdate)
            {
                student.teacher_id = null;  // Öğretmen bilgisi boşalt
            }

            // Öğretmen kaydını veritabanından sil
            ent.Teacher.Remove(teacherToDelete);

            // Değişiklikleri kaydet
            try
            {
                ent.SaveChanges();
                MessageBox.Show("Öğretmen ve ilişkili tüm kayıtlar başarıyla silindi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                // Formu güncelle
                LoadTeachers();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Bir hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }



            LoadTeachers();
        }

        private void tbxRehberOgretmenNumarasi_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                // Tuşun işlenmesini engelle
                e.Handled = true;
            }
        }

        private void tbxOgrenciNumarasi_TextChanged(object sender, EventArgs e)
        {
            if (int.TryParse(tbxOgrenciNumarasi.Text, out int studentId))
            {
                using (var context = new Dbo_acarEntities())
                {
                    var filteredStudents = context.Student
                        .Where(s => s.student_id == studentId)
                        .Select(s => new
                        {
                            s.student_id,
                            s.name,
                            s.@class,
                            TeacherName = context.Teacher.FirstOrDefault(t => t.teacher_id == s.teacher_id).name
                        })
                        .ToList();

                    dgwOgrenciSec.DataSource = filteredStudents;
                    dgwOgrenciSec.Columns["student_id"].HeaderText = "Öğrenci Numarası";
                    dgwOgrenciSec.Columns["studentName"].HeaderText = "Ad Soyad";
                    dgwOgrenciSec.Columns["@class"].HeaderText = "Sınıf";
                    dgwOgrenciSec.Columns["TeacherName"].HeaderText = "Rehber Öğretmen";
                }
            }
            else
            {
                LoadStudents(); // Load all students if no valid number is entered
            }
        }

        private void btnOgrenciTasi_Click(object sender, EventArgs e)
        {
            // Ensure both a student and a teacher are selected
            if (dgwOgrenciSec.SelectedRows.Count > 0 && dgwRehberOgretmenSec.SelectedRows.Count == 1)
            {
                // Get the selected teacher's ID from dgwOgretmenSec
                int selectedTeacherId = (int)dgwRehberOgretmenSec.SelectedRows[0].Cells["teacher_id"].Value;

                using (var context = new Dbo_acarEntities())
                {
                    foreach (DataGridViewRow selectedRow in dgwOgrenciSec.SelectedRows)
                    {
                        // Get the student ID from the selected row
                        int studentId = (int)selectedRow.Cells["student_id"].Value;

                        // Find the student in the database and update the teacher_id
                        var student = context.Student.FirstOrDefault(s => s.student_id == studentId);
                        if (student != null)
                        {
                            student.teacher_id = selectedTeacherId;
                        }
                    }

                    // Save changes to the database
                    context.SaveChanges();

                    // Refresh the students list
                    LoadStudents();
                }

                MessageBox.Show("Öğrenciler başarıyla taşındı.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Lütfen taşıma işlemi için birden fazla öğrenci ve bir öğretmen seçiniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnTumOgrencileriSil_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Tüm öğrenci kayıtlarını silmek istediğinizden emin misiniz?", "Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                using (var context = new Dbo_acarEntities())
                {
                    // Remove all Student records
                    context.Student.RemoveRange(context.Student);
                    context.SaveChanges();
                }

                MessageBox.Show("Tüm öğrenci kayıtları silindi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Optionally refresh the DataGridView
                LoadStudents();
            }
        }

        private void btnTumGorusmeleriSil_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Tüm görüşme kayıtlarını silmek istediğinizden emin misiniz?", "Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                using (var context = new Dbo_acarEntities())
                {
                    // Remove all Meeting records
                    context.Meeting.RemoveRange(context.Meeting);
                    context.SaveChanges();
                }

                MessageBox.Show("Tüm görüşme kayıtları silindi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Optionally refresh the DataGridView
                // LoadMeetings();
            }
        }

        private void btnGeriDon1_Click(object sender, EventArgs e)
        {
            RehberlikOgretmeniAnaForm rehberlikOgretmeniAnaForm = new RehberlikOgretmeniAnaForm(teacherId);
            rehberlikOgretmeniAnaForm.Show();
            this.Hide();
        }
    }
}
