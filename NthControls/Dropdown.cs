namespace Jasper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

public partial class Dropdown : UserControl
{
    private Label lblElemento2;
    private bool isFocused = false;
    private string _textDropdown = "Text";
    private int _idElemento;
    private int _qntDeElementosVisiveis = 4;
    private Size _tamanhoDropdown = new Size(438, 28);
    private Font _fontTexto = new Font("Segoe UI Semibold", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 0);
    private Color _colorDropdown = Color.LightGray;
    private Color _colorTextDropdown = Color.Black;
    private Color _colorElementoDropdown = Color.Silver;
    private Color _colorElementoTextDropdown = Color.Black;
    private Color _colorPanelDropdown = Color.Gray;
    private Image _imgDropdown;
    private List<Elementos> _elementos;
    public event EventHandler Escolheu;
    public string TextDropdown
    {
        get => _textDropdown;
        set
        {
            _textDropdown = value;
            label1.Text = TextDropdown;
            Invalidate();
        }
    }
    public int IdElemento
    {
        get => _idElemento;
        set
        {
            _idElemento = value;
            Invalidate();
        }
    }
    public int QntDeElementosVisiveis
    {
        get => _qntDeElementosVisiveis;
        set
        {
            _qntDeElementosVisiveis = value;
            Invalidate();
        }
    }
    public Size TamanhoDropdown
    {
        get => _tamanhoDropdown;
        set
        {
            _tamanhoDropdown = value;
            MudarTamanhoDropdown();
            Invalidate();
        }
    }
    public Font FontTexto
    {
        get => _fontTexto;
        set
        {
            _fontTexto = value;
            label1.Font = _fontTexto;
            Invalidate();
        }
    }
    public Color ColorDropdown
    {
        get => _colorDropdown;
        set
        {
            _colorDropdown = value;
            MudarCorDropdown();
            Invalidate();
        }
    }
    public Color ColorTextDropdown
    {
        get => _colorTextDropdown;
        set
        {
            _colorTextDropdown = value;
            MudarCorTextoDropdown();
            Invalidate();
        }
    }
    public Color ColorElementoDropdown
    {
        get => _colorElementoDropdown;
        set
        {
            _colorElementoDropdown = value;
            Invalidate();
        }
    }
    public Color ColorElementoTextDropdown
    {
        get => _colorElementoTextDropdown;
        set
        {
            _colorElementoTextDropdown = value;
            Invalidate();
        }
    }
    public Color ColorPanelDropdown
    {
        get => _colorPanelDropdown;
        set
        {
            _colorPanelDropdown = value;
            flowPanel1.BackColor = _colorPanelDropdown;
            Invalidate();
        }
    }
    public Image ImgDropdown
    {
        get => _imgDropdown;
        set
        {
            _imgDropdown = value;
            ColocarImagem();
            Invalidate();
        }
    }
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
    public List<Elementos> Elementos
    {
        get
        {
            if (_elementos == null) _elementos = new List<Elementos>();
            return _elementos;
        }
        set
        {
            _elementos = value;
            this.Invalidate();
        }
    }

