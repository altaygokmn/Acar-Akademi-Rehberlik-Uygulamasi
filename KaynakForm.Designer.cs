namespace AcarAkademiRehberlik
{
    partial class KaynakForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(KaynakForm));
            this.dgwKaynaklar = new System.Windows.Forms.DataGridView();
            this.bookName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.examArea = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bookType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.author = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bookClass = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnKaynakSil = new System.Windows.Forms.Button();
            this.btnKaynakEkle = new System.Windows.Forms.Button();
            this.cbxDers = new System.Windows.Forms.ComboBox();
            this.cbxKaynakTuru = new System.Windows.Forms.ComboBox();
            this.cbxAlan = new System.Windows.Forms.ComboBox();
            this.tbxYayincilik = new System.Windows.Forms.TextBox();
            this.tbxKaynakAdi = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnGeriDon = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgwKaynaklar)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgwKaynaklar
            // 
            this.dgwKaynaklar.Anchor = System.Windows.Forms.AnchorStyles.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(25)))), ((int)(((byte)(72)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(25)))), ((int)(((byte)(72)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgwKaynaklar.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgwKaynaklar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgwKaynaklar.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.bookName,
            this.examArea,
            this.bookType,
            this.author,
            this.bookClass});
            this.dgwKaynaklar.Location = new System.Drawing.Point(53, 131);
            this.dgwKaynaklar.MultiSelect = false;
            this.dgwKaynaklar.Name = "dgwKaynaklar";
            this.dgwKaynaklar.ReadOnly = true;
            this.dgwKaynaklar.RowHeadersWidth = 51;
            this.dgwKaynaklar.RowTemplate.Height = 24;
            this.dgwKaynaklar.Size = new System.Drawing.Size(940, 210);
            this.dgwKaynaklar.TabIndex = 0;
            // 
            // bookName
            // 
            this.bookName.DataPropertyName = "bookName";
            this.bookName.FillWeight = 150F;
            this.bookName.HeaderText = "Kaynak Adı";
            this.bookName.MinimumWidth = 100;
            this.bookName.Name = "bookName";
            this.bookName.ReadOnly = true;
            this.bookName.Width = 125;
            // 
            // examArea
            // 
            this.examArea.DataPropertyName = "examArea";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.examArea.DefaultCellStyle = dataGridViewCellStyle2;
            this.examArea.HeaderText = "Alan";
            this.examArea.MinimumWidth = 6;
            this.examArea.Name = "examArea";
            this.examArea.ReadOnly = true;
            this.examArea.Width = 125;
            // 
            // bookType
            // 
            this.bookType.DataPropertyName = "bookType";
            this.bookType.HeaderText = "Kaynak Türü";
            this.bookType.MinimumWidth = 6;
            this.bookType.Name = "bookType";
            this.bookType.ReadOnly = true;
            this.bookType.Width = 125;
            // 
            // author
            // 
            this.author.DataPropertyName = "author";
            this.author.HeaderText = "Yayıncılık";
            this.author.MinimumWidth = 6;
            this.author.Name = "author";
            this.author.ReadOnly = true;
            this.author.Width = 125;
            // 
            // bookClass
            // 
            this.bookClass.DataPropertyName = "bookClass";
            this.bookClass.HeaderText = "Ders";
            this.bookClass.MinimumWidth = 6;
            this.bookClass.Name = "bookClass";
            this.bookClass.ReadOnly = true;
            this.bookClass.Width = 125;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.groupBox1.Controls.Add(this.btnKaynakSil);
            this.groupBox1.Controls.Add(this.btnKaynakEkle);
            this.groupBox1.Controls.Add(this.cbxDers);
            this.groupBox1.Controls.Add(this.cbxKaynakTuru);
            this.groupBox1.Controls.Add(this.cbxAlan);
            this.groupBox1.Controls.Add(this.tbxYayincilik);
            this.groupBox1.Controls.Add(this.tbxKaynakAdi);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.groupBox1.Location = new System.Drawing.Point(53, 386);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(940, 259);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Kaynak Bilgileri";
            // 
            // btnKaynakSil
            // 
            this.btnKaynakSil.Location = new System.Drawing.Point(672, 199);
            this.btnKaynakSil.Name = "btnKaynakSil";
            this.btnKaynakSil.Size = new System.Drawing.Size(59, 51);
            this.btnKaynakSil.TabIndex = 20;
            this.btnKaynakSil.Text = "Sil";
            this.btnKaynakSil.UseVisualStyleBackColor = true;
            this.btnKaynakSil.Click += new System.EventHandler(this.btnKaynakSil_Click);
            // 
            // btnKaynakEkle
            // 
            this.btnKaynakEkle.Location = new System.Drawing.Point(737, 199);
            this.btnKaynakEkle.Name = "btnKaynakEkle";
            this.btnKaynakEkle.Size = new System.Drawing.Size(197, 51);
            this.btnKaynakEkle.TabIndex = 19;
            this.btnKaynakEkle.Text = "Tanımla";
            this.btnKaynakEkle.UseVisualStyleBackColor = true;
            this.btnKaynakEkle.Click += new System.EventHandler(this.btnKaynakEkle_Click);
            // 
            // cbxDers
            // 
            this.cbxDers.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxDers.FormattingEnabled = true;
            this.cbxDers.Items.AddRange(new object[] {
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
            this.cbxDers.Location = new System.Drawing.Point(173, 199);
            this.cbxDers.Name = "cbxDers";
            this.cbxDers.Size = new System.Drawing.Size(314, 31);
            this.cbxDers.TabIndex = 18;
            // 
            // cbxKaynakTuru
            // 
            this.cbxKaynakTuru.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxKaynakTuru.FormattingEnabled = true;
            this.cbxKaynakTuru.Items.AddRange(new object[] {
            "Soru Bankası",
            "Deneme Sınavı",
            "Branş Deneme Sınavı",
            "Konu Anlatım",
            "Video Defter",
            "Diğer"});
            this.cbxKaynakTuru.Location = new System.Drawing.Point(173, 119);
            this.cbxKaynakTuru.Name = "cbxKaynakTuru";
            this.cbxKaynakTuru.Size = new System.Drawing.Size(314, 31);
            this.cbxKaynakTuru.TabIndex = 17;
            // 
            // cbxAlan
            // 
            this.cbxAlan.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxAlan.FormattingEnabled = true;
            this.cbxAlan.Items.AddRange(new object[] {
            "TYT",
            "AYT",
            "Diğer"});
            this.cbxAlan.Location = new System.Drawing.Point(173, 81);
            this.cbxAlan.Name = "cbxAlan";
            this.cbxAlan.Size = new System.Drawing.Size(314, 31);
            this.cbxAlan.TabIndex = 16;
            // 
            // tbxYayincilik
            // 
            this.tbxYayincilik.Location = new System.Drawing.Point(173, 159);
            this.tbxYayincilik.Name = "tbxYayincilik";
            this.tbxYayincilik.Size = new System.Drawing.Size(314, 30);
            this.tbxYayincilik.TabIndex = 15;
            // 
            // tbxKaynakAdi
            // 
            this.tbxKaynakAdi.Location = new System.Drawing.Point(173, 43);
            this.tbxKaynakAdi.Name = "tbxKaynakAdi";
            this.tbxKaynakAdi.Size = new System.Drawing.Size(314, 30);
            this.tbxKaynakAdi.TabIndex = 12;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(46, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 18);
            this.label2.TabIndex = 4;
            this.label2.Text = "Kaynak Adı:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.Location = new System.Drawing.Point(59, 162);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 18);
            this.label3.TabIndex = 5;
            this.label3.Text = "Yayıncılık:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label10.Location = new System.Drawing.Point(91, 84);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(40, 18);
            this.label10.TabIndex = 11;
            this.label10.Text = "Alan:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label4.Location = new System.Drawing.Point(36, 122);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(95, 18);
            this.label4.TabIndex = 5;
            this.label4.Text = "Kaynak Türü:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label5.Location = new System.Drawing.Point(87, 202);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 18);
            this.label5.TabIndex = 6;
            this.label5.Text = "Ders:";
            // 
            // btnGeriDon
            // 
            this.btnGeriDon.BackColor = System.Drawing.Color.Transparent;
            this.btnGeriDon.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnGeriDon.FlatAppearance.BorderColor = System.Drawing.Color.Snow;
            this.btnGeriDon.FlatAppearance.BorderSize = 0;
            this.btnGeriDon.Font = new System.Drawing.Font("Franklin Gothic Book", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnGeriDon.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGeriDon.Location = new System.Drawing.Point(12, 12);
            this.btnGeriDon.Name = "btnGeriDon";
            this.btnGeriDon.Size = new System.Drawing.Size(199, 48);
            this.btnGeriDon.TabIndex = 25;
            this.btnGeriDon.Text = "🡸      Geri Dön";
            this.btnGeriDon.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGeriDon.UseVisualStyleBackColor = false;
            this.btnGeriDon.Click += new System.EventHandler(this.btnGeriDon_Click);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(50, 103);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(114, 16);
            this.label1.TabIndex = 26;
            this.label1.Text = "Tanımlı Kaynaklar";
            // 
            // KaynakForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1048, 741);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnGeriDon);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dgwKaynaklar);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "KaynakForm";
            this.Text = "Acar Akademi Rehberlik Uygulaması";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.KaynakForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgwKaynaklar)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgwKaynaklar;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbxAlan;
        private System.Windows.Forms.TextBox tbxKaynakAdi;
        private System.Windows.Forms.Button btnGeriDon;
        private System.Windows.Forms.ComboBox cbxKaynakTuru;
        private System.Windows.Forms.Button btnKaynakEkle;
        private System.Windows.Forms.ComboBox cbxDers;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbxYayincilik;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnKaynakSil;
        private System.Windows.Forms.DataGridViewTextBoxColumn bookName;
        private System.Windows.Forms.DataGridViewTextBoxColumn examArea;
        private System.Windows.Forms.DataGridViewTextBoxColumn bookType;
        private System.Windows.Forms.DataGridViewTextBoxColumn author;
        private System.Windows.Forms.DataGridViewTextBoxColumn bookClass;
    }
}