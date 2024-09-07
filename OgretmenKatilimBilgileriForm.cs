using iTextSharp.text.pdf;
using iTextSharp.text;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using Rectangle = System.Drawing.Rectangle;
using System.Windows.Forms.DataVisualization.Charting;
using DocumentFormat.OpenXml.Office2010.Excel;
using Color = System.Drawing.Color;
using DocumentFormat.OpenXml.Bibliography;

namespace AcarAkademiRehberlik
{
    public partial class OgretmenKatilimBilgileriForm : Form
    {
        private int teacherId;
        private Dbo_acarakademirehberlikAppEntities ent = new Dbo_acarakademirehberlikAppEntities();
        
        private Teacher currentTeacher;
        
        public OgretmenKatilimBilgileriForm(int id)
        {
            InitializeComponent();
            this.teacherId = id;
            
        }

        private void OgretmenKatilimBilgileriForm_Load(object sender, EventArgs e)
        {
            StyleDataGridView(dgwKatilimRaporu);
            dgwKatilimRaporu.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            LoadUniqueClasses();
            LoadAllStudentsToGrid();
            cbxSiniflar.SelectedItem = "Hepsi";
            StyleButton(btnSeciliKatilimSil);
            dgwOgrenciler.ClearSelection();
            dtpTarihAralikBaslangic.Value = DateTime.Now.AddDays(-7);
            dtpTarihAralikBitis.Value = DateTime.Now;
            StyleDataGridView(dgwOgrenciler);
            ApplyModernStyle(this);
            StyleButton(btnKatilimIndir);
            StyleButton(btnTumunuGoster);
            StyleButton(btnTumunuSil);
            StyleButton(btnOgrenciKatılımRaporuIndir);
            StyleButton(btnGeriDon);
            TeacherRoleControl();
        }
        private void TeacherRoleControl()
        {
            // Retrieve the teacher based on teacherId
            currentTeacher = ent.Teacher.FirstOrDefault(t => t.teacher_id == teacherId);

           
                // Check the role of the teacher
                if (currentTeacher.role == 0)
                {
                    // Hide the buttons if role is 0
                    btnSeciliKatilimSil.Visible = false;
                    btnTumunuSil.Visible = false;
                }
            
        }
        private void LoadAttendanceByStudentId(string studentId)
        {
            var attendanceRecords = ent.Attendance
                                       .Where(a => a.student_id.ToString() == studentId)
                                       .OrderByDescending(a => a.attendance_date)
                                       .ToList();

            dgwKatilimRaporu.Rows.Clear();
            dgwKatilimRaporu.Columns.Clear();

            // Sütunları ekle
            //dgwKatilimRaporu.Columns.Add("AttendanceIdColumn", "Kayıt ID");
            dgwKatilimRaporu.Columns.Add("DateColumn", "Tarih");
            dgwKatilimRaporu.Columns.Add("StudentIdColumn", "Öğrenci Numarası");
            dgwKatilimRaporu.Columns.Add("StudentNameColumn", "Öğrenci Adı");
            //dgwKatilimRaporu.Columns.Add("StatusColumn", "Durum");
            dgwKatilimRaporu.Columns.Add("DetailsColumn", "Gelmeme Sebebi");

            // Kayıtları DataGridView'a ekle
            foreach (var attendance in attendanceRecords)
            {
                var student = ent.Student.FirstOrDefault(s => s.student_id == attendance.student_id);

                if (student != null)
                {
                    string formattedDate = attendance.attendance_date.HasValue ? attendance.attendance_date.Value.ToString("dd MMMM yyyy") : string.Empty;
                    dgwKatilimRaporu.Rows.Add(formattedDate, attendance.student_id, student.name, attendance.attendance_details);
                }
            }
        }

