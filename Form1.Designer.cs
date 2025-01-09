namespace Jasper
{
    partial class Form1
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            Elementos elementos1 = new Elementos();
            Elementos elementos2 = new Elementos();
            Elementos elementos3 = new Elementos();
            Elementos elementos4 = new Elementos();
            Elementos elementos5 = new Elementos();
            Elementos elementos6 = new Elementos();
            Elementos elementos7 = new Elementos();
            Elementos elementos8 = new Elementos();
            flwpnlPlaylistsTransition = new System.Windows.Forms.Timer(components);
            picBtnAdicionarMusic = new PictureBox();
            picBtnEsconder = new PictureBox();
            pnlToolbox = new Panel();
            picBtnVisualizarFila = new PictureBox();
            flwpnlPlaylists = new FlowLayoutPanel();
            picImgMusic = new PictureBox();
            picSoundMusic = new PictureBox();
            lblNomeMusic = new Label();
            lblDuracaoMusic = new Label();
            lblArtistaMusic = new Label();
            sldVolumeMusic = new NthControls.Slider();
            lblPlaylistAtual = new Label();
            lblTocandoAgora = new Label();
            pnlDetailsMusic = new Panel();
            flwpnlListMusic = new FlowLayoutPanel();
            picBtnPlayMusic = new PictureBox();
            picBtnNextMusic = new PictureBox();
            picBtnPrevMusic = new PictureBox();
            picBtnRepetirMusic = new PictureBox();
            picBtnAleatorioMusic = new PictureBox();
            picBtnRetroMusic = new PictureBox();
            picBtnAvancarMusic = new PictureBox();
            sldTimelineMusic = new NthControls.Slider();
            pnlControlMusic = new Panel();
            lblAllTimeMusic = new Label();
            lblTimeMusic = new Label();
            lblCRUDTodasMusicas = new NthControls.LabelCRUD();
            dpdwOrganizar = new Dropdown();
            dpdwListar = new Dropdown();
            titleWindow = new Panel();
            titleBarPersonalizada1 = new NthControls.TitleBarPersonalizada();
            ((System.ComponentModel.ISupportInitialize)picBtnAdicionarMusic).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picBtnEsconder).BeginInit();
            pnlToolbox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picBtnVisualizarFila).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picImgMusic).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picSoundMusic).BeginInit();
            pnlDetailsMusic.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picBtnPlayMusic).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picBtnNextMusic).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picBtnPrevMusic).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picBtnRepetirMusic).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picBtnAleatorioMusic).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picBtnRetroMusic).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picBtnAvancarMusic).BeginInit();
            pnlControlMusic.SuspendLayout();
            titleWindow.SuspendLayout();
            SuspendLayout();
            // 
            // flwpnlPlaylistsTransition
            // 
            flwpnlPlaylistsTransition.Interval = 10;
            flwpnlPlaylistsTransition.Tick += TransicaoPlaylistsAbrir;
            // 
            // picBtnAdicionarMusic
            // 
            picBtnAdicionarMusic.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            picBtnAdicionarMusic.BackColor = Color.Transparent;
            picBtnAdicionarMusic.Image = (Image)resources.GetObject("picBtnAdicionarMusic.Image");
            picBtnAdicionarMusic.Location = new Point(805, 12);
            picBtnAdicionarMusic.Name = "picBtnAdicionarMusic";
            picBtnAdicionarMusic.Size = new Size(75, 75);
            picBtnAdicionarMusic.TabIndex = 1;
            picBtnAdicionarMusic.TabStop = false;
            // 
            // picBtnEsconder
            // 
            picBtnEsconder.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            picBtnEsconder.BackColor = Color.Transparent;
            picBtnEsconder.Image = (Image)resources.GetObject("picBtnEsconder.Image");
            picBtnEsconder.Location = new Point(749, 37);
            picBtnEsconder.Name = "picBtnEsconder";
            picBtnEsconder.Size = new Size(50, 50);
            picBtnEsconder.SizeMode = PictureBoxSizeMode.Zoom;
            picBtnEsconder.TabIndex = 2;
            picBtnEsconder.TabStop = false;
            // 
            // pnlToolbox
            // 
            pnlToolbox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pnlToolbox.BackColor = Color.FromArgb(21, 22, 23);
            pnlToolbox.Controls.Add(picBtnVisualizarFila);
            pnlToolbox.Controls.Add(picBtnEsconder);
            pnlToolbox.Controls.Add(picBtnAdicionarMusic);
            pnlToolbox.Location = new Point(376, 0);
            pnlToolbox.Name = "pnlToolbox";
            pnlToolbox.Size = new Size(893, 100);
            pnlToolbox.TabIndex = 1;
            // 
            // picBtnVisualizarFila
            // 
            picBtnVisualizarFila.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            picBtnVisualizarFila.BackColor = Color.Transparent;
            picBtnVisualizarFila.Image = Properties.Resources.AdicionarAFila;
            picBtnVisualizarFila.Location = new Point(693, 37);
            picBtnVisualizarFila.Name = "picBtnVisualizarFila";
            picBtnVisualizarFila.Size = new Size(50, 50);
            picBtnVisualizarFila.SizeMode = PictureBoxSizeMode.Zoom;
            picBtnVisualizarFila.TabIndex = 3;
            picBtnVisualizarFila.TabStop = false;
            // 
            // flwpnlPlaylists
            // 
            flwpnlPlaylists.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            flwpnlPlaylists.BackColor = Color.FromArgb(9, 13, 17);
            flwpnlPlaylists.Location = new Point(0, 101);
            flwpnlPlaylists.Margin = new Padding(0);
            flwpnlPlaylists.Name = "flwpnlPlaylists";
            flwpnlPlaylists.Size = new Size(376, 823);
            flwpnlPlaylists.TabIndex = 0;
            // 
            // picImgMusic
            // 
            picImgMusic.BackColor = Color.White;
            picImgMusic.Location = new Point(75, 162);
            picImgMusic.Name = "picImgMusic";
            picImgMusic.Size = new Size(300, 300);
            picImgMusic.SizeMode = PictureBoxSizeMode.Zoom;
            picImgMusic.TabIndex = 0;
            picImgMusic.TabStop = false;
            // 
            // picSoundMusic
            // 
            picSoundMusic.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            picSoundMusic.BackColor = Color.Transparent;
            picSoundMusic.Image = Properties.Resources.Mudo;
            picSoundMusic.Location = new Point(23, 831);
            picSoundMusic.Name = "picSoundMusic";
            picSoundMusic.Size = new Size(75, 75);
            picSoundMusic.SizeMode = PictureBoxSizeMode.Zoom;
            picSoundMusic.TabIndex = 7;
            picSoundMusic.TabStop = false;
            // 
            // lblNomeMusic
            // 
            lblNomeMusic.BackColor = Color.Transparent;
            lblNomeMusic.Font = new Font("Verdana", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblNomeMusic.ForeColor = SystemColors.ButtonFace;
            lblNomeMusic.Location = new Point(42, 465);
            lblNomeMusic.Margin = new Padding(0);
            lblNomeMusic.Name = "lblNomeMusic";
            lblNomeMusic.Size = new Size(373, 45);
            lblNomeMusic.TabIndex = 8;
            lblNomeMusic.Text = "Nome da Musica";
            lblNomeMusic.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblDuracaoMusic
            // 
            lblDuracaoMusic.BackColor = Color.Transparent;
            lblDuracaoMusic.Font = new Font("Verdana", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblDuracaoMusic.ForeColor = SystemColors.AppWorkspace;
            lblDuracaoMusic.Location = new Point(42, 530);
            lblDuracaoMusic.Margin = new Padding(0);
            lblDuracaoMusic.Name = "lblDuracaoMusic";
            lblDuracaoMusic.Size = new Size(373, 21);
            lblDuracaoMusic.TabIndex = 9;
            lblDuracaoMusic.Text = "12:34";
            lblDuracaoMusic.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblArtistaMusic
            // 
            lblArtistaMusic.BackColor = Color.Transparent;
            lblArtistaMusic.Font = new Font("Verdana", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblArtistaMusic.ForeColor = SystemColors.AppWorkspace;
            lblArtistaMusic.Location = new Point(42, 499);
            lblArtistaMusic.Margin = new Padding(0);
            lblArtistaMusic.Name = "lblArtistaMusic";
            lblArtistaMusic.Size = new Size(373, 31);
            lblArtistaMusic.TabIndex = 10;
            lblArtistaMusic.Text = "Artistas";
            lblArtistaMusic.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // sldVolumeMusic
            // 
            sldVolumeMusic.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            sldVolumeMusic.CorBotao = Color.FromArgb(86, 87, 101);
            sldVolumeMusic.CorPreenchido1 = Color.FromArgb(77, 83, 158);
            sldVolumeMusic.CorPreenchido2 = Color.FromArgb(160, 160, 160);
            sldVolumeMusic.CorVazio = Color.FromArgb(86, 87, 101);
            sldVolumeMusic.Habilitado = true;
            sldVolumeMusic.Location = new Point(104, 858);
            sldVolumeMusic.Maximum = 100;
            sldVolumeMusic.Minimum = 0;
            sldVolumeMusic.Name = "sldVolumeMusic";
            sldVolumeMusic.Size = new Size(334, 20);
            sldVolumeMusic.TabIndex = 11;
            sldVolumeMusic.Text = "slider2";
            sldVolumeMusic.ThumbSize = 16;
            sldVolumeMusic.TrackHeight = 4;
            sldVolumeMusic.Value = 50;
            sldVolumeMusic.ValueMouse = 50;
            sldVolumeMusic.WithPoint = true;
            // 
            // lblPlaylistAtual
            // 
            lblPlaylistAtual.BackColor = Color.Transparent;
            lblPlaylistAtual.Font = new Font("Verdana", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblPlaylistAtual.ForeColor = SystemColors.ButtonFace;
            lblPlaylistAtual.Location = new Point(42, 42);
            lblPlaylistAtual.Margin = new Padding(0);
            lblPlaylistAtual.Name = "lblPlaylistAtual";
            lblPlaylistAtual.Size = new Size(373, 45);
            lblPlaylistAtual.TabIndex = 12;
            lblPlaylistAtual.Text = "Nome da Playlist";
            lblPlaylistAtual.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblTocandoAgora
            // 
            lblTocandoAgora.BackColor = Color.Transparent;
            lblTocandoAgora.Font = new Font("Verdana", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTocandoAgora.ForeColor = SystemColors.AppWorkspace;
            lblTocandoAgora.Location = new Point(42, 22);
            lblTocandoAgora.Margin = new Padding(0);
            lblTocandoAgora.Name = "lblTocandoAgora";
            lblTocandoAgora.Size = new Size(373, 31);
            lblTocandoAgora.TabIndex = 13;
            lblTocandoAgora.Text = "Tocando agora...";
            lblTocandoAgora.TextAlign = ContentAlignment.BottomCenter;
            // 
            // pnlDetailsMusic
            // 
            pnlDetailsMusic.BackColor = Color.FromArgb(9, 13, 17);
            pnlDetailsMusic.Controls.Add(lblTocandoAgora);
            pnlDetailsMusic.Controls.Add(lblPlaylistAtual);
            pnlDetailsMusic.Controls.Add(sldVolumeMusic);
            pnlDetailsMusic.Controls.Add(lblArtistaMusic);
            pnlDetailsMusic.Controls.Add(lblDuracaoMusic);
            pnlDetailsMusic.Controls.Add(lblNomeMusic);
            pnlDetailsMusic.Controls.Add(picSoundMusic);
            pnlDetailsMusic.Controls.Add(picImgMusic);
            pnlDetailsMusic.Dock = DockStyle.Right;
            pnlDetailsMusic.Location = new Point(1269, 0);
            pnlDetailsMusic.Name = "pnlDetailsMusic";
            pnlDetailsMusic.Size = new Size(450, 924);
            pnlDetailsMusic.TabIndex = 2;
            // 
            // flwpnlListMusic
            // 
            flwpnlListMusic.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            flwpnlListMusic.AutoScroll = true;
            flwpnlListMusic.BackColor = Color.FromArgb(44, 44, 44);
            flwpnlListMusic.Location = new Point(376, 100);
            flwpnlListMusic.Margin = new Padding(0);
            flwpnlListMusic.Name = "flwpnlListMusic";
            flwpnlListMusic.Size = new Size(893, 714);
            flwpnlListMusic.TabIndex = 3;
            // 
            // picBtnPlayMusic
            // 
            picBtnPlayMusic.Anchor = AnchorStyles.Bottom;
            picBtnPlayMusic.BackColor = Color.Transparent;
            picBtnPlayMusic.Image = Properties.Resources.Play;
            picBtnPlayMusic.Location = new Point(413, 17);
            picBtnPlayMusic.Name = "picBtnPlayMusic";
            picBtnPlayMusic.Size = new Size(75, 75);
            picBtnPlayMusic.SizeMode = PictureBoxSizeMode.Zoom;
            picBtnPlayMusic.TabIndex = 0;
            picBtnPlayMusic.TabStop = false;
            // 
            // picBtnNextMusic
            // 
            picBtnNextMusic.Anchor = AnchorStyles.Bottom;
            picBtnNextMusic.BackColor = Color.Transparent;
            picBtnNextMusic.Image = (Image)resources.GetObject("picBtnNextMusic.Image");
            picBtnNextMusic.Location = new Point(503, 30);
            picBtnNextMusic.Name = "picBtnNextMusic";
            picBtnNextMusic.Size = new Size(50, 50);
            picBtnNextMusic.SizeMode = PictureBoxSizeMode.Zoom;
            picBtnNextMusic.TabIndex = 1;
            picBtnNextMusic.TabStop = false;
            // 
            // picBtnPrevMusic
            // 
            picBtnPrevMusic.Anchor = AnchorStyles.Bottom;
            picBtnPrevMusic.BackColor = Color.Transparent;
            picBtnPrevMusic.Image = (Image)resources.GetObject("picBtnPrevMusic.Image");
            picBtnPrevMusic.Location = new Point(348, 30);
            picBtnPrevMusic.Name = "picBtnPrevMusic";
            picBtnPrevMusic.Size = new Size(50, 50);
            picBtnPrevMusic.SizeMode = PictureBoxSizeMode.Zoom;
            picBtnPrevMusic.TabIndex = 2;
            picBtnPrevMusic.TabStop = false;
            // 
            // picBtnRepetirMusic
            // 
            picBtnRepetirMusic.Anchor = AnchorStyles.Bottom;
            picBtnRepetirMusic.BackColor = Color.Transparent;
            picBtnRepetirMusic.Image = Properties.Resources.RepetirDesabilitado;
            picBtnRepetirMusic.Location = new Point(630, 30);
            picBtnRepetirMusic.Margin = new Padding(8);
            picBtnRepetirMusic.Name = "picBtnRepetirMusic";
            picBtnRepetirMusic.Size = new Size(50, 50);
            picBtnRepetirMusic.SizeMode = PictureBoxSizeMode.Zoom;
            picBtnRepetirMusic.TabIndex = 3;
            picBtnRepetirMusic.TabStop = false;
            // 
            // picBtnAleatorioMusic
            // 
            picBtnAleatorioMusic.Anchor = AnchorStyles.Bottom;
            picBtnAleatorioMusic.BackColor = Color.Transparent;
            picBtnAleatorioMusic.Image = Properties.Resources.AleatorizarDesabilitado;
            picBtnAleatorioMusic.Location = new Point(221, 30);
            picBtnAleatorioMusic.Margin = new Padding(8);
            picBtnAleatorioMusic.Name = "picBtnAleatorioMusic";
            picBtnAleatorioMusic.Size = new Size(50, 50);
            picBtnAleatorioMusic.SizeMode = PictureBoxSizeMode.Zoom;
            picBtnAleatorioMusic.TabIndex = 4;
            picBtnAleatorioMusic.TabStop = false;
            // 
            // picBtnRetroMusic
            // 
            picBtnRetroMusic.Anchor = AnchorStyles.Bottom;
            picBtnRetroMusic.BackColor = Color.Transparent;
            picBtnRetroMusic.Image = (Image)resources.GetObject("picBtnRetroMusic.Image");
            picBtnRetroMusic.Location = new Point(287, 30);
            picBtnRetroMusic.Margin = new Padding(8);
            picBtnRetroMusic.Name = "picBtnRetroMusic";
            picBtnRetroMusic.Size = new Size(50, 50);
            picBtnRetroMusic.SizeMode = PictureBoxSizeMode.Zoom;
            picBtnRetroMusic.TabIndex = 5;
            picBtnRetroMusic.TabStop = false;
            // 
            // picBtnAvancarMusic
            // 
            picBtnAvancarMusic.Anchor = AnchorStyles.Bottom;
            picBtnAvancarMusic.BackColor = Color.Transparent;
            picBtnAvancarMusic.Image = (Image)resources.GetObject("picBtnAvancarMusic.Image");
            picBtnAvancarMusic.Location = new Point(564, 30);
            picBtnAvancarMusic.Margin = new Padding(8);
            picBtnAvancarMusic.Name = "picBtnAvancarMusic";
            picBtnAvancarMusic.Size = new Size(50, 50);
            picBtnAvancarMusic.SizeMode = PictureBoxSizeMode.Zoom;
            picBtnAvancarMusic.TabIndex = 6;
            picBtnAvancarMusic.TabStop = false;
            // 
            // sldTimelineMusic
            // 
            sldTimelineMusic.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            sldTimelineMusic.CorBotao = Color.FromArgb(191, 195, 198);
            sldTimelineMusic.CorPreenchido1 = Color.FromArgb(77, 83, 158);
            sldTimelineMusic.CorPreenchido2 = Color.FromArgb(160, 160, 160);
            sldTimelineMusic.CorVazio = Color.FromArgb(86, 87, 101);
            sldTimelineMusic.Habilitado = true;
            sldTimelineMusic.Location = new Point(-10, 0);
            sldTimelineMusic.Maximum = 100;
            sldTimelineMusic.Minimum = 0;
            sldTimelineMusic.Name = "sldTimelineMusic";
            sldTimelineMusic.Size = new Size(913, 5);
            sldTimelineMusic.TabIndex = 8;
            sldTimelineMusic.Text = "slider1";
            sldTimelineMusic.ThumbSize = 16;
            sldTimelineMusic.TrackHeight = 5;
            sldTimelineMusic.Value = 70;
            sldTimelineMusic.ValueMouse = 70;
            sldTimelineMusic.WithPoint = false;
            // 
            // pnlControlMusic
            // 
            pnlControlMusic.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pnlControlMusic.BackColor = Color.FromArgb(21, 22, 23);
            pnlControlMusic.Controls.Add(lblAllTimeMusic);
            pnlControlMusic.Controls.Add(sldTimelineMusic);
            pnlControlMusic.Controls.Add(lblTimeMusic);
            pnlControlMusic.Controls.Add(picBtnAvancarMusic);
            pnlControlMusic.Controls.Add(picBtnRetroMusic);
            pnlControlMusic.Controls.Add(picBtnAleatorioMusic);
            pnlControlMusic.Controls.Add(picBtnRepetirMusic);
            pnlControlMusic.Controls.Add(picBtnPrevMusic);
            pnlControlMusic.Controls.Add(picBtnNextMusic);
            pnlControlMusic.Controls.Add(picBtnPlayMusic);
            pnlControlMusic.Location = new Point(376, 814);
            pnlControlMusic.Name = "pnlControlMusic";
            pnlControlMusic.Size = new Size(893, 110);
            pnlControlMusic.TabIndex = 2;
            // 
            // lblAllTimeMusic
            // 
            lblAllTimeMusic.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblAllTimeMusic.AutoSize = true;
            lblAllTimeMusic.Font = new Font("Verdana", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblAllTimeMusic.ForeColor = Color.Silver;
            lblAllTimeMusic.Location = new Point(842, 8);
            lblAllTimeMusic.Name = "lblAllTimeMusic";
            lblAllTimeMusic.Size = new Size(48, 16);
            lblAllTimeMusic.TabIndex = 39;
            lblAllTimeMusic.Text = "00:00";
            // 
            // lblTimeMusic
            // 
            lblTimeMusic.AutoSize = true;
            lblTimeMusic.Font = new Font("Verdana", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTimeMusic.ForeColor = Color.Silver;
            lblTimeMusic.Location = new Point(3, 8);
            lblTimeMusic.Name = "lblTimeMusic";
            lblTimeMusic.Size = new Size(48, 16);
            lblTimeMusic.TabIndex = 38;
            lblTimeMusic.Text = "00:00";
            // 
            // lblCRUDTodasMusicas
            // 
            lblCRUDTodasMusicas.BackColor = Color.FromArgb(44, 44, 44);
            lblCRUDTodasMusicas.CorBackGround = Color.FromArgb(44, 44, 44);
            lblCRUDTodasMusicas.CorFontBackGround = Color.Silver;
            lblCRUDTodasMusicas.DiferencaCor = 0.9F;
            lblCRUDTodasMusicas.ForeColor = SystemColors.ControlText;
            lblCRUDTodasMusicas.Id = 0;
            lblCRUDTodasMusicas.ImgDeletar = null;
            lblCRUDTodasMusicas.ImgEditar = null;
            lblCRUDTodasMusicas.ImgExpandir = null;
            lblCRUDTodasMusicas.ImgPrincipal = (Image)resources.GetObject("lblCRUDTodasMusicas.ImgPrincipal");
            lblCRUDTodasMusicas.Location = new Point(0, 45);
            lblCRUDTodasMusicas.Margin = new Padding(0);
            lblCRUDTodasMusicas.Name = "lblCRUDTodasMusicas";
            lblCRUDTodasMusicas.Size = new Size(376, 56);
            lblCRUDTodasMusicas.TabIndex = 4;
            lblCRUDTodasMusicas.Texto = "Todas";
            lblCRUDTodasMusicas.WithDelete = false;
            lblCRUDTodasMusicas.WithEdit = false;
            lblCRUDTodasMusicas.WithExpand = false;
            lblCRUDTodasMusicas.WithImg = true;
            // 
            // dpdwOrganizar
            // 
            dpdwOrganizar.BackColor = Color.FromArgb(21, 22, 23);
            dpdwOrganizar.ColorDropdown = Color.FromArgb(21, 22, 23);
            dpdwOrganizar.ColorElementoDropdown = Color.FromArgb(52, 53, 55);
            dpdwOrganizar.ColorElementoTextDropdown = Color.Silver;
            dpdwOrganizar.ColorPanelDropdown = Color.FromArgb(41, 42, 44);
            dpdwOrganizar.ColorTextDropdown = Color.Silver;
            elementos1.Id = 0;
            elementos1.Nome = "Primeiro";
            elementos2.Id = 1;
            elementos2.Nome = "Por Ultimo";
            elementos3.Id = 2;
            elementos3.Nome = "Nome A - Z";
            elementos4.Id = 3;
            elementos4.Nome = "Nome Z - A";
            elementos5.Id = 4;
            elementos5.Nome = "Artista A - Z";
            elementos6.Id = 5;
            elementos6.Nome = "Artista Z- A";
            dpdwOrganizar.Elementos.Add(elementos1);
            dpdwOrganizar.Elementos.Add(elementos2);
            dpdwOrganizar.Elementos.Add(elementos3);
            dpdwOrganizar.Elementos.Add(elementos4);
            dpdwOrganizar.Elementos.Add(elementos5);
            dpdwOrganizar.Elementos.Add(elementos6);
            dpdwOrganizar.FontTexto = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dpdwOrganizar.IdElemento = 0;
            dpdwOrganizar.ImgDropdown = Properties.Resources.Aleatorizar;
            dpdwOrganizar.Location = new Point(400, 25);
            dpdwOrganizar.MinimumSize = new Size(148, 28);
            dpdwOrganizar.Name = "dpdwOrganizar";
            dpdwOrganizar.QntDeElementosVisiveis = 6;
            dpdwOrganizar.Size = new Size(220, 50);
            dpdwOrganizar.TabIndex = 0;
            dpdwOrganizar.TamanhoDropdown = new Size(220, 50);
            dpdwOrganizar.TextDropdown = "Organizar por:";
            // 
            // dpdwListar
            // 
            dpdwListar.BackColor = Color.FromArgb(4, 8, 11);
            dpdwListar.ColorDropdown = Color.FromArgb(4, 8, 11);
            dpdwListar.ColorElementoDropdown = Color.FromArgb(9, 13, 17);
            dpdwListar.ColorElementoTextDropdown = Color.DarkGray;
            dpdwListar.ColorPanelDropdown = Color.FromArgb(4, 8, 11);
            dpdwListar.ColorTextDropdown = Color.DarkGray;
            elementos7.Id = 0;
            elementos7.Nome = "Playlists:";
            elementos8.Id = 1;
            elementos8.Nome = "Artistas:";
            dpdwListar.Elementos.Add(elementos7);
            dpdwListar.Elementos.Add(elementos8);
            dpdwListar.FontTexto = new Font("Verdana", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dpdwListar.IdElemento = 0;
            dpdwListar.ImgDropdown = null;
            dpdwListar.Location = new Point(0, 0);
            dpdwListar.Margin = new Padding(0);
            dpdwListar.MinimumSize = new Size(148, 28);
            dpdwListar.Name = "dpdwListar";
            dpdwListar.QntDeElementosVisiveis = 4;
            dpdwListar.Size = new Size(376, 45);
            dpdwListar.TabIndex = 5;
            dpdwListar.TamanhoDropdown = new Size(376, 45);
            dpdwListar.TextDropdown = "Playlists:";
            // 
            // titleWindow
            // 
            titleWindow.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            titleWindow.Controls.Add(dpdwListar);
            titleWindow.Controls.Add(dpdwOrganizar);
            titleWindow.Controls.Add(lblCRUDTodasMusicas);
            titleWindow.Controls.Add(pnlControlMusic);
            titleWindow.Controls.Add(flwpnlListMusic);
            titleWindow.Controls.Add(pnlDetailsMusic);
            titleWindow.Controls.Add(flwpnlPlaylists);
            titleWindow.Controls.Add(pnlToolbox);
            titleWindow.Location = new Point(8, 42);
            titleWindow.Name = "titleWindow";
            titleWindow.Size = new Size(1719, 924);
            titleWindow.TabIndex = 0;
            // 
            // titleBarPersonalizada1
            // 
            titleBarPersonalizada1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            titleBarPersonalizada1.BackColor = Color.Transparent;
            titleBarPersonalizada1.Fechar = true;
            titleBarPersonalizada1.LabelPosition = 1;
            titleBarPersonalizada1.Location = new Point(8, 8);
            titleBarPersonalizada1.Maximizar = true;
            titleBarPersonalizada1.Minimizar = true;
            titleBarPersonalizada1.Name = "titleBarPersonalizada1";
            titleBarPersonalizada1.Size = new Size(1719, 34);
            titleBarPersonalizada1.TabIndex = 1;
            titleBarPersonalizada1.Title = "Jasper";
            titleBarPersonalizada1.WithFechar = true;
            titleBarPersonalizada1.WithMaximizar = true;
            titleBarPersonalizada1.WithMinimizar = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(21, 22, 23);
            ClientSize = new Size(1735, 974);
            Controls.Add(titleBarPersonalizada1);
            Controls.Add(titleWindow);
            ForeColor = SystemColors.ControlText;
            FormBorderStyle = FormBorderStyle.None;
            Name = "Form1";
            Text = "ArpeggioMain";
            ((System.ComponentModel.ISupportInitialize)picBtnAdicionarMusic).EndInit();
            ((System.ComponentModel.ISupportInitialize)picBtnEsconder).EndInit();
            pnlToolbox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)picBtnVisualizarFila).EndInit();
            ((System.ComponentModel.ISupportInitialize)picImgMusic).EndInit();
            ((System.ComponentModel.ISupportInitialize)picSoundMusic).EndInit();
            pnlDetailsMusic.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)picBtnPlayMusic).EndInit();
            ((System.ComponentModel.ISupportInitialize)picBtnNextMusic).EndInit();
            ((System.ComponentModel.ISupportInitialize)picBtnPrevMusic).EndInit();
            ((System.ComponentModel.ISupportInitialize)picBtnRepetirMusic).EndInit();
            ((System.ComponentModel.ISupportInitialize)picBtnAleatorioMusic).EndInit();
            ((System.ComponentModel.ISupportInitialize)picBtnRetroMusic).EndInit();
            ((System.ComponentModel.ISupportInitialize)picBtnAvancarMusic).EndInit();
            pnlControlMusic.ResumeLayout(false);
            pnlControlMusic.PerformLayout();
            titleWindow.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private ProgressBar pgbarDuracaoMusic;
        private System.Windows.Forms.Timer flwpnlPlaylistsTransition;
        private PictureBox picBtnAdicionarMusic;
        private PictureBox picBtnEsconder;
        private Panel pnlToolbox;
        private FlowLayoutPanel flwpnlPlaylists;
        private PictureBox picImgMusic;
        private PictureBox picSoundMusic;
        private Label lblNomeMusic;
        private Label lblDuracaoMusic;
        private Label lblArtistaMusic;
        private NthControls.Slider sldVolumeMusic;
        private Label lblPlaylistAtual;
        private Label lblTocandoAgora;
        private Panel pnlDetailsMusic;
        private FlowLayoutPanel flwpnlListMusic;
        private PictureBox picBtnPlayMusic;
        private PictureBox picBtnNextMusic;
        private PictureBox picBtnPrevMusic;
        private PictureBox picBtnRepetirMusic;
        private PictureBox picBtnAleatorioMusic;
        private PictureBox picBtnRetroMusic;
        private PictureBox picBtnAvancarMusic;
        private NthControls.Slider sldTimelineMusic;
        private Panel pnlControlMusic;
        private NthControls.LabelCRUD lblCRUDTodasMusicas;
        private Dropdown dpdwOrganizar;
        private Dropdown dpdwListar;
        private Panel titleWindow;
        private NthControls.TitleBarPersonalizada titleBarPersonalizada1;
        private PictureBox picBtnVisualizarFila;
        private Label lblAllTimeMusic;
        private Label lblTimeMusic;
    }
}