    public Dropdown()
    {
        InitializeComponent();
        this.MinimumSize = new Size(148, 28);
    }
    private void Dropdown_Load(object sender, EventArgs e)
    {
        label1.Text = TextDropdown;
        MudarTamanhoDropdown();
        MudarCorDropdown();
        flowPanel1.BackColor = _colorPanelDropdown;
    }
    private void ColocarImagem()
    {
        if (ImgDropdown != null)
        {
            pictureBox2.Image = ImgDropdown;
            pictureBox2.Visible = true;
            pictureBox2.Enabled = true;
            label1.Location = new Point(28, label1.Location.Y);
            label1.Size = new Size(this.Size.Width - 40 - 28, TamanhoDropdown.Height);
        }
        else
        {
            pictureBox2.Image = null;
            pictureBox2.Visible = false;
            pictureBox2.Enabled = false;
            label1.Location = new Point(0, 0);
            label1.Size = new Size(this.Size.Width - 40, TamanhoDropdown.Height);
        }
    }
    private void MudarTamanhoDropdown()
    {
        this.Size = TamanhoDropdown;
        label1.Size = new Size(label1.Width, TamanhoDropdown.Height);
        flowPanel1.Location = new Point(flowPanel1.Location.X, TamanhoDropdown.Height);
        pictureBox1.Size = new Size(pictureBox1.Width, TamanhoDropdown.Height);
        pictureBox2.Location = new Point(0, TamanhoDropdown.Height/2 - pictureBox2.Size.Height/2);
    }
    private void MudarCorDropdown()
    {
        this.BackColor = ColorDropdown;
        label1.BackColor = ColorDropdown;
        pictureBox1.BackColor = ColorDropdown;
    }
    private void MudarCorTextoDropdown()
    {
        label1.ForeColor = ColorTextDropdown;
    }
    private void DropdownClick(object sender, EventArgs e)
    {
        if (isFocused == false)
        {
            this.BringToFront();
            int TamanhoMax = QntDeElementosVisiveis * 28;
            isFocused = true;
            flowPanel1.Controls.Clear();

            if (Elementos == null) return;

            int ateOndeDescer = TamanhoDropdown.Height;
            int pixelsAMenos = -6;
            if (Elementos.Count > QntDeElementosVisiveis)
            {
                pixelsAMenos = -23;
            }
            flowPanel1.MaximumSize = new Size(this.Width, TamanhoMax);
            foreach (Elementos elementos in Elementos)
            {
                if (ateOndeDescer < TamanhoMax + TamanhoDropdown.Height)
                {
                    ateOndeDescer += 28;
                }
                
                Label lblElemento = new Label()
                {
                    BackColor = ColorElementoDropdown,
                    ForeColor = ColorElementoTextDropdown,
                    Margin = new Padding(2),
                    Name = "lbl_" + elementos.Nome + ">" + elementos.Id,
                    Size = new Size(flowPanel1.Size.Width + pixelsAMenos, 23),
                    Font = new Font("Segoe UI Semibold", 12f),
                    TabIndex = 0,
                    Text = elementos.Nome,
                    TextAlign = ContentAlignment.MiddleLeft
                };
                lblElemento.Click += ElementoClicado;
                lblElemento.MouseEnter += MouseEnterElementDropdown;
                lblElemento.MouseLeave += MouseLeaveElementDropdown;
                flowPanel1.Controls.Add(lblElemento);
            }

            this.Size = new Size(this.Width, ateOndeDescer);
            flowPanel1.Size = new Size(this.Width, ateOndeDescer);
        } 
        else
        {
            isFocused = false;
            this.Size = new Size(this.Width, TamanhoDropdown.Height);
            flowPanel1.Controls.Clear();
        }
    }
    private void ElementoClicado(object sender, EventArgs e)
    {
        Label nome = sender as Label;
        TextDropdown = nome.Text;
        label1.Text = TextDropdown;

        IdElemento = int.Parse(nome.Name.Split('>')[1]);

        this.Size = new Size(this.Width, TamanhoDropdown.Height);
        flowPanel1.Controls.Clear();
        isFocused = false;

        Escolheu?.Invoke(this, e);
    }
    private void MouseEnterDropdown(object sender, EventArgs e)
    {
        Color darkerColor = PicDarkenColor(ColorDropdown, 0.5f);
        label1.BackColor = darkerColor;
        pictureBox1.BackColor = darkerColor;
        this.BackColor = darkerColor;
    }
    private void MouseLeaveDropdown(object sender, EventArgs e)
    {
        label1.BackColor = ColorDropdown;
        pictureBox1.BackColor = ColorDropdown;
        this.BackColor = ColorDropdown;
    }
    private void MouseEnterElementDropdown(object sender, EventArgs e)
    {
        if (lblElemento2 == null) { 
            Label lblElemento = sender as Label;
            Color darkerColor = PicDarkenColor(ColorElementoDropdown, 0.5f);
            lblElemento.BackColor = darkerColor;
            lblElemento.Margin = new Padding(1);
            lblElemento.Size = new Size(lblElemento.Width + 2, lblElemento.Height + 2);
        }
    }
    private void MouseLeaveElementDropdown(object sender, EventArgs e)
    {
        Label lblElemento = sender as Label;
        lblElemento.BackColor = ColorElementoDropdown;
        lblElemento.Margin = new Padding(2);
        lblElemento.Size = new Size(lblElemento.Width - 2, lblElemento.Height - 2);
    }
    private static Color PicDarkenColor(Color color, float factor)
    {
        factor = Math.Clamp(factor, 0, 1);

        int r = (int)(color.R * factor);
        int g = (int)(color.G * factor);
        int b = (int)(color.B * factor);

        return Color.FromArgb(color.A, r, g, b);
    }
    protected override void OnResize(EventArgs e)
    {
        base.OnResize(e);

        int widthlabel1 = this.Size.Width - 40;
        pictureBox1.Location = new Point(widthlabel1, 0);
        label1.Size = new Size(widthlabel1, TamanhoDropdown.Height);
        flowPanel1.Size = new Size(this.Size.Width, flowPanel1.Size.Height);

        this.Invalidate();
    }
}
[TypeConverter(typeof(ExpandableObjectConverter))]
public class Elementos
{
    public string Nome { get; set; } = string.Empty;
    public int Id { get; set; } = 0;
    public Elementos()
    {

    }
    public override string ToString()
    {
        return Nome;
    }
}