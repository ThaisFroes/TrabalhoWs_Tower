CREATE DATABASE WSTower_app
GO

USE WSTower_app
GO

CREATE TABLE Usuario (
 ID		INT PRIMARY KEY IDENTITY
,Email	VARCHAR(255) NOT NULL
,Nome	VARCHAR(255) NOT NULL
,Senha	VARCHAR (255) NOT NULL
,foto IMAGE
,NomeUsuario VARCHAR (255) NOT NULL UNIQUE
,Acesso bit NOT NULL DEFAULT 0
)

GO

CREATE TABLE TipoDeIngresso (
IdTipoDeIngresso		INT PRIMARY KEY IDENTITY
,Tipo_de_Ingresso		VARCHAR	(255) NOT NULL
,Valor DECIMAL(12,2)
)

GO

CREATE TABLE FormaDePagamento (
IdFormaDePagamento		INT PRIMARY KEY IDENTITY
,Forma_de_Pagamento		VARCHAR(255) NOT NULL
)

GO

CREATE TABLE Estadio(
	ID INT PRIMARY KEY IDENTITY,
	Nome VARCHAR(255) NOT NULL,
	Endereco VARCHAR(255) NOT NULL,
	QuantidadeDeLugares INT NOT NULL
);

GO

CREATE TABLE Times(
	ID INT PRIMARY KEY IDENTITY,
	Nome VARCHAR(255) NOT NULL,
	Bandeira IMAGE,
);

GO

CREATE TABLE Jogos (
 ID			INT PRIMARY KEY IDENTITY
,Horario DATETIME NOT NULL
,IdTimeVisitante INT FOREIGN KEY REFERENCES Times (ID)
,IdTimeCasa INT FOREIGN KEY REFERENCES Times (ID)
,IdEstadio INT FOREIGN KEY REFERENCES Estadio (ID)
,Campeonato		VARCHAR(255)
,Detalhes		TEXT
);

GO

CREATE  TABLE CompraIngressos (
 ID		INT PRIMARY KEY IDENTITY
,Quantidade				INT
,Valor					VARCHAR(255)
,IdFormaDePagamento		INT FOREIGN KEY REFERENCES FormaDePagamento (IdFormaDePagamento)
,IdUsuario		INT FOREIGN KEY REFERENCES Usuario (id)
,IdTipoDeIngresso		INT FOREIGN KEY REFERENCES TipoDeIngresso (IdTipoDeIngresso)
,IdJogo					INT FOREIGN KEY REFERENCES Jogos (ID)
)

GO

CREATE TABLE IngressosVendidos(
ID	INT PRIMARY KEY IDENTITY
,NumeroDoIngresso VARCHAR(255) 
,IdCompra	INT FOREIGN KEY REFERENCES CompraIngressos (ID)
);