        private void LoadAttendanceByClass(string className)
        {
            IQueryable<Attendance> attendanceQuery;

            if (className == "Hepsi")
            {
                attendanceQuery = ent.Attendance.OrderByDescending(a => a.attendance_date);
            }
            else
            {
                attendanceQuery = ent.Attendance
                                      .OrderByDescending(a => a.attendance_date)
                                      .Where(a => ent.Student.Any(s => s.student_id == a.student_id && s.@class == className));
            }

            var attendanceRecords = attendanceQuery.ToList();

            dgwKatilimRaporu.Rows.Clear();
            dgwKatilimRaporu.Columns.Clear();

            // Sütunları ekle
            //dgwKatilimRaporu.Columns.Add("AttendanceIdColumn", "Kayıt ID");
            dgwKatilimRaporu.Columns.Add("DateColumn", "Tarih");
            dgwKatilimRaporu.Columns.Add("StudentIdColumn", "Öğrenci Numarası");
            dgwKatilimRaporu.Columns.Add("StudentNameColumn", "Öğrenci Adı");
            //dgwKatilimRaporu.Columns.Add("StatusColumn", "Durum");
            dgwKatilimRaporu.Columns.Add("DetailsColumn", "Gelmeme Sebebi");

            // Kayıtları DataGridView'a ekle
            foreach (var attendance in attendanceRecords)
            {
                var student = ent.Student.FirstOrDefault(s => s.student_id == attendance.student_id);
                if (student != null)
                {
                    string formattedDate = attendance.attendance_date.HasValue ? attendance.attendance_date.Value.ToString("dd MMMM yyyy") : string.Empty;
                    dgwKatilimRaporu.Rows.Add(formattedDate, attendance.student_id, student.name, attendance.attendance_details);
                }
            }
        }
        private void FilterAttendanceRecords()
        {
            string selectedClass = cbxSiniflar.SelectedItem?.ToString();
            //string selectedStatus = cbxKatilim.SelectedItem?.ToString();
            DateTime startDate = dtpTarihAralikBaslangic.Value.Date;
            DateTime endDate = dtpTarihAralikBitis.Value.Date;

            IQueryable<Attendance> attendanceQuery = ent.Attendance;

            // Eğer dgwOgrenciler'de seçili bir öğrenci varsa, filtrelemeyi bu öğrenciye göre yap
            if (dgwOgrenciler.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dgwOgrenciler.SelectedRows[0];
                if (selectedRow != null && selectedRow.Cells["StudentIdColumn"].Value != null)
                {
                    int studentId = Convert.ToInt32(selectedRow.Cells["StudentIdColumn"].Value);
                    attendanceQuery = attendanceQuery.Where(a => a.student_id == studentId);

                    // Seçili öğrencinin sınıfını cbxSiniflar'da otomatik olarak seç
                    var studentClass = ent.Student.FirstOrDefault(s => s.student_id == studentId)?.@class;
                    if (studentClass != null && cbxSiniflar.Items.Contains(studentClass))
                    {
                        cbxSiniflar.SelectedItem = studentClass;
                    }
                }
            }
            else
            {
                // Sınıf seçimi kontrolü
                if (selectedClass != null && selectedClass != "Hepsi")
                {
                    attendanceQuery = attendanceQuery.Where(a => ent.Student.Any(s => s.student_id == a.student_id && s.@class == selectedClass));
                }
            }

            // Katılım durumu seçimi kontrolü
            //if (selectedStatus != null && selectedStatus != "Hepsi")
            //{
            //    attendanceQuery = attendanceQuery.Where(a => a.attendance_status == selectedStatus);
            //}

            // Tarih aralığı kontrolü
            attendanceQuery = attendanceQuery.Where(a => a.attendance_date >= startDate && a.attendance_date <= endDate);

            var filteredAttendance = attendanceQuery.ToList();

            dgwKatilimRaporu.Rows.Clear();
            dgwKatilimRaporu.Columns.Clear();

            // Sütunları ekle
            //dgwKatilimRaporu.Columns.Add("AttendanceIdColumn", "Kayıt ID");
            dgwKatilimRaporu.Columns.Add("DateColumn", "Tarih");
            dgwKatilimRaporu.Columns.Add("StudentIdColumn", "Öğrenci Numarası");
            dgwKatilimRaporu.Columns.Add("StudentNameColumn", "Öğrenci Adı");
            //dgwKatilimRaporu.Columns.Add("StatusColumn", "Durum");
            dgwKatilimRaporu.Columns.Add("DetailsColumn", "Gelmeme Sebebi");

            // Kayıtları DataGridView'a ekle
            foreach (var attendance in filteredAttendance)
            {
                var student = ent.Student.FirstOrDefault(s => s.student_id == attendance.student_id);
                if (student != null)
                {
                    string formattedDate = attendance.attendance_date.HasValue ? attendance.attendance_date.Value.ToString("dd MMMM yyyy") : string.Empty;
                    dgwKatilimRaporu.Rows.Add(formattedDate, attendance.student_id, student.name, attendance.attendance_details);
                }
            }

            // dgwOgrenciler'de hiçbir satır seçilmediyse "Hepsi" seçeneğini cbxSiniflar'da seç
            if (dgwOgrenciler.SelectedRows.Count == 0)
            {
                //cbxSiniflar.SelectedItem = "Hepsi";
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
        private void LoadAllStudentsToGrid()
        {
            var allStudents = ent.Student
                                 .Select(s => new { s.student_id, s.name })
                                 .ToList();

            // DataGridView sıfırlama
            dgwOgrenciler.Rows.Clear();
            dgwOgrenciler.Columns.Clear();

            // Sütunları ekle
            dgwOgrenciler.Columns.Add("StudentIdColumn", "Öğrenci Numarası");
            dgwOgrenciler.Columns.Add("NameColumn", "İsim");

            // Öğrenci bilgilerini DataGridView'a ekle
            foreach (var student in allStudents)
            {
                dgwOgrenciler.Rows.Add(student.student_id, student.name);
            }
        }

        private void LoadUniqueClasses()
        {
            var uniqueClasses = ent.Student
                          .Select(s => s.@class)
                          .Distinct()
                          .ToList();

            cbxSiniflar.Items.Clear();
            cbxSiniflar.Items.AddRange(uniqueClasses.ToArray());
            cbxSiniflar.Items.Add("Hepsi");

        }

        private void tbxOgrenciNumarasi_TextChanged(object sender, EventArgs e)
        {
            string ogrenciNumarasi = tbxOgrenciNumarasi.Text.Trim();

            if (string.IsNullOrEmpty(ogrenciNumarasi))
            {
                // Eğer textbox boşsa, tüm öğrencileri yükle
                LoadAllStudentsToGrid();
            }
            else
            {
                // Öğrenci numarasına göre filtreleme
                int numara;
                if (int.TryParse(ogrenciNumarasi, out numara))
                {
                    var student = ent.Student.FirstOrDefault(s => s.student_id == numara);
                    if (student != null)
                    {
                        // Öğrenci bulundu, DataGridView'da göster
                        dgwOgrenciler.Rows.Clear();
                        dgwOgrenciler.Columns.Clear();

                        dgwOgrenciler.Columns.Add("StudentIdColumn", "Öğrenci Numarası");
                        dgwOgrenciler.Columns.Add("NameColumn", "İsim");

                        dgwOgrenciler.Rows.Add(student.student_id, student.name);
                    }

                }

            }
        }

        private void lblAramaYap_Click(object sender, EventArgs e)
        {
            FilterAttendanceRecords();
        }

        private void dgwOgrenciler_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                string studentId = dgwOgrenciler.Rows[e.RowIndex].Cells["StudentIdColumn"].Value.ToString();
                LoadAttendanceByStudentId(studentId);
            }
        }

