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
	password varchar(250) NOT NULL 
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
	name varchar(250) NOT NULL,
	[user] int FOREIGN KEY REFERENCES Users(id)
)

CREATE TABLE Activity_types(
	id int PRIMARY KEY IDENTITY(1,1),
	type varchar(250) NOT NULL UNIQUE
)

CREATE TABLE Note_types(
	id int PRIMARY KEY IDENTITY(1,1),
	type varchar(250) NOT NULL UNIQUE
)

CREATE TABLE Farms(
	id int PRIMARY KEY IDENTITY(1,1),
	name varchar(250) NOT NULL,
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
	mileage int DEFAULT 0,
	type int FOREIGN KEY REFERENCES Machine_types(id),
	inspection_date date,
	fuel float DEFAULT 0
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
	tool int FOREIGN KEY REFERENCES Tools(id),
	value float,
)

CREATE TABLE Notes(
	id int PRIMARY KEY IDENTITY(1,1),
	name varchar(100) NOT NULL,
	journal int FOREIGN KEY REFERENCES Journals(id) ON DELETE CASCADE,
	type int FOREIGN KEY REFERENCES Note_types(id),
	description varchar(250),
	start_date date,
	finish_date date,
	field int FOREIGN KEY REFERENCES Fields(id),
	value float,
	photo image
)

INSERT INTO Users (login,password) VALUES ('user1', 'qwe'), ('user2','qwe'), ('user3','qwe');

INSERT INTO Farms ([name], [user]) VALUES
('Farm 1', 1), 
('Farm 2', 1), 
('Farm 3', 1), 
('Farm 4', 1),
('Farm 1', 2), 
('Farm 2', 2), 
('Farm 3', 2),
('Farm 1', 3), 
('Farm 2', 3);

INSERT INTO Activity_types (type) VALUES ('Orka'), ('Siew'), ('Podlewanie'), ('Nawo¿enie'),('Pryskanie'), ('Zbiory');

INSERT INTO Note_types (type) VALUES ('Notatka'), ('Opady'), ('Chwasty'), ('Choroby');

INSERT INTO Journals (farm) VALUES (1),(2),(3),(4),(5),(6),(7),(8),(9);

INSERT INTO Plant_types (type) VALUES ('Zbo¿e'), ('Okopowe'), ('Pastewne'), ('Str¹czkowe');

INSERT INTO Plants (name, type) VALUES 
('Pszenica ozima',1),
('Pszenica jara',1),
('Jêczmieñ ozimy',1),
('Jêczmieñ jary',1),
('Kukurydza',1),
('Pszen¿yto ozime',1),
('Pszen¿yto jare',1),
('¯yto ozime',1),
('¯yto jare',1),
('Burak cukrowy',2),
('Marchew',2),
('Ziemniak',2),
('Burak pastewny',3),
('Trawa',3),
('Lucerna',3),
('Groch',4),
('Bób',4),
('Fasola',4),
('Soja',4);

