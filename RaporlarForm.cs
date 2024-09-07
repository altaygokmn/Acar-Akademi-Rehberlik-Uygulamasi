using DocumentFormat.OpenXml.Bibliography;
using iTextSharp.text;
using iTextSharp.text.pdf;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using static AcarAkademiRehberlik.KatilimBilgileriForm;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Font = System.Drawing.Font;
using LicenseContext = OfficeOpenXml.LicenseContext;
using Rectangle = System.Drawing.Rectangle;

namespace AcarAkademiRehberlik
{
    public partial class RaporlarForm : Form
    {
        private Dbo_acarEntities ent = new Dbo_acarEntities();
        private int teacherId;
        
        public RaporlarForm(int id)
        {
            InitializeComponent();
            this.teacherId = id;
            ExcelPackage.LicenseContext = LicenseContext.Commercial;

        }

        private void RaporlarForm_Load(object sender, EventArgs e)
        {
            
            cbxKaynakAlan.SelectedIndex = 0;
            cbxKaynakDers.SelectedIndex = 0;
            cbxKaynakTuru.SelectedIndex = 0;
            LoadMeetings();
            LoadBooks();
            LoadStudentMeetingCounts();
            OgretmenGorusmeSayisiGoster();
            LoadMonthlyMeetingCounts();
            DateTime today = DateTime.Today;
            DateTime oneMonthAgo = today.AddMonths(-1);

            dtpGorusmeDetayBaslangicTarihi.Value = oneMonthAgo;
            dtpGorusmeDetayBitisTarihi.Value = today;
            StyleDataGridView(dgwGorusmeDetaylari);
            StyleDataGridView(dgwKaynaklar);
            StyleButton(btnGeriDon);
            StyleButton(btnGeriDon2);
            StyleButton(btnGeriDon3);
            StyleButton(btnGeriDon4);
            StyleButton(btnGorusmeDetaylariTumunuGoster);
            StyleButton(btnGorusmeRaporuIndir);
            StyleButton(btnKaynakRaporuIndir);
            StyleButton(btnOgrenciKatilimRaporuIndir);
            //StyleButton(btnOgrenciNumarasiYapistir);
            StyleButton(btnOgretmenKatilimRaporuIndir);
            ApplyModernStyle(this);
            ApplyModernStyle(chartOgretmenGorusmeleri);
            ApplyModernStyle(chrtOgrenciGorusmeSayilari);


        }
        public void ApplyModernStyle(Control control)
        {
            foreach (Control c in control.Controls)
            {
                if (c is System.Windows.Forms.TextBox textBox)
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
                else if (c is System.Windows.Forms.ComboBox comboBox)
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
        public static void StyleButton(System.Windows.Forms.Button btn)
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
            RehberlikOgretmeniAnaForm rehberlikOgretmeniAnaForm = new RehberlikOgretmeniAnaForm(teacherId);
            rehberlikOgretmeniAnaForm.Show();
            this.Hide();
        }
        private void LoadStudentMeetingCounts()
        {
            // Öğretmenin öğrencilerinin görüşme sayılarını getir
            var studentMeetings = ent.Student
                .Where(s => s.teacher_id == teacherId)
                .Join(ent.Meeting,
                    student => student.student_id,
                    meeting => meeting.student_id,
                    (student, meeting) => new { student, meeting })
                .GroupBy(x => x.student.student_id)
                .Select(g => new
                {
                    StudentName = g.FirstOrDefault().student.name,
                    MeetingCount = g.Count()
                })
                .ToList();

            // Grafiği temizle ve yeni verilerle doldur
            chrtOgrenciGorusmeSayilari.Series.Clear();
            var series = new Series("Görüşme Sayısı")
            {
                ChartType = SeriesChartType.Column
            };
            chrtOgrenciGorusmeSayilari.Series.Add(series);

            foreach (var studentMeeting in studentMeetings)
            {
                series.Points.AddXY(studentMeeting.StudentName, studentMeeting.MeetingCount);
            }

            chrtOgrenciGorusmeSayilari.ChartAreas[0].AxisX.LabelStyle.Angle = -45; // X ekseni etiketlerini eğ
            chrtOgrenciGorusmeSayilari.ChartAreas[0].AxisX.Interval = 1; // X ekseni aralığını ayarla
        }
        private void LoadMeetings()
        {
            var meetings = ent.Meeting
                              .Where(m => m.teacher_id == teacherId)
                              .OrderByDescending(m => m.meeting_date)
                              .Select(m => new
                              {
                                  // m.meeting_id,
                                  m.student_id,
                                  PerformerName = m.meetingType == "Veli Görüşmesi"
                                                  ? ent.Student
                                                       .Where(s => s.student_id == m.student_id)
                                                       .Select(s => s.name + " (" + m.performerName + ")")
                                                       .FirstOrDefault()
                                                  : m.performerName,
                                  m.meetingType,
                                  m.meeting_date,
                                  m.meetingExplanation,
                                  // m.meetingSubject,
                                  // m.meetingPlanning,
                                  // m.meetingNotes
                              })
                              .ToList();

            dgwGorusmeDetaylari.DataSource = meetings;
        }


        private void LoadMonthlyMeetingCounts()
        {
            var meetings = ent.Meeting
                      .Where(m => m.teacher_id == teacherId)
                      .ToList();

            // Aylara göre görüşme sayılarını hesapla
            var monthlyMeetingCounts = meetings
                .GroupBy(m => new { m.meeting_date?.Year, m.meeting_date?.Month })
                .Select(g => new
                {
                    Year = g.Key.Year,
                    Month = g.Key.Month,
                    StudentMeetingCount = g.Count(m => m.meetingType == "Öğrenci Görüşmesi"),
                    ParentMeetingCount = g.Count(m => m.meetingType == "Veli Görüşmesi"),
                    TotalMeetingCount = g.Count()
                })
                .OrderBy(g => g.Year)
                .ThenBy(g => g.Month)
                .ToList();

            // Grafiği temizle ve yeni verilerle doldur
            chartOgretmenGorusmeleri.Series.Clear();

            var studentSeries = new Series("Öğrenci Görüşmesi")
            {
                ChartType = SeriesChartType.Line
            };
            var parentSeries = new Series("Veli Görüşmesi")
            {
                ChartType = SeriesChartType.Line
            };
            var totalSeries = new Series("Görüşme")
            {
                ChartType = SeriesChartType.Line
            };

            chartOgretmenGorusmeleri.Series.Add(studentSeries);
            chartOgretmenGorusmeleri.Series.Add(parentSeries);
            chartOgretmenGorusmeleri.Series.Add(totalSeries);

            // Aylara göre verileri grafiğe ekle
            foreach (var item in monthlyMeetingCounts)
            {
                string monthName = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName((int)item.Month);
                string label = $"{monthName} {item.Year}";

                studentSeries.Points.AddXY(label, item.StudentMeetingCount);
                parentSeries.Points.AddXY(label, item.ParentMeetingCount);
                totalSeries.Points.AddXY(label, item.TotalMeetingCount);
            }

            // Grafiği güncelle
            chartOgretmenGorusmeleri.ChartAreas[0].AxisX.Interval = 1; // X ekseni aralığını ayarla
            chartOgretmenGorusmeleri.ChartAreas[0].AxisX.LabelStyle.Angle = -45; // X ekseni etiketlerini eğ

            // Grafiği tekrar çiz
            chartOgretmenGorusmeleri.Invalidate();
        }

        private void btnGeriDon2_Click(object sender, EventArgs e)
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
        private void OgretmenGorusmeSayisiGoster()
        {
            var meetingCount = ent.Meeting
               .Where(m => m.teacher_id == teacherId)
               .Count();

            lblGerceklestirilenGorusmeSayisiOgretmen.Text = $"Toplam Görüşme Sayısı: {meetingCount}";
        }
        private void ApplyFilters()
        {
            var filteredBooks = ent.Book.AsQueryable();

            // ComboBox'lardan seçili öğeleri alın
            string selectedBookClass = cbxKaynakDers.SelectedItem?.ToString();
            string selectedExamArea = cbxKaynakAlan.SelectedItem?.ToString();
            string selectedBookType = cbxKaynakTuru.SelectedItem?.ToString();

            // "Tümünü Göster" seçeneği seçilmişse filtreleme yapma
            if (selectedBookClass != "Tümünü Göster")
            {
                filteredBooks = filteredBooks.Where(b => b.bookClass == selectedBookClass);
            }

            if (selectedExamArea != "Tümünü Göster")
            {
                filteredBooks = filteredBooks.Where(b => b.examArea == selectedExamArea);
            }

            if (selectedBookType != "Tümünü Göster")
            {
                filteredBooks = filteredBooks.Where(b => b.bookType == selectedBookType);
            }

            // DataGridView'i filtrelenmiş veriyle güncelle
            dgwKaynaklar.DataSource = filteredBooks.Select(b => new
            {
                b.book_id,
                b.bookName,
                b.examArea,
                b.bookClass,
                b.bookType,
                b.author
            }).ToList();

         
        }
        

        private void btnGeriDon3_Click(object sender, EventArgs e)
        {
            RehberlikOgretmeniAnaForm rehberlikOgretmeniAnaForm = new RehberlikOgretmeniAnaForm(teacherId);
            rehberlikOgretmeniAnaForm.Show();
            this.Hide();
        }

        private void btnGeriDon4_Click(object sender, EventArgs e)
        {
            RehberlikOgretmeniAnaForm rehberlikOgretmeniAnaForm = new RehberlikOgretmeniAnaForm(teacherId);
            rehberlikOgretmeniAnaForm.Show();
            this.Hide();
        }
        


        private void tbxOgrenciNumarasi_TextChanged(object sender, EventArgs e)
        {
            int studentId;
            if (int.TryParse(tbxOgrenciNumarasi.Text, out studentId))
            {
                var filteredMeetings = ent.Meeting
                                          .Where(m => m.teacher_id == teacherId && m.student_id == studentId)
                                          .Select(m => new
                                          {
                                              //m.meeting_id,
                                              m.student_id,
                                              m.meetingType,
                                              m.performerName,
                                              m.meeting_date,
                                              //m.meetingSubject,
                                              m.meetingExplanation,
                                              //m.meetingPlanning,
                                              //m.meetingNotes
                                          })
                                          .ToList();

                dgwGorusmeDetaylari.DataSource = filteredMeetings;
            }
            else
            {
                LoadMeetings();
            }
        }

        private void lblGorusmeDetaylariAramaYap_Click(object sender, EventArgs e)
        {
            DateTime startDate = dtpGorusmeDetayBaslangicTarihi.Value.Date;
            DateTime endDate = dtpGorusmeDetayBitisTarihi.Value.Date;

            if (startDate > endDate)
            {
                MessageBox.Show("Başlangıç tarihi bitiş tarihinden büyük olamaz.", "Tarih Hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var dateFilteredMeetings = ent.Meeting
                                          .Where(m => m.teacher_id == teacherId && m.meeting_date >= startDate && m.meeting_date <= endDate)
                                          .Select(m => new
                                          {
                                              //m.meeting_id,
                                              m.student_id,
                                              m.meetingType,
                                              m.performerName,
                                              m.meeting_date,
                                              //m.meetingSubject,
                                              m.meetingExplanation,
                                              //m.meetingPlanning,
                                              //m.meetingNotes
                                          })
                                          .ToList();

            dgwGorusmeDetaylari.DataSource = dateFilteredMeetings;
        }

        private void btnGorusmeDetaylariTumunuGoster_Click(object sender, EventArgs e)
        {
            LoadMeetings();
        }

        private void cbxKaynakDers_SelectedIndexChanged(object sender, EventArgs e)
        {
            ApplyFilters();
        }

        private void cbxKaynakAlan_SelectedIndexChanged(object sender, EventArgs e)
        {
            ApplyFilters();
        }

        private void cbxKaynakTuru_SelectedIndexChanged(object sender, EventArgs e)
        {
            ApplyFilters();
        }

        private void lblGorusmeSayisiAra_Click(object sender, EventArgs e)
        {
            int studentId;
            if (int.TryParse(tbxGorusmeSayisiOgrenciNumarasi.Text.Trim(), out studentId))
            {
                var meetingCount = ent.Meeting
                    .Where(m => m.student_id == studentId)
                    .Count();

                lblGerceklestirilenGorusmeSayisiOgrenci.Text = $"Toplam Görüşme Sayısı: {meetingCount}";
            }
            else
            {
                MessageBox.Show("Lütfen geçerli bir öğrenci numarası giriniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
        public void ExportDataGridViewToPdf(DataGridView dgv, string filePath, string baslik)
        {
            Document doc = new Document();
            PdfWriter writer = PdfWriter.GetInstance(doc, new FileStream(filePath, FileMode.Create));

            var teacher = ent.Teacher.FirstOrDefault(t => t.teacher_id == this.teacherId);
            string teacherName = teacher?.name;
            PdfPageEvents pageEvents = new PdfPageEvents(teacherName);
            writer.PageEvent = pageEvents;


            doc.Open();

            BaseFont baseFont = BaseFont.CreateFont(@"C:\Windows\Fonts\arial.ttf", BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
            iTextSharp.text.Font titleFont = new iTextSharp.text.Font(baseFont, 14f, iTextSharp.text.Font.NORMAL, BaseColor.BLACK);

            Paragraph title = new Paragraph(baslik, titleFont);
            title.Alignment = Element.ALIGN_CENTER;
            doc.Add(title);
            doc.Add(new Paragraph("\n"));
            doc.Add(new Paragraph("\n"));
            doc.Add(new Paragraph("\n"));
            // Determine column widths
            float[] columnWidths = new float[dgv.Columns.Count];
            for (int i = 0; i < dgv.Columns.Count; i++)
            {
                if (dgv.Columns[i].Name == "meetingExplanation")
                {
                    columnWidths[i] = 0.5f; // Meeting Explanation column gets half of the table width
                }
                else
                {
                    columnWidths[i] = 0.5f / (dgv.Columns.Count - 1); // Other columns share the remaining half
                }
            }

            PdfPTable table = new PdfPTable(columnWidths);
            table.WidthPercentage = 100;

            // Add headers
            string arialFontPath = @"C:\Windows\Fonts\arial.ttf";
            BaseFont arialBaseFont = BaseFont.CreateFont(arialFontPath, BaseFont.IDENTITY_H, BaseFont.EMBEDDED);

            iTextSharp.text.Font headerFont = new iTextSharp.text.Font(arialBaseFont, 10, iTextSharp.text.Font.BOLD, BaseColor.WHITE);
            iTextSharp.text.Font cellFont = new iTextSharp.text.Font(arialBaseFont, 10, iTextSharp.text.Font.NORMAL, BaseColor.BLACK);

            foreach (DataGridViewColumn column in dgv.Columns)
            {
                PdfPCell headerCell = new PdfPCell(new Phrase(column.HeaderText, headerFont))
                {
                    BackgroundColor = new BaseColor(51, 51, 51)
                };
                table.AddCell(headerCell);
            }

            // Add data rows
            foreach (DataGridViewRow row in dgv.Rows)
            {
                foreach (DataGridViewCell cell in row.Cells)
                {
                    table.AddCell(new PdfPCell(new Phrase(cell.Value?.ToString(), cellFont)));
                }
            }

            doc.Add(table);
            doc.Close();
        }


        public void ExportDataGridViewToExcel(DataGridView dgv, string filePath)
        {
            using (ExcelPackage package = new ExcelPackage())
            {
                ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("Görüşme Detayları");

                // Add headers
                for (int i = 0; i < dgv.Columns.Count; i++)
                {
                    worksheet.Cells[1, i + 1].Value = dgv.Columns[i].HeaderText;
                }

                // Add data rows
                for (int i = 0; i < dgv.Rows.Count; i++)
                {
                    for (int j = 0; j < dgv.Columns.Count; j++)
                    {
                        worksheet.Cells[i + 2, j + 1].Value = dgv.Rows[i].Cells[j].Value?.ToString();
                    }
                }

                // Format header
                using (var range = worksheet.Cells[1, 1, 1, dgv.Columns.Count])
                {
                    range.Style.Font.Bold = true;
                    range.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    range.Style.Fill.BackgroundColor.SetColor(Color.LightGray);
                    range.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                }

                // AutoFit columns
                worksheet.Cells.AutoFitColumns();

                // Save file
                FileInfo fileInfo = new FileInfo(filePath);
                package.SaveAs(fileInfo);
            }
        }
        

       



        private void btnGorusmeRaporuIndir_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "PDF Files|*.pdf|Excel Files|*.xlsx",
                Title = "Görüşme Raporunu Kaydet"
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = saveFileDialog.FileName;
                if (Path.GetExtension(filePath).ToLower() == ".pdf")
                {
                    ExportDataGridViewToPdf(dgwGorusmeDetaylari, filePath,"Görüşme Kayıtları Raporu");
                    MessageBox.Show($"Rapor başarıyla PDF formatında kaydedildi: {filePath}", "Rapor Kaydedildi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (Path.GetExtension(filePath).ToLower() == ".xlsx")
                {
                    ExportDataGridViewToExcel(dgwGorusmeDetaylari, filePath);
                    MessageBox.Show($"Rapor başarıyla Excel formatında kaydedildi: {filePath}", "Rapor Kaydedildi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void btnKaynakRaporuIndir_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "PDF Files|*.pdf|Excel Files|*.xlsx",
                Title = "Kaynakları Kaydet"
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = saveFileDialog.FileName;
                if (Path.GetExtension(filePath).ToLower() == ".pdf")
                {
                    ExportDataGridViewToPdf(dgwKaynaklar, filePath,"Kaynak Kitaplar Raporu");
                    MessageBox.Show($"Kaynaklar başarıyla PDF formatında kaydedildi: {filePath}", "Kaydedildi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (Path.GetExtension(filePath).ToLower() == ".xlsx")
                {
                    ExportDataGridViewToExcel(dgwKaynaklar, filePath);
                    MessageBox.Show($"Kaynaklar başarıyla Excel formatında kaydedildi: {filePath}", "Kaydedildi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
        private DataTable GetStudentMeetingCountsTable()
        {
            var studentMeetings = ent.Student
                .Where(s => s.teacher_id == teacherId)
                .Join(ent.Meeting,
                    student => student.student_id,
                    meeting => meeting.student_id,
                    (student, meeting) => new { student, meeting })
                .GroupBy(x => x.student.student_id)
                .Select(g => new
                {
                    StudentName = g.FirstOrDefault().student.name,
                    MeetingCount = g.Count()
                })
                .ToList();

            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("Öğrenci Adı Soyadı", typeof(string));
            dataTable.Columns.Add("Görüşme Sayısı", typeof(int));

            foreach (var studentMeeting in studentMeetings)
            {
                dataTable.Rows.Add(studentMeeting.StudentName, studentMeeting.MeetingCount);
            }

            return dataTable;
        }
        private DataTable GetMonthlyMeetingCountsTable()
        {
            var meetings = ent.Meeting
                .Where(m => m.teacher_id == teacherId)
                .ToList();

            var monthlyMeetingCounts = meetings
                .GroupBy(m => new { m.meeting_date?.Year, m.meeting_date?.Month })
                .Select(g => new
                {
                    Year = g.Key.Year,
                    Month = g.Key.Month,
                    StudentMeetingCount = g.Count(m => m.meetingType == "Öğrenci Görüşmesi"),
                    ParentMeetingCount = g.Count(m => m.meetingType == "Veli Görüşmesi"),
                    TotalMeetingCount = g.Count()
                })
                .OrderBy(g => g.Year)
                .ThenBy(g => g.Month)
                .ToList();

            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("Yıl", typeof(int));
            dataTable.Columns.Add("Ay", typeof(string));
            dataTable.Columns.Add("Öğrenci Görüşmeleri Sayısı", typeof(int));
            dataTable.Columns.Add("Veli Görüşmeleri Sayısı", typeof(int));
            dataTable.Columns.Add("Toplam Görüşme Sayısı", typeof(int));

            foreach (var item in monthlyMeetingCounts)
            {
                string monthName = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName((int)item.Month);
                dataTable.Rows.Add(item.Year, monthName, item.StudentMeetingCount, item.ParentMeetingCount, item.TotalMeetingCount);
            }

            return dataTable;
        }
        public void ExportDataTableToPdf(DataTable dt, string filePath, string titleText)
        {
            Document doc = new Document();
            PdfWriter writer = PdfWriter.GetInstance(doc, new FileStream(filePath, FileMode.Create));

            var teacher = ent.Teacher.FirstOrDefault(t => t.teacher_id == this.teacherId);
            string teacherName = teacher?.name;
            PdfPageEvents pageEvents = new PdfPageEvents(teacherName);
            writer.PageEvent = pageEvents;

            doc.Open();

            // Define the custom font
            BaseFont baseFont = BaseFont.CreateFont(@"C:\Windows\Fonts\arial.ttf", BaseFont.IDENTITY_H, BaseFont.EMBEDDED);

            // Title
            iTextSharp.text.Font titleFont = new iTextSharp.text.Font(baseFont, 14f, iTextSharp.text.Font.NORMAL, BaseColor.BLACK);
            Paragraph title = new Paragraph(titleText, titleFont);
            title.Alignment = Element.ALIGN_CENTER;
            doc.Add(title);
            doc.Add(new Paragraph("\n"));
            doc.Add(new Paragraph("\n"));
            doc.Add(new Paragraph("\n"));

            // Table
            PdfPTable table = new PdfPTable(dt.Columns.Count);
            table.WidthPercentage = 100;

            // Add headers
            iTextSharp.text.Font headerFont = new iTextSharp.text.Font(baseFont, 10f, iTextSharp.text.Font.BOLD, BaseColor.WHITE);
            foreach (DataColumn column in dt.Columns)
            {
                PdfPCell headerCell = new PdfPCell(new Phrase(column.ColumnName, headerFont))
                {
                    BackgroundColor = new BaseColor(51, 51, 51)
                };
                table.AddCell(headerCell);
            }

            // Add data rows
            iTextSharp.text.Font cellFont = new iTextSharp.text.Font(baseFont, 10f, iTextSharp.text.Font.NORMAL, BaseColor.BLACK);
            foreach (DataRow row in dt.Rows)
            {
                foreach (var cell in row.ItemArray)
                {
                    table.AddCell(new PdfPCell(new Phrase(cell.ToString(), cellFont)));
                }
            }

            doc.Add(table);
            doc.Close();
        }

        public void ExportDataTableToExcel(DataTable dt, string filePath)
        {
            using (ExcelPackage package = new ExcelPackage())
            {
                ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("Veriler");

                // Add headers
                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    worksheet.Cells[1, i + 1].Value = dt.Columns[i].ColumnName;
                }

                // Add data rows
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    for (int j = 0; j < dt.Columns.Count; j++)
                    {
                        worksheet.Cells[i + 2, j + 1].Value = dt.Rows[i][j].ToString();
                    }
                }

                // Format header
                using (var range = worksheet.Cells[1, 1, 1, dt.Columns.Count])
                {
                    range.Style.Font.Bold = true;
                    range.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    range.Style.Fill.BackgroundColor.SetColor(Color.LightGray);
                    range.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                }

                // AutoFit columns
                worksheet.Cells.AutoFitColumns();

                // Save file
                FileInfo fileInfo = new FileInfo(filePath);
                package.SaveAs(fileInfo);
            }
        }

        private void btnOgrenciKatilimRaporuIndir_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "PDF Files|*.pdf|Excel Files|*.xlsx",
                Title = "Öğrenci Görüşme Sayıları Raporunu Kaydet"
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = saveFileDialog.FileName;
                var dataTable = GetStudentMeetingCountsTable();

                if (Path.GetExtension(filePath).ToLower() == ".pdf")
                {
                    ExportDataTableToPdf(dataTable, filePath, "Öğrenci Görüşme Sayıları");
                    MessageBox.Show($"Rapor başarıyla PDF formatında kaydedildi: {filePath}", "Rapor Kaydedildi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (Path.GetExtension(filePath).ToLower() == ".xlsx")
                {
                    ExportDataTableToExcel(dataTable, filePath);
                    MessageBox.Show($"Rapor başarıyla Excel formatında kaydedildi: {filePath}", "Rapor Kaydedildi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void btnOgretmenKatilimRaporuIndir_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "PDF Files|*.pdf|Excel Files|*.xlsx",
                Title = "Rehber Ögretmen Katilim Raporunu Kaydet"
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = saveFileDialog.FileName;
                var dataTable = GetMonthlyMeetingCountsTable();

                if (Path.GetExtension(filePath).ToLower() == ".pdf")
                {
                    ExportDataTableToPdf(dataTable, filePath, "Rehber Öğretmen Görüşme Sayıları");
                    MessageBox.Show($"Rapor başarıyla PDF formatında kaydedildi: {filePath}", "Rapor Kaydedildi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (Path.GetExtension(filePath).ToLower() == ".xlsx")
                {
                    ExportDataTableToExcel(dataTable, filePath);
                    MessageBox.Show($"Rapor başarıyla Excel formatında kaydedildi: {filePath}", "Rapor Kaydedildi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void tbxOgrenciNumarasi_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true; // Tuşun işlenmesini durdur
            }
        }

        private void tbxGorusmeSayisiOgrenciNumarasi_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true; // Tuşun işlenmesini durdur
            }
        }
    }
}
