using OfficeOpenXml.Style;
using OfficeOpenXml;
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
using iTextSharp.text.pdf;
using iTextSharp.text;
using LicenseContext = OfficeOpenXml.LicenseContext;
using System.Drawing.Drawing2D;
using System.Windows.Forms.DataVisualization.Charting;
using Font = System.Drawing.Font;
using Rectangle = System.Drawing.Rectangle;
using OfficeOpenXml.Table;

namespace AcarAkademiRehberlik
{
    public partial class YoneticiGorusmeBilgileriForm : Form
    {
        private Dbo_acarEntities ent = new Dbo_acarEntities();
        private int teacherId;
        public YoneticiGorusmeBilgileriForm(int id)
        {
            InitializeComponent();
            this.teacherId = id;
            ExcelPackage.LicenseContext = LicenseContext.Commercial;
        }

        private void btnGeriDon_Click(object sender, EventArgs e)
        {
            RehberlikOgretmeniAnaForm rehberlikOgretmeniAnaForm = new RehberlikOgretmeniAnaForm(teacherId);
            rehberlikOgretmeniAnaForm.Show();
            this.Hide();
        }
        private void LoadTeachers()
        {
            var teachers = ent.Teacher
                              .Select(t => new { t.teacher_id, t.name })
                              .ToList();
            dgwRehberOgretmenler.DataSource = teachers;

            // Sütun başlıklarını belirleyin
            dgwRehberOgretmenler.Columns["teacher_id"].HeaderText = "Öğretmen Numarası";
            dgwRehberOgretmenler.Columns["name"].HeaderText = "Öğretmen Adı";
        }

        private void LoadStudents()
        {
            var students = ent.Student
                              .Select(s => new { s.student_id, s.name })
                              .ToList();
            dgwOgrenciler.DataSource = students;

            // Sütun başlıklarını belirleyin
            dgwOgrenciler.Columns["student_id"].HeaderText = "Öğrenci Numarası";
            dgwOgrenciler.Columns["name"].HeaderText = "Öğrenci Adı";
        }


        private void LoadMeetings()
        {
            var meetings = ent.Meeting
                .OrderByDescending(m => m.meeting_date)
                .Select(m => new
                {
                    m.meeting_id,
                    m.student_id,
                    m.teacher_id,
                    m.meetingType,
                    m.performerName,
                    m.meeting_date,
                    //m.meetingSubject,
                    m.meetingExplanation,
                    //m.meetingPlanning,
                    //m.meetingNotes
                })
                .ToList();


            dgwGorusmeler.DataSource = meetings;
            dgwGorusmeler.Columns["meeting_id"].Visible = false;
        }


