namespace AcarAkademiRehberlik
{
    partial class YoneticiGorusmeBilgileriForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(YoneticiGorusmeBilgileriForm));
            this.btnGorusmeSil = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblAramaYap = new System.Windows.Forms.Label();
            this.dtpGorusmeAralikBaslangicYonetici = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cbxGorusmeTuru = new System.Windows.Forms.ComboBox();
            this.dtpGorusmeAralikBitisYonetici = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dgwGorusmeler = new System.Windows.Forms.DataGridView();
            this.teacher_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.student_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.meetingType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.performerName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.meeting_date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.meetingExplanation = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label2 = new System.Windows.Forms.Label();
            this.tbxRehberOgretmenAdSoyad = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dgwRehberOgretmenler = new System.Windows.Forms.DataGridView();
            this.btnGorusmeRaporuIndir = new System.Windows.Forms.Button();
            this.btnGorusmeTumunuGoruntuleYonetici = new System.Windows.Forms.Button();
            this.btnGeriDon = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.tbxOgrenciNumarasi = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.dgwOgrenciler = new System.Windows.Forms.DataGridView();
            this.btnGorusmeDuzenle = new System.Windows.Forms.Button();
            this.lblOgretmenSecimiKaldir = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.btnYedekAl = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgwGorusmeler)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgwRehberOgretmenler)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgwOgrenciler)).BeginInit();
            this.SuspendLayout();
            // 
            // btnGorusmeSil
            // 
            this.btnGorusmeSil.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGorusmeSil.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnGorusmeSil.Location = new System.Drawing.Point(1424, 781);
            this.btnGorusmeSil.Name = "btnGorusmeSil";
            this.btnGorusmeSil.Size = new System.Drawing.Size(283, 49);
            this.btnGorusmeSil.TabIndex = 35;
            this.btnGorusmeSil.Text = "Seçili Görüşmeyi Sil";
            this.btnGorusmeSil.UseVisualStyleBackColor = true;
            this.btnGorusmeSil.Click += new System.EventHandler(this.btnGorusmeSil_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.lblAramaYap);
            this.groupBox1.Controls.Add(this.dtpGorusmeAralikBaslangicYonetici);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.cbxGorusmeTuru);
            this.groupBox1.Controls.Add(this.dtpGorusmeAralikBitisYonetici);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.groupBox1.Location = new System.Drawing.Point(606, 61);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1101, 119);
            this.groupBox1.TabIndex = 34;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filtrelemek için";
            // 
            // lblAramaYap
            // 
            this.lblAramaYap.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblAramaYap.AutoSize = true;
            this.lblAramaYap.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblAramaYap.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblAramaYap.Location = new System.Drawing.Point(968, 51);
            this.lblAramaYap.Name = "lblAramaYap";
            this.lblAramaYap.Size = new System.Drawing.Size(105, 28);
            this.lblAramaYap.TabIndex = 11;
            this.lblAramaYap.Text = "Arama Yap";
            this.lblAramaYap.Click += new System.EventHandler(this.lblAramaYap_Click);
            // 
            // dtpGorusmeAralikBaslangicYonetici
            // 
            this.dtpGorusmeAralikBaslangicYonetici.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.dtpGorusmeAralikBaslangicYonetici.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.dtpGorusmeAralikBaslangicYonetici.Location = new System.Drawing.Point(358, 49);
            this.dtpGorusmeAralikBaslangicYonetici.Name = "dtpGorusmeAralikBaslangicYonetici";
            this.dtpGorusmeAralikBaslangicYonetici.Size = new System.Drawing.Size(200, 27);
            this.dtpGorusmeAralikBaslangicYonetici.TabIndex = 10;
            this.dtpGorusmeAralikBaslangicYonetici.Value = new System.DateTime(2024, 6, 10, 0, 0, 0, 0);
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(151, 53);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(182, 20);
            this.label5.TabIndex = 9;
            this.label5.Text = "Aralık Başlangıç Tarihi:";
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(573, 53);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(95, 20);
            this.label4.TabIndex = 8;
            this.label4.Text = "Bitiş Tarihi:";
            // 
            // cbxGorusmeTuru
            // 
            this.cbxGorusmeTuru.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cbxGorusmeTuru.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxGorusmeTuru.FormattingEnabled = true;
            this.cbxGorusmeTuru.Items.AddRange(new object[] {
            "Öğrenci Görüşmesi",
            "Veli Görüşmesi",
            "Tümünü Göster"});
            this.cbxGorusmeTuru.Location = new System.Drawing.Point(170, 51);
            this.cbxGorusmeTuru.Name = "cbxGorusmeTuru";
            this.cbxGorusmeTuru.Size = new System.Drawing.Size(216, 28);
            this.cbxGorusmeTuru.TabIndex = 5;
            // 
            // dtpGorusmeAralikBitisYonetici
            // 
            this.dtpGorusmeAralikBitisYonetici.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.dtpGorusmeAralikBitisYonetici.Location = new System.Drawing.Point(683, 49);
            this.dtpGorusmeAralikBitisYonetici.Name = "dtpGorusmeAralikBitisYonetici";
            this.dtpGorusmeAralikBitisYonetici.Size = new System.Drawing.Size(200, 27);
            this.dtpGorusmeAralikBitisYonetici.TabIndex = 7;
            this.dtpGorusmeAralikBitisYonetici.Value = new System.DateTime(2024, 6, 10, 0, 0, 0, 0);
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(33, 54);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(122, 20);
            this.label6.TabIndex = 6;
            this.label6.Text = "Görüşme Türü:";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(33, 56);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(122, 20);
            this.label3.TabIndex = 6;
            this.label3.Text = "Görüşme Türü:";
            // 
            // dgwGorusmeler
            // 
            this.dgwGorusmeler.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(25)))), ((int)(((byte)(72)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgwGorusmeler.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgwGorusmeler.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgwGorusmeler.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.teacher_id,
            this.student_id,
            this.meetingType,
            this.performerName,
            this.meeting_date,
            this.meetingExplanation});
            this.dgwGorusmeler.Location = new System.Drawing.Point(519, 239);
            this.dgwGorusmeler.MultiSelect = false;
            this.dgwGorusmeler.Name = "dgwGorusmeler";
            this.dgwGorusmeler.ReadOnly = true;
            this.dgwGorusmeler.RowHeadersWidth = 51;
            this.dgwGorusmeler.RowTemplate.Height = 24;
            this.dgwGorusmeler.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgwGorusmeler.Size = new System.Drawing.Size(1206, 520);
            this.dgwGorusmeler.TabIndex = 33;
            // 
            // teacher_id
            // 
            this.teacher_id.DataPropertyName = "teacher_id";
            this.teacher_id.HeaderText = "Öğretmen Numarası";
            this.teacher_id.MinimumWidth = 6;
            this.teacher_id.Name = "teacher_id";
            this.teacher_id.ReadOnly = true;
            this.teacher_id.Width = 125;
            // 
            // student_id
            // 
            this.student_id.DataPropertyName = "student_id";
            this.student_id.HeaderText = "Öğrenci Numarası";
            this.student_id.MinimumWidth = 6;
            this.student_id.Name = "student_id";
            this.student_id.ReadOnly = true;
            this.student_id.Width = 125;
            // 
            // meetingType
            // 
            this.meetingType.DataPropertyName = "meetingType";
            this.meetingType.HeaderText = "Görüşme Türü";
            this.meetingType.MinimumWidth = 6;
            this.meetingType.Name = "meetingType";
            this.meetingType.ReadOnly = true;
            this.meetingType.Width = 125;
            // 
            // performerName
            // 
            this.performerName.DataPropertyName = "performerName";
            this.performerName.HeaderText = "Görüşülen Kişi";
            this.performerName.MinimumWidth = 6;
            this.performerName.Name = "performerName";
            this.performerName.ReadOnly = true;
            this.performerName.Width = 125;
            // 
            // meeting_date
            // 
            this.meeting_date.DataPropertyName = "meeting_date";
            this.meeting_date.HeaderText = "Tarih";
            this.meeting_date.MinimumWidth = 6;
            this.meeting_date.Name = "meeting_date";
            this.meeting_date.ReadOnly = true;
            this.meeting_date.Width = 125;
            // 
            // meetingExplanation
            // 
            this.meetingExplanation.DataPropertyName = "meetingExplanation";
            this.meetingExplanation.HeaderText = "Açıklama";
            this.meetingExplanation.MinimumWidth = 500;
            this.meetingExplanation.Name = "meetingExplanation";
            this.meetingExplanation.ReadOnly = true;
            this.meetingExplanation.Width = 500;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(180, 201);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 20);
            this.label2.TabIndex = 32;
            this.label2.Text = "Arama";
            // 
            // tbxRehberOgretmenAdSoyad
            // 
            this.tbxRehberOgretmenAdSoyad.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.tbxRehberOgretmenAdSoyad.Location = new System.Drawing.Point(254, 198);
            this.tbxRehberOgretmenAdSoyad.Name = "tbxRehberOgretmenAdSoyad";
            this.tbxRehberOgretmenAdSoyad.Size = new System.Drawing.Size(211, 27);
            this.tbxRehberOgretmenAdSoyad.TabIndex = 31;
            this.tbxRehberOgretmenAdSoyad.TextChanged += new System.EventHandler(this.tbxRehberOgretmenAdSoyad_TextChanged);
           
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(48, 158);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(215, 22);
            this.label1.TabIndex = 30;
            this.label1.Text = "Rehber Öğretmen Seçiniz";
            // 
            // dgwRehberOgretmenler
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(25)))), ((int)(((byte)(72)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgwRehberOgretmenler.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgwRehberOgretmenler.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgwRehberOgretmenler.Location = new System.Drawing.Point(52, 231);
            this.dgwRehberOgretmenler.MultiSelect = false;
            this.dgwRehberOgretmenler.Name = "dgwRehberOgretmenler";
            this.dgwRehberOgretmenler.ReadOnly = true;
            this.dgwRehberOgretmenler.RowHeadersWidth = 51;
            this.dgwRehberOgretmenler.RowTemplate.Height = 24;
            this.dgwRehberOgretmenler.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgwRehberOgretmenler.Size = new System.Drawing.Size(413, 206);
            this.dgwRehberOgretmenler.TabIndex = 29;
            this.dgwRehberOgretmenler.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgwRehberOgretmenler_CellClick);
            // 
            // btnGorusmeRaporuIndir
            // 
            this.btnGorusmeRaporuIndir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnGorusmeRaporuIndir.Location = new System.Drawing.Point(519, 782);
            this.btnGorusmeRaporuIndir.Name = "btnGorusmeRaporuIndir";
            this.btnGorusmeRaporuIndir.Size = new System.Drawing.Size(253, 49);
            this.btnGorusmeRaporuIndir.TabIndex = 36;
            this.btnGorusmeRaporuIndir.Text = "İndir";
            this.btnGorusmeRaporuIndir.UseVisualStyleBackColor = true;
            this.btnGorusmeRaporuIndir.Click += new System.EventHandler(this.btnGorusmeRaporuIndir_Click);
            // 
            // btnGorusmeTumunuGoruntuleYonetici
            // 
            this.btnGorusmeTumunuGoruntuleYonetici.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGorusmeTumunuGoruntuleYonetici.Location = new System.Drawing.Point(1418, 186);
            this.btnGorusmeTumunuGoruntuleYonetici.Name = "btnGorusmeTumunuGoruntuleYonetici";
            this.btnGorusmeTumunuGoruntuleYonetici.Size = new System.Drawing.Size(289, 47);
            this.btnGorusmeTumunuGoruntuleYonetici.TabIndex = 39;
            this.btnGorusmeTumunuGoruntuleYonetici.Text = "Tümünü Görüntüle";
            this.btnGorusmeTumunuGoruntuleYonetici.UseVisualStyleBackColor = true;
            this.btnGorusmeTumunuGoruntuleYonetici.Click += new System.EventHandler(this.btnGorusmeTumunuGoruntuleYonetici_Click);
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
            this.btnGeriDon.Size = new System.Drawing.Size(198, 48);
            this.btnGeriDon.TabIndex = 53;
            this.btnGeriDon.Text = "🡸      Geri Dön";
            this.btnGeriDon.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGeriDon.UseVisualStyleBackColor = false;
            this.btnGeriDon.Click += new System.EventHandler(this.btnGeriDon_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label7.Location = new System.Drawing.Point(180, 523);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(58, 20);
            this.label7.TabIndex = 57;
            this.label7.Text = "Arama";
            // 
            // tbxOgrenciNumarasi
            // 
            this.tbxOgrenciNumarasi.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.tbxOgrenciNumarasi.Location = new System.Drawing.Point(254, 520);
            this.tbxOgrenciNumarasi.Name = "tbxOgrenciNumarasi";
            this.tbxOgrenciNumarasi.Size = new System.Drawing.Size(211, 27);
            this.tbxOgrenciNumarasi.TabIndex = 56;
            this.tbxOgrenciNumarasi.TextChanged += new System.EventHandler(this.tbxOgrenciNumarasi_TextChanged);
            this.tbxOgrenciNumarasi.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbxOgrenciNumarasi_KeyPress);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label8.Location = new System.Drawing.Point(48, 472);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(135, 22);
            this.label8.TabIndex = 55;
            this.label8.Text = "Öğrenci Seçiniz";
            // 
            // dgwOgrenciler
            // 
            this.dgwOgrenciler.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(25)))), ((int)(((byte)(72)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgwOgrenciler.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgwOgrenciler.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgwOgrenciler.Location = new System.Drawing.Point(52, 553);
            this.dgwOgrenciler.MultiSelect = false;
            this.dgwOgrenciler.Name = "dgwOgrenciler";
            this.dgwOgrenciler.ReadOnly = true;
            this.dgwOgrenciler.RowHeadersWidth = 51;
            this.dgwOgrenciler.RowTemplate.Height = 24;
            this.dgwOgrenciler.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgwOgrenciler.Size = new System.Drawing.Size(429, 206);
            this.dgwOgrenciler.TabIndex = 54;
            this.dgwOgrenciler.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgwOgrenciler_CellClick);
            // 
            // btnGorusmeDuzenle
            // 
            this.btnGorusmeDuzenle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGorusmeDuzenle.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnGorusmeDuzenle.Location = new System.Drawing.Point(1135, 782);
            this.btnGorusmeDuzenle.Name = "btnGorusmeDuzenle";
            this.btnGorusmeDuzenle.Size = new System.Drawing.Size(283, 49);
            this.btnGorusmeDuzenle.TabIndex = 58;
            this.btnGorusmeDuzenle.Text = "Seçili Görüşmeyi Düzenle";
            this.btnGorusmeDuzenle.UseVisualStyleBackColor = true;
            this.btnGorusmeDuzenle.Click += new System.EventHandler(this.btnGorusmeDuzenle_Click);
            // 
            // lblOgretmenSecimiKaldir
            // 
            this.lblOgretmenSecimiKaldir.AutoSize = true;
            this.lblOgretmenSecimiKaldir.Location = new System.Drawing.Point(366, 457);
            this.lblOgretmenSecimiKaldir.Name = "lblOgretmenSecimiKaldir";
            this.lblOgretmenSecimiKaldir.Size = new System.Drawing.Size(85, 16);
            this.lblOgretmenSecimiKaldir.TabIndex = 59;
            this.lblOgretmenSecimiKaldir.Text = "Seçimi Kaldır";
            this.lblOgretmenSecimiKaldir.Click += new System.EventHandler(this.lblOgretmenSecimiKaldir_Click);
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(366, 782);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(85, 16);
            this.label9.TabIndex = 60;
            this.label9.Text = "Seçimi Kaldır";
            this.label9.Click += new System.EventHandler(this.label9_Click);
            // 
            // btnYedekAl
            // 
            this.btnYedekAl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnYedekAl.Location = new System.Drawing.Point(52, 838);
            this.btnYedekAl.Name = "btnYedekAl";
            this.btnYedekAl.Size = new System.Drawing.Size(283, 50);
            this.btnYedekAl.TabIndex = 61;
            this.btnYedekAl.Text = "Tümünü İndir";
            this.btnYedekAl.UseVisualStyleBackColor = true;
            this.btnYedekAl.Click += new System.EventHandler(this.btnYedekAl_Click);
            // 
            // YoneticiGorusmeBilgileriForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1797, 909);
            this.Controls.Add(this.btnYedekAl);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.lblOgretmenSecimiKaldir);
            this.Controls.Add(this.btnGorusmeDuzenle);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.tbxOgrenciNumarasi);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.dgwOgrenciler);
            this.Controls.Add(this.btnGeriDon);
            this.Controls.Add(this.btnGorusmeTumunuGoruntuleYonetici);
            this.Controls.Add(this.btnGorusmeSil);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dgwGorusmeler);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbxRehberOgretmenAdSoyad);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgwRehberOgretmenler);
            this.Controls.Add(this.btnGorusmeRaporuIndir);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "YoneticiGorusmeBilgileriForm";
            this.Text = "Acar Akademi Rehberlik Uygulaması";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.YoneticiGorusmeBilgileriForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgwGorusmeler)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgwRehberOgretmenler)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgwOgrenciler)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnGorusmeSil;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblAramaYap;
        private System.Windows.Forms.DateTimePicker dtpGorusmeAralikBaslangicYonetici;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbxGorusmeTuru;
        private System.Windows.Forms.DateTimePicker dtpGorusmeAralikBitisYonetici;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dgwGorusmeler;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbxRehberOgretmenAdSoyad;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgwRehberOgretmenler;
        private System.Windows.Forms.Button btnGorusmeRaporuIndir;
        private System.Windows.Forms.Button btnGorusmeTumunuGoruntuleYonetici;
        private System.Windows.Forms.Button btnGeriDon;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tbxOgrenciNumarasi;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DataGridView dgwOgrenciler;
        private System.Windows.Forms.Button btnGorusmeDuzenle;
        private System.Windows.Forms.Label lblOgretmenSecimiKaldir;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnYedekAl;
        private System.Windows.Forms.DataGridViewTextBoxColumn teacher_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn student_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn meetingType;
        private System.Windows.Forms.DataGridViewTextBoxColumn performerName;
        private System.Windows.Forms.DataGridViewTextBoxColumn meeting_date;
        private System.Windows.Forms.DataGridViewTextBoxColumn meetingExplanation;
    }
}