using iTextSharp.text.pdf;
using iTextSharp.text;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.IO;
using OfficeOpenXml.Style;
using OfficeOpenXml;
using LicenseContext = OfficeOpenXml.LicenseContext;
using System.Drawing.Drawing2D;
using Font = System.Drawing.Font;
using Rectangle = System.Drawing.Rectangle;

namespace AcarAkademiRehberlik
{
    public partial class YoneticiRaporlariForm : Form
    {
        private Dbo_acarEntities ent = new Dbo_acarEntities();
        private Dbo_acarakademirehberlikAppEntities ent2 = new Dbo_acarakademirehberlikAppEntities();
        private int teacherId;
        public YoneticiRaporlariForm(int id)
        {
            InitializeComponent();
            this.teacherId = id;
            ExcelPackage.LicenseContext = LicenseContext.Commercial;
        }
        private void YoneticiRaporlariForm_Load(object sender, EventArgs e)
        {
            LoadTeacherMeetingCounts();
            cbxOgretmenKatilimRaporuTarihAraligi.SelectedIndex = 0;
            LoadStudentMeetingCounts();
            ApplyModernStyle(this);
            StyleButton(btnGeriDon);
            StyleButton(btnGeriDon1);
            StyleButton(btnRehberOgretmenFaaliyetRaporuIndır);
            StyleButton(btnTumOgrencilerGorusmeSayilariIndir);
            cbxDevamsizlik.SelectedIndex = cbxDevamsizlik.Items.IndexOf("Tüm Zamanlar");
            LoadAttendanceRecords();
            StyleButton(btnDevamsizlikIndir);
            StyleDataGridView(dgwDevamsizlik);
            StyleButton(btnGeriDon2);
            cbxSıralamaTuru.SelectedIndex = cbxSıralamaTuru.Items.IndexOf("Önce en yüksek");

        }

        private void btnGeriDon_Click(object sender, EventArgs e)
        {
            RehberlikOgretmeniAnaForm rehberlikOgretmeniAnaForm = new RehberlikOgretmeniAnaForm(teacherId);
            rehberlikOgretmeniAnaForm.Show();
            this.Hide();
        }