        private void YoneticiGorusmeBilgileriForm_Load(object sender, EventArgs e)
        {
            if (cbxGorusmeTuru.Items.Count > 0)
            {
                cbxGorusmeTuru.SelectedIndex = 2;
            }
            LoadTeachers();
            LoadStudents();
            LoadMeetings();
            DateTime today = DateTime.Today;
            DateTime oneMonthAgo = today.AddMonths(-1);

            dtpGorusmeAralikBaslangicYonetici.Value = oneMonthAgo;
            dtpGorusmeAralikBitisYonetici.Value = today;
            StyleDataGridView(dgwRehberOgretmenler);
            StyleDataGridView(dgwOgrenciler);
            StyleDataGridView(dgwGorusmeler);
            StyleButton(btnGeriDon);
            StyleButton(btnGorusmeDuzenle);
            StyleButton(btnGorusmeRaporuIndir);
            StyleButton(btnGorusmeSil);
            StyleButton(btnGorusmeTumunuGoruntuleYonetici);
            StyleButton(btnYedekAl);
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
        private void tbxRehberOgretmenAdSoyad_TextChanged(object sender, EventArgs e)
        {
            string searchValue = tbxRehberOgretmenAdSoyad.Text.ToLower();
            var filteredTeachers = ent.Teacher
                                      .Where(t => t.name.ToLower().Contains(searchValue))
                                      .Select(t => new { t.teacher_id, t.name })
                                      .ToList();
            dgwRehberOgretmenler.DataSource = filteredTeachers;
        }

        private void tbxOgrenciNumarasi_TextChanged(object sender, EventArgs e)
        {
            if (int.TryParse(tbxOgrenciNumarasi.Text, out int studentId))
            {
                var filteredStudents = ent.Student
                                          .Where(s => s.student_id == studentId)
                                          .Select(s => new { s.student_id, s.name })
                                          .ToList();
                dgwOgrenciler.DataSource = filteredStudents;
            }
            else
            {
                LoadStudents();
            }
        }


        private void dgwRehberOgretmenler_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                
                int teacherId = (int)dgwRehberOgretmenler.Rows[e.RowIndex].Cells["teacher_id"].Value;
                var filteredMeetings = ent.Meeting.Where(m => m.teacher_id == teacherId).ToList();
                dgwGorusmeler.DataSource = filteredMeetings;
                dgwGorusmeler.Columns["Teacher"].Visible = false;
                dgwGorusmeler.Columns["Student"].Visible = false;
                dgwGorusmeler.Columns["meetingSubject"].Visible = false;
                dgwGorusmeler.Columns["meetingNotes"].Visible = false;
                dgwGorusmeler.Columns["meeting_id"].Visible = false;
                dgwGorusmeler.Columns["meetingPlanning"].Visible = false;

            }
        }

