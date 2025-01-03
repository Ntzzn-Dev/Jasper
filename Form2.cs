namespace Jasper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Data.Sqlite;
using System.IO;
using YoutubeExplode;
using YoutubeExplode.Videos.Streams;
using CSCore;
using CSCore.Codecs;
using CSCore.SoundOut;
using System.Diagnostics;
using Microsoft.Win32;
using SkiaSharp;
using System.Collections;
using YoutubeExplode.Common;
using System.Text.RegularExpressions;

public partial class Form2 : Form
{
    private int idAtual = 0;
    public Form2()
    {
        InitializeComponent();
        DefinirGatilhos();
        CriarDropdown();
        btnSalvarMusica.Click += SalvarMusica;
        btnSalvarArtista.Click += SalvarArtista;
        btnSalvarPlaylist.Click += SalvarPlaylist;
    }
    public Form2(Musicas msc)
    {
        InitializeComponent();
        DefinirGatilhos();
        CriarDropdown();

        txtbxNomeMusica.Texto = msc.getNomeMusica();
        dpdwnArtistaDaMusica.TextDropdown = msc.getNomeArtistaMusica();
        dpdwnArtistaDaMusica.IdElemento = msc.getIdArtistaMusica();
        picImgMusica.Image = msc.getImgMusica();

        txtbxURLMusica.LblPlaceholder = "Deixe em branco para manter";
        txtbxImgMusica.LblPlaceholder = "Deixe em branco para manter";
        btnSalvarMusica.Click += AlterarMusica;

        idAtual = msc.getIdMusica();

        TrocarPage(1);
    }
    public Form2(Playlists ply)
    {
        InitializeComponent();
        DefinirGatilhos();
        CriarDropdown();

        txtbxNomePlaylist.Texto = ply.getNomePlaylist();
        picImgPlaylist.Image = ply.getImgPlaylist();

        txtbxImgPlaylist.LblPlaceholder = "Deixe em branco para manter";
        btnSalvarPlaylist.Click += AlterarPlaylist;

        idAtual = ply.getIdPlaylist();

        TrocarPage(3);
    }
    private void DefinirGatilhos()
    {
        btnPageMusica.Click += BtnTrocarPage;
        btnPageArtista.Click += BtnTrocarPage;
        btnPagePlaylist.Click += BtnTrocarPage;

        btnCancelarMusica.Click += (s, e) => FecharCadastro();
        btnCancelarArtista.Click += (s, e) => FecharCadastro();
        btnCancelarPlaylist.Click += (s, e) => FecharCadastro();

        btnImgMusicaOnline.Click += BtnProcurarImgOnline;
        btnImgArtistaOnline.Click += BtnProcurarImgOnline;
        btnImgPlaylistOnline.Click += BtnProcurarImgOnline;

        btnImgMusicaLocal.Click += BtnProcurarImgLocal;
        btnImgArtistaLocal.Click += BtnProcurarImgLocal;
        btnImgPlaylistLocal.Click += BtnProcurarImgLocal;

        txtbxImgMusica.TextoChanged += (s, e) => { BaixarImgs(txtbxImgMusica.Texto, picImgMusica);}; 
        txtbxImgMusica.EnterPressed += (s, e) => { BaixarImgs(txtbxImgMusica.Texto, picImgMusica);}; 
        txtbxImgArtista.TextoChanged += (s, e) => { BaixarImgs(txtbxImgArtista.Texto, picImgArtista);}; 
        txtbxImgArtista.EnterPressed += (s, e) => { BaixarImgs(txtbxImgArtista.Texto, picImgArtista);}; 
        txtbxImgPlaylist.TextoChanged += (s, e) => { BaixarImgs(txtbxImgPlaylist.Texto, picImgPlaylist);}; 
        txtbxImgPlaylist.EnterPressed += (s, e) => { BaixarImgs(txtbxImgPlaylist.Texto, picImgPlaylist);}; 

        txtbxURLMusica.TextoChanged += IsValidUrlFormat;
    }
    
