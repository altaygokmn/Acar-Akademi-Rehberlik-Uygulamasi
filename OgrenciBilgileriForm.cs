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
using System.Windows.Forms.DataVisualization.Charting;
using Rectangle = System.Drawing.Rectangle;
using Font = System.Drawing.Font;
using OfficeOpenXml;
using LicenseContext = OfficeOpenXml.LicenseContext;
using ClosedXML.Excel;

namespace AcarAkademiRehberlik
{
    public partial class OgrenciBilgileriForm : Form
    {
        //private Dbo_acarEntities ent = new Dbo_acarEntities();
        private Dbo_acarRehberlikAkademiModel ent = new Dbo_acarRehberlikAkademiModel();
        private int teacherId;
        public OgrenciBilgileriForm(int id)
        {
            InitializeComponent();
            this.teacherId = id;
            LoadStudents();
            ExcelPackage.LicenseContext = LicenseContext.Commercial;
            
        }

        private void btnGeriDon_Click(object sender, EventArgs e)
        {
            RehberlikOgretmeniAnaForm rehberlikOgretmeniAnaForm = new RehberlikOgretmeniAnaForm(teacherId);
            rehberlikOgretmeniAnaForm.Show();
            this.Hide();
        }

        private void btnGeriDon2_Click(object sender, EventArgs e)
        {
            RehberlikOgretmeniAnaForm rehberlikOgretmeniAnaForm = new RehberlikOgretmeniAnaForm(teacherId);
            rehberlikOgretmeniAnaForm.Show();
            this.Hide();
        }

