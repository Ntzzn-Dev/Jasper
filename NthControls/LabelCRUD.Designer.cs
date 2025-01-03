namespace Jasper.NthControls
{
    partial class LabelCRUD
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
            picImgPrincipal = new PictureBox();
            label1 = new Label();
            picDeletar = new PictureBox();
            picEditar = new PictureBox();
            picExpandir = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)picImgPrincipal).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picDeletar).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picEditar).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picExpandir).BeginInit();
            SuspendLayout();
            // 
            // picImgPrincipal
            // 
            picImgPrincipal.BackColor = Color.Black;
            picImgPrincipal.Location = new Point(3, 3);
            picImgPrincipal.Name = "picImgPrincipal";
            picImgPrincipal.Size = new Size(50, 50);
            picImgPrincipal.SizeMode = PictureBoxSizeMode.Zoom;
            picImgPrincipal.TabIndex = 0;
            picImgPrincipal.TabStop = false;
            picImgPrincipal.Click += ImgPrincipal_Click;
            // 
            // label1
            // 
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Verdana", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(75, 3);
            label1.Name = "label1";
            label1.Size = new Size(605, 50);
            label1.TabIndex = 1;
            label1.Text = "Texto";
            label1.TextAlign = ContentAlignment.MiddleLeft;
            label1.Click += Label_Click;
            // 
            // picDeletar
            // 
            picDeletar.BackColor = Color.IndianRed;
            picDeletar.Location = new Point(742, 3);
            picDeletar.Name = "picDeletar";
            picDeletar.Size = new Size(50, 50);
            picDeletar.SizeMode = PictureBoxSizeMode.Zoom;
            picDeletar.TabIndex = 2;
            picDeletar.TabStop = false;
            picDeletar.Click += ImgDeletar_Click;
            // 
            // picEditar
            // 
            picEditar.BackColor = Color.LightBlue;
            picEditar.Location = new Point(686, 3);
            picEditar.Name = "picEditar";
            picEditar.Size = new Size(50, 50);
            picEditar.SizeMode = PictureBoxSizeMode.Zoom;
            picEditar.TabIndex = 3;
            picEditar.TabStop = false;
            picEditar.Click += ImgEditar_Click;
            // 
            // picExpandir
            // 
            picExpandir.BackColor = Color.Gainsboro;
            picExpandir.Location = new Point(798, 3);
            picExpandir.Name = "picExpandir";
            picExpandir.Size = new Size(50, 50);
            picExpandir.SizeMode = PictureBoxSizeMode.Zoom;
            picExpandir.TabIndex = 4;
            picExpandir.TabStop = false;
            picExpandir.Click += ImgExpandir_Click;
            // 
            // LabelCRUD
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.DarkGray;
            Controls.Add(picExpandir);
            Controls.Add(picEditar);
            Controls.Add(picDeletar);
            Controls.Add(label1);
            Controls.Add(picImgPrincipal);
            Name = "LabelCRUD";
            Size = new Size(852, 56);
            Paint += LabelCRUD_Paint;
            ((System.ComponentModel.ISupportInitialize)picImgPrincipal).EndInit();
            ((System.ComponentModel.ISupportInitialize)picDeletar).EndInit();
            ((System.ComponentModel.ISupportInitialize)picEditar).EndInit();
            ((System.ComponentModel.ISupportInitialize)picExpandir).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox picImgPrincipal;
        private Label label1;
        private PictureBox picDeletar;
        private PictureBox picEditar;
        private PictureBox picExpandir;
    }
}
