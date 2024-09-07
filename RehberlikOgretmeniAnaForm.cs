using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AcarAkademiRehberlik
{
    public partial class RehberlikOgretmeniAnaForm : Form
    {
        private int teacherId;
        //private Dbo_acarEntities ent = new Dbo_acarEntities();
        private Dbo_acarRehberlikAkademiModel ent = new Dbo_acarRehberlikAkademiModel();
        private Teacher currentTeacher;
        public RehberlikOgretmeniAnaForm(int id)
        {
            InitializeComponent();
            this.teacherId = id;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            menuStrip1.Renderer = new CustomToolStripRenderer();

        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            GirisForm girisForm = new GirisForm();
            girisForm.Show();
            this.Hide();
        }

        private void RehberlikOgretmeniAnaForm_Load(object sender, EventArgs e)
        {
            LoadAdminMessage();
            timer1.Start();
            tbxAdminMessage.ForeColor = Color.White;
            tbxAdminMessage.Enabled = false;
            tbxAdminMessage.ForeColor = Color.White;
            tbxAdminMessage.BackColor = Color.White;
            UpdateTeacherStatistics();
            currentTeacher = ent.Teacher.FirstOrDefault(t => t.teacher_id == teacherId);
            if (currentTeacher != null && currentTeacher.role == 0)
            {
                toolStripMenuItem9.Visible = false;
                toolStripMenuItem10.Visible = false;
                toolStripMenuItem11.Visible = false;
                toolStripMenuItem7.Visible = false;

            }
            lblOgretmenAdi.Text = currentTeacher.name;
        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
          
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            ProfilForm profilForm = new ProfilForm(teacherId);
            profilForm.Show();
            this.Hide();
        }

        private void toolStripMenuItem6_Click(object sender, EventArgs e)
        {
            GorusmeYapForm gorusmeYapForm = new GorusmeYapForm(teacherId);
            gorusmeYapForm.Show();
            this.Hide();
        }

        private void görüşmeBilgileriToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GorusmeBilgileriForm gorusmeBilgileriForm = new GorusmeBilgileriForm(teacherId);
            gorusmeBilgileriForm.Show();
            this.Hide();
        }

        private void öğrenciİşlemleriToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OgrenciIslemleriForm ogrenciIslemleriForm = new OgrenciIslemleriForm(teacherId);
            ogrenciIslemleriForm.Show();
            this.Hide();
        }

        private void öğrenciBilgileriToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OgrenciBilgileriForm ogrenciBilgileriForm = new OgrenciBilgileriForm(teacherId);
            ogrenciBilgileriForm.Show();
            this.Hide();
        }

   

        private void toolStripMenuItem9_Click(object sender, EventArgs e)
        {
            KaynakForm kaynakForm = new KaynakForm(teacherId);
            kaynakForm.Show();
            this.Hide();
        }

        private void toolStripMenuItem10_Click(object sender, EventArgs e)
        {
            RehberOgretmenIslemleriForm rehberOgretmenIslemleriForm = new RehberOgretmenIslemleriForm(teacherId);
            rehberOgretmenIslemleriForm.Show();
            this.Hide();
        }

        private void toolStripMenuItem8_Click(object sender, EventArgs e)
        {
            RaporlarForm raporlarForm = new RaporlarForm(teacherId);
            raporlarForm.Show();
            this.Hide();
        }

        private void toolStripMenuItem11_Click(object sender, EventArgs e)
        {
            YoneticiGorusmeBilgileriForm yoneticiGorusmeBilgileriForm = new YoneticiGorusmeBilgileriForm(teacherId);
            yoneticiGorusmeBilgileriForm.Show();
            this.Hide();
        }

        private void toolStripMenuItem7_Click(object sender, EventArgs e)
        {
            YoneticiRaporlariForm yoneticiRaporlariForm = new YoneticiRaporlariForm(teacherId);
            yoneticiRaporlariForm.Show();
            this.Hide();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblSaat.Text = DateTime.Now.ToString("HH:mm");
            lblTarih.Text = DateTime.Now.ToString("dddd, dd MMMM yyyy");
        }
        private void UpdateTeacherStatistics()
        {
            var teacher = ent.Teacher.Find(teacherId);
            if (teacher != null)
            {
                // Öğrenci sayısını al
                int ogrenciSayisi = ent.Student.Count(s => s.teacher_id == teacherId);
                lblOgrenciSayisi.Text = ogrenciSayisi.ToString();

                // Görüşme sayısını al
                int toplamGorusmeSayisi = ent.Meeting.Count(m => m.teacher_id == teacherId);
                lblToplamGorusmeSayim.Text = toplamGorusmeSayisi.ToString();
            }
        }

        private void LoadAdminMessage()
        {
            using (var context = new Dbo_acarakademirehberlikEntities2())
            {
                var messageRecord = context.Message.FirstOrDefault();

                if (messageRecord != null)
                {
                    tbxAdminMessage.Text = messageRecord.adminMessage;
                }
                else
                {
                    tbxAdminMessage.Text = "No message found.";
                }
            }
        }
        public class CustomToolStripRenderer : ToolStripProfessionalRenderer
        {
            protected override void OnRenderMenuItemBackground(ToolStripItemRenderEventArgs e)
            {
                if (e.Item is ToolStripMenuItem menuItem)
                {
                    // Alt öğelerden biri seçili mi kontrol edin
                    bool hasSelectedDropDownItem = false;
                    if (menuItem.HasDropDownItems)
                    {
                        foreach (ToolStripItem dropDownItem in menuItem.DropDownItems)
                        {
                            if (dropDownItem.Selected)
                            {
                                hasSelectedDropDownItem = true;
                                break;
                            }
                        }
                    }

                    if (e.Item.Selected || hasSelectedDropDownItem)
                    {
                        Rectangle rect = new Rectangle(Point.Empty, e.Item.Size);
                        Color hoverColor = Color.FromArgb(234, 92, 47);
                        using (SolidBrush brush = new SolidBrush(hoverColor))
                        {
                            e.Graphics.FillRectangle(brush, rect);
                        }
                        e.Graphics.DrawRectangle(Pens.Gray, 1, 0, rect.Width - 2, rect.Height - 1);
                    }
                    else
                    {
                        base.OnRenderMenuItemBackground(e);
                    }
                }
                else
                {
                    base.OnRenderMenuItemBackground(e);
                }
            }

           

        }

        private void katılımBilgileriToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OgretmenKatilimBilgileriForm katilimBilgileriForm = new OgretmenKatilimBilgileriForm(teacherId);
            katilimBilgileriForm.Show();
            this.Hide();
        }

       
    }
}
