USE master
GO

IF DB_ID('agro') IS NOT NULL
ALTER DATABASE agro SET single_user WITH ROLLBACK IMMEDIATE
DROP DATABASE agro;
GO

CREATE DATABASE agro;
GO

IF NOT EXISTS (SELECT name FROM master.sys.server_principals WHERE name = 'agro') 
BEGIN
	CREATE LOGIN [agro] WITH PASSWORD = 'demo123', DEFAULT_DATABASE = agro, CHECK_POLICY = OFF
END

GO
USE agro;

EXEC sp_changedbowner 'agro'
GO

CREATE TABLE Users(
	id int PRIMARY KEY IDENTITY(1,1),
	login varchar(50) NOT NULL UNIQUE,
	password varchar(250) NOT NULL UNIQUE
)

CREATE TABLE Resource_types(
	id int PRIMARY KEY IDENTITY(1,1),
	type varchar(100) NOT NULL UNIQUE
)

CREATE TABLE Plant_types(
	id int PRIMARY KEY IDENTITY(1,1),
	type varchar(100) NOT NULL UNIQUE
)

CREATE TABLE Plants(
	id int PRIMARY KEY IDENTITY(1,1),
	name varchar(250),
	type int FOREIGN KEY REFERENCES Plant_types(id)
)

CREATE TABLE Machine_types(
	id int PRIMARY KEY IDENTITY(1,1),
	type varchar(100) NOT NULL UNIQUE
)

CREATE TABLE Tool_types(
	id int PRIMARY KEY IDENTITY(1,1),
	type varchar(100) NOT NULL UNIQUE
)

CREATE TABLE Employees(
	id int PRIMARY KEY IDENTITY(1,1),
	name varchar(250) NOT NULL
)

CREATE TABLE Activity_types(
	id int PRIMARY KEY IDENTITY(1,1),
	type varchar(250) NOT NULL UNIQUE
)

CREATE TABLE Farms(
	id int PRIMARY KEY IDENTITY(1,1),
	name varchar(250),
	[user] int FOREIGN KEY REFERENCES Users(id)
)

CREATE TABLE Fields(
	id int PRIMARY KEY IDENTITY(1,1),
	[name] varchar(100) NOT NULL,
	[description] varchar (500),
	coordinates VARCHAR(5000),
	farm int FOREIGN KEY REFERENCES Farms(id) ON DELETE CASCADE,
	plant int FOREIGN KEY REFERENCES Plants(id) ON DELETE CASCADE
)

CREATE TABLE Garages(
	id int PRIMARY KEY IDENTITY(1,1),
	name varchar(250),
	farm int FOREIGN KEY REFERENCES Farms(id) ON DELETE CASCADE
)

CREATE TABLE Tools(
	id int PRIMARY KEY IDENTITY(1,1),
	name varchar(250),
	garage int FOREIGN KEY REFERENCES Garages(id),
	mileage int,
	type int FOREIGN KEY REFERENCES Tool_types(id)
)

CREATE TABLE Machines(
	id int PRIMARY KEY IDENTITY(1,1),
	name varchar(250),
	garage int FOREIGN KEY REFERENCES Garages(id),
	mileage int,
	type int FOREIGN KEY REFERENCES Machine_types(id),
	inspection_date date,
	fuel float
)

CREATE TABLE Storages(
	id int PRIMARY KEY IDENTITY(1,1),
	name varchar(250) NOT NULL UNIQUE,
	farm int FOREIGN KEY REFERENCES Farms(id) ON DELETE CASCADE
)

CREATE TABLE Resources(
	id int PRIMARY KEY IDENTITY(1,1),
	type int FOREIGN KEY REFERENCES Resource_types(id),
	storage int FOREIGN KEY REFERENCES Storages(id),
	amount float DEFAULT 0
)

CREATE TABLE Journals(
	id int PRIMARY KEY IDENTITY(1,1),
	farm int FOREIGN KEY REFERENCES Farms(id) ON DELETE CASCADE
)


CREATE TABLE Activities(
	id int PRIMARY KEY IDENTITY(1,1),
	name varchar(250) NOT NULL,
	journal int FOREIGN KEY REFERENCES Journals(id) ON DELETE CASCADE,
	description varchar(1000),
	start_date date,
	finish_date date,
	type int FOREIGN KEY REFERENCES Activity_types(id),
	field int FOREIGN KEY REFERENCES Fields(id),
	employee int FOREIGN KEY REFERENCES Employees(id),
	machine int FOREIGN KEY REFERENCES Machines(id),
	tool int FOREIGN KEY REFERENCES Tools(id)
)

CREATE TABLE Notes(
	id int PRIMARY KEY IDENTITY(1,1),
	name varchar(100) NOT NULL,
	journal int FOREIGN KEY REFERENCES Journals(id) ON DELETE CASCADE,
	description varchar(250),
	start_date date,
	finish_date date,
	field int FOREIGN KEY REFERENCES Fields(id),
	photo image
)

INSERT INTO Users (login,password) VALUES ('test1', 'qwe');

INSERT INTO Farms ([name], [user]) VALUES ('test1',1), ('test2',1);

INSERT INTO Journals (farm) VALUES (1),(2);

INSERT INTO Plant_types (type) VALUES ('Zbo¿e');

INSERT INTO Plants (name, type) VALUES ('Pszenica',1),('Jêczmieñ',1),('Kukurydza',1);

INSERT INTO Fields ([name], [description], coordinates, farm, plant) 
VALUES 
('Plac Wolnoœci', 'Plac Wolnoœci we W³oc³awku dolny tekst', '[[52.654806, 19.065356],[52.654806, 19.065356],[52.65575, 19.06629],[52.65575, 19.06629],[52.65534, 19.068071],[52.65534, 19.068071],[52.654031, 19.067041],[52.654023, 19.067041]]',1,1),
('Przyk³ad', 'Przyk³adowe pole w Brzeœciu', '[[52.597626, 18.940215],[52.597626, 18.940215],[52.600324, 18.941653],[52.600324, 18.941653],[52.598981, 18.950987],[52.598981, 18.950987],[52.597391, 18.950257],[52.597391, 18.950257],[52.598186, 18.944721],[52.598186, 18.944721],[52.597039, 18.944292],[52.597039, 18.944292]]',2,1);

INSERT INTO Garages (name,farm) VALUES ('garaz1',1), ('garaz2',1), ('garaz3',2);

INSERT INTO Storages(name,farm) VALUES ('magazyn1',1), ('magazyn2',1), ('magazyn3',2);

INSERT INTO Notes (name, description, field, start_date, finish_date, journal) VALUES ('test1', 'testOpis1',1,'2023-01-01', '2023-06-20',1), ('test2', 'testOpis2',2,'2023-01-01', '2023-06-24',1);

INSERT INTO Activities(name, description, field, start_date, finish_date, journal) VALUES ('test1', 'testOpis1',1,'2023-01-01', '2023-06-20',1), ('test2', 'testOpis2',2,'2023-01-01', '2023-06-24',1);