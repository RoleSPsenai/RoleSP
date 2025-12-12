USE master;
GO

IF DB_ID('DbRoleSP') IS NOT NULL
BEGIN
    ALTER DATABASE DbRoleSP SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
    DROP DATABASE DbRoleSP;
END
GO

CREATE DATABASE DbRoleSP;
GO

USE DbRoleSP;
GO

--------------------
-- Tabela Usuario --
--------------------
CREATE TABLE Usuario (
    ID_User INT PRIMARY KEY IDENTITY(1,1),
    Email VARCHAR(120) NOT NULL,
    Nome NVARCHAR(120),
    Apelido NVARCHAR(120),
    SenhaHash VARBINARY(32) NOT NULL,
    DataCriacao DATETIME DEFAULT GETDATE(),
    ImagemPerfil VARCHAR(MAX)
);
GO

-----------------
-- Tabela Post --
-----------------
CREATE TABLE Post (
    ID_Post INT PRIMARY KEY IDENTITY(1,1),
    Avaliacao INT,
    DataPost DATE DEFAULT GETDATE(),
    Legenda NVARCHAR(500),
    Imagem VARCHAR(MAX),
    ID_User INT NOT NULL,
    ID_Local INT NOT NULL,
    ID_Favorito INT NULL
);
GO

---------------------
-- Tabela Favorito --
---------------------
CREATE TABLE Favorito (
    ID_Favorito INT PRIMARY KEY IDENTITY(1,1),
    ID_User INT NOT NULL,
    ID_Post INT NOT NULL
);
GO

--------------------
-- Tabela Destino --
--------------------
CREATE TABLE Destino (
    ID_Destino INT PRIMARY KEY IDENTITY(1,1),
    ID_User INT NOT NULL,
    ID_Post INT NOT NULL
);
GO

-----------------------
-- Tabela Comentario --
-----------------------
CREATE TABLE Comentario (
    ID_Comentario INT PRIMARY KEY IDENTITY(1,1),
    DataComentario DATE DEFAULT GETDATE(),
    Texto NVARCHAR(500),
    ID_Post INT NOT NULL,
    ID_User INT NOT NULL
);
GO

------------------
-- Tabela Local --
------------------
CREATE TABLE Local (
    ID_Local INT PRIMARY KEY IDENTITY(1,1),
    Endereco NVARCHAR(500),
    ID_NomeLocal NVARCHAR(200),
    ID_Avaliacao INT
);
GO

-------------------
-- Tabela Filtro --
-------------------
CREATE TABLE Filtro (
    ID_Filtro INT PRIMARY KEY IDENTITY(1,1),
    Nome NVARCHAR(120)
);
GO

-----------------------------------------
-- Relacionamento Local - Filtro (N:N) --
-----------------------------------------
CREATE TABLE Local_Filtro (
    ID_Filtro INT NOT NULL,
    ID_Local INT NOT NULL,
    PRIMARY KEY (ID_Filtro, ID_Local),
    FOREIGN KEY (ID_Filtro) REFERENCES Filtro(ID_Filtro),
    FOREIGN KEY (ID_Local) REFERENCES Local(ID_Local)
);
GO

-------------------------------
-- CHAVES ESTRANGEIRAS (FKs) --
-------------------------------

ALTER TABLE Favorito ADD FOREIGN KEY (ID_User) REFERENCES Usuario(ID_User);
ALTER TABLE Favorito ADD FOREIGN KEY (ID_Post) REFERENCES Post(ID_Post);

ALTER TABLE Destino ADD FOREIGN KEY (ID_User) REFERENCES Usuario(ID_User);
ALTER TABLE Destino ADD FOREIGN KEY (ID_Post) REFERENCES Post(ID_Post);

ALTER TABLE Comentario ADD FOREIGN KEY (ID_Post) REFERENCES Post(ID_Post);
ALTER TABLE Comentario ADD FOREIGN KEY (ID_User) REFERENCES Usuario(ID_User);

ALTER TABLE Post ADD FOREIGN KEY (ID_User) REFERENCES Usuario(ID_User);
ALTER TABLE Post ADD FOREIGN KEY (ID_Local) REFERENCES Local(ID_Local);
ALTER TABLE Post ADD FOREIGN KEY (ID_Favorito) REFERENCES Favorito(ID_Favorito);
GO