INSERT INTO Fields ([name], [description], coordinates, farm, plant)
VALUES
('Pole 1', 'Pole 1 na farmie 1', '[[51.762844, 19.432226],[51.762849, 19.432398],[51.762732, 19.432391],[51.762727, 19.432223],[51.762844, 19.432226]]', 1, 1),
('Pole 2', 'Pole 2 na farmie 1', '[[54.352025, 18.646100],[54.352025, 18.646100],[54.352077, 18.646101],[54.352077, 18.646101],[54.352025, 18.646100]]', 1, 2),
('Pole 3', 'Pole 3 na farmie 1', '[[50.061430, 19.936568],[50.061430, 19.936568],[50.061430, 19.936568],[50.061430, 19.936568],[50.061430, 19.936568],[50.061430, 19.936568],[50.061430, 19.936568],[50.061430, 19.936568],[50.061430, 19.936568],[50.061430, 19.936568],[50.061430, 19.936568],[50.061430, 19.936568]]', 1, 3),
('Pole 4', 'Pole 4 na farmie 1', '[[49.986598, 19.913978],[49.986598, 19.913978],[49.986598, 19.913978],[49.986598, 19.913978],[49.986598, 19.913978],[49.986598, 19.913978],[49.986598, 19.913978],[49.986598, 19.913978],[49.986598, 19.913978],[49.986598, 19.913978],[49.986598, 19.913978],[49.986598, 19.913978]]', 1, 4),
('Pole 5', 'Pole 5 na farmie 1', '[[53.428543, 14.552765],[53.428543, 14.552765],[53.428543, 14.552765],[53.428543, 14.552765],[53.428543, 14.552765],[53.428543, 14.552765],[53.428543, 14.552765],[53.428543, 14.552765]]', 1, 5),
('Pole 6', 'Pole 6 na farmie 1', '[[52.230812, 21.011660],[52.230812, 21.011660],[52.230812, 21.011660],[52.230812, 21.011660],[52.230812, 21.011660]]', 1, 6),
('Pole 7', 'Pole 7 na farmie 2', '[[54.352025, 18.646100],[54.352025, 18.646100],[54.352077, 18.646101],[54.352077, 18.646101],[54.352025, 18.646100],[54.352025, 18.646100]]', 2, 7),
('Pole 8', 'Pole 8 na farmie 2', '[[51.762844, 19.432226],[51.762849, 19.432398],[51.762732, 19.432391],[51.762727, 19.432223],[51.762844, 19.432226],[51.762844, 19.432226],[51.762849, 19.432398],[51.762732, 19.432391],[51.762727, 19.432223]]', 2, 8),
('Pole 9', 'Pole 9 na farmie 2', '[[52.230812, 21.011660],[52.230812, 21.011660],[52.230812, 21.011660],[52.230812, 21.011660]]', 2, 9),
('Pole 10', 'Pole 10 na farmie 3', '[[49.986598, 19.913978],[49.986598, 19.913978],[49.986598, 19.913978],[49.986598, 19.913978],[49.986598, 19.913978],[49.986598, 19.913978]]', 3, 10),
('Pole 11', 'Pole 11 na farmie 3', '[[50.061430, 19.936568],[50.061430, 19.936568],[50.061430, 19.936568],[50.061430, 19.936568],[50.061430, 19.936568],[50.061430, 19.936568],[50.061430, 19.936568],[50.061430, 19.936568],[50.061430, 19.936568],[50.061430, 19.936568],[50.061430, 19.936568]]', 3, 11),
('Pole 12', 'Pole 12 na farmie 3', '[[53.428543, 14.552765],[53.428543, 14.552765],[53.428543, 14.552765],[53.428543, 14.552765],[53.428543, 14.552765],[53.428543, 14.552765]]', 3, 12);

INSERT INTO Garages (name,farm) VALUES ('garaz1',1), ('garaz2',1), ('garaz3',2);

INSERT INTO Storages(name,farm) VALUES ('magazyn1',1), ('magazyn2',1), ('magazyn3',2);

INSERT INTO Machine_types(type) VALUES ('Traktor'),('Kombajn zbo¿owy'), ('Opryskiwacz samojezdny'), ('£adowarka teleskopowa');

INSERT INTO Tool_types(type) VALUES ('Agregat uprawowy'),('Brona talerzowa'), ('Deszczownia'), ('Glebogryzarka'), ('Kopaczka do ziemniaków'), ('Kultywator'),('Mulczer'),('Opryskiwacz'), ('Prasa'), ('Przetrz¹sacz'), ('P³ug'), ('Przyczepa'), ('Przyczepa zbieraj¹ca'),('Rozsiewacz nawozów'), ('Rozrzutnik obornika'), ('Sadzarka'), ('Siewnik')   , ('Zbrabiarka');

INSERT INTO Resource_types (type) VALUES ('Oprysk grzybobójczy'), ('Oprysk owadobójczy'), ('Od¿ywka'), ('Nawóz');

INSERT INTO Machines (name, garage, mileage, type)
VALUES
('Traktor 1', 1, 200, 1),
('Traktor 2', 2, 250, 1),
('Kombajn 1', 1, 150, 2),
('Kombajn 2', 2, 180, 2),
('Opryskiwacz 1', 1, 70, 3),
('Opryskiwacz 2', 2, 100, 3),
('£adowarka 1', 1, 120, 4),
('£adowarka 2', 2, 140, 4),
('Traktor 3', 1, 210, 1),
('Kombajn 3', 1, 160, 2),
('Opryskiwacz 3', 1, 80, 3),
('£adowarka 3', 1, 130, 4),
('Traktor 4', 2, 260, 1),
('Kombajn 4', 2, 190, 2),
('Opryskiwacz 4', 2, 110, 3);

INSERT INTO Tools (name, garage, mileage, type)
VALUES
('Agregat 1', 1, 100, 1),
('Agregat 2', 2, 200, 1),
('Agregat 3', 3, 150, 1),
('Brona talerzowa 1', 1, 80, 2),
('Brona talerzowa 2', 2, 120, 2),
('Brona talerzowa 3', 3, 90, 2),
('Deszczownia 1', 1, 30, 3),
('Deszczownia 2', 2, 45, 3),
('Glebogryzarka 1', 1, 70, 4),
('Glebogryzarka 2', 2, 100, 4),
('Kopaczka do ziemniaków 1', 1, 40, 5),
('Kopaczka do ziemniaków 2', 2, 60, 5),
('Kultywator 1', 1, 110, 6),
('Kultywator 2', 2, 85, 6),
('Mulczer 1', 1, 75, 7),
('Mulczer 2', 2, 120, 7),
('Opryskiwacz 1', 1, 55, 8),
('Opryskiwacz 2', 2, 90, 8),
('Prasa 1', 1, 25, 9),
('Prasa 2', 2, 40, 9),
('Przetrz¹sacz 1', 1, 70, 10),
('Przetrz¹sacz 2', 2, 100, 10),
('P³ug 1', 1, 65, 11),
('P³ug 2', 2, 110, 11),
('Przyczepa 1', 1, 90, 12),
('Przyczepa 2', 2, 120, 12);

