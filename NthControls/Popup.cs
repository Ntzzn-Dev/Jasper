namespace Jasper.NthControls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;

public partial class Popup : UserControl
{
    private Size _sizePopup;
    private Color _colorPopup;
    private Color _colorElementoPopup;
    private Color _colorTextPopup;
    private List<Boxes> _elementosPopup;
    public event EventHandler BoxClicadoEvent;
    public bool sla;
    public Size SizePopup
    {
        get => _sizePopup;
        set
        {
            _sizePopup = value;
            Invalidate();
        }
    }
    public Color ColorPopup
    {
        get => _colorPopup;
        set
        {
            _colorPopup = value;
            Invalidate();
        }
    }
    public Color ColorElementoPopup
    {
        get => _colorElementoPopup;
        set
        {
            _colorElementoPopup = value;
            Invalidate();
        }
    }
    public Color ColorTextPopup
    {
        get => _colorTextPopup;
        set
        {
            _colorTextPopup = value;
            Invalidate();
        }
    }
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
    public List<Boxes> ElementosPopup
    {
        get
        {
            if (_elementosPopup == null) _elementosPopup = new List<Boxes>();
            return _elementosPopup;
        }
        set
        {
            _elementosPopup = value;
            this.Invalidate();
        }
    }
    public Popup()
    {
        InitializeComponent();
    }
    private void PopupLoad(object sender, EventArgs e) 
    {
        this.BackColor = ColorPopup;
        flowLayoutPanel1.Controls.Clear();
        SizePopup = new Size(278, 0);
        foreach (Boxes box in ElementosPopup) {
            SizePopup = new Size(SizePopup.Width, SizePopup.Height + 56);
            Panel pnl = new Panel()
            {
                Location = new Point(0, 3),
                Margin = new Padding(3, 3, 3, 3),
                Name = "pnl>" + box.IdBox + ">" + box.IdRepassar,
                Size = new Size(272, 50),
                BackColor = ColorElementoPopup
            };
            PictureBox pic = new PictureBox()
            {
                Location = new Point(0, 0),
                Margin = new Padding(0),
                Name = "pic>"+ box.IdBox + ">" + box.IdRepassar,
                Size = new Size(50, 50),
                Image = box.Imagem,
                SizeMode = PictureBoxSizeMode.Zoom,
                BackColor = Color.Transparent
            };
            Label lbl = new Label()
            {
                Font = new Font("Verdana", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0),
                Location = new Point(50, 0),
                Margin = new Padding(0),
                Name = "lbl>"+ box.IdBox + ">" + box.IdRepassar,
                Size = new Size(222, 50),
                TabIndex = 0,
                Text = box.Nome,
                TextAlign = ContentAlignment.MiddleCenter,
                ForeColor = ColorTextPopup,
                BackColor = Color.Transparent
            };
            lbl.Click += BoxClicado;
            pic.Click += BoxClicado;
            lbl.MouseEnter += BoxEnter;
            pic.MouseEnter += BoxEnter;
            lbl.MouseLeave += BoxLeave;
            pic.MouseLeave += BoxLeave;
            pnl.Controls.Add(lbl);
            pnl.Controls.Add(pic);
            flowLayoutPanel1.Controls.Add(pnl);
        }
        this.Size = SizePopup;
    }
    private void BoxClicado(object sender, EventArgs e)
    {
        BoxClicadoEvent?.Invoke(sender, e);
    }
    private void BoxEnter(object sender, EventArgs e)
    {
        if (sender is Label label)
        {
            var panel = label.Parent as Panel;

            if (panel != null)
            {
                panel.BackColor = PicDarkenColor(ColorElementoPopup);
            }
        }
        else if(sender is PictureBox pic)
        {
            var panel = pic.Parent as Panel;

            if (panel != null)
            {
                panel.BackColor = PicDarkenColor(ColorElementoPopup);
            }
        }
    }
    private void BoxLeave(object sender, EventArgs e)
    {
        if (sender is Label label)
        {
            var panel = label.Parent as Panel;

            if (panel != null)
            {
                panel.BackColor = ColorElementoPopup;
            }
        }
        else if (sender is PictureBox pic)
        {
            var panel = pic.Parent as Panel;

            if (panel != null)
            {
                panel.BackColor = ColorElementoPopup;
            }
        }
    }
    private static Color PicDarkenColor(Color color, float factor = 0.8f)
    {
        factor = Math.Clamp(factor, 0, 1);

        int r = (int)(color.R * factor);
        int g = (int)(color.G * factor);
        int b = (int)(color.B * factor);

        return Color.FromArgb(color.A, r, g, b);
    }
}
[TypeConverter(typeof(ExpandableObjectConverter))]
public class Boxes
{
    public string Nome { get; set; } = string.Empty;
    public int IdBox { get; set; } = 0;
    public int IdRepassar { get; set; } = 0;
    public Image Imagem { get; set; } = null;
    public Boxes()
    {

    }
    public override string ToString()
    {
        return Nome;
    }
}
