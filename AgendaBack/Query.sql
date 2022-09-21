-- Cria a tabela Products
CREATE TABLE Eventos(
	Id					INT NOT NULL UNIQUE,
	[Name]			    VARCHAR(255) NOT NULL,
	[Description]		VARCHAR(255) NOT NULL,
	[Start]			    DATETIME,
	[End]				DATETIME,
	Users				VARCHAR(255),
);
GO

-- Lista os dados da tabela
SELECT * FROM Events;
GO

-- Insere um registro na tabela
INSERT INTO Eventos (Id, [Name], [Description], [Start], [End], Users)
VALUES				 ();
GO

-- Deleta um registro que coincida com o IdProduct informado
DELETE FROM Products WHERE IdProduct = '';