create table Betegek(
	BetegID int IDENTITY(1,1) Primary Key,
	PeopleID int,
	TAJ varchar(7),
	Deleted smallint
);
create table Koortortenet_fej(
	KoortortenetFejID int IDENTITY(1,1) Primary Key,
	BetegID int,
	Deleted smallint
);
create table Koortortenet_tetel(
	KoortortenetTetelID int IDENTITY(1,1) Primary Key,
	KoortortenetFejID int,
	Datum date,
	Orvos varchar(20),
	Kezeles varchar(200),
	Deleted smallint
);

insert into Betegek (PeopleID, TAJ, Deleted) values(18, '1234567', 0);
insert into Koortortenet_fej (BetegID, Deleted)values(1, 0);
insert into Koortortenet_tetel (KoortortenetFejID, Datum, Orvos, Kezeles, Deleted) values (1, '2009.01.01', 'Orvos1', 'Elso kezeles',  0);