    private void CriarDropdown(){
        List<Artistas> arts = Artistas.ConsultarArtistas();
        arts.Sort((a, b) => string.Compare(a.getNomeArtista(), b.getNomeArtista(), StringComparison.OrdinalIgnoreCase));

        foreach (var art in arts)
        {
            Elementos elemento = new Elementos();
            elemento.NomeArtista = art.getNomeArtista();
            elemento.IdArtista = art.getIdArtista();
            dpdwnArtistaDaMusica.Elementos.Add(elemento);
        }
    }
    public void DadoRecebidoOnline(string urlRecebida, int labelEspecificado)
    {
        switch (labelEspecificado)
        {
            case 1:
                txtbxImgMusica.Texto = urlRecebida;
                break;
            case 2:
                txtbxImgArtista.Texto = urlRecebida;
                break;
            case 3:
                txtbxImgPlaylist.Texto = urlRecebida;
                break;
        }
    }
    private async void SalvarMusica(object sender, EventArgs e)
    {
        byte[] bytesMusica = await AudioVideo();

        Musicas musica = new Musicas();
        musica.setNomeMusica(txtbxNomeMusica.Texto);
        musica.setBytesMusica(bytesMusica);
        musica.setIdArtistaMusica(dpdwnArtistaDaMusica.IdElemento);
        musica.setImgMusica(picImgMusica.Image);

        Musicas.Salvar(musica);
        this.Close();
    }
    private async void AlterarMusica(object sender, EventArgs e)
    {
        Musicas musica = new Musicas();
        musica.setIdMusica(idAtual);
        musica.setNomeMusica(txtbxNomeMusica.Texto);
        musica.setBytesMusica(new byte[0]);
        musica.setIdArtistaMusica(dpdwnArtistaDaMusica.IdElemento);
        musica.setImgMusica(picImgMusica.Image);
        if(txtbxURLMusica.Texto != ""){
            byte[] bytesMusica = await AudioVideo();
            musica.setBytesMusica(bytesMusica);
        }

        Musicas.Alterar(musica);
        this.Close();
    }
    private void SalvarArtista(object sender, EventArgs e)
    {
        Artistas art = new Artistas();
        art.setNomeArtista(txtbxNomeArtista.Texto);
        art.setImgArtista(picImgArtista.Image);

        Artistas.Salvar(art);
        this.Close();
    }
    private void SalvarPlaylist(object sender, EventArgs e)
    {
        Playlists ply = new Playlists();
        ply.setNomePlaylist(txtbxNomePlaylist.Texto);
        ply.setImgPlaylist(picImgPlaylist.Image);

        Playlists.Salvar(ply);
        this.Close();
    }
    private async void AlterarPlaylist(object sender, EventArgs e)
    {
        Playlists ply = new Playlists();
        ply.setIdPlaylist(idAtual);
        ply.setNomePlaylist(txtbxNomePlaylist.Texto);
        ply.setImgPlaylist(picImgPlaylist.Image);

        Playlists.Alterar(ply);
        this.Close();
    }
    private void BtnTrocarPage(object sender, EventArgs e){
        int indice = 0;
        if(sender == btnPageMusica){
            indice = 1;
        } else 
        if(sender == btnPageArtista){
            indice = 2;
        } else 
        if(sender == btnPagePlaylist){
            indice = 3;
        }
        TrocarPage(indice);
    }
    private void TrocarPage(int indice){
        int music = 0, artist = 0, playlist = 0;
        
        btnPageMusica.BackColor = Color.Gray;
        btnPageArtista.BackColor = Color.Gray;
        btnPagePlaylist.BackColor = Color.Gray;

        switch(indice){
            case 1:
            music = 313;
            btnPageMusica.BackColor = Color.DarkGray;
                break;
            case 2:
            artist = 313;
            btnPageArtista.BackColor = Color.DarkGray;
                break;
            case 3:
            playlist = 313;
            btnPagePlaylist.BackColor = Color.DarkGray;
                break;
        }

        pnlCdtMusic.Size = new Size(669, music);
        pnlCdtArtista.Size = new Size(669, artist);
        pnlCdtPlaylist.Size = new Size(669, playlist);
    }
    private void FecharCadastro(){
        this.Close();
    }
    private async Task<byte[]> AudioVideo()
    {
        string youtubeUrl = txtbxURLMusica.Texto;// URL do vídeo

        try
        {
            YoutubeClient youtube = new YoutubeClient();
            //string outputPath = "audio.mp3";
            var manifest = await youtube.Videos.Streams.GetManifestAsync(youtubeUrl);
            var audioStreamInfo = manifest.GetAudioOnlyStreams().GetWithHighestBitrate();

            if (audioStreamInfo != null)
            {
                //await youtube.Videos.Streams.DownloadAsync(audioStreamInfo, audioPath);
                var audioStream = await youtube.Videos.Streams.GetAsync(audioStreamInfo);
                /*using (var fileStream = new FileStream(outputPath, FileMode.Create, FileAccess.Write))
                {
                    await audioStream.CopyToAsync(fileStream);  // Salva o áudio diretamente no arquivo
                }*/
                using (var memoryStream = new MemoryStream())
                {
                    await audioStream.CopyToAsync(memoryStream);  // Copia o stream de áudio para o MemoryStream
                    byte[] audioBytes = memoryStream.ToArray();   // Converte para array de bytes
                    //MessageBox.Show(audioBytes.Length.ToString());
                    return audioBytes;
                }
            }
            else
            {
                MessageBox.Show("Erro: Nenhum fluxo de áudio encontrado.");
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Erro: {ex.Message}");
        }
        return Array.Empty<byte>();
    }
    private async Task<byte[]> ThumbnailVideo(string thumbnailUrl)
    {
        using (var httpClient = new HttpClient())
        {
            try
            {
                return await httpClient.GetByteArrayAsync(thumbnailUrl);
            }
            catch
            {
                return null;
            }
        }
    }
    private async Task<string> NomeVideo()
    {
        string youtubeUrl = txtbxURLMusica.Texto; // URL do vídeo

        try
        {
            YoutubeClient youtube = new YoutubeClient();

            var video = await youtube.Videos.GetAsync(youtubeUrl);
            string videoTitle = video.Title;
            string output = videoTitle.Replace("\"", "'");
            output = output.Replace("|", "-");

            return output;
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Erro: {ex.Message}");
            return null;
        }
    }
    public async void IsValidUrlFormat(object sender, EventArgs e)
    {
        try
        {
            string url = txtbxURLMusica.Texto;
            if (Uri.IsWellFormedUriString(url, UriKind.Absolute))
            {
                string videoId = ExtractVideoId(url);

                if (!string.IsNullOrEmpty(videoId))
                {
                    string thumbnailUrl = $"https://img.youtube.com/vi/{videoId}/maxresdefault.jpg";

                    if (txtbxImgMusica.Texto == "")
                    {
                        byte[] bytethumb = await ThumbnailVideo(thumbnailUrl);
                        if (bytethumb != null && bytethumb.Length > 0)
                        {
                            picImgMusica.Image = Referencias.ByteArrayToImage(bytethumb);
                            Referencias.PicDefinirCorDeFundo(Referencias.ByteArrayToImage(bytethumb), picImgMusica);
                        }
                        else
                        {
                            MessageBox.Show("Erro: Não foi possível obter a miniatura.");
                        }
                    }

                    if (txtbxNomeMusica.Texto == "")
                    {
                        txtbxNomeMusica.Texto = await NomeVideo();
                    }
                }
                else
                {
                    MessageBox.Show("Erro: ID do vídeo não encontrado na URL.");
                }
            }
            else
            {
                txtbxURLMusica.Texto = "URL inválida";
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Erro: {ex.Message}");
        }
    }
    private string ExtractVideoId(string url)
    {
        // Regex para extrair o ID do vídeo do formato de URL do YouTube
        var match = Regex.Match(url, @"(?:https?://)?(?:www\.)?youtube\.com/watch\?v=([a-zA-Z0-9_-]+)");
        if (match.Success)
        {
            return match.Groups[1].Value;
        }
        return null;
    }
    private void BtnProcurarImgOnline(object sender, EventArgs e)
    {
        string palavraChave = "";
        string acaoTelaCola = "";
        if (sender == btnImgMusicaOnline) { 
            acaoTelaCola = lblImgMusica.Text; 
            palavraChave = txtbxNomeMusica.Texto;
            if(!dpdwnArtistaDaMusica.TextDropdown.Contains("desconhecido", StringComparison.OrdinalIgnoreCase)){ palavraChave = palavraChave + " " + dpdwnArtistaDaMusica.TextDropdown;}}
        else
        if (sender == btnImgArtistaOnline) { acaoTelaCola = lblImgArtista.Text; palavraChave = txtbxNomeArtista.Texto;}
        else
        if (sender == btnImgPlaylistOnline) { acaoTelaCola = lblImgPlaylist.Text; palavraChave = txtbxNomePlaylist.Texto;}
        string urlPesquisa = $"https://www.google.com/search?hl=pt-BR&tbm=isch&q={Uri.EscapeDataString(palavraChave)}";

        try
        {
            string caminhoNavegador = GetDefaultBrowserPath();

            Process navegadorAberto;

            if (File.Exists(caminhoNavegador))
            {
                navegadorAberto = Process.Start(caminhoNavegador, urlPesquisa);
            }
            else
            {
                navegadorAberto = Process.Start(urlPesquisa);
            }

            CriarTelaDeCola(navegadorAberto, acaoTelaCola);
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Erro ao abrir o navegador: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
    private void Reaparecer(string nomeNavegador)
    {
        this.Show();
        this.Owner.Show();

        Process[] navegatorProcesses = Process.GetProcessesByName(nomeNavegador);
        foreach (var process in navegatorProcesses)
        {
            try
            {
                if (process != null && !process.HasExited)
                {
                    process.Kill();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao encerrar o processo: {ex.Message}");
            }
        }
    }
    private string GetDefaultBrowserPath()
    {
        string browserPath = string.Empty;

        string userChoicePath = @"HKEY_CURRENT_USER\Software\Microsoft\Windows\Shell\Associations\UrlAssociations\http\UserChoice";

        string progId = Registry.GetValue(userChoicePath, "ProgId", null) as string;

        if (string.IsNullOrEmpty(progId))
            throw new Exception("Navegador padrão não encontrado.");

        string browserRegPath = $@"HKEY_CLASSES_ROOT\{progId}\shell\open\command";
        browserPath = Registry.GetValue(browserRegPath, null, null) as string;

        if (string.IsNullOrEmpty(browserPath))
            throw new Exception("Caminho do navegador padrão não encontrado.");

        int firstQuote = browserPath.IndexOf('"');
        if (firstQuote >= 0)
        {
            int secondQuote = browserPath.IndexOf('"', firstQuote + 1);
            if (secondQuote > firstQuote)
            {
                browserPath = browserPath.Substring(firstQuote + 1, secondQuote - firstQuote - 1);
            }
        }

        return browserPath;
    }
    public void BtnProcurarImgLocal(object sender, EventArgs e)
    {
        OpenFileDialog ofd = new OpenFileDialog();
        ofd.Filter = "Imagens (*.jpg;*.png;*.webp;*.jpeg)|*.jpg;*.png;*.webp;*.jpeg";

        if (sender == btnImgMusicaLocal)
        {
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                txtbxImgMusica.Texto = ofd.FileName;
            }
        }
        if (sender == btnImgArtistaLocal)
        {
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                txtbxImgArtista.Texto = ofd.FileName;
            }
        }
        if (sender == btnImgPlaylistLocal)
        {
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                txtbxImgPlaylist.Texto = ofd.FileName;
            }
        }
    }
    private void CriarTelaDeCola(Process navegadorAberto, string acaoTelaCola)
    {
        if (navegadorAberto != null && !navegadorAberto.HasExited)
        {
            string nomeDoProcessador = navegadorAberto.ProcessName;
            Form3 telaCola = new Form3(navegadorAberto, acaoTelaCola);
            telaCola.Owner = this;
            telaCola.FormClosed += (s, e) => Reaparecer(nomeDoProcessador);

            this.Owner.Hide();
            this.Hide();

            telaCola.ShowDialog();
        }
        else
        {
            Form3 telaCola = new Form3(acaoTelaCola);
            telaCola.Owner = this;

            this.Owner.Hide();
            this.Hide();

            telaCola.ShowDialog();
        }
    }
    private async Task BaixarImgs(string pathToImg, PictureBox pcbxEmUso)
    {
        try
        {
            string formato = await DetectarFormatoAsync(pathToImg);
            byte[] bytesDaImg = new byte[0];
            Image imgCarregada = null;
            if (string.IsNullOrEmpty(pathToImg))
            {
                pcbxEmUso.Image = Image.FromFile(Referencias.caminhoImgPadrao);
                bytesDaImg = File.ReadAllBytes(Referencias.caminhoImgPadrao);
                return;
            }

            if (formato == "LOCAL")
            {
                imgCarregada = Image.FromFile(pathToImg);
                
                bytesDaImg = File.ReadAllBytes(pathToImg);
                pcbxEmUso.Image = imgCarregada;
            }
            else if (formato == "BASE64")
            {
                var base64Data = pathToImg.Split(',')[1];
                byte[] bytesDaImg2 = Convert.FromBase64String(base64Data);

                using (MemoryStream stream = new MemoryStream(bytesDaImg2))
                {
                    imgCarregada = Image.FromStream(stream);
                    
                    bytesDaImg = Convert.FromBase64String(base64Data);
                    pcbxEmUso.Image = imgCarregada;
                }
            }
            else if (formato == "OUTRO")
            {
                using (HttpClient client = new HttpClient())
                {
                    bytesDaImg = await client.GetByteArrayAsync(pathToImg);

                    using (MemoryStream stream = new MemoryStream(bytesDaImg))
                    {
                        imgCarregada = Image.FromStream(stream);
                        
                        pcbxEmUso.Image = imgCarregada;                    
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
                        imgCarregada = Image.FromStream(ms);
                        pcbxEmUso.Image = bitmap;
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
                        imgCarregada = Image.FromStream(ms);
                        pcbxEmUso.Image = bitmap;
                    }
                }                
            }
            else {return;}

            Referencias.PicDefinirCorDeFundo(imgCarregada, pcbxEmUso);
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