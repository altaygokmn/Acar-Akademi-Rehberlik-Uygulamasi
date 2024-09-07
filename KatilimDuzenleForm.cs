using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AcarAkademiRehberlik
{
    public partial class KatilimDuzenleForm : Form
    {
        private Dbo_acarakademirehberlikAppEntities ent = new Dbo_acarakademirehberlikAppEntities();
        private string studentId;
        private string date;

        public KatilimDuzenleForm(string date, string studentId, string studentName, string details)
        {
            InitializeComponent();

            this.date = date;
            this.studentId = studentId;

            lblDate.Text = date;
            lblStudentId.Text = studentId;
            lblStudentName.Text = studentName;
            tbxDetails.Text = details;
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

        private void KatilimDuzenleForm_Load(object sender, EventArgs e)
        {
            StyleButton(btnKatilimGuncelle);
        }

        private void btnKatilimGuncelle_Click(object sender, EventArgs e)
        {
            using (var context = new Dbo_acarakademirehberlikAppEntities())
            {
                var attendanceRecords = context.Attendance
     .Where(a => a.student_id.ToString() == studentId)
     .ToList(); // Fetch the data into memory first

                var attendanceRecord = attendanceRecords
                    .FirstOrDefault(a => a.attendance_date.HasValue &&
                                         a.attendance_date.Value.ToString("dd MMMM yyyy") == date);

                if (attendanceRecord != null)
                {
                    attendanceRecord.attendance_details = tbxDetails.Text;
                    context.SaveChanges();
                    MessageBox.Show("Katılım bilgisi güncellendi.", "Başarılı!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Güncelleme sırasında hata oluştu.");
                }
            }
            this.Close(); // Formu kapat
            
        }
    }
}
