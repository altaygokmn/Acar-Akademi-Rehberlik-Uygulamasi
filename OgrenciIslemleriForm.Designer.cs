namespace AcarAkademiRehberlik
{
    partial class OgrenciIslemleriForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OgrenciIslemleriForm));
            this.dgwOgrencilerim = new System.Windows.Forms.DataGridView();
            this.tbxOgrenciNumarasi = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnOgrenciEkle = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.tbxOgrenciAdSoyad = new System.Windows.Forms.TextBox();
            this.tbxOgrenciOkul = new System.Windows.Forms.TextBox();
            this.tbxOgrenciTelefon = new System.Windows.Forms.TextBox();
            this.tbxOgrenciHedef = new System.Windows.Forms.TextBox();
            this.tbxOgrenciMsuNeti = new System.Windows.Forms.TextBox();
            this.tbxOgrenciAytNeti = new System.Windows.Forms.TextBox();
            this.tbxOgrenciTytNeti = new System.Windows.Forms.TextBox();
            this.tbxOgrenciYksSiralama = new System.Windows.Forms.TextBox();
            this.tbxVeli1Telefon = new System.Windows.Forms.TextBox();
            this.tbxVeli1Yakinlik = new System.Windows.Forms.TextBox();
            this.tbxVeli1AdSoyad = new System.Windows.Forms.TextBox();
            this.tbxVeli2Telefon = new System.Windows.Forms.TextBox();
            this.tbxVeli2Yakinlik = new System.Windows.Forms.TextBox();
            this.tbxVeli2AdSoyad = new System.Windows.Forms.TextBox();
            this.btnOgrenciDuzenle = new System.Windows.Forms.Button();
            this.btnOgrenciSil = new System.Windows.Forms.Button();
            this.btnGeriDon = new System.Windows.Forms.Button();
            this.label17 = new System.Windows.Forms.Label();
            this.lblOgrenciAra = new System.Windows.Forms.Label();
            this.tbxOgrenciAra = new System.Windows.Forms.TextBox();
            this.lblTextBoxTemizle = new System.Windows.Forms.Label();
            this.btnDosyadanOgrenciEkle = new System.Windows.Forms.Button();
            this.cbxSinif = new System.Windows.Forms.ComboBox();
            this.label18 = new System.Windows.Forms.Label();
            this.tbxOdevNumarasi = new System.Windows.Forms.TextBox();
            this.student_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.homework_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sinif = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.school = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.phoneNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.yksScore = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tytScore = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.aytScore = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.msuScore = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.purpose = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.parent1Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.parent1ParentalCloseness = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.parent1PhoneNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.parent2Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.parent2ParentalCloseness = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.parent2PhoneNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgwOgrencilerim)).BeginInit();
            this.SuspendLayout();
            // 
            // dgwOgrencilerim
            // 
            this.dgwOgrencilerim.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(25)))), ((int)(((byte)(72)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgwOgrencilerim.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgwOgrencilerim.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgwOgrencilerim.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.student_id,
            this.homework_id,
            this.name,
            this.sinif,
            this.school,
            this.phoneNumber,
            this.yksScore,
            this.tytScore,
            this.aytScore,
            this.msuScore,
            this.purpose,
            this.parent1Name,
            this.parent1ParentalCloseness,
            this.parent1PhoneNumber,
            this.parent2Name,
            this.parent2ParentalCloseness,
            this.parent2PhoneNumber});
            this.dgwOgrencilerim.Location = new System.Drawing.Point(31, 76);
            this.dgwOgrencilerim.MultiSelect = false;
            this.dgwOgrencilerim.Name = "dgwOgrencilerim";
            this.dgwOgrencilerim.ReadOnly = true;
            this.dgwOgrencilerim.RowHeadersWidth = 51;
            this.dgwOgrencilerim.RowTemplate.Height = 24;
            this.dgwOgrencilerim.Size = new System.Drawing.Size(1672, 426);
            this.dgwOgrencilerim.TabIndex = 0;
            this.dgwOgrencilerim.SelectionChanged += new System.EventHandler(this.dgwOgrencilerim_SelectionChanged);
            // 
            // tbxOgrenciNumarasi
            // 
            this.tbxOgrenciNumarasi.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.tbxOgrenciNumarasi.Location = new System.Drawing.Point(233, 546);
            this.tbxOgrenciNumarasi.MaxLength = 9;
            this.tbxOgrenciNumarasi.Name = "tbxOgrenciNumarasi";
            this.tbxOgrenciNumarasi.Size = new System.Drawing.Size(269, 22);
            this.tbxOgrenciNumarasi.TabIndex = 1;
            this.tbxOgrenciNumarasi.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbxOgrenciNumarasi_KeyPress);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(51, 549);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(123, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "*Öğrenci Numarası:";
            // 
            // btnOgrenciEkle
            // 
            this.btnOgrenciEkle.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnOgrenciEkle.Location = new System.Drawing.Point(1400, 523);
            this.btnOgrenciEkle.Name = "btnOgrenciEkle";
            this.btnOgrenciEkle.Size = new System.Drawing.Size(269, 79);
            this.btnOgrenciEkle.TabIndex = 3;
            this.btnOgrenciEkle.Text = "Ekle";
            this.btnOgrenciEkle.UseVisualStyleBackColor = true;
            this.btnOgrenciEkle.Click += new System.EventHandler(this.btnOgrenciEkle_Click);
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(51, 624);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 16);
            this.label2.TabIndex = 4;
            this.label2.Text = "*Ad Soyad:";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(51, 659);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 16);
            this.label3.TabIndex = 5;
            this.label3.Text = "*Sınıf:";
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(51, 699);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 16);
            this.label4.TabIndex = 6;
            this.label4.Text = "*Okul:";
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(51, 735);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(61, 16);
            this.label5.TabIndex = 7;
            this.label5.Text = "*Telefon:";
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(573, 549);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(103, 16);
            this.label6.TabIndex = 8;
            this.label6.Text = "YKS Sıralaması:";
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(573, 586);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(64, 16);
            this.label7.TabIndex = 9;
            this.label7.Text = "TYT Neti:";
            // 
            // label8
            // 
            this.label8.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(573, 697);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(50, 16);
            this.label8.TabIndex = 10;
            this.label8.Text = "Hedefi:";
            // 
            // label9
            // 
            this.label9.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(573, 661);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(67, 16);
            this.label9.TabIndex = 11;
            this.label9.Text = "MSÜ Neti:";
            // 
            // label10
            // 
            this.label10.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(573, 624);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(64, 16);
            this.label10.TabIndex = 12;
            this.label10.Text = "AYT Neti:";
            // 
            // label11
            // 
            this.label11.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(1100, 549);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(109, 16);
            this.label11.TabIndex = 13;
            this.label11.Text = "1. Veli Ad Soyad:";
            // 
            // label12
            // 
            this.label12.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(1100, 586);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(96, 16);
            this.label12.TabIndex = 14;
            this.label12.Text = "1. Veli Yakınlık:";
            // 
            // label13
            // 
            this.label13.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(1100, 624);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(95, 16);
            this.label13.TabIndex = 15;
            this.label13.Text = "1. Veli Telefon:";
            // 
            // label14
            // 
            this.label14.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(1100, 753);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(95, 16);
            this.label14.TabIndex = 18;
            this.label14.Text = "2. Veli Telefon:";
            // 
            // label15
            // 
            this.label15.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(1100, 715);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(96, 16);
            this.label15.TabIndex = 17;
            this.label15.Text = "2. Veli Yakınlık:";
            // 
            // label16
            // 
            this.label16.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(1100, 678);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(109, 16);
            this.label16.TabIndex = 16;
            this.label16.Text = "2. Veli Ad Soyad:";
            // 
            // tbxOgrenciAdSoyad
            // 
            this.tbxOgrenciAdSoyad.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.tbxOgrenciAdSoyad.Location = new System.Drawing.Point(233, 618);
            this.tbxOgrenciAdSoyad.MaxLength = 25;
            this.tbxOgrenciAdSoyad.Name = "tbxOgrenciAdSoyad";
            this.tbxOgrenciAdSoyad.Size = new System.Drawing.Size(269, 22);
            this.tbxOgrenciAdSoyad.TabIndex = 19;
            this.tbxOgrenciAdSoyad.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbxOgrenciAdSoyad_KeyPress);
            // 
            // tbxOgrenciOkul
            // 
            this.tbxOgrenciOkul.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.tbxOgrenciOkul.Location = new System.Drawing.Point(233, 696);
            this.tbxOgrenciOkul.MaxLength = 50;
            this.tbxOgrenciOkul.Name = "tbxOgrenciOkul";
            this.tbxOgrenciOkul.Size = new System.Drawing.Size(269, 22);
            this.tbxOgrenciOkul.TabIndex = 21;
            // 
            // tbxOgrenciTelefon
            // 
            this.tbxOgrenciTelefon.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.tbxOgrenciTelefon.Location = new System.Drawing.Point(233, 732);
            this.tbxOgrenciTelefon.MaxLength = 10;
            this.tbxOgrenciTelefon.Name = "tbxOgrenciTelefon";
            this.tbxOgrenciTelefon.Size = new System.Drawing.Size(269, 22);
            this.tbxOgrenciTelefon.TabIndex = 22;
            this.tbxOgrenciTelefon.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbxOgrenciTelefon_KeyPress);
            // 
            // tbxOgrenciHedef
            // 
            this.tbxOgrenciHedef.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.tbxOgrenciHedef.Location = new System.Drawing.Point(741, 694);
            this.tbxOgrenciHedef.MaxLength = 25;
            this.tbxOgrenciHedef.Name = "tbxOgrenciHedef";
            this.tbxOgrenciHedef.Size = new System.Drawing.Size(289, 22);
            this.tbxOgrenciHedef.TabIndex = 27;
            // 
            // tbxOgrenciMsuNeti
            // 
            this.tbxOgrenciMsuNeti.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.tbxOgrenciMsuNeti.Location = new System.Drawing.Point(741, 658);
            this.tbxOgrenciMsuNeti.Name = "tbxOgrenciMsuNeti";
            this.tbxOgrenciMsuNeti.Size = new System.Drawing.Size(289, 22);
            this.tbxOgrenciMsuNeti.TabIndex = 26;
            this.tbxOgrenciMsuNeti.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbxOgrenciMsuNeti_KeyPress);
            // 
            // tbxOgrenciAytNeti
            // 
            this.tbxOgrenciAytNeti.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.tbxOgrenciAytNeti.Location = new System.Drawing.Point(741, 621);
            this.tbxOgrenciAytNeti.Name = "tbxOgrenciAytNeti";
            this.tbxOgrenciAytNeti.Size = new System.Drawing.Size(289, 22);
            this.tbxOgrenciAytNeti.TabIndex = 25;
            this.tbxOgrenciAytNeti.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbxOgrenciAytNeti_KeyPress);
            // 
            // tbxOgrenciTytNeti
            // 
            this.tbxOgrenciTytNeti.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.tbxOgrenciTytNeti.Location = new System.Drawing.Point(741, 580);
            this.tbxOgrenciTytNeti.Name = "tbxOgrenciTytNeti";
            this.tbxOgrenciTytNeti.Size = new System.Drawing.Size(289, 22);
            this.tbxOgrenciTytNeti.TabIndex = 24;
            this.tbxOgrenciTytNeti.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbxOgrenciTytNeti_KeyPress);
            // 
            // tbxOgrenciYksSiralama
            // 
            this.tbxOgrenciYksSiralama.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.tbxOgrenciYksSiralama.Location = new System.Drawing.Point(741, 546);
            this.tbxOgrenciYksSiralama.Name = "tbxOgrenciYksSiralama";
            this.tbxOgrenciYksSiralama.Size = new System.Drawing.Size(289, 22);
            this.tbxOgrenciYksSiralama.TabIndex = 23;
            this.tbxOgrenciYksSiralama.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbxOgrenciYksSiralama_KeyPress);
            // 
            // tbxVeli1Telefon
            // 
            this.tbxVeli1Telefon.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.tbxVeli1Telefon.Location = new System.Drawing.Point(1293, 621);
            this.tbxVeli1Telefon.MaxLength = 10;
            this.tbxVeli1Telefon.Name = "tbxVeli1Telefon";
            this.tbxVeli1Telefon.Size = new System.Drawing.Size(264, 22);
            this.tbxVeli1Telefon.TabIndex = 30;
            this.tbxVeli1Telefon.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbxVeli1Telefon_KeyPress);
            // 
            // tbxVeli1Yakinlik
            // 
            this.tbxVeli1Yakinlik.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.tbxVeli1Yakinlik.Location = new System.Drawing.Point(1293, 583);
            this.tbxVeli1Yakinlik.MaxLength = 30;
            this.tbxVeli1Yakinlik.Name = "tbxVeli1Yakinlik";
            this.tbxVeli1Yakinlik.Size = new System.Drawing.Size(264, 22);
            this.tbxVeli1Yakinlik.TabIndex = 29;
            this.tbxVeli1Yakinlik.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbxVeli1Yakinlik_KeyPress);
            // 
            // tbxVeli1AdSoyad
            // 
            this.tbxVeli1AdSoyad.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.tbxVeli1AdSoyad.Location = new System.Drawing.Point(1293, 546);
            this.tbxVeli1AdSoyad.MaxLength = 25;
            this.tbxVeli1AdSoyad.Name = "tbxVeli1AdSoyad";
            this.tbxVeli1AdSoyad.Size = new System.Drawing.Size(264, 22);
            this.tbxVeli1AdSoyad.TabIndex = 28;
            this.tbxVeli1AdSoyad.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbxVeli1AdSoyad_KeyPress);
            // 
            // tbxVeli2Telefon
            // 
            this.tbxVeli2Telefon.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.tbxVeli2Telefon.Location = new System.Drawing.Point(1293, 750);
            this.tbxVeli2Telefon.MaxLength = 10;
            this.tbxVeli2Telefon.Name = "tbxVeli2Telefon";
            this.tbxVeli2Telefon.Size = new System.Drawing.Size(264, 22);
            this.tbxVeli2Telefon.TabIndex = 33;
            this.tbxVeli2Telefon.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbxVeli2Telefon_KeyPress);
            // 
            // tbxVeli2Yakinlik
            // 
            this.tbxVeli2Yakinlik.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.tbxVeli2Yakinlik.Location = new System.Drawing.Point(1293, 712);
            this.tbxVeli2Yakinlik.MaxLength = 30;
            this.tbxVeli2Yakinlik.Name = "tbxVeli2Yakinlik";
            this.tbxVeli2Yakinlik.Size = new System.Drawing.Size(264, 22);
            this.tbxVeli2Yakinlik.TabIndex = 32;
            this.tbxVeli2Yakinlik.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbxVeli2Yakinlik_KeyPress);
            // 
            // tbxVeli2AdSoyad
            // 
            this.tbxVeli2AdSoyad.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.tbxVeli2AdSoyad.Location = new System.Drawing.Point(1293, 675);
            this.tbxVeli2AdSoyad.MaxLength = 25;
            this.tbxVeli2AdSoyad.Name = "tbxVeli2AdSoyad";
            this.tbxVeli2AdSoyad.Size = new System.Drawing.Size(264, 22);
            this.tbxVeli2AdSoyad.TabIndex = 31;
            this.tbxVeli2AdSoyad.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbxVeli2AdSoyad_KeyPress);
            // 
            // btnOgrenciDuzenle
            // 
            this.btnOgrenciDuzenle.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnOgrenciDuzenle.Location = new System.Drawing.Point(1400, 608);
            this.btnOgrenciDuzenle.Name = "btnOgrenciDuzenle";
            this.btnOgrenciDuzenle.Size = new System.Drawing.Size(269, 79);
            this.btnOgrenciDuzenle.TabIndex = 34;
            this.btnOgrenciDuzenle.Text = "Düzenle";
            this.btnOgrenciDuzenle.UseVisualStyleBackColor = true;
            this.btnOgrenciDuzenle.Click += new System.EventHandler(this.btnOgrenciDuzenle_Click);
            // 
            // btnOgrenciSil
            // 
            this.btnOgrenciSil.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnOgrenciSil.Location = new System.Drawing.Point(1400, 693);
            this.btnOgrenciSil.Name = "btnOgrenciSil";
            this.btnOgrenciSil.Size = new System.Drawing.Size(269, 79);
            this.btnOgrenciSil.TabIndex = 35;
            this.btnOgrenciSil.Text = "Sil";
            this.btnOgrenciSil.UseVisualStyleBackColor = true;
            this.btnOgrenciSil.Click += new System.EventHandler(this.btnOgrenciSil_Click);
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
            this.btnGeriDon.TabIndex = 36;
            this.btnGeriDon.Text = "🡸      Geri Dön";
            this.btnGeriDon.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGeriDon.UseVisualStyleBackColor = false;
            this.btnGeriDon.Click += new System.EventHandler(this.btnGeriDon_Click);
            // 
            // label17
            // 
            this.label17.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(51, 28);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(86, 16);
            this.label17.TabIndex = 37;
            this.label17.Text = "Öğrencilerim:";
            // 
            // lblOgrenciAra
            // 
            this.lblOgrenciAra.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblOgrenciAra.AutoSize = true;
            this.lblOgrenciAra.Location = new System.Drawing.Point(1378, 31);
            this.lblOgrenciAra.Name = "lblOgrenciAra";
            this.lblOgrenciAra.Size = new System.Drawing.Size(47, 16);
            this.lblOgrenciAra.TabIndex = 38;
            this.lblOgrenciAra.Text = "Arama";
            // 
            // tbxOgrenciAra
            // 
            this.tbxOgrenciAra.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.tbxOgrenciAra.Location = new System.Drawing.Point(1450, 28);
            this.tbxOgrenciAra.Name = "tbxOgrenciAra";
            this.tbxOgrenciAra.Size = new System.Drawing.Size(219, 22);
            this.tbxOgrenciAra.TabIndex = 39;
            this.tbxOgrenciAra.TextChanged += new System.EventHandler(this.tbxOgrenciAra_TextChanged);
            // 
            // lblTextBoxTemizle
            // 
            this.lblTextBoxTemizle.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblTextBoxTemizle.AutoSize = true;
            this.lblTextBoxTemizle.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblTextBoxTemizle.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblTextBoxTemizle.Location = new System.Drawing.Point(1604, 808);
            this.lblTextBoxTemizle.Name = "lblTextBoxTemizle";
            this.lblTextBoxTemizle.Size = new System.Drawing.Size(55, 16);
            this.lblTextBoxTemizle.TabIndex = 40;
            this.lblTextBoxTemizle.Text = "Temizle";
            this.lblTextBoxTemizle.Click += new System.EventHandler(this.lblTextBoxTemizle_Click);
            // 
            // btnDosyadanOgrenciEkle
            // 
            this.btnDosyadanOgrenciEkle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDosyadanOgrenciEkle.Location = new System.Drawing.Point(54, 794);
            this.btnDosyadanOgrenciEkle.Name = "btnDosyadanOgrenciEkle";
            this.btnDosyadanOgrenciEkle.Size = new System.Drawing.Size(296, 45);
            this.btnDosyadanOgrenciEkle.TabIndex = 41;
            this.btnDosyadanOgrenciEkle.Text = "Dosyadan Öğrenci Ekle";
            this.btnDosyadanOgrenciEkle.UseVisualStyleBackColor = true;
            this.btnDosyadanOgrenciEkle.Click += new System.EventHandler(this.btnDosyadanOgrenciEkle_Click);
            // 
            // cbxSinif
            // 
            this.cbxSinif.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cbxSinif.BackColor = System.Drawing.Color.White;
            this.cbxSinif.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.cbxSinif.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cbxSinif.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.cbxSinif.FormattingEnabled = true;
            this.cbxSinif.Location = new System.Drawing.Point(233, 656);
            this.cbxSinif.Name = "cbxSinif";
            this.cbxSinif.Size = new System.Drawing.Size(269, 31);
            this.cbxSinif.TabIndex = 42;
            // 
            // label18
            // 
            this.label18.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(51, 586);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(104, 16);
            this.label18.TabIndex = 44;
            this.label18.Text = "Ödev Numarası:";
            // 
            // tbxOdevNumarasi
            // 
            this.tbxOdevNumarasi.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.tbxOdevNumarasi.Location = new System.Drawing.Point(233, 583);
            this.tbxOdevNumarasi.MaxLength = 9;
            this.tbxOdevNumarasi.Name = "tbxOdevNumarasi";
            this.tbxOdevNumarasi.Size = new System.Drawing.Size(269, 22);
            this.tbxOdevNumarasi.TabIndex = 43;
            this.tbxOdevNumarasi.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbxOdevNumarasi_KeyPress);
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
            // homework_id
            // 
            this.homework_id.DataPropertyName = "homework_id";
            this.homework_id.HeaderText = "Ödev No";
            this.homework_id.MinimumWidth = 6;
            this.homework_id.Name = "homework_id";
            this.homework_id.ReadOnly = true;
            this.homework_id.Width = 125;
            // 
            // name
            // 
            this.name.DataPropertyName = "name";
            this.name.HeaderText = "Öğrenci";
            this.name.MinimumWidth = 6;
            this.name.Name = "name";
            this.name.ReadOnly = true;
            this.name.Width = 125;
            // 
            // sinif
            // 
            this.sinif.DataPropertyName = "class";
            this.sinif.HeaderText = "Sınıf";
            this.sinif.MinimumWidth = 6;
            this.sinif.Name = "sinif";
            this.sinif.ReadOnly = true;
            this.sinif.Width = 125;
            // 
            // school
            // 
            this.school.DataPropertyName = "school";
            this.school.HeaderText = "Okul";
            this.school.MinimumWidth = 6;
            this.school.Name = "school";
            this.school.ReadOnly = true;
            this.school.Width = 125;
            // 
            // phoneNumber
            // 
            this.phoneNumber.DataPropertyName = "phoneNumber";
            this.phoneNumber.HeaderText = "Telefon";
            this.phoneNumber.MinimumWidth = 6;
            this.phoneNumber.Name = "phoneNumber";
            this.phoneNumber.ReadOnly = true;
            this.phoneNumber.Width = 125;
            // 
            // yksScore
            // 
            this.yksScore.DataPropertyName = "yksScore";
            this.yksScore.HeaderText = "YKS Sıralaması";
            this.yksScore.MinimumWidth = 6;
            this.yksScore.Name = "yksScore";
            this.yksScore.ReadOnly = true;
            this.yksScore.Width = 125;
            // 
            // tytScore
            // 
            this.tytScore.DataPropertyName = "tytScore";
            this.tytScore.HeaderText = "TYT Neti";
            this.tytScore.MinimumWidth = 6;
            this.tytScore.Name = "tytScore";
            this.tytScore.ReadOnly = true;
            this.tytScore.Width = 125;
            // 
            // aytScore
            // 
            this.aytScore.DataPropertyName = "aytScore";
            this.aytScore.HeaderText = "AYT Neti";
            this.aytScore.MinimumWidth = 6;
            this.aytScore.Name = "aytScore";
            this.aytScore.ReadOnly = true;
            this.aytScore.Width = 125;
            // 
            // msuScore
            // 
            this.msuScore.DataPropertyName = "msuScore";
            this.msuScore.HeaderText = "MSU Neti";
            this.msuScore.MinimumWidth = 6;
            this.msuScore.Name = "msuScore";
            this.msuScore.ReadOnly = true;
            this.msuScore.Width = 125;
            // 
            // purpose
            // 
            this.purpose.DataPropertyName = "purpose";
            this.purpose.HeaderText = "Hedefi";
            this.purpose.MinimumWidth = 6;
            this.purpose.Name = "purpose";
            this.purpose.ReadOnly = true;
            this.purpose.Width = 125;
            // 
            // parent1Name
            // 
            this.parent1Name.DataPropertyName = "parent1Name";
            this.parent1Name.HeaderText = "1. Velisi";
            this.parent1Name.MinimumWidth = 6;
            this.parent1Name.Name = "parent1Name";
            this.parent1Name.ReadOnly = true;
            this.parent1Name.Width = 125;
            // 
            // parent1ParentalCloseness
            // 
            this.parent1ParentalCloseness.DataPropertyName = "parent1ParentalCloseness";
            this.parent1ParentalCloseness.HeaderText = "Yakınlık";
            this.parent1ParentalCloseness.MinimumWidth = 6;
            this.parent1ParentalCloseness.Name = "parent1ParentalCloseness";
            this.parent1ParentalCloseness.ReadOnly = true;
            this.parent1ParentalCloseness.Width = 125;
            // 
            // parent1PhoneNumber
            // 
            this.parent1PhoneNumber.DataPropertyName = "parent1PhoneNumber";
            this.parent1PhoneNumber.HeaderText = "Telefon";
            this.parent1PhoneNumber.MinimumWidth = 6;
            this.parent1PhoneNumber.Name = "parent1PhoneNumber";
            this.parent1PhoneNumber.ReadOnly = true;
            this.parent1PhoneNumber.Width = 125;
            // 
            // parent2Name
            // 
            this.parent2Name.DataPropertyName = "parent2Name";
            this.parent2Name.HeaderText = "2. Velisi";
            this.parent2Name.MinimumWidth = 6;
            this.parent2Name.Name = "parent2Name";
            this.parent2Name.ReadOnly = true;
            this.parent2Name.Width = 125;
            // 
            // parent2ParentalCloseness
            // 
            this.parent2ParentalCloseness.DataPropertyName = "parent2ParentalCloseness";
            this.parent2ParentalCloseness.HeaderText = "Yakınlık";
            this.parent2ParentalCloseness.MinimumWidth = 6;
            this.parent2ParentalCloseness.Name = "parent2ParentalCloseness";
            this.parent2ParentalCloseness.ReadOnly = true;
            this.parent2ParentalCloseness.Width = 125;
            // 
            // parent2PhoneNumber
            // 
            this.parent2PhoneNumber.DataPropertyName = "parent2PhoneNumber";
            this.parent2PhoneNumber.HeaderText = "Telefon";
            this.parent2PhoneNumber.MinimumWidth = 6;
            this.parent2PhoneNumber.Name = "parent2PhoneNumber";
            this.parent2PhoneNumber.ReadOnly = true;
            this.parent2PhoneNumber.Width = 125;
            // 
            // OgrenciIslemleriForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1732, 852);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.tbxOdevNumarasi);
            this.Controls.Add(this.cbxSinif);
            this.Controls.Add(this.btnDosyadanOgrenciEkle);
            this.Controls.Add(this.lblTextBoxTemizle);
            this.Controls.Add(this.tbxOgrenciAra);
            this.Controls.Add(this.lblOgrenciAra);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.btnGeriDon);
            this.Controls.Add(this.btnOgrenciSil);
            this.Controls.Add(this.btnOgrenciDuzenle);
            this.Controls.Add(this.tbxVeli2Telefon);
            this.Controls.Add(this.tbxVeli2Yakinlik);
            this.Controls.Add(this.tbxVeli2AdSoyad);
            this.Controls.Add(this.tbxVeli1Telefon);
            this.Controls.Add(this.tbxVeli1Yakinlik);
            this.Controls.Add(this.tbxVeli1AdSoyad);
            this.Controls.Add(this.tbxOgrenciHedef);
            this.Controls.Add(this.tbxOgrenciMsuNeti);
            this.Controls.Add(this.tbxOgrenciAytNeti);
            this.Controls.Add(this.tbxOgrenciTytNeti);
            this.Controls.Add(this.tbxOgrenciYksSiralama);
            this.Controls.Add(this.tbxOgrenciTelefon);
            this.Controls.Add(this.tbxOgrenciOkul);
            this.Controls.Add(this.tbxOgrenciAdSoyad);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnOgrenciEkle);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbxOgrenciNumarasi);
            this.Controls.Add(this.dgwOgrencilerim);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "OgrenciIslemleriForm";
            this.Text = "Acar Akademi Rehberlik Uygulaması";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.OgrenciIslemleriForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgwOgrencilerim)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgwOgrencilerim;
        private System.Windows.Forms.TextBox tbxOgrenciNumarasi;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnOgrenciEkle;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox tbxOgrenciAdSoyad;
        private System.Windows.Forms.TextBox tbxOgrenciOkul;
        private System.Windows.Forms.TextBox tbxOgrenciTelefon;
        private System.Windows.Forms.TextBox tbxOgrenciHedef;
        private System.Windows.Forms.TextBox tbxOgrenciMsuNeti;
        private System.Windows.Forms.TextBox tbxOgrenciAytNeti;
        private System.Windows.Forms.TextBox tbxOgrenciTytNeti;
        private System.Windows.Forms.TextBox tbxOgrenciYksSiralama;
        private System.Windows.Forms.TextBox tbxVeli1Telefon;
        private System.Windows.Forms.TextBox tbxVeli1Yakinlik;
        private System.Windows.Forms.TextBox tbxVeli1AdSoyad;
        private System.Windows.Forms.TextBox tbxVeli2Telefon;
        private System.Windows.Forms.TextBox tbxVeli2Yakinlik;
        private System.Windows.Forms.TextBox tbxVeli2AdSoyad;
        private System.Windows.Forms.Button btnOgrenciDuzenle;
        private System.Windows.Forms.Button btnOgrenciSil;
        private System.Windows.Forms.Button btnGeriDon;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label lblOgrenciAra;
        private System.Windows.Forms.TextBox tbxOgrenciAra;
        private System.Windows.Forms.DataGridViewTextBoxColumn @class;
        private System.Windows.Forms.Label lblTextBoxTemizle;
        private System.Windows.Forms.Button btnDosyadanOgrenciEkle;
        private System.Windows.Forms.ComboBox cbxSinif;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox tbxOdevNumarasi;
        private System.Windows.Forms.DataGridViewTextBoxColumn student_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn homework_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn name;
        private System.Windows.Forms.DataGridViewTextBoxColumn sinif;
        private System.Windows.Forms.DataGridViewTextBoxColumn school;
        private System.Windows.Forms.DataGridViewTextBoxColumn phoneNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn yksScore;
        private System.Windows.Forms.DataGridViewTextBoxColumn tytScore;
        private System.Windows.Forms.DataGridViewTextBoxColumn aytScore;
        private System.Windows.Forms.DataGridViewTextBoxColumn msuScore;
        private System.Windows.Forms.DataGridViewTextBoxColumn purpose;
        private System.Windows.Forms.DataGridViewTextBoxColumn parent1Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn parent1ParentalCloseness;
        private System.Windows.Forms.DataGridViewTextBoxColumn parent1PhoneNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn parent2Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn parent2ParentalCloseness;
        private System.Windows.Forms.DataGridViewTextBoxColumn parent2PhoneNumber;
    }
}