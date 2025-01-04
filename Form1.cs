namespace Jasper;

using System.Collections;
using CSCore;
using CSCore.Codecs;
using CSCore.SoundOut;
using CSCore.Streams;
using Jasper.NthControls;

public partial class Form1 : Form
{
    // Audio --------------------------
    public static ISoundOut _soundOut;
    public static IWaveSource _audioSource;
    public static VolumeSource _volumeSource;
    private static float _volume = 1;
    public static string tempFilePath;
    // Musica -------------------------
    public static System.Threading.Timer timerWhileMusic;
    public static bool isPlaying = false, finalizandoMusica = false;
    public static Musicas musicaAtual;
    public static int idAtual = 1;
    public static ArrayList ids = new ArrayList();
    // Playlist -----------------------
    public static int playlistAtual = 0;
    private int vendoPlaylist = 0;
    private bool playlistsOcultas = true;
    private FlowLayoutPanel flwpnlPlaylistsAdicionar;
    private int flwpnlPlaylistsHeight;
    private List<Control> controlesPermitidos = new List<Control>();
    // Controles ----------------------
    private static int _repetir = 0;
    private static int _aleatorio = 0;
    // Getters and Setters ------------
    public float VolumeNvl{
        get => _volume;
        set{
            _volume = value;
            SldVolumeNivel(value, sldVolumeMusic);
        }
    }
    public int RepetirNvl {
        get => _repetir;
        set{
            _repetir = value;
            _repetir = ToogleSituacao(_repetir -1, picBtnRepetirMusic, "Repetir");    
        }
    }
    public int AleatorioNvl {
        get => _aleatorio;
        set{
            _aleatorio = value;
            _aleatorio = ToogleSituacao(_aleatorio -1, picBtnAleatorioMusic, "Aleatorizar");
        }
    }
    public static List<int> aleatorioSemRepeticao = new List<int>();

