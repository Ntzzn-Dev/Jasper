namespace Jasper;

partial class Form2
{
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
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
    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        components = new System.ComponentModel.Container();
        lblNomeMusica = new Label();
        lblURLMusica = new Label();
        btnSalvarMusica = new Button();
        btnCancelarMusica = new Button();
        lblArtistaMusica = new Label();
        btnURLOnlineMusic = new Button();
        picImgMusica = new PictureBox();
        btnImgMusicaOnline = new Button();
        btnImgMusicaLocal = new Button();
        lblImgMusica = new Label();
        btnAjudaPlaylist = new Button();
        lblNomePlaylist = new Label();
        picImgPlaylist = new PictureBox();
        btnImgPlaylistOnline = new Button();
        btnImgPlaylistLocal = new Button();
        lblImgPlaylist = new Label();
        btnSalvarPlaylist = new Button();
        btnCancelarPlaylist = new Button();
        btnAjudaArtista = new Button();
        lblNomeArtista = new Label();
        picImgArtista = new PictureBox();
        btnImgArtistaOnline = new Button();
        btnImgArtistaLocal = new Button();
        lblImgArtista = new Label();
        btnSalvarArtista = new Button();
        btnCancelarArtista = new Button();
        pnlCdtMusic = new Panel();
        lblNomeDosArtistas = new Label();
        txtbxImgMusica = new NthControls.CustomTextbox();
        txtbxURLMusica = new NthControls.CustomTextbox();
        txtbxNomeMusica = new NthControls.CustomTextbox();
        dpdwnArtistaDaMusica1 = new Dropdown();
        pnlCdtArtista = new Panel();
        txtbxImgArtista = new NthControls.CustomTextbox();
        txtbxNomeArtista = new NthControls.CustomTextbox();
        pnlCdtPlaylist = new Panel();
        txtbxImgPlaylist = new NthControls.CustomTextbox();
        txtbxNomePlaylist = new NthControls.CustomTextbox();
        pnlPageNav = new Panel();
        picPagePlaylist = new PictureBox();
        btnPagePlaylist = new Button();
        picPageMusic = new PictureBox();
        btnPageMusica = new Button();
        picPageArtista = new PictureBox();
        btnPageArtista = new Button();
        timer1 = new System.Windows.Forms.Timer(components);
        lblNomeArtista1 = new Label();
        lblNomeArtista2 = new Label();
        dpdwnArtistaDaMusica2 = new Dropdown();
        lblNomeArtista4 = new Label();
        dpdwnArtistaDaMusica4 = new Dropdown();
        lblNomeArtista3 = new Label();
        dpdwnArtistaDaMusica3 = new Dropdown();
        lblNomeArtista5 = new Label();
        dpdwnArtistaDaMusica5 = new Dropdown();
        titleWindow = new Panel();
        titleBar = new NthControls.TitleBarPersonalizada();
        ((System.ComponentModel.ISupportInitialize)picImgMusica).BeginInit();
        ((System.ComponentModel.ISupportInitialize)picImgPlaylist).BeginInit();
        ((System.ComponentModel.ISupportInitialize)picImgArtista).BeginInit();
        pnlCdtMusic.SuspendLayout();
        pnlCdtArtista.SuspendLayout();
        pnlCdtPlaylist.SuspendLayout();
        pnlPageNav.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)picPagePlaylist).BeginInit();
        ((System.ComponentModel.ISupportInitialize)picPageMusic).BeginInit();
        ((System.ComponentModel.ISupportInitialize)picPageArtista).BeginInit();
        titleWindow.SuspendLayout();
        SuspendLayout();
        // 
        // lblNomeMusica
        // 
        lblNomeMusica.AutoSize = true;
        lblNomeMusica.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
        lblNomeMusica.ForeColor = Color.Silver;
        lblNomeMusica.Location = new Point(13, 6);
        lblNomeMusica.Name = "lblNomeMusica";
        lblNomeMusica.Size = new Size(178, 30);
        lblNomeMusica.TabIndex = 2;
        lblNomeMusica.Text = "Nome da Musica";
        // 
        // lblURLMusica
        // 
        lblURLMusica.AutoSize = true;
        lblURLMusica.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
        lblURLMusica.ForeColor = Color.Silver;
        lblURLMusica.Location = new Point(13, 65);
        lblURLMusica.Name = "lblURLMusica";
        lblURLMusica.Size = new Size(158, 30);
        lblURLMusica.TabIndex = 3;
        lblURLMusica.Text = "URL da Musica";
        // 
        // btnSalvarMusica
        // 
        btnSalvarMusica.BackColor = Color.FromArgb(59, 58, 58);
        btnSalvarMusica.FlatStyle = FlatStyle.Flat;
        btnSalvarMusica.Location = new Point(396, 259);
        btnSalvarMusica.Name = "btnSalvarMusica";
        btnSalvarMusica.Size = new Size(119, 41);
        btnSalvarMusica.TabIndex = 11;
        btnSalvarMusica.Text = "Salvar";
        btnSalvarMusica.UseVisualStyleBackColor = false;
        // 
        // btnCancelarMusica
        // 
        btnCancelarMusica.BackColor = Color.FromArgb(59, 58, 58);
        btnCancelarMusica.FlatStyle = FlatStyle.Flat;
        btnCancelarMusica.Location = new Point(521, 259);
        btnCancelarMusica.Name = "btnCancelarMusica";
        btnCancelarMusica.Size = new Size(119, 41);
        btnCancelarMusica.TabIndex = 12;
        btnCancelarMusica.Text = "Cancelar";
        btnCancelarMusica.UseVisualStyleBackColor = false;
        // 
        // lblArtistaMusica
        // 
        lblArtistaMusica.AutoSize = true;
        lblArtistaMusica.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
        lblArtistaMusica.ForeColor = Color.Silver;
        lblArtistaMusica.Location = new Point(11, 123);
        lblArtistaMusica.Name = "lblArtistaMusica";
        lblArtistaMusica.Size = new Size(193, 30);
        lblArtistaMusica.TabIndex = 7;
        lblArtistaMusica.Text = "Artistas da Musica";
        // 
        // btnURLOnlineMusic
        // 
        btnURLOnlineMusic.BackColor = Color.FromArgb(59, 58, 58);
        btnURLOnlineMusic.FlatAppearance.BorderSize = 0;
        btnURLOnlineMusic.FlatStyle = FlatStyle.Flat;
        btnURLOnlineMusic.Location = new Point(303, 100);
        btnURLOnlineMusic.Name = "btnURLOnlineMusic";
        btnURLOnlineMusic.Size = new Size(119, 25);
        btnURLOnlineMusic.TabIndex = 5;
        btnURLOnlineMusic.Text = "Pesquisar online";
        btnURLOnlineMusic.UseVisualStyleBackColor = false;
        // 
        // picImgMusica
        // 
        picImgMusica.Location = new Point(428, 10);
        picImgMusica.Name = "picImgMusica";
        picImgMusica.Size = new Size(227, 227);
        picImgMusica.SizeMode = PictureBoxSizeMode.Zoom;
        picImgMusica.TabIndex = 13;
        picImgMusica.TabStop = false;
        // 
        // btnImgMusicaOnline
        // 
        btnImgMusicaOnline.BackColor = Color.FromArgb(59, 58, 58);
        btnImgMusicaOnline.FlatAppearance.BorderSize = 0;
        btnImgMusicaOnline.FlatStyle = FlatStyle.Flat;
        btnImgMusicaOnline.Location = new Point(143, 247);
        btnImgMusicaOnline.Name = "btnImgMusicaOnline";
        btnImgMusicaOnline.Size = new Size(119, 25);
        btnImgMusicaOnline.TabIndex = 8;
        btnImgMusicaOnline.Text = "Pesquisar online";
        btnImgMusicaOnline.UseVisualStyleBackColor = false;
        // 
        // btnImgMusicaLocal
        // 
        btnImgMusicaLocal.BackColor = Color.FromArgb(59, 58, 58);
        btnImgMusicaLocal.FlatAppearance.BorderSize = 0;
        btnImgMusicaLocal.FlatStyle = FlatStyle.Flat;
        btnImgMusicaLocal.Location = new Point(267, 247);
        btnImgMusicaLocal.Name = "btnImgMusicaLocal";
        btnImgMusicaLocal.Size = new Size(119, 25);
        btnImgMusicaLocal.TabIndex = 9;
        btnImgMusicaLocal.Text = "Procurar";
        btnImgMusicaLocal.UseVisualStyleBackColor = false;
        // 
        // lblImgMusica
        // 
        lblImgMusica.AutoSize = true;
        lblImgMusica.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
        lblImgMusica.ForeColor = Color.Silver;
        lblImgMusica.Location = new Point(13, 212);
        lblImgMusica.Name = "lblImgMusica";
        lblImgMusica.Size = new Size(197, 30);
        lblImgMusica.TabIndex = 16;
        lblImgMusica.Text = "Imagem da musica";
        // 
        // btnAjudaPlaylist
        // 
        btnAjudaPlaylist.BackColor = Color.FromArgb(59, 58, 58);
        btnAjudaPlaylist.FlatStyle = FlatStyle.Flat;
        btnAjudaPlaylist.Location = new Point(396, 212);
        btnAjudaPlaylist.Name = "btnAjudaPlaylist";
        btnAjudaPlaylist.Size = new Size(244, 41);
        btnAjudaPlaylist.TabIndex = 37;
        btnAjudaPlaylist.Text = "Ajuda";
        btnAjudaPlaylist.UseVisualStyleBackColor = false;
        // 
        // lblNomePlaylist
        // 
        lblNomePlaylist.AutoSize = true;
        lblNomePlaylist.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
        lblNomePlaylist.ForeColor = Color.Silver;
        lblNomePlaylist.Location = new Point(13, 6);
        lblNomePlaylist.Name = "lblNomePlaylist";
        lblNomePlaylist.Size = new Size(179, 30);
        lblNomePlaylist.TabIndex = 40;
        lblNomePlaylist.Text = "Nome da Playlist";
        // 
        // picImgPlaylist
        // 
        picImgPlaylist.BackColor = Color.FromArgb(44, 44, 44);
        picImgPlaylist.Location = new Point(11, 141);
        picImgPlaylist.Name = "picImgPlaylist";
        picImgPlaylist.Size = new Size(160, 160);
        picImgPlaylist.SizeMode = PictureBoxSizeMode.Zoom;
        picImgPlaylist.TabIndex = 42;
        picImgPlaylist.TabStop = false;
        // 
        // btnImgPlaylistOnline
        // 
        btnImgPlaylistOnline.BackColor = Color.FromArgb(59, 58, 58);
        btnImgPlaylistOnline.FlatAppearance.BorderSize = 0;
        btnImgPlaylistOnline.FlatStyle = FlatStyle.Flat;
        btnImgPlaylistOnline.Location = new Point(396, 99);
        btnImgPlaylistOnline.Name = "btnImgPlaylistOnline";
        btnImgPlaylistOnline.Size = new Size(119, 28);
        btnImgPlaylistOnline.TabIndex = 35;
        btnImgPlaylistOnline.Text = "Pesquisar online";
        btnImgPlaylistOnline.UseVisualStyleBackColor = false;
        // 
        // btnImgPlaylistLocal
        // 
        btnImgPlaylistLocal.BackColor = Color.FromArgb(59, 58, 58);
        btnImgPlaylistLocal.FlatAppearance.BorderSize = 0;
        btnImgPlaylistLocal.FlatStyle = FlatStyle.Flat;
        btnImgPlaylistLocal.Location = new Point(521, 99);
        btnImgPlaylistLocal.Name = "btnImgPlaylistLocal";
        btnImgPlaylistLocal.Size = new Size(119, 28);
        btnImgPlaylistLocal.TabIndex = 36;
        btnImgPlaylistLocal.Text = "Procurar";
        btnImgPlaylistLocal.UseVisualStyleBackColor = false;
        // 
        // lblImgPlaylist
        // 
        lblImgPlaylist.AutoSize = true;
        lblImgPlaylist.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
        lblImgPlaylist.ForeColor = Color.Silver;
        lblImgPlaylist.Location = new Point(13, 65);
        lblImgPlaylist.Name = "lblImgPlaylist";
        lblImgPlaylist.Size = new Size(199, 30);
        lblImgPlaylist.TabIndex = 41;
        lblImgPlaylist.Text = "Imagem da Playlist";
        // 
        // btnSalvarPlaylist
        // 
        btnSalvarPlaylist.BackColor = Color.FromArgb(59, 58, 58);
        btnSalvarPlaylist.FlatStyle = FlatStyle.Flat;
        btnSalvarPlaylist.Location = new Point(396, 259);
        btnSalvarPlaylist.Name = "btnSalvarPlaylist";
        btnSalvarPlaylist.Size = new Size(119, 41);
        btnSalvarPlaylist.TabIndex = 38;
        btnSalvarPlaylist.Text = "Salvar";
        btnSalvarPlaylist.UseVisualStyleBackColor = false;
        // 
        // btnCancelarPlaylist
        // 
        btnCancelarPlaylist.BackColor = Color.FromArgb(59, 58, 58);
        btnCancelarPlaylist.FlatStyle = FlatStyle.Flat;
        btnCancelarPlaylist.Location = new Point(521, 259);
        btnCancelarPlaylist.Name = "btnCancelarPlaylist";
        btnCancelarPlaylist.Size = new Size(119, 41);
        btnCancelarPlaylist.TabIndex = 39;
        btnCancelarPlaylist.Text = "Cancelar";
        btnCancelarPlaylist.UseVisualStyleBackColor = false;
        // 
        // btnAjudaArtista
        // 
        btnAjudaArtista.BackColor = Color.FromArgb(59, 58, 58);
        btnAjudaArtista.FlatStyle = FlatStyle.Flat;
        btnAjudaArtista.Location = new Point(396, 212);
        btnAjudaArtista.Name = "btnAjudaArtista";
        btnAjudaArtista.Size = new Size(244, 41);
        btnAjudaArtista.TabIndex = 6;
        btnAjudaArtista.Text = "Ajuda";
        btnAjudaArtista.UseVisualStyleBackColor = false;
        // 
        // lblNomeArtista
        // 
        lblNomeArtista.AutoSize = true;
        lblNomeArtista.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
        lblNomeArtista.ForeColor = Color.Silver;
        lblNomeArtista.Location = new Point(13, 6);
        lblNomeArtista.Name = "lblNomeArtista";
        lblNomeArtista.Size = new Size(177, 30);
        lblNomeArtista.TabIndex = 22;
        lblNomeArtista.Text = "Nome do Artista";
        // 
        // picImgArtista
        // 
        picImgArtista.Location = new Point(11, 141);
        picImgArtista.Name = "picImgArtista";
        picImgArtista.Size = new Size(160, 160);
        picImgArtista.SizeMode = PictureBoxSizeMode.Zoom;
        picImgArtista.TabIndex = 32;
        picImgArtista.TabStop = false;
        // 
        // btnImgArtistaOnline
        // 
        btnImgArtistaOnline.BackColor = Color.FromArgb(59, 58, 58);
        btnImgArtistaOnline.FlatAppearance.BorderSize = 0;
        btnImgArtistaOnline.FlatStyle = FlatStyle.Flat;
        btnImgArtistaOnline.Location = new Point(396, 99);
        btnImgArtistaOnline.Name = "btnImgArtistaOnline";
        btnImgArtistaOnline.Size = new Size(119, 28);
        btnImgArtistaOnline.TabIndex = 4;
        btnImgArtistaOnline.Text = "Pesquisar online";
        btnImgArtistaOnline.UseVisualStyleBackColor = false;
        // 
        // btnImgArtistaLocal
        // 
        btnImgArtistaLocal.BackColor = Color.FromArgb(59, 58, 58);
        btnImgArtistaLocal.FlatAppearance.BorderSize = 0;
        btnImgArtistaLocal.FlatStyle = FlatStyle.Flat;
        btnImgArtistaLocal.Location = new Point(521, 99);
        btnImgArtistaLocal.Name = "btnImgArtistaLocal";
        btnImgArtistaLocal.Size = new Size(119, 28);
        btnImgArtistaLocal.TabIndex = 5;
        btnImgArtistaLocal.Text = "Procurar";
        btnImgArtistaLocal.UseVisualStyleBackColor = false;
        // 
        // lblImgArtista
        // 
        lblImgArtista.AutoSize = true;
        lblImgArtista.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
        lblImgArtista.ForeColor = Color.Silver;
        lblImgArtista.Location = new Point(13, 65);
        lblImgArtista.Name = "lblImgArtista";
        lblImgArtista.Size = new Size(197, 30);
        lblImgArtista.TabIndex = 29;
        lblImgArtista.Text = "Imagem do Artista";
        // 
        // btnSalvarArtista
        // 
        btnSalvarArtista.BackColor = Color.FromArgb(59, 58, 58);
        btnSalvarArtista.FlatStyle = FlatStyle.Flat;
        btnSalvarArtista.Location = new Point(396, 259);
        btnSalvarArtista.Name = "btnSalvarArtista";
        btnSalvarArtista.Size = new Size(119, 41);
        btnSalvarArtista.TabIndex = 7;
        btnSalvarArtista.Text = "Salvar";
        btnSalvarArtista.UseVisualStyleBackColor = false;
        // 
        // btnCancelarArtista
        // 
        btnCancelarArtista.BackColor = Color.FromArgb(59, 58, 58);
        btnCancelarArtista.FlatStyle = FlatStyle.Flat;
        btnCancelarArtista.Location = new Point(521, 259);
        btnCancelarArtista.Name = "btnCancelarArtista";
        btnCancelarArtista.Size = new Size(119, 41);
        btnCancelarArtista.TabIndex = 8;
        btnCancelarArtista.Text = "Cancelar";
        btnCancelarArtista.UseVisualStyleBackColor = false;
        // 
        // pnlCdtMusic
        // 
        pnlCdtMusic.BackColor = Color.FromArgb(44, 44, 44);
        pnlCdtMusic.Controls.Add(lblNomeDosArtistas);
        pnlCdtMusic.Controls.Add(lblImgMusica);
        pnlCdtMusic.Controls.Add(txtbxImgMusica);
        pnlCdtMusic.Controls.Add(txtbxURLMusica);
        pnlCdtMusic.Controls.Add(txtbxNomeMusica);
        pnlCdtMusic.Controls.Add(lblNomeMusica);
        pnlCdtMusic.Controls.Add(picImgMusica);
        pnlCdtMusic.Controls.Add(btnImgMusicaOnline);
        pnlCdtMusic.Controls.Add(btnURLOnlineMusic);
        pnlCdtMusic.Controls.Add(lblArtistaMusica);
        pnlCdtMusic.Controls.Add(btnImgMusicaLocal);
        pnlCdtMusic.Controls.Add(lblURLMusica);
        pnlCdtMusic.Controls.Add(btnCancelarMusica);
        pnlCdtMusic.Controls.Add(btnSalvarMusica);
        pnlCdtMusic.Location = new Point(4, 48);
        pnlCdtMusic.Margin = new Padding(3, 0, 3, 3);
        pnlCdtMusic.Name = "pnlCdtMusic";
        pnlCdtMusic.Size = new Size(669, 313);
        pnlCdtMusic.TabIndex = 21;
        // 
        // lblNomeDosArtistas
        // 
        lblNomeDosArtistas.BackColor = Color.FromArgb(59, 58, 58);
        lblNomeDosArtistas.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
        lblNomeDosArtistas.ForeColor = Color.DimGray;
        lblNomeDosArtistas.Location = new Point(13, 153);
        lblNomeDosArtistas.Name = "lblNomeDosArtistas";
        lblNomeDosArtistas.Size = new Size(409, 56);
        lblNomeDosArtistas.TabIndex = 25;
        lblNomeDosArtistas.Text = "Nome dos artistas";
        lblNomeDosArtistas.TextAlign = ContentAlignment.MiddleLeft;
        // 
        // txtbxImgMusica
        // 
        txtbxImgMusica.backColor = Color.FromArgb(59, 58, 58);
        txtbxImgMusica.LblPlaceholder = "Thumbnail (padrão)";
        txtbxImgMusica.Location = new Point(13, 239);
        txtbxImgMusica.Multiline = false;
        txtbxImgMusica.Name = "txtbxImgMusica";
        txtbxImgMusica.Password = false;
        txtbxImgMusica.Size = new Size(124, 36);
        txtbxImgMusica.TabIndex = 19;
        txtbxImgMusica.textColor = Color.DimGray;
        txtbxImgMusica.Texto = "";
        // 
        // txtbxURLMusica
        // 
        txtbxURLMusica.backColor = Color.FromArgb(59, 58, 58);
        txtbxURLMusica.LblPlaceholder = "Link do youtube";
        txtbxURLMusica.Location = new Point(13, 92);
        txtbxURLMusica.Multiline = false;
        txtbxURLMusica.Name = "txtbxURLMusica";
        txtbxURLMusica.Password = false;
        txtbxURLMusica.Size = new Size(284, 36);
        txtbxURLMusica.TabIndex = 18;
        txtbxURLMusica.textColor = Color.DimGray;
        txtbxURLMusica.Texto = "";
        // 
        // txtbxNomeMusica
        // 
        txtbxNomeMusica.backColor = Color.FromArgb(59, 58, 58);
        txtbxNomeMusica.LblPlaceholder = "";
        txtbxNomeMusica.Location = new Point(13, 32);
        txtbxNomeMusica.Multiline = false;
        txtbxNomeMusica.Name = "txtbxNomeMusica";
        txtbxNomeMusica.Password = false;
        txtbxNomeMusica.Size = new Size(409, 36);
        txtbxNomeMusica.TabIndex = 17;
        txtbxNomeMusica.textColor = Color.DimGray;
        txtbxNomeMusica.Texto = "";
        // 
        // dpdwnArtistaDaMusica1
        // 
        dpdwnArtistaDaMusica1.BackColor = Color.FromArgb(59, 58, 58);
        dpdwnArtistaDaMusica1.ColorDropdown = Color.FromArgb(59, 58, 58);
        dpdwnArtistaDaMusica1.ColorElementoDropdown = Color.Silver;
        dpdwnArtistaDaMusica1.ColorElementoTextDropdown = Color.Black;
        dpdwnArtistaDaMusica1.ColorPanelDropdown = Color.Gray;
        dpdwnArtistaDaMusica1.ColorTextDropdown = Color.Silver;
        dpdwnArtistaDaMusica1.FontTexto = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
        dpdwnArtistaDaMusica1.IdElemento = 0;
        dpdwnArtistaDaMusica1.ImgDropdown = null;
        dpdwnArtistaDaMusica1.Location = new Point(690, 48);
        dpdwnArtistaDaMusica1.MinimumSize = new Size(148, 28);
        dpdwnArtistaDaMusica1.Name = "dpdwnArtistaDaMusica1";
        dpdwnArtistaDaMusica1.QntDeElementosVisiveis = 4;
        dpdwnArtistaDaMusica1.Size = new Size(409, 28);
        dpdwnArtistaDaMusica1.TabIndex = 20;
        dpdwnArtistaDaMusica1.TamanhoDropdown = new Size(409, 28);
        dpdwnArtistaDaMusica1.TextDropdown = "Nome do artista";
        // 
        // pnlCdtArtista
        // 
        pnlCdtArtista.BackColor = Color.FromArgb(44, 44, 44);
        pnlCdtArtista.Controls.Add(lblImgArtista);
        pnlCdtArtista.Controls.Add(txtbxImgArtista);
        pnlCdtArtista.Controls.Add(txtbxNomeArtista);
        pnlCdtArtista.Controls.Add(btnAjudaArtista);
        pnlCdtArtista.Controls.Add(lblNomeArtista);
        pnlCdtArtista.Controls.Add(btnCancelarArtista);
        pnlCdtArtista.Controls.Add(picImgArtista);
        pnlCdtArtista.Controls.Add(btnSalvarArtista);
        pnlCdtArtista.Controls.Add(btnImgArtistaOnline);
        pnlCdtArtista.Controls.Add(btnImgArtistaLocal);
        pnlCdtArtista.Location = new Point(4, 48);
        pnlCdtArtista.Margin = new Padding(3, 0, 3, 3);
        pnlCdtArtista.Name = "pnlCdtArtista";
        pnlCdtArtista.Size = new Size(669, 0);
        pnlCdtArtista.TabIndex = 22;
        // 
        // txtbxImgArtista
        // 
        txtbxImgArtista.backColor = Color.FromArgb(59, 58, 58);
        txtbxImgArtista.LblPlaceholder = "Representação do artista";
        txtbxImgArtista.Location = new Point(13, 92);
        txtbxImgArtista.Multiline = false;
        txtbxImgArtista.Name = "txtbxImgArtista";
        txtbxImgArtista.Password = false;
        txtbxImgArtista.Size = new Size(379, 36);
        txtbxImgArtista.TabIndex = 34;
        txtbxImgArtista.textColor = Color.DimGray;
        txtbxImgArtista.Texto = "";
        // 
        // txtbxNomeArtista
        // 
        txtbxNomeArtista.backColor = Color.FromArgb(59, 58, 58);
        txtbxNomeArtista.LblPlaceholder = "Nome artístico";
        txtbxNomeArtista.Location = new Point(13, 32);
        txtbxNomeArtista.Multiline = false;
        txtbxNomeArtista.Name = "txtbxNomeArtista";
        txtbxNomeArtista.Password = false;
        txtbxNomeArtista.Size = new Size(627, 36);
        txtbxNomeArtista.TabIndex = 33;
        txtbxNomeArtista.textColor = Color.DimGray;
        txtbxNomeArtista.Texto = "";
        // 
        // pnlCdtPlaylist
        // 
        pnlCdtPlaylist.BackColor = Color.FromArgb(44, 44, 44);
        pnlCdtPlaylist.Controls.Add(lblImgPlaylist);
        pnlCdtPlaylist.Controls.Add(txtbxImgPlaylist);
        pnlCdtPlaylist.Controls.Add(lblNomePlaylist);
        pnlCdtPlaylist.Controls.Add(txtbxNomePlaylist);
        pnlCdtPlaylist.Controls.Add(btnAjudaPlaylist);
        pnlCdtPlaylist.Controls.Add(btnCancelarPlaylist);
        pnlCdtPlaylist.Controls.Add(picImgPlaylist);
        pnlCdtPlaylist.Controls.Add(btnSalvarPlaylist);
        pnlCdtPlaylist.Controls.Add(btnImgPlaylistOnline);
        pnlCdtPlaylist.Controls.Add(btnImgPlaylistLocal);
        pnlCdtPlaylist.Location = new Point(4, 48);
        pnlCdtPlaylist.Margin = new Padding(3, 0, 3, 3);
        pnlCdtPlaylist.Name = "pnlCdtPlaylist";
        pnlCdtPlaylist.Size = new Size(669, 0);
        pnlCdtPlaylist.TabIndex = 23;
        // 
        // txtbxImgPlaylist
        // 
        txtbxImgPlaylist.backColor = Color.FromArgb(59, 58, 58);
        txtbxImgPlaylist.LblPlaceholder = "Imagem de exibição da Playlist";
        txtbxImgPlaylist.Location = new Point(13, 92);
        txtbxImgPlaylist.Multiline = false;
        txtbxImgPlaylist.Name = "txtbxImgPlaylist";
        txtbxImgPlaylist.Password = false;
        txtbxImgPlaylist.Size = new Size(379, 36);
        txtbxImgPlaylist.TabIndex = 44;
        txtbxImgPlaylist.textColor = Color.DimGray;
        txtbxImgPlaylist.Texto = "";
        // 
        // txtbxNomePlaylist
        // 
        txtbxNomePlaylist.backColor = Color.FromArgb(59, 58, 58);
        txtbxNomePlaylist.LblPlaceholder = "";
        txtbxNomePlaylist.Location = new Point(13, 32);
        txtbxNomePlaylist.Multiline = false;
        txtbxNomePlaylist.Name = "txtbxNomePlaylist";
        txtbxNomePlaylist.Password = false;
        txtbxNomePlaylist.Size = new Size(627, 36);
        txtbxNomePlaylist.TabIndex = 43;
        txtbxNomePlaylist.textColor = Color.DimGray;
        txtbxNomePlaylist.Texto = "";
        // 
        // pnlPageNav
        // 
        pnlPageNav.Controls.Add(picPagePlaylist);
        pnlPageNav.Controls.Add(btnPagePlaylist);
        pnlPageNav.Controls.Add(picPageMusic);
        pnlPageNav.Controls.Add(btnPageMusica);
        pnlPageNav.Controls.Add(picPageArtista);
        pnlPageNav.Controls.Add(btnPageArtista);
        pnlPageNav.Location = new Point(4, 12);
        pnlPageNav.Name = "pnlPageNav";
        pnlPageNav.Size = new Size(669, 30);
        pnlPageNav.TabIndex = 24;
        // 
        // picPagePlaylist
        // 
        picPagePlaylist.Location = new Point(222, 0);
        picPagePlaylist.Margin = new Padding(3, 3, 0, 3);
        picPagePlaylist.Name = "picPagePlaylist";
        picPagePlaylist.Size = new Size(30, 30);
        picPagePlaylist.TabIndex = 30;
        picPagePlaylist.TabStop = false;
        // 
        // btnPagePlaylist
        // 
        btnPagePlaylist.BackColor = Color.FromArgb(44, 44, 44);
        btnPagePlaylist.FlatAppearance.BorderSize = 0;
        btnPagePlaylist.FlatStyle = FlatStyle.Flat;
        btnPagePlaylist.ForeColor = Color.Silver;
        btnPagePlaylist.Location = new Point(252, 0);
        btnPagePlaylist.Margin = new Padding(0, 3, 0, 3);
        btnPagePlaylist.Name = "btnPagePlaylist";
        btnPagePlaylist.Size = new Size(75, 30);
        btnPagePlaylist.TabIndex = 29;
        btnPagePlaylist.Text = "Playlist";
        btnPagePlaylist.UseVisualStyleBackColor = false;
        // 
        // picPageMusic
        // 
        picPageMusic.Location = new Point(5, 0);
        picPageMusic.Margin = new Padding(3, 3, 0, 3);
        picPageMusic.Name = "picPageMusic";
        picPageMusic.Size = new Size(30, 30);
        picPageMusic.TabIndex = 26;
        picPageMusic.TabStop = false;
        // 
        // btnPageMusica
        // 
        btnPageMusica.BackColor = Color.FromArgb(44, 44, 44);
        btnPageMusica.FlatAppearance.BorderSize = 0;
        btnPageMusica.FlatStyle = FlatStyle.Flat;
        btnPageMusica.ForeColor = Color.Silver;
        btnPageMusica.Location = new Point(35, 0);
        btnPageMusica.Margin = new Padding(0, 3, 0, 3);
        btnPageMusica.Name = "btnPageMusica";
        btnPageMusica.Size = new Size(75, 30);
        btnPageMusica.TabIndex = 25;
        btnPageMusica.Text = "Musica";
        btnPageMusica.UseVisualStyleBackColor = false;
        // 
        // picPageArtista
        // 
        picPageArtista.Location = new Point(113, 0);
        picPageArtista.Margin = new Padding(3, 3, 0, 3);
        picPageArtista.Name = "picPageArtista";
        picPageArtista.Size = new Size(30, 30);
        picPageArtista.TabIndex = 28;
        picPageArtista.TabStop = false;
        // 
        // btnPageArtista
        // 
        btnPageArtista.BackColor = Color.FromArgb(44, 44, 44);
        btnPageArtista.FlatAppearance.BorderSize = 0;
        btnPageArtista.FlatStyle = FlatStyle.Flat;
        btnPageArtista.ForeColor = Color.Silver;
        btnPageArtista.Location = new Point(143, 0);
        btnPageArtista.Margin = new Padding(0, 3, 0, 3);
        btnPageArtista.Name = "btnPageArtista";
        btnPageArtista.Size = new Size(75, 30);
        btnPageArtista.TabIndex = 27;
        btnPageArtista.Text = "Artista";
        btnPageArtista.UseVisualStyleBackColor = false;
        // 
        // lblNomeArtista1
        // 
        lblNomeArtista1.AutoSize = true;
        lblNomeArtista1.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
        lblNomeArtista1.ForeColor = Color.Silver;
        lblNomeArtista1.Location = new Point(690, 12);
        lblNomeArtista1.Name = "lblNomeArtista1";
        lblNomeArtista1.Size = new Size(191, 30);
        lblNomeArtista1.TabIndex = 26;
        lblNomeArtista1.Text = "Nome do artista 1";
        // 
        // lblNomeArtista2
        // 
        lblNomeArtista2.AutoSize = true;
        lblNomeArtista2.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
        lblNomeArtista2.ForeColor = Color.Silver;
        lblNomeArtista2.Location = new Point(690, 79);
        lblNomeArtista2.Name = "lblNomeArtista2";
        lblNomeArtista2.Size = new Size(191, 30);
        lblNomeArtista2.TabIndex = 28;
        lblNomeArtista2.Text = "Nome do artista 2";
        // 
        // dpdwnArtistaDaMusica2
        // 
        dpdwnArtistaDaMusica2.BackColor = Color.FromArgb(59, 58, 58);
        dpdwnArtistaDaMusica2.ColorDropdown = Color.FromArgb(59, 58, 58);
        dpdwnArtistaDaMusica2.ColorElementoDropdown = Color.Silver;
        dpdwnArtistaDaMusica2.ColorElementoTextDropdown = Color.Black;
        dpdwnArtistaDaMusica2.ColorPanelDropdown = Color.Gray;
        dpdwnArtistaDaMusica2.ColorTextDropdown = Color.Silver;
        dpdwnArtistaDaMusica2.FontTexto = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
        dpdwnArtistaDaMusica2.IdElemento = 0;
        dpdwnArtistaDaMusica2.ImgDropdown = null;
        dpdwnArtistaDaMusica2.Location = new Point(690, 115);
        dpdwnArtistaDaMusica2.MinimumSize = new Size(148, 28);
        dpdwnArtistaDaMusica2.Name = "dpdwnArtistaDaMusica2";
        dpdwnArtistaDaMusica2.QntDeElementosVisiveis = 4;
        dpdwnArtistaDaMusica2.Size = new Size(409, 28);
        dpdwnArtistaDaMusica2.TabIndex = 27;
        dpdwnArtistaDaMusica2.TamanhoDropdown = new Size(409, 28);
        dpdwnArtistaDaMusica2.TextDropdown = "Nome do artista";
        // 
        // lblNomeArtista4
        // 
        lblNomeArtista4.AutoSize = true;
        lblNomeArtista4.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
        lblNomeArtista4.ForeColor = Color.Silver;
        lblNomeArtista4.Location = new Point(690, 214);
        lblNomeArtista4.Name = "lblNomeArtista4";
        lblNomeArtista4.Size = new Size(191, 30);
        lblNomeArtista4.TabIndex = 32;
        lblNomeArtista4.Text = "Nome do artista 4";
        // 
        // dpdwnArtistaDaMusica4
        // 
        dpdwnArtistaDaMusica4.BackColor = Color.FromArgb(59, 58, 58);
        dpdwnArtistaDaMusica4.ColorDropdown = Color.FromArgb(59, 58, 58);
        dpdwnArtistaDaMusica4.ColorElementoDropdown = Color.Silver;
        dpdwnArtistaDaMusica4.ColorElementoTextDropdown = Color.Black;
        dpdwnArtistaDaMusica4.ColorPanelDropdown = Color.Gray;
        dpdwnArtistaDaMusica4.ColorTextDropdown = Color.Silver;
        dpdwnArtistaDaMusica4.FontTexto = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
        dpdwnArtistaDaMusica4.IdElemento = 0;
        dpdwnArtistaDaMusica4.ImgDropdown = null;
        dpdwnArtistaDaMusica4.Location = new Point(690, 250);
        dpdwnArtistaDaMusica4.MinimumSize = new Size(148, 28);
        dpdwnArtistaDaMusica4.Name = "dpdwnArtistaDaMusica4";
        dpdwnArtistaDaMusica4.QntDeElementosVisiveis = 3;
        dpdwnArtistaDaMusica4.Size = new Size(409, 28);
        dpdwnArtistaDaMusica4.TabIndex = 31;
        dpdwnArtistaDaMusica4.TamanhoDropdown = new Size(409, 28);
        dpdwnArtistaDaMusica4.TextDropdown = "Nome do artista";
        // 
        // lblNomeArtista3
        // 
        lblNomeArtista3.AutoSize = true;
        lblNomeArtista3.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
        lblNomeArtista3.ForeColor = Color.Silver;
        lblNomeArtista3.Location = new Point(690, 147);
        lblNomeArtista3.Name = "lblNomeArtista3";
        lblNomeArtista3.Size = new Size(191, 30);
        lblNomeArtista3.TabIndex = 30;
        lblNomeArtista3.Text = "Nome do artista 3";
        // 
        // dpdwnArtistaDaMusica3
        // 
        dpdwnArtistaDaMusica3.BackColor = Color.FromArgb(59, 58, 58);
        dpdwnArtistaDaMusica3.ColorDropdown = Color.FromArgb(59, 58, 58);
        dpdwnArtistaDaMusica3.ColorElementoDropdown = Color.Silver;
        dpdwnArtistaDaMusica3.ColorElementoTextDropdown = Color.Black;
        dpdwnArtistaDaMusica3.ColorPanelDropdown = Color.Gray;
        dpdwnArtistaDaMusica3.ColorTextDropdown = Color.Silver;
        dpdwnArtistaDaMusica3.FontTexto = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
        dpdwnArtistaDaMusica3.IdElemento = 0;
        dpdwnArtistaDaMusica3.ImgDropdown = null;
        dpdwnArtistaDaMusica3.Location = new Point(690, 183);
        dpdwnArtistaDaMusica3.MinimumSize = new Size(148, 28);
        dpdwnArtistaDaMusica3.Name = "dpdwnArtistaDaMusica3";
        dpdwnArtistaDaMusica3.QntDeElementosVisiveis = 4;
        dpdwnArtistaDaMusica3.Size = new Size(409, 28);
        dpdwnArtistaDaMusica3.TabIndex = 29;
        dpdwnArtistaDaMusica3.TamanhoDropdown = new Size(409, 28);
        dpdwnArtistaDaMusica3.TextDropdown = "Nome do artista";
        // 
        // lblNomeArtista5
        // 
        lblNomeArtista5.AutoSize = true;
        lblNomeArtista5.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
        lblNomeArtista5.ForeColor = Color.Silver;
        lblNomeArtista5.Location = new Point(690, 281);
        lblNomeArtista5.Name = "lblNomeArtista5";
        lblNomeArtista5.Size = new Size(191, 30);
        lblNomeArtista5.TabIndex = 34;
        lblNomeArtista5.Text = "Nome do artista 5";
        // 
        // dpdwnArtistaDaMusica5
        // 
        dpdwnArtistaDaMusica5.BackColor = Color.FromArgb(59, 58, 58);
        dpdwnArtistaDaMusica5.ColorDropdown = Color.FromArgb(59, 58, 58);
        dpdwnArtistaDaMusica5.ColorElementoDropdown = Color.Silver;
        dpdwnArtistaDaMusica5.ColorElementoTextDropdown = Color.Black;
        dpdwnArtistaDaMusica5.ColorPanelDropdown = Color.Gray;
        dpdwnArtistaDaMusica5.ColorTextDropdown = Color.Silver;
        dpdwnArtistaDaMusica5.FontTexto = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
        dpdwnArtistaDaMusica5.ForeColor = SystemColors.ControlText;
        dpdwnArtistaDaMusica5.IdElemento = 0;
        dpdwnArtistaDaMusica5.ImgDropdown = null;
        dpdwnArtistaDaMusica5.Location = new Point(690, 317);
        dpdwnArtistaDaMusica5.MinimumSize = new Size(148, 28);
        dpdwnArtistaDaMusica5.Name = "dpdwnArtistaDaMusica5";
        dpdwnArtistaDaMusica5.QntDeElementosVisiveis = 1;
        dpdwnArtistaDaMusica5.Size = new Size(409, 28);
        dpdwnArtistaDaMusica5.TabIndex = 33;
        dpdwnArtistaDaMusica5.TamanhoDropdown = new Size(409, 28);
        dpdwnArtistaDaMusica5.TextDropdown = "Nome do artista";
        // 
        // titleWindow
        // 
        titleWindow.BackColor = Color.FromArgb(27, 28, 29);
        titleWindow.Controls.Add(lblNomeArtista5);
        titleWindow.Controls.Add(dpdwnArtistaDaMusica5);
        titleWindow.Controls.Add(lblNomeArtista4);
        titleWindow.Controls.Add(dpdwnArtistaDaMusica4);
        titleWindow.Controls.Add(lblNomeArtista3);
        titleWindow.Controls.Add(dpdwnArtistaDaMusica3);
        titleWindow.Controls.Add(lblNomeArtista2);
        titleWindow.Controls.Add(dpdwnArtistaDaMusica2);
        titleWindow.Controls.Add(lblNomeArtista1);
        titleWindow.Controls.Add(dpdwnArtistaDaMusica1);
        titleWindow.Controls.Add(pnlPageNav);
        titleWindow.Controls.Add(pnlCdtPlaylist);
        titleWindow.Controls.Add(pnlCdtArtista);
        titleWindow.Controls.Add(pnlCdtMusic);
        titleWindow.Location = new Point(8, 42);
        titleWindow.Name = "titleWindow";
        titleWindow.Size = new Size(1130, 368);
        titleWindow.TabIndex = 35;
        // 
        // titleBar
        // 
        titleBar.BackColor = Color.Transparent;
        titleBar.Fechar = false;
        titleBar.LabelPosition = 1;
        titleBar.Location = new Point(8, 8);
        titleBar.Maximizar = true;
        titleBar.Minimizar = true;
        titleBar.Name = "titleBar";
        titleBar.Size = new Size(1130, 34);
        titleBar.TabIndex = 36;
        titleBar.Title = "CADASTROS";
        titleBar.WithFechar = true;
        titleBar.WithMaximizar = false;
        titleBar.WithMinimizar = false;
        // 
        // Form2
        // 
        BackColor = Color.FromArgb(21, 22, 23);
        ClientSize = new Size(1146, 418);
        Controls.Add(titleBar);
        Controls.Add(titleWindow);
        DoubleBuffered = true;
        FormBorderStyle = FormBorderStyle.None;
        MaximizeBox = false;
        MinimizeBox = false;
        Name = "Form2";
        Text = "Jasper Cadastro";
        ((System.ComponentModel.ISupportInitialize)picImgMusica).EndInit();
        ((System.ComponentModel.ISupportInitialize)picImgPlaylist).EndInit();
        ((System.ComponentModel.ISupportInitialize)picImgArtista).EndInit();
        pnlCdtMusic.ResumeLayout(false);
        pnlCdtMusic.PerformLayout();
        pnlCdtArtista.ResumeLayout(false);
        pnlCdtArtista.PerformLayout();
        pnlCdtPlaylist.ResumeLayout(false);
        pnlCdtPlaylist.PerformLayout();
        pnlPageNav.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)picPagePlaylist).EndInit();
        ((System.ComponentModel.ISupportInitialize)picPageMusic).EndInit();
        ((System.ComponentModel.ISupportInitialize)picPageArtista).EndInit();
        titleWindow.ResumeLayout(false);
        titleWindow.PerformLayout();
        ResumeLayout(false);
    }

    #endregion
    private Label lblNomeMusica;
    private Label lblURLMusica;
    private Button btnSalvarMusica;
    private Button btnCancelarMusica;
    private Label lblArtistaMusica;
    private Button btnURLOnlineMusic;
    private PictureBox picImgMusica;
    private Button btnImgMusicaOnline;
    private Button btnImgMusicaLocal;
    private Label lblImgMusica;
    private Label lblNomeArtista;
    private PictureBox picImgArtista;
    private Button btnImgArtistaOnline;
    private Button btnImgArtistaLocal;
    private Label lblImgArtista;
    private Button btnSalvarArtista;
    private Button btnCancelarArtista;
    private Button btnAjudaArtista;
    private Button btnAjudaPlaylist;
    private Label lblNomePlaylist;
    private PictureBox picImgPlaylist;
    private Button btnImgPlaylistOnline;
    private Button btnImgPlaylistLocal;
    private Label lblImgPlaylist;
    private Button btnSalvarPlaylist;
    private Button btnCancelarPlaylist;
    private Panel pnlCdtMusic;
    private Panel pnlCdtArtista;
    private Panel pnlCdtPlaylist;
    private Panel pnlPageNav;
    private Button btnPageMusica;
    private PictureBox picPageMusic;
    private PictureBox picPagePlaylist;
    private Button btnPagePlaylist;
    private PictureBox picPageArtista;
    private Button btnPageArtista;
    private System.Windows.Forms.Timer timer1;
    private NthControls.CustomTextbox txtbxNomeMusica;
    private NthControls.CustomTextbox txtbxURLMusica;
    private NthControls.CustomTextbox txtbxImgMusica;
    private NthControls.CustomTextbox txtbxNomeArtista;
    private NthControls.CustomTextbox txtbxImgArtista;
    private NthControls.CustomTextbox txtbxNomePlaylist;
    private NthControls.CustomTextbox txtbxImgPlaylist;
    private Dropdown dpdwnArtistaDaMusica1;
    private Label lblNomeDosArtistas;
    private Label lblNomeArtista1;
    private Label lblNomeArtista2;
    private Dropdown dpdwnArtistaDaMusica2;
    private Label lblNomeArtista4;
    private Dropdown dpdwnArtistaDaMusica4;
    private Label lblNomeArtista3;
    private Dropdown dpdwnArtistaDaMusica3;
    private Label lblNomeArtista5;
    private Dropdown dpdwnArtistaDaMusica5;
    private Panel titleWindow;
    private NthControls.TitleBarPersonalizada titleBar;
}
