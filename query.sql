CREATE TABLE Artista (
    Id INTEGER PRIMARY KEY AUTOINCREMENT,
    Nome TEXT NOT NULL,
    Imagem BLOB NOT NULL
);
CREATE TABLE Musicas (
    Id INTEGER PRIMARY KEY AUTOINCREMENT,
    Nome TEXT NOT NULL,
    Musica BLOB NOT NULL,
    Id_Artista INTEGER NOT NULL,
    Thumbnail BLOB NOT NULL,
    FOREIGN KEY (Id_Artista) REFERENCES Artista (Id)
    ON UPDATE CASCADE
    ON DELETE CASCADE
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

INSERT INTO Artista (Id, nome, imagem) VALUES (0, "desconhecido", "");

SELECT * FROM Musicas;
SELECT * FROM Artista;
SELECT * FROM Playlist;
SELECT * FROM Playlist_Musicas;

SELECT Musicas.Id, Musicas.Nome, Musicas.Id_Artista, Musicas.Thumbnail, Artista.Nome FROM Playlist_Musicas INNER JOIN Musicas ON Playlist_Musicas.Id_Musica = Musicas.Id INNER JOIN Artista ON Musicas.Id_Artista = Artista.Id WHERE Playlist_Musicas.Id_Playlist = 1

INSERT INTO Playlist_Musicas (Id_Playlist, Id_Musica) VALUES (1, 1);
INSERT INTO Playlist_Musicas (Id_Playlist, Id_Musica) VALUES (1, 3);

UPDATE Musicas SET Nome = "ffff", Id_Artista = 2 WHERE id = 3