        private void cbxSiniflar_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedClass = cbxSiniflar.SelectedItem.ToString();
            LoadAttendanceByClass(selectedClass);
        }

        private void lblSecimiKaldir_Click(object sender, EventArgs e)
        {
            dgwOgrenciler.ClearSelection();
        }

        private void btnTumunuGoster_Click(object sender, EventArgs e)
        {
            var allAttendanceRecords = ent.Attendance
                                                    .OrderByDescending(a => a.attendance_date)
                                                    .ToList();

            dgwKatilimRaporu.Rows.Clear();
            dgwKatilimRaporu.Columns.Clear();

            //dgwKatilimRaporu.Columns.Add("AttendanceIdColumn", "Kayıt ID");
            dgwKatilimRaporu.Columns.Add("DateColumn", "Tarih");
            dgwKatilimRaporu.Columns.Add("StudentIdColumn", "Öğrenci Numarası");
            dgwKatilimRaporu.Columns.Add("StudentNameColumn", "Öğrenci Adı");
            //dgwKatilimRaporu.Columns.Add("StatusColumn", "Durum");
            dgwKatilimRaporu.Columns.Add("DetailsColumn", "Gelmeme Sebebi");

            // Kayıtları DataGridView'a ekle
            foreach (var attendance in allAttendanceRecords)
            {
                var student = ent.Student.FirstOrDefault(s => s.student_id == attendance.student_id);
                string formattedDate = attendance.attendance_date.HasValue ? attendance.attendance_date.Value.ToString("dd MMMM yyyy") : string.Empty;
                dgwKatilimRaporu.Rows.Add(formattedDate, attendance.student_id, student.name, attendance.attendance_details);
            }
        }

