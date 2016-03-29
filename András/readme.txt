adatkezelõ alrendszer:

Az adatkezelõ alrendszer fõ eleme az AdatSzolgáltató osztály.
Ennek az a feladata, hogy az összes a rendszerhez kapcsolt adatbázisban szereplõ adattábla
minden adatát szolgáltassa a felsõbb rétegbeli osztályok számára.
Ennek módja, hogy ObservableCollection generikus kollekcióként az adattáblák rekordjait
leképezzük és ezen listákat publikus propertyként elérhetõvé tesszük.

Ezek az adattáblák a mi rendszerünkben szereplõ rögzített adatokat tartalmazzák.
Rendszerünk jellege indokolja ezt a felépítést, és láthatóvá teszi az adatbázis felépítését is.
A lista elemeit meghatározó osztályok teszik lehetõvé a kórházi rendszer mûködését.
Az adatbázis leképzése miatt minden osztályhoz felvettünk egy elsõdleges kulcs mezõt, 
<táblanév>ID típusa int.

A Beteg osztály a betegek nyilvántartásba vett adatainak szerkezetét írja le, ide értve a személyes adatokat: email, nem, név, születésiDátum, tajSzám, telefonszám.

Az Alkamazott osztály a kórházi dolgozók adatainak szerkeszetét írja le. Különös tekintettel a beosztás string típusú mezõre, amely meghatározza a kórházban betöltött funkcióját is.

A Hiba osztály az informatikus értesítésére szolgál, a rendszerben felmerült hibákról.
Tartalmaz a bejelentõID-t azaz információt arról, hogy melyik alkalmazott jelentette be a hibát.
 
A Szolgáltatás osztály a beteg által igényelt szolgáltatások adatait tartalmazza, ezzel teszi lehetõvé kórházunk minõségi szolgáltatását.

Az Idõpont osztály adatmezõiben tartjuk nyilván a betegek orvosoknál lefoglalt idõpontjait.
A dátum mezõ a napot azonosítja, az idõ mezõ meg a napon belüli idõpontot, ezenkívül nyilvántartjuk.

A Mûszak osztály az alkalmazottak munkaidõ beosztását segíti. A dátum mezõ határozza meg a kezdõidõpontot, a megjegyzés rovat egyéb információt nyújthat. 