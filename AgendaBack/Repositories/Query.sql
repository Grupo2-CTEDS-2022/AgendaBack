use db_16;
-- Cria a tabela Products
CREATE TABLE Eventos(
Id VARCHAR(6) NOT NULL,
[Name] VARCHAR(255) NOT NULL,
[Description] VARCHAR(255) NOT NULL,
[Start] DATETIME,
[End] DATETIME,
Users VARCHAR(255),
);

-- Insere um registro na tabela
INSERT INTO Eventos (Id, [Name], [Description], [Start], [End], Users)
VALUES ('12345', 'Festa', 'Aniversario legal', '2008-11-11 13:23:4', '2008-11-11 14:23:4',  '00000,01111');


-- Lista os dados da tabela
SELECT * FROM Eventos;


-- Deleta um registro que coincida com o IdProduct informado
DELETE FROM EVENTOS WHERE Id = '12345'; 

--DROP TABLE Eventos;