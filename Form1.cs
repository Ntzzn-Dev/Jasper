namespace Jasper;

using System.Collections;
using System.Windows.Forms.VisualStyles;
using CSCore;
using CSCore.Codecs;
using CSCore.SoundOut;
using CSCore.Streams;
using Jasper.NthControls;
using YoutubeExplode;
using YoutubeExplode.Playlists;
using YoutubeExplode.Videos.Streams;

public partial class Form1 : Form
{
    private ISoundOut _soundOut;
    private IWaveSource _audioSource;
    private VolumeSource _volumeSource;
    private System.Threading.Timer _timer;
    private bool _isPlaying = false;
    private Musicas musicaAtual;
    private int idAtual = 1;
    private int playlistAtual = 0, vendoPlaylist = 0;
    private float volume = 1;
    private ArrayList ids = new ArrayList();
    private bool _finalizandoMusica = false;
    private bool playlistsOcultas = true;
    private int repetir = 0;
    private int aleatorio = 0;
    private List<int> aleatorioSemRepeticao = new List<int>();
    private FlowLayoutPanel flwpnlPlaylistsAdicionar;
    private int flwpnlPlaylistsHeight;
    string tempFilePath;
    private List<Control> controlesPermitidos = new List<Control>();
    public Form1()
    {
        InitializeComponent();
        DefinirGatilhos();
        PegarIds();
        musicaAtual = new Musicas(idAtual);
        
        volume = (float)sldVolumeMusic.Value / 100;
        MusicaAtual();
        OnFlowPanel(playlistAtual);

        AppDomain.CurrentDomain.UnhandledException += (sender, args) =>
        {
            Exception ex = (Exception)args.ExceptionObject;
            MessageBox.Show($"Erro não tratado: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        };

        Application.ThreadException += (sender, args) =>
        {
            MessageBox.Show($"Erro de thread: {args.Exception.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        };

        Referencias.PicArredondarBordas(picImgMusic, 30, 30, 30, 30);

        ListarPlaylists();
        lblPlaylistAtual.Text = "Todas";
    }
    private void AoCarregar(){
        PegarIds(); 
        OnFlowPanel(playlistAtual); 
        ListarPlaylists();
    }

    private void OnFlowPanel(int idPlaylist){
        foreach (Control control in flwpnlListMusic.Controls) { control.Dispose(); }
        flwpnlListMusic.Controls.Clear();

        List<Musicas> mscs = Musicas.ConsultarMusicas(idPlaylist);
        //if(!mscs.Contains(musicaAtual)){musicaAtual = mscs[0];}

        foreach(Musicas msc in mscs){
            LabelCRUD lbl = new LabelCRUD(){
                Texto = msc.getNomeMusica(),
                Id = msc.getIdMusica(),
                ImgPrincipal = msc.getImgMusica(),
                Size = new Size(flwpnlListMusic.Size.Width - 6, 56),
                Name = "lblCrud>" + msc.getIdMusica(),
                CorBackGround = Color.FromArgb(44, 44, 44),
                CorFontBackGround = Color.Silver
            };
            lbl.ImgPrincipalClick += SelecionarMusicaClick;
            lbl.LabelClick += SelecionarMusicaClick;
            lbl.Click += SelecionarMusicaClick;
            lbl.ImgEditarClick += EditarMusicaClick;
            lbl.ImgDeletarClick += DeletarMusicaClick;
            lbl.ImgExpandirClick += AdicionarAPlaylistMusicaClick;

            flwpnlListMusic.Controls.Add(lbl);
        }

        LabelCRUD lblAtual = FindControlByName(flwpnlListMusic, "lblCrud>" + musicaAtual.getIdMusica());
        if(lblAtual != null && vendoPlaylist == playlistAtual){
            lblAtual.CorBackGround = Color.FromArgb(36, 40, 81);
        }

        PegarIds();
        MusicaAtual();
    }
    private void SelecionarMusicaClick(object sender, EventArgs e){
        LabelCRUD lblClicado = sender as LabelCRUD;
        SelecionarMusica(lblClicado);
        if(vendoPlaylist != playlistAtual)
        {
            playlistAtual = vendoPlaylist; 
            PegarIds(); 
            Playlists ply = new Playlists(playlistAtual);
            lblPlaylistAtual.Text = string.IsNullOrEmpty(ply.getNomePlaylist()) ? "Todas" : ply.getNomePlaylist();
            TrocarMusica();
        }
    }
    private void EditarMusicaClick(object sender, EventArgs e){
        LabelCRUD lblClicado = sender as LabelCRUD;
        EditarMusica(lblClicado);
    }
    private void DeletarMusicaClick(object sender, EventArgs e){
        LabelCRUD lblClicado = sender as LabelCRUD;
        DeletarMusica(lblClicado);
    }
    private void AdicionarAPlaylistMusicaClick(object sender, EventArgs e){
        LabelCRUD lblClicado = sender as LabelCRUD;
        if(vendoPlaylist != 0){
            Playlists.TirarMusica(vendoPlaylist, lblClicado.Id); 
            if(vendoPlaylist == playlistAtual){
                NextMusic(); 
            }
            OnFlowPanel(vendoPlaylist);
            PegarIds();
        }
        else {AdicionarAPlaylistMusica(lblClicado);}
    }
    private void SalvarNaPlaylistClick(object sender, EventArgs e){
        LabelCRUD lblClicado = sender as LabelCRUD;

        int idMusica = int.Parse(lblClicado.Name.Split(">")[1]);
        Playlists.SalvarMusica(lblClicado.Id, idMusica);

        flwpnlPlaylistsTransition.Start();
    }
    private async Task SelecionarMusica(LabelCRUD lblClicado){
        if(idAtual != lblClicado.Id){
            if (_soundOut != null)
            {
                await finalizarMusica();
            }
            idAtual = lblClicado.Id;
            PlayPauseButton_Click();
        }
    }
    private async Task EditarMusica(LabelCRUD lblClicado){
        Musicas msc = new Musicas(lblClicado.Id);

        Form2 telaCadastro = new Form2(msc);
        telaCadastro.FormClosed += (s, e) => AoCarregar();
        telaCadastro.Owner = this;
        telaCadastro.Show();
    
        if(idAtual == lblClicado.Id){
            if (_soundOut != null)
            {
                await finalizarMusica();
            }
        }
    }
    private async Task DeletarMusica(LabelCRUD lblClicado){
        Musicas.Deletar(lblClicado.Id);
        if(idAtual == lblClicado.Id){
            if (_soundOut != null)
            {
                await finalizarMusica();
            }
            if (!(await NextMusic())){
                await PrevMusic();
            }
        }
        OnFlowPanel(playlistAtual);
        PegarIds();
    }
    private async Task AdicionarAPlaylistMusica(LabelCRUD lblClicado){
        if(flwpnlPlaylistsAdicionar != null){
            flwpnlPlaylistsTransition.Start();
            return;
        }

        flwpnlPlaylistsAdicionar = new FlowLayoutPanel(){
            Size = new Size(flwpnlListMusic.Size.Width, 0),
            Location = new Point(flwpnlListMusic.Location.X, this.Size.Height),
            Name = "flwpnlPlaylistsAdicionar",
            Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right,
            AutoScroll = true,
            AutoSize = true,
            BackColor = Color.FromArgb(7, 12, 26)
        };
        
        this.Controls.Add(flwpnlPlaylistsAdicionar);

        flwpnlPlaylistsAdicionar.BringToFront();
        pnlControlMusic.BringToFront();

        List<Playlists> plys = Playlists.ConsultarPlaylists();
        foreach(Playlists ply in plys){
            LabelCRUD lblPly = new LabelCRUD(){
                Texto = ply.getNomePlaylist(),
                Id = ply.getIdPlaylist(),
                ImgPrincipal = ply.getImgPlaylist(),
                Size = new Size(flwpnlPlaylistsAdicionar.Size.Width - 6, 56),
                Name = "lblCrud>" + lblClicado.Id,
                WithEdit = false,
                WithDelete = false,
                CorBackGround = Color.FromArgb(44, 44, 44),
                CorFontBackGround = Color.Silver
            };
            lblPly.ImgPrincipalClick += SalvarNaPlaylistClick;
            lblPly.LabelClick += SalvarNaPlaylistClick;
            lblPly.Click += SalvarNaPlaylistClick;

            flwpnlPlaylistsAdicionar.Controls.Add(lblPly);
        }

        foreach(Control control in flwpnlPlaylistsAdicionar.Controls){
            controlesPermitidos.Add(control);
        }
        controlesPermitidos.Add(flwpnlPlaylistsAdicionar);

        BtnAlternarAppsOcultos();
    }
    private void TransicaoPlaylistsAbrir(object sender, EventArgs e)
    {
        if (playlistsOcultas)
        {
            flwpnlPlaylistsHeight += 25;
            flwpnlPlaylistsAdicionar.Location = new Point(flwpnlListMusic.Location.X, pnlControlMusic.Location.Y - flwpnlPlaylistsHeight);
            flwpnlPlaylistsAdicionar.Size = new Size(flwpnlListMusic.Size.Width, flwpnlPlaylistsHeight);
            if (flwpnlPlaylistsAdicionar.Location.Y <= pnlControlMusic.Location.Y - 500)
            {
                flwpnlPlaylistsAdicionar.Location = new Point(flwpnlListMusic.Location.X, pnlControlMusic.Location.Y - 500);
                flwpnlPlaylistsAdicionar.Size = new Size(flwpnlListMusic.Size.Width, 500);
                playlistsOcultas = false;
                DetectarClique(true);
                flwpnlPlaylistsTransition.Stop();
            }
        }
        else
        {
            flwpnlPlaylistsHeight -= 25;
            flwpnlPlaylistsAdicionar.Location = new Point(flwpnlListMusic.Location.X, pnlControlMusic.Location.Y - flwpnlPlaylistsHeight);
            flwpnlPlaylistsAdicionar.Size = new Size(flwpnlListMusic.Size.Width, flwpnlPlaylistsHeight);
            if (flwpnlPlaylistsAdicionar.Location.Y > pnlControlMusic.Location.Y)
            {
                flwpnlPlaylistsAdicionar.Location = new Point(flwpnlListMusic.Location.X, pnlControlMusic.Location.Y);
                flwpnlPlaylistsAdicionar.Size = new Size(flwpnlListMusic.Size.Width, 0);
                playlistsOcultas = true;

                DetectarClique(false);
                flwpnlPlaylistsAdicionar.Dispose();
                this.Controls.Remove(flwpnlPlaylistsAdicionar);
                flwpnlPlaylistsAdicionar = null;
                
                flwpnlPlaylistsTransition.Stop();
            }
        }
    }
    private void BtnAlternarAppsOcultos()
    {
        flwpnlPlaylistsTransition.Start();
    }
    private void DetectarClique(bool detectar){
        if(detectar){
            foreach (Control ctrl in this.Controls)
            {
                ctrl.MouseDown += new MouseEventHandler(ClicarForaDasPlaylists);
            }
        }
        else {
            foreach (Control ctrl in this.Controls)
            {
                ctrl.MouseDown -= new MouseEventHandler(ClicarForaDasPlaylists);
            }
        }
    }
    private void ClicarForaDasPlaylists(object sender, MouseEventArgs e)
    {
        Control ctrl = sender as Control;
        //MessageBox.Show($"Clique detectado em ({e.X}, {e.Y}) dentro do controle: {sender.GetType().Name}");
        if (!controlesPermitidos.Contains(ctrl)){
            flwpnlPlaylistsTransition.Start();
        }
    }
    private void ListarPlaylists(){
        foreach (Control control in flwpnlPlaylists.Controls) { control.Dispose(); }
        flwpnlPlaylists.Controls.Clear();

        List<Playlists> plys = Playlists.ConsultarPlaylists();
        foreach(Playlists ply in plys){
            LabelCRUD lblPly = new LabelCRUD(){
                Texto = ply.getNomePlaylist(),
                Id = ply.getIdPlaylist(),
                ImgPrincipal = ply.getImgPlaylist(),
                Margin = new Padding(0, 3, 0, 0),
                Size = new Size(flwpnlPlaylists.Size.Width, 56),
                Name = "lblCrud>" + ply.getIdPlaylist(),
                WithExpand = false,
                CorBackGround = Color.FromArgb(44, 44, 44),
                CorFontBackGround = Color.Silver
            };
            lblPly.ImgPrincipalClick += (s, e) => DefinirPlaylist(ply.getIdPlaylist());
            lblPly.LabelClick += (s, e) => DefinirPlaylist(ply.getIdPlaylist());
            lblPly.Click += (s, e) => DefinirPlaylist(ply.getIdPlaylist());
            lblPly.ImgEditarClick += EditarPlaylist;
            lblPly.ImgDeletarClick += DeletarPlaylist;

            flwpnlPlaylists.Controls.Add(lblPly);
        }
    }
    private void EditarPlaylist(object sender, EventArgs e){
        LabelCRUD lblClicado = sender as LabelCRUD;
        Playlists ply = new Playlists(lblClicado.Id);

        Form2 telaCadastro = new Form2(ply);
        telaCadastro.FormClosed += (s, e) => AoCarregar();
        telaCadastro.Owner = this;
        telaCadastro.Show();
    }
    private void DeletarPlaylist(object sender, EventArgs e){
        LabelCRUD lblClicado = sender as LabelCRUD;
        Playlists.Deletar(lblClicado.Id);
        ListarPlaylists();
    }
    private void DefinirPlaylist(int idPly){
        vendoPlaylist = idPly;
        OnFlowPanel(idPly);
    }
    LabelCRUD FindControlByName(FlowLayoutPanel panel, string controlName)
    {
        foreach (LabelCRUD control in panel.Controls)
        {
            if (control.Name.Equals(controlName, StringComparison.OrdinalIgnoreCase))
            {
                return control;
            }
        }
        return null;
    }
    private void DefinirGatilhos(){
        picBtnAdicionarMusic.Click += AbrirCadastro;
        picBtnPlayMusic.Click += (s, e) => PlayPauseButton_Click();
        picBtnNextMusic.Click += (s, e) => NextMusic();
        picBtnPrevMusic.Click += (s, e) => PrevMusic();
        picSoundMusic.Click += ToggleSilenciar;

        picBtnAvancarMusic.Click += AdiantarMusica;
        picBtnRetroMusic.Click += AtrasarMusica;

        sldVolumeMusic.ValueMouseChanged += VolumeSlider;
        sldTimelineMusic.ValueMouseChanged += TimelineSlider;

        lblCRUDTodasMusicas.ImgPrincipalClick += (s, e) => DefinirPlaylist(0);
        lblCRUDTodasMusicas.LabelClick += (s, e) => DefinirPlaylist(0);
        lblCRUDTodasMusicas.Click += (s, e) => DefinirPlaylist(0);

        picBtnAleatorioMusic.Click += (s,e) =>{
            switch(aleatorio){
                case 0:
                    aleatorio = 1;
                    picBtnAleatorioMusic.Image = Image.FromFile(Referencias.caminhoImgRandom);
                    break;
                case 1:
                    aleatorio = 2;
                    picBtnAleatorioMusic.Image = Image.FromFile(Referencias.caminhoImgRandom1);
                    break;
                case 2:
                    aleatorio = 0;
                    picBtnAleatorioMusic.Image = Image.FromFile(Referencias.caminhoImgRandomD);
                    break;
            }
        };

        picBtnRepetirMusic.Click += (s, e) => {
            switch(repetir){
                case 0:
                    repetir = 1;
                    picBtnRepetirMusic.Image = Image.FromFile(Referencias.caminhoImgRepeat);
                    break;
                case 1:
                    repetir = 2;
                    picBtnRepetirMusic.Image = Image.FromFile(Referencias.caminhoImgRepeat1);
                    break;
                case 2:
                    repetir = 0;
                    picBtnRepetirMusic.Image = Image.FromFile(Referencias.caminhoImgRepeatD);
                    break;
            }
        };
    }
    private async void MusicaAtual(){
        try{
            if (!File.Exists(tempFilePath)) { await CriacaoAudio(); }
            if (_soundOut == null)
            {
                InitializeAudio();
            }
            Referencias.PicDefinirCorDeFundo(musicaAtual.getImgMusica(), picImgMusic);
            picImgMusic.Image = musicaAtual.getImgMusica();
            lblNomeMusic.Text = musicaAtual.getNomeMusica();
            lblArtistaMusic.Text = musicaAtual.getNomeArtistaMusica();
            lblDuracaoMusic.Text = TimeSpan.FromSeconds(Math.Round(_audioSource.GetLength().TotalSeconds)).ToString(@"mm\:ss");
        } catch (Exception e){
            MessageBox.Show($"Erro ao atualizar musica: {e.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
    private void VolumeSlider(object sender, EventArgs e){
        volume = (float)sldVolumeMusic.Value / 100;
        if (_volumeSource != null)
        {
            _volumeSource.Volume = volume; // Ajusta o volume em tempo real
        }

        DefinirImageVolume(sldVolumeMusic.Value);
    }
    private void DefinirImageVolume(int Volume){
        if(Volume <= 0){
            picSoundMusic.Image = Image.FromFile(Referencias.caminhoImgMudo);
        } else
        if(Volume >= 1 && Volume <= 33){
            picSoundMusic.Image = Image.FromFile(Referencias.caminhoImgVolume1);
        } else
        if(Volume >= 34 && Volume <= 66){
            picSoundMusic.Image = Image.FromFile(Referencias.caminhoImgVolume2);
        } else
        if(Volume >= 67 && Volume <= 100){
            picSoundMusic.Image = Image.FromFile(Referencias.caminhoImgVolume3);
        }
    }
    private void AbrirCadastro(object sender, EventArgs e){
        Form2 telaCadastro = new Form2();
        telaCadastro.FormClosed += (s, e) => AoCarregar();
        telaCadastro.Owner = this;
        telaCadastro.Show();
    }
    private void ToggleSilenciar(object sender, EventArgs e){
        if (_volumeSource != null)
        {
            if(_volumeSource.Volume != 0){
                _volumeSource.Volume = 0;
                sldVolumeMusic.Habilitado = false;
                picSoundMusic.Image = Image.FromFile(Referencias.caminhoImgMudo);
            } else {
                _volumeSource.Volume = volume;
                sldVolumeMusic.Habilitado = true;
                DefinirImageVolume(sldVolumeMusic.Value);
            }
        }
    }
    private void AdiantarMusica(object sender, EventArgs e){
        MudarPosicaoMusica((int)_audioSource.GetPosition().TotalSeconds + 10);
    }
    private void AtrasarMusica(object sender, EventArgs e){
        MudarPosicaoMusica((int)_audioSource.GetPosition().TotalSeconds - 10);
    }
    private void PegarIds(){
        ids.Clear();
        try
        {
            ids = Musicas.ConsultarIDs(playlistAtual);
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Erro ao listar ids: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        if (ids.Count > 0)
        {
            if (!ids.Contains(idAtual)) { idAtual = (int)ids[0]; }
        }
    }
    private async Task finalizarMusica(){
         if (_finalizandoMusica) return;
            _finalizandoMusica = true;
        try{
            tempFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Musicas", musicaAtual.getNomeMusica() + ".m4a");
            
            _isPlaying = false;
            if (_soundOut != null)
            {
                _soundOut.Stop();
                _soundOut.Dispose();
                _soundOut = null;
            }
            if (_audioSource != null)
            {
                _audioSource.Dispose();
                _audioSource = null;
            }

            if (File.Exists(tempFilePath))
            {
                File.Delete(tempFilePath);
            }
        } catch (Exception e){
            MessageBox.Show($"Erro ao finalizar nova musica: {e.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        finally
        {
            _finalizandoMusica = false;
        }
    }
    private async Task<bool> NextMusic(){
        try{
            int indiceAtual = ids.IndexOf(idAtual);
            int proximoIndice = indiceAtual + 1;

            int Randomic(int valorpadrao){
                Random random = new Random();
                if(aleatorio == 1){
                    return random.Next(1, ids.Count);
                } else
                if(aleatorio == 2){
                    if(aleatorioSemRepeticao.Count == 0){
                        aleatorioSemRepeticao = Enumerable.Range(0, ids.Count).ToList();
                    }
                    int indiceAleatorio = random.Next(aleatorioSemRepeticao.Count);
                    aleatorioSemRepeticao.RemoveAt(indiceAleatorio);
                    return aleatorioSemRepeticao[indiceAleatorio];
                }
                return valorpadrao;
            }
            
            if (indiceAtual < ids.Count - 1 && repetir != 2)
            {
                proximoIndice = Randomic(indiceAtual + 1);
                if (_soundOut != null)
                {
                    await finalizarMusica();
                }
                idAtual = (int)ids[proximoIndice];
                PlayPauseButton_Click();
                return true;
            } 

            if(repetir == 1 || aleatorio != 0){
                    proximoIndice = Randomic(0);
                    if (_soundOut != null)
                    {
                        await finalizarMusica();
                    }
                    idAtual = (int)ids[proximoIndice];
                    PlayPauseButton_Click();
                return true;
            }
            if(repetir == 2){
                    if (_soundOut != null)
                    {
                        await finalizarMusica();
                    }
                    PlayPauseButton_Click();
                return true;
            }

        } catch (Exception e){
            MessageBox.Show($"Erro ao passar uma musica: {e.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        return false;
    }
    private async Task<bool> PrevMusic(){
        try{
            int indiceAtual = ids.IndexOf(idAtual);
            if (indiceAtual > 0)
            {
                if (_soundOut != null)
                {
                    await finalizarMusica();
                }
                idAtual = (int)ids[indiceAtual - 1];
                PlayPauseButton_Click();
                return true;
            }
        } catch (Exception e){
            MessageBox.Show($"Erro ao voltar uma musica: {e.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        return false;
    }
    private async void PlayPauseButton_Click()
    {
        try{
            TrocarMusica();
            tempFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Musicas", musicaAtual.getNomeMusica() + ".m4a");
            if (!File.Exists(tempFilePath)) { await CriacaoAudio(); }
            
            if (_isPlaying)
            {
                // Pausar reprodução
                if (_soundOut != null)
                {
                    _soundOut.Pause();
                    _isPlaying = false;
                    picBtnPlayMusic.Image = Image.FromFile(Referencias.caminhoImgPlay);
                }
            }
            else
            {
                // Retomar ou iniciar reprodução
                if (_soundOut == null)
                {
                    InitializeAudio();
                } 
                if (_soundOut != null)
                {   
                    _soundOut.Play();
                    _timer?.Dispose();
                    _timer = new System.Threading.Timer(PerformActionWhileMusicPlays, null, 0, 500);    
                    sldTimelineMusic.Maximum = (int)Math.Round(_audioSource.GetLength().TotalSeconds);
                    _isPlaying = true;
                    picBtnPlayMusic.Image = Image.FromFile(Referencias.caminhoImgPause);
                }
            }
            MusicaAtual();
        } catch (Exception e){
            MessageBox.Show($"Erro ao iniciar nova musica: {e.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
    private void TrocarMusica(){
        LabelCRUD lblAtual = FindControlByName(flwpnlListMusic, "lblCrud>" + musicaAtual.getIdMusica());
        if (lblAtual != null && vendoPlaylist == playlistAtual) 
        {
            lblAtual.CorBackGround = Color.FromArgb(44, 44, 44);
        }
        musicaAtual = new Musicas(idAtual);
        lblAtual = FindControlByName(flwpnlListMusic, "lblCrud>" + musicaAtual.getIdMusica());
        if (lblAtual != null && vendoPlaylist == playlistAtual) 
        {
            lblAtual.CorBackGround = Color.FromArgb(36, 40, 81);
        }
    }
    private async void PerformActionWhileMusicPlays(object state)
    {
        if (_soundOut != null)
        {
            if (_audioSource.GetPosition().TotalSeconds >= _audioSource.GetLength().TotalSeconds - 0.5f)
            {
                await NextMusic();
                return;
            } else 
            if (_soundOut.PlaybackState == PlaybackState.Playing)
            {
                sldTimelineMusic.Value = (int)_audioSource.GetPosition().TotalSeconds;
            }
            else
            {
                _timer.Dispose();
                sldTimelineMusic.Value = 0;
            }
        }
    }
    private void MudarPosicaoMusica(int segundo)
    {
        _audioSource.Position = (long)(_audioSource.WaveFormat.SampleRate * segundo * _audioSource.WaveFormat.Channels * _audioSource.WaveFormat.BitsPerSample / 8);
    }
    private void TimelineSlider(object sender, EventArgs e){
        MudarPosicaoMusica(sldTimelineMusic.Value);
    }
    private async Task CriacaoAudio(){
        try{
            tempFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Musicas", musicaAtual.getNomeMusica() + ".m4a");
            string directoryPath = Path.GetDirectoryName(tempFilePath);
            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }
            if (!File.Exists(tempFilePath))
            {
                File.WriteAllBytes(tempFilePath, musicaAtual.getBytesMusica());
            }
        } catch (Exception e){
            MessageBox.Show($"Erro ao criar musica: {e.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
    private void InitializeAudio()
    {
        try{
            tempFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Musicas", musicaAtual.getNomeMusica() + ".m4a");

            _audioSource = CodecFactory.Instance.GetCodec(tempFilePath);

            _volumeSource = new VolumeSource(_audioSource.ToSampleSource())
            {
                Volume = volume // Valor entre 0.0f (mudo) e 1.0f (volume máximo)
            };

            _soundOut = new WasapiOut();
            _soundOut.Initialize(_volumeSource.ToWaveSource());
        } catch (Exception e){
            MessageBox.Show($"Erro ao iniciar novo audio: {e.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    protected override void OnFormClosing(FormClosingEventArgs e)
    {
        tempFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Musicas", musicaAtual.getNomeMusica() + ".m4a");
        if (_soundOut != null)
        {
            _soundOut?.Stop();
            _soundOut?.Dispose();
            _audioSource?.Dispose();
        }
        if (File.Exists(tempFilePath))
        {
            File.Delete(tempFilePath);
        }

        base.OnFormClosing(e);
    }
}
