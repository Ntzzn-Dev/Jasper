namespace Jasper.NthControls;
using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Slider : Control
{
    private int _minimum = 0;
    private int _maximum = 100;
    private int _value = 50;
    private bool _isDragging = false;
    private int _trackHeight = 4;
    private int _thumbSize = 16;
    private bool _withPoint = true;

    public event EventHandler ValueChanged;

    public int Minimum
    {
        get => _minimum;
        set
        {
            _minimum = value;
            Invalidate();
        }
    }

    public int Maximum
    {
        get => _maximum;
        set
        {
            _maximum = value;
            Invalidate();
        }
    }

    public int Value
    {
        get => _value;
        set
        {
            int newValue = Math.Max(_minimum, Math.Min(_maximum, value));
            if (_value != newValue)
            {
                _value = newValue;
                OnValueChanged(EventArgs.Empty); // Dispara o evento
                Invalidate();
            }
        }
    }

    public int TrackHeight
    {
        get => _trackHeight;
        set
        {
            _trackHeight = value;
            Invalidate();
        }
    }

    public int ThumbSize
    {
        get => _thumbSize;
        set
        {
            _thumbSize = value;
            Invalidate();
        }
    }

    public bool WithPoint
    {
        get => _withPoint;
        set
        {
            _withPoint = value;
            Invalidate();
        }
    }

    public Slider()
    {
        this.DoubleBuffered = true;
        this.Size = new Size(200, 40);
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        Brush vazio = new SolidBrush(Color.FromArgb(255, 160, 160, 160)); // Cor do trilho
        LinearGradientBrush preenchido = new LinearGradientBrush(new PointF(0, 0), new PointF(Width, 0), Color.FromArgb(98, 51, 175), Color.FromArgb(255, 120, 120, 120));
        Brush polegar = new SolidBrush(Color.FromArgb(255, 191, 195, 198)); // Cor do polegar

        int fillWidth = (int)((float)(Value - Minimum) / (Maximum - Minimum) * (Width - 20));
        Rectangle fillRect = new Rectangle(10, Height / 2 - TrackHeight / 2, fillWidth, TrackHeight);

        Rectangle trackRect = new Rectangle(10, Height / 2 - TrackHeight / 2, Width - 20, TrackHeight);
        e.Graphics.FillRectangle(vazio, trackRect); // Preenche o trilho com a cor definida
        
        e.Graphics.FillRectangle(preenchido, fillRect); // Preenche a parte preenchida do slider

        if (WithPoint)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            int thumbX = 10 + fillWidth - ThumbSize / 2;
            Rectangle thumbRect = new Rectangle(thumbX, Height / 2 - ThumbSize / 2, ThumbSize, ThumbSize);
            e.Graphics.FillEllipse(polegar, thumbRect);

        }
        
        base.OnPaint(e);
    }

    protected override void OnMouseDown(MouseEventArgs e)
    {
        base.OnMouseDown(e);

        // Detectar se o clique foi na barra
        if (e.Button == MouseButtons.Left)
        {
            int mouseX = Math.Max(10, Math.Min(Width - 10, e.X));
            int relativeX = mouseX - 10;
            Value = Minimum + (int)((float)relativeX / (Width - 20) * (Maximum - Minimum));

            // Verificar se o clique foi dentro do polegar para começar o arrasto
            Rectangle thumbRect = new Rectangle(
                10 + (int)((float)(Value - Minimum) / (Maximum - Minimum) * (Width - 20)) - 8,
                Height / 2 - 8, 16, 16);

            _isDragging = thumbRect.Contains(e.Location);
        }
    }

    protected override void OnMouseMove(MouseEventArgs e)
    {
        base.OnMouseMove(e);

        if (_isDragging)
        {
            int mouseX = Math.Max(10, Math.Min(Width - 10, e.X));
            int relativeX = mouseX - 10;
            Value = Minimum + (int)((float)relativeX / (Width - 20) * (Maximum - Minimum));
        }
    }

    protected override void OnMouseUp(MouseEventArgs e)
    {
        base.OnMouseUp(e);
        _isDragging = false;
    }

    protected virtual void OnValueChanged(EventArgs e)
    {
        ValueChanged?.Invoke(this, e); // Invoca os assinantes do evento
    }
}