    public Form1()
    {
        InitializeComponent();
        this.Load += AoCarregar;
        

        //*Garantia
        AppDomain.CurrentDomain.UnhandledException += (sender, args) =>
        {
            Exception ex = (Exception)args.ExceptionObject;
            MessageBox.Show($"Erro não tratado: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        };

        Application.ThreadException += (sender, args) =>
        {
            MessageBox.Show($"Erro de thread: {args.Exception.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        };
        //*/
    }
    //Inicio --------------------------------------------------------------------------------------
    private void AoCarregar(object sender, EventArgs e){
        AoRecarregar();
        DefinirGatilhos();
        lblPlaylistAtual.Text = "Todas";
        Referencias.PicArredondarBordas(picImgMusic, 30, 30, 30, 30);
    }
    private void AoRecarregar(){
        PegarIds(); 
        musicaAtual = new Musicas(idAtual);
        
        VolumeNvl = (float)sldVolumeMusic.Value / 100;
        DefinirImageVolume(sldVolumeMusic.Value);
        ExibicaoMusicaAtual();
        FlowPanelPrincipalMusicas(playlistAtual);
        ListarPlaylists();
    }
    private void DefinirGatilhos(){
        picBtnAdicionarMusic.Click += AbrirCadastro;
        picBtnPlayMusic.Click += (s, e) => PlayMusica();
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

        picBtnRepetirMusic.Click += (s,e) =>{RepetirNvl = ToogleSituacao(RepetirNvl, picBtnRepetirMusic, "Repetir");};

        picBtnAleatorioMusic.Click += (s, e) => {AleatorioNvl = ToogleSituacao(AleatorioNvl, picBtnAleatorioMusic, "Aleatorizar");};

        picBtnEsconder.Click += (s, e) => {
            Form4 telaCadastro = new Form4();
            telaCadastro.Owner = this;
            telaCadastro.FormClosed += (s, e) => this.Show();
            this.Hide();
            telaCadastro.Show();
        };
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

    // Musicas Audio ------------------------------------------------------------------------------
    public static async Task CreateAudio(){
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
    public static void InitializeAudio()
    {
        try{
            tempFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Musicas", musicaAtual.getNomeMusica() + ".m4a");

            _audioSource = CodecFactory.Instance.GetCodec(tempFilePath);

            _volumeSource = new VolumeSource(_audioSource.ToSampleSource())
            {
                Volume = _volume
            };

            _soundOut = new WasapiOut();
            _soundOut.Initialize(_volumeSource.ToWaveSource());
        } catch (Exception e){
            MessageBox.Show($"Erro ao iniciar novo audio: {e.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
    private async void PlayMusica()
    {
        try{
            TrocarSelecaoMusica();
            tempFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Musicas", musicaAtual.getNomeMusica() + ".m4a");
            if (!File.Exists(tempFilePath)) { await CreateAudio(); }
            
            if (isPlaying)
            {
                // Pausar reprodução
                if (_soundOut != null)
                {
                    _soundOut.Pause();
                    isPlaying = false;
                    picBtnPlayMusic.Image = Properties.Resources.Play;
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
                    timerWhileMusic?.Dispose();
                    timerWhileMusic = new System.Threading.Timer(WhileMusic, null, 0, 500);    
                    sldTimelineMusic.Maximum = (int)Math.Round(_audioSource.GetLength().TotalSeconds);
                    isPlaying = true;
                    picBtnPlayMusic.Image = Properties.Resources.Pausar;
                }
            }
            ExibicaoMusicaAtual();
        } catch (Exception e){
            MessageBox.Show($"Erro ao iniciar nova musica: {e.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
    private async void WhileMusic(object state)
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
                timerWhileMusic.Dispose();
                sldTimelineMusic.Value = 0;
            }
        }
    }
    public static void MudarTempoMusica(int segundo)
    {
        _audioSource.Position = (long)(_audioSource.WaveFormat.SampleRate * segundo * _audioSource.WaveFormat.Channels * _audioSource.WaveFormat.BitsPerSample / 8);
    }
    private async Task<bool> NextMusic(){
        try{
            int indiceAtual = ids.IndexOf(idAtual);
            int proximoIndice = indiceAtual + 1;

            int Randomic(int valorpadrao){
                Random random = new Random();
                if(AleatorioNvl == 1){
                    return random.Next(1, ids.Count);
                } else
                if(AleatorioNvl == 2){
                    if(aleatorioSemRepeticao.Count == 0){
                        aleatorioSemRepeticao = Enumerable.Range(0, ids.Count).ToList();
                    }
                    int indiceAleatorio = random.Next(aleatorioSemRepeticao.Count);
                    var mscAleatoria = aleatorioSemRepeticao[indiceAleatorio];
                    aleatorioSemRepeticao.RemoveAt(indiceAleatorio);
                    return mscAleatoria;
                }
                return valorpadrao;
            }
            
            if (indiceAtual < ids.Count - 1 && RepetirNvl != 2)
            {
                proximoIndice = Randomic(indiceAtual + 1);
                if (_soundOut != null)
                {
                    await FinalizarMusica();
                }
                idAtual = (int)ids[proximoIndice];
                PlayMusica();
                return true;
            } 

            if(RepetirNvl == 1 || AleatorioNvl != 0){
                    proximoIndice = Randomic(0);
                    if (_soundOut != null)
                    {
                        await FinalizarMusica();
                    }
                    idAtual = (int)ids[proximoIndice];
                    PlayMusica();
                return true;
            }
            if(RepetirNvl == 2){
                    if (_soundOut != null)
                    {
                        await FinalizarMusica();
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
            int indiceAtual = ids.IndexOf(idAtual);
            if (indiceAtual > 0)
            {
                if (_soundOut != null)
                {
                    await FinalizarMusica();
                }
                idAtual = (int)ids[indiceAtual - 1];
                PlayMusica();
                return true;
            }
        } catch (Exception e){
            MessageBox.Show($"Erro ao voltar uma musica: {e.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        return false;
    }
    private void AdiantarMusica(object sender, EventArgs e){
        MudarTempoMusica((int)_audioSource.GetPosition().TotalSeconds + 10);
    }
    private void AtrasarMusica(object sender, EventArgs e){
        MudarTempoMusica((int)_audioSource.GetPosition().TotalSeconds - 10);
    }
    private void VolumeSlider(object sender, EventArgs e){
        VolumeNvl = (float)sldVolumeMusic.Value / 100;
        if (_volumeSource != null)
        {
            _volumeSource.Volume = VolumeNvl; // Ajusta o volume em tempo real
        }

        DefinirImageVolume(sldVolumeMusic.Value);
    }
    private void ToggleSilenciar(object sender, EventArgs e){
        if (_volumeSource != null)
        {
            if(_volumeSource.Volume != 0){
                _volumeSource.Volume = 0;
                sldVolumeMusic.Habilitado = false;
                picSoundMusic.Image = Properties.Resources.Mudo;
            } else {
                _volumeSource.Volume = VolumeNvl;
                sldVolumeMusic.Habilitado = true;
                DefinirImageVolume(sldVolumeMusic.Value);
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
    public static async Task FinalizarMusica(){
         if (finalizandoMusica) return;
            finalizandoMusica = true;
        try{
            tempFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Musicas", musicaAtual.getNomeMusica() + ".m4a");
            
            isPlaying = false;
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
            MessageBox.Show($"Erro ao finalizar musica: {e.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        finally
        {
            finalizandoMusica = false;
        }
    }

    // Musicas UI ---------------------------------------------------------------------------------
    private void TimelineSlider(object sender, EventArgs e){
        MudarTempoMusica(sldTimelineMusic.Value);
    }
    private void TrocarSelecaoMusica(){
        LabelCRUD lblAtual = FindControl(flwpnlListMusic, "lblCrud>" + musicaAtual.getIdMusica());
        if (lblAtual != null && vendoPlaylist == playlistAtual) 
        {
            lblAtual.CorBackGround = Color.FromArgb(44, 44, 44);
        }
        musicaAtual = new Musicas(idAtual);
        lblAtual = FindControl(flwpnlListMusic, "lblCrud>" + musicaAtual.getIdMusica());
        if (lblAtual != null && vendoPlaylist == playlistAtual) 
        {
            lblAtual.CorBackGround = Color.FromArgb(36, 40, 81);
        }
    }
    private void FlowPanelPrincipalMusicas(int idPlaylist){
        foreach (Control control in flwpnlListMusic.Controls) { control.Dispose(); }
        flwpnlListMusic.Controls.Clear();

        List<Musicas> mscs = Musicas.ConsultarMusicas(idPlaylist);

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
            lbl.ImgPrincipalClick += BtnSelecionarMusica;
            lbl.LabelClick += BtnSelecionarMusica;
            lbl.Click += BtnSelecionarMusica;
            lbl.ImgEditarClick += BtnEditarMusica;
            lbl.ImgDeletarClick += BtnDeletarMusica;
            lbl.ImgExpandirClick += BtnSalvarNaPlaylist;

            flwpnlListMusic.Controls.Add(lbl);
        }

        TrocarSelecaoMusica();
        PegarIds();
        ExibicaoMusicaAtual();
    }
    private async void ExibicaoMusicaAtual(){
        try{
            if (!File.Exists(tempFilePath)) { await CreateAudio(); }
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
            MessageBox.Show($"Erro ao exibir musica: {e.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
    private LabelCRUD FindControl(FlowLayoutPanel panel, string controlName)
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

    // Playlists UI -------------------------------------------------------------------------------
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
            lblPly.ImgEditarClick += BtnEditarPlaylist;
            lblPly.ImgDeletarClick += BtnDeletarPlaylist;

            flwpnlPlaylists.Controls.Add(lblPly);
        }
    }
    private void BtnEditarPlaylist(object sender, EventArgs e){
        LabelCRUD lblClicado = sender as LabelCRUD;
        Playlists ply = new Playlists(lblClicado.Id);

        Form2 telaCadastro = new Form2(ply);
        telaCadastro.FormClosed += (s, e) => AoRecarregar();
        telaCadastro.Owner = this;
        telaCadastro.Show();
    }
    private void BtnDeletarPlaylist(object sender, EventArgs e){
        LabelCRUD lblClicado = sender as LabelCRUD;
        Playlists.Deletar(lblClicado.Id);
        ListarPlaylists();
        if(vendoPlaylist == lblClicado.Id){
            vendoPlaylist = 0;
            FlowPanelPrincipalMusicas(vendoPlaylist);
        }
    }
    private void DefinirPlaylist(int idPly){
        vendoPlaylist = idPly;
        FlowPanelPrincipalMusicas(idPly);
    }
 
    // Botoes -------------------------------------------------------------------------------------
    private void BtnSelecionarMusica(object sender, EventArgs e){
        LabelCRUD lblClicado = sender as LabelCRUD;
        SelecionarMusica(lblClicado);
        if(vendoPlaylist != playlistAtual)
        {
            playlistAtual = vendoPlaylist; 
            PegarIds(); 
            Playlists ply = new Playlists(playlistAtual);
            lblPlaylistAtual.Text = string.IsNullOrEmpty(ply.getNomePlaylist()) ? "Todas" : ply.getNomePlaylist();
            TrocarSelecaoMusica();
        }
    }
    private void BtnEditarMusica(object sender, EventArgs e){
        LabelCRUD lblClicado = sender as LabelCRUD;
        EditarMusica(lblClicado);
    }
    private void BtnDeletarMusica(object sender, EventArgs e){
        LabelCRUD lblClicado = sender as LabelCRUD;
        DeletarMusica(lblClicado);
    }
    private void BtnSalvarNaPlaylist(object sender, EventArgs e){
        LabelCRUD lblClicado = sender as LabelCRUD;

        //Retirar da Playlist
        if(vendoPlaylist != 0){
            Playlists.TirarMusica(vendoPlaylist, lblClicado.Id); 
            if(vendoPlaylist == playlistAtual){
                NextMusic(); 
            }
            FlowPanelPrincipalMusicas(vendoPlaylist);
            PegarIds();
        }

        //Adicionar a Playlist
        else {SalvarNaPlaylist(lblClicado);}
    }
    private void BtnSalvarNessaPlaylist(object sender, EventArgs e){
        LabelCRUD lblClicado = sender as LabelCRUD;

        int idMusica = int.Parse(lblClicado.Name.Split(">")[1]);
        Playlists.SalvarMusica(lblClicado.Id, idMusica);

        flwpnlPlaylistsTransition.Start();
    }

    // Acoes --------------------------------------------------------------------------------------
    private async Task SelecionarMusica(LabelCRUD lblClicado){
        if(idAtual != lblClicado.Id){
            if (_soundOut != null)
            {
                await FinalizarMusica();
            }
            idAtual = lblClicado.Id;
            PlayMusica();
        }
    }
    private async Task EditarMusica(LabelCRUD lblClicado){
        Musicas msc = new Musicas(lblClicado.Id);

        Form2 telaCadastro = new Form2(msc);
        telaCadastro.FormClosed += (s, e) => AoRecarregar();
        telaCadastro.Owner = this;
        telaCadastro.Show();
    
        if(idAtual == lblClicado.Id){
            if (_soundOut != null)
            {
                await FinalizarMusica();
            }
        }
    }
    private async Task DeletarMusica(LabelCRUD lblClicado){
        Musicas.Deletar(lblClicado.Id);
        if(idAtual == lblClicado.Id){
            if (_soundOut != null)
            {
                await FinalizarMusica();
            }
            if (!(await NextMusic())){
                await PrevMusic();
            }
        }
        FlowPanelPrincipalMusicas(playlistAtual);
        PegarIds();
    }
    private async Task SalvarNaPlaylist(LabelCRUD lblClicado){
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
            lblPly.ImgPrincipalClick += BtnSalvarNessaPlaylist;
            lblPly.LabelClick += BtnSalvarNessaPlaylist;
            lblPly.Click += BtnSalvarNessaPlaylist;

            flwpnlPlaylistsAdicionar.Controls.Add(lblPly);
        }

        foreach(Control control in flwpnlPlaylistsAdicionar.Controls){
            controlesPermitidos.Add(control);
        }
        controlesPermitidos.Add(flwpnlPlaylistsAdicionar);

        TogglePlaylistsOcultas();
    }

    // Transicao - Salvar em uma Playlist ---------------------------------------------------------
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
                CriarDetectarCliqueFora(true);
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

                CriarDetectarCliqueFora(false);
                flwpnlPlaylistsAdicionar.Dispose();
                this.Controls.Remove(flwpnlPlaylistsAdicionar);
                flwpnlPlaylistsAdicionar = null;
                
                flwpnlPlaylistsTransition.Stop();
            }
        }
    }
    private void TogglePlaylistsOcultas()
    {
        flwpnlPlaylistsTransition.Start();
    }
    private void CriarDetectarCliqueFora(bool detectar){
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
        if (!controlesPermitidos.Contains(ctrl)){
            flwpnlPlaylistsTransition.Start();
        }
    }

    // Gerenciamento ------------------------------------------------------------------------------
    private void AbrirCadastro(object sender, EventArgs e){
        Form2 telaCadastro = new Form2();
        telaCadastro.FormClosed += (s, e) => AoRecarregar();
        telaCadastro.Owner = this;
        telaCadastro.Show();
    }
    public static int ToogleSituacao(int situacao, PictureBox picInUse, string palavraChave){
        
        switch(situacao){
                case -1:
                    picInUse.Image = (Bitmap)Properties.Resources.ResourceManager.GetObject(palavraChave + "Desabilitado");
                    return 0;
                case 0:
                    picInUse.Image = (Bitmap)Properties.Resources.ResourceManager.GetObject(palavraChave);
                    return 1;
                case 1:
                    picInUse.Image = (Bitmap)Properties.Resources.ResourceManager.GetObject(palavraChave + "1");
                    return 2;
                case 2:
                    picInUse.Image = (Bitmap)Properties.Resources.ResourceManager.GetObject(palavraChave + "Desabilitado");
                    return 0;
            }
        return -1;
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
    private static void SldVolumeNivel(float nvlvlm, Slider sld){
        sld.Value = (int)(nvlvlm * 100);
    }
}
