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
            flwpnlPlaylists = new FlowLayoutPanel();
            lblPlaylists = new Label();
            pnlToolbox = new Panel();
            picBtnAdicionarMusic = new PictureBox();
            pnlDetailsMusic = new Panel();
            lblTocandoAgora = new Label();
            lblPlaylistAtual = new Label();
            sldVolumeMusic = new NthControls.Slider();
            lblArtistaMusic = new Label();
            lblDuracaoMusic = new Label();
            lblNomeMusic = new Label();
            picSoundMusic = new PictureBox();
            picImgMusic = new PictureBox();
            pnlControlMusic = new Panel();
            sldTimelineMusic = new NthControls.Slider();
            picBtnAvancarMusic = new PictureBox();
            picBtnRetroMusic = new PictureBox();
            picBtnAleatorioMusic = new PictureBox();
            picBtnRepetirMusic = new PictureBox();
            picBtnPrevMusic = new PictureBox();
            picBtnNextMusic = new PictureBox();
            picBtnPlayMusic = new PictureBox();
            flwpnlListMusic = new FlowLayoutPanel();
            flwpnlPlaylistsTransition = new System.Windows.Forms.Timer(components);
            lblCRUDTodasMusicas = new NthControls.LabelCRUD();
            pnlToolbox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picBtnAdicionarMusic).BeginInit();
            pnlDetailsMusic.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picSoundMusic).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picImgMusic).BeginInit();
            pnlControlMusic.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picBtnAvancarMusic).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picBtnRetroMusic).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picBtnAleatorioMusic).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picBtnRepetirMusic).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picBtnPrevMusic).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picBtnNextMusic).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picBtnPlayMusic).BeginInit();
            SuspendLayout();
            // 
            // flwpnlPlaylists
            // 
            flwpnlPlaylists.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            flwpnlPlaylists.BackColor = Color.FromArgb(9, 13, 17);
            flwpnlPlaylists.Location = new Point(0, 100);
            flwpnlPlaylists.Margin = new Padding(0);
            flwpnlPlaylists.Name = "flwpnlPlaylists";
            flwpnlPlaylists.Size = new Size(376, 824);
            flwpnlPlaylists.TabIndex = 0;
            // 
            // lblPlaylists
            // 
            lblPlaylists.BackColor = Color.FromArgb(4, 8, 11);
            lblPlaylists.Font = new Font("Verdana", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblPlaylists.ForeColor = Color.DarkGray;
            lblPlaylists.Location = new Point(0, 0);
            lblPlaylists.Margin = new Padding(0);
            lblPlaylists.Name = "lblPlaylists";
            lblPlaylists.Size = new Size(376, 45);
            lblPlaylists.TabIndex = 0;
            lblPlaylists.Text = "Playlists:...";
            // 
            // pnlToolbox
            // 
            pnlToolbox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pnlToolbox.BackColor = Color.FromArgb(21, 22, 23);
            pnlToolbox.Controls.Add(picBtnAdicionarMusic);
            pnlToolbox.Location = new Point(376, 0);
            pnlToolbox.Name = "pnlToolbox";
            pnlToolbox.Size = new Size(893, 100);
            pnlToolbox.TabIndex = 1;
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
            // picSoundMusic
            // 
            picSoundMusic.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            picSoundMusic.BackColor = Color.Transparent;
            picSoundMusic.Image = (Image)resources.GetObject("picSoundMusic.Image");
            picSoundMusic.Location = new Point(23, 831);
            picSoundMusic.Name = "picSoundMusic";
            picSoundMusic.Size = new Size(75, 75);
            picSoundMusic.SizeMode = PictureBoxSizeMode.Zoom;
            picSoundMusic.TabIndex = 7;
            picSoundMusic.TabStop = false;
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
            // pnlControlMusic
            // 
            pnlControlMusic.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pnlControlMusic.BackColor = Color.FromArgb(21, 22, 23);
            pnlControlMusic.Controls.Add(sldTimelineMusic);
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
            // sldTimelineMusic
            // 
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
            // picBtnAvancarMusic
            // 
            picBtnAvancarMusic.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
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
            // picBtnRetroMusic
            // 
            picBtnRetroMusic.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
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
            // picBtnAleatorioMusic
            // 
            picBtnAleatorioMusic.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            picBtnAleatorioMusic.BackColor = Color.Transparent;
            picBtnAleatorioMusic.Image = (Image)resources.GetObject("picBtnAleatorioMusic.Image");
            picBtnAleatorioMusic.Location = new Point(221, 30);
            picBtnAleatorioMusic.Margin = new Padding(8);
            picBtnAleatorioMusic.Name = "picBtnAleatorioMusic";
            picBtnAleatorioMusic.Size = new Size(50, 50);
            picBtnAleatorioMusic.SizeMode = PictureBoxSizeMode.Zoom;
            picBtnAleatorioMusic.TabIndex = 4;
            picBtnAleatorioMusic.TabStop = false;
            // 
            // picBtnRepetirMusic
            // 
            picBtnRepetirMusic.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            picBtnRepetirMusic.BackColor = Color.Transparent;
            picBtnRepetirMusic.Image = (Image)resources.GetObject("picBtnRepetirMusic.Image");
            picBtnRepetirMusic.Location = new Point(630, 30);
            picBtnRepetirMusic.Margin = new Padding(8);
            picBtnRepetirMusic.Name = "picBtnRepetirMusic";
            picBtnRepetirMusic.Size = new Size(50, 50);
            picBtnRepetirMusic.SizeMode = PictureBoxSizeMode.Zoom;
            picBtnRepetirMusic.TabIndex = 3;
            picBtnRepetirMusic.TabStop = false;
            // 
            // picBtnPrevMusic
            // 
            picBtnPrevMusic.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            picBtnPrevMusic.BackColor = Color.Transparent;
            picBtnPrevMusic.Image = (Image)resources.GetObject("picBtnPrevMusic.Image");
            picBtnPrevMusic.Location = new Point(348, 30);
            picBtnPrevMusic.Name = "picBtnPrevMusic";
            picBtnPrevMusic.Size = new Size(50, 50);
            picBtnPrevMusic.SizeMode = PictureBoxSizeMode.Zoom;
            picBtnPrevMusic.TabIndex = 2;
            picBtnPrevMusic.TabStop = false;
            // 
            // picBtnNextMusic
            // 
            picBtnNextMusic.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            picBtnNextMusic.BackColor = Color.Transparent;
            picBtnNextMusic.Image = (Image)resources.GetObject("picBtnNextMusic.Image");
            picBtnNextMusic.Location = new Point(503, 30);
            picBtnNextMusic.Name = "picBtnNextMusic";
            picBtnNextMusic.Size = new Size(50, 50);
            picBtnNextMusic.SizeMode = PictureBoxSizeMode.Zoom;
            picBtnNextMusic.TabIndex = 1;
            picBtnNextMusic.TabStop = false;
            // 
            // picBtnPlayMusic
            // 
            picBtnPlayMusic.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            picBtnPlayMusic.BackColor = Color.Transparent;
            picBtnPlayMusic.Image = (Image)resources.GetObject("picBtnPlayMusic.Image");
            picBtnPlayMusic.Location = new Point(413, 17);
            picBtnPlayMusic.Name = "picBtnPlayMusic";
            picBtnPlayMusic.Size = new Size(75, 75);
            picBtnPlayMusic.SizeMode = PictureBoxSizeMode.Zoom;
            picBtnPlayMusic.TabIndex = 0;
            picBtnPlayMusic.TabStop = false;
            // 
            // flwpnlListMusic
            // 
            flwpnlListMusic.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            flwpnlListMusic.AutoScroll = true;
            flwpnlListMusic.AutoSize = true;
            flwpnlListMusic.BackColor = Color.FromArgb(44, 44, 44);
            flwpnlListMusic.Location = new Point(376, 100);
            flwpnlListMusic.Margin = new Padding(0);
            flwpnlListMusic.Name = "flwpnlListMusic";
            flwpnlListMusic.Size = new Size(893, 714);
            flwpnlListMusic.TabIndex = 3;
            // 
            // flwpnlPlaylistsTransition
            // 
            flwpnlPlaylistsTransition.Interval = 10;
            flwpnlPlaylistsTransition.Tick += TransicaoPlaylistsAbrir;
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
            lblCRUDTodasMusicas.Location = new Point(0, 44);
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
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Black;
            ClientSize = new Size(1719, 924);
            Controls.Add(lblCRUDTodasMusicas);
            Controls.Add(lblPlaylists);
            Controls.Add(pnlControlMusic);
            Controls.Add(flwpnlListMusic);
            Controls.Add(pnlDetailsMusic);
            Controls.Add(flwpnlPlaylists);
            Controls.Add(pnlToolbox);
            ForeColor = SystemColors.ControlText;
            Name = "Form1";
            Text = "ArpeggioMain";
            pnlToolbox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)picBtnAdicionarMusic).EndInit();
            pnlDetailsMusic.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)picSoundMusic).EndInit();
            ((System.ComponentModel.ISupportInitialize)picImgMusic).EndInit();
            pnlControlMusic.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)picBtnAvancarMusic).EndInit();
            ((System.ComponentModel.ISupportInitialize)picBtnRetroMusic).EndInit();
            ((System.ComponentModel.ISupportInitialize)picBtnAleatorioMusic).EndInit();
            ((System.ComponentModel.ISupportInitialize)picBtnRepetirMusic).EndInit();
            ((System.ComponentModel.ISupportInitialize)picBtnPrevMusic).EndInit();
            ((System.ComponentModel.ISupportInitialize)picBtnNextMusic).EndInit();
            ((System.ComponentModel.ISupportInitialize)picBtnPlayMusic).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        /*
   lblPlaylists.Parent = flwpnlPlaylists;
   picBtnAdicionarMusic.Parent = pnlToolbox;
   lblArtistaMusic.Parent = pnlDetailsMusic;
   lblDuracaoMusic.Parent = pnlDetailsMusic;
   lblNomeMusic.Parent = pnlDetailsMusic;
   picSoundMusic.Parent = pnlDetailsMusic;
   picImgMusic.Parent = pnlDetailsMusic;
   picBtnAvancarMusic.Parent = pnlControlMusic;
   picBtnRetroMusic.Parent = pnlControlMusic;
   picBtnAleatorioMusic.Parent = pnlControlMusic;
   picBtnRepetirMusic.Parent = pnlControlMusic;
   picBtnPrevMusic.Parent = pnlControlMusic;
   picBtnNextMusic.Parent = pnlControlMusic;
   picBtnPlayMusic.Parent = pnlControlMusic;
*/

        #endregion

        private FlowLayoutPanel flwpnlPlaylists;
        private Label lblPlaylists;
        private Panel pnlToolbox;
        private Panel pnlDetailsMusic;
        private PictureBox picImgMusic;
        private Panel pnlControlMusic;
        private FlowLayoutPanel flwpnlListMusic;
        private PictureBox picBtnAleatorioMusic;
        private PictureBox picBtnRepetirMusic;
        private PictureBox picBtnPrevMusic;
        private PictureBox picBtnNextMusic;
        private PictureBox picBtnPlayMusic;
        private ProgressBar pgbarDuracaoMusic;
        private PictureBox picSoundMusic;
        private PictureBox picBtnRetroMusic;
        private PictureBox picBtnAvancarMusic;
        private PictureBox picBtnAdicionarMusic;
        private Label lblNomeMusic;
        private Label lblArtistaMusic;
        private Label lblDuracaoMusic;
        private NthControls.Slider sldTimelineMusic;
        private NthControls.Slider sldVolumeMusic;
        private System.Windows.Forms.Timer flwpnlPlaylistsTransition;
        private NthControls.LabelCRUD lblCRUDTodasMusicas;
        private Label lblTocandoAgora;
        private Label lblPlaylistAtual;
    }
}