namespace AcarAkademiRehberlik
{
    partial class AdminMesajiEkleForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdminMesajiEkleForm));
            this.tbxAdminMessage = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnMesajKaydet = new System.Windows.Forms.Button();
            this.llbClrMessage = new System.Windows.Forms.LinkLabel();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // tbxAdminMessage
            // 
            this.tbxAdminMessage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbxAdminMessage.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.tbxAdminMessage.Location = new System.Drawing.Point(50, 145);
            this.tbxAdminMessage.MaxLength = 300;
            this.tbxAdminMessage.Multiline = true;
            this.tbxAdminMessage.Name = "tbxAdminMessage";
            this.tbxAdminMessage.Size = new System.Drawing.Size(614, 159);
            this.tbxAdminMessage.TabIndex = 6;
            this.tbxAdminMessage.Text = "Lütfen metninizi girin...";
            this.tbxAdminMessage.Click += new System.EventHandler(this.tbxAdminMessage_Click);
            this.tbxAdminMessage.Enter += new System.EventHandler(this.tbxAdminMessage_Enter);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(102, 185);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 28);
            this.label1.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 408);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(664, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "*Acar Akademi Rehberlik Uygulaması ana sayfa mesajı içeriğini güncellemek için iç" +
    "eriği doldurun ve kaydedin.";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::AcarAkademiRehberlik.Properties.Resources.wtrmrkAcar;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox1.Location = new System.Drawing.Point(50, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(614, 127);
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // btnMesajKaydet
            // 
            this.btnMesajKaydet.Location = new System.Drawing.Point(407, 329);
            this.btnMesajKaydet.Name = "btnMesajKaydet";
            this.btnMesajKaydet.Size = new System.Drawing.Size(257, 43);
            this.btnMesajKaydet.TabIndex = 0;
            this.btnMesajKaydet.Text = "Kaydet";
            this.btnMesajKaydet.UseVisualStyleBackColor = true;
            this.btnMesajKaydet.Click += new System.EventHandler(this.btnMesajKaydet_Click);
            // 
            // llbClrMessage
            // 
            this.llbClrMessage.AutoSize = true;
            this.llbClrMessage.LinkColor = System.Drawing.Color.Black;
            this.llbClrMessage.Location = new System.Drawing.Point(47, 329);
            this.llbClrMessage.Name = "llbClrMessage";
            this.llbClrMessage.Size = new System.Drawing.Size(55, 16);
            this.llbClrMessage.TabIndex = 5;
            this.llbClrMessage.TabStop = true;
            this.llbClrMessage.Text = "Temizle";
            this.llbClrMessage.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llbClrMessage_LinkClicked);
            // 
            // AdminMesajiEkleForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(728, 433);
            this.Controls.Add(this.llbClrMessage);
            this.Controls.Add(this.btnMesajKaydet);
            this.Controls.Add(this.tbxAdminMessage);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AdminMesajiEkleForm";
            this.Text = "Acar Akademi - Uygulama Mesajı";
            this.Load += new System.EventHandler(this.AdminMesajiEkleForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbxAdminMessage;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnMesajKaydet;
        private System.Windows.Forms.LinkLabel llbClrMessage;
    }
}