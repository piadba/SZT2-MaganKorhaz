create table Betegek(
	BetegID int IDENTITY(1,1) Primary Key,
	PeopleID int,
	TAJ varchar(7),
	Deleted smallint
);
create table Kortortenet_fej(
	KortortenetFejID int IDENTITY(1,1) Primary Key,
	BetegID int,
	Deleted smallint
);
create table Kortortenet_tetel(
	KortortenetTetelID int IDENTITY(1,1) Primary Key,
	KortortenetFejID int,
	Datum date,
	Orvos varchar(20),
	Kezeles varchar(200),
	Deleted smallint
);

insert into Betegek (PeopleID, TAJ, Deleted) values(18, '1234567', 0);
insert into Kortortenet_fej (BetegID, Deleted)values(1, 0);
insert into Kortortenet_tetel (KortortenetFejID, Datum, Orvos, Kezeles, Deleted) values (1, '2009.01.01', 'Orvos1', 'Elso kezeles',  0);

insert into Betegek (PeopleID, TAJ, Deleted) values(19, '2345678', 0);
insert into Kortortenet_fej (BetegID, Deleted)values(2, 0);
insert into Kortortenet_tetel (KortortenetFejID, Datum, Orvos, Kezeles, Deleted) values (2, '2012.01.01', 'Orvos2', 'Elso kezeles2',  0);