using Microsoft.Data.Sqlite;

public class Musicas{
    private int id;
    private string nome;
    private byte[] musica;
    private int id_artista;
    private Image thumbnail;

    public Musicas(){

    }
    public Musicas(int idDePesquisa){
        try{
            string dbPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Assets", "JasperMusic.db");

            using (var connection = Referencias.CreateConnection(dbPath))
            {
                connection.Open();
                string selectCommand = "SELECT Nome, Musica, Id_Artista, Thumbnail FROM Musicas WHERE Id = @id";
                using (var command = new SqliteCommand(selectCommand, connection))
                {
                    command.Parameters.AddWithValue("@id", idDePesquisa);
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            setIdMusica(idDePesquisa);

                            string nome = reader.GetString(0);
                            setNomeMusica(nome);
                            
                            long tamanhoBlobMusica = reader.GetBytes(1, 0, null, 0, 0);
                            byte[] musica = new byte[tamanhoBlobMusica];
                            reader.GetBytes(3, 0, musica, 0, (int)tamanhoBlobMusica);
                            setBytesMusica(musica);

                            int idArtista = reader.GetInt32(2);
                            setArtistaMusica(idArtista);
                            
                            long tamanhoBlobImg = reader.GetBytes(3, 0, null, 0, 0);
                            byte[] bufferImg = new byte[tamanhoBlobImg];
                            reader.GetBytes(3, 0, bufferImg, 0, (int)tamanhoBlobImg);

                            using (MemoryStream ms = new MemoryStream(bufferImg))
                            {
                                Image img = Image.FromStream(ms);
                                setImgMusica(img);
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

    public static void Salvar(Musicas music){
        try{
            string nome = music.getNomeMusica();
            byte[] musica = music.getBytesMusica();
            int idArtista = music.getArtistaMusica();
            byte[] imgEmBytes = Referencias.ImageToByteArray(music.getImgMusica());

            string dbPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Assets", "JasperMusic.db");

            using (var connection = Referencias.CreateConnection(dbPath))
            {
                connection.Open();

                string insertCommand = "INSERT INTO Musicas (Nome, Musica, Id_Artista, Thumbnail) VALUES (@nome, @musica, @id_Artista, @thumbnail)";
                using (var command = new SqliteCommand(insertCommand, connection))
                {
                    command.Parameters.AddWithValue("@nome", nome);
                    command.Parameters.AddWithValue("@musica", musica);
                    command.Parameters.AddWithValue("@id_Artista", idArtista);
                    command.Parameters.AddWithValue("@thumbnail", imgEmBytes);

                    command.ExecuteNonQuery();
                }
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Erro ao salvar musica: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
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
    public int getArtistaMusica(){
        return this.id_artista;
    }
    public void setArtistaMusica(int id_artista){
        this.id_artista = id_artista;
    }
    public Image getImgMusica(){
        return this.thumbnail;
    }
    public void setImgMusica(Image thumbnail){
        this.thumbnail = thumbnail;
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
}