namespace Jasper
{
    partial class Form4
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form4));
            titleBarPersonalizada1 = new NthControls.TitleBarPersonalizada();
            pnlWindow = new Panel();
            picSoundMusic = new PictureBox();
            sldVolume = new NthControls.Slider();
            lblDuracaoAtual = new Label();
            lblDuracaoFinal = new Label();
            lblNomePlaylist = new Label();
            lblPlaylist = new Label();
            lblNomeArtista = new Label();
            picImgMusica = new PictureBox();
            lblNomeMusica = new Label();
            sldTimelineMusic = new NthControls.Slider();
            picBtnPlayMusic = new PictureBox();
            picBtnAvancarMusic = new PictureBox();
            picBtnNextMusic = new PictureBox();
            picBtnRetroMusic = new PictureBox();
            picBtnPrevMusic = new PictureBox();
            picBtnAleatorioMusic = new PictureBox();
            picBtnRepetirMusic = new PictureBox();
            pnlWindow.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picSoundMusic).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picImgMusica).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picBtnPlayMusic).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picBtnAvancarMusic).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picBtnNextMusic).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picBtnRetroMusic).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picBtnPrevMusic).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picBtnAleatorioMusic).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picBtnRepetirMusic).BeginInit();
            SuspendLayout();
            // 
            // titleBarPersonalizada1
            // 
            titleBarPersonalizada1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            titleBarPersonalizada1.BackColor = Color.Transparent;
            titleBarPersonalizada1.LabelPosition = 1;
            titleBarPersonalizada1.Location = new Point(8, 8);
            titleBarPersonalizada1.Margin = new Padding(0);
            titleBarPersonalizada1.Name = "titleBarPersonalizada1";
            titleBarPersonalizada1.Size = new Size(700, 34);
            titleBarPersonalizada1.TabIndex = 17;
            titleBarPersonalizada1.Title = "JASPER CONTROL";
            titleBarPersonalizada1.WithFechar = true;
            titleBarPersonalizada1.WithMaximizar = false;
            titleBarPersonalizada1.WithMinimizar = false;
            // 
            // pnlWindow
            // 
            pnlWindow.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pnlWindow.BackColor = Color.FromArgb(44, 44, 44);
            pnlWindow.Controls.Add(picSoundMusic);
            pnlWindow.Controls.Add(sldVolume);
            pnlWindow.Controls.Add(lblDuracaoAtual);
            pnlWindow.Controls.Add(lblDuracaoFinal);
            pnlWindow.Controls.Add(lblNomePlaylist);
            pnlWindow.Controls.Add(lblPlaylist);
            pnlWindow.Controls.Add(lblNomeArtista);
            pnlWindow.Controls.Add(picImgMusica);
            pnlWindow.Controls.Add(lblNomeMusica);
            pnlWindow.Controls.Add(sldTimelineMusic);
            pnlWindow.Controls.Add(picBtnPlayMusic);
            pnlWindow.Controls.Add(picBtnAvancarMusic);
            pnlWindow.Controls.Add(picBtnNextMusic);
            pnlWindow.Controls.Add(picBtnRetroMusic);
            pnlWindow.Controls.Add(picBtnPrevMusic);
            pnlWindow.Controls.Add(picBtnAleatorioMusic);
            pnlWindow.Controls.Add(picBtnRepetirMusic);
            pnlWindow.Location = new Point(8, 42);
            pnlWindow.Margin = new Padding(0);
            pnlWindow.Name = "pnlWindow";
            pnlWindow.Size = new Size(700, 149);
            pnlWindow.TabIndex = 18;
            // 
            // picSoundMusic
            // 
            picSoundMusic.Image = Properties.Resources.Volume2;
            picSoundMusic.Location = new Point(117, 116);
            picSoundMusic.Name = "picSoundMusic";
            picSoundMusic.Size = new Size(30, 30);
            picSoundMusic.SizeMode = PictureBoxSizeMode.Zoom;
            picSoundMusic.TabIndex = 35;
            picSoundMusic.TabStop = false;
            // 
            // sldVolume
            // 
            sldVolume.CorBotao = Color.FromArgb(191, 195, 198);
            sldVolume.CorPreenchido1 = Color.FromArgb(77, 83, 158);
            sldVolume.CorPreenchido2 = Color.FromArgb(160, 160, 160);
            sldVolume.CorVazio = Color.FromArgb(86, 87, 101);
            sldVolume.Habilitado = true;
            sldVolume.Location = new Point(0, 129);
            sldVolume.Maximum = 100;
            sldVolume.Minimum = 0;
            sldVolume.Name = "sldVolume";
            sldVolume.Size = new Size(120, 5);
            sldVolume.TabIndex = 34;
            sldVolume.Text = "slider1";
            sldVolume.ThumbSize = 16;
            sldVolume.TrackHeight = 5;
            sldVolume.Value = 70;
            sldVolume.ValueMouse = 70;
            sldVolume.WithPoint = false;
            // 
            // lblDuracaoAtual
            // 
            lblDuracaoAtual.AutoSize = true;
            lblDuracaoAtual.Font = new Font("Verdana", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblDuracaoAtual.ForeColor = Color.Gray;
            lblDuracaoAtual.Location = new Point(126, 69);
            lblDuracaoAtual.Name = "lblDuracaoAtual";
            lblDuracaoAtual.Size = new Size(48, 16);
            lblDuracaoAtual.TabIndex = 33;
            lblDuracaoAtual.Text = "00:00";
            // 
            // lblDuracaoFinal
            // 
            lblDuracaoFinal.AutoSize = true;
            lblDuracaoFinal.Font = new Font("Verdana", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblDuracaoFinal.ForeColor = Color.Gray;
            lblDuracaoFinal.Location = new Point(637, 69);
            lblDuracaoFinal.Name = "lblDuracaoFinal";
            lblDuracaoFinal.Size = new Size(48, 16);
            lblDuracaoFinal.TabIndex = 32;
            lblDuracaoFinal.Text = "12:34";
            // 
            // lblNomePlaylist
            // 
            lblNomePlaylist.AutoSize = true;
            lblNomePlaylist.Font = new Font("Verdana", 11.25F, FontStyle.Italic, GraphicsUnit.Point, 0);
            lblNomePlaylist.ForeColor = Color.DarkGray;
            lblNomePlaylist.Location = new Point(551, 40);
            lblNomePlaylist.Name = "lblNomePlaylist";
            lblNomePlaylist.Size = new Size(133, 18);
            lblNomePlaylist.TabIndex = 31;
            lblNomePlaylist.Text = "Nome da playlsit";
            // 
            // lblPlaylist
            // 
            lblPlaylist.AutoSize = true;
            lblPlaylist.Font = new Font("Verdana", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblPlaylist.ForeColor = Color.Silver;
            lblPlaylist.Location = new Point(470, 36);
            lblPlaylist.Name = "lblPlaylist";
            lblPlaylist.Size = new Size(87, 23);
            lblPlaylist.TabIndex = 30;
            lblPlaylist.Text = "Playlist:";
            // 
            // lblNomeArtista
            // 
            lblNomeArtista.AutoSize = true;
            lblNomeArtista.Font = new Font("Verdana", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblNomeArtista.ForeColor = Color.Gray;
            lblNomeArtista.Location = new Point(126, 39);
            lblNomeArtista.Name = "lblNomeArtista";
            lblNomeArtista.Size = new Size(148, 18);
            lblNomeArtista.TabIndex = 29;
            lblNomeArtista.Text = "Nome do artista";
            // 
            // picImgMusica
            // 
            picImgMusica.Location = new Point(10, 10);
            picImgMusica.Margin = new Padding(10);
            picImgMusica.Name = "picImgMusica";
            picImgMusica.Size = new Size(100, 100);
            picImgMusica.SizeMode = PictureBoxSizeMode.Zoom;
            picImgMusica.TabIndex = 28;
            picImgMusica.TabStop = false;
            // 
            // lblNomeMusica
            // 
            lblNomeMusica.AutoSize = true;
            lblNomeMusica.Font = new Font("Verdana", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblNomeMusica.ForeColor = Color.Silver;
            lblNomeMusica.Location = new Point(123, 10);
            lblNomeMusica.Name = "lblNomeMusica";
            lblNomeMusica.Size = new Size(233, 29);
            lblNomeMusica.TabIndex = 27;
            lblNomeMusica.Text = "Nome da musica";
            // 
            // sldTimelineMusic
            // 
            sldTimelineMusic.CorBotao = Color.FromArgb(191, 195, 198);
            sldTimelineMusic.CorPreenchido1 = Color.FromArgb(77, 83, 158);
            sldTimelineMusic.CorPreenchido2 = Color.FromArgb(160, 160, 160);
            sldTimelineMusic.CorVazio = Color.FromArgb(86, 87, 101);
            sldTimelineMusic.Habilitado = true;
            sldTimelineMusic.Location = new Point(118, 61);
            sldTimelineMusic.Maximum = 100;
            sldTimelineMusic.Minimum = 0;
            sldTimelineMusic.Name = "sldTimelineMusic";
            sldTimelineMusic.Size = new Size(573, 5);
            sldTimelineMusic.TabIndex = 26;
            sldTimelineMusic.Text = "slider1";
            sldTimelineMusic.ThumbSize = 16;
            sldTimelineMusic.TrackHeight = 5;
            sldTimelineMusic.Value = 70;
            sldTimelineMusic.ValueMouse = 70;
            sldTimelineMusic.WithPoint = false;
            // 
            // picBtnPlayMusic
            // 
            picBtnPlayMusic.BackColor = Color.Transparent;
            picBtnPlayMusic.Image = Properties.Resources.Play;
            picBtnPlayMusic.Location = new Point(367, 71);
            picBtnPlayMusic.Name = "picBtnPlayMusic";
            picBtnPlayMusic.Size = new Size(75, 75);
            picBtnPlayMusic.SizeMode = PictureBoxSizeMode.Zoom;
            picBtnPlayMusic.TabIndex = 19;
            picBtnPlayMusic.TabStop = false;
            // 
            // picBtnAvancarMusic
            // 
            picBtnAvancarMusic.BackColor = Color.Transparent;
            picBtnAvancarMusic.Image = (Image)resources.GetObject("picBtnAvancarMusic.Image");
            picBtnAvancarMusic.Location = new Point(518, 84);
            picBtnAvancarMusic.Margin = new Padding(8);
            picBtnAvancarMusic.Name = "picBtnAvancarMusic";
            picBtnAvancarMusic.Size = new Size(50, 50);
            picBtnAvancarMusic.SizeMode = PictureBoxSizeMode.Zoom;
            picBtnAvancarMusic.TabIndex = 25;
            picBtnAvancarMusic.TabStop = false;
            // 
            // picBtnNextMusic
            // 
            picBtnNextMusic.BackColor = Color.Transparent;
            picBtnNextMusic.Image = (Image)resources.GetObject("picBtnNextMusic.Image");
            picBtnNextMusic.Location = new Point(457, 84);
            picBtnNextMusic.Name = "picBtnNextMusic";
            picBtnNextMusic.Size = new Size(50, 50);
            picBtnNextMusic.SizeMode = PictureBoxSizeMode.Zoom;
            picBtnNextMusic.TabIndex = 20;
            picBtnNextMusic.TabStop = false;
            // 
            // picBtnRetroMusic
            // 
            picBtnRetroMusic.BackColor = Color.Transparent;
            picBtnRetroMusic.Image = (Image)resources.GetObject("picBtnRetroMusic.Image");
            picBtnRetroMusic.Location = new Point(241, 84);
            picBtnRetroMusic.Margin = new Padding(8);
            picBtnRetroMusic.Name = "picBtnRetroMusic";
            picBtnRetroMusic.Size = new Size(50, 50);
            picBtnRetroMusic.SizeMode = PictureBoxSizeMode.Zoom;
            picBtnRetroMusic.TabIndex = 24;
            picBtnRetroMusic.TabStop = false;
            // 
            // picBtnPrevMusic
            // 
            picBtnPrevMusic.BackColor = Color.Transparent;
            picBtnPrevMusic.Image = (Image)resources.GetObject("picBtnPrevMusic.Image");
            picBtnPrevMusic.Location = new Point(302, 84);
            picBtnPrevMusic.Name = "picBtnPrevMusic";
            picBtnPrevMusic.Size = new Size(50, 50);
            picBtnPrevMusic.SizeMode = PictureBoxSizeMode.Zoom;
            picBtnPrevMusic.TabIndex = 21;
            picBtnPrevMusic.TabStop = false;
            // 
            // picBtnAleatorioMusic
            // 
            picBtnAleatorioMusic.BackColor = Color.Transparent;
            picBtnAleatorioMusic.Image = Properties.Resources.AleatorizarDesabilitado;
            picBtnAleatorioMusic.Location = new Point(175, 84);
            picBtnAleatorioMusic.Margin = new Padding(8);
            picBtnAleatorioMusic.Name = "picBtnAleatorioMusic";
            picBtnAleatorioMusic.Size = new Size(50, 50);
            picBtnAleatorioMusic.SizeMode = PictureBoxSizeMode.Zoom;
            picBtnAleatorioMusic.TabIndex = 23;
            picBtnAleatorioMusic.TabStop = false;
            // 
            // picBtnRepetirMusic
            // 
            picBtnRepetirMusic.BackColor = Color.Transparent;
            picBtnRepetirMusic.Image = Properties.Resources.RepetirDesabilitado;
            picBtnRepetirMusic.Location = new Point(584, 84);
            picBtnRepetirMusic.Margin = new Padding(8);
            picBtnRepetirMusic.Name = "picBtnRepetirMusic";
            picBtnRepetirMusic.Size = new Size(50, 50);
            picBtnRepetirMusic.SizeMode = PictureBoxSizeMode.Zoom;
            picBtnRepetirMusic.TabIndex = 22;
            picBtnRepetirMusic.TabStop = false;
            // 
            // Form4
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(21, 22, 23);
            ClientSize = new Size(716, 200);
            Controls.Add(pnlWindow);
            Controls.Add(titleBarPersonalizada1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Form4";
            Text = "Form4";
            pnlWindow.ResumeLayout(false);
            pnlWindow.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picSoundMusic).EndInit();
            ((System.ComponentModel.ISupportInitialize)picImgMusica).EndInit();
            ((System.ComponentModel.ISupportInitialize)picBtnPlayMusic).EndInit();
            ((System.ComponentModel.ISupportInitialize)picBtnAvancarMusic).EndInit();
            ((System.ComponentModel.ISupportInitialize)picBtnNextMusic).EndInit();
            ((System.ComponentModel.ISupportInitialize)picBtnRetroMusic).EndInit();
            ((System.ComponentModel.ISupportInitialize)picBtnPrevMusic).EndInit();
            ((System.ComponentModel.ISupportInitialize)picBtnAleatorioMusic).EndInit();
            ((System.ComponentModel.ISupportInitialize)picBtnRepetirMusic).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private NthControls.Slider sldTimelineMusic;
        private PictureBox picBtnAvancarMusic;
        private PictureBox picBtnRetroMusic;
        private PictureBox picBtnAleatorioMusic;
        private PictureBox picBtnRepetirMusic;
        private PictureBox picBtnPrevMusic;
        private PictureBox picBtnNextMusic;
        private PictureBox picBtnPlayMusic;
        private NthControls.TitleBarPersonalizada titleBarPersonalizada1;
        private Panel pnlWindow;
        private PictureBox picImgMusica;
        private Label lblNomeMusica;
        private Label lblPlaylist;
        private Label lblNomeArtista;
        private Label lblNomePlaylist;
        private Label lblDuracaoFinal;
        private Label lblDuracaoAtual;
        private NthControls.Slider sldVolume;
        private PictureBox picSoundMusic;
    }
}