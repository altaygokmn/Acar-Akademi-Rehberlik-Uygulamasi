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
    public partial class GorusmeDuzenleForm : Form
    {
        private Dbo_acarEntities ent = new Dbo_acarEntities();
        private int selectedMeetingId;
        private int studentId;

        public GorusmeDuzenleForm(int meetingId, int studentId)
        {
            InitializeComponent();
            this.selectedMeetingId = meetingId;
            this.studentId = studentId;
        }

        private void GorusmeDuzenleForm_Load(object sender, EventArgs e)
        {
            var meeting = ent.Meeting.FirstOrDefault(m => m.meeting_id == selectedMeetingId);
            if (meeting != null)
            {
                cbxGorusmeTuru.SelectedItem = meeting.meetingType;
                cbxGorusmeyiGerceklestirenKisi.SelectedItem = meeting.performerName;
                dtpGorusmeTarihi.Value = meeting.meeting_date ?? DateTime.Now;
                //tbxGorusmeKonusu.Text = meeting.meetingSubject;
                tbxGorusmeAciklamasi.Text = meeting.meetingExplanation;
                tbxGorusmePlanlamasi.Text = meeting.meetingPlanning;
                //tbxGorusmeNotlari.Text = meeting.meetingNotes;
                lblGorusmeNumarasi.Text = $"Görüşme Numarası: {meeting.meeting_id}";
            }

            UpdatePerformerList();
            StyleButton(btnGorusmeYap);
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
                    //textBox.Height = 30;
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
        private void UpdatePerformerList()
        {
            cbxGorusmeyiGerceklestirenKisi.Items.Clear();

            var student = ent.Student.FirstOrDefault(s => s.student_id == studentId);

            if (student != null)
            {
                if (cbxGorusmeTuru.SelectedItem != null && cbxGorusmeTuru.SelectedItem.ToString() == "Öğrenci Görüşmesi")
                {
                    cbxGorusmeyiGerceklestirenKisi.Items.Add(student.name);
                    cbxGorusmeyiGerceklestirenKisi.SelectedItem = student.name;
                }
                else if (cbxGorusmeTuru.SelectedItem != null && cbxGorusmeTuru.SelectedItem.ToString() == "Veli Görüşmesi")
                {   
                    
                    if (!string.IsNullOrEmpty(student.parent1Name))
                        cbxGorusmeyiGerceklestirenKisi.Items.Add(student.parent1Name);
                    if (!string.IsNullOrEmpty(student.parent2Name))
                        cbxGorusmeyiGerceklestirenKisi.Items.Add(student.parent2Name);
                }
            }
        }


        private void cbxGorusmeTuru_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdatePerformerList();
        }

        private void btnGorusmeYap_Click(object sender, EventArgs e)
        {
            var meeting = ent.Meeting.FirstOrDefault(m => m.meeting_id == selectedMeetingId);
            if (meeting != null)
            {
                cbxGorusmeyiGerceklestirenKisi.SelectedItem = meeting.performerName;
                meeting.meetingType = cbxGorusmeTuru.SelectedItem.ToString();
                meeting.performerName = cbxGorusmeyiGerceklestirenKisi.SelectedItem.ToString();
                meeting.meeting_date = dtpGorusmeTarihi.Value.Date;
                meeting.meetingSubject = "Bos Deger";
                meeting.meetingExplanation = tbxGorusmeAciklamasi.Text;
                meeting.meetingPlanning = tbxGorusmePlanlamasi.Text;
                meeting.meetingNotes = "Bos Deger";

                ent.SaveChanges();
                MessageBox.Show("Görüşme başarıyla güncellendi.", "Güncelleme Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
                
            }
        }

        private void lblGorusmeTemizle_Click(object sender, EventArgs e)
        {
            
            //tbxGorusmeKonusu.Clear();
            tbxGorusmeAciklamasi.Clear();
            tbxGorusmePlanlamasi.Clear();
            //tbxGorusmeNotlari.Clear();
        }
    }
}
