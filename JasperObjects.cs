using System.Collections;
using System.Drawing.Drawing2D;
using Microsoft.Data.Sqlite;

public class Musicas{
    private int id;
    private string nome;
    private byte[] musica;
    private List<int> id_artista;
    private string nome_artista;
    private List<string> nome_artistas;
    private Image thumbnail;

    public Musicas(){

    }

    public Musicas(int idDePesquisa)
    {
        try
        {
            string dbPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Assets", "JasperMusic.db");

            using (var connection = Referencias.CreateConnection(dbPath))
            {
                connection.Open();

                string selectCommand = @"SELECT m.Nome, m.Musica, m.Thumbnail, a.Nome, a.Id FROM Musicas m LEFT JOIN Artistas_Musicas ON m.Id = Artistas_Musicas.Id_Musica LEFT JOIN Artista a ON Artistas_Musicas.Id_Artista = a.Id WHERE m.Id = @id";

                using (var command = new SqliteCommand(selectCommand, connection))
                {
                    command.Parameters.AddWithValue("@id", idDePesquisa);

                    using (var reader = command.ExecuteReader())
                    {
                        List<string> nomesArtistas = new List<string>();
                        List<int> idsArtistas = new List<int>();

                        while (reader.Read())
                        {
                            setIdMusica(idDePesquisa);

                            string nome = reader.GetString(0);
                            setNomeMusica(nome);

                            long tamanhoBlobMusica = reader.GetBytes(1, 0, null, 0, 0);
                            byte[] musica = new byte[tamanhoBlobMusica];
                            reader.GetBytes(1, 0, musica, 0, (int)tamanhoBlobMusica);
                            setBytesMusica(musica);

                            long tamanhoBlobImg = reader.GetBytes(2, 0, null, 0, 0);
                            byte[] bufferImg = new byte[tamanhoBlobImg];
                            reader.GetBytes(2, 0, bufferImg, 0, (int)tamanhoBlobImg);

                            using (MemoryStream ms = new MemoryStream(bufferImg))
                            {
                                Image img = Image.FromStream(ms);
                                setImgMusica(img);
                            }

                            if (!reader.IsDBNull(3))
                            {
                                string nomeArtista = reader.GetString(3);
                                nomesArtistas.Add(nomeArtista);
                            }
                            int idArtista = reader.GetInt32(4);
                            idsArtistas.Add(idArtista);
                        }
                        setNomesArtistasMusica(nomesArtistas);
                        setNomeArtistaMusica(string.Join(", ", nomesArtistas));
                        setIdsArtistasMusica(idsArtistas);
                    }
                }

                connection.Close();
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Erro ao listar música: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    public static void Salvar(Musicas msc)
    {
        try
        {
            string nome = msc.getNomeMusica();
            byte[] musica = msc.getBytesMusica();
            byte[] imgEmBytes = Referencias.ImageToByteArray(msc.getImgMusica());
            List<int> artistasIds = msc.getIdsArtistasMusica().Count > 0 ? msc.getIdsArtistasMusica() : new List<int> { 0 };

            string dbPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Assets", "JasperMusic.db");

            using (var connection = Referencias.CreateConnection(dbPath))
            {
                connection.Open();
                string insertCommand = "INSERT INTO Musicas (Nome, Musica, Thumbnail) VALUES (@nome, @musica, @thumbnail); SELECT last_insert_rowid();";
                long idMusica;

                using (var command = new SqliteCommand(insertCommand, connection))
                {
                    command.Parameters.AddWithValue("@nome", nome);
                    command.Parameters.AddWithValue("@musica", musica);
                    command.Parameters.AddWithValue("@thumbnail", imgEmBytes);

                    idMusica = (long)command.ExecuteScalar();
                }

                if (artistasIds != null && artistasIds.Count > 0)
                {
                MessageBox.Show("1");
                    string insertArtistaMusicaCommand = "INSERT INTO Artistas_Musicas (Id_Artista, Id_Musica) VALUES (@idArtista, @idMusica)";
                MessageBox.Show("2");
                    foreach (int idArtista in artistasIds)
                    {
                MessageBox.Show("3");
                        using (var command = new SqliteCommand(insertArtistaMusicaCommand, connection))
                        {
                MessageBox.Show("4");
                            command.Parameters.AddWithValue("@idArtista", idArtista);
                MessageBox.Show("5");
                            command.Parameters.AddWithValue("@idMusica", idMusica);
                MessageBox.Show("6");
                            command.ExecuteNonQuery();
                MessageBox.Show("7");
                        }
                    }
                }

                connection.Close();
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Erro ao salvar música: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
    public static void Alterar(Musicas msc)
    {
        try
        {
            int idDeAlteracao = msc.getIdMusica();
            string nome = msc.getNomeMusica();
            byte[] musicaEmBytes = msc.getBytesMusica();
            List<int> idsArtistas = msc.getIdsArtistasMusica();
            byte[] imgEmBytes = Referencias.ImageToByteArray(msc.getImgMusica());

            string dbPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Assets", "JasperMusic.db");

            using (var connection = Referencias.CreateConnection(dbPath))
            {
                connection.Open();

                List<string> camposParaAtualizar = new List<string> { "Nome = @nome" };

                if (musicaEmBytes.Length > 0) { camposParaAtualizar.Add("Musica = @musica"); }

                if (imgEmBytes.Length > 0) { camposParaAtualizar.Add("Thumbnail = @img"); }

                string updateCommand = $"UPDATE Musicas SET {string.Join(", ", camposParaAtualizar)} WHERE Id = @id";

                using (var command = new SqliteCommand(updateCommand, connection))
                {
                    command.Parameters.AddWithValue("@nome", nome);
                    if (musicaEmBytes.Length > 0) { command.Parameters.AddWithValue("@musica", musicaEmBytes); }
                    if (imgEmBytes.Length > 0) { command.Parameters.AddWithValue("@img", imgEmBytes); }
                    command.Parameters.AddWithValue("@id", idDeAlteracao);

                    command.ExecuteNonQuery();
                }

                if (idsArtistas != null && idsArtistas.Count > 0)
                {
                    string deleteCommand_ArtMsc = "DELETE FROM Artistas_Musicas WHERE Id_Musica = @idMusica";
                    using (var deleteCommand = new SqliteCommand(deleteCommand_ArtMsc, connection))
                    {
                        deleteCommand.Parameters.AddWithValue("@idMusica", idDeAlteracao);
                        deleteCommand.ExecuteNonQuery();
                    }

                    string insertCommand_ArtMsc = "INSERT INTO Artistas_Musicas (Id_Artista, Id_Musica) VALUES (@idArtista, @idMusica)";
                    foreach (int idArtista in idsArtistas)
                    {
                        using (var insertCommand = new SqliteCommand(insertCommand_ArtMsc, connection))
                        {
                            insertCommand.Parameters.AddWithValue("@idArtista", idArtista);
                            insertCommand.Parameters.AddWithValue("@idMusica", idDeAlteracao);
                            insertCommand.ExecuteNonQuery();
                        }
                    }
                }

                connection.Close();
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Erro ao alterar a música: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
    public static void Deletar(int idDeExclusao){
        try
        {
            string dbPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Assets", "JasperMusic.db");
            string connectionString = $"Data Source={dbPath}";

            using (var connection = Referencias.CreateConnection(dbPath))
            {
                connection.Open();
                string deleteCommand = "DELETE FROM Musicas WHERE id = @id";

                using (var command = new SqliteCommand(deleteCommand, connection))
                {
                    command.Parameters.AddWithValue("@id", idDeExclusao);

                    int rowsAffected = command.ExecuteNonQuery();
                }

                string deleteCommand_ArtMsc = "DELETE FROM Artistas_Musicas WHERE Id_Musica = @idMusica";

                using (var deleteCommand2 = new SqliteCommand(deleteCommand_ArtMsc, connection))
                {
                    deleteCommand2.Parameters.AddWithValue("@idMusica", idDeExclusao);
                    deleteCommand2.ExecuteNonQuery();
                }

                connection.Close();
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Erro ao excluir o atalho: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
    public static ArrayList ConsultarIDs(int idPlaylist = 0, int idPlaylistArtista = -1){
        ArrayList idsApps = new ArrayList();
        try
        {
            string dbPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Assets", "JasperMusic.db");

            using (var connection = Referencias.CreateConnection(dbPath))
            {
                connection.Open();

                string selectCommand = "SELECT Id FROM Musicas";
                if(idPlaylist != 0){
                    selectCommand = "SELECT Musicas.Id FROM Playlist_Musicas INNER JOIN Musicas ON Playlist_Musicas.Id_Musica = Musicas.Id WHERE Playlist_Musicas.Id_Playlist = @idplaylist";
                }
                if(idPlaylistArtista != -1){
                    selectCommand = "SELECT Musicas.Id FROM Artistas_Musicas INNER JOIN Musicas ON Artistas_Musicas.Id_Musica = Musicas.Id WHERE Artistas_Musicas.Id_Artista = @idplaylistArtista";
                }
                
                using (var command = new SqliteCommand(selectCommand, connection)){
                    if(idPlaylist != 0){command.Parameters.AddWithValue("@idplaylist", idPlaylist);}
                    if(idPlaylistArtista != -1){command.Parameters.AddWithValue("@idplaylistArtista", idPlaylistArtista);}
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int id = reader.GetInt32(0);

                            idsApps.Add(id);
                        }
                    }
                }
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Erro ao listar id das musicas: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        return idsApps;
    }
    public static List<Musicas> ConsultarMusicas(int idPlaylist = 0, int idPlaylistArtista = -1){
        List<Musicas> mscs = new List<Musicas>();
        try
        {
            string dbPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Assets", "JasperMusic.db");

            using (var connection = Referencias.CreateConnection(dbPath))
            {
                connection.Open();

                string selectCommand = "SELECT m.Id, m.Nome, m.Musica, m.Thumbnail FROM Musicas m";
                if(idPlaylist != 0){
                    selectCommand = "SELECT m.Id, m.Nome, m.Musica, m.Thumbnail FROM Playlist_Musicas INNER JOIN Musicas m ON Playlist_Musicas.Id_Musica = m.Id WHERE Playlist_Musicas.Id_Playlist = @idplaylist";
                }
                if(idPlaylistArtista != -1){
                    selectCommand = "SELECT m.Id, m.Nome, m.Musica, m.Thumbnail FROM Artistas_Musicas INNER JOIN Musicas m ON Artistas_Musicas.Id_Musica = m.Id WHERE Artistas_Musicas.Id_Artista = @idplaylistArtista";
                }
                using (var command = new SqliteCommand(selectCommand, connection)){
                    if(idPlaylist != 0){command.Parameters.AddWithValue("@idplaylist", idPlaylist);}
                    if(idPlaylistArtista != -1){command.Parameters.AddWithValue("@idplaylistArtista", idPlaylistArtista);}
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int id = reader.GetInt32(0);
                            string nome = reader.GetString(1);

                            Musicas msc = new Musicas();

                            msc.setIdMusica(id);
                            msc.setNomeMusica(nome);

                            long tamanhoBlobMsc = reader.GetBytes(2, 0, null, 0, 0);
                            byte[] bufferMsc = new byte[tamanhoBlobMsc];
                            reader.GetBytes(2, 0, bufferMsc, 0, (int)tamanhoBlobMsc);
                            
                            msc.setBytesMusica(bufferMsc);

                            long tamanhoBlobImg = reader.GetBytes(3, 0, null, 0, 0);
                            byte[] bufferImg = new byte[tamanhoBlobImg];
                            reader.GetBytes(3, 0, bufferImg, 0, (int)tamanhoBlobImg);

                            using (MemoryStream ms = new MemoryStream(bufferImg))
                            {
                                Image img = Image.FromStream(ms);
                                msc.setImgMusica(img);
                            }

                            mscs.Add(msc);
                        }
                    }
                }

                //Pegar Artistas
                string selectCommand_ArtMsc = "SELECT a.Nome, a.Id FROM Artistas_Musicas INNER JOIN Artista a ON Artistas_Musicas.Id_Artista = a.Id WHERE Artistas_Musicas.Id_Musica = @idMusica";

                foreach(Musicas msc in mscs){
                    using (var selectCommand2 = new SqliteCommand(selectCommand_ArtMsc, connection))
                    {
                        selectCommand2.Parameters.AddWithValue("@idMusica", msc.getIdMusica());
                        using (var reader = selectCommand2.ExecuteReader())
                        {
                            List<string> nomesArtistas = new List<string>();
                            List<int> idsArtistas = new List<int>();
                            while (reader.Read())
                            {
                                if (!reader.IsDBNull(0))
                                {
                                    string nomeArtista = reader.GetString(0);
                                    nomesArtistas.Add(nomeArtista);
                                }
                                int idArtista = reader.GetInt32(1);
                                idsArtistas.Add(idArtista);
                            }
                            msc.setNomesArtistasMusica(nomesArtistas);
                            msc.setNomeArtistaMusica(string.Join(", ", nomesArtistas));
                            msc.setIdsArtistasMusica(idsArtistas);
                        }
                    }
                }
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Erro ao listar musicas: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        return mscs;
    }

    public int getIdMusica(){
        return this.id;
    }
    public void setIdMusica(int id){
        this.id = id;
    }
    public string getNomeMusica(){
        return this.nome;
    }
    public void setNomeMusica(string nome){
        this.nome = nome;
    }
    public byte[] getBytesMusica(){
        return this.musica;
    }
    public void setBytesMusica(byte[] musica){
        this.musica = musica;
    }
    public List<int> getIdsArtistasMusica(){
        return this.id_artista;
    }
    public void setIdsArtistasMusica(List<int> id_artista){
        this.id_artista = id_artista;
    }
    public string getNomeArtistaMusica(){
        return this.nome_artista;
    }
    public void setNomeArtistaMusica(string nome_artista){
        this.nome_artista = nome_artista;
    }
    public List<string> getNomesArtistasMusica(){
        return this.nome_artistas;
    }
    public void setNomesArtistasMusica(List<string> nome_artistas){
        this.nome_artistas = nome_artistas;
    }
    public Image getImgMusica(){
        return this.thumbnail;
    }
    public void setImgMusica(Image thumbnail){
        this.thumbnail = thumbnail;
    }
}
public class Artistas{
    private int id;
    private string nome;
    private Image imagem;

    public Artistas(){

    }
    public Artistas(int idDePesquisa){
        try{
            string dbPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Assets", "JasperMusic.db");

            using (var connection = Referencias.CreateConnection(dbPath))
            {
                connection.Open();
                string selectCommand = "SELECT Nome, Imagem FROM Artista WHERE Id = @id";
                using (var command = new SqliteCommand(selectCommand, connection))
                {
                    command.Parameters.AddWithValue("@id", idDePesquisa);
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            setIdArtista(idDePesquisa);

                            string nome = reader.GetString(0);
                            setNomeArtista(nome);
                            
                            long tamanhoBlobImg = reader.GetBytes(1, 0, null, 0, 0);
                            byte[] bufferImg = new byte[tamanhoBlobImg];
                            reader.GetBytes(1, 0, bufferImg, 0, (int)tamanhoBlobImg);

                            using (MemoryStream ms = new MemoryStream(bufferImg))
                            {
                                Image img = Image.FromStream(ms);
                                setImgArtista(img);
                            }
                        }
                    }
                }
                connection.Close();
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Erro ao listar musica: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    public static void Salvar(Artistas art){
        try{
            string nome = art.getNomeArtista();
            byte[] imgEmBytes = Referencias.ImageToByteArray(art.getImgArtista());

            string dbPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Assets", "JasperMusic.db");

            using (var connection = Referencias.CreateConnection(dbPath))
            {
                connection.Open();

                string insertCommand = "INSERT INTO Artista (Nome, Imagem) VALUES (@nome, @imagem)";
                using (var command = new SqliteCommand(insertCommand, connection))
                {
                    command.Parameters.AddWithValue("@nome", nome);
                    command.Parameters.AddWithValue("@imagem", imgEmBytes);

                    command.ExecuteNonQuery();
                }
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Erro ao salvar musica: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
    public static void Alterar(Artistas art){
        try
        {
            int idDeAlteracao = art.getIdArtista();
            string nome = art.getNomeArtista();
            byte[] imgEmBytes = Referencias.ImageToByteArray(art.getImgArtista());

            string dbPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Assets", "JasperMusic.db");
            string connectionString = $"Data Source={dbPath}";
            
            using (var connection = Referencias.CreateConnection(dbPath))
            {
                connection.Open();

                string condicaoCommand = "";

                if (imgEmBytes.Length != 0) {condicaoCommand = ", Imagem = @img "; }

                string insertCommand = $"UPDATE Artista SET Nome = @nome{condicaoCommand} WHERE Id = @id";

                using (var command = new SqliteCommand(insertCommand, connection))
                {
                    command.Parameters.AddWithValue("@nome", nome);
                    if (imgEmBytes.Length != 0) { command.Parameters.AddWithValue("@img", imgEmBytes); }
                    command.Parameters.AddWithValue("@id", idDeAlteracao);

                    command.ExecuteNonQuery();
                }
                connection.Close();
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Erro ao alterar a playlist: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
    public static List<Artistas> ConsultarArtistas(){
        List<Artistas> arts = new List<Artistas>();
        try
        {
            string dbPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Assets", "JasperMusic.db");

            using (var connection = Referencias.CreateConnection(dbPath))
            {
                connection.Open();

                string selectCommand = "SELECT Id, Nome, Imagem FROM Artista";
                using (var command = new SqliteCommand(selectCommand, connection))
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int id = reader.GetInt32(0);
                        string nome = reader.GetString(1);

                        Artistas art = new Artistas();

                        art.setIdArtista(id);
                        art.setNomeArtista(nome);

                        long tamanhoBlobImg = reader.GetBytes(2, 0, null, 0, 0);
                        byte[] bufferImg = new byte[tamanhoBlobImg];
                        reader.GetBytes(2, 0, bufferImg, 0, (int)tamanhoBlobImg);

                        using (MemoryStream ms = new MemoryStream(bufferImg))
                        {
                            Image img = Image.FromStream(ms);
                            art.setImgArtista(img);
                        }

                        arts.Add(art);
                    }
                }
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Erro ao listar aplicativos: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        return arts;
    }

    public int getIdArtista(){
        return this.id;
    }
    public void setIdArtista(int id){
        this.id = id;
    }
    public string getNomeArtista(){
        return this.nome;
    }
    public void setNomeArtista(string nome){
        this.nome = nome;
    }    
    public Image getImgArtista(){
        return this.imagem;
    }
    public void setImgArtista(Image imagem){
        this.imagem = imagem;
    }
}
public class Playlists{
    private int id;
    private string nome;
    private Image imagem;

    public Playlists(){

    }
    public Playlists(int idDePesquisa){
        try{
            string dbPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Assets", "JasperMusic.db");

            using (var connection = Referencias.CreateConnection(dbPath))
            {
                connection.Open();
                string selectCommand = "SELECT Nome, Imagem FROM Playlist WHERE Id = @id";
                using (var command = new SqliteCommand(selectCommand, connection))
                {
                    command.Parameters.AddWithValue("@id", idDePesquisa);
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            setIdPlaylist(idDePesquisa);

                            string nome = reader.GetString(0);
                            setNomePlaylist(nome);
                            
                            long tamanhoBlobImg = reader.GetBytes(1, 0, null, 0, 0);
                            byte[] bufferImg = new byte[tamanhoBlobImg];
                            reader.GetBytes(1, 0, bufferImg, 0, (int)tamanhoBlobImg);

                            using (MemoryStream ms = new MemoryStream(bufferImg))
                            {
                                Image img = Image.FromStream(ms);
                                setImgPlaylist(img);
                            }
                        }
                    }
                }
                connection.Close();
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Erro ao listar musica: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    public static void Salvar(Playlists ply){
        try{
            string nome = ply.getNomePlaylist();
            byte[] imgEmBytes = Referencias.ImageToByteArray(ply.getImgPlaylist());

            string dbPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Assets", "JasperMusic.db");

            using (var connection = Referencias.CreateConnection(dbPath))
            {
                connection.Open();

                string insertCommand = "INSERT INTO Playlist (Nome, Imagem) VALUES (@nome, @imagem)";
                using (var command = new SqliteCommand(insertCommand, connection))
                {
                    command.Parameters.AddWithValue("@nome", nome);
                    command.Parameters.AddWithValue("@imagem", imgEmBytes);

                    command.ExecuteNonQuery();
                }
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Erro ao salvar musica: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
    public static void Alterar(Playlists ply){
        try
        {
            int idDeAlteracao = ply.getIdPlaylist();
            string nome = ply.getNomePlaylist();
            byte[] imgEmBytes = Referencias.ImageToByteArray(ply.getImgPlaylist());

            string dbPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Assets", "JasperMusic.db");
            string connectionString = $"Data Source={dbPath}";
            
            using (var connection = Referencias.CreateConnection(dbPath))
            {
                connection.Open();

                string condicaoCommand = "";

                if (imgEmBytes.Length != 0) {condicaoCommand = ", Imagem = @img "; }

                string insertCommand = $"UPDATE Playlist SET Nome = @nome{condicaoCommand} WHERE Id = @id";

                using (var command = new SqliteCommand(insertCommand, connection))
                {
                    command.Parameters.AddWithValue("@nome", nome);
                    if (imgEmBytes.Length != 0) { command.Parameters.AddWithValue("@img", imgEmBytes); }
                    command.Parameters.AddWithValue("@id", idDeAlteracao);

                    command.ExecuteNonQuery();
                }
                connection.Close();
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Erro ao alterar a playlist: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
    public static void Deletar(int idDeExclusao){
        try
        {
            string dbPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Assets", "JasperMusic.db");
            string connectionString = $"Data Source={dbPath}";

            using (var connection = Referencias.CreateConnection(dbPath))
            {
                connection.Open();
                string deleteCommand = "DELETE FROM Playlist WHERE id = @id";

                using (var command = new SqliteCommand(deleteCommand, connection))
                {
                    command.Parameters.AddWithValue("@id", idDeExclusao);

                    int rowsAffected = command.ExecuteNonQuery();
                }
                connection.Close();
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Erro ao excluir o atalho: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
    public static List<Playlists> ConsultarPlaylists(){
        List<Playlists> plys = new List<Playlists>();
        try
        {
            string dbPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Assets", "JasperMusic.db");

            using (var connection = Referencias.CreateConnection(dbPath))
            {
                connection.Open();

                string selectCommand = "SELECT Id, Nome, Imagem FROM Playlist";
                using (var command = new SqliteCommand(selectCommand, connection))
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int id = reader.GetInt32(0);
                        string nome = reader.GetString(1);

                        Playlists ply = new Playlists();

                        ply.setIdPlaylist(id);
                        ply.setNomePlaylist(nome);
                        
                        long tamanhoBlobImg = reader.GetBytes(2, 0, null, 0, 0);
                        byte[] bufferImg = new byte[tamanhoBlobImg];
                        reader.GetBytes(2, 0, bufferImg, 0, (int)tamanhoBlobImg);

                        using (MemoryStream ms = new MemoryStream(bufferImg))
                        {
                            Image img = Image.FromStream(ms);
                            ply.setImgPlaylist(img);
                        }

                        plys.Add(ply);
                    }
                }
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Erro ao listar aplicativos: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        return plys;
    }

    public static void SalvarMusica(int idPlaylist, int idMusica){
        try{
            string dbPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Assets", "JasperMusic.db");

            using (var connection = Referencias.CreateConnection(dbPath))
            {
                connection.Open();

                string insertCommand = "INSERT OR IGNORE INTO Playlist_Musicas (Id_Playlist, Id_Musica) VALUES (@idplaylist, @idmusica)";
                using (var command = new SqliteCommand(insertCommand, connection))
                {
                    command.Parameters.AddWithValue("@idplaylist", idPlaylist);
                    command.Parameters.AddWithValue("@idmusica", idMusica);

                    command.ExecuteNonQuery();
                }
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Erro ao salvar musica: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
    public static void TirarMusica(int idPlaylist, int idMusica){
        try{
            string dbPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Assets", "JasperMusic.db");

            using (var connection = Referencias.CreateConnection(dbPath))
            {
                connection.Open();

                string insertCommand = "DELETE FROM Playlist_Musicas WHERE Id_Playlist = @idplaylist AND Id_Musica = @idmusica";
                using (var command = new SqliteCommand(insertCommand, connection))
                {
                    command.Parameters.AddWithValue("@idplaylist", idPlaylist);
                    command.Parameters.AddWithValue("@idmusica", idMusica);

                    command.ExecuteNonQuery();
                }
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Erro ao tirar musica da playlist: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    public int getIdPlaylist(){
        return this.id;
    }
    public void setIdPlaylist(int id){
        this.id = id;
    }
    public string getNomePlaylist(){
        return this.nome;
    }
    public void setNomePlaylist(string nome){
        this.nome = nome;
    }    
    public Image getImgPlaylist(){
        return this.imagem;
    }
    public void setImgPlaylist(Image imagem){
        this.imagem = imagem;
    }
}
public class Referencias{
    public static string caminhoImgPadrao = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Assets", "Morgan.jpg");
    public Referencias(){

    }
    public static byte[] ImageToByteArray(Image image)
    {
        if (image != null){
            using (MemoryStream ms = new MemoryStream())
            {
                Bitmap bitmap = new Bitmap(image);
                bitmap.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                return ms.ToArray();
            }
        }
        return new byte[0];
    }
    public static Image ByteArrayToImage(byte[] byteArray)
    {
        using (MemoryStream ms = new MemoryStream(byteArray))
        {
            return Image.FromStream(ms); // Converte os bytes para uma imagem
        }
    }

    public static SqliteConnection CreateConnection(string databasePath)
    {
        var connection = new SqliteConnection($"Data Source={databasePath};");
        connection.Open();

        using (var command = new SqliteCommand("PRAGMA foreign_keys = ON;", connection))
        {
            command.ExecuteNonQuery();
        }

        return connection;
    }

    public static void PicDefinirCorDeFundo(Image imgData, PictureBox pic)
    {
        if (imgData == null)
            return;

        Bitmap bitmap = new Bitmap(imgData);
        Color corBordaSuperior = bitmap.GetPixel(bitmap.Width / 2, 0);
        Color corBordaInferior = bitmap.GetPixel(bitmap.Width / 2, bitmap.Height - 1);
        Color corBordaEsquerda = bitmap.GetPixel(0, bitmap.Height / 2);
        Color corBordaDireita = bitmap.GetPixel(bitmap.Width - 1, bitmap.Height / 2);

        int a = (corBordaSuperior.A + corBordaInferior.A + corBordaEsquerda.A + corBordaDireita.A) / 4;
        int r = (corBordaSuperior.R + corBordaInferior.R + corBordaEsquerda.R + corBordaDireita.R) / 4;
        int g = (corBordaSuperior.G + corBordaInferior.G + corBordaEsquerda.G + corBordaDireita.G) / 4;
        int b = (corBordaSuperior.B + corBordaInferior.B + corBordaEsquerda.B + corBordaDireita.B) / 4;

        pic.BackColor = Color.FromArgb(a, r, g, b);
    }

    public static PictureBox PicArredondarBordas(PictureBox pictureBox, int topLeftRadius = 30, int topRightRadius = 30, int bottomRightRadius = 30, int bottomLeftRadius = 30)
    {
        using (GraphicsPath gp = new GraphicsPath())
        {
            // Canto superior esquerdo
            if (topLeftRadius > 0)
                gp.AddArc(0, 0, topLeftRadius * 2, topLeftRadius * 2, 180, 90);
            else
                gp.AddLine(0, 0, 0, 0); // Pontudo

            // Canto superior direito
            if (topRightRadius > 0)
                gp.AddArc(pictureBox.Width - topRightRadius * 2, 0, topRightRadius * 2, topRightRadius * 2, 270, 90);
            else
                gp.AddLine(pictureBox.Width, 0, pictureBox.Width, 0); // Pontudo

            // Canto inferior direito
            if (bottomRightRadius > 0)
                gp.AddArc(pictureBox.Width - bottomRightRadius * 2, pictureBox.Height - bottomRightRadius * 2, bottomRightRadius * 2, bottomRightRadius * 2, 0, 90);
            else
                gp.AddLine(pictureBox.Width, pictureBox.Height, pictureBox.Width, pictureBox.Height); // Pontudo

            // Canto inferior esquerdo
            if (bottomLeftRadius > 0)
                gp.AddArc(0, pictureBox.Height - bottomLeftRadius * 2, bottomLeftRadius * 2, bottomLeftRadius * 2, 90, 90);
            else
                gp.AddLine(0, pictureBox.Height, 0, pictureBox.Height); // Pontudo

            gp.CloseFigure();

            pictureBox.Region = new Region(gp);
            return pictureBox;
        }
    }
}