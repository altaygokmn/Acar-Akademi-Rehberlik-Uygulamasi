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
    public partial class SekreterAnaForm : Form
    {
        public SekreterAnaForm()
        {
            InitializeComponent();
            menuStrip1.Renderer = new CustomToolStripRenderer();
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            timer1.Start();
        }

       

        private void devamsızlıkİşlemleriToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SekreterForm sekreterForm = new SekreterForm();
            sekreterForm.Show();
            this.Hide();
        }

        private void devamsızlıkBilgileriToolStripMenuItem_Click(object sender, EventArgs e)
        {
            KatilimBilgileriForm katilimBilgileriForm = new KatilimBilgileriForm();
            katilimBilgileriForm.Show();
            this.Hide();
        }

        private void çıkışYapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SekreterGirisForm sekreterGirisForm = new SekreterGirisForm();
            sekreterGirisForm.Show();
                this.Hide();
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

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblSaat1.Text = DateTime.Now.ToString("HH:mm");
            lblTarih1.Text = DateTime.Now.ToString("dddd, dd MMMM yyyy");
        }

        private void SekreterAnaForm_Load(object sender, EventArgs e)
        {
            
        }

        
    }
}
