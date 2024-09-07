namespace AcarAkademiRehberlik
{
    partial class KatilimBilgileriForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(KatilimBilgileriForm));
            this.dgwOgrenciler = new System.Windows.Forms.DataGridView();
            this.dtpTarihAralikBaslangic = new System.Windows.Forms.DateTimePicker();
            this.dgwKatilimRaporu = new System.Windows.Forms.DataGridView();
            this.cbxSiniflar = new System.Windows.Forms.ComboBox();
            this.btnKatilimIndir = new System.Windows.Forms.Button();
            this.btnTumunuGoster = new System.Windows.Forms.Button();
            this.lblOgrenci = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbxOgrenciNumarasi = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.lblAramaYap = new System.Windows.Forms.Label();
            this.dtpTarihAralikBitis = new System.Windows.Forms.DateTimePicker();
            this.lblSecimiKaldir = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnTumunuSil = new System.Windows.Forms.Button();
            this.btnOgrenciKatılımRaporuIndir = new System.Windows.Forms.Button();
            this.btnGeriDon = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.btnSeciliKatilimSil = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgwOgrenciler)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgwKatilimRaporu)).BeginInit();
            this.SuspendLayout();
            // 
            // dgwOgrenciler
            // 
            this.dgwOgrenciler.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(25)))), ((int)(((byte)(72)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgwOgrenciler.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgwOgrenciler.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgwOgrenciler.Location = new System.Drawing.Point(65, 198);
            this.dgwOgrenciler.MultiSelect = false;
            this.dgwOgrenciler.Name = "dgwOgrenciler";
            this.dgwOgrenciler.ReadOnly = true;
            this.dgwOgrenciler.RowHeadersWidth = 51;
            this.dgwOgrenciler.RowTemplate.Height = 24;
            this.dgwOgrenciler.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgwOgrenciler.Size = new System.Drawing.Size(342, 346);
            this.dgwOgrenciler.TabIndex = 0;
            this.dgwOgrenciler.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgwOgrenciler_CellClick);
            this.dgwOgrenciler.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgwOgrenciler_CellContentClick);
            // 
            // dtpTarihAralikBaslangic
            // 
            this.dtpTarihAralikBaslangic.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpTarihAralikBaslangic.Location = new System.Drawing.Point(926, 101);
            this.dtpTarihAralikBaslangic.Name = "dtpTarihAralikBaslangic";
            this.dtpTarihAralikBaslangic.Size = new System.Drawing.Size(195, 22);
            this.dtpTarihAralikBaslangic.TabIndex = 1;
            this.dtpTarihAralikBaslangic.ValueChanged += new System.EventHandler(this.dtpTarihAralikBaslangic_ValueChanged);
            // 
            // dgwKatilimRaporu
            // 
            this.dgwKatilimRaporu.AllowUserToAddRows = false;
            this.dgwKatilimRaporu.AllowUserToDeleteRows = false;
            this.dgwKatilimRaporu.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(25)))), ((int)(((byte)(72)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgwKatilimRaporu.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgwKatilimRaporu.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgwKatilimRaporu.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgwKatilimRaporu.Location = new System.Drawing.Point(520, 198);
            this.dgwKatilimRaporu.MultiSelect = false;
            this.dgwKatilimRaporu.Name = "dgwKatilimRaporu";
            this.dgwKatilimRaporu.ReadOnly = true;
            this.dgwKatilimRaporu.RowHeadersVisible = false;
            this.dgwKatilimRaporu.RowHeadersWidth = 51;
            this.dgwKatilimRaporu.RowTemplate.Height = 24;
            this.dgwKatilimRaporu.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgwKatilimRaporu.Size = new System.Drawing.Size(816, 346);
            this.dgwKatilimRaporu.TabIndex = 2;
            this.dgwKatilimRaporu.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgwKatilimRaporu_CellContentClick);

            // 
            // cbxSiniflar
            // 
            this.cbxSiniflar.FormattingEnabled = true;
            this.cbxSiniflar.Location = new System.Drawing.Point(603, 147);
            this.cbxSiniflar.Name = "cbxSiniflar";
            this.cbxSiniflar.Size = new System.Drawing.Size(170, 24);
            this.cbxSiniflar.TabIndex = 3;
            this.cbxSiniflar.SelectedIndexChanged += new System.EventHandler(this.cbxSiniflar_SelectedIndexChanged);
            // 
            // btnKatilimIndir
            // 
            this.btnKatilimIndir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnKatilimIndir.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnKatilimIndir.Location = new System.Drawing.Point(1079, 580);
            this.btnKatilimIndir.Name = "btnKatilimIndir";
            this.btnKatilimIndir.Size = new System.Drawing.Size(257, 40);
            this.btnKatilimIndir.TabIndex = 4;
            this.btnKatilimIndir.Text = "İndir";
            this.btnKatilimIndir.UseVisualStyleBackColor = true;
            this.btnKatilimIndir.Click += new System.EventHandler(this.btnKatilimIndir_Click);
            // 
            // btnTumunuGoster
            // 
            this.btnTumunuGoster.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnTumunuGoster.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTumunuGoster.Location = new System.Drawing.Point(520, 580);
            this.btnTumunuGoster.Name = "btnTumunuGoster";
            this.btnTumunuGoster.Size = new System.Drawing.Size(257, 40);
            this.btnTumunuGoster.TabIndex = 5;
            this.btnTumunuGoster.Text = "Tümünü Göster";
            this.btnTumunuGoster.UseVisualStyleBackColor = true;
            this.btnTumunuGoster.Click += new System.EventHandler(this.btnTumunuGoster_Click);
            // 
            // lblOgrenci
            // 
            this.lblOgrenci.AutoSize = true;
            this.lblOgrenci.Location = new System.Drawing.Point(66, 109);
            this.lblOgrenci.Name = "lblOgrenci";
            this.lblOgrenci.Size = new System.Drawing.Size(91, 16);
            this.lblOgrenci.TabIndex = 6;
            this.lblOgrenci.Text = "Öğrenci Seçin";
            this.lblOgrenci.Click += new System.EventHandler(this.lblOgrenci_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(517, 150);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 16);
            this.label1.TabIndex = 7;
            this.label1.Text = "Sınıf:";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(758, 106);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(107, 16);
            this.label2.TabIndex = 8;
            this.label2.Text = "Başlangıç Tarihi:";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // tbxOgrenciNumarasi
            // 
            this.tbxOgrenciNumarasi.Location = new System.Drawing.Point(239, 150);
            this.tbxOgrenciNumarasi.Name = "tbxOgrenciNumarasi";
            this.tbxOgrenciNumarasi.Size = new System.Drawing.Size(172, 22);
            this.tbxOgrenciNumarasi.TabIndex = 11;
            this.tbxOgrenciNumarasi.TextChanged += new System.EventHandler(this.tbxOgrenciNumarasi_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(66, 153);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(118, 16);
            this.label4.TabIndex = 12;
            this.label4.Text = "Öğrenci Numarası:";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // lblAramaYap
            // 
            this.lblAramaYap.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblAramaYap.AutoSize = true;
            this.lblAramaYap.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblAramaYap.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblAramaYap.Location = new System.Drawing.Point(1164, 148);
            this.lblAramaYap.Name = "lblAramaYap";
            this.lblAramaYap.Size = new System.Drawing.Size(99, 22);
            this.lblAramaYap.TabIndex = 13;
            this.lblAramaYap.Text = "Arama Yap";
            this.lblAramaYap.Click += new System.EventHandler(this.lblAramaYap_Click);
            // 
            // dtpTarihAralikBitis
            // 
            this.dtpTarihAralikBitis.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpTarihAralikBitis.Location = new System.Drawing.Point(926, 150);
            this.dtpTarihAralikBitis.Name = "dtpTarihAralikBitis";
            this.dtpTarihAralikBitis.Size = new System.Drawing.Size(195, 22);
            this.dtpTarihAralikBitis.TabIndex = 14;
            this.dtpTarihAralikBitis.ValueChanged += new System.EventHandler(this.dtpTarihAralikBitis_ValueChanged);
            // 
            // lblSecimiKaldir
            // 
            this.lblSecimiKaldir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblSecimiKaldir.AutoSize = true;
            this.lblSecimiKaldir.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblSecimiKaldir.Location = new System.Drawing.Point(62, 572);
            this.lblSecimiKaldir.Name = "lblSecimiKaldir";
            this.lblSecimiKaldir.Size = new System.Drawing.Size(85, 16);
            this.lblSecimiKaldir.TabIndex = 15;
            this.lblSecimiKaldir.Text = "Seçimi Kaldır";
            this.lblSecimiKaldir.Click += new System.EventHandler(this.lblSecimiKaldir_Click);
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(758, 152);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(72, 16);
            this.label5.TabIndex = 16;
            this.label5.Text = "Bitiş Tarihi:";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // btnTumunuSil
            // 
            this.btnTumunuSil.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTumunuSil.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTumunuSil.Location = new System.Drawing.Point(1199, 646);
            this.btnTumunuSil.Name = "btnTumunuSil";
            this.btnTumunuSil.Size = new System.Drawing.Size(137, 40);
            this.btnTumunuSil.TabIndex = 17;
            this.btnTumunuSil.Text = "Tümünü Sil";
            this.btnTumunuSil.UseVisualStyleBackColor = true;
            this.btnTumunuSil.Click += new System.EventHandler(this.btnTumunuSil_Click);
            // 
            // btnOgrenciKatılımRaporuIndir
            // 
            this.btnOgrenciKatılımRaporuIndir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnOgrenciKatılımRaporuIndir.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOgrenciKatılımRaporuIndir.Location = new System.Drawing.Point(65, 613);
            this.btnOgrenciKatılımRaporuIndir.Name = "btnOgrenciKatılımRaporuIndir";
            this.btnOgrenciKatılımRaporuIndir.Size = new System.Drawing.Size(342, 40);
            this.btnOgrenciKatılımRaporuIndir.TabIndex = 18;
            this.btnOgrenciKatılımRaporuIndir.Text = "Öğrenci Katılım Rap. İndir";
            this.btnOgrenciKatılımRaporuIndir.UseVisualStyleBackColor = true;
            this.btnOgrenciKatılımRaporuIndir.Click += new System.EventHandler(this.btnOgrenciKatılımRaporuIndir_Click);
            // 
            // btnGeriDon
            // 
            this.btnGeriDon.Location = new System.Drawing.Point(12, 12);
            this.btnGeriDon.Name = "btnGeriDon";
            this.btnGeriDon.Size = new System.Drawing.Size(193, 62);
            this.btnGeriDon.TabIndex = 19;
            this.btnGeriDon.Text = "🡸      Geri Dön";
            this.btnGeriDon.UseVisualStyleBackColor = true;
            this.btnGeriDon.Click += new System.EventHandler(this.btnGeriDon_Click);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(758, 153);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 16);
            this.label3.TabIndex = 16;
            this.label3.Text = "Bitiş Tarihi:";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // btnSeciliKatilimSil
            // 
            this.btnSeciliKatilimSil.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSeciliKatilimSil.Location = new System.Drawing.Point(797, 580);
            this.btnSeciliKatilimSil.Name = "btnSeciliKatilimSil";
            this.btnSeciliKatilimSil.Size = new System.Drawing.Size(104, 40);
            this.btnSeciliKatilimSil.TabIndex = 40;
            this.btnSeciliKatilimSil.Text = "Sil";
            this.btnSeciliKatilimSil.UseVisualStyleBackColor = true;
            this.btnSeciliKatilimSil.Click += new System.EventHandler(this.btnSeciliKatilimSil_Click);
            // 
            // KatilimBilgileriForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1399, 698);
            this.Controls.Add(this.btnSeciliKatilimSil);
            this.Controls.Add(this.btnGeriDon);
            this.Controls.Add(this.btnOgrenciKatılımRaporuIndir);
            this.Controls.Add(this.btnTumunuSil);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lblSecimiKaldir);
            this.Controls.Add(this.dtpTarihAralikBitis);
            this.Controls.Add(this.lblAramaYap);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tbxOgrenciNumarasi);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblOgrenci);
            this.Controls.Add(this.btnTumunuGoster);
            this.Controls.Add(this.btnKatilimIndir);
            this.Controls.Add(this.cbxSiniflar);
            this.Controls.Add(this.dgwKatilimRaporu);
            this.Controls.Add(this.dtpTarihAralikBaslangic);
            this.Controls.Add(this.dgwOgrenciler);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "KatilimBilgileriForm";
            this.Text = "Acar Akademi Rehberlik Uygulaması";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.KatilimBilgileriForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgwOgrenciler)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgwKatilimRaporu)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgwOgrenciler;
        private System.Windows.Forms.DateTimePicker dtpTarihAralikBaslangic;
        private System.Windows.Forms.DataGridView dgwKatilimRaporu;
        private System.Windows.Forms.ComboBox cbxSiniflar;
        private System.Windows.Forms.Button btnKatilimIndir;
        private System.Windows.Forms.Button btnTumunuGoster;
        private System.Windows.Forms.Label lblOgrenci;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbxOgrenciNumarasi;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblAramaYap;
        private System.Windows.Forms.DateTimePicker dtpTarihAralikBitis;
        private System.Windows.Forms.Label lblSecimiKaldir;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnTumunuSil;
        private System.Windows.Forms.Button btnOgrenciKatılımRaporuIndir;
        private System.Windows.Forms.Button btnGeriDon;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnSeciliKatilimSil;
    }
}