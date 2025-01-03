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

INSERT INTO Artista (nome, imagem) VALUES ("lucasART", "");

SELECT * FROM Musicas;
SELECT * FROM Artista;