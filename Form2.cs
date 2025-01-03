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

public partial class Form2 : Form
{
    private ISoundOut _soundOut;
    private IWaveSource _audioSource;
    private bool _isPlaying = false;
    private Musicas musc;
    public Form2()
    {
        InitializeComponent();
        DefinirGatilhos();
    }
    private void DefinirGatilhos()
    {
        btnPageMusica.Click += TrocarPage;
        btnPageArtista.Click += TrocarPage;
        btnPagePlaylist.Click += TrocarPage;

        btnSalvarMusica.Click += Salvar;

        btnURLOnlineMusic.Click += PlayPauseButton_Click;

        btnCancelarMusica.Click += FecharCadastro;
        btnCancelarArtista.Click += FecharCadastro;
        btnCancelarPlaylist.Click += FecharCadastro;
    }
    private async void Salvar(object sender, EventArgs e)
    {
        byte[] bytesMusica = await btnDownload_Click();
        Musicas musica = new Musicas();
        musica.setNomeMusica(txtbxNomeMusica.Texto);
        musica.setBytesMusica(bytesMusica);
        musica.setArtistaMusica(1);
        musica.setImgMusica(Image.FromFile(Referencias.caminhoImgPadrao));

        Musicas.Salvar(musica);
    }
    /*private void TocarMusica (object sender, EventArgs e)
    {
        Musicas muica = new Musicas(1);
        byte[] audioBytes = muica.getBytesMusica();
        PlayAudioFromBytes(audioBytes);
    }*/
    /*public void PlayAudioFromBytes(byte[] audioBytes)
    {
        try
        {
            using (var memoryStream = new MemoryStream(audioBytes))
        {
            // Defina o caminho temporário para o arquivo de áudio
            string tempFilePath = Path.Combine(Path.GetTempPath(), "temp_audio.m4a");

            // Grave o array de bytes em um arquivo temporário
            File.WriteAllBytes(tempFilePath, audioBytes);

            // Inicialize o VLC
            var vlcControl = new VlcControl();
vlcControl.VlcLibDirectory = new DirectoryInfo(@"C:\Program Files\VideoLAN\VLC"); // Caminho para o VLC
this.Controls.Add(vlcControl); // Adiciona o controle ao formulário
vlcControl.Play(new FileInfo(tempFilePath));

            Console.WriteLine("Reproduzindo áudio..."); // Mantém o console aberto enquanto o áudio toca

            // Remova o arquivo temporário após a reprodução
            File.Delete(tempFilePath);
        }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Erro ao tocar música: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }*/
    
    private void PlayPauseButton_Click(object sender, EventArgs e)
    {
        if(musc == null){CriacaoAudio();}
        if (_isPlaying)
        {
            // Pausar reprodução
            _soundOut.Pause();
            _isPlaying = false;
            ((Button)sender).Text = "Play";
        }
        else
        {
            // Retomar ou iniciar reprodução
            if (_soundOut == null)
            {
                InitializeAudio();
            }
            _soundOut.Play();
            _isPlaying = true;
            ((Button)sender).Text = "Pause";
        }
    }
    private async void CriacaoAudio(){
        //musc = new Musicas(1);
        string tempFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Musicas", "VVV.m4a");
        string directoryPath = Path.GetDirectoryName(tempFilePath);
        if (!Directory.Exists(directoryPath))
        {
            Directory.CreateDirectory(directoryPath);
        }
        if (!File.Exists(tempFilePath))
        {
            byte[] bytesMusica = await btnDownload_Click();
            MessageBox.Show(bytesMusica.Length.ToString());
            File.WriteAllBytes(tempFilePath, bytesMusica);
        }
        /*if (File.Exists(tempFilePath))
        {
            File.Delete(tempFilePath);
            Console.WriteLine("Arquivo temporário apagado: " + tempFilePath);
        }*/
    }

    private void InitializeAudio()
    {
        string tempFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Musicas", "VVV.m4a");

        // Configurar reprodução
        _audioSource = CodecFactory.Instance.GetCodec(tempFilePath);
        _soundOut = new WasapiOut();
        _soundOut.Initialize(_audioSource);
    }

    protected override void OnFormClosing(FormClosingEventArgs e)
    {
        // Liberar recursos ao fechar o formulário
        _soundOut?.Stop();
        _soundOut?.Dispose();
        _audioSource?.Dispose();
        base.OnFormClosing(e);
    }
    private void TrocarPage(object sender, EventArgs e){
        Button btn = sender as Button;
        int music = 0, artist = 0, playlist = 0;
        
        btnPageMusica.BackColor = Color.Gray;
        btnPageArtista.BackColor = Color.Gray;
        btnPagePlaylist.BackColor = Color.Gray;

        if(btn.Name.ToLower().Contains("music")){
            music = 313;
        } else 
        if(btn.Name.ToLower().Contains("artist")){
            artist = 313;
        } else 
        if(btn.Name.ToLower().Contains("play")){
            playlist = 313;
        }

        btn.BackColor = Color.DarkGray;
        
        pnlCdtMusic.Size = new Size(669, music);
        pnlCdtArtista.Size = new Size(669, artist);
        pnlCdtPlaylist.Size = new Size(669, playlist);
    }
    private void FecharCadastro(object sender, EventArgs e){
        this.Close();
    }

    private async Task<byte[]> btnDownload_Click()
    {
        string youtubeUrl = txtbxURLMusica.Texto;//txtbxLinkMusic.Text; // URL do vídeo
        string audioPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "audio.m4a");

        try
        {
            //lblStatusMusic.Text = "Baixando áudio...";
            YoutubeClient youtube = new YoutubeClient();

            // Obtém o manifesto de streams
            var manifest = await youtube.Videos.Streams.GetManifestAsync(youtubeUrl);
            var audioStreamInfo = manifest.GetAudioOnlyStreams().GetWithHighestBitrate();

            if (audioStreamInfo != null)
            {
                //await youtube.Videos.Streams.DownloadAsync(audioStreamInfo, audioPath);
                var audioStream = await youtube.Videos.Streams.GetAsync(audioStreamInfo);
                using (var memoryStream = new MemoryStream())
                {
                    await audioStream.CopyToAsync(memoryStream);  // Copia o stream de áudio para o MemoryStream
                    byte[] audioBytes = memoryStream.ToArray();   // Converte para array de bytes
                    MessageBox.Show(audioBytes.Length.ToString());
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
}
