namespace Jasper
{
    partial class Dropdown
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Dropdown));
            label1 = new Label();
            flowPanel1 = new FlowLayoutPanel();
            pictureBox1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.BackColor = Color.LightGray;
            label1.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(0, 0);
            label1.Margin = new Padding(0);
            label1.Name = "label1";
            label1.Size = new Size(398, 28);
            label1.TabIndex = 0;
            label1.Text = "Nome do Autor";
            label1.TextAlign = ContentAlignment.MiddleLeft;
            label1.Click += DropdownClick;
            label1.MouseEnter += MouseEnterDropdown;
            label1.MouseLeave += MouseLeaveDropdown;
            // 
            // flowPanel1
            // 
            flowPanel1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            flowPanel1.AutoScroll = true;
            flowPanel1.AutoSize = true;
            flowPanel1.BackColor = Color.Transparent;
            flowPanel1.FlowDirection = FlowDirection.TopDown;
            flowPanel1.Location = new Point(0, 28);
            flowPanel1.Margin = new Padding(0);
            flowPanel1.MaximumSize = new Size(438, 116);
            flowPanel1.Name = "flowPanel1";
            flowPanel1.Size = new Size(438, 29);
            flowPanel1.TabIndex = 2;
            flowPanel1.WrapContents = false;
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.LightGray;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(398, 0);
            pictureBox1.Margin = new Padding(0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(40, 28);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            pictureBox1.Click += DropdownClick;
            pictureBox1.MouseEnter += MouseEnterDropdown;
            pictureBox1.MouseLeave += MouseLeaveDropdown;
            // 
            // Dropdown
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(pictureBox1);
            Controls.Add(flowPanel1);
            Controls.Add(label1);
            MinimumSize = new Size(148, 28);
            Name = "Dropdown";
            Size = new Size(438, 28);
            Paint += Dropdown_Paint;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private FlowLayoutPanel flowPanel1;
        private PictureBox pictureBox1;
    }
}
