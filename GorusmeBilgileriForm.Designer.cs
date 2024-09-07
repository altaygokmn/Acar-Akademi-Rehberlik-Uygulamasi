namespace AcarAkademiRehberlik
{
    partial class GorusmeBilgileriForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GorusmeBilgileriForm));
            this.dgwOgrencilerim = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.tbxOgrenciNumarasi = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dgwGorusmeBilgileri = new System.Windows.Forms.DataGridView();
            this.cbxGorusmeTuru = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dtpGorusmeTarihiAralikBitis = new System.Windows.Forms.DateTimePicker();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblAramaYap = new System.Windows.Forms.Label();
            this.dtpGorusmeTarihiAralikBaslangic = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btnGorusmeSil = new System.Windows.Forms.Button();
            this.btnGeriDon = new System.Windows.Forms.Button();
            this.btnGorusmeRaporuIndir = new System.Windows.Forms.Button();
            this.btnPDFIndir = new System.Windows.Forms.Button();
            this.btnExcelIndir = new System.Windows.Forms.Button();
            this.btnGorusmeTumunuGoruntuleRehberOgretmen = new System.Windows.Forms.Button();
            this.btnGorusmeDuzenle = new System.Windows.Forms.Button();
            this.lblOgrenciSecimKaldir = new System.Windows.Forms.Label();
            this.student_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StudentName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.meetingType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.performerName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.meeting_date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.meetingExplanation = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgwOgrencilerim)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgwGorusmeBilgileri)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgwOgrencilerim
            // 
            this.dgwOgrencilerim.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(25)))), ((int)(((byte)(72)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(25)))), ((int)(((byte)(72)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgwOgrencilerim.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgwOgrencilerim.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgwOgrencilerim.Location = new System.Drawing.Point(49, 246);
            this.dgwOgrencilerim.MultiSelect = false;
            this.dgwOgrencilerim.Name = "dgwOgrencilerim";
            this.dgwOgrencilerim.ReadOnly = true;
            this.dgwOgrencilerim.RowHeadersVisible = false;
            this.dgwOgrencilerim.RowHeadersWidth = 51;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(92)))), ((int)(((byte)(47)))));
            this.dgwOgrencilerim.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgwOgrencilerim.RowTemplate.Height = 24;
            this.dgwOgrencilerim.Size = new System.Drawing.Size(413, 371);
            this.dgwOgrencilerim.TabIndex = 0;
            this.dgwOgrencilerim.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgwOgrencilerim_CellContentClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(45, 146);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(135, 22);
            this.label1.TabIndex = 1;
            this.label1.Text = "Öğrenci Seçiniz";
            // 
            // tbxOgrenciNumarasi
            // 
            this.tbxOgrenciNumarasi.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.tbxOgrenciNumarasi.Location = new System.Drawing.Point(251, 186);
            this.tbxOgrenciNumarasi.Name = "tbxOgrenciNumarasi";
            this.tbxOgrenciNumarasi.Size = new System.Drawing.Size(211, 27);
            this.tbxOgrenciNumarasi.TabIndex = 2;
            this.tbxOgrenciNumarasi.TextChanged += new System.EventHandler(this.tbxOgrenciNumarasi_TextChanged);
            this.tbxOgrenciNumarasi.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbxOgrenciNumarasi_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(177, 189);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Arama";
            // 
            // dgwGorusmeBilgileri
            // 
            this.dgwGorusmeBilgileri.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(25)))), ((int)(((byte)(72)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(25)))), ((int)(((byte)(72)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgwGorusmeBilgileri.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgwGorusmeBilgileri.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgwGorusmeBilgileri.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.student_id,
            this.StudentName,
            this.meetingType,
            this.performerName,
            this.meeting_date,
            this.meetingExplanation});
            this.dgwGorusmeBilgileri.Location = new System.Drawing.Point(510, 244);
            this.dgwGorusmeBilgileri.MultiSelect = false;
            this.dgwGorusmeBilgileri.Name = "dgwGorusmeBilgileri";
            this.dgwGorusmeBilgileri.ReadOnly = true;
            this.dgwGorusmeBilgileri.RowHeadersVisible = false;
            this.dgwGorusmeBilgileri.RowHeadersWidth = 51;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(92)))), ((int)(((byte)(47)))));
            this.dgwGorusmeBilgileri.RowsDefaultCellStyle = dataGridViewCellStyle7;
            this.dgwGorusmeBilgileri.RowTemplate.Height = 24;
            this.dgwGorusmeBilgileri.Size = new System.Drawing.Size(1183, 373);
            this.dgwGorusmeBilgileri.TabIndex = 4;
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
            this.cbxGorusmeTuru.SelectedIndexChanged += new System.EventHandler(this.cbxGorusmeTuru_SelectedIndexChanged);
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
            // dtpGorusmeTarihiAralikBitis
            // 
            this.dtpGorusmeTarihiAralikBitis.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.dtpGorusmeTarihiAralikBitis.Location = new System.Drawing.Point(765, 49);
            this.dtpGorusmeTarihiAralikBitis.Name = "dtpGorusmeTarihiAralikBitis";
            this.dtpGorusmeTarihiAralikBitis.Size = new System.Drawing.Size(200, 27);
            this.dtpGorusmeTarihiAralikBitis.TabIndex = 7;
            this.dtpGorusmeTarihiAralikBitis.Value = new System.DateTime(2024, 6, 10, 0, 0, 0, 0);
            this.dtpGorusmeTarihiAralikBitis.ValueChanged += new System.EventHandler(this.dtpGorusmeTarihiAralikBitis_ValueChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.lblAramaYap);
            this.groupBox1.Controls.Add(this.dtpGorusmeTarihiAralikBaslangic);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.cbxGorusmeTuru);
            this.groupBox1.Controls.Add(this.dtpGorusmeTarihiAralikBitis);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.groupBox1.Location = new System.Drawing.Point(510, 62);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1183, 119);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filtrelemek için";
            // 
            // lblAramaYap
            // 
            this.lblAramaYap.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblAramaYap.AutoSize = true;
            this.lblAramaYap.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblAramaYap.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblAramaYap.Location = new System.Drawing.Point(1050, 51);
            this.lblAramaYap.Name = "lblAramaYap";
            this.lblAramaYap.Size = new System.Drawing.Size(99, 22);
            this.lblAramaYap.TabIndex = 11;
            this.lblAramaYap.Text = "Arama Yap";
            this.lblAramaYap.Click += new System.EventHandler(this.lblAramaYap_Click);
            // 
            // dtpGorusmeTarihiAralikBaslangic
            // 
            this.dtpGorusmeTarihiAralikBaslangic.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.dtpGorusmeTarihiAralikBaslangic.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.dtpGorusmeTarihiAralikBaslangic.Location = new System.Drawing.Point(424, 49);
            this.dtpGorusmeTarihiAralikBaslangic.Name = "dtpGorusmeTarihiAralikBaslangic";
            this.dtpGorusmeTarihiAralikBaslangic.Size = new System.Drawing.Size(200, 27);
            this.dtpGorusmeTarihiAralikBaslangic.TabIndex = 10;
            this.dtpGorusmeTarihiAralikBaslangic.Value = new System.DateTime(2024, 6, 10, 0, 0, 0, 0);
            this.dtpGorusmeTarihiAralikBaslangic.ValueChanged += new System.EventHandler(this.dtpGorusmeTarihiAralikBaslangic_ValueChanged);
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(240, 53);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(135, 20);
            this.label5.TabIndex = 9;
            this.label5.Text = "Başlangıç Tarihi:";
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(655, 53);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(95, 20);
            this.label4.TabIndex = 8;
            this.label4.Text = "Bitiş Tarihi:";
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
            // btnGorusmeSil
            // 
            this.btnGorusmeSil.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGorusmeSil.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnGorusmeSil.Location = new System.Drawing.Point(1365, 655);
            this.btnGorusmeSil.Name = "btnGorusmeSil";
            this.btnGorusmeSil.Size = new System.Drawing.Size(328, 40);
            this.btnGorusmeSil.TabIndex = 9;
            this.btnGorusmeSil.Text = "Seçili Görüşmeyi Sil";
            this.btnGorusmeSil.UseVisualStyleBackColor = true;
            this.btnGorusmeSil.Click += new System.EventHandler(this.btnGorusmeSil_Click);
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
            // btnGorusmeRaporuIndir
            // 
            this.btnGorusmeRaporuIndir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnGorusmeRaporuIndir.Location = new System.Drawing.Point(510, 658);
            this.btnGorusmeRaporuIndir.Name = "btnGorusmeRaporuIndir";
            this.btnGorusmeRaporuIndir.Size = new System.Drawing.Size(245, 36);
            this.btnGorusmeRaporuIndir.TabIndex = 26;
            this.btnGorusmeRaporuIndir.Text = "İndir";
            this.btnGorusmeRaporuIndir.UseVisualStyleBackColor = true;
            this.btnGorusmeRaporuIndir.Click += new System.EventHandler(this.btnGorusmeRaporuIndir_Click);
            // 
            // btnPDFIndir
            // 
            this.btnPDFIndir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnPDFIndir.Location = new System.Drawing.Point(510, 655);
            this.btnPDFIndir.Name = "btnPDFIndir";
            this.btnPDFIndir.Size = new System.Drawing.Size(124, 39);
            this.btnPDFIndir.TabIndex = 27;
            this.btnPDFIndir.Text = "PDF";
            this.btnPDFIndir.UseVisualStyleBackColor = true;
            this.btnPDFIndir.Click += new System.EventHandler(this.btnPDFIndir_Click);
            // 
            // btnExcelIndir
            // 
            this.btnExcelIndir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnExcelIndir.Location = new System.Drawing.Point(631, 655);
            this.btnExcelIndir.Name = "btnExcelIndir";
            this.btnExcelIndir.Size = new System.Drawing.Size(124, 39);
            this.btnExcelIndir.TabIndex = 28;
            this.btnExcelIndir.Text = "Excel";
            this.btnExcelIndir.UseVisualStyleBackColor = true;
            this.btnExcelIndir.Click += new System.EventHandler(this.btnExcelIndir_Click);
            // 
            // btnGorusmeTumunuGoruntuleRehberOgretmen
            // 
            this.btnGorusmeTumunuGoruntuleRehberOgretmen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGorusmeTumunuGoruntuleRehberOgretmen.Location = new System.Drawing.Point(1441, 187);
            this.btnGorusmeTumunuGoruntuleRehberOgretmen.Name = "btnGorusmeTumunuGoruntuleRehberOgretmen";
            this.btnGorusmeTumunuGoruntuleRehberOgretmen.Size = new System.Drawing.Size(252, 51);
            this.btnGorusmeTumunuGoruntuleRehberOgretmen.TabIndex = 29;
            this.btnGorusmeTumunuGoruntuleRehberOgretmen.Text = "Tümünü Görüntüle";
            this.btnGorusmeTumunuGoruntuleRehberOgretmen.UseVisualStyleBackColor = true;
            this.btnGorusmeTumunuGoruntuleRehberOgretmen.Click += new System.EventHandler(this.btnGorusmeTumunuGoruntuleRehberOgretmen_Click);
            // 
            // btnGorusmeDuzenle
            // 
            this.btnGorusmeDuzenle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGorusmeDuzenle.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnGorusmeDuzenle.Location = new System.Drawing.Point(1038, 655);
            this.btnGorusmeDuzenle.Name = "btnGorusmeDuzenle";
            this.btnGorusmeDuzenle.Size = new System.Drawing.Size(321, 40);
            this.btnGorusmeDuzenle.TabIndex = 30;
            this.btnGorusmeDuzenle.Text = "Seçili Görüşmeyi Düzenle";
            this.btnGorusmeDuzenle.UseVisualStyleBackColor = true;
            this.btnGorusmeDuzenle.Click += new System.EventHandler(this.btnGorusmeDuzenle_Click);
            // 
            // lblOgrenciSecimKaldir
            // 
            this.lblOgrenciSecimKaldir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblOgrenciSecimKaldir.AutoSize = true;
            this.lblOgrenciSecimKaldir.Location = new System.Drawing.Point(46, 655);
            this.lblOgrenciSecimKaldir.Name = "lblOgrenciSecimKaldir";
            this.lblOgrenciSecimKaldir.Size = new System.Drawing.Size(85, 16);
            this.lblOgrenciSecimKaldir.TabIndex = 31;
            this.lblOgrenciSecimKaldir.Text = "Seçimi Kaldır";
            this.lblOgrenciSecimKaldir.Click += new System.EventHandler(this.lblOgrenciSecimKaldir_Click);
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
            // StudentName
            // 
            this.StudentName.DataPropertyName = "StudentName";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.StudentName.DefaultCellStyle = dataGridViewCellStyle4;
            this.StudentName.HeaderText = "Öğrenci";
            this.StudentName.MinimumWidth = 6;
            this.StudentName.Name = "StudentName";
            this.StudentName.ReadOnly = true;
            this.StudentName.Width = 125;
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
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.performerName.DefaultCellStyle = dataGridViewCellStyle5;
            this.performerName.HeaderText = "Görüşülen Kişi";
            this.performerName.MinimumWidth = 6;
            this.performerName.Name = "performerName";
            this.performerName.ReadOnly = true;
            this.performerName.Width = 125;
            // 
            // meeting_date
            // 
            this.meeting_date.DataPropertyName = "meeting_date";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.meeting_date.DefaultCellStyle = dataGridViewCellStyle6;
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
            // GorusmeBilgileriForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Snow;
            this.ClientSize = new System.Drawing.Size(1771, 729);
            this.Controls.Add(this.lblOgrenciSecimKaldir);
            this.Controls.Add(this.btnGorusmeDuzenle);
            this.Controls.Add(this.btnGorusmeTumunuGoruntuleRehberOgretmen);
            this.Controls.Add(this.btnExcelIndir);
            this.Controls.Add(this.btnGeriDon);
            this.Controls.Add(this.btnGorusmeSil);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dgwGorusmeBilgileri);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbxOgrenciNumarasi);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgwOgrencilerim);
            this.Controls.Add(this.btnGorusmeRaporuIndir);
            this.Controls.Add(this.btnPDFIndir);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "GorusmeBilgileriForm";
            this.Text = "Acar Akademi Rehberlik Uygulaması";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.GorusmeBilgileriForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgwOgrencilerim)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgwGorusmeBilgileri)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgwOgrencilerim;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbxOgrenciNumarasi;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgwGorusmeBilgileri;
        private System.Windows.Forms.ComboBox cbxGorusmeTuru;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtpGorusmeTarihiAralikBitis;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dtpGorusmeTarihiAralikBaslangic;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblAramaYap;
        private System.Windows.Forms.Button btnGorusmeSil;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnGeriDon;
        private System.Windows.Forms.Button btnGorusmeRaporuIndir;
        private System.Windows.Forms.Button btnPDFIndir;
        private System.Windows.Forms.Button btnExcelIndir;
        private System.Windows.Forms.Button btnGorusmeTumunuGoruntuleRehberOgretmen;
        private System.Windows.Forms.Button btnGorusmeDuzenle;
        private System.Windows.Forms.Label lblOgrenciSecimKaldir;
        private System.Windows.Forms.DataGridViewTextBoxColumn student_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn StudentName;
        private System.Windows.Forms.DataGridViewTextBoxColumn meetingType;
        private System.Windows.Forms.DataGridViewTextBoxColumn performerName;
        private System.Windows.Forms.DataGridViewTextBoxColumn meeting_date;
        private System.Windows.Forms.DataGridViewTextBoxColumn meetingExplanation;
    }
}