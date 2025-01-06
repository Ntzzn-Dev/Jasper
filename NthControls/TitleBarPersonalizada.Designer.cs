namespace Jasper.NthControls
{
    partial class TitleBarPersonalizada
    {
        /// <summary> 
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Designer de Componentes

        /// <summary> 
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TitleBarPersonalizada));
            lblNomeTela = new Label();
            titleBar = new Panel();
            picBtnMinimizar = new PictureBox();
            picBtnMaximizar = new PictureBox();
            picBtnFechar = new PictureBox();
            titleBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picBtnMinimizar).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picBtnMaximizar).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picBtnFechar).BeginInit();
            SuspendLayout();
            // 
            // lblNomeTela
            // 
            lblNomeTela.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblNomeTela.AutoSize = true;
            lblNomeTela.Font = new Font("Verdana", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblNomeTela.ForeColor = Color.Silver;
            lblNomeTela.Location = new Point(516, 0);
            lblNomeTela.Name = "lblNomeTela";
            lblNomeTela.Size = new Size(282, 32);
            lblNomeTela.TabIndex = 0;
            lblNomeTela.Text = "JASPER CONTROL";
            lblNomeTela.MouseDown += TitleSegurar;
            // 
            // titleBar
            // 
            titleBar.BackColor = Color.FromArgb(21, 22, 23);
            titleBar.Controls.Add(picBtnMinimizar);
            titleBar.Controls.Add(picBtnMaximizar);
            titleBar.Controls.Add(picBtnFechar);
            titleBar.Controls.Add(lblNomeTela);
            titleBar.Dock = DockStyle.Top;
            titleBar.Location = new Point(0, 0);
            titleBar.Margin = new Padding(0);
            titleBar.Name = "titleBar";
            titleBar.Size = new Size(1228, 34);
            titleBar.TabIndex = 1;
            titleBar.MouseDown += TitleSegurar;
            // 
            // picBtnMinimizar
            // 
            picBtnMinimizar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            picBtnMinimizar.BackColor = Color.Transparent;
            picBtnMinimizar.Image = (Image)resources.GetObject("picBtnMinimizar.Image");
            picBtnMinimizar.Location = new Point(1074, 1);
            picBtnMinimizar.Margin = new Padding(1);
            picBtnMinimizar.Name = "picBtnMinimizar";
            picBtnMinimizar.Size = new Size(50, 32);
            picBtnMinimizar.SizeMode = PictureBoxSizeMode.Zoom;
            picBtnMinimizar.TabIndex = 19;
            picBtnMinimizar.TabStop = false;
            picBtnMinimizar.Click += PicBtnMinimizar;
            // 
            // picBtnMaximizar
            // 
            picBtnMaximizar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            picBtnMaximizar.BackColor = Color.Transparent;
            picBtnMaximizar.Image = (Image)resources.GetObject("picBtnMaximizar.Image");
            picBtnMaximizar.Location = new Point(1126, 1);
            picBtnMaximizar.Margin = new Padding(1);
            picBtnMaximizar.Name = "picBtnMaximizar";
            picBtnMaximizar.Size = new Size(50, 32);
            picBtnMaximizar.SizeMode = PictureBoxSizeMode.Zoom;
            picBtnMaximizar.TabIndex = 18;
            picBtnMaximizar.TabStop = false;
            picBtnMaximizar.Click += PicBtnMaximizar;
            // 
            // picBtnFechar
            // 
            picBtnFechar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            picBtnFechar.BackColor = Color.Transparent;
            picBtnFechar.Image = (Image)resources.GetObject("picBtnFechar.Image");
            picBtnFechar.Location = new Point(1177, 1);
            picBtnFechar.Margin = new Padding(1);
            picBtnFechar.Name = "picBtnFechar";
            picBtnFechar.Size = new Size(50, 32);
            picBtnFechar.SizeMode = PictureBoxSizeMode.Zoom;
            picBtnFechar.TabIndex = 17;
            picBtnFechar.TabStop = false;
            picBtnFechar.Click += PicBtnFechar;
            // 
            // TitleBarPersonalizada
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Transparent;
            Controls.Add(titleBar);
            Name = "TitleBarPersonalizada";
            Size = new Size(1228, 34);
            Load += TitleBarPersonalizada_Load;
            SizeChanged += TitleBarPersonalizada_Load;
            Paint += TitleBarPersonalizada_Paint;
            Resize += TitleBarPersonalizada_Load;
            titleBar.ResumeLayout(false);
            titleBar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picBtnMinimizar).EndInit();
            ((System.ComponentModel.ISupportInitialize)picBtnMaximizar).EndInit();
            ((System.ComponentModel.ISupportInitialize)picBtnFechar).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Label lblNomeTela;
        private Panel titleBar;
        private PictureBox picBtnMaximizar;
        private PictureBox picBtnFechar;
        private PictureBox picBtnMinimizar;
    }
}