        private void btnGeriDon1_Click(object sender, EventArgs e)
        {
            RehberlikOgretmeniAnaForm rehberlikOgretmeniAnaForm = new RehberlikOgretmeniAnaForm(teacherId);
            rehberlikOgretmeniAnaForm.Show();
            this.Hide();
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
        private void LoadTeacherMeetingCounts()
        {
            // ComboBox'tan seçilen tarihi al
            string selectedPeriod = cbxOgretmenKatilimRaporuTarihAraligi.SelectedItem?.ToString();
            var dateRange = GetDateRange(selectedPeriod);

            // Tüm öğretmenlerin gerçekleştirdiği görüşme sayılarını getir
            var teacherMeetings = ent.Meeting
                .Where(m => dateRange.Start <= m.meeting_date && m.meeting_date <= dateRange.End)
                .GroupBy(m => new { m.teacher_id, m.meetingType })
                .Select(g => new
                {
                    TeacherId = g.Key.teacher_id,
                    MeetingType = g.Key.meetingType,
                    MeetingCount = g.Count()
                })
                .ToList();

            // Grafiği temizle
            chrtOgretmenGorusmeSayilari.Series.Clear();

            // Öğrenci Görüşmeleri Serisi
            var ogrenciSeries = new Series("Öğrenci Görüşmeleri")
            {
                ChartType = SeriesChartType.Column
            };
            chrtOgretmenGorusmeSayilari.Series.Add(ogrenciSeries);

            // Veli Görüşmeleri Serisi
            var veliSeries = new Series("Veli Görüşmeleri")
            {
                ChartType = SeriesChartType.Column
            };
            chrtOgretmenGorusmeSayilari.Series.Add(veliSeries);

            // Toplam Görüşmeler Serisi
            var allMeetingsSeries = new Series("Toplam Görüşme Sayısı")
            {
                ChartType = SeriesChartType.Column
            };
            chrtOgretmenGorusmeSayilari.Series.Add(allMeetingsSeries);

            // Öğretmenleri al
            var teachers = ent.Teacher.ToList();

            foreach (var teacher in teachers)
            {
                string teacherName = teacher.name;

                var teacherMeetingData = teacherMeetings.Where(tm => tm.TeacherId == teacher.teacher_id).ToList();

                // Öğrenci Görüşmeleri
                var ogrenciMeetingCount = teacherMeetingData.Where(tm => tm.MeetingType == "Öğrenci Görüşmesi").Sum(tm => tm.MeetingCount);
                if (ogrenciMeetingCount > 0)
                {
                    ogrenciSeries.Points.AddXY(teacherName, ogrenciMeetingCount);
                }

                // Veli Görüşmeleri
                var veliMeetingCount = teacherMeetingData.Where(tm => tm.MeetingType == "Veli Görüşmesi").Sum(tm => tm.MeetingCount);
                if (veliMeetingCount > 0)
                {
                    veliSeries.Points.AddXY(teacherName, veliMeetingCount);
                }

                // Toplam Görüşme Sayısı
                var totalMeetingCount = teacherMeetingData.Sum(tm => tm.MeetingCount);
                if (totalMeetingCount > 0)
                {
                    allMeetingsSeries.Points.AddXY(teacherName, totalMeetingCount);
                }
            }
            
            // Grafiği ayarla
            chrtOgretmenGorusmeSayilari.ChartAreas[0].AxisX.LabelStyle.Angle = -45;
            chrtOgretmenGorusmeSayilari.ChartAreas[0].AxisX.Interval = 1;
        }

        // Tarih aralığını belirleyen fonksiyon
        private (DateTime Start, DateTime End) GetDateRange(string selectedPeriod)
        {
            DateTime startDate;
            DateTime endDate = DateTime.Now;

            switch (selectedPeriod)
            {
                case "Tüm Zamanlar":
                    startDate = DateTime.MinValue;
                    break;
                case "Son 12 Ay":
                    startDate = DateTime.Now.AddMonths(-12);
                    break;
                case "Son 6 Ay":
                    startDate = DateTime.Now.AddMonths(-6);
                    break;
                case "Son 3 Ay":
                    startDate = DateTime.Now.AddMonths(-3);
                    break;
                case "Bu Ay":
                    startDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
                    break;
                default:
                    startDate = DateTime.MinValue;
                    break;
            }

            return (startDate, endDate);
        }
        private void LoadAttendanceRecords()
        {
            DateTime startDate = DateTime.Today;
            switch (cbxDevamsizlik.SelectedItem?.ToString())
            {
                case "30 Gün":
                    startDate = DateTime.Today.AddDays(-30);
                    break;
                case "3 Ay":
                    startDate = DateTime.Today.AddMonths(-3);
                    break;
                case "6 Ay":
                    startDate = DateTime.Today.AddMonths(-6);
                    break;
                case "1 Yıl":
                    startDate = DateTime.Today.AddYears(-1);
                    break;
                case "Tüm Zamanlar":
                    startDate = DateTime.MinValue;
                    break;
                default:
                    startDate = DateTime.MinValue; // Varsayılan olarak tüm zamanlar
                    break;
            }

            var attendanceRecords = from a in ent2.Attendance
                                    where a.attendance_date >= startDate
                                    join s in ent2.Student on a.student_id equals s.student_id
                                    join t in ent2.Teacher on s.teacher_id equals t.teacher_id
                                    group new { a, s, t } by new { s.student_id, StudentName = s.name, TeacherName = t.name } into g
                                    select new
                                    {
                                        StudentId = g.Key.student_id,
                                        StudentName = g.Key.StudentName,
                                        TeacherName = g.Key.TeacherName,
                                        AbsenceCount = g.Count()
                                    };

            var sortOrder = cbxSıralamaTuru.SelectedItem?.ToString();
            if (sortOrder == "Önce en düşük")
            {
                attendanceRecords = attendanceRecords.OrderBy(r => r.AbsenceCount);
            }
            else if (sortOrder == "Önce en yüksek")
            {
                attendanceRecords = attendanceRecords.OrderByDescending(r => r.AbsenceCount);
            }

            dgwDevamsizlik.DataSource = attendanceRecords.ToList();
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
                        
                    }
                }
                else
                {
                    ApplyModernStyle(c);
                }
            }
        }
        private void cbxOgretmenKatilimRaporuTarihAraligi_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadTeacherMeetingCounts();
        }
        private void CreatePdfReport(string filePath)
        {
            // Create a BaseFont that supports Turkish characters
            BaseFont baseFont = BaseFont.CreateFont(@"C:\Windows\Fonts\arial.ttf", BaseFont.IDENTITY_H, BaseFont.EMBEDDED);

            // Define fonts for different uses
            iTextSharp.text.Font titleFont = new iTextSharp.text.Font(baseFont, 18f, iTextSharp.text.Font.NORMAL, BaseColor.BLACK);
            iTextSharp.text.Font headerFont = new iTextSharp.text.Font(baseFont, 12f, iTextSharp.text.Font.BOLD, BaseColor.BLACK);
            iTextSharp.text.Font regularFont = new iTextSharp.text.Font(baseFont, 12f, iTextSharp.text.Font.NORMAL, BaseColor.BLACK);

            Document doc = new Document();
            PdfWriter writer = PdfWriter.GetInstance(doc, new FileStream(filePath, FileMode.Create));

            var currentTeacher = ent.Teacher.FirstOrDefault(t => t.teacher_id == this.teacherId);
            string currentTeacherName = currentTeacher?.name;
            PdfPageEvents pageEvents = new PdfPageEvents(currentTeacherName);
            writer.PageEvent = pageEvents;
            doc.Open();

            // Add language attribute for Turkish
            doc.AddLanguage("tr-TR");

            // Başlık
            doc.Add(new Paragraph("\n"));
            doc.Add(new Paragraph("\n"));
            doc.Add(new Paragraph("\n"));



            doc.Add(new Paragraph("Rehber Öğretmen Görüşme Raporu", titleFont));
            doc.Add(new Paragraph("\n"));
            // Tablo Başlığı
            PdfPTable table = new PdfPTable(4);
            table.AddCell(new PdfPCell(new Phrase("Öğretmen Adı", headerFont)) { BackgroundColor = BaseColor.WHITE });
            table.AddCell(new PdfPCell(new Phrase("Öğrenci Görüşmesi", headerFont)) { BackgroundColor = BaseColor.WHITE});
            table.AddCell(new PdfPCell(new Phrase("Veli Görüşmesi", headerFont)) { BackgroundColor = BaseColor.WHITE });
            table.AddCell(new PdfPCell(new Phrase("Toplam Görüşme", headerFont)) { BackgroundColor = BaseColor.WHITE });

            // Öğretmen Verilerini Al
            var teacherMeetings = ent.Meeting
                .GroupBy(m => new { m.teacher_id, m.meetingType })
                .Select(g => new
                {
                    TeacherId = g.Key.teacher_id,
                    MeetingType = g.Key.meetingType,
                    MeetingCount = g.Count()
                })
                .ToList();

            var teachers = ent.Teacher.ToList();

            foreach (var teacher in teachers)
            {
                string teacherName = teacher.name;
                var teacherMeetingData = teacherMeetings.Where(tm => tm.TeacherId == teacher.teacher_id).ToList();

                int studentMeetingsCount = teacherMeetingData.Where(tm => tm.MeetingType == "Öğrenci Görüşmesi").Sum(tm => tm.MeetingCount);
                int veliMeetingsCount = teacherMeetingData.Where(tm => tm.MeetingType == "Veli Görüşmesi").Sum(tm => tm.MeetingCount);
                int totalMeetingsCount = studentMeetingsCount + veliMeetingsCount;

                table.AddCell(new PdfPCell(new Phrase(teacherName, regularFont)));
                table.AddCell(new PdfPCell(new Phrase(studentMeetingsCount.ToString(), regularFont)));
                table.AddCell(new PdfPCell(new Phrase(veliMeetingsCount.ToString(), regularFont)));
                table.AddCell(new PdfPCell(new Phrase(totalMeetingsCount.ToString(), regularFont)));
            }

            // Toplam Görüşme Sayısını Hesapla
            int totalStudentMeetings = teacherMeetings.Where(tm => tm.MeetingType == "Öğrenci Görüşmesi").Sum(tm => tm.MeetingCount);
            int totalVeliMeetings = teacherMeetings.Where(tm => tm.MeetingType == "Veli Görüşmesi").Sum(tm => tm.MeetingCount);
            int grandTotalMeetings = totalStudentMeetings + totalVeliMeetings;

            table.AddCell(new PdfPCell(new Phrase("Toplam Görüşme Sayısı", headerFont)) { Colspan = 3, BackgroundColor = BaseColor.WHITE });
            table.AddCell(new PdfPCell(new Phrase(grandTotalMeetings.ToString(), regularFont)));

            doc.Add(table);
            doc.Close();
        }

        private void btnRehberOgretmenFaaliyetRaporuIndır_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "PDF Files|*.pdf",
                Title = "PDF Raporu Kaydet"
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = saveFileDialog.FileName;
                CreatePdfReport(filePath);
                MessageBox.Show($"Rapor başarıyla kaydedildi: {filePath}", "Rapor Kaydedildi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void LoadStudentMeetingCounts()
        {
            var studentMeetingCounts = ent.Student
                .Select(s => new
                {
                    s.student_id,
                    s.name,
                    VeliGorusmesi = ent.Meeting.Count(m => m.student_id == s.student_id && m.meetingType == "Veli Görüşmesi"),
                    OgrenciGorusmesi = ent.Meeting.Count(m => m.student_id == s.student_id && m.meetingType == "Öğrenci Görüşmesi"),
                    Toplam = ent.Meeting.Count(m => m.student_id == s.student_id)
                })
                .ToList();

            chartTumOgrenciler.Series.Clear();

            var seriesVeliGorusmesi = new Series("Veli Görüşmesi");
            var seriesOgrenciGorusmesi = new Series("Öğrenci Görüşmesi");
            var seriesToplam = new Series("Toplam");

            foreach (var student in studentMeetingCounts)
            {
                seriesVeliGorusmesi.Points.AddXY(student.name, student.VeliGorusmesi);
                seriesOgrenciGorusmesi.Points.AddXY(student.name, student.OgrenciGorusmesi);
                seriesToplam.Points.AddXY(student.name, student.Toplam);
            }

            chartTumOgrenciler.Series.Add(seriesVeliGorusmesi);
            chartTumOgrenciler.Series.Add(seriesOgrenciGorusmesi);
            chartTumOgrenciler.Series.Add(seriesToplam);

            chartTumOgrenciler.ChartAreas[0].AxisX.Interval = 1;
            chartTumOgrenciler.Legends[0].Docking = Docking.Top;
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

                if (writer.PageNumber == 1)
                {
                    logoImage.SetAbsolutePosition(40, document.PageSize.Height - 100);
                    cb.AddImage(logoImage);
                

                

                // Tarih ve öğretmen adı ekle (her sayfada)
                cb.BeginText();
                cb.SetFontAndSize(baseFont, 10);
                cb.SetTextMatrix(document.PageSize.Width - 175, document.PageSize.Height - 50);
                cb.ShowText("Tarih: " + printTime.ToString("dd/MM/yyyy"));
                cb.SetTextMatrix(document.PageSize.Width - 175, document.PageSize.Height - 65);
                cb.ShowText("Rehber Öğretmen: " + teacherName);
                cb.EndText();
                }
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

        private void CreateStudentMeetingCountsPdf(string filePath)
        {
            var studentMeetingCounts = ent.Student
                .Select(s => new
                {
                    s.student_id,
                    s.name,
                    VeliGorusmesi = ent.Meeting.Count(m => m.student_id == s.student_id && m.meetingType == "Veli Görüşmesi"),
                    OgrenciGorusmesi = ent.Meeting.Count(m => m.student_id == s.student_id && m.meetingType == "Öğrenci Görüşmesi"),
                    Toplam = ent.Meeting.Count(m => m.student_id == s.student_id)
                })
                .ToList();

            // Create a base font that supports Turkish characters
            BaseFont baseFont = BaseFont.CreateFont(@"C:\Windows\Fonts\arial.ttf", BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
            iTextSharp.text.Font titleFont = new iTextSharp.text.Font(baseFont, 18f, iTextSharp.text.Font.BOLD, BaseColor.BLACK);
            iTextSharp.text.Font boldFont = new iTextSharp.text.Font(baseFont, 10f, iTextSharp.text.Font.BOLD, BaseColor.WHITE);
            iTextSharp.text.Font regularFont = new iTextSharp.text.Font(baseFont, 10f, iTextSharp.text.Font.NORMAL, BaseColor.BLACK);

            Document doc = new Document();
            PdfWriter writer = PdfWriter.GetInstance(doc, new FileStream(filePath, FileMode.Create));

            var teacher = ent.Teacher.FirstOrDefault(t => t.teacher_id == this.teacherId);
            string teacherName = teacher?.name;
            PdfPageEvents pageEvents = new PdfPageEvents(teacherName);
            writer.PageEvent = pageEvents;

            doc.Open();

            Paragraph title = new Paragraph("Öğrencilerin Görüşme Sayıları", titleFont);
            title.Alignment = Element.ALIGN_CENTER;
            doc.Add(new Paragraph("\n"));
            doc.Add(new Paragraph("\n"));
            doc.Add(new Paragraph("\n"));
            doc.Add(new Paragraph("\n"));
            doc.Add(title);

            PdfPTable table = new PdfPTable(4);
            table.WidthPercentage = 100;
            table.SetWidths(new float[] { 2, 2, 2, 2 });

            // Add table headers
            AddCell(table, "Öğrenci Adı", boldFont, BaseColor.GRAY);
            AddCell(table, "Veli Görüşmesi", boldFont, BaseColor.GRAY);
            AddCell(table, "Öğrenci Görüşmesi", boldFont, BaseColor.GRAY);
            AddCell(table, "Toplam Görüşme Sayısı", boldFont, BaseColor.GRAY);

            // Add student data
            foreach (var student in studentMeetingCounts)
            {
                AddCell(table, student.name, regularFont, BaseColor.WHITE);
                AddCell(table, student.VeliGorusmesi.ToString(), regularFont, BaseColor.WHITE);
                AddCell(table, student.OgrenciGorusmesi.ToString(), regularFont, BaseColor.WHITE);
                AddCell(table, student.Toplam.ToString(), regularFont, BaseColor.WHITE);
            }
            doc.Add(new Paragraph("\n"));
            doc.Add(new Paragraph("\n"));
            doc.Add(new Paragraph("\n"));
            doc.Add(table);

            doc.Close();
        }

        private void AddCell(PdfPTable table, string text, iTextSharp.text.Font font, BaseColor backgroundColor)
        {
            PdfPCell cell = new PdfPCell(new Phrase(text, font));
            cell.BackgroundColor = backgroundColor;
            table.AddCell(cell);
        }



        private void CreateStudentMeetingCountsExcel(string filePath)
        {
            var studentMeetingCounts = ent.Student
                .Select(s => new
                {
                    s.student_id,
                    s.name,
                    VeliGorusmesi = ent.Meeting.Count(m => m.student_id == s.student_id && m.meetingType == "Veli Görüşmesi"),
                    OgrenciGorusmesi = ent.Meeting.Count(m => m.student_id == s.student_id && m.meetingType == "Öğrenci Görüşmesi"),
                    Toplam = ent.Meeting.Count(m => m.student_id == s.student_id)
                })
                .ToList();

            using (ExcelPackage package = new ExcelPackage())
            {
                ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("Görüşme Sayıları");

                worksheet.Cells[1, 1].Value = "Öğrenci Adı";
                worksheet.Cells[1, 2].Value = "Veli Görüşmesi";
                worksheet.Cells[1, 3].Value = "Öğrenci Görüşmesi";
                worksheet.Cells[1, 4].Value = "Toplam Görüşme Sayısı";

                using (var range = worksheet.Cells[1, 1, 1, 4])
                {
                    range.Style.Font.Bold = true;
                    range.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    range.Style.Fill.BackgroundColor.SetColor(Color.LightGray);
                    range.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                }

                int row = 2;
                foreach (var student in studentMeetingCounts)
                {
                    worksheet.Cells[row, 1].Value = student.name;
                    worksheet.Cells[row, 2].Value = student.VeliGorusmesi;
                    worksheet.Cells[row, 3].Value = student.OgrenciGorusmesi;
                    worksheet.Cells[row, 4].Value = student.Toplam;
                    row++;
                }

                worksheet.Cells.AutoFitColumns();
                FileInfo fileInfo = new FileInfo(filePath);
                package.SaveAs(fileInfo);
            }
        }

        private void btnTumOgrencilerGorusmeSayilariIndir_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "PDF Files|*.pdf|Excel Files|*.xlsx",
                Title = "Öğrencilerin Görüşme Sayılarını Kaydet"
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = saveFileDialog.FileName;
                string extension = Path.GetExtension(filePath).ToLower();

                try
                {
                    if (extension == ".pdf")
                    {
                        CreateStudentMeetingCountsPdf(filePath);
                    }
                    else if (extension == ".xlsx")
                    {
                        CreateStudentMeetingCountsExcel(filePath);
                    }
                    MessageBox.Show($"Rapor başarıyla kaydedildi: {filePath}", "Rapor Kaydedildi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Bir hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void lblOgrenciAra_Click(object sender, EventArgs e)
        {
            if (int.TryParse(tbxOgrenciNumarasi.Text, out int studentId))
            {
                // Öğrencinin adını ve soyadını al
                var student = ent.Student.FirstOrDefault(s => s.student_id == studentId);
                if (student != null)
                {
                    lblOgrenciAdSoyad.Text = student.name;

                    // Öğrenciye ait toplam görüşme sayısını al
                    int toplamGorusmeSayisi = ent.Meeting.Count(m => m.student_id == studentId);

                    // Veli Görüşmesi olan görüşme sayısını al
                    int veliGorusmesiSayisi = ent.Meeting.Count(m => m.student_id == studentId && m.meetingType == "Veli Görüşmesi");

                    // Öğrenci Görüşmesi olan görüşme sayısını al
                    int ogrenciGorusmesiSayisi = ent.Meeting.Count(m => m.student_id == studentId && m.meetingType == "Öğrenci Görüşmesi");

                    // Sonuçları etiketlerde göster
                    lblGerceklestirilenGorusmeSayisiOgrenci.Text = toplamGorusmeSayisi.ToString();
                    lblVeliGorusmeSayisi.Text = veliGorusmesiSayisi.ToString();
                    lblOgrenciGorusmeSayisi.Text = ogrenciGorusmesiSayisi.ToString();
                }
                else
                {
                    MessageBox.Show("Girilen öğrenci numarasına ait bir kayıt bulunamadı.", "Öğrenci Bulunamadı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Lütfen geçerli bir öğrenci numarası giriniz.", "Geçersiz Giriş", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void lblAra_Click(object sender, EventArgs e)
        {
            if (int.TryParse(tbxRehberOgretmenNumarasi.Text, out int teacherId))
            {
                // Öğretmenin adını al
                var teacher = ent.Teacher.FirstOrDefault(t => t.teacher_id == teacherId);
                if (teacher != null)
                {
                    

                    // Öğretmenin toplam görüşme sayısını göster
                    ShowTeacherMeetingCounts(teacherId);
                }
                else
                {
                    MessageBox.Show("Girilen öğretmen numarasına ait bir kayıt bulunamadı.", "Öğretmen Bulunamadı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Lütfen geçerli bir öğretmen numarası giriniz.", "Geçersiz Giriş", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void ShowTeacherMeetingCounts(int teacherId)
        {
            // Öğretmenin toplam görüşme sayısını al
            int toplamGorusmeSayisi = ent.Meeting.Count(m => m.teacher_id == teacherId);

            // Sonuçları etiketlerde göster
            lblGerceklestirilenGorusmeSayisiOgretmen.Text = toplamGorusmeSayisi.ToString();
        }

        private void tbxOgrenciNumarasi_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true; // Tuşun işlenmesini durdur
            }
        }

        private void tbxRehberOgretmenNumarasi_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true; // Tuşun işlenmesini durdur
            }
        }

        private void btnDevamsizlikIndir_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "PDF Dosyası|*.pdf";
            saveFileDialog.Title = "Devamsızlık Raporunu Kaydet";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    using (FileStream stream = new FileStream(saveFileDialog.FileName, FileMode.Create))
                    {
                        Document pdfDoc = new Document(PageSize.A4, 20f, 20f, 20f, 20f);
                        PdfWriter writer = PdfWriter.GetInstance(pdfDoc, stream);

                        var currentTeacher = ent.Teacher.FirstOrDefault(t => t.teacher_id == this.teacherId);
                        string currentTeacherName = currentTeacher?.name;
                        PdfPageEvents pageEvents = new PdfPageEvents(currentTeacherName);
                        writer.PageEvent = pageEvents;

                        pdfDoc.Open();

                        // Arial fontunu yükle
                        string arialFontPath = @"C:\Windows\Fonts\arial.ttf";
                        BaseFont baseFont = BaseFont.CreateFont(arialFontPath, BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
                        iTextSharp.text.Font titleFont = new iTextSharp.text.Font(baseFont, 17f, iTextSharp.text.Font.NORMAL, BaseColor.BLACK);
                        iTextSharp.text.Font headerFont = new iTextSharp.text.Font(baseFont, 10f, iTextSharp.text.Font.BOLD, BaseColor.BLACK);
                        iTextSharp.text.Font cellFont = new iTextSharp.text.Font(baseFont, 10f, iTextSharp.text.Font.NORMAL, BaseColor.BLACK);

                        pdfDoc.Add(new Paragraph("\n"));
                        pdfDoc.Add(new Paragraph("\n"));
                        pdfDoc.Add(new Paragraph("\n"));
                        Paragraph title = new Paragraph("Devamsızlık Raporu", titleFont)
                        {
                            Alignment = Element.ALIGN_CENTER
                        };
                        pdfDoc.Add(title);
                        pdfDoc.Add(new Paragraph("\n")); // Boşluk ekle

                        // PDF tablosunu oluştur
                        PdfPTable pdfTable = new PdfPTable(dgwDevamsizlik.Columns.Count);
                        pdfTable.WidthPercentage = 100;

                        // Sütun başlıkları ekle
                        foreach (DataGridViewColumn column in dgwDevamsizlik.Columns)
                        {
                            PdfPCell cell = new PdfPCell(new Phrase(column.HeaderText, headerFont))
                            {
                                BackgroundColor = BaseColor.WHITE,
                                HorizontalAlignment = Element.ALIGN_CENTER,
                                VerticalAlignment = Element.ALIGN_MIDDLE
                            };
                            pdfTable.AddCell(cell);
                        }

                        // Satırları ekle
                        foreach (DataGridViewRow row in dgwDevamsizlik.Rows)
                        {
                            foreach (DataGridViewCell cell in row.Cells)
                            {
                                PdfPCell pdfCell = new PdfPCell(new Phrase(cell.Value?.ToString(), cellFont))
                                {
                                    HorizontalAlignment = Element.ALIGN_CENTER,
                                    VerticalAlignment = Element.ALIGN_MIDDLE
                                };
                                pdfTable.AddCell(pdfCell);
                            }
                        }

                        pdfDoc.Add(pdfTable);
                        pdfDoc.Close();
                        stream.Close();

                        // Başarı mesajı
                        MessageBox.Show("Devamsızlık raporu başarıyla PDF olarak kaydedildi.", "Başarı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    // Hata mesajı
                    MessageBox.Show("Bir hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void cbxSıralamaTuru_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadAttendanceRecords();
        }

        private void cbxDevamsizlik_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadAttendanceRecords();
        }

        private void btnGeriDon2_Click(object sender, EventArgs e)
        {
            RehberlikOgretmeniAnaForm rehberlikOgretmeniAnaForm = new RehberlikOgretmeniAnaForm(teacherId);
            rehberlikOgretmeniAnaForm.Show();
            this.Hide();
        }
    }
}
