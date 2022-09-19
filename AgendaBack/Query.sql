CREATE DATABASE Agenda;
GO

-- Define qual banco de dados será utilizado
USE Agenda;
GO

-- Cria a tabela Products
CREATE TABLE Eventos(
	Id		    INT NOT NULL UNIQUE,
	[Name]			    VARCHAR(255) NOT NULL,
	[Description]		VARCHAR(255) NOT NULL,
	[DATE]			    VARCHAR(10) NOT NULL,
	[TIME]				VARCHAR(10) NOT NULL,
);
GO

-- Lista os dados da tabela
SELECT * FROM Events;
GO

-- Insere um registro na tabela
INSERT INTO Products (IdProduct, [Name], [Description], Price)
VALUES				 ('SM-G781BLVJZTO', 'Galaxy S20 FE 5G Violeta', 'Tons para deixar até o arco-íris com inveja. Todos os olhos voltados para a tela Infinity-O. A câmera de lente tripla de nível profissional.', 1299.99);
GO

-- Deleta um registro que coincida com o IdProduct informado
DELETE FROM Products WHERE IdProduct = 'SM-G781BLVJZTO';