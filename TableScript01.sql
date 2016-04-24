IF OBJECT_ID('KiadottGyogyszer') IS NOT NULL drop table KiadottGyogyszer
create table KiadottGyogyszer(
	KiadottGyogyszer int identity(1,1) primary key,
	ForrasID int,
	GyogyszerID int,
	Mennyiseg int,
	Statusz int,
	Datum datetime,
	Deleted tinyint
)

IF OBJECT_ID('Gyogyszer') IS NOT NULL drop table Gyogyszer
create table Gyogyszer(
	GyogyszerID int identity(1,1) primary key,
	Megnevezes varchar(200),
	Hatoanyag varchar(200),
	Mennyiseg int,
	Egyseg varchar(20),
	EgysegMennyiseg int,
	Deleted tinyint
)

IF OBJECT_ID('Lazlap') IS NOT NULL drop table Lazlap
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

IF OBJECT_ID('KorhaziEszkozok_Fej') IS NOT NULL drop table KorhaziEszkozok_Fej
create table KorhaziEszkozok_Fej(
	Eszkoz_FejID int identity(1,1) primary key,
	Megnevezes varchar(200),
	Deleted tinyint
)

IF OBJECT_ID('KorhaziEszkoz') IS NOT NULL drop table KorhaziEszkoz
create table KorhaziEszkoz(
	EszkozID int identity(1,1) primary key,
	Eszkoz_FejID int,
	Megnevezes varchar(200),
	Statusz bit,
	Deleted tinyint
)

IF OBJECT_ID('Idopontok') IS NOT NULL drop table Idopontok
create table Idopontok(
	IdopontID int identity(1,1) primary key,
	BetegID int,
	OrvosID int,
	Datum datetime,
	Deleted tinyint,
)

IF OBJECT_ID('ApoloMuszak') IS NOT NULL drop table ApoloMuszak
create table ApoloMuszak(
	ApoloMuszakID int identity(1,1) primary key,
	PeopleID int,
	StartDate datetime,
	EndDate datetime,
	Deleted tinyint
)