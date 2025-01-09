CREATE TABLE Artista (
    Id INTEGER PRIMARY KEY AUTOINCREMENT,
    Nome TEXT NOT NULL,
    Imagem BLOB NOT NULL
);
CREATE TABLE Musicas (
    Id INTEGER PRIMARY KEY AUTOINCREMENT,
    Nome TEXT NOT NULL,
    Musica BLOB NOT NULL,
    Thumbnail BLOB NOT NULL
);
CREATE TABLE Playlist (
    Id INTEGER PRIMARY KEY AUTOINCREMENT,
    Nome TEXT NOT NULL,
    Imagem BLOB NOT NULL
);
CREATE TABLE Playlist_Musicas (
    Id_Playlist INTEGER NOT NULL,
    Id_Musica INTEGER NOT NULL,
    PRIMARY KEY (Id_Playlist, Id_Musica),
    FOREIGN KEY (Id_Playlist) REFERENCES Playlist(Id)
        ON DELETE CASCADE,
    FOREIGN KEY (Id_Musica) REFERENCES Musicas(Id)
        ON DELETE CASCADE
);
CREATE TABLE Artistas_Musicas (
    Id_Artista INTEGER NOT NULL,
    Id_Musica INTEGER NOT NULL,
    PRIMARY KEY (Id_Artista, Id_Musica),
    FOREIGN KEY (Id_Artista) REFERENCES Artista(Id)
        ON DELETE CASCADE,
    FOREIGN KEY (Id_Musica) REFERENCES Musicas(Id)
        ON DELETE CASCADE
);

SELECT * FROM Musicas;
SELECT * FROM Artista;
SELECT * FROM Playlist;
SELECT * FROM Playlist_Musicas;
SELECT * FROM Artistas_Musicas;

DELETE FROM sqlite_sequence WHERE name='Artista';