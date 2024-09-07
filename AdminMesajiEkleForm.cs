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
    public partial class AdminMesajiEkleForm : Form
    {
        private Dbo_acarakademirehberlikEntities2 ent = new Dbo_acarakademirehberlikEntities2();
        public AdminMesajiEkleForm()
        {
            InitializeComponent();
        }

        private void llbClrMessage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            tbxAdminMessage.Clear();
        }

        private void tbxAdminMessage_Click(object sender, EventArgs e)
        {
           
        }
        public static void StyleButton(Button btn)
        {
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.BackColor = Color.FromArgb(234, 92, 47);
            btn.ForeColor = Color.White;
            btn.Font = new System.Drawing.Font("Segoe UI", 10, FontStyle.Bold);
            btn.FlatAppearance.MouseOverBackColor = Color.FromArgb(189, 78, 23);
            btn.FlatAppearance.MouseDownBackColor = Color.FromArgb(30, 100, 140);

        }

        private void AdminMesajiEkleForm_Load(object sender, EventArgs e)
        {
            StyleButton(btnMesajKaydet);
        }

        private void tbxAdminMessage_Enter(object sender, EventArgs e)
        {
            tbxAdminMessage.Clear();
        }

        private void btnMesajKaydet_Click(object sender, EventArgs e)
        {
            var messageRecord = ent.Message.FirstOrDefault(m => m.message_id == 1);

            if (messageRecord != null)
            {
                // Update the adminMessage with the content of tbxAdminMessage
                messageRecord.adminMessage = tbxAdminMessage.Text;

                // Save changes to the database
                ent.SaveChanges();

                MessageBox.Show($"Mesaj içeriği başarıyla güncellendi!", "Mesaj Kaydedildi!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show($"Mesaj içeriği güncellenemedi!", "Hata!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
