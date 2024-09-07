namespace AcarAkademiRehberlik
{
    partial class KitapOnerForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(KitapOnerForm));
            this.clbTanimliKaynaklar = new System.Windows.Forms.CheckedListBox();
            this.lbxSecilenKaynaklar = new System.Windows.Forms.ListBox();
            this.btnKaynakOner = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnKaynakAra = new System.Windows.Forms.Button();
            this.cbxKitapDers = new System.Windows.Forms.ComboBox();
            this.cbxKitapTuru = new System.Windows.Forms.ComboBox();
            this.cbxKitapAlan = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.lblTumKaynaklar = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // clbTanimliKaynaklar
            // 
            this.clbTanimliKaynaklar.FormattingEnabled = true;
            this.clbTanimliKaynaklar.Location = new System.Drawing.Point(69, 83);
            this.clbTanimliKaynaklar.Name = "clbTanimliKaynaklar";
            this.clbTanimliKaynaklar.Size = new System.Drawing.Size(495, 259);
            this.clbTanimliKaynaklar.TabIndex = 0;
            this.clbTanimliKaynaklar.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.clbTanimliKaynaklar_ItemCheck);
            // 
            // lbxSecilenKaynaklar
            // 
            this.lbxSecilenKaynaklar.FormattingEnabled = true;
            this.lbxSecilenKaynaklar.ItemHeight = 16;
            this.lbxSecilenKaynaklar.Location = new System.Drawing.Point(69, 420);
            this.lbxSecilenKaynaklar.Name = "lbxSecilenKaynaklar";
            this.lbxSecilenKaynaklar.Size = new System.Drawing.Size(495, 132);
            this.lbxSecilenKaynaklar.TabIndex = 1;
            // 
            // btnKaynakOner
            // 
            this.btnKaynakOner.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnKaynakOner.Location = new System.Drawing.Point(608, 420);
            this.btnKaynakOner.Name = "btnKaynakOner";
            this.btnKaynakOner.Size = new System.Drawing.Size(400, 69);
            this.btnKaynakOner.TabIndex = 2;
            this.btnKaynakOner.Text = "Seçilen Kaynakları Öner";
            this.btnKaynakOner.UseVisualStyleBackColor = true;
            this.btnKaynakOner.Click += new System.EventHandler(this.btnKaynakOner_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(66, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(124, 18);
            this.label1.TabIndex = 3;
            this.label1.Text = "Tanımlı Kaynaklar";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label4.Location = new System.Drawing.Point(18, 100);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(95, 18);
            this.label4.TabIndex = 5;
            this.label4.Text = "Kaynak Türü:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label5.Location = new System.Drawing.Point(18, 148);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 18);
            this.label5.TabIndex = 6;
            this.label5.Text = "Ders:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label10.Location = new System.Drawing.Point(18, 52);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(40, 18);
            this.label10.TabIndex = 11;
            this.label10.Text = "Alan:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnKaynakAra);
            this.groupBox1.Controls.Add(this.cbxKitapDers);
            this.groupBox1.Controls.Add(this.cbxKitapTuru);
            this.groupBox1.Controls.Add(this.cbxKitapAlan);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.groupBox1.Location = new System.Drawing.Point(608, 83);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(400, 259);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Kaynak Bilgileri";
            // 
            // btnKaynakAra
            // 
            this.btnKaynakAra.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnKaynakAra.Location = new System.Drawing.Point(214, 209);
            this.btnKaynakAra.Name = "btnKaynakAra";
            this.btnKaynakAra.Size = new System.Drawing.Size(180, 44);
            this.btnKaynakAra.TabIndex = 20;
            this.btnKaynakAra.Text = "Ara";
            this.btnKaynakAra.UseVisualStyleBackColor = true;
            this.btnKaynakAra.Click += new System.EventHandler(this.btnKaynakAra_Click);
            // 
            // cbxKitapDers
            // 
            this.cbxKitapDers.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxKitapDers.FormattingEnabled = true;
            this.cbxKitapDers.Items.AddRange(new object[] {
            "Türkçe",
            "Matematik",
            "Fizik",
            "Kimya",
            "Biyoloji",
            "Tarih",
            "Coğrafya",
            "Felsefe",
            "Türk Dili ve Edebiyatı",
            "Din Kültürü ve Ahlak Bilgisi",
            "İngilizce"});
            this.cbxKitapDers.Location = new System.Drawing.Point(132, 145);
            this.cbxKitapDers.Name = "cbxKitapDers";
            this.cbxKitapDers.Size = new System.Drawing.Size(242, 26);
            this.cbxKitapDers.TabIndex = 19;
            // 
            // cbxKitapTuru
            // 
            this.cbxKitapTuru.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxKitapTuru.FormattingEnabled = true;
            this.cbxKitapTuru.Items.AddRange(new object[] {
            "Soru Bankası",
            "Deneme Sınavı",
            "Branş Deneme Sınavı",
            "Konu Anlatım",
            "Video Defter",
            "Diğer"});
            this.cbxKitapTuru.Location = new System.Drawing.Point(132, 97);
            this.cbxKitapTuru.Name = "cbxKitapTuru";
            this.cbxKitapTuru.Size = new System.Drawing.Size(242, 26);
            this.cbxKitapTuru.TabIndex = 18;
            // 
            // cbxKitapAlan
            // 
            this.cbxKitapAlan.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxKitapAlan.FormattingEnabled = true;
            this.cbxKitapAlan.Items.AddRange(new object[] {
            "TYT",
            "AYT",
            "Diğer"});
            this.cbxKitapAlan.Location = new System.Drawing.Point(132, 49);
            this.cbxKitapAlan.Name = "cbxKitapAlan";
            this.cbxKitapAlan.Size = new System.Drawing.Size(242, 26);
            this.cbxKitapAlan.TabIndex = 17;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label6.Location = new System.Drawing.Point(66, 382);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(125, 18);
            this.label6.TabIndex = 14;
            this.label6.Text = "Seçilen Kaynaklar";
            // 
            // lblTumKaynaklar
            // 
            this.lblTumKaynaklar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblTumKaynaklar.AutoSize = true;
            this.lblTumKaynaklar.Location = new System.Drawing.Point(429, 361);
            this.lblTumKaynaklar.Name = "lblTumKaynaklar";
            this.lblTumKaynaklar.Size = new System.Drawing.Size(98, 16);
            this.lblTumKaynaklar.TabIndex = 21;
            this.lblTumKaynaklar.Text = "Tümünü Göster";
            this.lblTumKaynaklar.Click += new System.EventHandler(this.lblTumKaynaklar_Click);
            // 
            // KitapOnerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Snow;
            this.ClientSize = new System.Drawing.Size(1059, 606);
            this.Controls.Add(this.lblTumKaynaklar);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnKaynakOner);
            this.Controls.Add(this.lbxSecilenKaynaklar);
            this.Controls.Add(this.clbTanimliKaynaklar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "KitapOnerForm";
            this.Text = "Kaynak Öner!";
            this.Load += new System.EventHandler(this.KitapOnerForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckedListBox clbTanimliKaynaklar;
        private System.Windows.Forms.ListBox lbxSecilenKaynaklar;
        private System.Windows.Forms.Button btnKaynakOner;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cbxKitapAlan;
        private System.Windows.Forms.ComboBox cbxKitapTuru;
        private System.Windows.Forms.Button btnKaynakAra;
        private System.Windows.Forms.ComboBox cbxKitapDers;
        private System.Windows.Forms.Label lblTumKaynaklar;
    }
}