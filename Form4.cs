namespace Jasper;
using System;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using CSCore;
using CSCore.SoundOut;

public partial class Form4 : Form
{
    private Form1 formularioPai;
    private NotifyIcon notifyIcon;
    private SynchronizationContext _syncContext;
    public Form4()
    {
        InitializeComponent();
        _syncContext = SynchronizationContext.Current;

        this.Load += (s,e) => AoCarregar();
        DefinirGatilhos();
        this.TopMost = true;
        
        titleBarPersonalizada1.MinimizarCustom += (s, e) => MandarParaBandeja();

        Form1.musicaTrocada += (s, e) => MostrarMusica();
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
        MostrarMusica();
        formularioPai = (Form1)this.Owner;

        formularioPai.RepetirNvl = Form1.ToogleSituacao(formularioPai.RepetirNvl -1, picBtnRepetirMusic, "Repetir"); 
        formularioPai.AleatorioNvl = Form1.ToogleSituacao(formularioPai.AleatorioNvl -1, picBtnAleatorioMusic, "Aleatorizar");

        if(Form1.isPlaying){picBtnPlayMusic.Image = Properties.Resources.Pausar;}
        else {picBtnPlayMusic.Image = Properties.Resources.Play;} 
        
        _syncContext.Post(_ =>
        {
            sldTimelineMusic.Maximum = (int)Math.Round(Form1._audioSource.GetLength().TotalSeconds);
        }, null);

        sldVolume.Value = (int)(formularioPai.VolumeNvl * 100);
        DefinirImageVolume(sldVolume.Value);

        Playlists ply = new Playlists(Form1._playlistAtual);
        LblPosicionarCorretamente(string.IsNullOrEmpty(ply.getNomePlaylist()) ? "Todas" : ply.getNomePlaylist(), lblNomePlaylist);
        lblPlaylist.Location = new Point(lblNomePlaylist.Location.X - lblPlaylist.Size.Width, lblPlaylist.Location.Y);
    }
    private void DefinirGatilhos(){
        picBtnPlayMusic.Click += (s, e) => PlayMusic();
        picBtnNextMusic.Click += (s, e) => Form1.MusicNext();
        picBtnPrevMusic.Click += (s, e) => Form1.MusicPrev();
        picSoundMusic.Click += (s, e) => Form1.ToggleMute();

        picBtnAvancarMusic.Click += (s, e) => Form1.MusicAdiantar();
        picBtnRetroMusic.Click += (s, e) => Form1.MusicAtrasar();
        
        sldVolume.ValueMouseChanged += VolumeSlider;
        sldTimelineMusic.ValueMouseChanged += TimelineSlider;

        picBtnRepetirMusic.Click += (s,e) =>{formularioPai.RepetirNvl = Form1.ToogleSituacao(formularioPai.RepetirNvl, picBtnRepetirMusic, "Repetir");};

        picBtnAleatorioMusic.Click += (s, e) => {formularioPai.AleatorioNvl = Form1.ToogleSituacao(formularioPai.AleatorioNvl, picBtnAleatorioMusic, "Aleatorizar");};
    }
    private void PlayMusic(){
        Form1.TogglePlay(); 
        TempWhileMusic(); 
        
        if(Form1.isPlaying){picBtnPlayMusic.Image = Properties.Resources.Pausar;}
        else {picBtnPlayMusic.Image = Properties.Resources.Play;} 
    }
    private void LblPosicionarCorretamente(string novoTexto, Label textToEdit)
    {
        int antigaLargura = textToEdit.Width;
        textToEdit.Text = novoTexto;

        int novaLargura = textToEdit.Width;
        int deslocamento = novaLargura - antigaLargura;

        textToEdit.Left -= deslocamento;
    }
    private void TempWhileMusic(){
        Form1.timerWhileMusic?.Dispose();
        Form1.timerWhileMusic = new System.Threading.Timer(WhileMusic, null, 0, 500);
    }
    private async void WhileMusic(object state)
    {
        if (Form1._soundOut != null)
        {
            if (Form1._audioSource.GetPosition().TotalSeconds >= Form1._audioSource.GetLength().TotalSeconds - 0.5f)
            {
                Form1.MusicNext();
                return;
            } else 
            if (Form1._soundOut.PlaybackState == PlaybackState.Playing)
            {
                sldTimelineMusic.Value = (int)Form1._audioSource.GetPosition().TotalSeconds;
                _syncContext.Post(_ =>
                {
                    lblTimeMusic.Text = TimeSpan.FromSeconds(Math.Round(Form1._audioSource.GetPosition().TotalSeconds)).ToString(@"mm\:ss");
                }, null);
            }
            else
            {
                Form1.timerWhileMusic?.Dispose();
            }
        }
    }
    private void MostrarMusica(){
        _syncContext.Post(_ =>
        {
            Referencias.PicDefinirCorDeFundo(Form1.musicaAtual.getImgMusica(), picImgMusica);
            Referencias.PicArredondarBordas(picImgMusica, 10, 10, 10, 10);
            picImgMusica.Image = Form1.musicaAtual.getImgMusica();
            lblNomeMusica.Text = Form1.musicaAtual.getNomeMusica();
            lblNomeArtista.Text = Form1.musicaAtual.getNomeArtistaMusica();
            lblAllTimeMusic.Text =  TimeSpan.FromSeconds(Math.Round(Form1._audioSource.GetLength().TotalSeconds)).ToString(@"mm\:ss");

            TempWhileMusic();
        }, null);
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