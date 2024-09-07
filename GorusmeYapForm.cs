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
    public partial class GorusmeYapForm : Form
    {
        private Dbo_acarEntities ent = new Dbo_acarEntities();
        private int teacherId;
        private Student selectedStudent;
        public GorusmeYapForm(int id)
        {
            InitializeComponent();
            this.teacherId = id;
        }

        private void btnKitapOnerFormAc_Click(object sender, EventArgs e)
        {
            if (selectedStudent == null)
            {
                MessageBox.Show("Lütfen bir öğrenci seçin.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            KitapOnerForm kitapOnerForm = new KitapOnerForm(selectedStudent.student_id);
            kitapOnerForm.ShowDialog();
        }


        private void btnGeriDon_Click(object sender, EventArgs e)
        {
            RehberlikOgretmeniAnaForm rehberlikOgretmeniAnaForm = new RehberlikOgretmeniAnaForm(teacherId);
            rehberlikOgretmeniAnaForm.Show();
            this.Hide();
        }

        private void GorusmeYapForm_Load(object sender, EventArgs e)
        {
            LoadStudents();
            StyleDataGridView(dgwOgrenciler);
            StyleButton(btnGeriDon);
            StyleButton(btnKitapOnerFormAc);
            StyleButton(btnGorusmeYap);
            StyleButton(btnGeriDon);
            StyleDataGridView(dwgOgrencininEskiGorusmeleri);
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
        private void LoadStudents()
        {
            var ogrenciler = ent.Student
                                 .Where(s => s.teacher_id == teacherId)
                                 .Select(s => new { s.student_id, s.name })
                                 .ToList();

            dgwOgrenciler.DataSource = ogrenciler;
            dgwOgrenciler.Columns["student_id"].HeaderText = "Öğrenci Numarası";
            dgwOgrenciler.Columns["name"].HeaderText = "Öğrenci Adı";
        }

        private void tbxOgrenciAra_TextChanged(object sender, EventArgs e)
        {
            string aramaTermi = tbxOgrenciAra.Text.Trim();
            int studentId;

            try
            {
                if (int.TryParse(aramaTermi, out studentId))
                {
                    var ogrenciler = ent.Student
                                        .Where(s => s.teacher_id == teacherId && s.student_id.ToString().Contains(aramaTermi))
                                        .Select(s => new { s.student_id, s.name })
                                        .ToList();

                    dgwOgrenciler.DataSource = ogrenciler;
                }
                else
                {
                    LoadStudents();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgwOgrenciler_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int studentId = Convert.ToInt32(dgwOgrenciler.Rows[e.RowIndex].Cells["student_id"].Value);
                selectedStudent = ent.Student.FirstOrDefault(s => s.student_id == studentId);

                if (selectedStudent != null)
                {
                    lblOgrenciNumarasi.Text = selectedStudent.student_id.ToString();
                    lblAdSoyad.Text = selectedStudent.name;
                    lblOgrenciAdi.Text = selectedStudent.name;
                    lblOgrenciSinifi.Text = selectedStudent.@class;
                    lblOkulAdi.Text = selectedStudent.school;
                    lblYksSiralama.Text = selectedStudent.yksScore.ToString();
                    lblTytNeti.Text = selectedStudent.tytScore.ToString();
                    lblAytNeti.Text = selectedStudent.aytScore.ToString();
                    lblMsuNeti.Text = selectedStudent.msuScore.ToString();
                    lblHedef.Text = selectedStudent.purpose;
                    lblOgrenciTelefonNumarasi.Text = selectedStudent.phoneNumber;
                    lblVeli1Adi.Text = selectedStudent.parent1Name;
                    lblVeli1Yakinligi.Text = selectedStudent.parent1ParentalCloseness;
                    lblVeli1TelefonNumarasi.Text = selectedStudent.parent1PhoneNumber;
                    lblVeli2Adi.Text = selectedStudent.parent2Name;
                    lblVeli2Yakinligi.Text = selectedStudent.parent2ParentalCloseness;
                    lblVeli2TelefonNumarasi.Text = selectedStudent.parent2PhoneNumber;

                    dwgOgrencininEskiGorusmeleri.Visible = true;
                    LoadMeetings(selectedStudent.student_id);
                }
                cbxGorusmeGerceklestirenKisi.Items.Clear();
                if (selectedStudent != null && cbxGorusmeTuru.SelectedItem != null)
                {
                    if (cbxGorusmeTuru.SelectedItem.ToString() == "Veli Görüşmesi")
                    {
                        if (!string.IsNullOrEmpty(selectedStudent.parent1Name))
                            cbxGorusmeGerceklestirenKisi.Items.Add(selectedStudent.parent1Name);
                        if (!string.IsNullOrEmpty(selectedStudent.parent2Name))
                            cbxGorusmeGerceklestirenKisi.Items.Add(selectedStudent.parent2Name);
                    }
                    else if (cbxGorusmeTuru.SelectedItem.ToString() == "Öğrenci Görüşmesi")
                    {
                        cbxGorusmeGerceklestirenKisi.Items.Add(selectedStudent.name);
                        cbxGorusmeGerceklestirenKisi.Text = selectedStudent.name;
                    }
                    

                }
            }
        }
        private void LoadMeetings(int studentId)
        {
            var meetings = ent.Meeting
                              .Where(m => m.student_id == studentId)
                              .OrderByDescending(m => m.meeting_date)
                              .Select(m => new
                              {
                                  //m.meeting_id,
                                  meetingType = (m.meetingType == "Öğrenci Görüşmesi") ? "ÖG" :
                                        (m.meetingType == "Veli Görüşmesi") ? "VG" : m.meetingType,
                                  m.performerName,
                                  m.meeting_date,
                                  //m.meetingSubject,
                                  m.meetingExplanation,
                                  m.meetingPlanning,
                                  //m.meetingNotes
                              })
                              .ToList();

            dwgOgrencininEskiGorusmeleri.DataSource = meetings;
            //dwgOgrencininEskiGorusmeleri.Columns["meeting_id"].HeaderText = "Görüşme Numarası";
            dwgOgrencininEskiGorusmeleri.Columns["meetingType"].HeaderText = "GT";
            dwgOgrencininEskiGorusmeleri.Columns["performerName"].HeaderText = "Görüşülen Kişi";
            dwgOgrencininEskiGorusmeleri.Columns["meeting_date"].HeaderText = "Tarih";
            //dwgOgrencininEskiGorusmeleri.Columns["meetingSubject"].HeaderText = "Konu";
            dwgOgrencininEskiGorusmeleri.Columns["meetingExplanation"].HeaderText = "Açıklama";
            dwgOgrencininEskiGorusmeleri.Columns["meetingPlanning"].HeaderText = "Planlama";
            //dwgOgrencininEskiGorusmeleri.Columns["meetingNotes"].HeaderText = "Notlar";
        }
        private void cbxGorusmeTuru_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbxGorusmeGerceklestirenKisi.Items.Clear();
            if (selectedStudent != null)
            {
                if (cbxGorusmeTuru.SelectedItem.ToString() == "Veli Görüşmesi")
                {
                    if (!string.IsNullOrEmpty(selectedStudent.parent1Name))
                        cbxGorusmeGerceklestirenKisi.Items.Add(selectedStudent.parent1Name);
                    if (!string.IsNullOrEmpty(selectedStudent.parent2Name))
                        cbxGorusmeGerceklestirenKisi.Items.Add(selectedStudent.parent2Name);
                }
                else if (cbxGorusmeTuru.SelectedItem.ToString() == "Öğrenci Görüşmesi")
                {
                    cbxGorusmeGerceklestirenKisi.Items.Add(selectedStudent.name);
                    cbxGorusmeGerceklestirenKisi.Text = selectedStudent.name;
                }
                
            }
        }

        private void btnGorusmeYap_Click(object sender, EventArgs e)
        {
            try
            {
                if (selectedStudent == null)
                {
                    MessageBox.Show("Lütfen bir öğrenci seçin.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var newMeeting = new Meeting
                {
                    student_id = selectedStudent.student_id,
                    teacher_id = this.teacherId,
                    meetingType = cbxGorusmeTuru.SelectedItem?.ToString(),
                    performerName = cbxGorusmeGerceklestirenKisi.SelectedItem?.ToString(),
                    meeting_date = dtpGorusmeTarihi.Value.Date,
                    meetingSubject = "Bos Deger",
                    meetingExplanation = tbxGorusmeAciklamasi.Text,
                    meetingPlanning = tbxGorusmePlanlamasi.Text,
                    meetingNotes = "Bos Deger"
                };

                if (string.IsNullOrWhiteSpace(newMeeting.meetingType) || string.IsNullOrWhiteSpace(newMeeting.performerName) ||  string.IsNullOrWhiteSpace(newMeeting.meetingExplanation))
                {
                    MessageBox.Show("Lütfen tüm alanları doldurun.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                ent.Meeting.Add(newMeeting);
                ent.SaveChanges();

                int newMeetingId = newMeeting.meeting_id;
                lblGorusmeNumarasi.Text = $"Görüşme Numarası: {newMeetingId}";
                MessageBox.Show("Görüşme başarıyla eklendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadMeetings(selectedStudent.student_id);
                tbxGorusmeAciklamasi.Clear();
                tbxGorusmePlanlamasi.Clear();
                cbxGorusmeGerceklestirenKisi.SelectedIndex = -1;
                cbxGorusmeGerceklestirenKisi.SelectedIndex = -1;
                cbxGorusmeGerceklestirenKisi.Items.Clear();
                cbxGorusmeTuru.SelectedItem = -1;
                dgwOgrenciler.ClearSelection();
                dwgOgrencininEskiGorusmeleri.Visible = false;
                lblOgrenciNumarasi.Text = null;
                lblAdSoyad.Text = null;
                lblOgrenciAdi.Text = null;
                lblOgrenciSinifi.Text = null;
                lblOkulAdi.Text = null;
                lblYksSiralama.Text = null;
                lblTytNeti.Text = null;
                lblAytNeti.Text = null;
                lblMsuNeti.Text = null;
                lblHedef.Text = null;
                lblOgrenciTelefonNumarasi.Text = null;
                lblVeli1Adi.Text = null;
                lblVeli1Yakinligi.Text = null;
                lblVeli1TelefonNumarasi.Text = null;
                lblVeli2Adi.Text = null;
                lblVeli2Yakinligi.Text = null;
                lblVeli2TelefonNumarasi.Text = null;


            }
            catch (Exception ex)
            {
                MessageBox.Show($"Görüşme kaydedilirken hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void lblGorusmeTemizle_Click(object sender, EventArgs e)
        {
            
            cbxGorusmeGerceklestirenKisi.SelectedIndex = -1;
            dtpGorusmeTarihi.Value = DateTime.Now;
            //tbxGorusmeKonusu.Clear();
            tbxGorusmeAciklamasi.Clear();
            tbxGorusmePlanlamasi.Clear();
            //tbxGorusmeNotlari.Clear();
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

