namespace Jasper.NthControls;
using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Reflection.Emit;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using static System.Net.WebRequestMethods;

public partial class TitleBarPersonalizada : UserControl
{
    [DllImport("user32.dll")]
    public static extern bool ReleaseCapture();
    [DllImport("user32.dll")]
    public static extern bool SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
    const int WM_NCLBUTTONDOWN = 0xA1;
    const int HTCAPTION = 0x2;

    private bool _withFechar = true;
    private bool _withMaximizar = true;
    private bool _withMinimizar = true;
    private int _labelPosition = 0;
    private string _title = "new window";
    private bool _Fechar = true;
    private bool _Maximizar = true;
    private bool _Minimizar = true;
    public EventHandler FecharCustom;
    public EventHandler MaximizarCustom;
    public EventHandler MinimizarCustom;
    public bool WithFechar
    {
        get => _withFechar;
        set
        {
            _withFechar = value;
            ToogleImg();
            picBtnFechar.Enabled = value;
            picBtnFechar.Visible = value;
            Invalidate();
        }
    }
    public bool WithMaximizar
    {
        get => _withMaximizar;
        set
        {
            _withMaximizar = value;
            ToogleImg();
            picBtnMaximizar.Enabled = value;
            picBtnMaximizar.Visible = value;
            Invalidate();
        }
    }
    public bool WithMinimizar
    {
        get => _withMinimizar;
        set
        {
            _withMinimizar = value;
            ToogleImg();
            picBtnMinimizar.Enabled = value;
            picBtnMinimizar.Visible = value;
            Invalidate();
        }
    }
    public int LabelPosition
    {
        get => _labelPosition;
        set
        {
            _labelPosition = value;
            PosicaoLabel(_labelPosition);
            Invalidate();
        }
    }
    public string Title
    {
        get => _title;
        set
        {
            _title = value;
            lblNomeTela.Text = _title;
            Invalidate();
        }
    }
    public bool Fechar
    {
        get => _Fechar;
        set
        {
            _Fechar = value;
            Invalidate();
        }
    }
    public bool Maximizar
    {
        get => _Maximizar;
        set
        {
            _Maximizar = value;
            Invalidate();
        }
    }
    public bool Minimizar
    {
        get => _Minimizar;
        set
        {
            _Minimizar = value;
            Invalidate();
        }
    }

