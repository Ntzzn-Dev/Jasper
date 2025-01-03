namespace Jasper;
using System.Diagnostics;
using System.Windows.Forms;
using SkiaSharp;

public partial class Form3 : Form
{
    Process navegadorAberto;
    int imgCarregada = 0;
    public Form3(Process navegador, string acaoAtual)
    {
        InitializeComponent();

        DefinirGatilhos();

        navegadorAberto = navegador;

        lblTelaColaWeb.Text = acaoAtual;

        picImagemDaWeb.Image = Image.FromFile(Referencias.caminhoImgPadrao);

        txtbxURLWeb.KeyDown += (s, e) => {if(e.KeyCode == Keys.Enter){BaixarImgs(txtbxURLWeb.Text);}};
        txtbxURLWeb.TextChanged += (s, e) => BaixarImgs(txtbxURLWeb.Text);
    }
    public Form3(string acaoAtual)
    {
        InitializeComponent();
        
        DefinirGatilhos();

        lblTelaColaWeb.Text = acaoAtual;

        picImagemDaWeb.Image = Image.FromFile(Referencias.caminhoImgPadrao);
    }

    private void DefinirGatilhos()
    {
        btnRetornoWeb.Click += (s, e) => RetornarURL();
        btnCancelarWeb.Click += (s, e) => FecharBuscaWeb();

        txtbxURLWeb.KeyDown += EnterToEndCola;
    }
    private void EnterToEndCola(object sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Enter)
        {
            e.SuppressKeyPress = true;
            if (sender == txtbxURLWeb)
            {
                if (imgCarregada == 1)
                {
                    RetornarURL();  //Testar
                    imgCarregada = 0;
                }
            }
        }
    }
    private void RetornarURL()
    {
        if (this.Owner is Form2 form2)
        {
            int labelEspecificado = 0;
            if(lblTelaColaWeb.Text.Contains("musica", StringComparison.OrdinalIgnoreCase)) { labelEspecificado = 1;} else
            if(lblTelaColaWeb.Text.Contains("artista", StringComparison.OrdinalIgnoreCase)) { labelEspecificado = 2;} else
            if(lblTelaColaWeb.Text.Contains("playlist", StringComparison.OrdinalIgnoreCase)) { labelEspecificado = 3;}

            form2.DadoRecebidoOnline(txtbxURLWeb.Text, labelEspecificado);

            if (this.Owner != null)
            {
                this.Owner.Show();
                this.Owner.Owner.Show();
            }
        }
    }
    private void FecharBuscaWeb()
    {
        if (navegadorAberto != null && !navegadorAberto.HasExited)
        {
            navegadorAberto.Kill();
        }

        if (this.Owner != null)
        {
            this.Owner.Show();
            this.Owner.Owner.Show();
        }

        this.Close();
    }
    private async Task BaixarImgs(string pathToImg)
    {
        try
        {
            string formato = await DetectarFormatoAsync(pathToImg);
            byte[] bytesDaImg = new byte[0];
            
            if (string.IsNullOrEmpty(pathToImg))
            {
                picImagemDaWeb.Image = Image.FromFile(Referencias.caminhoImgPadrao);
                return;
            }

            if (formato == "LOCAL")
            {
                Image imgCarregada = Image.FromFile(pathToImg);
                picImagemDaWeb.Image = imgCarregada;
            }
            else if (formato == "BASE64")
            {
                var base64Data = pathToImg.Split(',')[1];
                bytesDaImg = Convert.FromBase64String(base64Data);

                using (MemoryStream stream = new MemoryStream(bytesDaImg))
                {
                    Image imgCarregada = Image.FromStream(stream);
                    picImagemDaWeb.Image = imgCarregada;
                }
            }
            else if (formato == "OUTRO")
            {
                using (HttpClient client = new HttpClient())
                {
                    bytesDaImg = await client.GetByteArrayAsync(pathToImg);

                    using (MemoryStream stream = new MemoryStream(bytesDaImg))
                    {
                        Image imgCarregada = Image.FromStream(stream);
                        picImagemDaWeb.Image = imgCarregada;
                    }
                }
            }
            else if (formato == "WEBP")
            {
                Image imagem = await CarregarImagemWebpAsync(pathToImg);

                if (imagem != null){
                    using (MemoryStream ms = new MemoryStream())
                    {
                        Bitmap bitmap = new Bitmap(imagem);
                        bitmap.Save(ms, System.Drawing.Imaging.ImageFormat.Png);

                        bytesDaImg = ms.ToArray();

                        picImagemDaWeb.Image = bitmap;
                    }
                }    
            }
            else if (formato == "ICO")
            {
                Image imagem = await BaixarEConverterIcoAsync(pathToImg);

                if (imagem != null){
                    using (MemoryStream ms = new MemoryStream())
                    {
                        Bitmap bitmap = new Bitmap(imagem);
                        bitmap.Save(ms, System.Drawing.Imaging.ImageFormat.Png);

                        bytesDaImg = ms.ToArray();

                        picImagemDaWeb.Image = bitmap;
                    }
                }                
            } else {return;}
            
            imgCarregada = 1;
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Erro ao baixar a imagem: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
    private async Task<string> DetectarFormatoAsync(string url)
    {
        if(url.StartsWith("data:", StringComparison.OrdinalIgnoreCase)){ return "BASE64"; } else 
        if (File.Exists(url)) { return "LOCAL";} else 
        if (Uri.TryCreate(url, UriKind.Absolute, out Uri? uriResult) && (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps))
            {
            using (HttpClient client = new HttpClient())
            {
                byte[] bytes = await client.GetByteArrayAsync(url);

                if (bytes.Length >= 12)
                {
                    string header = BitConverter.ToString(bytes.Take(12).ToArray()).Replace("-", "");

                    if (header.StartsWith("52494646") && header.Contains("57454250")) // WEBP
                        return "WEBP";

                    if (header.StartsWith("00000100") || header.StartsWith("00000200")) // ICO
                        return "ICO";
                }
                return "OUTRO";
            }
        }
        return "NENHUM";
    }
    private async Task<Image> CarregarImagemWebpAsync(string url)
    {
        using (HttpClient client = new HttpClient())
        {
            byte[] bytes = await client.GetByteArrayAsync(url);

            using (var ms = new MemoryStream(bytes))
            {
                SKBitmap bitmap = SKBitmap.Decode(ms);
                return Image.FromStream(bitmap.Encode(SKEncodedImageFormat.Png, 100).AsStream());
            }
        }
    }
    private async Task<Image> BaixarEConverterIcoAsync(string url)
    {
        using (HttpClient client = new HttpClient())
        {
            byte[] icoBytes = await client.GetByteArrayAsync(url);

            using (var ms = new MemoryStream(icoBytes))
            {
                SKBitmap bitmap = SKBitmap.Decode(ms);
                if (bitmap == null)
                    throw new Exception("Não foi possível decodificar a imagem como um ícone válido.");

                using (MemoryStream pngStream = new MemoryStream())
                {
                    bitmap.Encode(pngStream, SKEncodedImageFormat.Png, 100);
                    pngStream.Seek(0, SeekOrigin.Begin);
                    return Image.FromStream(pngStream);
                }
            }
        }
    }
}
