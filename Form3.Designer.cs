namespace Jasper
{
    partial class Form3
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
            txtbxURLWeb = new TextBox();
            lblTelaColaWeb = new Label();
            btnCancelarWeb = new Button();
            picImagemDaWeb = new PictureBox();
            btnRetornoWeb = new Button();
            ((System.ComponentModel.ISupportInitialize)picImagemDaWeb).BeginInit();
            SuspendLayout();
            // 
            // txtbxURLWeb
            // 
            txtbxURLWeb.Location = new Point(213, 47);
            txtbxURLWeb.Name = "txtbxURLWeb";
            txtbxURLWeb.PlaceholderText = "Cole aqui para ";
            txtbxURLWeb.Size = new Size(337, 23);
            txtbxURLWeb.TabIndex = 0;
            // 
            // lblTelaColaWeb
            // 
            lblTelaColaWeb.AutoSize = true;
            lblTelaColaWeb.Font = new Font("Segoe UI Black", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTelaColaWeb.Location = new Point(210, 12);
            lblTelaColaWeb.Name = "lblTelaColaWeb";
            lblTelaColaWeb.Size = new Size(179, 32);
            lblTelaColaWeb.TabIndex = 1;
            lblTelaColaWeb.Text = "Nome da ação";
            // 
            // btnCancelarWeb
            // 
            btnCancelarWeb.Location = new Point(431, 92);
            btnCancelarWeb.Name = "btnCancelarWeb";
            btnCancelarWeb.Size = new Size(119, 30);
            btnCancelarWeb.TabIndex = 2;
            btnCancelarWeb.Text = "Cancelar";
            btnCancelarWeb.UseVisualStyleBackColor = true;
            // 
            // picImagemDaWeb
            // 
            picImagemDaWeb.Location = new Point(12, 12);
            picImagemDaWeb.Name = "picImagemDaWeb";
            picImagemDaWeb.Size = new Size(195, 110);
            picImagemDaWeb.SizeMode = PictureBoxSizeMode.Zoom;
            picImagemDaWeb.TabIndex = 3;
            picImagemDaWeb.TabStop = false;
            // 
            // btnRetornoWeb
            // 
            btnRetornoWeb.Location = new Point(306, 92);
            btnRetornoWeb.Name = "btnRetornoWeb";
            btnRetornoWeb.Size = new Size(119, 30);
            btnRetornoWeb.TabIndex = 4;
            btnRetornoWeb.Text = "Pronto";
            btnRetornoWeb.UseVisualStyleBackColor = true;
            // 
            // Form4
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btnRetornoWeb;
            ClientSize = new Size(562, 137);
            Controls.Add(btnRetornoWeb);
            Controls.Add(picImagemDaWeb);
            Controls.Add(btnCancelarWeb);
            Controls.Add(lblTelaColaWeb);
            Controls.Add(txtbxURLWeb);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "Form4";
            ShowIcon = false;
            Text = "Tela de cola web";
            TopMost = true;
            ((System.ComponentModel.ISupportInitialize)picImagemDaWeb).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtbxURLWeb;
        private Label lblTelaColaWeb;
        private Button btnCancelarWeb;
        private PictureBox picImagemDaWeb;
        private Button btnRetornoWeb;
    }
}