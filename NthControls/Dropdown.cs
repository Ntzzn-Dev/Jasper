namespace Jasper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

public partial class Dropdown : UserControl
{
    private bool isFocused = false;
    private string _textDropdown = "Text";
    private List<Elementos> _elementos;
    private int _idElemento;
    public string TextDropdown
    {
        get
        {
            return _textDropdown;
        }
        set
        {
            _textDropdown = value;
            this.Validate();
        }
    }
    public int IdElemento
    {
        get
        {
            return _idElemento;
        }
        set
        {
            _idElemento = value;
            label1.Text = TextDropdown;
            this.Validate();
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
    private void Dropdown_Paint(object sender, PaintEventArgs e)
    {
        label1.Text = TextDropdown;
    }

    private void DropdownClick(object sender, EventArgs e)
    {
        if (isFocused == false)
        {
            isFocused = true;
            flowPanel1.Controls.Clear();

            if (Elementos == null) return;

            int ateOndeDescer = 28;
            int pixelsAMenos = -6;
            if (Elementos.Count > 4)
            {
                pixelsAMenos = -23;
            }
            foreach (Elementos elementos in Elementos)
            {
                if (ateOndeDescer <= 140)
                {
                    ateOndeDescer += 23 + 6;
                }
                
                Label lblElemento = new Label()
                {
                    BackColor = Color.Gray,
                    Margin = new Padding(3),
                    Name = "lbl_" + elementos.NomeArtista + ">" + elementos.IdArtista,
                    Size = new Size(flowPanel1.Size.Width + pixelsAMenos, 23),
                    TabIndex = 0,
                    Text = elementos.NomeArtista,
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
            this.Size = new Size(this.Width, 28);
            flowPanel1.Controls.Clear();
        }
    }
    private void ElementoClicado(object sender, EventArgs e)
    {
        Label nome = sender as Label;
        TextDropdown = nome.Text;
        label1.Text = TextDropdown;

        IdElemento = int.Parse(nome.Name.Split('>')[1]);

        this.Size = new Size(this.Width, 28);
        flowPanel1.Controls.Clear();
        isFocused = false;
    }
    private void MouseEnterDropdown(object sender, EventArgs e)
    {
        label1.BackColor = Color.DarkGray;
        pictureBox1.BackColor = Color.DarkGray;
    }
    private void MouseLeaveDropdown(object sender, EventArgs e)
    {
        label1.BackColor = Color.LightGray;
        pictureBox1.BackColor = Color.LightGray;
    }
    private void MouseEnterElementDropdown(object sender, EventArgs e)
    {
        Label lblElemento = sender as Label;
        lblElemento.BackColor = Color.Silver;
        lblElemento.Size = new Size(lblElemento.Width+2, lblElemento.Height+2);
        lblElemento.Margin = new Padding(2);
    }
    private void MouseLeaveElementDropdown(object sender, EventArgs e)
    {
        Label lblElemento = sender as Label;
        lblElemento.BackColor = Color.Gray;
        lblElemento.Size = new Size(lblElemento.Width - 2, lblElemento.Height - 2);
        lblElemento.Margin = new Padding(3);
    }
    protected override void OnResize(EventArgs e)
    {
        base.OnResize(e);

        int widthlabel1 = this.Size.Width - 40;
        pictureBox1.Location = new Point(widthlabel1, 0);
        label1.Size = new Size(widthlabel1, 28);
        flowPanel1.Size = new Size(this.Size.Width, flowPanel1.Size.Height);

        this.Invalidate();
    }
}
[TypeConverter(typeof(ExpandableObjectConverter))]
public class Elementos
{
    public string NomeArtista { get; set; } = string.Empty;
    public int IdArtista { get; set; } = 0;
    public Elementos()
    {

    }
    public override string ToString()
    {
        return NomeArtista;
    }
}