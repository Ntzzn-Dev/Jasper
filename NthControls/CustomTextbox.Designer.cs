namespace Jasper.NthControls
{
    partial class CustomTextbox
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
            components = new System.ComponentModel.Container();
            textBox1 = new TextBox();
            label1 = new Label();
            lblTimer = new System.Windows.Forms.Timer(components);
            SuspendLayout();
            // 
            // textBox1
            // 
            textBox1.BorderStyle = BorderStyle.None;
            textBox1.Location = new Point(3, 11);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(414, 16);
            textBox1.TabIndex = 1;
            textBox1.TextChanged += textBox1_TextChanged;
            textBox1.Enter += textBox1_EnterOrLeave;
            textBox1.Leave += textBox1_EnterOrLeave;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(6, 10);
            label1.Name = "label1";
            label1.Size = new Size(31, 17);
            label1.TabIndex = 2;
            label1.Text = "Text";
            label1.Click += label1_Click;
            // 
            // lblTimer
            // 
            lblTimer.Interval = 1;
            lblTimer.Tick += lblTimer_Tick;
            // 
            // CustomTextbox
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(label1);
            Controls.Add(textBox1);
            Name = "CustomTextbox";
            Size = new Size(420, 32);
            Load += AoCarregar;
            Paint += CustomTextBox_Paint;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TextBox textBox1;
        private Label label1;
        private System.Windows.Forms.Timer lblTimer;
    }
}
