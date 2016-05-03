truncate table ApoloMuszak;
truncate table Betegek;
truncate table Gyogyszer;
truncate table Idopontok;
truncate table KiadottGyogyszer;
truncate table KorhaziEszkoz;
truncate table KorhaziEszkozok_Fej;
truncate table Kortortenet_fej;
truncate table Kortortenet_tetel;
truncate table Lazlap;
truncate table People;

insert into People (UserName, [Password], Name, [Address], Phone, Email, Gender, [Group], Deleted) values('orvos', 'orvos', 'Orvos Oszkár', '1010. Mungo u. 1.', '06303030303', 'orvos@mungo.hu', 'férfi', 2, 0);
insert into People (UserName, [Password], Name, [Address], Phone, Email, Gender, [Group], Deleted) values('apolo', 'apolo', 'Ápoló Álmos', '1010. Mungo u. 2.', '06303030304', 'apolo@mungo.hu', 'férfi', 3, 0);
insert into People (UserName, [Password], Name, [Address], Phone, Email, Gender, [Group], Deleted) values('gazdalk', 'gazdalk', 'Gazdasági Gellért', '1010. Mungo u. 3.', '06303030305', 'gazdalk@mungo.hu', 'férfi', 4, 0);
insert into People (UserName, [Password], Name, [Address], Phone, Email, Gender, [Group], Deleted) values('recepcios', 'recepcios', 'Recepciós Rezeda', '1010. Mungo u. 4.', '06303030306', 'rec@mungo.hu', 'nő', 5, 0);
insert into People (UserName, [Password], Name, [Address], Phone, Email, Gender, [Group], Deleted) values('admin', 'admin', 'Admin Aladár', '1010. Mungo u. 5.', '06303030307', 'admin@mungo.hu', 'férfi', 6, 0);

insert into Idopontok (OrvosID, Datum, Deleted) values (1,'2016.05.03 16:00:00', 0);
insert into Idopontok (OrvosID, Datum, Deleted) values (1,'2016.05.03 17:00:00', 0);
insert into Idopontok (OrvosID, Datum, Deleted) values (1,'2016.05.03 18:00:00', 0);
insert into Idopontok (OrvosID, Datum, Deleted) values (1,'2016.05.03 19:00:00', 0);
insert into Idopontok (OrvosID, Datum, Deleted) values (1,'2016.05.03 20:00:00', 0);
insert into Idopontok (OrvosID, Datum, Deleted) values (1,'2016.05.04 16:00:00', 0);
insert into Idopontok (OrvosID, Datum, Deleted) values (1,'2016.05.04 17:00:00', 0);
insert into Idopontok (OrvosID, Datum, Deleted) values (1,'2016.05.04 18:00:00', 0);
insert into Idopontok (OrvosID, Datum, Deleted) values (1,'2016.05.04 19:00:00', 0);
insert into Idopontok (OrvosID, Datum, Deleted) values (1,'2016.05.04 20:00:00', 0);