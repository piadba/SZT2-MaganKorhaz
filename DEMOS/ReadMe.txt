=============================================================
**********=============16.04.09=============*****************
=============================================================
M�riusz 17:10

Lookup t�bla: ide t�roljuk a felsorol�sokat, az ID-kat t�roljuk a t�bbi t�bl�ban (LookupID),
a Value ami a fel�leten megjelenik, a deleted a deleted, az objecttype pedig hogy milyen t�pus� elem.
Az objecttype majd lesz mindenf�le �llapot, meg tudomis�n, v�gan b�v�thet� a t�bla �s j�l lehet csoportos�tani.

select * from LookUps where deleted=0 and ObjectType='UserGroup'

LookupId	Value			Deleted	ObjectType
----------------------------------------------------------	
1		Beteg			0	UserGroup
2		Orvos/Asszisztens	0	UserGroup
3		�pol�			0	UserGroup
4		Gazdas�gi alkalmazott	0	UserGroup
5		Recepci�s		0	UserGroup
6		Admin			0	UserGroup

Loginscreenen sikeres bel�p�s ut�n elt�roljuk a usert, az p�ld�nynak lesz �gy egy csoportsz�ma (Group oszlop/Mez�)
Att�l f�gg�en hogy mi a csoport, az � k�perny�je jelenik meg.

Admin van csak bent perpill, vele bel�p�nk, �s ami most kell, egy k�perny�, ahol tudunk hozz�adni m�s usert. (People t�bla)
A usernek van
	- PeopleID : elvileg nem kell t�lteni, mert inkrement�lis id
	- UserName : csak egy lehet bel�le (leszarom, nem ez lesz az id)
	- Password : kell neki sima �s confirm mez� is a fel�letre, lehet�leg passwordbox-szal
	- Group    : combo, de ne az ID-k jelenjenek meg, hanem a value-k, viszont az ID-t sz�rja r� a p�ld�nyra
	- Deleted  : default 2 - ment�sn�l lesz csak 0, ergo felviteln�l: deleted alapb�l 2
							    ment�sn�l:	 savechanges �s update 0-ra
                                                            t�rl�sn�l:	 1

A betegek mennek a beteg t�bl�ba, a t�bbiek az alkalmazottakba.
Ha �sszeszeditek/szedj�k miket akarunk elt�rolni egy-egy dologr�l(betegr�l �s alkalmazottr�l), akkor megcsin�lom a t�bl�kat, 
de el�sz�r csak a People-be menjen, hogy legyen user�nk!
=============================================================
*************************************************************
=============================================================
