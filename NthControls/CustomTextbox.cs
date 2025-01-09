namespace Jasper.NthControls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public partial class CustomTextbox : UserControl
{
    bool isFocused = false;
    private string _placeholder = "";
    private bool _password = false;
    private bool _multiline = false;
    private Color _backColor = Color.White;
    private Color _textColor = Color.White;
    private string _texto = "";
    public event EventHandler TextoChanged;
    public string LblPlaceholder
    {
        get { return _placeholder; }
        set
        {
            _placeholder = value;
            this.Invalidate();
        }
    }
    public string Texto
    {
        get { return _texto; }
        set
        {
            _texto = value;
            OnTextChanged(EventArgs.Empty);
            textBox1.Text = _texto;
            if (textBox1.Text != "") {
                isFocused = true;
                label1.Font = new Font("Segoe UI", 8);
                int y = 0;
                label1.Location = new Point(label1.Location.X, y);
                label1.ForeColor = Color.Silver;
            }
            this.Invalidate();
        }
    }
    public bool Password
    {
        get { return _password; }
        set
        {
            _password = value;
            this.Invalidate();
        }
    }
    public bool Multiline
    {
        get { return _multiline; }
        set
        {
            _multiline = value;
            this.Invalidate();
        }
    }
    public Color backColor
    {
        get { return _backColor; }
        set
        {
            this._backColor = value;
            this.Invalidate();
        }
    }
    public Color textColor
    {
        get { return _textColor; }
        set
        {
            this._textColor = value;
            this.Invalidate();
        }
    }

    public CustomTextbox()
    {
        InitializeComponent();
        textBox1.KeyDown += TextBox1_KeyDown;
    }

    private void AoCarregar(object sender, EventArgs e)
    {
        if (Password == true)
        {
            textBox1.UseSystemPasswordChar = true;
        }
        if (!Texto.Equals(""))
        {
            textBox1.Text = Texto;
            lblTimer.Start();
        }
    }
    private void CustomTextBox_Paint(object sender, PaintEventArgs e)
    {
        using (Brush greenBrush = new SolidBrush(backColor))
        {
            Rectangle greenRectangle = new Rectangle(
                0, // Começa no X do TextBox
                textBox1.Location.Y - 3, // Começa no Y do TextBox
                this.Width,      // Largura do TextBox
                this.Height - textBox1.Location.Y // Altura até o final do UserControl
            );
            e.Graphics.FillRectangle(greenBrush, greenRectangle);
        }

        label1.BackColor = backColor;
        textBox1.BackColor = backColor;

        label1.Text = LblPlaceholder;
        if (Multiline == true)
        {
            textBox1.Multiline = true;
            textBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right | AnchorStyles.Left;
            textBox1.Height = this.Height;
        }
        label1.ForeColor = textColor;
    }

    private void lblTimer_Tick(object sender, EventArgs e)
    {
        int y = label1.Location.Y;
        if (isFocused == false)
        {
            y -= 2;
            label1.Location = new Point(label1.Location.X, y);
            if (y <= 0) //Definicao de altura max
            {
                isFocused = true;
                lblTimer.Stop();
                label1.Font = new Font("Segoe UI", 8);
                y = 0;
                label1.Location = new Point(label1.Location.X, y);
                label1.ForeColor = Color.Silver;
            }
        }
        else
        {
            y += 2;
            label1.Location = new Point(label1.Location.X, y);
            if (y >= 10)
            {
                isFocused = false;
                lblTimer.Stop();
                label1.Font = new Font("Segoe UI", 10);
                y = 10;
                label1.Location = new Point(label1.Location.X, y);
                label1.ForeColor = textColor;
            }
        }
    }

    private void textBox1_EnterOrLeave(object sender, EventArgs e)
    {
        if (textBox1.Text == "")
        {
            lblTimer.Start();
        }
    }
    private void label1_Click(object sender, EventArgs e)
    {
        textBox1.Focus();
    }
    private void textBox1_TextChanged(object sender, EventArgs e)
    {
        Texto = textBox1.Text;
    }
    protected virtual void OnTextChanged(EventArgs e)
    {
        TextoChanged?.Invoke(this, e);
    }
    private void TextBox1_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Enter)
        {
            e.SuppressKeyPress = true;
            OnEnterPressed(EventArgs.Empty);
        }
    }
    public event EventHandler EnterPressed;

    protected virtual void OnEnterPressed(EventArgs e)
    {
        EnterPressed?.Invoke(this, e);
    }
}