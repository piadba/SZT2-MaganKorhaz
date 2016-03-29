adatkezel� alrendszer:

Az adatkezel� alrendszer f� eleme az AdatSzolg�ltat� oszt�ly.
Ennek az a feladata, hogy az �sszes a rendszerhez kapcsolt adatb�zisban szerepl� adatt�bla
minden adat�t szolg�ltassa a fels�bb r�tegbeli oszt�lyok sz�m�ra.
Ennek m�dja, hogy ObservableCollection generikus kollekci�k�nt az adatt�bl�k rekordjait
lek�pezz�k �s ezen list�kat publikus propertyk�nt el�rhet�v� tessz�k.

Ezek az adatt�bl�k a mi rendszer�nkben szerepl� r�gz�tett adatokat tartalmazz�k.
Rendszer�nk jellege indokolja ezt a fel�p�t�st, �s l�that�v� teszi az adatb�zis fel�p�t�s�t is.
A lista elemeit meghat�roz� oszt�lyok teszik lehet�v� a k�rh�zi rendszer m�k�d�s�t.
Az adatb�zis lek�pz�se miatt minden oszt�lyhoz felvett�nk egy els�dleges kulcs mez�t, 
<t�blan�v>ID t�pusa int.

A Beteg oszt�ly a betegek nyilv�ntart�sba vett adatainak szerkezet�t �rja le, ide �rtve a szem�lyes adatokat: email, nem, n�v, sz�let�siD�tum, tajSz�m, telefonsz�m.

Az Alkamazott oszt�ly a k�rh�zi dolgoz�k adatainak szerkeszet�t �rja le. K�l�n�s tekintettel a beoszt�s string t�pus� mez�re, amely meghat�rozza a k�rh�zban bet�lt�tt funkci�j�t is.

A Hiba oszt�ly az informatikus �rtes�t�s�re szolg�l, a rendszerben felmer�lt hib�kr�l.
Tartalmaz a bejelent�ID-t azaz inform�ci�t arr�l, hogy melyik alkalmazott jelentette be a hib�t.
 
A Szolg�ltat�s oszt�ly a beteg �ltal ig�nyelt szolg�ltat�sok adatait tartalmazza, ezzel teszi lehet�v� k�rh�zunk min�s�gi szolg�ltat�s�t.

Az Id�pont oszt�ly adatmez�iben tartjuk nyilv�n a betegek orvosokn�l lefoglalt id�pontjait.
A d�tum mez� a napot azonos�tja, az id� mez� meg a napon bel�li id�pontot, ezenk�v�l nyilv�ntartjuk.

A M�szak oszt�ly az alkalmazottak munkaid� beoszt�s�t seg�ti. A d�tum mez� hat�rozza meg a kezd�id�pontot, a megjegyz�s rovat egy�b inform�ci�t ny�jthat. 