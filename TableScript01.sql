drop table KiadottGyogyszer
create table KiadottGyogyszer(
	LazlapGyogyszerID int identity(1,1) primary key,
	ForrasID int,
	GyogyszerID int,
	Mennyiseg int,
	Statusz int,
	Datum datetime,
	Deleted tinyint
)
drop table Gyogyszer
create table Gyogyszer(
	GyogyszerID int identity(1,1) primary key,
	Megnevezes varchar(200),
	Hatoanyag varchar(200),
	Mennyiseg int,
	Egyseg varchar(20),
	EgysegMennyiseg int,
	Deleted tinyint
)
drop table Lazlap
create table Lazlap(
	LazlapID int identity(1,1) primary key,
	BetegID int,
	OrvosID int,
	ApoloID int,
	OrvosMegjegyzes varchar(max),
	ApoloMegjegyzes varchar(max),
	UtolsoFelvetelDatum datetime,
	Statusz int,
	Deleted tinyint
)