namespace Jasper;

using System.Collections;
using System.Runtime.InteropServices;
using CSCore;
using CSCore.Codecs;
using CSCore.SoundOut;
using CSCore.Streams;
using Jasper.NthControls;

public partial class Form1 : Form
{
    // Audio ==========================
    public static ISoundOut _soundOut;
    public static IWaveSource _audioSource;
    public static VolumeSource _volumeSource;
    private static float _volume = 1;
    public static string tempFilePath;
    private SynchronizationContext _syncContext;
    // Musica ====================
    public static System.Threading.Timer timerWhileMusic;
    public static bool isPlaying = false, finalizandoMusica = false;
    public static Musicas musicaAtual;
    public static int idAtual = 1;
    public List<int> filaAtual = new List<int>();
    // Playlist =======================
    private bool playlistsArtista, filaPersonalizada;
    public static int _playlistAtual = 0;
    private int vendoPlaylist = 0;
    private int tipoDeOrganizacaoPlaylist = 0;
    private bool playlistsOcultas = true;
    private FlowLayoutPanel flwpnlPlaylistsAdicionar;
    private Popup pop;
    private int flwpnlPlaylistsHeight;
    private List<Control> controlesPermitidos = new List<Control>();
    // Controles ======================
    private int _repetir = 0;
    private int _aleatorio = 0;
    public List<int> aleatorioSemRepeticao = new List<int>();
    // Getters and Setters ============
    public float VolumeNvl
    {
        get => _volume;
        set
        {
            _volume = value;
            SldVolumeNivel(value, sldVolumeMusic);
        }
    }
    public int RepetirNvl
    {
        get => _repetir;
        set
        {
            _repetir = value;
            _repetir = ToogleSituacao(_repetir - 1, picBtnRepetirMusic, "Repetir");
        }
    }
    public int AleatorioNvl
    {
        get => _aleatorio;
        set
        {
            _aleatorio = value;
            _aleatorio = ToogleSituacao(_aleatorio - 1, picBtnAleatorioMusic, "Aleatorizar");
        }
    }
    public int PlaylistAtual
    {
        get => _playlistAtual;
        set
        {
            _playlistAtual = value;
            FlowPanelPrincipalMusicas(_playlistAtual, true);
        }
    }
    // Eventos ========================
    public static event EventHandler musicaTrocada, musicNext, musicPrev, musicAdiantar, musicAtrasar, toogleMute;
    public static event EventHandler btnPlayPause;
    // Hotkeys e DLL ==================
    private const int WM_NCHITTEST = 0x84;
    private const int HTLEFT = 10;
    private const int HTRIGHT = 11;
    private const int HTTOP = 12;
    private const int HTTOPLEFT = 13;
    private const int HTTOPRIGHT = 14;
    private const int HTBOTTOM = 15;
    private const int HTBOTTOMLEFT = 16;
    private const int HTBOTTOMRIGHT = 17;
    private const int WM_HOTKEY = 0x0312;

    [DllImport("user32.dll")]
    private static extern bool RegisterHotKey(IntPtr hWnd, int id, uint fsModifiers, uint vk);
    [DllImport("user32.dll")]
    private static extern bool UnregisterHotKey(IntPtr hWnd, int id);

