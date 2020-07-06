namespace SVD
{
    public partial class Form1 
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.l_SVD = new System.Windows.Forms.Label();
            this.b_Nacti = new System.Windows.Forms.Button();
            this.l_KvalitaKomprese = new System.Windows.Forms.Label();
            this.b_Zkomprimuj = new System.Windows.Forms.Button();
            this.b_Konec = new System.Windows.Forms.Button();
            this.l_Popis = new System.Windows.Forms.Label();
            this.lB_zpusobKomprese = new System.Windows.Forms.CheckedListBox();
            this.tB_uzivatelUroven = new System.Windows.Forms.TextBox();
            this.b_novyObrazek = new System.Windows.Forms.Button();
            this.l_Zmena = new System.Windows.Forms.Label();
            this.l_ENTER = new System.Windows.Forms.Label();
            this.l_Porovnani = new System.Windows.Forms.Label();
            this.b_Editace = new System.Windows.Forms.Button();
            this.b_UlozitEd = new System.Windows.Forms.Button();
            this.b_Editace0 = new System.Windows.Forms.Button();
            this.b_StupneSedi = new System.Windows.Forms.Button();
            this.b_Invertovat = new System.Windows.Forms.Button();
            this.pB_nacitani = new System.Windows.Forms.PictureBox();
            this.pB_puvodni = new System.Windows.Forms.PictureBox();
            this.pb_komprese = new System.Windows.Forms.PictureBox();
            this.pB_Editace = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.tB_jas = new System.Windows.Forms.TrackBar();
            this.l_jas = new System.Windows.Forms.Label();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.l_Kontrast = new System.Windows.Forms.Label();
            this.b_Navrat = new System.Windows.Forms.Button();
            this.b_KomprimovatEd = new System.Windows.Forms.Button();
            this.b_Ulozit = new System.Windows.Forms.Button();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.b_PredchoziVerze = new System.Windows.Forms.Button();
            this.b_NacistVerzi = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pB_nacitani)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pB_puvodni)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_komprese)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pB_Editace)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tB_jas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            this.SuspendLayout();
            // 
            // l_SVD
            // 
            this.l_SVD.AutoSize = true;
            this.l_SVD.Font = new System.Drawing.Font("Bahnschrift", 19.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.l_SVD.Location = new System.Drawing.Point(61, 68);
            this.l_SVD.Name = "l_SVD";
            this.l_SVD.Size = new System.Drawing.Size(314, 64);
            this.l_SVD.TabIndex = 0;
            this.l_SVD.Text = "SVD rozklad";
            // 
            // b_Nacti
            // 
            this.b_Nacti.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.b_Nacti.BackColor = System.Drawing.Color.DarkCyan;
            this.b_Nacti.Font = new System.Drawing.Font("Bahnschrift", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.b_Nacti.ForeColor = System.Drawing.Color.Snow;
            this.b_Nacti.Location = new System.Drawing.Point(1167, 920);
            this.b_Nacti.Name = "b_Nacti";
            this.b_Nacti.Size = new System.Drawing.Size(291, 65);
            this.b_Nacti.TabIndex = 1;
            this.b_Nacti.Text = "Vybrat obrázek";
            this.b_Nacti.UseVisualStyleBackColor = false;
            this.b_Nacti.Click += new System.EventHandler(this.b_Nacti_Click);
            // 
            // l_KvalitaKomprese
            // 
            this.l_KvalitaKomprese.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.l_KvalitaKomprese.AutoSize = true;
            this.l_KvalitaKomprese.Location = new System.Drawing.Point(67, 828);
            this.l_KvalitaKomprese.Name = "l_KvalitaKomprese";
            this.l_KvalitaKomprese.Size = new System.Drawing.Size(185, 25);
            this.l_KvalitaKomprese.TabIndex = 4;
            this.l_KvalitaKomprese.Text = "l_KvalitaKomprese";
            // 
            // b_Zkomprimuj
            // 
            this.b_Zkomprimuj.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.b_Zkomprimuj.BackColor = System.Drawing.Color.DarkCyan;
            this.b_Zkomprimuj.Font = new System.Drawing.Font("Bahnschrift", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.b_Zkomprimuj.ForeColor = System.Drawing.Color.Snow;
            this.b_Zkomprimuj.Location = new System.Drawing.Point(1167, 844);
            this.b_Zkomprimuj.Name = "b_Zkomprimuj";
            this.b_Zkomprimuj.Size = new System.Drawing.Size(291, 65);
            this.b_Zkomprimuj.TabIndex = 6;
            this.b_Zkomprimuj.Text = "Komprimovat";
            this.b_Zkomprimuj.UseVisualStyleBackColor = false;
            this.b_Zkomprimuj.Click += new System.EventHandler(this.b_Zkomprimuj_Click);
            // 
            // b_Konec
            // 
            this.b_Konec.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.b_Konec.BackColor = System.Drawing.Color.DarkCyan;
            this.b_Konec.Font = new System.Drawing.Font("Bahnschrift", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.b_Konec.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.b_Konec.Location = new System.Drawing.Point(1167, 996);
            this.b_Konec.Name = "b_Konec";
            this.b_Konec.Size = new System.Drawing.Size(291, 65);
            this.b_Konec.TabIndex = 7;
            this.b_Konec.Text = "Konec";
            this.b_Konec.UseVisualStyleBackColor = false;
            this.b_Konec.Click += new System.EventHandler(this.b_Konec_Click);
            // 
            // l_Popis
            // 
            this.l_Popis.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.l_Popis.AutoSize = true;
            this.l_Popis.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.l_Popis.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.l_Popis.Location = new System.Drawing.Point(53, 812);
            this.l_Popis.Name = "l_Popis";
            this.l_Popis.Size = new System.Drawing.Size(1115, 232);
            this.l_Popis.TabIndex = 9;
            this.l_Popis.Text = resources.GetString("l_Popis.Text");
            // 
            // lB_zpusobKomprese
            // 
            this.lB_zpusobKomprese.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lB_zpusobKomprese.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.lB_zpusobKomprese.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lB_zpusobKomprese.CheckOnClick = true;
            this.lB_zpusobKomprese.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lB_zpusobKomprese.FormattingEnabled = true;
            this.lB_zpusobKomprese.Items.AddRange(new object[] {
            "Počet singulárních čísel [int]",
            "Úroveň komprese [%]"});
            this.lB_zpusobKomprese.Location = new System.Drawing.Point(72, 969);
            this.lB_zpusobKomprese.Name = "lB_zpusobKomprese";
            this.lB_zpusobKomprese.Size = new System.Drawing.Size(431, 64);
            this.lB_zpusobKomprese.TabIndex = 12;
            this.lB_zpusobKomprese.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.lB_zpusobKomprese_ItemCheck);
            // 
            // tB_uzivatelUroven
            // 
            this.tB_uzivatelUroven.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.tB_uzivatelUroven.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tB_uzivatelUroven.Location = new System.Drawing.Point(509, 996);
            this.tB_uzivatelUroven.Name = "tB_uzivatelUroven";
            this.tB_uzivatelUroven.Size = new System.Drawing.Size(181, 37);
            this.tB_uzivatelUroven.TabIndex = 13;
            this.tB_uzivatelUroven.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tB_uzivatelUroven_KeyDown);
            this.tB_uzivatelUroven.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tB_uzivatelUroven_KeyPress);
            // 
            // b_novyObrazek
            // 
            this.b_novyObrazek.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.b_novyObrazek.BackColor = System.Drawing.Color.DarkCyan;
            this.b_novyObrazek.Font = new System.Drawing.Font("Bahnschrift", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.b_novyObrazek.ForeColor = System.Drawing.Color.Snow;
            this.b_novyObrazek.Location = new System.Drawing.Point(1167, 920);
            this.b_novyObrazek.Name = "b_novyObrazek";
            this.b_novyObrazek.Size = new System.Drawing.Size(291, 65);
            this.b_novyObrazek.TabIndex = 14;
            this.b_novyObrazek.Text = "Jiný obrázek";
            this.b_novyObrazek.UseVisualStyleBackColor = false;
            this.b_novyObrazek.Click += new System.EventHandler(this.b_novyObrazek_Click);
            // 
            // l_Zmena
            // 
            this.l_Zmena.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.l_Zmena.AutoSize = true;
            this.l_Zmena.Location = new System.Drawing.Point(67, 915);
            this.l_Zmena.Name = "l_Zmena";
            this.l_Zmena.Size = new System.Drawing.Size(561, 25);
            this.l_Zmena.TabIndex = 15;
            this.l_Zmena.Text = "Vybere způsob nové komprese a zadejte příslušnou hodnotu:";
            // 
            // l_ENTER
            // 
            this.l_ENTER.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.l_ENTER.AutoSize = true;
            this.l_ENTER.Font = new System.Drawing.Font("Calibri Light", 7.875F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.l_ENTER.Location = new System.Drawing.Point(707, 981);
            this.l_ENTER.Name = "l_ENTER";
            this.l_ENTER.Size = new System.Drawing.Size(317, 52);
            this.l_ENTER.TabIndex = 18;
            this.l_ENTER.Text = "Pokračujte stisknutím ENTER \r\nnebo klikněte na ZMĚNIT KOMPRESI\r\n";
            this.l_ENTER.Visible = false;
            // 
            // l_Porovnani
            // 
            this.l_Porovnani.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.l_Porovnani.AutoSize = true;
            this.l_Porovnani.Location = new System.Drawing.Point(681, 828);
            this.l_Porovnani.Name = "l_Porovnani";
            this.l_Porovnani.Size = new System.Drawing.Size(122, 25);
            this.l_Porovnani.TabIndex = 19;
            this.l_Porovnani.Text = "l_Porovnani";
            // 
            // b_Editace
            // 
            this.b_Editace.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.b_Editace.BackColor = System.Drawing.Color.DarkCyan;
            this.b_Editace.Font = new System.Drawing.Font("Bahnschrift", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.b_Editace.ForeColor = System.Drawing.Color.Snow;
            this.b_Editace.Location = new System.Drawing.Point(1167, 108);
            this.b_Editace.Name = "b_Editace";
            this.b_Editace.Size = new System.Drawing.Size(291, 65);
            this.b_Editace.TabIndex = 20;
            this.b_Editace.Text = "Editovat";
            this.b_Editace.UseVisualStyleBackColor = false;
            this.b_Editace.Click += new System.EventHandler(this.b_Editace_Click_1);
            // 
            // b_UlozitEd
            // 
            this.b_UlozitEd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.b_UlozitEd.BackColor = System.Drawing.Color.DarkCyan;
            this.b_UlozitEd.Font = new System.Drawing.Font("Bahnschrift", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.b_UlozitEd.ForeColor = System.Drawing.Color.Snow;
            this.b_UlozitEd.Location = new System.Drawing.Point(1167, 35);
            this.b_UlozitEd.Name = "b_UlozitEd";
            this.b_UlozitEd.Size = new System.Drawing.Size(291, 65);
            this.b_UlozitEd.TabIndex = 21;
            this.b_UlozitEd.Text = "Uložit ";
            this.b_UlozitEd.UseVisualStyleBackColor = false;
            this.b_UlozitEd.Click += new System.EventHandler(this.b_Ulozit_Click);
            // 
            // b_Editace0
            // 
            this.b_Editace0.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.b_Editace0.BackColor = System.Drawing.Color.DarkCyan;
            this.b_Editace0.Font = new System.Drawing.Font("Bahnschrift", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.b_Editace0.ForeColor = System.Drawing.Color.Snow;
            this.b_Editace0.Location = new System.Drawing.Point(1167, 108);
            this.b_Editace0.Name = "b_Editace0";
            this.b_Editace0.Size = new System.Drawing.Size(291, 65);
            this.b_Editace0.TabIndex = 22;
            this.b_Editace0.Text = "Editovat";
            this.b_Editace0.UseVisualStyleBackColor = false;
            this.b_Editace0.Click += new System.EventHandler(this.b_Editace0_Click);
            // 
            // b_StupneSedi
            // 
            this.b_StupneSedi.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.b_StupneSedi.BackColor = System.Drawing.Color.Purple;
            this.b_StupneSedi.Font = new System.Drawing.Font("Bahnschrift", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.b_StupneSedi.ForeColor = System.Drawing.Color.Snow;
            this.b_StupneSedi.Location = new System.Drawing.Point(1167, 220);
            this.b_StupneSedi.Name = "b_StupneSedi";
            this.b_StupneSedi.Size = new System.Drawing.Size(291, 65);
            this.b_StupneSedi.TabIndex = 23;
            this.b_StupneSedi.Text = "Stupně šedi";
            this.b_StupneSedi.UseVisualStyleBackColor = false;
            this.b_StupneSedi.Click += new System.EventHandler(this.b_StupneSedi_Click);
            // 
            // b_Invertovat
            // 
            this.b_Invertovat.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.b_Invertovat.BackColor = System.Drawing.Color.Purple;
            this.b_Invertovat.Font = new System.Drawing.Font("Bahnschrift", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.b_Invertovat.ForeColor = System.Drawing.Color.Snow;
            this.b_Invertovat.Location = new System.Drawing.Point(1167, 291);
            this.b_Invertovat.Name = "b_Invertovat";
            this.b_Invertovat.Size = new System.Drawing.Size(291, 65);
            this.b_Invertovat.TabIndex = 24;
            this.b_Invertovat.Text = "Invertovat";
            this.b_Invertovat.UseVisualStyleBackColor = false;
            this.b_Invertovat.Click += new System.EventHandler(this.b_Invertovat_Click);
            // 
            // pB_nacitani
            // 
            this.pB_nacitani.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pB_nacitani.Location = new System.Drawing.Point(1098, 467);
            this.pB_nacitani.Name = "pB_nacitani";
            this.pB_nacitani.Size = new System.Drawing.Size(32, 32);
            this.pB_nacitani.TabIndex = 16;
            this.pB_nacitani.TabStop = false;
            // 
            // pB_puvodni
            // 
            this.pB_puvodni.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.pB_puvodni.Location = new System.Drawing.Point(92, 221);
            this.pB_puvodni.Name = "pB_puvodni";
            this.pB_puvodni.Size = new System.Drawing.Size(657, 545);
            this.pB_puvodni.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pB_puvodni.TabIndex = 3;
            this.pB_puvodni.TabStop = false;
            // 
            // pb_komprese
            // 
            this.pb_komprese.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pb_komprese.Location = new System.Drawing.Point(769, 221);
            this.pb_komprese.Name = "pb_komprese";
            this.pb_komprese.Size = new System.Drawing.Size(657, 545);
            this.pb_komprese.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pb_komprese.TabIndex = 2;
            this.pb_komprese.TabStop = false;
            // 
            // pB_Editace
            // 
            this.pB_Editace.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pB_Editace.BackColor = System.Drawing.Color.Gainsboro;
            this.pB_Editace.Location = new System.Drawing.Point(37, 160);
            this.pB_Editace.Name = "pB_Editace";
            this.pB_Editace.Size = new System.Drawing.Size(1055, 839);
            this.pB_Editace.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pB_Editace.TabIndex = 10;
            this.pB_Editace.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(58, 197);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1400, 595);
            this.pictureBox1.TabIndex = 17;
            this.pictureBox1.TabStop = false;
            // 
            // tB_jas
            // 
            this.tB_jas.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.tB_jas.LargeChange = 10;
            this.tB_jas.Location = new System.Drawing.Point(1118, 591);
            this.tB_jas.Maximum = 100;
            this.tB_jas.Minimum = -100;
            this.tB_jas.Name = "tB_jas";
            this.tB_jas.Size = new System.Drawing.Size(385, 90);
            this.tB_jas.SmallChange = 5;
            this.tB_jas.TabIndex = 30;
            this.tB_jas.TickFrequency = 5;
            this.tB_jas.Scroll += new System.EventHandler(this.tB_jas_Scroll);
            // 
            // l_jas
            // 
            this.l_jas.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.l_jas.AutoSize = true;
            this.l_jas.Font = new System.Drawing.Font("Bahnschrift", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.l_jas.Location = new System.Drawing.Point(1285, 535);
            this.l_jas.Name = "l_jas";
            this.l_jas.Size = new System.Drawing.Size(50, 29);
            this.l_jas.TabIndex = 31;
            this.l_jas.Text = "Jas";
            // 
            // trackBar1
            // 
            this.trackBar1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.trackBar1.LargeChange = 10;
            this.trackBar1.Location = new System.Drawing.Point(1118, 733);
            this.trackBar1.Maximum = 49;
            this.trackBar1.Minimum = 1;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(385, 90);
            this.trackBar1.SmallChange = 5;
            this.trackBar1.TabIndex = 32;
            this.trackBar1.TickFrequency = 5;
            this.trackBar1.Value = 25;
            this.trackBar1.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // l_Kontrast
            // 
            this.l_Kontrast.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.l_Kontrast.AutoSize = true;
            this.l_Kontrast.Font = new System.Drawing.Font("Bahnschrift", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.l_Kontrast.Location = new System.Drawing.Point(1259, 684);
            this.l_Kontrast.Name = "l_Kontrast";
            this.l_Kontrast.Size = new System.Drawing.Size(105, 29);
            this.l_Kontrast.TabIndex = 33;
            this.l_Kontrast.Text = "Kontrast";
            // 
            // b_Navrat
            // 
            this.b_Navrat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.b_Navrat.BackColor = System.Drawing.Color.DarkCyan;
            this.b_Navrat.Font = new System.Drawing.Font("Bahnschrift", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.b_Navrat.ForeColor = System.Drawing.Color.Snow;
            this.b_Navrat.Location = new System.Drawing.Point(1167, 108);
            this.b_Navrat.Name = "b_Navrat";
            this.b_Navrat.Size = new System.Drawing.Size(291, 65);
            this.b_Navrat.TabIndex = 34;
            this.b_Navrat.Text = "Návrat k původnímu";
            this.b_Navrat.UseVisualStyleBackColor = false;
            this.b_Navrat.Click += new System.EventHandler(this.b_Navrat_Click);
            // 
            // b_KomprimovatEd
            // 
            this.b_KomprimovatEd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.b_KomprimovatEd.BackColor = System.Drawing.Color.DarkCyan;
            this.b_KomprimovatEd.Font = new System.Drawing.Font("Bahnschrift", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.b_KomprimovatEd.ForeColor = System.Drawing.Color.Snow;
            this.b_KomprimovatEd.Location = new System.Drawing.Point(1167, 844);
            this.b_KomprimovatEd.Name = "b_KomprimovatEd";
            this.b_KomprimovatEd.Size = new System.Drawing.Size(291, 65);
            this.b_KomprimovatEd.TabIndex = 35;
            this.b_KomprimovatEd.Text = "Komprimovat ";
            this.b_KomprimovatEd.UseVisualStyleBackColor = false;
            this.b_KomprimovatEd.Click += new System.EventHandler(this.b_KomprimovatEd_Click);
            // 
            // b_Ulozit
            // 
            this.b_Ulozit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.b_Ulozit.BackColor = System.Drawing.Color.DarkCyan;
            this.b_Ulozit.Font = new System.Drawing.Font("Bahnschrift", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.b_Ulozit.ForeColor = System.Drawing.Color.Snow;
            this.b_Ulozit.Location = new System.Drawing.Point(1167, 36);
            this.b_Ulozit.Name = "b_Ulozit";
            this.b_Ulozit.Size = new System.Drawing.Size(291, 65);
            this.b_Ulozit.TabIndex = 36;
            this.b_Ulozit.Text = "Uložit ";
            this.b_Ulozit.UseVisualStyleBackColor = false;
            this.b_Ulozit.Click += new System.EventHandler(this.b_Ulozit_Click_1);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            this.contextMenuStrip1.Click += new System.EventHandler(this.contextMenuStrip1_Click);
            // 
            // b_PredchoziVerze
            // 
            this.b_PredchoziVerze.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.b_PredchoziVerze.BackColor = System.Drawing.Color.DarkCyan;
            this.b_PredchoziVerze.ContextMenuStrip = this.contextMenuStrip1;
            this.b_PredchoziVerze.Font = new System.Drawing.Font("Bahnschrift", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.b_PredchoziVerze.ForeColor = System.Drawing.Color.Snow;
            this.b_PredchoziVerze.Location = new System.Drawing.Point(856, 37);
            this.b_PredchoziVerze.Name = "b_PredchoziVerze";
            this.b_PredchoziVerze.Size = new System.Drawing.Size(291, 65);
            this.b_PredchoziVerze.TabIndex = 38;
            this.b_PredchoziVerze.Text = "Předchozí verze";
            this.b_PredchoziVerze.UseVisualStyleBackColor = false;
            this.b_PredchoziVerze.Click += new System.EventHandler(this.b_PredchoziVerze_Click);
            // 
            // b_NacistVerzi
            // 
            this.b_NacistVerzi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.b_NacistVerzi.BackColor = System.Drawing.Color.DarkCyan;
            this.b_NacistVerzi.Font = new System.Drawing.Font("Bahnschrift", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.b_NacistVerzi.ForeColor = System.Drawing.Color.Snow;
            this.b_NacistVerzi.Location = new System.Drawing.Point(856, 108);
            this.b_NacistVerzi.Name = "b_NacistVerzi";
            this.b_NacistVerzi.Size = new System.Drawing.Size(291, 65);
            this.b_NacistVerzi.TabIndex = 39;
            this.b_NacistVerzi.Text = "Načíst verzi";
            this.b_NacistVerzi.UseVisualStyleBackColor = false;
            this.b_NacistVerzi.Click += new System.EventHandler(this.b_NacistVerzi_Click);
            // 
            // Form1
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(1550, 1110);
            this.Controls.Add(this.b_NacistVerzi);
            this.Controls.Add(this.b_PredchoziVerze);
            this.Controls.Add(this.b_Ulozit);
            this.Controls.Add(this.b_KomprimovatEd);
            this.Controls.Add(this.b_Navrat);
            this.Controls.Add(this.l_Kontrast);
            this.Controls.Add(this.trackBar1);
            this.Controls.Add(this.l_jas);
            this.Controls.Add(this.tB_jas);
            this.Controls.Add(this.b_Invertovat);
            this.Controls.Add(this.b_StupneSedi);
            this.Controls.Add(this.b_Editace0);
            this.Controls.Add(this.b_UlozitEd);
            this.Controls.Add(this.b_Editace);
            this.Controls.Add(this.l_Porovnani);
            this.Controls.Add(this.l_ENTER);
            this.Controls.Add(this.b_Nacti);
            this.Controls.Add(this.pB_nacitani);
            this.Controls.Add(this.l_Zmena);
            this.Controls.Add(this.b_novyObrazek);
            this.Controls.Add(this.tB_uzivatelUroven);
            this.Controls.Add(this.lB_zpusobKomprese);
            this.Controls.Add(this.l_Popis);
            this.Controls.Add(this.b_Konec);
            this.Controls.Add(this.b_Zkomprimuj);
            this.Controls.Add(this.l_SVD);
            this.Controls.Add(this.l_KvalitaKomprese);
            this.Controls.Add(this.pB_puvodni);
            this.Controls.Add(this.pb_komprese);
            this.Controls.Add(this.pB_Editace);
            this.Controls.Add(this.pictureBox1);
            this.Font = new System.Drawing.Font("Bahnschrift", 7.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Komprese obrázků metodou singulárního rozkladu";
            this.Resize += new System.EventHandler(this.Form1_Resize_1);
            ((System.ComponentModel.ISupportInitialize)(this.pB_nacitani)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pB_puvodni)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_komprese)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pB_Editace)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tB_jas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button b_Nacti;
        private System.Windows.Forms.PictureBox pb_komprese;
        private System.Windows.Forms.Label l_KvalitaKomprese;
        public System.Windows.Forms.Label l_SVD;
        public System.Windows.Forms.PictureBox pB_puvodni;
        private System.Windows.Forms.Button b_Zkomprimuj;
        private System.Windows.Forms.Button b_Konec;
        private System.Windows.Forms.Label l_Popis;
        private System.Windows.Forms.PictureBox pB_Editace;
        private System.Windows.Forms.CheckedListBox lB_zpusobKomprese;
        private System.Windows.Forms.TextBox tB_uzivatelUroven;
        private System.Windows.Forms.Button b_novyObrazek;
        private System.Windows.Forms.Label l_Zmena;
        private System.Windows.Forms.PictureBox pB_nacitani;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label l_ENTER;
        private System.Windows.Forms.Label l_Porovnani;
        private System.Windows.Forms.Button b_Editace;
        private System.Windows.Forms.Button b_UlozitEd;
        private System.Windows.Forms.Button b_Editace0;
        private System.Windows.Forms.Button b_StupneSedi;
        private System.Windows.Forms.Button b_Invertovat;
        private System.Windows.Forms.TrackBar tB_jas;
        private System.Windows.Forms.Label l_jas;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.Label l_Kontrast;
        private System.Windows.Forms.Button b_Navrat;
        private System.Windows.Forms.Button b_KomprimovatEd;
        private System.Windows.Forms.Button b_Ulozit;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.Button b_PredchoziVerze;
        private System.Windows.Forms.Button b_NacistVerzi;
    }
}

