using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Jasper.NthControls
{
    public partial class LabelCRUD : UserControl
    {
        private bool _withImg = true;
        private bool _withEdit = true;
        private bool _withDelete = true;
        private bool _withExpand = true;
        private string _texto = "Texto";
        private int _id = 0;
        private Image _imgPrc;
        private Image _imgEdt;
        private Image _imgDlt;
        private Image _imgExp;
        public event EventHandler TextoChanged;
        public event EventHandler LabelClick;
        public event EventHandler ImgPrincipalClick;
        public event EventHandler ImgEditarClick;
        public event EventHandler ImgDeletarClick;
        public event EventHandler ImgExpandirClick;
        public bool WithImg
        {
            get => _withImg;
            set
            {
                _withImg = value;
                ToogleImg();
                picImgPrincipal.Enabled = value;
                picImgPrincipal.Visible = value;
                Invalidate();
            }
        }
        public bool WithEdit
        {
            get => _withEdit;
            set
            {
                _withEdit = value;
                ToogleImg();
                picEditar.Enabled = value;
                picEditar.Visible = value;
                Invalidate();
            }
        }
        public bool WithDelete
        {
            get => _withDelete;
            set
            {
                _withDelete = value;
                ToogleImg();
                picDeletar.Enabled = value;
                picDeletar.Visible = value;
                Invalidate();
            }
        }
        public bool WithExpand
        {
            get => _withExpand;
            set
            {
                _withExpand = value;
                ToogleImg();
                picExpandir.Enabled = value;
                picExpandir.Visible = value;
                Invalidate();
            }
        }
        public string Texto
        {
            get => _texto;
            set
            {
                _texto = value;
                OnTextChanged(EventArgs.Empty);
                label1.Text = _texto;
                Invalidate();
            }
        }
        public int Id
        {
            get => _id;
            set
            {
                _id = value;
                Invalidate();
            }
        }
        public Image ImgPrincipal
        {
            get => _imgPrc;
            set
            {
                _imgPrc = value;
                picImgPrincipal.Image = _imgPrc;
                PicDefinirCorDeFundo(_imgPrc, picImgPrincipal);
                Invalidate();
            }
        }
        public Image ImgEditar
        {
            get => _imgEdt;
            set
            {
                _imgEdt = value;
                picEditar.Image = _imgEdt;
                Invalidate();
            }
        }
        public Image ImgDeletar
        {
            get => _imgDlt;
            set
            {
                _imgDlt = value;
                picDeletar.Image = _imgDlt;
                Invalidate();
            }
        }
        public Image ImgExpandir
        {
            get => _imgExp;
            set
            {
                _imgExp = value;
                picExpandir.Image = _imgExp;
                Invalidate();
            }
        }

        public LabelCRUD()
        {
            InitializeComponent();
            PicArredondarBordas(picImgPrincipal, 10, 10, 10, 10);
        }
        private void LabelCRUD_Paint(object sender, PaintEventArgs e)
        {
            label1.Text = Texto;
        }
        private void ToogleImg()
        {
            List<Point> posicoes =
            [
                new Point(this.Size.Width - 54, 3),
                new Point(this.Size.Width - 110, 3),
                new Point(this.Size.Width - 166, 3),
            ];

            if(WithExpand) {picExpandir.Location = posicoes[0]; posicoes.RemoveAt(0);}
            if(WithDelete) {picDeletar.Location = posicoes[0]; posicoes.RemoveAt(0);}
            if(WithEdit) {picEditar.Location = posicoes[0]; posicoes.RemoveAt(0);}

            if(WithImg){label1.Location = new Point(75, 3);}
            else {label1.Location = new Point(3, 3);}
        }
        private void PicDefinirCorDeFundo(Image imgData, PictureBox pic)
        {
            if (imgData == null)
                return;

            Bitmap bitmap = new Bitmap(imgData);
            Color corBordaSuperior = bitmap.GetPixel(bitmap.Width / 2, 0);
            Color corBordaInferior = bitmap.GetPixel(bitmap.Width / 2, bitmap.Height - 1);
            Color corBordaEsquerda = bitmap.GetPixel(0, bitmap.Height / 2);
            Color corBordaDireita = bitmap.GetPixel(bitmap.Width - 1, bitmap.Height / 2);

            int a = (corBordaSuperior.A + corBordaInferior.A + corBordaEsquerda.A + corBordaDireita.A) / 4;
            int r = (corBordaSuperior.R + corBordaInferior.R + corBordaEsquerda.R + corBordaDireita.R) / 4;
            int g = (corBordaSuperior.G + corBordaInferior.G + corBordaEsquerda.G + corBordaDireita.G) / 4;
            int b = (corBordaSuperior.B + corBordaInferior.B + corBordaEsquerda.B + corBordaDireita.B) / 4;

            pic.BackColor = Color.FromArgb(a, r, g, b);
        }
        public void PicArredondarBordas(PictureBox pictureBox, int topLeftRadius, int topRightRadius, int bottomRightRadius, int bottomLeftRadius)
        {
            using (GraphicsPath gp = new GraphicsPath())
            {
                // Canto superior esquerdo
                if (topLeftRadius > 0)
                    gp.AddArc(0, 0, topLeftRadius * 2, topLeftRadius * 2, 180, 90);
                else
                    gp.AddLine(0, 0, 0, 0); // Pontudo

                // Canto superior direito
                if (topRightRadius > 0)
                    gp.AddArc(pictureBox.Width - topRightRadius * 2, 0, topRightRadius * 2, topRightRadius * 2, 270, 90);
                else
                    gp.AddLine(pictureBox.Width, 0, pictureBox.Width, 0); // Pontudo

                // Canto inferior direito
                if (bottomRightRadius > 0)
                    gp.AddArc(pictureBox.Width - bottomRightRadius * 2, pictureBox.Height - bottomRightRadius * 2, bottomRightRadius * 2, bottomRightRadius * 2, 0, 90);
                else
                    gp.AddLine(pictureBox.Width, pictureBox.Height, pictureBox.Width, pictureBox.Height); // Pontudo

                // Canto inferior esquerdo
                if (bottomLeftRadius > 0)
                    gp.AddArc(0, pictureBox.Height - bottomLeftRadius * 2, bottomLeftRadius * 2, bottomLeftRadius * 2, 90, 90);
                else
                    gp.AddLine(0, pictureBox.Height, 0, pictureBox.Height); // Pontudo

                gp.CloseFigure();

                pictureBox.Region = new Region(gp);
            }
        }
        protected virtual void Label_Click(object sender, EventArgs e)
        {
            LabelClick?.Invoke(this, e);
        }
        protected virtual void ImgPrincipal_Click(object sender, EventArgs e)
        {
            ImgPrincipalClick?.Invoke(this, e);
        }
        protected virtual void ImgEditar_Click(object sender, EventArgs e)
        {
            ImgEditarClick?.Invoke(this, e);
        }
        protected virtual void ImgDeletar_Click(object sender, EventArgs e)
        {
            ImgDeletarClick?.Invoke(this, e);
        }
        protected virtual void ImgExpandir_Click(object sender, EventArgs e)
        {
            ImgExpandirClick?.Invoke(this, e);
        }
        protected virtual void OnTextChanged(EventArgs e)
        {
            TextoChanged?.Invoke(this, e);
        }
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);

            int primeiraPosition = this.Size.Width - 54;
            picExpandir.Location = new Point(primeiraPosition, 3);
            picDeletar.Location = new Point(picExpandir.Location.X - 56, 3);
            picEditar.Location = new Point(picDeletar.Location.X - 56, 3);
            label1.Size = new Size(picEditar.Location.X - 6 - (label1.Location.X), 50);
            
            this.Invalidate();
        }
    }
}
