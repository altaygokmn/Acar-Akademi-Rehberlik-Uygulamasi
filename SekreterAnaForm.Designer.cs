namespace AcarAkademiRehberlik
{
    partial class SekreterAnaForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SekreterAnaForm));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.devamsızlıkİşlemleriToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.devamsızlıkBilgileriToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.çıkışYapToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lblTarih1 = new System.Windows.Forms.Label();
            this.lblSaat1 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(54)))), ((int)(((byte)(80)))));
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.devamsızlıkİşlemleriToolStripMenuItem,
            this.devamsızlıkBilgileriToolStripMenuItem,
            this.çıkışYapToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(0);
            this.menuStrip1.Size = new System.Drawing.Size(1269, 50);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // devamsızlıkİşlemleriToolStripMenuItem
            // 
            this.devamsızlıkİşlemleriToolStripMenuItem.AutoSize = false;
            this.devamsızlıkİşlemleriToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI Semibold", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.devamsızlıkİşlemleriToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.devamsızlıkİşlemleriToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("devamsızlıkİşlemleriToolStripMenuItem.Image")));
            this.devamsızlıkİşlemleriToolStripMenuItem.Name = "devamsızlıkİşlemleriToolStripMenuItem";
            this.devamsızlıkİşlemleriToolStripMenuItem.Size = new System.Drawing.Size(300, 50);
            this.devamsızlıkİşlemleriToolStripMenuItem.Text = "Devamsızlık İşlemleri";
            this.devamsızlıkİşlemleriToolStripMenuItem.Click += new System.EventHandler(this.devamsızlıkİşlemleriToolStripMenuItem_Click);
            // 
            // devamsızlıkBilgileriToolStripMenuItem
            // 
            this.devamsızlıkBilgileriToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI Semibold", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.devamsızlıkBilgileriToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.devamsızlıkBilgileriToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("devamsızlıkBilgileriToolStripMenuItem.Image")));
            this.devamsızlıkBilgileriToolStripMenuItem.Name = "devamsızlıkBilgileriToolStripMenuItem";
            this.devamsızlıkBilgileriToolStripMenuItem.Size = new System.Drawing.Size(257, 50);
            this.devamsızlıkBilgileriToolStripMenuItem.Text = "Devamsızlık Bilgileri";
            this.devamsızlıkBilgileriToolStripMenuItem.Click += new System.EventHandler(this.devamsızlıkBilgileriToolStripMenuItem_Click);
            // 
            // çıkışYapToolStripMenuItem
            // 
            this.çıkışYapToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.çıkışYapToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.çıkışYapToolStripMenuItem.Name = "çıkışYapToolStripMenuItem";
            this.çıkışYapToolStripMenuItem.Size = new System.Drawing.Size(90, 50);
            this.çıkışYapToolStripMenuItem.Text = "Çıkış Yap";
            this.çıkışYapToolStripMenuItem.Click += new System.EventHandler(this.çıkışYapToolStripMenuItem_Click);
            // 
            // lblTarih1
            // 
            this.lblTarih1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.lblTarih1.AutoSize = true;
            this.lblTarih1.BackColor = System.Drawing.Color.Transparent;
            this.lblTarih1.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblTarih1.ForeColor = System.Drawing.Color.Gray;
            this.lblTarih1.Location = new System.Drawing.Point(475, 607);
            this.lblTarih1.Name = "lblTarih1";
            this.lblTarih1.Size = new System.Drawing.Size(276, 37);
            this.lblTarih1.TabIndex = 23;
            this.lblTarih1.Text = "Pazartesi, 01.01.0001";
            this.lblTarih1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblSaat1
            // 
            this.lblSaat1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.lblSaat1.AutoSize = true;
            this.lblSaat1.BackColor = System.Drawing.Color.Transparent;
            this.lblSaat1.Font = new System.Drawing.Font("Verdana", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblSaat1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(92)))), ((int)(((byte)(47)))));
            this.lblSaat1.Location = new System.Drawing.Point(486, 510);
            this.lblSaat1.Name = "lblSaat1";
            this.lblSaat1.Size = new System.Drawing.Size(302, 97);
            this.lblSaat1.TabIndex = 22;
            this.lblSaat1.Text = "00:00";
            this.lblSaat1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // SekreterAnaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(1269, 696);
            this.Controls.Add(this.lblTarih1);
            this.Controls.Add(this.lblSaat1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SekreterAnaForm";
            this.Text = "Acar Akademi Rehberlik Uygulaması";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.SekreterAnaForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem devamsızlıkİşlemleriToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem devamsızlıkBilgileriToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem çıkışYapToolStripMenuItem;
        private System.Windows.Forms.Label lblTarih1;
        private System.Windows.Forms.Label lblSaat1;
        private System.Windows.Forms.Timer timer1;
    }
}