        private void btnKatilimIndir_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "PDF Files|*.pdf",
                Title = "Katılım Raporunu Kaydet"
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = saveFileDialog.FileName;
                CreateAttendancePdfReport(filePath);
                MessageBox.Show($"Katılım raporu başarıyla kaydedildi: {filePath}", "Rapor Kaydedildi", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
        private void CreateAttendancePdfReport(string filePath)
        {
            Document doc = new Document();
            PdfWriter writer = PdfWriter.GetInstance(doc, new FileStream(filePath, FileMode.Create));

            var teacher = ent.Teacher.FirstOrDefault(t => t.teacher_id == this.teacherId);
            string teacherName = teacher?.name;
            PdfPageEvents pageEvents = new PdfPageEvents(teacherName);
            writer.PageEvent = pageEvents;

            doc.Open();
            doc.Add(new Paragraph("\n"));
            doc.Add(new Paragraph("\n"));
            doc.Add(new Paragraph("\n"));
            // Başlık
            BaseFont baseFont = BaseFont.CreateFont(@"C:\Windows\Fonts\arial.ttf", BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
            iTextSharp.text.Font titleFont = new iTextSharp.text.Font(baseFont, 18f, iTextSharp.text.Font.BOLD, BaseColor.BLACK);
            Paragraph title = new Paragraph("Katılım Raporu", titleFont);
            title.Alignment = Element.ALIGN_CENTER;
            doc.Add(title);
            doc.Add(new Paragraph("\n"));

            // Tarih aralığı bilgisi
            //Paragraph dateInfo = new Paragraph($"Rapor Alma Tarihi: {DateTime.Now.ToString("dd MMMM yyyy")}", new iTextSharp.text.Font(baseFont, 12f, iTextSharp.text.Font.BOLD, BaseColor.BLACK));
           // dateInfo.Alignment = Element.ALIGN_CENTER;
            //doc.Add(dateInfo);
            

            // Önce tarihlerin listesini alalım
            List<DateTime> uniqueDates = dgwKatilimRaporu.Rows.Cast<DataGridViewRow>()
                                        .Select(r => Convert.ToDateTime(r.Cells["DateColumn"].Value))
                                        .Distinct()
                                        .OrderBy(d => d)
                                        .ToList();

            // Her tarih için işlem yapalım
            foreach (DateTime date in uniqueDates)
            {
                // Tarih başlığı ekle
                Paragraph dateTitle = new Paragraph($"Tarih: {date.ToString("dd MMMM yyyy")}", new iTextSharp.text.Font(baseFont, 12f, iTextSharp.text.Font.BOLD, BaseColor.BLACK));
                doc.Add(dateTitle);
                doc.Add(new Paragraph("\n"));

                // Tarihe ait kayıtları alalım
                var recordsForDate = dgwKatilimRaporu.Rows.Cast<DataGridViewRow>()
                                    .Where(r => Convert.ToDateTime(r.Cells["DateColumn"].Value) == date)
                                    .ToList();

                // Öğrenci sınıflarını gruplamak için Dictionary tanımla
                Dictionary<string, List<string>> classStudents = new Dictionary<string, List<string>>();

                // DataGridView içindeki her satırı dolaşarak öğrenci sınıflarını grupla
                foreach (DataGridViewRow row in recordsForDate)
                {
                    if (row.Cells["StudentIdColumn"].Value != null)//**************
                    {
                        string studentId = row.Cells["StudentIdColumn"].Value.ToString();
                        string studentClass = ent.Student.FirstOrDefault(s => s.student_id.ToString() == studentId)?.@class;

                        if (studentClass != null)
                        {
                            if (!classStudents.ContainsKey(studentClass))
                            {
                                classStudents[studentClass] = new List<string>();
                            }

                            if (!classStudents[studentClass].Contains(studentId))
                            {
                                classStudents[studentClass].Add(studentId);
                            }
                        }
                    }
                }

                // Sınıfları ve öğrenci bilgilerini PDF'e ekle
                foreach (var classStudentPair in classStudents)
                {
                    string studentClass = classStudentPair.Key;
                    List<string> studentIds = classStudentPair.Value;

                    //// Sınıf başlığı ekle
                    //Paragraph classTitle = new Paragraph($"Sınıf: {studentClass}", new iTextSharp.text.Font(baseFont, 10f, iTextSharp.text.Font.BOLD, BaseColor.BLACK));
                    //doc.Add(classTitle);
                    //Paragraph centerAlignedText = new Paragraph("Öğrenci - Gelmeme Sebebi", new iTextSharp.text.Font(baseFont, 8f, iTextSharp.text.Font.NORMAL, BaseColor.BLACK));
                    //centerAlignedText.Alignment = Element.ALIGN_CENTER;
                    //centerAlignedText.SpacingAfter = 10f; // Alt boşluk ekleyelim
                    //centerAlignedText.SpacingBefore = 10f; // Alt boşluk ekleyelim
                    //doc.Add(centerAlignedText);
                    //doc.Add(new Paragraph("\n"));

                    // Tabloyu sağa hizalayarak oluştur
                    PdfPTable table = new PdfPTable(2); // 2 sütunlu tablo oluştur
                    table.TotalWidth = 300f;
                    table.LockedWidth = true;

                    // Hücreleri sağa ve sola doğru ayarla
                    PdfPCell leftCell = new PdfPCell();
                    leftCell.HorizontalAlignment = Element.ALIGN_LEFT; // Sol hizalama

                    PdfPCell rightCell = new PdfPCell();
                    rightCell.HorizontalAlignment = Element.ALIGN_RIGHT; // Sağ hizalama

                    foreach (string studentId in studentIds)
                    {
                        string studentName = ent.Student.FirstOrDefault(s => s.student_id.ToString() == studentId)?.name;
                        string details = recordsForDate
                                    .Where(r => r.Cells["StudentIdColumn"].Value.ToString() == studentId && r.Cells["DetailsColumn"].Value != null)
                                    .Select(r => r.Cells["DetailsColumn"].Value.ToString())
                                    .FirstOrDefault() ?? string.Empty; // null ise boş string ver

                        if (studentName != null)
                        {
                            // Hücre içeriğini sağa ve sola doğru ekle
                            leftCell = new PdfPCell(new Phrase($"{studentName} ({studentId})", new iTextSharp.text.Font(baseFont, 8f, iTextSharp.text.Font.NORMAL, BaseColor.BLACK)));
                            leftCell.HorizontalAlignment = Element.ALIGN_CENTER; // Sol hizalama
                            table.AddCell(leftCell);

                            rightCell = new PdfPCell(new Phrase($"{details}", new iTextSharp.text.Font(baseFont, 8f, iTextSharp.text.Font.NORMAL, BaseColor.BLACK)));
                            rightCell.HorizontalAlignment = Element.ALIGN_CENTER; // Sağ hizalama
                            table.AddCell(rightCell);
                        }
                    }

                    // Tabloyu dokümana ekle
                    doc.Add(table);

                    // Yeni sayfaya geçme kontrolü
                    float currentY = writer.GetVerticalPosition(true);
                    if (currentY < 200)
                    {
                        doc.NewPage();
                    }
                }

                Paragraph rightAlignedText = new Paragraph("Acar Akademi Rehberlik Uygulaması, Acar Akademi", new iTextSharp.text.Font(baseFont, 10f, iTextSharp.text.Font.NORMAL, BaseColor.BLACK));
                rightAlignedText.Alignment = Element.ALIGN_RIGHT;
                rightAlignedText.SpacingAfter = 10f; // Alt boşluk ekleyelim
                rightAlignedText.SpacingBefore = 20f; // Alt boşluk ekleyelim
                doc.Add(rightAlignedText);
                // Yeni sayfa ekleme
                //doc.NewPage();
            }

            // Raporu kapat
            doc.Close();
        }
        private class PdfPageEvents : PdfPageEventHelper
        {
            private string teacherName;
            private BaseFont baseFont;
            private PdfContentByte cb;
            private PdfTemplate headerTemplate, footerTemplate;
            private iTextSharp.text.Image logoImage, watermarkImage;
            private DateTime printTime;

            public PdfPageEvents(string teacherName)
            {
                this.teacherName = teacherName;
                baseFont = BaseFont.CreateFont(@"C:\Windows\Fonts\arial.ttf", BaseFont.IDENTITY_H, BaseFont.EMBEDDED);

                // Logoyu ve filigranı yükleyin
                logoImage = ConvertBitmapToImage(Properties.Resources.logoAcarAkademi); // Bitmap'i iTextSharp Image'e dönüştür
                watermarkImage = ConvertBitmapToImage(Properties.Resources.wtrmrkAcar);

                logoImage.ScaleToFit(100, 100);
                watermarkImage.ScaleToFit(400, 400);
            }

            public iTextSharp.text.Image ConvertBitmapToImage(System.Drawing.Bitmap bitmap)
            {
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    bitmap.Save(memoryStream, System.Drawing.Imaging.ImageFormat.Png); // Bitmap'i MemoryStream'e kaydet
                    memoryStream.Position = 0; // Akışın başlangıcına geri dön
                    return iTextSharp.text.Image.GetInstance(memoryStream); // Akıştan Image nesnesini oluştur
                }
            }

            public override void OnStartPage(PdfWriter writer, Document document)
            {
                cb = writer.DirectContent;

                // Logo ekle (sadece ilk sayfada)
                if (writer.PageNumber == 1)
                {
                    logoImage.SetAbsolutePosition(40, document.PageSize.Height - 100);
                    cb.AddImage(logoImage);
                }

                // Tarih ve öğretmen adı ekle (her sayfada)
                cb.BeginText();
                cb.SetFontAndSize(baseFont, 10);
                cb.SetTextMatrix(document.PageSize.Width - 175, document.PageSize.Height - 50);
                cb.ShowText("Tarih: " + printTime.ToString("dd/MM/yyyy"));
                cb.SetTextMatrix(document.PageSize.Width - 175, document.PageSize.Height - 65);
                cb.ShowText("Rehber Öğretmen: " + teacherName);
                cb.EndText();
            }

            public override void OnEndPage(PdfWriter writer, Document document)
            {
                cb = writer.DirectContent;

                // Saydamlık ayarları
                PdfGState gState = new PdfGState
                {
                    FillOpacity = 0.5f, // Saydamlık değeri (0.0 tamamen şeffaf, 1.0 tamamen opak)
                    StrokeOpacity = 0.5f
                };
                cb.SaveState();
                cb.SetGState(gState);

                // Filigranı ortalayarak ve öne yerleştir
                float xPosition = (document.PageSize.Width - watermarkImage.ScaledWidth) / 2;
                float yPosition = (document.PageSize.Height - watermarkImage.ScaledHeight) / 2;
                watermarkImage.SetAbsolutePosition(xPosition, yPosition);

                // Filigranı ekle (sayfanın en üst katmanına)
                cb.AddImage(watermarkImage);
                cb.RestoreState();

                // Sayfa numarası ekle
                string text = "Sayfa " + writer.PageNumber + " / ";
                float len = baseFont.GetWidthPoint(text, 8);
                cb.BeginText();
                cb.SetFontAndSize(baseFont, 8);
                cb.SetTextMatrix(document.PageSize.Width / 2, document.PageSize.GetBottom(30));
                cb.ShowText(text);
                cb.EndText();

                cb.AddTemplate(footerTemplate, document.PageSize.Width / 2 + len, document.PageSize.GetBottom(30));
            }

            public override void OnOpenDocument(PdfWriter writer, Document document)
            {
                printTime = DateTime.Now.Date;
                cb = writer.DirectContent;
                footerTemplate = cb.CreateTemplate(50, 50); // footerTemplate burada başlatılıyor
            }

            public override void OnCloseDocument(PdfWriter writer, Document document)
            {
                footerTemplate.BeginText();
                footerTemplate.SetFontAndSize(baseFont, 8);
                footerTemplate.SetTextMatrix(0, 0);
                footerTemplate.ShowText("" + (writer.PageNumber));
                footerTemplate.EndText();
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
                    textBox.Font = new System.Drawing.Font("Segoe UI", 10);
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
                    label.Font = new System.Drawing.Font("Segoe UI", 10, FontStyle.Regular);
                }
                else if (c is ComboBox comboBox)
                {
                    comboBox.FlatStyle = FlatStyle.Flat;
                    comboBox.BackColor = Color.White;
                    comboBox.ForeColor = Color.Black;
                    comboBox.Font = new System.Drawing.Font("Segoe UI", 10);
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
                        axis.TitleFont = new System.Drawing.Font("Segoe UI", 10);
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

        private void btnOgrenciKatılımRaporuIndir_Click(object sender, EventArgs e)
        {
            // Seçili öğrencinin student_id'sini al
            string studentId = dgwOgrenciler.CurrentRow.Cells["StudentIdColumn"].Value.ToString();

            // Öğrenci detaylarını al
            var studentDetails = ent.Student.FirstOrDefault(s => s.student_id.ToString() == studentId);
            if (studentDetails == null)
            {
                MessageBox.Show("Öğrenci detayları bulunamadı.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            var teacherDetails = ent.Teacher.FirstOrDefault(t => t.teacher_id == studentDetails.teacher_id);
            if (teacherDetails == null)
            {
                MessageBox.Show("Öğretmen detayları bulunamadı.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Katılım bilgilerini al
            var attendanceRecords = ent.Attendance.Where(a => a.student_id.ToString() == studentId).ToList();

            // PDF dosyası oluşturma işlemleri
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "PDF Dosyaları|*.pdf";
            saveFileDialog.Title = "Öğrenci Katılım Raporunu Kaydet";
            saveFileDialog.FileName = $"{studentDetails.name}_Katilim_Raporu.pdf";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = saveFileDialog.FileName;

                // PDF oluşturma işlemleri
                Document doc = new Document();
                PdfWriter writer = PdfWriter.GetInstance(doc, new FileStream(filePath, FileMode.Create));

                var teacher = ent.Teacher.FirstOrDefault(t => t.teacher_id == this.teacherId);
                string teacherName = teacher?.name;
                PdfPageEvents pageEvents = new PdfPageEvents(teacherName);
                writer.PageEvent = pageEvents;
                doc.Open();
                doc.Add(new Paragraph("\n"));
                doc.Add(new Paragraph("\n"));
                doc.Add(new Paragraph("\n"));
               

                // Öğrenci detaylarını ve başlık ekleme
                BaseFont baseFont = BaseFont.CreateFont(@"C:\Windows\Fonts\arial.ttf", BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
                iTextSharp.text.Font titleFont = new iTextSharp.text.Font(baseFont, 18f, iTextSharp.text.Font.BOLD, BaseColor.BLACK);

                Paragraph title = new Paragraph($"Öğrenci Katılım Raporu - {studentDetails.name}", titleFont);
                title.Alignment = Element.ALIGN_CENTER;
                doc.Add(title);

                doc.Add(new Paragraph("\n"));

                // Öğrenci bilgilerini ekleyelim
                PdfPTable studentInfoTable = new PdfPTable(2);
                studentInfoTable.DefaultCell.Border = PdfPCell.NO_BORDER;

                // Student ID
                studentInfoTable.AddCell(new Phrase("Öğrenci Numarası:", new iTextSharp.text.Font(baseFont, 10f, iTextSharp.text.Font.BOLD)));
                studentInfoTable.AddCell(new Phrase(studentDetails.student_id.ToString(), new iTextSharp.text.Font(baseFont, 10f)));

                // Name
                studentInfoTable.AddCell(new Phrase("Adı Soyadı:", new iTextSharp.text.Font(baseFont, 10f, iTextSharp.text.Font.BOLD)));
                studentInfoTable.AddCell(new Phrase(studentDetails.name, new iTextSharp.text.Font(baseFont, 10f)));

                // Class
                studentInfoTable.AddCell(new Phrase("Sınıf:", new iTextSharp.text.Font(baseFont, 10f, iTextSharp.text.Font.BOLD)));
                studentInfoTable.AddCell(new Phrase(studentDetails.@class, new iTextSharp.text.Font(baseFont, 10f)));

                // Phone Number
                studentInfoTable.AddCell(new Phrase("Telefon Numarası:", new iTextSharp.text.Font(baseFont, 10f, iTextSharp.text.Font.BOLD)));
                studentInfoTable.AddCell(new Phrase(studentDetails.phoneNumber, new iTextSharp.text.Font(baseFont, 10f)));

                // School Name
                studentInfoTable.AddCell(new Phrase("Okul Adı:", new iTextSharp.text.Font(baseFont, 10f, iTextSharp.text.Font.BOLD)));
                studentInfoTable.AddCell(new Phrase(studentDetails.school, new iTextSharp.text.Font(baseFont, 10f)));

                // Parent 1 Name
                studentInfoTable.AddCell(new Phrase("1. Veli Adı:", new iTextSharp.text.Font(baseFont, 10f, iTextSharp.text.Font.BOLD)));
                studentInfoTable.AddCell(new Phrase(studentDetails.parent1Name, new iTextSharp.text.Font(baseFont, 10f)));

                // Parent 1 Phone Number
                studentInfoTable.AddCell(new Phrase("1. Veli Telefon Numarası:", new iTextSharp.text.Font(baseFont, 10f, iTextSharp.text.Font.BOLD)));
                studentInfoTable.AddCell(new Phrase(studentDetails.parent1PhoneNumber, new iTextSharp.text.Font(baseFont, 10f)));

                // Parent 2 Name
                studentInfoTable.AddCell(new Phrase("2. Veli Adı:", new iTextSharp.text.Font(baseFont, 10f, iTextSharp.text.Font.BOLD)));
                studentInfoTable.AddCell(new Phrase(studentDetails.parent2Name, new iTextSharp.text.Font(baseFont, 10f)));

                // Parent 2 Phone Number
                studentInfoTable.AddCell(new Phrase("2. Veli Telefon Numarası:", new iTextSharp.text.Font(baseFont, 10f, iTextSharp.text.Font.BOLD)));
                studentInfoTable.AddCell(new Phrase(studentDetails.parent2PhoneNumber, new iTextSharp.text.Font(baseFont, 10f)));

                // Teacher ID
                studentInfoTable.AddCell(new Phrase("Rehber Öğretmen Adı Soyadı:", new iTextSharp.text.Font(baseFont, 10f, iTextSharp.text.Font.BOLD)));
                studentInfoTable.AddCell(new Phrase(teacherDetails.name, new iTextSharp.text.Font(baseFont, 10f)));

                doc.Add(studentInfoTable);

                doc.Add(new Paragraph("\n"));

                // Katılım bilgilerini tablo olarak ekleyelim
                PdfPTable attendanceTable = new PdfPTable(2);
                attendanceTable.DefaultCell.Border = PdfPCell.NO_BORDER;

                attendanceTable.AddCell(new Phrase("Tarih", new iTextSharp.text.Font(baseFont, 10f, iTextSharp.text.Font.BOLD)));
                attendanceTable.AddCell(new Phrase("Gelmeme Sebebi", new iTextSharp.text.Font(baseFont, 10f, iTextSharp.text.Font.BOLD)));

                foreach (var record in attendanceRecords)
                {

                    string date = record.attendance_date.HasValue ? record.attendance_date.Value.ToString("dd MMMM yyyy") : string.Empty;
                    string details = record.attendance_details;

                    attendanceTable.AddCell(new Phrase(date, new iTextSharp.text.Font(baseFont, 10f)));
                    attendanceTable.AddCell(new Phrase(details, new iTextSharp.text.Font(baseFont, 10f)));
                }

                doc.Add(attendanceTable);

                // PDF'i kapat
                doc.Close();

                MessageBox.Show("Öğrenci katılım raporu başarıyla indirildi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnTumunuSil_Click(object sender, EventArgs e)
        {
            // Kullanıcıdan onay almak için bir mesaj kutusu gösterin
            DialogResult dialogResult = MessageBox.Show("Tüm yoklama kayıtlarını silmek istediğinizden emin misiniz?", "Emin misiniz?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            // Kullanıcı "Yes" seçeneğine tıkladıysa
            if (dialogResult == DialogResult.Yes)
            {
                try
                {
                    // Attendance tablosundaki tüm kayıtları alın
                    var allAttendanceRecords = ent.Attendance.ToList();

                    // Tüm kayıtları sil
                    ent.Attendance.RemoveRange(allAttendanceRecords);

                    // Değişiklikleri veritabanına kaydedin
                    ent.SaveChanges();

                    // Kullanıcıya başarı mesajı gösterin
                    MessageBox.Show("Tüm yoklama kayıtları başarıyla silindi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    // Hata mesajı gösterin
                    MessageBox.Show("Kayıtlar silinirken bir hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnGeriDon_Click(object sender, EventArgs e)
        {
            RehberlikOgretmeniAnaForm anaForm = new RehberlikOgretmeniAnaForm(teacherId);
            anaForm.Show();
            this.Hide();
        }

        private void btnSeciliKatilimSil_Click(object sender, EventArgs e)
        {
            // Check if a row is selected
            if (dgwKatilimRaporu.SelectedRows.Count > 0)
            {
                var selectedRow = dgwKatilimRaporu.SelectedRows[0];
                var studentId = Convert.ToInt32(selectedRow.Cells["StudentIdColumn"].Value);
                var attendanceDate = DateTime.Parse(selectedRow.Cells["DateColumn"].Value.ToString());

                // Ask for confirmation
                var confirmation = MessageBox.Show("Seçili katılım kaydını silmek istediğinizden emin misiniz?",
                                                   "Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (confirmation == DialogResult.Yes)
                {
                    // Find the attendance record in the database
                    var attendanceRecord = ent.Attendance.FirstOrDefault(a => a.student_id == studentId &&
                                                                               a.attendance_date == attendanceDate);

                    if (attendanceRecord != null)
                    {
                        // Remove the record from the database
                        ent.Attendance.Remove(attendanceRecord);
                        ent.SaveChanges();

                        // Refresh the DataGridView
                        LoadAttendanceByClass(cbxSiniflar.SelectedItem?.ToString());

                        MessageBox.Show("Katılım kaydı başarıyla silindi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Katılım kaydı bulunamadı.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Lütfen silmek için bir kayıt seçin.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgwKatilimRaporu_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (currentTeacher.role == 1)
            {
                if (e.RowIndex >= 0)
                {
                    DataGridViewRow row = dgwKatilimRaporu.Rows[e.RowIndex];

                    string date = row.Cells["DateColumn"].Value.ToString();
                    string studentId = row.Cells["StudentIdColumn"].Value.ToString();
                    string studentName = row.Cells["StudentNameColumn"].Value.ToString();
                    string details = row.Cells["DetailsColumn"].Value != null ? row.Cells["DetailsColumn"].Value.ToString() : string.Empty;

                    KatilimDuzenleForm katilimForm = new KatilimDuzenleForm(date, studentId, studentName, details);
                    katilimForm.ShowDialog();
                }
            }
        }
    }
}
