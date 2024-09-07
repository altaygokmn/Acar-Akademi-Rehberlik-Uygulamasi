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
using OfficeOpenXml.Style;
using OfficeOpenXml;
using LicenseContext = OfficeOpenXml.LicenseContext;
using System.Runtime.InteropServices.ComTypes;
using System.Drawing.Drawing2D;
using System.Windows.Forms.DataVisualization.Charting;
using Rectangle = System.Drawing.Rectangle;
using Font = System.Drawing.Font;


namespace AcarAkademiRehberlik
{
    public partial class GorusmeBilgileriForm : Form
    {
        private Dbo_acarEntities ent = new Dbo_acarEntities();
        private int teacherId;
        public GorusmeBilgileriForm(int id)
        {  
            InitializeComponent();
            this.teacherId = id;
            ExcelPackage.LicenseContext = LicenseContext.Commercial;
            

        }


        private void GorusmeBilgileriForm_Load(object sender, EventArgs e)
        {
            dtpGorusmeTarihiAralikBitis.Value = DateTime.Now;
            dtpGorusmeTarihiAralikBaslangic.Value = DateTime.Now.AddMonths(-1); // Varsayılan olarak son 1 ay
            btnExcelIndir.Hide();
            btnPDFIndir.Hide();
            LoadStudents();
            LoadMeetings();
            ApplyModernStyle(this);
            // Tarih aralığı
            StyleDataGridView(dgwGorusmeBilgileri);
            StyleDataGridView(dgwOgrencilerim);
            // Filtreleme butonunun tıklama olayını bağla
            StyleButton(btnExcelIndir);
            StyleButton(btnPDFIndir);
            StyleButton(btnGeriDon);
            StyleButton(btnGorusmeDuzenle);
            StyleButton(btnGorusmeRaporuIndir);
            StyleButton(btnGorusmeSil);
            StyleButton(btnGorusmeTumunuGoruntuleRehberOgretmen);
            cbxGorusmeTuru.SelectedIndex = 2; // Default olarak "Tümünü Göster" seçilsin

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
        private void btnGorusmeRaporuIndir_Click(object sender, EventArgs e)
        {
            btnGorusmeRaporuIndir.Hide();
            btnPDFIndir.Show();
            btnExcelIndir.Show();
            
        }
        private void LoadStudents()
        {
            var students = ent.Student
                .Where(s => s.teacher_id == teacherId)
                .Select(s => new
                {
                    s.student_id,
                    s.name
                }).ToList();

            dgwOgrencilerim.DataSource = students;
            dgwOgrencilerim.Columns["student_id"].HeaderText = "Öğrenci Numarası";
            dgwOgrencilerim.Columns["name"].HeaderText = "Öğrenci Adı";
        }

        private void LoadMeetings()
        {
            var meetings = ent.Meeting
                .Where(m => m.teacher_id == teacherId)
                .OrderByDescending(m => m.meeting_date)
                .Select(m => new
                {
                    m.meeting_id,
                    StudentName = ent.Student.FirstOrDefault(t => t.student_id == m.student_id).name,
                    m.student_id,
                    m.meetingType,
                    m.performerName,
                    m.meeting_date,
                    //m.meetingSubject,
                    m.meetingExplanation,
                    //m.meetingPlanning,
                    //m.meetingNotes
                }).ToList();

            dgwGorusmeBilgileri.DataSource = meetings;
            dgwGorusmeBilgileri.Columns["meeting_id"].Visible = false;
            dgwGorusmeBilgileri.Columns["StudentName"].HeaderText = "Öğrenci";
            dgwGorusmeBilgileri.Columns["student_id"].HeaderText = "Öğrenci Numarası";
            dgwGorusmeBilgileri.Columns["meetingType"].HeaderText = "Görüşme Türü";
            dgwGorusmeBilgileri.Columns["performerName"].HeaderText = "Görüşülen Kişi";
            dgwGorusmeBilgileri.Columns["meeting_date"].HeaderText = "Tarih";
            //dgwGorusmeBilgileri.Columns["meetingSubject"].HeaderText = "Konu";
            dgwGorusmeBilgileri.Columns["meetingExplanation"].HeaderText = "Açıklama";
            //dgwGorusmeBilgileri.Columns["meetingPlanning"].HeaderText = "Planlama";
            //dgwGorusmeBilgileri.Columns["meetingNotes"].HeaderText = "Notlar";
            
        }
        
        

        
        private void btnGeriDon_Click(object sender, EventArgs e)
        {
            RehberlikOgretmeniAnaForm rehberlikOgretmeniAnaForm = new RehberlikOgretmeniAnaForm(teacherId);
            rehberlikOgretmeniAnaForm.Show();
            this.Hide();
        }

        private void btnGorusmeDuzenle_Click(object sender, EventArgs e)
        {
            if (dgwGorusmeBilgileri.SelectedRows.Count > 0)
            {
                int selectedMeetingId = Convert.ToInt32(dgwGorusmeBilgileri.SelectedRows[0].Cells["meeting_id"].Value);
                int selectedStudentId = Convert.ToInt32(dgwGorusmeBilgileri.SelectedRows[0].Cells["student_id"].Value);
                GorusmeDuzenleForm gorusmeDuzenleForm = new GorusmeDuzenleForm(selectedMeetingId, selectedStudentId);
                gorusmeDuzenleForm.Show();
            }
            else
            {
                MessageBox.Show("Lütfen düzenlemek istediğiniz görüşmeyi seçin.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void ApplyFilters()
        {
            string selectedType = cbxGorusmeTuru.SelectedItem?.ToString();
            DateTime? startDate = dtpGorusmeTarihiAralikBaslangic.Value.Date;
            DateTime? endDate = dtpGorusmeTarihiAralikBitis.Value.Date;

            var filteredMeetings = ent.Meeting.AsQueryable();

            // Görüşme türüne göre filtreleme
            if (selectedType != "Tümünü Göster")
            {
                filteredMeetings = filteredMeetings.Where(m => m.meetingType == selectedType);
            }

            if (startDate > endDate)
            {
                MessageBox.Show("Başlangıç tarihi bitiş tarihinden büyük olamaz.", "Tarih Hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (startDate.HasValue && endDate.HasValue)
            {
                filteredMeetings = filteredMeetings.Where(m => m.meeting_date >= startDate.Value);
            }
            if (endDate.HasValue)
            {
                filteredMeetings = filteredMeetings.Where(m => m.meeting_date <= endDate.Value);
            }

            // Seçili öğrenciye göre filtreleme



            if (dgwOgrencilerim.SelectedRows.Count > 0)
            {
                int selectedStudentId = Convert.ToInt32(dgwOgrencilerim.SelectedRows[0].Cells["student_id"].Value);
                filteredMeetings = filteredMeetings.Where(m => m.student_id == selectedStudentId);
            }

            var filteredMeetingsList = filteredMeetings
                .Where(m => m.teacher_id == teacherId)
                .OrderByDescending(m => m.meeting_date)
                .Select(m => new
                {
                    m.meeting_id,
                    StudentName = ent.Student.FirstOrDefault(t => t.student_id == m.student_id).name,
                    m.student_id,
                    m.meetingType,
                    m.performerName,
                    m.meeting_date,
                    //m.meetingSubject,
                    m.meetingExplanation,
                    //m.meetingPlanning,
                    //m.meetingNotes
                }).ToList();

            dgwGorusmeBilgileri.DataSource = filteredMeetingsList;
            dgwGorusmeBilgileri.Columns["meeting_id"].Visible = false;
            dgwGorusmeBilgileri.Columns["StudentName"].HeaderText = "Öğrenci";
            dgwGorusmeBilgileri.Columns["student_id"].Visible = false;
            dgwGorusmeBilgileri.Columns["meetingType"].HeaderText = "Görüşme Türü";
            dgwGorusmeBilgileri.Columns["performerName"].HeaderText = "Görüşülen Kişi";
            dgwGorusmeBilgileri.Columns["meeting_date"].HeaderText = "Tarih";
            //dgwGorusmeBilgileri.Columns["meetingSubject"].HeaderText = "Konu";
            dgwGorusmeBilgileri.Columns["meetingExplanation"].HeaderText = "Açıklama";
            //dgwGorusmeBilgileri.Columns["meetingPlanning"].HeaderText = "Planlama";
            //dgwGorusmeBilgileri.Columns["meetingNotes"].HeaderText = "Notlar";
            //dgwGorusmeBilgileri.Columns["teacher_id"].Visible = false;
        }





        private void lblAramaYap_Click(object sender, EventArgs e)
        {
            ApplyFilters();
        }

        private void cbxGorusmeTuru_SelectedIndexChanged(object sender, EventArgs e)
        {
            ApplyFilters();
        }

        private void dtpGorusmeTarihiAralikBaslangic_ValueChanged(object sender, EventArgs e)
        {
            ApplyFilters();
        }

        private void dtpGorusmeTarihiAralikBitis_ValueChanged(object sender, EventArgs e)
        {
            ApplyFilters();
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
        private void CreateFilteredMeetingsPdfReport(string filePath)
        {
            // Öğretmen bilgilerini alın
            var teacher = ent.Teacher.FirstOrDefault(t => t.teacher_id == this.teacherId);
            string teacherName = teacher?.name;

            Document doc = new Document();
            PdfWriter writer = PdfWriter.GetInstance(doc, new FileStream(filePath, FileMode.Create));

            // Page Event Helper'ı ekleyin
            writer.PageEvent = new PdfPageEvents(teacherName);

            doc.Open();

            List<string> processedStudents = new List<string>();

            foreach (DataGridViewRow studentRow in dgwGorusmeBilgileri.Rows)
            {
                string studentName = studentRow.Cells["StudentName"].Value?.ToString();
                if (processedStudents.Contains(studentName))
                    continue;

                processedStudents.Add(studentName);

                BaseFont baseFont = BaseFont.CreateFont(@"C:\Windows\Fonts\arial.ttf", BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
                iTextSharp.text.Font titleFont = new iTextSharp.text.Font(baseFont, 17f, iTextSharp.text.Font.BOLD, BaseColor.BLACK);
                doc.Add(new Paragraph("\n"));

                Paragraph title = new Paragraph($"Görüşmeler - {studentName}", titleFont);
                title.Alignment = Element.ALIGN_CENTER;
                doc.Add(title);
                doc.Add(new Paragraph("\n"));
                doc.Add(new Paragraph("\n"));
                var studentInfo = ent.Student
                    .Where(s => s.name == studentName)
                    .Select(s => new
                    {
                        StudentClass = s.@class,
                        StudentNumber = s.student_id,
                        TeacherName = ent.Teacher.FirstOrDefault(t => t.teacher_id == s.teacher_id).name
                    })
                    .FirstOrDefault();

                PdfPTable infoTable = new PdfPTable(2);
                infoTable.WidthPercentage = 50;
                infoTable.HorizontalAlignment = Element.ALIGN_LEFT;

                AddInfoCell(infoTable, "Öğrenci Numarası", studentInfo?.StudentNumber.ToString());
                AddInfoCell(infoTable, "Sınıf", studentInfo?.StudentClass);
                AddInfoCell(infoTable, "Öğretmen", studentInfo?.TeacherName);

                doc.Add(infoTable);
                doc.Add(new Paragraph("\n"));

                PdfPTable table = new PdfPTable(4);
                table.WidthPercentage = 100;
                table.SpacingBefore = 10;
                table.SpacingAfter = 10;

                foreach (DataGridViewRow row in dgwGorusmeBilgileri.Rows)
                {
                    if (row.Cells["StudentName"].Value?.ToString() == studentName)
                    {
                        AddCell(table, "Görüşme Türü", row.Cells["meetingType"].Value?.ToString());
                        AddCell(table, "Görüşülen Kişi", row.Cells["performerName"].Value?.ToString());
                        AddCell(table, "Tarih", row.Cells["meeting_date"].Value?.ToString());
                        table.CompleteRow();
                        AddWideCell(table, "Görüşme İçeriği", row.Cells["meetingExplanation"].Value?.ToString());

                        PdfPCell emptyCell = new PdfPCell(new Phrase(" "));
                        emptyCell.Colspan = 4;
                        emptyCell.Border = PdfPCell.NO_BORDER;
                        table.AddCell(emptyCell);
                    }
                }

                doc.Add(table);
                doc.NewPage();
            }

            doc.Close();
        }


        // Tabloya hücre ekleme metod

        private void AddCell(PdfPTable table, string label, string value)
        {
            PdfPCell headerCell = new PdfPCell(new Phrase(label, new iTextSharp.text.Font(BaseFont.CreateFont(@"C:\Windows\Fonts\arial.ttf", BaseFont.IDENTITY_H, BaseFont.EMBEDDED))));
            headerCell.BackgroundColor = new BaseColor(255, 255, 255);
            headerCell.HorizontalAlignment = Element.ALIGN_CENTER;
            table.AddCell(headerCell);

            PdfPCell valueCell = new PdfPCell(new Phrase(value, new iTextSharp.text.Font(BaseFont.CreateFont(@"C:\Windows\Fonts\arial.ttf", BaseFont.IDENTITY_H, BaseFont.EMBEDDED))));
            valueCell.BackgroundColor = BaseColor.WHITE;
            table.AddCell(valueCell);
        }

        // Geniş hücre ekleme metod
        private void AddWideCell(PdfPTable table, string label, string value)
        {
            PdfPCell headerCell = new PdfPCell(new Phrase(label, new iTextSharp.text.Font(BaseFont.CreateFont(@"C:\Windows\Fonts\arial.ttf", BaseFont.IDENTITY_H, BaseFont.EMBEDDED))));
            headerCell.BackgroundColor = new BaseColor(255, 255, 255);
            headerCell.HorizontalAlignment = Element.ALIGN_CENTER;
            table.AddCell(headerCell);

            PdfPCell valueCell = new PdfPCell(new Phrase(value, new iTextSharp.text.Font(BaseFont.CreateFont(@"C:\Windows\Fonts\arial.ttf", BaseFont.IDENTITY_H, BaseFont.EMBEDDED))));
            valueCell.BackgroundColor = BaseColor.WHITE;
            valueCell.Colspan = 3; // Geniş hücre için kolon sayısını ayarlayın
            table.AddCell(valueCell);
        }

        // Bilgi tablosuna hücre ekleme metod
        private void AddInfoCell(PdfPTable table, string label, string value)
        {
            PdfPCell headerCell = new PdfPCell(new Phrase(label, new iTextSharp.text.Font(BaseFont.CreateFont(@"C:\Windows\Fonts\arial.ttf", BaseFont.IDENTITY_H, BaseFont.EMBEDDED))));
            headerCell.BackgroundColor = new BaseColor(255, 255, 255);
            headerCell.HorizontalAlignment = Element.ALIGN_LEFT;
            table.AddCell(headerCell);

            PdfPCell valueCell = new PdfPCell(new Phrase(value, new iTextSharp.text.Font(BaseFont.CreateFont(@"C:\Windows\Fonts\arial.ttf", BaseFont.IDENTITY_H, BaseFont.EMBEDDED))));
            valueCell.BackgroundColor = BaseColor.WHITE;
            table.AddCell(valueCell);
        }

        // PDF indirme butonu click eventi
        private void btnPDFIndir_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "PDF Dosyaları|*.pdf",
                Title = "Filtrelenmiş Görüşmeleri Kaydet"
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = saveFileDialog.FileName;
                CreateFilteredMeetingsPdfReport(filePath);
                MessageBox.Show($"Görüşmeler başarıyla kaydedildi: {filePath}", "Rapor Kaydedildi", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                footerTemplate.ShowText("" + (writer.PageNumber - 1));
                footerTemplate.EndText();
            }
        }





        public void CreateFilteredMeetingsExcelReport(string filePath)
        {
            using (ExcelPackage package = new ExcelPackage())
            {
                ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("Görüşmeler");

                // Başlıkları Ekle
                worksheet.Cells[1, 1].Value = "Görüşme Numarası";
                worksheet.Cells[1, 2].Value = "Öğrenci";
                worksheet.Cells[1, 3].Value = "Öğrenci Numarası";
                worksheet.Cells[1, 4].Value = "Görüşme Türü";
                worksheet.Cells[1, 5].Value = "Görüşülen Kişi";
                worksheet.Cells[1, 6].Value = "Tarih";
                //worksheet.Cells[1, 7].Value = "Konu";
                worksheet.Cells[1, 8].Value = "Açıklama";
                //worksheet.Cells[1, 9].Value = "Planlama";
                //worksheet.Cells[1, 10].Value = "Notlar";

                // Başlık hücrelerini stilize et
                using (var range = worksheet.Cells[1, 1, 1, 10])
                {
                    range.Style.Font.Bold = true;
                    range.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    range.Style.Fill.BackgroundColor.SetColor(Color.LightGray);
                    range.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                }

                // Verileri tabloya ekle
                int row = 2;
                foreach (DataGridViewRow dgvRow in dgwGorusmeBilgileri.Rows)
                {
                    worksheet.Cells[row, 1].Value = dgvRow.Cells["meeting_id"].Value?.ToString();
                    worksheet.Cells[row, 2].Value = dgvRow.Cells["StudentName"].Value?.ToString();
                    worksheet.Cells[row, 3].Value = dgvRow.Cells["student_id"].Value?.ToString();
                    worksheet.Cells[row, 4].Value = dgvRow.Cells["meetingType"].Value?.ToString();
                    worksheet.Cells[row, 5].Value = dgvRow.Cells["performerName"].Value?.ToString();
                    worksheet.Cells[row, 6].Value = dgvRow.Cells["meeting_date"].Value?.ToString();
                    //worksheet.Cells[row, 7].Value = dgvRow.Cells["meetingSubject"].Value?.ToString();
                    worksheet.Cells[row, 8].Value = dgvRow.Cells["meetingExplanation"].Value?.ToString();
                    //worksheet.Cells[row, 9].Value = dgvRow.Cells["meetingPlanning"].Value?.ToString();
                    //worksheet.Cells[row, 10].Value = dgvRow.Cells["meetingNotes"].Value?.ToString();
                    row++;
                }

                // Satırların boyutlarını ayarla
                worksheet.Cells.AutoFitColumns();

                // Dosyayı kaydet
                FileInfo fileInfo = new FileInfo(filePath);
                package.SaveAs(fileInfo);
            }
        }

        private void btnGorusmeTumunuGoruntuleRehberOgretmen_Click(object sender, EventArgs e)
        {
            LoadMeetings();
        }

       

        private void btnExcelIndir_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "Excel Files (*.xlsx)|*.xlsx",
                Title = "Filtrelenmiş Görüşmeleri Kaydet"
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = saveFileDialog.FileName;
                CreateFilteredMeetingsExcelReport(filePath);
                MessageBox.Show($"Görüşmeler başarıyla kaydedildi: {filePath}", "Rapor Kaydedildi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnGorusmeSil_Click(object sender, EventArgs e)
        {
            if (dgwGorusmeBilgileri.SelectedRows.Count > 0)
            {
                int selectedMeetingId = Convert.ToInt32(dgwGorusmeBilgileri.SelectedRows[0].Cells["meeting_id"].Value);
                var meeting = ent.Meeting.FirstOrDefault(m => m.meeting_id == selectedMeetingId);

                if (meeting != null)
                {
                    DialogResult dialogResult = MessageBox.Show("Seçili görüşmeyi silmek istediğinizden emin misiniz?", "Görüşme Sil", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (dialogResult == DialogResult.Yes)
                    {
                        ent.Meeting.Remove(meeting);
                        ent.SaveChanges();
                        MessageBox.Show("Görüşme başarıyla silindi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadMeetings();
                    }
                }
                else
                {
                    MessageBox.Show("Seçili görüşme bulunamadı.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Lütfen silmek istediğiniz görüşmeyi seçin.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void tbxOgrenciNumarasi_TextChanged(object sender, EventArgs e)
        {
            if (int.TryParse(tbxOgrenciNumarasi.Text, out int studentId))
            {
                var filteredStudents = ent.Student
                                           .Where(s => s.student_id == studentId)
                                           .Select(s => new { s.student_id, s.name }) // Sadece gerekli sütunları seçiyoruz
                                           .ToList();
                dgwOgrencilerim.DataSource = filteredStudents;

                // Sütun başlıklarını belirleyin (eğer DataGridView otomatik başlık atamıyorsa)
                dgwOgrencilerim.Columns["student_id"].HeaderText = "Öğrenci Numarası";
                dgwOgrencilerim.Columns["name"].HeaderText = "Öğrenci Adı";
            }
            else
            {
                // Geçersiz giriş durumunda tüm öğrencileri yükleyin
                LoadStudents();
            }
        }

        private void tbxOgrenciNumarasi_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true; // Tuşun işlenmesini durdur
            }
        }

        private void lblOgrenciSecimKaldir_Click(object sender, EventArgs e)
        {
            dgwOgrencilerim.ClearSelection(); 
        }

        private void dgwOgrencilerim_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int studentId = (int)dgwOgrencilerim.Rows[e.RowIndex].Cells["student_id"].Value;
                var filteredMeetings = ent.Meeting.Where(m => m.student_id == studentId)
                .OrderByDescending(m => m.meeting_date)
                .Select(m => new
                {
                    m.meeting_id,
                    StudentName = ent.Student.FirstOrDefault(t => t.student_id == m.student_id).name,
                    m.student_id,
                    m.meetingType,
                    m.performerName,
                    m.meeting_date,
                    //m.meetingSubject,
                    m.meetingExplanation,
                    //m.meetingPlanning,
                    //m.meetingNotes
                }).ToList();

                dgwGorusmeBilgileri.DataSource = filteredMeetings;
                dgwGorusmeBilgileri.Columns["meeting_id"].Visible = false;
                dgwGorusmeBilgileri.Columns["StudentName"].HeaderText = "Öğrenci";
                dgwGorusmeBilgileri.Columns["student_id"].Visible = false;
                dgwGorusmeBilgileri.Columns["meetingType"].HeaderText = "Görüşme Türü";
                dgwGorusmeBilgileri.Columns["performerName"].HeaderText = "Görüşülen Kişi";
                dgwGorusmeBilgileri.Columns["meeting_date"].HeaderText = "Tarih";
                //dgwGorusmeBilgileri.Columns["meetingSubject"].HeaderText = "Konu";
                dgwGorusmeBilgileri.Columns["meetingExplanation"].HeaderText = "Açıklama";
                //dgwGorusmeBilgileri.Columns["meetingPlanning"].HeaderText = "Planlama";
                //dgwGorusmeBilgileri.Columns["meetingNotes"].HeaderText = "Notlar";
                //dgwGorusmeBilgileri.Columns["teacher_id"].Visible = false;
                

            }
        }
    }
}
    