INSERT INTO Employees(name, [user]) VALUES ('pracownik1',1), ('pracownik2',1), ('pracownik3',1), ('pracownik4',1);

INSERT INTO Notes (name, description, field, start_date, finish_date, journal, type, value) VALUES ('notatka1', 'notatkaOpis1',1,'2023-01-01', '2023-06-20',1,1, NULL), ('notatka2', 'notatkaOpad',2,'2023-01-01', '2023-06-24',1,2,10);

INSERT INTO Activities(name, description, field, start_date, finish_date, journal, type, employee, machine, tool, value) VALUES 
('praca1', 'pracaOpis1',1,'2023-01-01', '2023-06-20',1,1,1,1,1,NULL), 
('praca2', 'pracaPodlewanie1',2,'2023-10-01', '2023-10-01',1,3,2,2,2,40), 
('praca3', 'pracaPodlewanie2',2,'2023-10-01', '2023-10-10',1,3,2,2,2,20);

GO
CREATE VIEW machinesView AS SELECT id, [name] FROM Machines;
GO
CREATE VIEW plantsView AS SELECT * FROM Plants;
GO
CREATE VIEW machine_typesView AS SELECT * FROM Machine_types;
GO
CREATE VIEW tool_typesView AS SELECT * FROM Tool_types;
GO
CREATE VIEW resource_typesView AS SELECT * FROM Resource_types;
GO
CREATE VIEW activity_typesView AS SELECT id, type FROM Activity_types;
GO
CREATE VIEW note_typesView AS SELECT id, type FROM Note_types;
GO
CREATE VIEW toolsView AS SELECT t.id,t.name,t.mileage,tt.type FROM Tools as t JOIN Tool_types as tt on t.type = tt.id; 
GO
CREATE VIEW activitiesView AS SELECT  name, description, start_date, finish_date, field, type, employee, machine, tool, id FROM Activities;
GO
CREATE VIEW notesView AS SELECT name, description, start_date, finish_date, field, id FROM Notes;
GO 
CREATE VIEW notesJournalEntriesView AS SELECT n.id, 0 as category, n.name as NoteName, n.start_date, n.finish_date, f.name as FarmName, nt.type, j.id as journalId FROM Notes as n JOIN Fields as f on n.field = f.id JOIN Journals as j on n.journal = j.id JOIN Note_types as nt ON n.type = nt.id;
GO
CREATE VIEW activitiesJournalEntriesView AS SELECT a.id, 1 as category, a.name as ActivityName, a.start_date, a.finish_date, f.name as FarmName, at.type, j.id as journalId FROM Activities as a JOIN Fields as f on a.field = f.id JOIN Journals as j on a.journal = j.id JOIN Activity_types as at ON a.type = at.id
GO
CREATE VIEW farmsView AS SELECT * FROM Farms;
GO
CREATE VIEW employeesView1 AS SELECT id, name FROM Employees WHERE [user] = 1;
GO
CREATE VIEW fieldsView1 AS SELECT fld.id, fld.[name], fld.[description], fld.coordinates, fld.plant, fld.farm FROM Fields as fld JOIN Farms AS frm ON frm.id = fld.farm;
GO
CREATE VIEW garagesView1 AS SELECT g.id, g.name, g.farm FROM Garages as g JOIN Farms as f on g.farm = f.id WHERE f.[user] = 1;
GO
CREATE VIEW storagesView1 AS SELECT s.id, s.[name], s.farm FROM Storages as s JOIN Farms AS frm ON frm.id = s.farm WHERE frm.[user] = 1;
GO
CREATE VIEW machinesView AS SELECT m.id, m.garage, m.name, m.mileage, mt.type, m.inspection_date, m.fuel FROM Machines as m JOIN Machine_types as mt ON m.type = mt.id JOIN Garages as g ON m.garage = g.id JOIN Farms as f ON g.farm = f.id;
GO
CREATE VIEW resourcesView1 AS SELECT r.id, rt.type, r.amount, st.id FROM Resources as r JOIN Resource_types as rt ON r.type = rt.id JOIN Storages as st ON r.storage = st.id JOIN Farms as f ON st.farm = f.id;

