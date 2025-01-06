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

INSERT INTO Artista (Id, nome, imagem) VALUES (0, "desconhecido", "");

SELECT * FROM Musicas;
SELECT * FROM Artista;
SELECT * FROM Playlist;
SELECT * FROM Playlist_Musicas;
SELECT * FROM Artistas_Musicas;

DELETE FROM Artista WHERE id = 2;
DELETE FROM sqlite_sequence WHERE name='Artista';

INSERT INTO Artistas_Musicas (Id_Artista, Id_Musica) VALUES (0, 1)

INSERT INTO Playlist_Musicas (Id_Playlist, Id_Musica) VALUES (1, 1);
INSERT INTO Playlist_Musicas (Id_Playlist, Id_Musica) VALUES (1, 3);

INSERT INTO Artistas_Musicas (Id_Artista, Id_Musica) VALUES (6, 1);
INSERT INTO Artistas_Musicas (Id_Artista, Id_Musica) VALUES (5, 4);