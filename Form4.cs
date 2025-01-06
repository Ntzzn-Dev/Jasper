namespace Jasper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CSCore;
using CSCore.SoundOut;
using CSCore.Streams;

public partial class Form4 : Form
{
    private Form1 formularioPai;
    private NotifyIcon notifyIcon;
    public Form4()
    {
        InitializeComponent();
        MostrarMusica();
        this.Load += (s,e) => AoCarregar();
        DefinirGatilhos();
        this.TopMost = true;
        titleBarPersonalizada1.MinimizarCustom += (s, e) => MandarParaBandeja();
    }
    private void CriarNotificacao()
    {
        notifyIcon = new NotifyIcon();
        notifyIcon.Icon = SystemIcons.Information;
        notifyIcon.Visible = true;

        ContextMenuStrip contextMenu = new ContextMenuStrip();
        contextMenu.Items.Add("Restaurar", null, RestaurarControl);
        contextMenu.Items.Add("Sair", null, SairControl);
        notifyIcon.ContextMenuStrip = contextMenu;
    }
    private void RestaurarControl(object sender, EventArgs e)
    {
        this.Show();
        RemoverNotificacao();
    }
    private void SairControl(object sender, EventArgs e)
    {
        RemoverNotificacao();
        Application.Exit();
    }
    private void RemoverNotificacao()
    {
        if (notifyIcon != null)
        {
            notifyIcon.Visible = false;
            notifyIcon.Dispose();
        }
    }
    private void MandarParaBandeja(){
        CriarNotificacao();
        this.Hide();
        notifyIcon.ShowBalloonTip(10000, "Aplicativo Minimizado", "Clique para restaurar", ToolTipIcon.Info);
    }
    private void AoCarregar(){
        formularioPai = (Form1)this.Owner;

        formularioPai.RepetirNvl = Form1.ToogleSituacao(formularioPai.RepetirNvl -1, picBtnRepetirMusic, "Repetir"); 
        formularioPai.AleatorioNvl = Form1.ToogleSituacao(formularioPai.AleatorioNvl -1, picBtnAleatorioMusic, "Aleatorizar");

        if(Form1.isPlaying){picBtnPlayMusic.Image = Properties.Resources.Pausar;}
        else {picBtnPlayMusic.Image = Properties.Resources.Play;} 

        Form1.timerWhileMusic?.Dispose();
        Form1.timerWhileMusic = new System.Threading.Timer(WhileMusic, null, 0, 500);
        sldTimelineMusic.Maximum = (int)Math.Round(Form1._audioSource.GetLength().TotalSeconds);

        sldVolume.Value = (int)(formularioPai.VolumeNvl * 100);
        DefinirImageVolume(sldVolume.Value);

        Playlists ply = new Playlists(Form1.playlistAtual);
        LblPosicionarCorretamente(string.IsNullOrEmpty(ply.getNomePlaylist()) ? "Todas" : ply.getNomePlaylist(), lblNomePlaylist);
        lblPlaylist.Location = new Point(lblNomePlaylist.Location.X - lblPlaylist.Size.Width, lblPlaylist.Location.Y);
    }
    private void DefinirGatilhos(){
        picBtnPlayMusic.Click += (s, e) => PlayMusica();
        picBtnNextMusic.Click += (s, e) => NextMusic();
        picBtnPrevMusic.Click += (s, e) => PrevMusic();
        picSoundMusic.Click += ToggleSilenciar;

        picBtnAvancarMusic.Click += AdiantarMusica;
        picBtnRetroMusic.Click += AtrasarMusica;
        
        sldVolume.ValueMouseChanged += VolumeSlider;
        sldTimelineMusic.ValueMouseChanged += TimelineSlider;

        picBtnRepetirMusic.Click += (s,e) =>{formularioPai.RepetirNvl = Form1.ToogleSituacao(formularioPai.RepetirNvl, picBtnRepetirMusic, "Repetir");};

        picBtnAleatorioMusic.Click += (s, e) => {formularioPai.AleatorioNvl = Form1.ToogleSituacao(formularioPai.AleatorioNvl, picBtnAleatorioMusic, "Aleatorizar");};
    }
    private void LblPosicionarCorretamente(string novoTexto, Label textToEdit)
    {
        int antigaLargura = textToEdit.Width;
        textToEdit.Text = novoTexto;

        int novaLargura = textToEdit.Width;
        int deslocamento = novaLargura - antigaLargura;

        textToEdit.Left -= deslocamento;
    }
    private async void PlayMusica()
    {
        try{
            Form1.musicaAtual = new Musicas(Form1.idAtual);
            Form1.tempFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Musicas", Form1.musicaAtual.getNomeMusica() + ".m4a");
            if (!File.Exists(Form1.tempFilePath)) { await Form1.CreateAudio(); }
            
            if (Form1.isPlaying)
            {
                // Pausar reprodução
                if (Form1._soundOut != null)
                {
                    Form1._soundOut.Pause();
                    Form1.isPlaying = false;
                    picBtnPlayMusic.Image = Properties.Resources.Play;
                }
            }
            else
            {
                // Retomar ou iniciar reprodução
                if (Form1._soundOut == null)
                {
                    Form1.InitializeAudio();
                } 
                if (Form1._soundOut != null)
                {   
                    Form1._soundOut.Play();
                    Form1.timerWhileMusic?.Dispose();
                    Form1.timerWhileMusic = new System.Threading.Timer(WhileMusic, null, 0, 500);
                    sldTimelineMusic.Maximum = (int)Math.Round(Form1._audioSource.GetLength().TotalSeconds);    
                    Form1.isPlaying = true;
                    picBtnPlayMusic.Image = Properties.Resources.Pausar;
                }
            }
            MostrarMusica();
        } catch (Exception e){
            MessageBox.Show($"Erro ao iniciar nova musica: {e.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
    private async void WhileMusic(object state)
    {
        if (Form1._soundOut != null)
        {
            if (Form1._audioSource.GetPosition().TotalSeconds >= Form1._audioSource.GetLength().TotalSeconds - 0.5f)
            {
                await NextMusic();
                return;
            } else 
            if (Form1._soundOut.PlaybackState == PlaybackState.Playing)
            {
                sldTimelineMusic.Value = (int)Form1._audioSource.GetPosition().TotalSeconds;
                lblDuracaoAtual.Text = TimeSpan.FromSeconds(Math.Round(Form1._audioSource.GetPosition().TotalSeconds)).ToString(@"mm\:ss");
            }
            else
            {
                Form1.timerWhileMusic.Dispose();
                sldTimelineMusic.Value = 0;
            }
        }
    }
    private async Task<bool> NextMusic(){
        try{
            int indiceAtual = Form1.filaAtual.IndexOf(Form1.idAtual);
            int proximoIndice = indiceAtual + 1;

            int Randomic(int valorpadrao){
                Random random = new Random();
                if(formularioPai.AleatorioNvl == 1){
                    return random.Next(1, Form1.filaAtual.Count);
                } else
                if(formularioPai.AleatorioNvl == 2){
                    if(Form1.aleatorioSemRepeticao.Count == 0){
                        Form1.aleatorioSemRepeticao = Enumerable.Range(0, Form1.filaAtual.Count).ToList();
                    }
                    int indiceAleatorio = random.Next(Form1.aleatorioSemRepeticao.Count);
                    var mscAleatoria = Form1.aleatorioSemRepeticao[indiceAleatorio];
                    Form1.aleatorioSemRepeticao.RemoveAt(indiceAleatorio);
                    return mscAleatoria;
                }
                return valorpadrao;
            }
            
            if (indiceAtual < Form1.filaAtual.Count - 1 && formularioPai.RepetirNvl != 2)
            {
                proximoIndice = Randomic(indiceAtual + 1);
                if (Form1._soundOut != null)
                {
                    await Form1.FinalizarMusica();
                }
                Form1.idAtual = (int)Form1.filaAtual[proximoIndice];
                PlayMusica();
                return true;
            } 

            if(formularioPai.RepetirNvl == 1 || formularioPai.AleatorioNvl != 0){
                    proximoIndice = Randomic(0);
                    if (Form1._soundOut != null)
                    {
                        await Form1.FinalizarMusica();
                    }
                    Form1.idAtual = (int)Form1.filaAtual[proximoIndice];
                    PlayMusica();
                return true;
            }
            if(formularioPai.RepetirNvl == 2){
                    if (Form1._soundOut != null)
                    {
                        await Form1.FinalizarMusica();
                    }
                    PlayMusica();
                return true;
            }

        } catch (Exception e){
            MessageBox.Show($"Erro ao passar uma musica: {e.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        return false;
    }
    private async Task<bool> PrevMusic(){
        try{
            int indiceAtual = Form1.filaAtual.IndexOf(Form1.idAtual);
            if (indiceAtual > 0)
            {
                if (Form1._soundOut != null)
                {
                    await Form1.FinalizarMusica();
                }
                Form1.idAtual = (int)Form1.filaAtual[indiceAtual - 1];
                PlayMusica();
                return true;
            }
        } catch (Exception e){
            MessageBox.Show($"Erro ao voltar uma musica: {e.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        return false;
    }
    private void MostrarMusica(){
        Referencias.PicDefinirCorDeFundo(Form1.musicaAtual.getImgMusica(), picImgMusica);
        Referencias.PicArredondarBordas(picImgMusica, 10, 10, 10, 10);
        picImgMusica.Image = Form1.musicaAtual.getImgMusica();
        lblNomeMusica.Text = Form1.musicaAtual.getNomeMusica();
        lblNomeArtista.Text = Form1.musicaAtual.getNomeArtistaMusica();
        lblDuracaoFinal.Text = TimeSpan.FromSeconds(Math.Round(Form1._audioSource.GetLength().TotalSeconds)).ToString(@"mm\:ss");
    }
    private void ToggleSilenciar(object sender, EventArgs e){
        if (Form1._volumeSource != null)
        {
            if(Form1._volumeSource.Volume != 0){
                Form1._volumeSource.Volume = 0;
                sldVolume.Habilitado = false;
                picSoundMusic.Image = Properties.Resources.Mudo;
            } else {
                Form1._volumeSource.Volume = formularioPai.VolumeNvl;
                sldVolume.Habilitado = true;
                DefinirImageVolume(sldVolume.Value);
            }
        }
    }
    private void DefinirImageVolume(int Volume){
        if(Volume <= 0){
            picSoundMusic.Image = Properties.Resources.Mudo;
        } else
        if(Volume >= 1 && Volume <= 33){
            picSoundMusic.Image = Properties.Resources.Volume1;
        } else
        if(Volume >= 34 && Volume <= 66){
            picSoundMusic.Image = Properties.Resources.Volume2;
        } else
        if(Volume >= 67 && Volume <= 100){
            picSoundMusic.Image = Properties.Resources.Volume3;
        }
    }
    private void AdiantarMusica(object sender, EventArgs e){
        Form1.MudarTempoMusica((int)Form1._audioSource.GetPosition().TotalSeconds + 10);
    }
    private void AtrasarMusica(object sender, EventArgs e){
        Form1.MudarTempoMusica((int)Form1._audioSource.GetPosition().TotalSeconds - 10);
    }
    private void VolumeSlider(object sender, EventArgs e){
        formularioPai.VolumeNvl = (float)sldVolume.Value / 100;
        if (Form1._volumeSource != null)
        {
            Form1._volumeSource.Volume = formularioPai.VolumeNvl; // Ajusta o volume em tempo real
        }

        DefinirImageVolume(sldVolume.Value);
    }
    private void TimelineSlider(object sender, EventArgs e){
        Form1.MudarTempoMusica(sldTimelineMusic.Value);
    }
    
}