    public Form1()
    {
        InitializeComponent();
        _syncContext = SynchronizationContext.Current;
        this.Load += AoCarregar;

        // Teclas de atalho
        RegisterHotKey(this.Handle, 1, (uint)ModifierKeys.Control, (uint)Keys.NumPad8);                     //Pausar ou despausar
        RegisterHotKey(this.Handle, 2, (uint)ModifierKeys.Control, (uint)Keys.NumPad9);                     //Passar
        RegisterHotKey(this.Handle, 3, (uint)ModifierKeys.Control, (uint)Keys.NumPad7);                     //Mutar e desmutar
        RegisterHotKey(this.Handle, 4, (uint)ModifierKeys.Control | (uint)ModifierKeys.Alt , (uint)Keys.Q); //Fechar

        flwpnlListMusic.Resize += (s, e) => {
            foreach (LabelCRUD lblCrud in flwpnlListMusic.Controls)
            {
                lblCrud.Size = new Size(flwpnlListMusic.Width - 29, lblCrud.Height);
            }
        };

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
    [Flags]
    public enum ModifierKeys : uint
    {
        None = 0,
        Alt = 1,
        Control = 2,
        Shift = 4,
        Windows = 8
    }
    protected override void WndProc(ref Message m)
    {
        int gripSize = 8;
        if (m.Msg == WM_NCHITTEST)
        {
            base.WndProc(ref m);

            var cursor = this.PointToClient(Cursor.Position);

            if (cursor.X <= gripSize && cursor.Y <= gripSize)
                m.Result = (IntPtr)HTTOPLEFT;
            else if (cursor.X >= this.ClientSize.Width - gripSize && cursor.Y <= gripSize)
                m.Result = (IntPtr)HTTOPRIGHT;
            else if (cursor.X <= gripSize && cursor.Y >= this.ClientSize.Height - gripSize)
                m.Result = (IntPtr)HTBOTTOMLEFT;
            else if (cursor.X >= this.ClientSize.Width - gripSize && cursor.Y >= this.ClientSize.Height - gripSize)
                m.Result = (IntPtr)HTBOTTOMRIGHT;
            else if (cursor.X <= gripSize)
                m.Result = (IntPtr)HTLEFT;
            else if (cursor.X >= this.ClientSize.Width - gripSize)
                m.Result = (IntPtr)HTRIGHT;
            else if (cursor.Y <= gripSize)
                m.Result = (IntPtr)HTTOP;
            else if (cursor.Y >= this.ClientSize.Height - gripSize)
                m.Result = (IntPtr)HTBOTTOM;

            return;
        }
        else if (m.Msg == WM_HOTKEY)
        {
            int idDoAtalho = m.WParam.ToInt32();
            if (idDoAtalho == 1) {
                PlayMusica();
            } else 
            if (idDoAtalho == 2) {
                MusicNext();
            } else 
            if (idDoAtalho == 3) {
                ToggleMute();
            } else 
            if (idDoAtalho == 4) {
                Application.Exit();
            }
        }

        base.WndProc(ref m);
    }
    //Inicio --------------------------------------------------------------------------------------
    private void AoCarregar(object sender, EventArgs e)
    {
        AoRecarregar();
        DefinirGatilhos();
        lblPlaylistAtual.Text = "Todas";
        Referencias.PicArredondarBordas(picImgMusic, 30, 30, 30, 30);
    }
    private void AoRecarregar()
    {
        FlowPanelPrincipalMusicas(vendoPlaylist);
        if (filaAtual.Count > 0){
            musicaAtual = new Musicas(idAtual);

            VolumeNvl = (float)sldVolumeMusic.Value / 100;
            DefinirImageVolume(sldVolumeMusic.Value);
            ExibicaoMusicaAtual();
            if(dpdwListar.IdElemento == 0){
                ListarPlaylists();
                playlistsArtista = false;
            }
            if(dpdwListar.IdElemento == 1){
                ListarArtistas();
                playlistsArtista = true;
            }
        }
    }
    private void DefinirGatilhos()
    {
        picBtnAdicionarMusic.Click += (s, e) => AbrirCadastro();
        picBtnPlayMusic.Click += (s, e) => TogglePlay();
        picBtnNextMusic.Click += (s, e) => MusicNext();
        picBtnPrevMusic.Click += (s, e) => MusicPrev();
        picSoundMusic.Click += (s, e) => ToggleMute();

        picBtnAvancarMusic.Click += (s, e) => MusicAdiantar();
        picBtnRetroMusic.Click += (s, e) => MusicAtrasar();

        sldVolumeMusic.ValueMouseChanged += VolumeSlider;
        sldTimelineMusic.ValueMouseChanged += TimelineSlider;

        lblCRUDTodasMusicas.ImgPrincipalClick += (s, e) => DefinirPlaylist(0);
        lblCRUDTodasMusicas.LabelClick += (s, e) => DefinirPlaylist(0);
        lblCRUDTodasMusicas.Click += (s, e) => DefinirPlaylist(0);

        picBtnRepetirMusic.Click += (s, e) => { RepetirNvl = ToogleSituacao(RepetirNvl, picBtnRepetirMusic, "Repetir"); };

        picBtnAleatorioMusic.Click += (s, e) => { AleatorioNvl = ToogleSituacao(AleatorioNvl, picBtnAleatorioMusic, "Aleatorizar"); };

        picBtnEsconder.Click += (s, e) =>
        {
            Form4 telaCadastro = new Form4();
            telaCadastro.Owner = this;
            telaCadastro.FormClosed += (s, e) => this.Show();
            this.Hide();
            telaCadastro.Show();
        };
        
        dpdwListar.Escolheu += (s, e) => EscolhaDpdwListar();
        dpdwOrganizar.Escolheu += (s, e) => EscolhaDpdwOrganizar();
        picBtnVisualizarFila.Click += (s, e) => VisualizarFila();

        // Eventos
        musicNext += async (s,e) => await NextMusic();
        musicPrev += async (s,e) => await PrevMusic();
        musicAdiantar += (s,e) => AdiantarMusica();
        musicAtrasar += (s,e) => AtrasarMusica();
        toogleMute += (s,e) => ToggleSilenciar();

        btnPlayPause += (s, e) => PlayMusica();
    }

    // Eventos ------------------------------------------------------------------------------------
    public static void MusicNext()
    {
        musicNext?.Invoke(null, EventArgs.Empty);
    }
    public static void MusicPrev()
    {
        musicPrev?.Invoke(null, EventArgs.Empty);
    }
    public static void MusicAdiantar()
    {
        musicAdiantar?.Invoke(null, EventArgs.Empty);
    }
    public static void MusicAtrasar()
    {
        musicAtrasar?.Invoke(null, EventArgs.Empty);
    }
    public static void ToggleMute()
    {
        toogleMute?.Invoke(null, EventArgs.Empty);
    }
    public static void TogglePlay()
    {
        btnPlayPause?.Invoke(null, EventArgs.Empty);
    }

    // Musicas Audio ------------------------------------------------------------------------------
    public async Task CreateAudio()
    {
        try
        {
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
        }
        catch (Exception e)
        {
            MessageBox.Show($"Erro ao criar musica: {e.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
    public void InitializeAudio()
    {
        try
        {
            tempFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Musicas", musicaAtual.getNomeMusica() + ".m4a");

            _audioSource = CodecFactory.Instance.GetCodec(tempFilePath);

            _volumeSource = new VolumeSource(_audioSource.ToSampleSource())
            {
                Volume = _volume
            };

            _soundOut = new WasapiOut();
            _soundOut.Initialize(_volumeSource.ToWaveSource());
            
            musicaTrocada?.Invoke(this, EventArgs.Empty);
        }
        catch (Exception e)
        {
            MessageBox.Show($"Erro ao iniciar novo audio: {e.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
    private async void PlayMusica()
    {
        try
        {
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
                    timerWhileMusic?.Dispose();
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
        }
        catch (Exception e)
        {
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
            }
            else
            if (_soundOut.PlaybackState == PlaybackState.Playing)
            {
                AtualizarPosMusic();
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
    private async Task<bool> NextMusic()
    {
        try
        {
            int indiceAtual = filaAtual.IndexOf(idAtual);
            int proximoIndice = indiceAtual + 1;

            int Randomic(int valorpadrao)
            {
                Random random = new Random();
                if (AleatorioNvl == 1)
                {
                    return random.Next(1, filaAtual.Count);
                }
                else
                if (AleatorioNvl == 2)
                {
                    if (aleatorioSemRepeticao.Count == 0)
                    {
                        aleatorioSemRepeticao = Enumerable.Range(0, filaAtual.Count).ToList();
                    }
                    int indiceAleatorio = random.Next(aleatorioSemRepeticao.Count);
                    var mscAleatoria = aleatorioSemRepeticao[indiceAleatorio];
                    aleatorioSemRepeticao.RemoveAt(indiceAleatorio);
                    return mscAleatoria;
                }
                return valorpadrao;
            }

            if (indiceAtual < filaAtual.Count - 1 && RepetirNvl != 2)
            {
                proximoIndice = Randomic(indiceAtual + 1);
                if (_soundOut != null)
                {
                    await FinalizarMusica();
                }
                idAtual = (int)filaAtual[proximoIndice];
                PlayMusica();
                return true;
            }

            if (RepetirNvl == 1 || AleatorioNvl != 0)
            {
                proximoIndice = Randomic(0);
                if (_soundOut != null)
                {
                    await FinalizarMusica();
                }
                idAtual = (int)filaAtual[proximoIndice];
                PlayMusica();
                return true;
            }
            if (RepetirNvl == 2)
            {
                if (_soundOut != null)
                {
                    await FinalizarMusica();
                }
                PlayMusica();
                return true;
            }

        }
        catch (Exception e)
        {
            MessageBox.Show($"Erro ao passar uma musica: {e.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        return false;
    }
    private async Task<bool> PrevMusic()
    {
        try
        {
            int indiceAtual = filaAtual.IndexOf(idAtual);
            if (indiceAtual > 0)
            {
                if (_soundOut != null)
                {
                    await FinalizarMusica();
                }
                idAtual = (int)filaAtual[indiceAtual - 1];
                PlayMusica();
                return true;
            }
        }
        catch (Exception e)
        {
            MessageBox.Show($"Erro ao voltar uma musica: {e.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        return false;
    }
    private void AdiantarMusica()
    {
        MudarTempoMusica((int)_audioSource.GetPosition().TotalSeconds + 10);
        
        AtualizarPosMusic();
    }
    private void AtrasarMusica()
    {
        MudarTempoMusica((int)_audioSource.GetPosition().TotalSeconds - 10);

        AtualizarPosMusic();
    }
    private void VolumeSlider(object sender, EventArgs e)
    {
        VolumeNvl = (float)sldVolumeMusic.Value / 100;
        if (_volumeSource != null)
        {
            _volumeSource.Volume = VolumeNvl; // Ajusta o volume em tempo real
        }

        DefinirImageVolume(sldVolumeMusic.Value);
    }
    private void ToggleSilenciar()
    {
        if (_volumeSource != null)
        {
            if (_volumeSource.Volume != 0)
            {
                _volumeSource.Volume = 0;
                sldVolumeMusic.Habilitado = false;
                picSoundMusic.Image = Properties.Resources.Mudo;
            }
            else
            {
                _volumeSource.Volume = VolumeNvl;
                sldVolumeMusic.Habilitado = true;
                DefinirImageVolume(sldVolumeMusic.Value);
            }
        }
    }
    private void DefinirImageVolume(int Volume)
    {
        if (Volume <= 0)
        {
            picSoundMusic.Image = Properties.Resources.Mudo;
        }
        else
        if (Volume >= 1 && Volume <= 33)
        {
            picSoundMusic.Image = Properties.Resources.Volume1;
        }
        else
        if (Volume >= 34 && Volume <= 66)
        {
            picSoundMusic.Image = Properties.Resources.Volume2;
        }
        else
        if (Volume >= 67 && Volume <= 100)
        {
            picSoundMusic.Image = Properties.Resources.Volume3;
        }
    }
    public static async Task FinalizarMusica()
    {
        if (finalizandoMusica) return;
        finalizandoMusica = true;
        try
        {
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
        }
        catch (Exception e)
        {
            MessageBox.Show($"Erro ao finalizar musica: {e.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        finally
        {
            finalizandoMusica = false;
        }
    }
    private void AdicionarAFila(int idMusica){
        lblPlaylistAtual.Text = "Fila Personalizada";
        filaPersonalizada = true;
        LabelCRUD lblAtual = FindControl(flwpnlListMusic, "lblCrud>" + musicaAtual.getIdMusica());
        if (lblAtual != null)
        {
            lblAtual.CorBackGround = Color.FromArgb(44, 44, 44);
        }
        filaAtual.Add(idMusica);
    }

    // Musicas UI ---------------------------------------------------------------------------------
    private void TimelineSlider(object sender, EventArgs e)
    {
        MudarTempoMusica(sldTimelineMusic.Value);
    }
    private void TrocarSelecaoMusica()
    {
        LabelCRUD lblAtual = flwpnlListMusic.Controls.OfType<LabelCRUD>().FirstOrDefault(lbl => lbl.CorBackGround == Color.FromArgb(36, 40, 81));
        if (lblAtual != null && vendoPlaylist == _playlistAtual && filaPersonalizada == false)
        {
            lblAtual.CorBackGround = Color.FromArgb(44, 44, 44);
        }
        musicaAtual = new Musicas(idAtual);
        lblAtual = FindControl(flwpnlListMusic, "lblCrud>" + musicaAtual.getIdMusica());
        if (lblAtual != null && vendoPlaylist == _playlistAtual && filaPersonalizada == false)
        {
            lblAtual.CorBackGround = Color.FromArgb(36, 40, 81);
        }
    }
    private void FlowPanelPrincipalMusicas(int idPlaylist, bool apenasIds = false)
    {
        if(playlistsArtista){idPlaylist = idPlaylist * -1;}

        List<Musicas> mscs = Musicas.ConsultarMusicas(idPlaylist);

        switch(tipoDeOrganizacaoPlaylist){ // 0 = ordem de primeiro até ultimo
            case 1: //Ordem de ultimo até primeiro
                mscs.Reverse();
                break;
            case 2: //Nome A-Z
                mscs.Sort((a, b) => string.Compare(a.getNomeMusica(), b.getNomeMusica(), StringComparison.OrdinalIgnoreCase));
                break;
            case 3: //Nome Z-A
                mscs.Sort((a, b) => string.Compare(b.getNomeMusica(), a.getNomeMusica(), StringComparison.OrdinalIgnoreCase));
                break;
            case 4: //Nome artista A-Z
                mscs.Sort((a, b) => string.Compare(a.getNomeArtistaMusica(), b.getNomeArtistaMusica(), StringComparison.OrdinalIgnoreCase));
                break;
            case 5: //Nome artista Z-A
                mscs.Sort((a, b) => string.Compare(b.getNomeArtistaMusica(), a.getNomeArtistaMusica(), StringComparison.OrdinalIgnoreCase));
                break;
        }

        if(_playlistAtual == idPlaylist){
            filaAtual.Clear();
            filaAtual = mscs.Select(m => m.getIdMusica()).ToList();
            if (filaAtual.Count > 0)
            {
                if (!filaAtual.Contains(idAtual)) { idAtual = (int)filaAtual[0]; }
            }
            else 
            {
                AbrirCadastro();
            }
        }

        if(apenasIds || filaAtual.Count <= 0){return;}

        foreach (Control control in flwpnlListMusic.Controls) { control.Dispose(); }
        flwpnlListMusic.Controls.Clear();

        int tamanholbls = flwpnlListMusic.Size.Width - 6;
        if(mscs.Count > 8){
            tamanholbls -= 23;
        }
        foreach (Musicas msc in mscs)
        {
            LabelCRUD lbl = new LabelCRUD()
            {
                Anchor = AnchorStyles.Left | AnchorStyles.Right,
                Texto = msc.getNomeMusica(),
                Id = msc.getIdMusica(),
                ImgPrincipal = msc.getImgMusica(),
                Size = new Size(tamanholbls, 56),
                Name = "lblCrud>" + msc.getIdMusica(),
                CorBackGround = Color.FromArgb(44, 44, 44),
                CorFontBackGround = Color.Silver
            };
            lbl.ImgPrincipalClick += BtnSelecionarMusica;
            lbl.LabelClick += BtnSelecionarMusica;
            lbl.Click += BtnSelecionarMusica;
            lbl.ImgEditarClick += BtnEditarMusica;
            lbl.ImgDeletarClick += BtnDeletarMusica;
            lbl.ImgExpandirClick += PopupSalvarNaPlaylist;

            flwpnlListMusic.Controls.Add(lbl);
        }
        TrocarSelecaoMusica();
        ExibicaoMusicaAtual();
    }
    private async void ExibicaoMusicaAtual()
    {
        try
        {
            if (!File.Exists(tempFilePath)) { await CreateAudio(); }
            if (_soundOut == null)
            {
                InitializeAudio();
            }
            _syncContext.Post(_ =>
            {
                Referencias.PicDefinirCorDeFundo(musicaAtual.getImgMusica(), picImgMusic);
                picImgMusic.Image = musicaAtual.getImgMusica();
                lblNomeMusic.Text = musicaAtual.getNomeMusica();
                lblArtistaMusic.Text = musicaAtual.getNomeArtistaMusica();
                lblDuracaoMusic.Text = TimeSpan.FromSeconds(Math.Round(_audioSource.GetLength().TotalSeconds)).ToString(@"mm\:ss");
                lblAllTimeMusic.Text = TimeSpan.FromSeconds(Math.Round(_audioSource.GetLength().TotalSeconds)).ToString(@"mm\:ss");
            }, null);
        }
        catch (Exception e)
        {
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
    private void EscolhaDpdwOrganizar(){
        tipoDeOrganizacaoPlaylist = dpdwOrganizar.IdElemento;

        FlowPanelPrincipalMusicas(vendoPlaylist);
    }
    private void AtualizarPosMusic(){
        sldTimelineMusic.Value = (int)_audioSource.GetPosition().TotalSeconds;
        _syncContext.Post(_ =>
        {
            lblTimeMusic.Text = TimeSpan.FromSeconds(Math.Round(_audioSource.GetPosition().TotalSeconds)).ToString(@"mm\:ss");
        }, null);
    }

    // Playlists UI -------------------------------------------------------------------------------
    private void ListarArtistas()
    {
        foreach (Control control in flwpnlPlaylists.Controls) { control.Dispose(); }
        flwpnlPlaylists.Controls.Clear();

        List<Artistas> arts = Artistas.ConsultarArtistas();
        foreach (Artistas art in arts)
        {
            LabelCRUD lblArt = new LabelCRUD()
            {
                Texto = art.getNomeArtista(),
                Id = art.getIdArtista(),
                ImgPrincipal = art.getImgArtista(),
                Margin = new Padding(0, 3, 0, 0),
                Size = new Size(flwpnlPlaylists.Size.Width, 56),
                Name = "lblCrud>" + art.getIdArtista(),
                WithExpand = false,
                CorBackGround = Color.FromArgb(44, 44, 44),
                CorFontBackGround = Color.Silver
            };
            lblArt.ImgPrincipalClick += (s, e) => DefinirPlaylist(art.getIdArtista());
            lblArt.LabelClick += (s, e) => DefinirPlaylist(art.getIdArtista());
            lblArt.Click += (s, e) => DefinirPlaylist(art.getIdArtista());
            lblArt.ImgEditarClick += BtnEditarArtista;
            lblArt.ImgDeletarClick += BtnDeletarArtista;

            flwpnlPlaylists.Controls.Add(lblArt);
        }
    }
    private void ListarPlaylists()
    {
        foreach (Control control in flwpnlPlaylists.Controls) { control.Dispose(); }
        flwpnlPlaylists.Controls.Clear();

        List<Playlists> plys = Playlists.ConsultarPlaylists();
        foreach (Playlists ply in plys)
        {
            LabelCRUD lblPly = new LabelCRUD()
            {
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
    private void BtnEditarPlaylist(object sender, EventArgs e)
    {
        LabelCRUD lblClicado = sender as LabelCRUD;
        Playlists ply = new Playlists(lblClicado.Id);

        Form2 telaCadastro = new Form2(ply);
        telaCadastro.FormClosed += (s, e) => AoRecarregar();
        telaCadastro.Owner = this;
        telaCadastro.Show();
    }
    private void BtnDeletarPlaylist(object sender, EventArgs e)
    {
        LabelCRUD lblClicado = sender as LabelCRUD;
        Playlists.Deletar(lblClicado.Id);
        ListarPlaylists();
        if (vendoPlaylist == lblClicado.Id)
        {
            vendoPlaylist = 0;
            FlowPanelPrincipalMusicas(vendoPlaylist);
        }
    }
    private void BtnEditarArtista(object sender, EventArgs e)
    {
        LabelCRUD lblClicado = sender as LabelCRUD;
        Artistas art = new Artistas(lblClicado.Id);

        Form2 telaCadastro = new Form2(art);
        telaCadastro.FormClosed += (s, e) => AoRecarregar();
        telaCadastro.Owner = this;
        telaCadastro.Show();
    }
    private void BtnDeletarArtista(object sender, EventArgs e)
    {
        LabelCRUD lblClicado = sender as LabelCRUD;
        Artistas.Deletar(lblClicado.Id);
        ListarArtistas();
        if (vendoPlaylist == lblClicado.Id)
        {
            vendoPlaylist = 0;
            FlowPanelPrincipalMusicas(vendoPlaylist);
        }
    }
    private void DefinirPlaylist(int idPly)
    {
        vendoPlaylist = idPly;
        FlowPanelPrincipalMusicas(idPly);
    }
    private void EscolhaDpdwListar(){
        if(dpdwListar.IdElemento == 0){
            ListarPlaylists();
            playlistsArtista = false;
        }
        if(dpdwListar.IdElemento == 1){
            ListarArtistas();
            playlistsArtista = true;
        }
    }

    // Botoes -------------------------------------------------------------------------------------
    private void BtnSelecionarMusica(object sender, EventArgs e)
    {
        LabelCRUD lblClicado = sender as LabelCRUD;
        SelecionarMusica(lblClicado);
        if (vendoPlaylist != _playlistAtual && filaPersonalizada == false)
        {
            PlaylistAtual = vendoPlaylist;
            Playlists ply = new Playlists(_playlistAtual);
            lblPlaylistAtual.Text = string.IsNullOrEmpty(ply.getNomePlaylist()) ? "Todas" : ply.getNomePlaylist();
            TrocarSelecaoMusica();
        }
    }
    private void BtnEditarMusica(object sender, EventArgs e)
    {
        LabelCRUD lblClicado = sender as LabelCRUD;
        EditarMusica(lblClicado);
    }
    private void BtnDeletarMusica(object sender, EventArgs e)
    {
        LabelCRUD lblClicado = sender as LabelCRUD;
        DeletarMusica(lblClicado);
    }
    private void BtnSalvarNessaPlaylist(object sender, EventArgs e)
    {
        LabelCRUD lblClicado = sender as LabelCRUD;

        int idMusica = int.Parse(lblClicado.Name.Split(">")[1]);
        Playlists.SalvarMusica(lblClicado.Id, idMusica);

        flwpnlPlaylistsTransition.Start();
    }

    // Popup --------------------------------------------------------------------------------------
    private void PopupRetirarDaFila (object sender, EventArgs e){
        LabelCRUD lblClicado = sender as LabelCRUD;

        Boxes boxRetirarDaLista = new Boxes(){
            IdBox = 3,
            IdRepassar = lblClicado.Id,
            Imagem = Properties.Resources.AdicionarAPlaylist,
            Nome = "Retirar da lista"
        };
        List<Boxes> bxs = new List<Boxes>(){ boxRetirarDaLista };

        CriarPopup(bxs);
    }
    private void PopupSalvarNaPlaylist(object sender, EventArgs e)
    {
        LabelCRUD lblClicado = sender as LabelCRUD;

        Boxes boxAdicionarALista = new Boxes(){
            IdBox = 1,
            IdRepassar = lblClicado.Id,
            Imagem = Properties.Resources.AdicionarAFila,
            Nome = "Adicionar a fila"
        };
        List<Boxes> bxs = new List<Boxes>();
        bxs.Add(boxAdicionarALista);

        //Retirar da Playlist
        if (vendoPlaylist != 0)
        {
            Boxes boxRetirarDaPlaylist = new Boxes(){
                IdBox = 2,
                IdRepassar = lblClicado.Id,
                Imagem = Properties.Resources.Pausar,
                Nome = "Retirar da playlist"
            };
            bxs.Add(boxRetirarDaPlaylist);
        }

        //Adicionar a Playlist
        else {
            Boxes boxAdicionarAPlaylist = new Boxes(){
                IdBox = 0,
                IdRepassar = lblClicado.Id,
                Imagem = Properties.Resources.AdicionarAPlaylist,
                Nome = "Adicionar a playlist"
            };
            bxs.Add(boxAdicionarAPlaylist);
        }

        CriarPopup(bxs);
    }
    private void ReconhecerEscolhaPopup(object sender, EventArgs e){
        int botaoClicado = -1;
        int valorRepassado = -1;

        if (sender is Label label)
        {
            botaoClicado = int.Parse(label.Name.Split(">")[1]);
            valorRepassado = int.Parse(label.Name.Split(">")[2]);
        }
        else if(sender is PictureBox pic)
        {
            botaoClicado = int.Parse(pic.Name.Split(">")[1]);
            valorRepassado = int.Parse(pic.Name.Split(">")[2]);
        }

        if(botaoClicado == 0){SalvarNaPlaylist(valorRepassado); }
        if(botaoClicado == 1){AdicionarAFila(valorRepassado); }
        if(botaoClicado == 2){RetirarDaPlaylist(valorRepassado); }
        if(botaoClicado == 3){RetirarDaFila(valorRepassado); }

        CriarDetectarCliqueForaPopup(false);
        pop.Enabled = false;
        pop.Dispose();
        this.Controls.Remove(pop);
    }
    private void CriarPopup(List<Boxes> boxes){
        pop = new Popup(){
            ColorElementoPopup = Color.FromArgb(44, 44, 44),
            ColorPopup = Color.FromArgb(21, 22, 23),
            ColorTextPopup = Color.Silver,
            Location = this.PointToClient(Cursor.Position),
            Name = "popup1",
            Size = new Size(278, 170),
            SizePopup = new Size(0, 0),
            TabIndex = 0,
        };

        foreach(Boxes box in boxes){
            pop.ElementosPopup.Add(box);
        }

        this.Controls.Add(pop);
        pop.BringToFront();
        
        pop.BoxClicadoEvent += ReconhecerEscolhaPopup;

        controlesPermitidos = GetAllControls(pop);
        controlesPermitidos.Add(pop);

        CriarDetectarCliqueForaPopup(true);
    }

    // Acoes --------------------------------------------------------------------------------------
    private async Task SelecionarMusica(LabelCRUD lblClicado)
    {
        if (idAtual != lblClicado.Id)
        {
            if (_soundOut != null)
            {
                await FinalizarMusica();
            }
            idAtual = lblClicado.Id;
            PlayMusica();
        }
    }
    private async Task EditarMusica(LabelCRUD lblClicado)
    {
        Musicas msc = new Musicas(lblClicado.Id);

        Form2 telaCadastro = new Form2(msc);
        telaCadastro.FormClosed += (s, e) => AoRecarregar();
        telaCadastro.Owner = this;
        telaCadastro.Show();

        if (idAtual == lblClicado.Id)
        {
            if (_soundOut != null)
            {
                await FinalizarMusica();
            }
        }
    }
    private async Task DeletarMusica(LabelCRUD lblClicado)
    {
        Musicas.Deletar(lblClicado.Id);
        if (idAtual == lblClicado.Id)
        {
            if (_soundOut != null) {
                await FinalizarMusica();
            }
            if (!await NextMusic()) {
                await PrevMusic();
            }
        }
        //Recriar fila atual sem a musica deletada
        if(filaAtual.Contains(lblClicado.Id)){
            PlaylistAtual = _playlistAtual;
        }

        LabelCRUD lblDeletar = FindControl(flwpnlListMusic, "lblCrud>" + lblClicado.Id);
        flwpnlListMusic.Controls.Remove(lblDeletar);
    }
    private void SalvarNaPlaylist(int id)
    {
        if(flwpnlPlaylistsAdicionar != null){
            TogglePlaylistsOcultas(); return;
        }

        flwpnlPlaylistsAdicionar = new FlowLayoutPanel()
        {
            Size = new Size(pnlControlMusic.Size.Width, 500),
            Location = new Point(pnlControlMusic.Location.X, this.Size.Height),
            Name = "flwpnlPlaylistsAdicionar",
            Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right,
            AutoScroll = true,
            BackColor = Color.FromArgb(7, 12, 26)
        };

        titleWindow.Controls.Add(flwpnlPlaylistsAdicionar);

        flwpnlPlaylistsAdicionar.BringToFront();
        pnlControlMusic.BringToFront();

        List<Playlists> plys = Playlists.ConsultarPlaylists();
        int tamanholbls = flwpnlPlaylistsAdicionar.Size.Width - 6;
        if(plys.Count > 8){
            tamanholbls -= 23;
        }
        foreach (Playlists ply in plys)
        {
            LabelCRUD lblPly = new LabelCRUD()
            {
                Texto = ply.getNomePlaylist(),
                Id = ply.getIdPlaylist(),
                ImgPrincipal = ply.getImgPlaylist(),
                Size = new Size(tamanholbls, 56),
                Name = "lblCrud>" + id,
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

        controlesPermitidos = GetAllControls(flwpnlPlaylistsAdicionar);
        controlesPermitidos.Add(flwpnlPlaylistsAdicionar);

        TogglePlaylistsOcultas();
    }
    private async void RetirarDaPlaylist(int id){
        Playlists.TirarMusica(vendoPlaylist, id);
        if (vendoPlaylist == _playlistAtual)
        {
            if(!await NextMusic()) {
                await PrevMusic();
            }
        }

        if(filaAtual.Contains(id)){
            PlaylistAtual = _playlistAtual;
        }
        LabelCRUD lblDeletar = FindControl(flwpnlListMusic, "lblCrud>" + id);
        flwpnlListMusic.Controls.Remove(lblDeletar);
    }
    private async void RetirarDaFila(int id){
        filaAtual.Remove(id);

        if (id == idAtual)
        {
            if(!await NextMusic()){
                await PrevMusic();
            };
        }
        LabelCRUD lblDeletar = FindControl(flwpnlPlaylistsAdicionar, "lblCrudFila>" + id);
        flwpnlPlaylistsAdicionar.Controls.Remove(lblDeletar);
    }
    private void VisualizarFila()
    {
        if(flwpnlPlaylistsAdicionar != null){
            TogglePlaylistsOcultas(); return;
        }

        flwpnlPlaylistsAdicionar = new FlowLayoutPanel()
        {
            Size = new Size(pnlControlMusic.Size.Width, 500),
            Location = new Point(pnlControlMusic.Location.X, this.Size.Height),
            Name = "flwpnlPlaylistsAdicionar",
            Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right,
            AutoScroll = true,
            BackColor = Color.FromArgb(7, 12, 26)
        };

        titleWindow.Controls.Add(flwpnlPlaylistsAdicionar);

        flwpnlPlaylistsAdicionar.BringToFront();
        pnlControlMusic.BringToFront();
        List<int> listInt = filaAtual.Cast<int>().ToList();
        List<Musicas> mscs = Musicas.ConsultarMusicas(listInt);
        int tamanholbls = flwpnlPlaylistsAdicionar.Size.Width - 6;
        if(mscs.Count > 8){
            tamanholbls -= 23;
        }
        foreach (Musicas msc in mscs)
        {
            LabelCRUD lblMsc = new LabelCRUD()
            {
                Texto = msc.getNomeMusica(),
                Id = msc.getIdMusica(),
                ImgPrincipal = msc.getImgMusica(),
                Size = new Size(tamanholbls, 56),
                Name = "lblCrudFila>"+ msc.getIdMusica(),
                WithEdit = false,
                WithDelete = false,
                CorBackGround = Color.FromArgb(44, 44, 44),
                CorFontBackGround = Color.Silver
            };
            lblMsc.ImgPrincipalClick += BtnSelecionarMusica;
            lblMsc.LabelClick += BtnSelecionarMusica;
            lblMsc.Click += BtnSelecionarMusica;
            lblMsc.ImgExpandirClick += PopupRetirarDaFila;

            flwpnlPlaylistsAdicionar.Controls.Add(lblMsc);
        }

        controlesPermitidos = GetAllControls(flwpnlPlaylistsAdicionar);
        controlesPermitidos.AddRange(GetAllControls(pnlControlMusic));
        controlesPermitidos.Add(flwpnlPlaylistsAdicionar);

        TogglePlaylistsOcultas();
    }

    // Transicao - Salvar em uma Playlist ---------------------------------------------------------
    private void TransicaoPlaylistsAbrir(object sender, EventArgs e)
    {
        
        if (playlistsOcultas)
        {
            flwpnlPlaylistsHeight += 25;
            flwpnlPlaylistsAdicionar.Location = new Point(pnlControlMusic.Location.X, pnlControlMusic.Location.Y - flwpnlPlaylistsHeight);
            if (flwpnlPlaylistsAdicionar.Location.Y <= pnlControlMusic.Location.Y - 500)
            {
                flwpnlPlaylistsAdicionar.Location = new Point(pnlControlMusic.Location.X, pnlControlMusic.Location.Y - 500);
                playlistsOcultas = false;
                CriarDetectarCliqueFora(true);
                flwpnlPlaylistsTransition.Stop();
            }
        }
        else
        {
            flwpnlPlaylistsHeight -= 25;
            flwpnlPlaylistsAdicionar.Location = new Point(pnlControlMusic.Location.X, pnlControlMusic.Location.Y - flwpnlPlaylistsHeight);
            if (flwpnlPlaylistsAdicionar.Location.Y > pnlControlMusic.Location.Y)
            {
                flwpnlPlaylistsAdicionar.Location = new Point(pnlControlMusic.Location.X, pnlControlMusic.Location.Y);
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

    // Detectar Clique ----------------------------------------------------------------------------
    private void CriarDetectarCliqueForaPopup(bool detectar)
    {
        List<Control> ctrls = GetAllControls(this);
        if (detectar)
        {
            foreach (Control ctrl in ctrls)
            {
                ctrl.MouseDown += new MouseEventHandler(ClicarForaDoPopup);
            }
        }
        else
        {
            foreach (Control ctrl in ctrls)
            {
                ctrl.MouseDown -= new MouseEventHandler(ClicarForaDoPopup);
            }
        }
    }
    private void ClicarForaDoPopup(object sender, MouseEventArgs e)
    {
        Control ctrl = sender as Control;
        if (!controlesPermitidos.Contains(ctrl))
        {
            pop.Enabled = false;
            pop.Dispose();
            this.Controls.Remove(pop);
        }
    }
    private void CriarDetectarCliqueFora(bool detectar)
    {
        List<Control> ctrls = GetAllControls(this);
        if (detectar)
        {
            foreach (Control ctrl in ctrls)
            {
                ctrl.MouseDown += new MouseEventHandler(ClicarForaDasPlaylists);
            }
        }
        else
        {
            foreach (Control ctrl in ctrls)
            {
                ctrl.MouseDown -= new MouseEventHandler(ClicarForaDasPlaylists);
            }
        }
    }   
    private void ClicarForaDasPlaylists(object sender, MouseEventArgs e)
    {
        Control ctrl = sender as Control;
        if (!controlesPermitidos.Contains(ctrl))
        {
            flwpnlPlaylistsTransition.Start();
        }
    }
    public static List<Control> GetAllControls(Control parent)
    {
        List<Control> controls = new List<Control>();

        foreach (Control control in parent.Controls)
        {
            controls.Add(control);
            controls.AddRange(GetAllControls(control));
        }

        return controls;
    }

    // Gerenciamento ------------------------------------------------------------------------------
    private void AbrirCadastro()
    {
        Form2 telaCadastro = new Form2();
        telaCadastro.FormClosed += (s, e) => AoRecarregar();
        telaCadastro.Owner = this;
        telaCadastro.Show();
    }
    public static int ToogleSituacao(int situacao, PictureBox picInUse, string palavraChave)
    {

        switch (situacao)
        {
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
        if (!this.IsDisposed && this.Handle != IntPtr.Zero)
        {
            UnregisterHotKey(this.Handle, 1);
            UnregisterHotKey(this.Handle, 2);
            UnregisterHotKey(this.Handle, 3);
            UnregisterHotKey(this.Handle, 4);
        }
        if(musicaAtual != null){
            tempFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Musicas", musicaAtual.getNomeMusica() + ".m4a");
        }
        if (_soundOut != null)
        {
            //_soundOut?.Stop();
            _soundOut?.Dispose();
            _audioSource?.Dispose();
        }
        if (File.Exists(tempFilePath))
        {
            File.Delete(tempFilePath);
        }

        base.OnFormClosing(e);
    }
    private static void SldVolumeNivel(float nvlvlm, Slider sld)
    {
        sld.Value = (int)(nvlvlm * 100);
    }
}