        private void OgrenciBilgileriForm_Load(object sender, EventArgs e)
        {
            cbxAralik.SelectedIndex = 2;
            StyleButton(btnGeriDon);
            StyleButton(btnGeriDon2);
            StyleButton(btnOgrenciBilgileriIndir);
            //StyleButton(btnOgrenciNumarasiKopyala);
            StyleButton(btnTumOgrenciBilgileriniIndir);
            StyleDataGridView(dgwOgrencilerim);
            StyleListBox(lbxOgrenciOnerilenKaynaklar);
            ApplyModernStyle(this);
            ApplyModernStyle(chartAylikGorusmeSayisiOgrenci);
            ApplyModernStyle(chartAylikGorusmeSayisiVeli);
            StyleButton(btnAylikGorusmeSayisiOgrenciVeOgretmen);

        }
        public static void StyleListBox(ListBox listBox)
        {
            listBox.BorderStyle = BorderStyle.None;
            listBox.BackColor = Color.FromArgb(240, 240, 240);
            listBox.ForeColor = Color.FromArgb(40, 40, 40);
            listBox.Font = new System.Drawing.Font("Segoe UI", 10, FontStyle.Regular);
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
                        series.Color = Color.FromArgb(20,25,78); // Customize color
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
        private void dgwOgrencilerim_SelectionChanged(object sender, EventArgs e)
        {

            if (dgwOgrencilerim.SelectedRows.Count > 0)
            {
                int studentId = Convert.ToInt32(dgwOgrencilerim.SelectedRows[0].Cells["student_id"].Value);
                int selectedStudentId = Convert.ToInt32(dgwOgrencilerim.SelectedRows[0].Cells["student_id"].Value);
                string ogrenciAdSoyad = dgwOgrencilerim.SelectedRows[0].Cells["name"].Value.ToString();
                lblSeciliOgrenciAdSoyad.Text = ogrenciAdSoyad;
                
                //*********************
                var student = ent.Student.FirstOrDefault(s => s.student_id == studentId);
                if (student != null)
                {
                    lblOgrenciNumarasi.Text = student.student_id.ToString();
                    lblOdevNo.Text = student.homework_id.ToString();
                    lblOgrenciAdSoyad.Text = student.name;
                    lblOgrenciSinif.Text = student.@class;
                    lblOgrenciOkul.Text = student.school;
                    lblOgrenciTelefon.Text = student.phoneNumber;
                    lblYksSiralamasi.Text = student.yksScore.ToString();
                    lblTytNeti.Text = student.tytScore.ToString();
                    lblAytNeti.Text = student.aytScore.ToString();
                    lblMsuNeti.Text = student.msuScore.ToString();
                    lblOgrenciHedef.Text = student.purpose;
                    lblVeli1AdSoyad.Text = student.parent1Name;
                    lblVeli1Yakinlik.Text = student.parent1ParentalCloseness;
                    lblVeli1Telefon.Text = student.parent1PhoneNumber;
                    lblVeli2AdSoyad.Text = student.parent2Name;
                    lblVeli2Yakinlik.Text = student.parent2ParentalCloseness;
                    lblVeli2Telefon.Text = student.parent2PhoneNumber;

                    // Son Öğrenci Görüşme Tarihi
                    var sonOgrenciGorusme = ent.Meeting
                        .Where(m => m.meetingType == "Öğrenci Görüşmesi" && m.student_id == studentId)
                        .OrderByDescending(m => m.meeting_date)
                        .FirstOrDefault();
                    lblSonGorusmeTarihiOgrenci.Text = sonOgrenciGorusme?.meeting_date?.ToString("dd.MM.yyyy") ?? "-";

                    // Son Veli Görüşme Tarihi
                    var sonVeliGorusme = ent.Meeting
                        .Where(m => m.meetingType == "Veli Görüşmesi" && m.student_id == studentId)
                        .OrderByDescending(m => m.meeting_date)
                        .FirstOrDefault();
                    lblSonGorusmeTarihiVeli.Text = sonVeliGorusme?.meeting_date?.ToString("dd.MM.yyyy") ?? "-";

                    // Toplam Öğrenci Görüşme Sayısı
                    int toplamOgrenciGorusmeSayisi = ent.Meeting
                        .Where(m => m.meetingType == "Öğrenci Görüşmesi" && m.student_id == studentId)
                        .Count();
                    lblToplamGorusmeSayisiOgrenci.Text = toplamOgrenciGorusmeSayisi.ToString();

                    // Toplam Veli Görüşme Sayısı
                    int toplamVeliGorusmeSayisi = ent.Meeting
                        .Where(m => m.meetingType == "Veli Görüşmesi" && m.student_id == studentId)
                        .Count();
                    lblToplamGorusmeSayisiVeli.Text = toplamVeliGorusmeSayisi.ToString();

                    // Öğrenciye Önerilen Kitaplar
                    var kitapIds = ent.Meeting_Book_Recommendation
                        .Where(mbr => mbr.student_id == studentId)
                        .Select(mbr => mbr.book_id)
                        .ToList();

                    var kitaplar = ent.Book
                        .Where(b => kitapIds.Contains(b.book_id))
                        .Select(b => b.bookName)
                        .ToList();

                    lbxOgrenciOnerilenKaynaklar.DataSource = kitaplar;
                }
                DateTime startDate;
                string selectedPeriod = cbxAralik.SelectedItem?.ToString();

                if (selectedPeriod == "Son 6 Ay")
                {
                    startDate = DateTime.Now.AddMonths(-6);
                }
                else if (selectedPeriod == "Son 12 Ay")
                {
                    startDate = DateTime.Now.AddMonths(-12);
                }
                else if (selectedPeriod == "Tüm Zamanlar")
                {
                    startDate = DateTime.MinValue;
                }
                else
                {
                    return;
                }

                // Öğrenci Görüşmeleri
                var ogrenciGorusmeleri = ent.Meeting
                    .Where(m => m.student_id == selectedStudentId && m.meetingType == "Öğrenci Görüşmesi" && m.meeting_date >= startDate)
                    .ToList();

                // Veli Görüşmeleri
                var veliGorusmeleri = ent.Meeting
                    .Where(m => m.student_id == selectedStudentId && m.meetingType == "Veli Görüşmesi" && m.meeting_date >= startDate)
                    .ToList();

                // Öğrenci Görüşmeleri grafiğine veri ekleme
                if (!chartAylikGorusmeSayisiOgrenci.Series.Any(s => s.Name == "Görüşme Sayısı"))
                {
                    chartAylikGorusmeSayisiOgrenci.Series.Add("Görüşme Sayısı");
                }
                chartAylikGorusmeSayisiOgrenci.Series["Görüşme Sayısı"].Points.Clear();

                var ogrenciGorusmeAylik = ogrenciGorusmeleri
                    .Select(m => new
                    {
                        Year = m.meeting_date?.Year,
                        Month = m.meeting_date?.Month,
                        Count = 1
                    })
                    .GroupBy(m => new { m.Year, m.Month })
                    .Select(g => new { g.Key.Year, g.Key.Month, Count = g.Count() })
                    .ToList();

                foreach (var item in ogrenciGorusmeAylik)
                {
                    string label = $"{item.Month}/{item.Year}";
                    chartAylikGorusmeSayisiOgrenci.Series["Görüşme Sayısı"].Points.AddXY(label, item.Count);
                }

                // Veli Görüşmeleri grafiğine veri ekleme
                if (!chartAylikGorusmeSayisiVeli.Series.Any(s => s.Name == "Görüşme Sayısı"))
                {
                    chartAylikGorusmeSayisiVeli.Series.Add("Görüşme Sayısı");
                   
                }
                chartAylikGorusmeSayisiVeli.Series["Görüşme Sayısı"].Points.Clear();
                var veliGorusmeAylik = veliGorusmeleri
                    .Select(m => new
                    {
                        Year = m.meeting_date?.Year,
                        Month = m.meeting_date?.Month,
                        Count = 1
                    })
                    .GroupBy(m => new { m.Year, m.Month })
                    .Select(g => new { g.Key.Year, g.Key.Month, Count = g.Count() })
                    .ToList();

                foreach (var item in veliGorusmeAylik)
                {
                    string label = $"{item.Month}/{item.Year}";
                    chartAylikGorusmeSayisiVeli.Series["Görüşme Sayısı"].Points.AddXY(label, item.Count);
                }

                // Görüşme Türü Grafiği için veri hazırlama
                
                var gorismeTurleri = ent.Meeting
            .Where(m => m.student_id == selectedStudentId && m.meeting_date >= startDate)
            .GroupBy(m => m.meetingType)
            .Select(g => new { Tur = g.Key, Sayi = g.Count() })
            .ToList();

                if (!chartGorusmeTuruGrafigi.Series.Any(s => s.Name == "Görüşme Türü"))
                {
                    chartGorusmeTuruGrafigi.Series.Add("Görüşme Türü");
                }
                chartGorusmeTuruGrafigi.Series["Görüşme Türü"].Points.Clear();
                foreach (var item in gorismeTurleri)
                {
                    chartGorusmeTuruGrafigi.Series["Görüşme Türü"].Points.AddXY(item.Tur, item.Sayi);
                }

                // Görüşme Türü Grafiği Verileri
                chartGorusmeTuruGrafigi.Series["Görüşme Türü"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
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
                    s.name
                }).ToList();

            dgwOgrencilerim.DataSource = students;
        }
        private class PdfPageEvents : PdfPageEventHelper
        {
            private string teacherName;
            private BaseFont baseFont;
            private PdfContentByte cb;
            private PdfTemplate footerTemplate;
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
               
                
                cb.BeginText();
                cb.SetFontAndSize(baseFont, 10);
                cb.SetTextMatrix(document.PageSize.Width - 175, document.PageSize.Height - 50);
                cb.ShowText("Tarih: " + printTime.ToString("dd/MM/yyyy"));
                cb.SetTextMatrix(document.PageSize.Width - 175, document.PageSize.Height - 65);
                cb.ShowText("Rehber Öğretmen: " + teacherName);
                cb.EndText();
                

                // Tarih ve öğretmen adı ekle (her sayfada)
                    logoImage.SetAbsolutePosition(40, document.PageSize.Height - 100);
                    cb.AddImage(logoImage);
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
                cb.SetTextMatrix(document.PageSize.Width / 2 - len, document.PageSize.GetBottom(30));
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
        private void btnOgrenciNumarasiKopyala_Click(object sender, EventArgs e)
        {
            string ogrenciNumarasi = lblOgrenciNumarasi.Text;

            // Bu numarayı panoya kopyalayın
            if (!string.IsNullOrEmpty(ogrenciNumarasi))
            {
                Clipboard.SetText(ogrenciNumarasi);
                MessageBox.Show("Öğrenci numarası panoya kopyalandı.", "Kopyalandı", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Öğrenci numarası boş.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void CreateStudentPdfReport(string filePath, int studentId)
        {
            var teacher = ent.Teacher.FirstOrDefault(t => t.teacher_id == this.teacherId);
            string teacherName = teacher?.name;
            // Create a base font that supports Turkish characters
            BaseFont baseFont = BaseFont.CreateFont(@"C:\Windows\Fonts\arial.ttf", BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
            iTextSharp.text.Font boldFont = new iTextSharp.text.Font(baseFont, 12f, iTextSharp.text.Font.BOLD, BaseColor.BLACK);
            iTextSharp.text.Font regularFont = new iTextSharp.text.Font(baseFont, 12f, iTextSharp.text.Font.NORMAL, BaseColor.BLACK);

            Document doc = new Document();
            PdfWriter writer = PdfWriter.GetInstance(doc, new FileStream(filePath, FileMode.Create));

            // Burada PdfPageEvents sınıfını kullanıyoruz
            PdfPageEvents pageEvents = new PdfPageEvents(teacherName); // Öğretmen adını geçin
            writer.PageEvent = pageEvents;

            doc.Open();
            doc.Add(new Paragraph("\n"));
            doc.Add(new Paragraph("\n"));
            doc.Add(new Paragraph("\n"));
            doc.Add(new Paragraph("\n"));
            // Başlık
            doc.Add(new Paragraph($"Öğrenci Bilgileri - {lblOgrenciAdSoyad.Text}", boldFont));
            doc.Add(new Paragraph("\n"));

            // Öğrenci Bilgileri Tablosu
            PdfPTable table = new PdfPTable(2);
            table.AddCell(new PdfPCell(new Phrase("Bilgi", boldFont)) { BackgroundColor = BaseColor.LIGHT_GRAY });
            table.AddCell(new PdfPCell(new Phrase("Sonuç", boldFont)) { BackgroundColor = BaseColor.LIGHT_GRAY });

            // Öğrenci Bilgilerini Ekle
            table.AddCell(new PdfPCell(new Phrase("Öğrenci Numarası", boldFont)));
            table.AddCell(new PdfPCell(new Phrase(lblOgrenciNumarasi.Text, regularFont)));
            table.AddCell(new PdfPCell(new Phrase("Ödev Numarası", boldFont)));
            table.AddCell(new PdfPCell(new Phrase(lblOdevNo.Text, regularFont)));
            table.AddCell(new PdfPCell(new Phrase("Adı Soyadı", boldFont)));
            table.AddCell(new PdfPCell(new Phrase(lblOgrenciAdSoyad.Text, regularFont)));
            table.AddCell(new PdfPCell(new Phrase("Sınıf", boldFont)));
            table.AddCell(new PdfPCell(new Phrase(lblOgrenciSinif.Text, regularFont)));
            table.AddCell(new PdfPCell(new Phrase("Okul", boldFont)));
            table.AddCell(new PdfPCell(new Phrase(lblOgrenciOkul.Text, regularFont)));
            table.AddCell(new PdfPCell(new Phrase("Telefon", boldFont)));
            table.AddCell(new PdfPCell(new Phrase(lblOgrenciTelefon.Text, regularFont)));
            table.AddCell(new PdfPCell(new Phrase("YKS Sıralaması", boldFont)));
            table.AddCell(new PdfPCell(new Phrase(lblYksSiralamasi.Text, regularFont)));
            table.AddCell(new PdfPCell(new Phrase("TYT Neti", boldFont)));
            table.AddCell(new PdfPCell(new Phrase(lblTytNeti.Text, regularFont)));
            table.AddCell(new PdfPCell(new Phrase("AYT Neti", boldFont)));
            table.AddCell(new PdfPCell(new Phrase(lblAytNeti.Text, regularFont)));
            table.AddCell(new PdfPCell(new Phrase("Hedef", boldFont)));
            table.AddCell(new PdfPCell(new Phrase(lblOgrenciHedef.Text, regularFont)));
            table.AddCell(new PdfPCell(new Phrase("1. Veli Ad Soyad", boldFont)));
            table.AddCell(new PdfPCell(new Phrase(lblVeli1AdSoyad.Text, regularFont)));
            table.AddCell(new PdfPCell(new Phrase("1. Veli Yakınlığı", boldFont)));
            table.AddCell(new PdfPCell(new Phrase(lblVeli1Yakinlik.Text, regularFont)));
            table.AddCell(new PdfPCell(new Phrase("1. Veli Telefon", boldFont)));
            table.AddCell(new PdfPCell(new Phrase(lblVeli1Telefon.Text, regularFont)));
            table.AddCell(new PdfPCell(new Phrase("2. Veli Adı Soyadı", boldFont)));
            table.AddCell(new PdfPCell(new Phrase(lblVeli2AdSoyad.Text, regularFont)));
            table.AddCell(new PdfPCell(new Phrase("2. Veli Yakınlığı", boldFont)));
            table.AddCell(new PdfPCell(new Phrase(lblVeli2Yakinlik.Text, regularFont)));
            table.AddCell(new PdfPCell(new Phrase("2. Veli Telefon", boldFont)));
            table.AddCell(new PdfPCell(new Phrase(lblVeli2Telefon.Text, regularFont)));
            table.AddCell(new PdfPCell(new Phrase("Son Görüşme Tarihi (Öğrenci)", boldFont)));
            table.AddCell(new PdfPCell(new Phrase(lblSonGorusmeTarihiOgrenci.Text, regularFont)));
            table.AddCell(new PdfPCell(new Phrase("Son Görüşme Tarihi (Veli)", boldFont)));
            table.AddCell(new PdfPCell(new Phrase(lblSonGorusmeTarihiVeli.Text, regularFont)));
            table.AddCell(new PdfPCell(new Phrase("Toplam Öğrenci Görüşmesi", boldFont)));
            table.AddCell(new PdfPCell(new Phrase(lblToplamGorusmeSayisiOgrenci.Text, regularFont)));
            table.AddCell(new PdfPCell(new Phrase("Toplam Veli Görüşmesi", boldFont)));
            table.AddCell(new PdfPCell(new Phrase(lblToplamGorusmeSayisiVeli.Text, regularFont)));

            doc.Add(table);

            // Kitap Tavsiyeleri
            var kitaplar = lbxOgrenciOnerilenKaynaklar.Items.Cast<string>().ToList();
            doc.Add(new Paragraph("\nÖğrenciye Önerilen Kitaplar:", boldFont));
            foreach (var kitap in kitaplar)
            {
                doc.Add(new Paragraph($"- {kitap}", regularFont));
            }

            doc.Close();
        }


        private void cbxAralik_SelectedIndexChanged(object sender, EventArgs e)
        {
            dgwOgrencilerim_SelectionChanged(sender, e);
        }

        private void btnOgrenciBilgileriIndir_Click(object sender, EventArgs e)
        {
            if (dgwOgrencilerim.SelectedRows.Count > 0)
            {
                int studentId = Convert.ToInt32(dgwOgrencilerim.SelectedRows[0].Cells["student_id"].Value);
                SaveFileDialog saveFileDialog = new SaveFileDialog
                {
                    Filter = "PDF Files|*.pdf",
                    Title = "Öğrenci Bilgileri Raporu Kaydet"
                };

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = saveFileDialog.FileName;
                    CreateStudentPdfReport(filePath, studentId);
                    MessageBox.Show($"Öğrenci bilgileri başarıyla kaydedildi: {filePath}", "Rapor Kaydedildi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Lütfen bir öğrenci seçin.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void CreateAllStudentsPdfReport(string filePath, int teacherId)
        {
            var teacher = ent.Teacher.FirstOrDefault(t => t.teacher_id == teacherId);
            string teacherName = teacher?.name;
            Document doc = new Document();
            PdfWriter writer = PdfWriter.GetInstance(doc, new FileStream(filePath, FileMode.Create));
            PdfPageEvents pageEvents = new PdfPageEvents(teacherName);
            writer.PageEvent = pageEvents;
            doc.Open();

            // Arial fontunu ayarla
            BaseFont baseFont = BaseFont.CreateFont(@"C:\Windows\Fonts\arial.ttf", BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
            iTextSharp.text.Font titleFont = new iTextSharp.text.Font(baseFont, 18, iTextSharp.text.Font.NORMAL, BaseColor.BLACK);
            iTextSharp.text.Font boldFont = new iTextSharp.text.Font(baseFont, 10, iTextSharp.text.Font.BOLD, BaseColor.BLACK);
            iTextSharp.text.Font regularFont = new iTextSharp.text.Font(baseFont, 10, iTextSharp.text.Font.NORMAL, BaseColor.BLACK);

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
                    s.msuScore,
                    s.purpose,
                    s.parent1Name,
                    s.parent1ParentalCloseness,
                    s.parent1PhoneNumber,
                    s.parent2Name,
                    s.parent2ParentalCloseness,
                    s.parent2PhoneNumber
                }).ToList();

            foreach (var student in students)
            {
                // Başlık
                doc.Add(new Paragraph("\n\n\n\n")); // Sayfanın üst kısmında boşluk bırakmak için
                Paragraph title = new Paragraph($"Öğretmenin Tüm Öğrencileri - {teacherName}", titleFont)
                {
                    Alignment = Element.ALIGN_CENTER
                };
                doc.Add(title);
                doc.Add(new Paragraph("\n"));

                // Her öğrenci için yeni bir tablo oluştur
                PdfPTable studentTable = new PdfPTable(2) // 2 sütunlu tablo
                {
                    WidthPercentage = 100,
                    SpacingBefore = 10,
                    SpacingAfter = 10
                };

                // Tablonun sütun genişliklerini ayarla
                float[] columnWidths = { 2f, 3f };
                studentTable.SetWidths(columnWidths);

                // Öğrenci bilgileri için satırları ekle
                AddDetailRow(studentTable, "Öğrenci Numarası", student.student_id.ToString(), boldFont, regularFont);
                AddDetailRow(studentTable, "Ödev Numarası", student.homework_id.ToString(), boldFont, regularFont);
                AddDetailRow(studentTable, "Adı Soyadı", student.name, boldFont, regularFont);
                AddDetailRow(studentTable, "Sınıf", student.@class, boldFont, regularFont);
                AddDetailRow(studentTable, "Okul", student.school, boldFont, regularFont);
                AddDetailRow(studentTable, "Telefon", student.phoneNumber, boldFont, regularFont);
                AddDetailRow(studentTable, "YKS Sıralaması", student.yksScore.ToString(), boldFont, regularFont);
                AddDetailRow(studentTable, "TYT Neti", student.tytScore.ToString(), boldFont, regularFont);
                AddDetailRow(studentTable, "AYT Neti", student.msuScore.ToString(), boldFont, regularFont);
                AddDetailRow(studentTable, "Hedef", student.purpose, boldFont, regularFont);
                AddDetailRow(studentTable, "1. Veli Adı Soyadı", student.parent1Name, boldFont, regularFont);
                AddDetailRow(studentTable, "1. Veli Yakınlığı", student.parent1ParentalCloseness, boldFont, regularFont);
                AddDetailRow(studentTable, "1. Veli Telefon", student.parent1PhoneNumber, boldFont, regularFont);
                AddDetailRow(studentTable, "2. Veli Adı Soyadı", student.parent2Name, boldFont, regularFont);
                AddDetailRow(studentTable, "2. Veli Yakınlığı", student.parent2ParentalCloseness, boldFont, regularFont);
                AddDetailRow(studentTable, "2. Veli Telefon", student.parent2PhoneNumber, boldFont, regularFont);

                // Tablonun sonunda PDF'e tabloyu ekle ve yeni bir sayfaya geç
                doc.Add(studentTable);
                doc.NewPage();
            }

            doc.Close();
        }


        private void AddDetailRow(PdfPTable table, string label, string value, iTextSharp.text.Font labelFont, iTextSharp.text.Font valueFont)
        {
            PdfPCell labelCell = new PdfPCell(new Phrase(label, labelFont))
            {
                BackgroundColor = BaseColor.WHITE,
                Padding = 5
            };
            PdfPCell valueCell = new PdfPCell(new Phrase(value, valueFont))
            {
                Padding = 5
            };

            table.AddCell(labelCell);
            table.AddCell(valueCell);
        }

        private void AddBooksDetail(PdfPTable table, string label, List<string> books, iTextSharp.text.Font boldFont, iTextSharp.text.Font regularFont)
        {
            PdfPCell cell = new PdfPCell(new Phrase(label, boldFont));
            cell.BackgroundColor = new BaseColor(80,80,80); // Light gray background
            table.AddCell(cell);

            cell = new PdfPCell();
            foreach (var book in books)
            {
                cell.AddElement(new Phrase($"- {book}\n", regularFont));
            }
            cell.BackgroundColor = BaseColor.WHITE;
            table.AddCell(cell);
        }

        private string GetLastMeetingDate(string meetingType, int studentId)
        {
            var lastMeeting = ent.Meeting
                .Where(m => m.meetingType == meetingType && m.student_id == studentId)
                .OrderByDescending(m => m.meeting_date)
                .FirstOrDefault();

            return lastMeeting?.meeting_date?.ToString("dd.MM.yyyy") ?? "-";
        }

        private int GetMeetingCount(string meetingType, int studentId)
        {
            return ent.Meeting
                .Where(m => m.meetingType == meetingType && m.student_id == studentId)
                .Count();
        }

        private List<string> GetRecommendedBooks(int studentId)
        {
            var bookIds = ent.Meeting_Book_Recommendation
                .Where(mbr => mbr.student_id == studentId)
                .Select(mbr => mbr.book_id)
                .ToList();

            var books = ent.Book
                .Where(b => bookIds.Contains(b.book_id))
                .Select(b => b.bookName)
                .ToList();

            return books;
        }
        private void CreateMeetingCountsPdfReport(string filePath)
        {
            Document doc = new Document();
            PdfWriter writer = PdfWriter.GetInstance(doc, new FileStream(filePath, FileMode.Create));

            // Get the teacher's name
            var teacher = ent.Teacher.FirstOrDefault(t => t.teacher_id == this.teacherId);
            string teacherName = teacher?.name;

            // Set up the page events
            PdfPageEvents pageEvents = new PdfPageEvents(teacherName); // Pass the teacher's name
            writer.PageEvent = pageEvents;

            // Set up the custom font
            BaseFont baseFont = BaseFont.CreateFont(@"C:\Windows\Fonts\arial.ttf", BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
            iTextSharp.text.Font boldFont = new iTextSharp.text.Font(baseFont, 12f, iTextSharp.text.Font.NORMAL, BaseColor.BLACK);
            iTextSharp.text.Font regularFont = new iTextSharp.text.Font(baseFont, 12f, iTextSharp.text.Font.NORMAL, BaseColor.BLACK);
            iTextSharp.text.Font headerFont = new iTextSharp.text.Font(baseFont, 14f, iTextSharp.text.Font.NORMAL, BaseColor.BLACK);

            doc.Open();

            // Add content to the PDF
            doc.Add(new Paragraph("\n", regularFont));
            doc.Add(new Paragraph("\n", regularFont));
            doc.Add(new Paragraph("\n", regularFont));
            doc.Add(new Paragraph("\n", regularFont));
            doc.Add(new Paragraph("Aylık Toplam Görüşme Sayıları - Öğrenci ve Veli", headerFont));
            doc.Add(new Paragraph("\n", regularFont));

            PdfPTable table = new PdfPTable(3);
            table.AddCell(new PdfPCell(new Phrase("Yıl/Ay", regularFont)) { BackgroundColor = BaseColor.LIGHT_GRAY });
            table.AddCell(new PdfPCell(new Phrase("Öğrenci Görüşme Sayısı", regularFont)) { BackgroundColor = BaseColor.LIGHT_GRAY });
            table.AddCell(new PdfPCell(new Phrase("Veli Görüşme Sayısı", regularFont)) { BackgroundColor = BaseColor.LIGHT_GRAY });

            var studentMeetingCounts = GetMonthlyMeetingCounts("Öğrenci Görüşmesi");
            var parentMeetingCounts = GetMonthlyMeetingCounts("Veli Görüşmesi");

            foreach (var item in studentMeetingCounts)
            {
                string label = $"{item.Key.Month}/{item.Key.Year}";
                table.AddCell(new PdfPCell(new Phrase(label, regularFont)));
                table.AddCell(new PdfPCell(new Phrase(item.Value.ToString(), regularFont)));
                table.AddCell(new PdfPCell(new Phrase(parentMeetingCounts.ContainsKey(item.Key) ? parentMeetingCounts[item.Key].ToString() : "0", regularFont)));
            }

            doc.Add(table);
            doc.Close();
        }



        private void CreateMeetingCountsExcelReport(string filePath)
        {
            var workbook = new XLWorkbook();
            var worksheet = workbook.Worksheets.Add("Aylık Görüşme Sayıları");

            worksheet.Cell(1, 1).Value = "Yıl/Ay";
            worksheet.Cell(1, 2).Value = "Öğrenci Görüşme Sayısı";
            worksheet.Cell(1, 3).Value = "Veli Görüşme Sayısı";

            var studentMeetingCounts = GetMonthlyMeetingCounts("Öğrenci Görüşmesi");
            var parentMeetingCounts = GetMonthlyMeetingCounts("Veli Görüşmesi");

            int row = 2;
            foreach (var item in studentMeetingCounts)
            {
                string label = $"{item.Key.Month}/{item.Key.Year}";
                worksheet.Cell(row, 1).Value = label;
                worksheet.Cell(row, 2).Value = item.Value;
                worksheet.Cell(row, 3).Value = parentMeetingCounts.ContainsKey(item.Key) ? parentMeetingCounts[item.Key] : 0;
                row++;
            }

            workbook.SaveAs(filePath);
        }

        private Dictionary<(int Year, int Month), int> GetMonthlyMeetingCounts(string meetingType)
        {
            DateTime startDate;
            string selectedPeriod = cbxAralik.SelectedItem?.ToString();

            if (selectedPeriod == "Son 6 Ay")
            {
                startDate = DateTime.Now.AddMonths(-6);
            }
            else if (selectedPeriod == "Son 12 Ay")
            {
                startDate = DateTime.Now.AddMonths(-12);
            }
            else if (selectedPeriod == "Tüm Zamanlar")
            {
                startDate = DateTime.MinValue;
            }
            else
            {
                startDate = DateTime.MinValue;
            }

            var meetings = ent.Meeting
                .Where(m => m.meetingType == meetingType && m.meeting_date >= startDate)
                .ToList();

            var monthlyCounts = meetings
                .Select(m => new
                {
                    Year = m.meeting_date?.Year,
                    Month = m.meeting_date?.Month,
                    Count = 1
                })
                .GroupBy(m => new { m.Year, m.Month })
                .Select(g => new { g.Key.Year, g.Key.Month, Count = g.Count() })
                .ToDictionary(g => (g.Year.Value, g.Month.Value), g => g.Count);

            return monthlyCounts;
        }

        private void btnTumOgrenciBilgileriniIndir_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "PDF Files|*.pdf",
                Title = "Tüm Öğrenci Bilgilerini Kaydet"
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = saveFileDialog.FileName;
                CreateAllStudentsPdfReport(filePath, teacherId);
                MessageBox.Show($"Tüm öğrenci bilgileri başarıyla kaydedildi: {filePath}", "Rapor Kaydedildi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnAylikGorusmeSayisiOgrenciVeOgretmen_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "PDF Files|*.pdf|Excel Files|*.xlsx",
                Title = "Aylık Görüşme Sayıları Raporu Kaydet"
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = saveFileDialog.FileName;

                if (Path.GetExtension(filePath).ToLower() == ".pdf")
                {
                    CreateMeetingCountsPdfReport(filePath);
                }
                else if (Path.GetExtension(filePath).ToLower() == ".xlsx")
                {
                    CreateMeetingCountsExcelReport(filePath);
                }

                MessageBox.Show($"Aylık görüşme sayıları başarıyla kaydedildi: {filePath}", "Rapor Kaydedildi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void tbxOgrenciAra_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true; // Tuşun işlenmesini durdur
            }
        }
    }
}