        private void dgwOgrenciler_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int studentId = (int)dgwOgrenciler.Rows[e.RowIndex].Cells["student_id"].Value;
                var filteredMeetings = ent.Meeting.Where(m => m.student_id == studentId).ToList();
                dgwGorusmeler.DataSource = filteredMeetings;
                dgwGorusmeler.Columns["Teacher"].Visible = false;
                dgwGorusmeler.Columns["Student"].Visible = false;
                dgwGorusmeler.Columns["meetingSubject"].Visible = false;
                dgwGorusmeler.Columns["meetingNotes"].Visible = false;
                dgwGorusmeler.Columns["meeting_id"].Visible = false;
                dgwGorusmeler.Columns["meetingPlanning"].Visible = false;
            }
        }

        private void lblAramaYap_Click(object sender, EventArgs e)
        {
            if (dgwGorusmeler.Columns["Teacher"]!=null) { dgwGorusmeler.Columns["Teacher"].Visible = false; }
            if (dgwGorusmeler.Columns["Student"] != null) { dgwGorusmeler.Columns["Teacher"].Visible = false; }
            string selectedType = cbxGorusmeTuru.SelectedItem.ToString();
            DateTime? startDate = dtpGorusmeAralikBaslangicYonetici.Value;
            DateTime? endDate = dtpGorusmeAralikBitisYonetici.Value;

            var filteredMeetings = ent.Meeting.AsQueryable();

            // Görüşme türüne göre filtreleme
            if (selectedType != "Tümünü Göster")
            {
                filteredMeetings = filteredMeetings.Where(m => m.meetingType == selectedType);
            }

            // Tarih aralığına göre filtreleme
            if (startDate > endDate)
            {
                MessageBox.Show("Başlangıç tarihi bitiş tarihinden büyük olamaz.", "Tarih Hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (startDate.HasValue)
            {
                filteredMeetings = filteredMeetings.Where(m => m.meeting_date >= startDate.Value);
            }
            if (endDate.HasValue)
            {
                filteredMeetings = filteredMeetings.Where(m => m.meeting_date <= endDate.Value);
            }

            // Öğrenci veya öğretmen filtrelemesi
            if (dgwOgrenciler.SelectedRows.Count > 0)
            {
                int selectedStudentId = Convert.ToInt32(dgwOgrenciler.SelectedRows[0].Cells["student_id"].Value);
                filteredMeetings = filteredMeetings.Where(m => m.student_id == selectedStudentId);
            }

            if (dgwRehberOgretmenler.SelectedRows.Count > 0)
            {
                int selectedTeacherId = Convert.ToInt32(dgwRehberOgretmenler.SelectedRows[0].Cells["teacher_id"].Value);
                filteredMeetings = filteredMeetings.Where(m => m.teacher_id == selectedTeacherId);
            }

            // Filtrelenmiş verileri DataGridView'e yükleme
            var filteredMeetingsList = filteredMeetings
                .Select(m => new
                {
                    m.meeting_id,
                    m.teacher_id,
                    m.student_id,
                    m.meetingType,
                    m.performerName,
                    m.meeting_date,
                    //m.meetingSubject,
                    m.meetingExplanation,
                    //m.meetingPlanning,
                    //m.meetingNotes
                }).ToList();

            dgwGorusmeler.DataSource = filteredMeetingsList;
            dgwGorusmeler.Columns["meeting_id"].Visible = false;
            dgwGorusmeler.Columns["teacher_id"].HeaderText = "Öğretmen Numarası";
            dgwGorusmeler.Columns["student_id"].HeaderText = "Öğrenci Numarası";
            dgwGorusmeler.Columns["meetingType"].HeaderText = "Görüşme Türü";
            dgwGorusmeler.Columns["performerName"].HeaderText = "Görüşmeyi Yapan Kişi";
            dgwGorusmeler.Columns["meeting_date"].HeaderText = "Tarih";
            //dgwGorusmeler.Columns["meetingSubject"].HeaderText = "Konu";
            dgwGorusmeler.Columns["meetingExplanation"].HeaderText = "Açıklama";
            //dgwGorusmeler.Columns["meetingPlanning"].HeaderText = "Planlama";
            //dgwGorusmeler.Columns["meetingNotes"].HeaderText = "Notlar";
            dgwOgrenciler.ClearSelection();
            dgwRehberOgretmenler.ClearSelection();
        }




        private void btnGorusmeRaporuIndir_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "PDF Files|*.pdf|Excel Files (*.xlsx)|*.xlsx",
                Title = "Filtrelenmiş Görüşmeleri Kaydet"
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = saveFileDialog.FileName;
                string selectedExtension = Path.GetExtension(filePath).ToLower();

                if (selectedExtension == ".pdf")
                {
                    CreateFilteredMeetingsPdfReport(filePath);
                    MessageBox.Show($"Filtrelenmiş görüşmeler başarıyla PDF formatında kaydedildi: {filePath}", "Rapor Kaydedildi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (selectedExtension == ".xlsx")
                {
                    ExportDataTableToExcel(filePath);
                    MessageBox.Show($"Filtrelenmiş görüşmeler başarıyla Excel formatında kaydedildi: {filePath}", "Rapor Kaydedildi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
        public void ExportDataGridViewToPdf(DataGridView dgv, string filePath, string baslik)
        {
            Document doc = new Document();
            PdfWriter.GetInstance(doc, new FileStream(filePath, FileMode.Create));
            doc.Open();

            BaseFont baseFont = BaseFont.CreateFont(@"C:\Windows\Fonts\arial.ttf", BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
            iTextSharp.text.Font titleFont = new iTextSharp.text.Font(baseFont, 18f, iTextSharp.text.Font.BOLD, BaseColor.BLACK);

            Paragraph title = new Paragraph(baslik, titleFont);
            title.Alignment = Element.ALIGN_CENTER;
            doc.Add(title);
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
        public void ExportDataTableToPdf(string filePath)
        {
            Document doc = new Document();
            PdfWriter.GetInstance(doc, new FileStream(filePath, FileMode.Create));
            doc.Open();

            // Başlık
            iTextSharp.text.Font titleFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 18, BaseColor.BLACK);
            Paragraph title = new Paragraph("Görüsme Raporu", titleFont);
            title.Alignment = Element.ALIGN_CENTER;
            doc.Add(title);
            doc.Add(new Paragraph("\n"));

            iTextSharp.text.Font cellFont = FontFactory.GetFont(BaseFont.HELVETICA, 10, BaseColor.BLACK);
            iTextSharp.text.Font headerFont = FontFactory.GetFont(BaseFont.HELVETICA_BOLD, 10, BaseColor.WHITE);

            foreach (DataGridViewRow row in dgwGorusmeler.Rows)
            {
                // Görüşme Detayları Tablosu
                PdfPTable table = new PdfPTable(2);
                table.WidthPercentage = 100;
                table.SpacingBefore = 10;
                table.SpacingAfter = 10;

                // Hücreleri ekle
                //AddCell(table, "Görüsme Numarasi", row.Cells["meeting_id"].Value?.ToString(), cellFont, headerFont);
                AddCell(table, "Ögretmen Numarasi", teacherId.ToString(), cellFont, headerFont);
                AddCell(table, "Ögrenci Numarasi", row.Cells["student_id"].Value?.ToString(), cellFont, headerFont);
                AddCell(table, "Görüsme Türü", row.Cells["meetingType"].Value?.ToString(), cellFont, headerFont);
                AddCell(table, "Görusulen Kisi", row.Cells["performerName"].Value?.ToString(), cellFont, headerFont);
                AddCell(table, "Tarih", row.Cells["meeting_date"].Value?.ToString(), cellFont, headerFont);
                //AddCell(table, "Konu", row.Cells["meetingSubject"].Value?.ToString(), cellFont, headerFont);
                AddCell(table, "Aciklama", row.Cells["meetingExplanation"].Value?.ToString(), cellFont, headerFont);
                //AddCell(table, "Planlama", row.Cells["meetingPlanning"].Value?.ToString(), cellFont, headerFont);
                //AddCell(table, "Notlar", row.Cells["meetingNotes"].Value?.ToString(), cellFont, headerFont);

                doc.Add(table);
                doc.Add(new Paragraph("\n"));
            }

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
        private void CreateFilteredMeetingsPdfReport(string filePath)
        {
            Document doc = new Document();
            PdfWriter writer = PdfWriter.GetInstance(doc, new FileStream(filePath, FileMode.Create));

            var teacher = ent.Teacher.FirstOrDefault(t => t.teacher_id == this.teacherId);
            string teacherName = teacher?.name;
            PdfPageEvents pageEvents = new PdfPageEvents(teacherName);
            writer.PageEvent = pageEvents;

            doc.Open();

            // Öğrenci isimlerini takip etmek için bir liste oluştur
            List<string> processedStudents = new List<string>();

            // DataGridView'deki her öğrenci için döngü
            foreach (DataGridViewRow studentRow in dgwGorusmeler.Rows)
            {
                string studentId = studentRow.Cells["student_id"].Value?.ToString();

                // Eğer bu öğrenci daha önce işlenmişse, devam et
                if (processedStudents.Contains(studentId))
                    continue;

                processedStudents.Add(studentId);

                // Başlık
                BaseFont baseFont = BaseFont.CreateFont(@"C:\Windows\Fonts\arial.ttf", BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
                iTextSharp.text.Font titleFont = new iTextSharp.text.Font(baseFont, 12f, iTextSharp.text.Font.BOLD, BaseColor.BLACK);

                // Başlık
                var studentInfo = ent.Student
                    .Where(s => s.student_id.ToString() == studentId)
                    .Select(s => new
                    {
                        StudentClass = s.@class,
                        StudentNumber = s.student_id,
                        TeacherName = ent.Teacher.FirstOrDefault(t => t.teacher_id == s.teacher_id).name,
                        StudentName = s.name
                    })
                    .FirstOrDefault(); // Sadece bir öğrenci bilgisi alıyoruz
                Paragraph title = new Paragraph($"Görüşmeler - {studentInfo.StudentName}", titleFont);
                title.Alignment = Element.ALIGN_CENTER;
                doc.Add(title);
                doc.Add(new Paragraph("\n"));
                doc.Add(new Paragraph("\n"));
                doc.Add(new Paragraph("\n"));
                // Öğrenciye ait bilgileri al

                // Öğrenci bilgilerini içeren tabloyu oluştur
                PdfPTable infoTable = new PdfPTable(2);
                infoTable.WidthPercentage = 50;
                infoTable.HorizontalAlignment = Element.ALIGN_LEFT;

                // Bilgi hücrelerini ekleyin
                AddInfoCell(infoTable, "Öğrenci Numarası", studentInfo?.StudentNumber.ToString());
                AddInfoCell(infoTable, "Sınıf", studentInfo?.StudentClass);
                AddInfoCell(infoTable, "Öğretmen", studentInfo?.TeacherName);

                doc.Add(infoTable);
                doc.Add(new Paragraph("\n"));

                // Görüşmeler için tabloyu oluştur
                PdfPTable table = new PdfPTable(4); // Kolon sayısını görüşme bilgilerine göre ayarlayabilirsiniz
                table.WidthPercentage = 100;
                table.SpacingBefore = 10;
                table.SpacingAfter = 10;

                foreach (DataGridViewRow row in dgwGorusmeler.Rows)
                {
                    // Eğer bu satırın öğrenci adı istenen öğrenci adına eşitse, bu görüşmeyi rapora ekle
                    if (row.Cells["student_id"].Value?.ToString() == studentId)
                    {
                        AddCell(table, "Görüşme Türü", row.Cells["meetingType"].Value?.ToString());
                        AddCell(table, "Görüşülen Kişi", row.Cells["performerName"].Value?.ToString());
                        AddCell(table, "Tarih", row.Cells["meeting_date"].Value?.ToString());
                        table.CompleteRow(); // Satırı tamamla (gerekirse)
                        AddWideCell(table, "Görüşme İçeriği", row.Cells["meetingExplanation"].Value?.ToString());

                        // Boş bir satır ekleyebilirsiniz
                        PdfPCell emptyCell = new PdfPCell(new Phrase(" "));
                        emptyCell.Colspan = 4;
                        emptyCell.Border = PdfPCell.NO_BORDER;
                        table.AddCell(emptyCell);
                        table.AddCell(emptyCell);
                    }
                }

                doc.Add(table);
                doc.NewPage(); // Her öğrenci için yeni sayfa oluştur
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
        private void AddCell(PdfPTable table, string label, string value, iTextSharp.text.Font cellFont, iTextSharp.text.Font headerFont)
        {
            PdfPCell headerCell = new PdfPCell(new Phrase(label, headerFont));
            headerCell.BackgroundColor = new BaseColor(51, 51, 51);
            table.AddCell(headerCell);

            PdfPCell valueCell = new PdfPCell(new Phrase(value, cellFont));
            valueCell.BackgroundColor = BaseColor.WHITE;
            table.AddCell(valueCell);
        }
        public void ExportDataTableToExcel(string filePath)
        {
            using (ExcelPackage package = new ExcelPackage())
            {
                ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("Görüşmeler");

                // Başlıkları Ekle
                worksheet.Cells[1, 1].Value = "Görüşme Numarası";
                worksheet.Cells[1, 2].Value = "Öğretmen Numarası";
                worksheet.Cells[1, 3].Value = "Öğrenci Numarası";
                worksheet.Cells[1, 4].Value = "Görüşme Türü";
                worksheet.Cells[1, 5].Value = "Görüşmeyi Yapan";
                worksheet.Cells[1, 6].Value = "Tarih";
                worksheet.Cells[1, 7].Value = "Konu";
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
                foreach (DataGridViewRow dgvRow in dgwGorusmeler.Rows)
                {
                    worksheet.Cells[row, 1].Value = dgvRow.Cells["meeting_id"].Value?.ToString();
                    worksheet.Cells[row, 2].Value = teacherId;
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

        private void btnGorusmeSil_Click(object sender, EventArgs e)
        {
            if (dgwGorusmeler.SelectedRows.Count > 0)
            {
                int meetingId = (int)dgwGorusmeler.SelectedRows[0].Cells["meeting_id"].Value;
                var meetingToDelete = ent.Meeting.Find(meetingId);

                if (meetingToDelete != null)
                {
                    ent.Meeting.Remove(meetingToDelete);
                    ent.SaveChanges();
                    LoadMeetings();
                    MessageBox.Show("Görüşme başarıyla silindi.", "Silme İşlemi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Silmek için bir görüşme seçmelisiniz.", "Silme İşlemi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
     

        private void btnGorusmeDuzenle_Click(object sender, EventArgs e)
        {
            if (dgwGorusmeler.SelectedRows.Count > 0)
            {
                int meetingId = (int)dgwGorusmeler.SelectedRows[0].Cells["meeting_id"].Value;
                int studentId = (int)dgwGorusmeler.SelectedRows[0].Cells["student_id"].Value; // student_id sütununu alın

                GorusmeDuzenleForm gorusmeDuzenleForm = new GorusmeDuzenleForm(meetingId, studentId);
                gorusmeDuzenleForm.ShowDialog();
                LoadMeetings();
            }
            else
            {
                MessageBox.Show("Düzenlemek için bir görüşme seçmelisiniz.", "Düzenleme İşlemi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnGorusmeTumunuGoruntuleYonetici_Click(object sender, EventArgs e)
        {
            LoadMeetings();
        }

     

        private void tbxOgrenciNumarasi_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true; // Tuşun işlenmesini durdur
            }
        }

        private void lblOgretmenSecimiKaldir_Click(object sender, EventArgs e)
        {
            dgwRehberOgretmenler.ClearSelection();
        }

        private void label9_Click(object sender, EventArgs e)
        {
            dgwOgrenciler.ClearSelection();
        }

        private void btnYedekAl_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "Excel Files (*.xlsx)|*.xlsx|All Files (*.*)|*.*",
                FileName = "VeritabaniYedegi_" + DateTime.Now.ToString("yyyy-MM-dd") + ".xlsx"
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string[] tableNames = { "Book", "Meeting", "Meeting_Book_Recommendation", "Student", "Teacher" };

                using (ExcelPackage excelPackage = new ExcelPackage())
                {
                    foreach (string tableName in tableNames)
                    {
                        DataTable dataTable = GetDataTableFromEntity(tableName);

                        if (dataTable != null)
                        {
                            ExcelWorksheet worksheet = excelPackage.Workbook.Worksheets.Add(tableName);
                            worksheet.Cells["A1"].LoadFromDataTable(dataTable, true, TableStyles.Medium1);
                        }
                    }

                    FileInfo fileInfo = new FileInfo(saveFileDialog.FileName);
                    excelPackage.SaveAs(fileInfo);

                    MessageBox.Show("Veritabanı yedeği başarıyla Excel dosyası olarak kaydedildi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }

        }
        private DataTable GetDataTableFromEntity(string tableName)
        {
            DataTable dataTable = new DataTable(tableName);

            switch (tableName)
            {
                case "Book":
                    var books = ent.Book.ToList();
                    dataTable = ConvertToDataTable(books);
                    break;

                case "Meeting":
                    var meetings = ent.Meeting.ToList();
                    dataTable = ConvertToDataTable(meetings);
                    break;

                case "Meeting_Book_Recommendation":
                    var meetingBookRecommendations = ent.Meeting_Book_Recommendation.ToList();
                    dataTable = ConvertToDataTable(meetingBookRecommendations);
                    break;

                case "Student":
                    var students = ent.Student.ToList();
                    dataTable = ConvertToDataTable(students);
                    break;

                case "Teacher":
                    var teachers = ent.Teacher.ToList();
                    dataTable = ConvertToDataTable(teachers);
                    break;
            }

            return dataTable;
        }

        private DataTable ConvertToDataTable<T>(IList<T> data)
        {
            PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(typeof(T));
            DataTable table = new DataTable();

            foreach (PropertyDescriptor prop in properties)
            {
                table.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
            }

            foreach (T item in data)
            {
                DataRow row = table.NewRow();
                foreach (PropertyDescriptor prop in properties)
                {
                    row[prop.Name] = prop.GetValue(item) ?? DBNull.Value;
                }
                table.Rows.Add(row);
            }
            return table;
        }
    }
}
