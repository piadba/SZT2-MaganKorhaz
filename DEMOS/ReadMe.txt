=============================================================
**********=============16.04.09=============*****************
=============================================================
Máriusz 17:10

Lookup tábla: ide tároljuk a felsorolásokat, az ID-kat tároljuk a többi táblában (LookupID),
a Value ami a felületen megjelenik, a deleted a deleted, az objecttype pedig hogy milyen típusú elem.
Az objecttype majd lesz mindenféle állapot, meg tudomisén, vígan bõvíthetõ a tábla és jól lehet csoportosítani.

select * from LookUps where deleted=0 and ObjectType='UserGroup'

LookupId	Value			Deleted	ObjectType
----------------------------------------------------------	
1		Beteg			0	UserGroup
2		Orvos/Asszisztens	0	UserGroup
3		Ápoló			0	UserGroup
4		Gazdasági alkalmazott	0	UserGroup
5		Recepciós		0	UserGroup
6		Admin			0	UserGroup

Loginscreenen sikeres belépés után eltároljuk a usert, az példánynak lesz így egy csoportszáma (Group oszlop/Mezõ)
Attól függõen hogy mi a csoport, az õ képernyõje jelenik meg.

Admin van csak bent perpill, vele belépünk, és ami most kell, egy képernyõ, ahol tudunk hozzáadni más usert. (People tábla)
A usernek van
	- PeopleID : elvileg nem kell tölteni, mert inkrementális id
	- UserName : csak egy lehet belõle (leszarom, nem ez lesz az id)
	- Password : kell neki sima és confirm mezõ is a felületre, lehetõleg passwordbox-szal
	- Group    : combo, de ne az ID-k jelenjenek meg, hanem a value-k, viszont az ID-t szúrja rá a példányra
	- Deleted  : default 2 - mentésnél lesz csak 0, ergo felvitelnél: deleted alapból 2
							    mentésnél:	 savechanges és update 0-ra
                                                            törlésnél:	 1

A betegek mennek a beteg táblába, a többiek az alkalmazottakba.
Ha összeszeditek/szedjük miket akarunk eltárolni egy-egy dologról(betegrõl és alkalmazottról), akkor megcsinálom a táblákat, 
de elõször csak a People-be menjen, hogy legyen userünk!
=============================================================
*************************************************************
=============================================================
