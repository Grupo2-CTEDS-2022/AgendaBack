use db_16;

select * from Accounts;
select * from Eventos;
SELECT * FROM Accounts where Name = 'batman';

drop table Accounts;

-- Cria a tabela Accounts
CREATE TABLE Accounts(
	IdAccount		    int  NOT NULL UNIQUE IDENTITY(1,1),
	[Name]			    VARCHAR(255) NOT NULL,
	[Email]     		VARCHAR(255) NOT NULL UNIQUE,
	[Password]			VARCHAR(255) NOT NULL,
    primary key(IdAccount)
	
);

INSERT INTO Accounts ([Name], [Email], [Password])
VALUES ('Admin', 'admin@email.com', 'admin123'),
('Test', 'test@email.com', 'test123');

drop table Eventos;
CREATE TABLE Eventos(
	Id int  NOT NULL UNIQUE IDENTITY(1,1),
	[Name] VARCHAR(255) NOT NULL,
	[Description] VARCHAR(255) NOT NULL,
	[Start] DATETIME,
	[End] DATETIME,
	Users VARCHAR(255),
	OwnerId int,
    primary key(Id)
);

-- Insere um registro na tabela
INSERT INTO Eventos ([Name], [Description], [Start], [End], Users, OwnerId)
VALUES ('Festa', 'Aniversario legal', '2008-11-11 13:23:4', '2008-11-11 14:23:4',  '00000,01111', 1);

SELECT * FROM Eventos;