    public TitleBarPersonalizada()
    {
        InitializeComponent();
    }
    private void PosicaoLabel(int i)
    {
        List<Point> posicoes =
        [
            new Point(3, 1),
            new Point(this.Size.Width/2 - lblNomeTela.Size.Width/2, 1),
            //new Point(this.Size.Width - 153, 1),
        ];

        lblNomeTela.Location = posicoes[i];
    }
    private void ToogleImg()
    {
        List<Point> posicoes =
        [
            new Point(this.Size.Width - 51, 1),
            new Point(this.Size.Width - 102, 1),
            new Point(this.Size.Width - 153, 1),
        ];

        if (WithFechar) { picBtnFechar.Location = posicoes[0]; posicoes.RemoveAt(0); }
        if (WithMaximizar) { picBtnMaximizar.Location = posicoes[0]; posicoes.RemoveAt(0); }
        if (WithMinimizar) { picBtnMinimizar.Location = posicoes[0]; }
    }
    protected virtual void TitleSegurar(object sender, MouseEventArgs e)
    {
        if (this.Parent is Form parentForm)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(parentForm.Handle, WM_NCLBUTTONDOWN, HTCAPTION, 0);
            }
        }
    }
    protected virtual void PicBtnFechar(object sender, EventArgs e)
    {
        if (Fechar == false) { FecharCustom?.Invoke(this, e); return; }
        if (this.Parent is Form parentForm) { parentForm.Close(); }
    }
    protected virtual void PicBtnMaximizar(object sender, EventArgs e)
    {
        if (Maximizar == false) { MaximizarCustom?.Invoke(this, e); return; }
        if (this.Parent is Form parentForm) {
            if (parentForm.WindowState == FormWindowState.Maximized)
                parentForm.WindowState = FormWindowState.Normal;
            else
                parentForm.WindowState = FormWindowState.Maximized;
        }
    }
    protected virtual void PicBtnMinimizar(object sender, EventArgs e)
    {
        if (Minimizar == false) { MinimizarCustom?.Invoke(this, e); return; }
        if (this.Parent is Form parentForm) { parentForm.WindowState = FormWindowState.Minimized; }
    }
    private void TitleBarPersonalizada_Paint(object sender, PaintEventArgs e)
    {
        lblNomeTela.Text = _title;
        PosicaoLabel(_labelPosition);
        ToogleImg();
    }
    private void TitleBarPersonalizada_Load(object sender, EventArgs e)
    {
        lblNomeTela.Text = _title;
        PosicaoLabel(_labelPosition);
        ToogleImg();
        /*
        this.MouseDown += MainForm_MouseDown;
        this.MouseMove += MainForm_MouseMove;
        this.MouseUp += MainForm_MouseUp;*/
    }
    /*private void MainForm_MouseDown(object sender, MouseEventArgs e)
    {
        int margin = 10;

        resizeDirection = GetResizeDirection(e.Location, margin);

        if (resizeDirection != ResizeDirection.None)
        {
            isResizing = true;
            lastMousePosition = e.Location;
        }
    }

    private void MainForm_MouseMove(object sender, MouseEventArgs e)
    {
        int margin = 10;

        if (isResizing)
        {
            ResizeForm(e.Location);
            lastMousePosition = e.Location;
        }
        else
        {
            // Atualiza o cursor com base na borda próxima
            resizeDirection = GetResizeDirection(e.Location, margin);
            this.Cursor = GetCursorForDirection(resizeDirection);
        }
    }

    private void MainForm_MouseUp(object sender, MouseEventArgs e)
    {
        isResizing = false;
        resizeDirection = ResizeDirection.None;
        this.Cursor = Cursors.Default;
    }

    private ResizeDirection GetResizeDirection(Point mousePosition, int margin)
    {
        if (mousePosition.X < margin && mousePosition.Y < margin)
            return ResizeDirection.TopLeft;
        if (mousePosition.X > this.Width - margin && mousePosition.Y < margin)
            return ResizeDirection.TopRight;
        if (mousePosition.X < margin && mousePosition.Y > this.Height - margin)
            return ResizeDirection.BottomLeft;
        if (mousePosition.X > this.Width - margin && mousePosition.Y > this.Height - margin)
            return ResizeDirection.BottomRight;
        if (mousePosition.X < margin)
            return ResizeDirection.Left;
        if (mousePosition.X > this.Width - margin)
            return ResizeDirection.Right;
        if (mousePosition.Y < margin)
            return ResizeDirection.Top;
        if (mousePosition.Y > this.Height - margin)
            return ResizeDirection.Bottom;

        return ResizeDirection.None;
    }

    private Cursor GetCursorForDirection(ResizeDirection direction)
    {
        return direction switch
        {
            ResizeDirection.TopLeft or ResizeDirection.BottomRight => Cursors.SizeNWSE,
            ResizeDirection.TopRight or ResizeDirection.BottomLeft => Cursors.SizeNESW,
            ResizeDirection.Left or ResizeDirection.Right => Cursors.SizeWE,
            ResizeDirection.Top or ResizeDirection.Bottom => Cursors.SizeNS,
            _ => Cursors.Default,
        };
    }

    private void ResizeForm(Point mousePosition)
    {
        if (this.Parent is Form parentForm)
        {
            int deltaX = mousePosition.X - lastMousePosition.X;
            int deltaY = mousePosition.Y - lastMousePosition.Y;

            switch (resizeDirection)
            {
                case ResizeDirection.TopLeft:
                    parentForm.Width -= deltaX;
                    parentForm.Height -= deltaY;
                    parentForm.Left += deltaX;
                    parentForm.Top += deltaY;
                    break;
                case ResizeDirection.TopRight:
                    parentForm.Width += deltaX;
                    parentForm.Height -= deltaY;
                    parentForm.Top += deltaY;
                    break;
                case ResizeDirection.BottomLeft:
                    parentForm.Width -= deltaX;
                    parentForm.Height += deltaY;
                    parentForm.Left += deltaX;
                    break;
                case ResizeDirection.BottomRight:
                    parentForm.Width += deltaX;
                    parentForm.Height += deltaY;
                    break;
                case ResizeDirection.Left:
                    parentForm.Width -= deltaX;
                    parentForm.Left += deltaX;
                    break;
                case ResizeDirection.Right:
                    parentForm.Width += deltaX;
                    break;
                case ResizeDirection.Top:
                    parentForm.Height -= deltaY;
                    parentForm.Top += deltaY;
                    break;
                case ResizeDirection.Bottom:
                    parentForm.Height += deltaY;
                    break;
            }
        }
    }

    private enum ResizeDirection
    {
        None,
        TopLeft,
        TopRight,
        BottomLeft,
        BottomRight,
        Left,
        Right,
        Top,
        Bottom
    }*/
}
