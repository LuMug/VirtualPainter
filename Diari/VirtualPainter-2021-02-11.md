# VirtualPainter | Diario di lavoro
##### Karim Galliciotti, Zeno Darani, Stefano Mureddu e Sara Bressan
### SAMT, 2021-02-11

## Lavori svolti

Link utili:
-https://developer-archive.leapmotion.com/documentation/v2/unity/devguide/Leap_Gestures.html

-https://unitycoder.com/blog/2015/11/04/leap-motion-get-finger-position-direction/

-https://developer-archive.leapmotion.com/documentation/csharp/devguide/Leap_Hand.html


### Karim Galliciotti


|Orario        |Lavoro svolto                 |
|--------------|------------------------------|
|08:20 - 09:50 | Importato script sulla build principale e implementato creazione foglio|
|10:05 - 11:35 | Implementato creazione foglio, cominciato salvataggio foglio, cominciato caricamento foglio|
|12:30 - 14:00 | Continuato salvataggio foglio, implementato caricamento foglio|
|14:15 - 15:45 | Continuato salvataggio foglio|

#### Creazione foglio
 Io e Stefano abbiamo sistemato lo script "CreateFile" e aggiunto il codice necessario 
 allo script "ShowMenu" per poter nascondere i menu e mostrare la tela.
 
 Per mostrare la tela si deve aggiungere come componente all'ActionController lo script
 "CreateFile"  e passargli come riferimenti "Input Altezza", "Input Larghezza" (Campi di testo),
 "Tela Disegnabile" (Il piano che rappresenta la tela) e "Continua" (Il pulsante continua).
 
Con Zeno ho sistemato il fatto che provando a creare un nuovo foglio quest'ultimo non assumeva il colore richiesto.
 Per fare ciò abbiamo creato un nuovo materiale e gli abbiamo assegnato la shader di default per gli sprite. Così facendo Siamo riusciti a presentare una tela bianca.
 
Ho modificato lo script "CreateFile" per poter consentire all'utente di salvare il file dove vuole, tenendo conto di tutti i fogli creati dall'utente su un file json. Purtroppo cercando di fare ciò mi sono non sono riuscito ad andare avanti perché ho avuto dei problemi con il namespace di "Newton.Json".

#### Caricamento foglio esistente
 Per caricare un foglio già esistente ho creato un nuovo script chiamato "GetFile"
 usato il modello fatto da Zeno, "FileManager", che contiene
 tutti i metodi necessari per salvare e ricavare una texture.
 All'interno del mio script ho fatto in modo che quando l'utente decide di caricare un foglio
 già esitente si apra il file explorer del sistema operativo che gli consentirà di scegliere
 solamente un'immagine.



### Zeno Darani


|Orario        |Lavoro svolto                 |
|--------------|------------------------------|
|08:20 - 14:00 | Creazione ColorPicker|
|14:15 - 15:45 | Aggiunta della paletta di colori al ColorPicker|

#### Creazione ColorPiker
Oggi ho lavorato alla funzione della selezione del colore. Ho iniziato creando la parte grafica composta da un canvas contenente un immagine a forma circolare che rappresenterà il colore selezionato, e quattro slider per rappresentare le tonalità di rosso, verde, blu e alpha (trasparenza). Ho quindi creato lo script ColorPicker per gestire il cambio del coore tramite l'utilizzo degli slider. Infatti all'interno dello script ci sono dei metodi ascoltatori degli slider che quando cambiano il loro valore vanno a modificare la tonalità del colore dell'immagine. Dopodiche ho aggiunto a fianco ad ogni slider un campo di testo che contiene il valore della tonalità nel range tra [0;255].

#### Aggiunta paletta di colori
Verso le 14:00 sono passato alla creazine della paletta di colori, ovvero ulteriori colori da tenere salvati mentre si disegna. Per farlo ho suddiviso il canvas iniziale in due con un GridLayout così da ottenere una seconda sezione sotto. In questa sezione ho fatto una copia dell'immagine che indica il colore selezionato e nel metodo start del ColorPicker  che viene eseguito all'inizo dello script ne creo altre 12 copie così da averene una lista che rappresenterà la paletta.

### Stefano Mureddu


|Orario        |Lavoro svolto                 |
|--------------|------------------------------|
|08:20 - 09:50 |Implementazione script nel progetto|
|10:05 - 11:35 |Documentazione progettazione|
|12:30 - 14:00 |Rifiniture script + documentazione|
|14:15 - 15:45 |Aiuto a Karim + diario|

### Implementazione script
All'inizio ho preso lo script creato la scorsa volta e lo ho implementato nel programma sul pc di Karim. Abbiamo avuto qualche difficoltà data dal fatto che non avevo riferimenti uguali quando lo ho creato sulla mia macchina, tuttavia siamo riusciti a far si che funzionasse.
### Documentazione progettazione
Successivamente ho documentato alcuni aspetti della progettazione come il design delle interfacce e quello dell'architettura.
### Rifiniture script e documentazione
Nel pomeriggio insieme a Karim ho provato a mettere a posto qualche problemino con lo script che era sorto nella mattinata e poi ho documentanto una prima parte dell'implmementazione.
### Aiuto a Karim e diario
L'ultima ora e mezza la ho passata a fare il diario e ad aiutare Karim con quello che stava facendo.




### Sara Bressan


|Orario        |Lavoro svolto                 |
|--------------|------------------------------|
|08:20 - 09:50 | Mi sono informata su come creare le interazioni tra interfaccia grafica e LeapMotion Controller.|
|10:05 - 11:35 | Integrazione del codice di tutti i componenti del team nella scena principale e interfaccia grafica dell'inventario. Integrazione dell'inventario se la mano non dominante è girata.|
|12:30 - 15:45 | Fine della creazione dell'inventario, inserimento dei nuovi elementi creati dal resto del gruppo|

Link utili: https://leapmotion.github.io/UnityModules/interaction-engine.html

Per prima cosa ho impostato il timestep a 0.0111111 (90 frames/secondo) come consigliato dalla documentazione 
del Leap Motion Controller.
Queste impostazioni sono state cambiate in "Edit -> Project Settings -> Time".

### Creazione della tela disegnabile

Per prima cosa ho creato nella scena principale un piano che fungerà da tela disegnabile (si chiama anche "TelaDisegnabile") esattamente come è stata creata dai miei compagni.
La posizione di questo GameObject è x = 0, y = 0 e z = 140.
La rotazione corrisponde a x = 90, y = 180 e z = 0.
La scala iniziale è di x = 12, y = 14 e z = 12.

### Spostamento della main camera

Per poter visualizzare sia le mani che la tela contemporaneamente ho messo la "Main Camera", cioè la telecamera principale in posizione x = 0, y = 0 e z = 3.066 .


### Aggiunta delle mani

#### HandsModel

In seguito ho aggiunto le due mani create da Karim la lezione precedente (l'HandsModel e il LeapHandCOntroller  -> Vedi diario di Karim della scorsa lezione) all'interno di un GameObject vuoto chiamato "Hands".
La posizione di questo GameObject è x = -1.04, y = 0 e z = -0.04 .

#### Attachment Hands

All'interno del HandsModel ho inserito il prefab "Attachment Hands" che si trova nel progetto in 
"Assets/Plugins/LeapMotion/Core/Prefabs".
All'interno di questo Prefab si trovano i due Attachment Hand (Left e Right), uno per la mano sinistra e uno per la mano destra.
La mano destra non viene per ora modificata, mentre nella mano sinistra ho inserito un GameObject chiamato "Palm Forward Transform", il quale verrà utilizzato in seguito come target (per indicare la posizione della mano - del palmo).

Il codice seguente è stato implementato grazie alla seguente guida : https://leapmotion.github.io/UnityModules/interaction-engine.html .

In seguito ho inserito il GameObject "Palm UI Pivot Animation", il quale dovrebbe gestire la rotazione della mano per gestire la visualizzazione (o la non visualizzazione) dell'inventario (però non funziona -> bisogna sistemare le cordinate lette dalla mano).
All'interno del GameObject appena creato ho messo due GameObject (Hidden e Visible) contenenti le cordinate che indicano la posizione per la quale l'inventario si vede e le cordinate per la quale l'inventario non si vede.
"Palm UI Pivot Animation" ha al suo interno lo script "Transform Tween Behaviour" fornito dal Package scaricato in precedenza del LeapMotion Controller, le proprietà inserite sono:
	- Target transform: Palm Forward Transform (GameObject creato in precedenza)
	- Start Transform: Hidden
	- End Transform: Visible
	- Le altre impostazioni sono quelle di default.

Dopo aver eseguito i passaggi precedenti ho creato il "Palm UI Pivot Anchor" il quale andrà a contenere la grafica dell'inventario e al suo interno ha lo script "Simple Facing Camera Callbacks" il quale ha le seguenti caratteristiche:
	- To face camera: Palm Forward Transform
	- Camera to face: none
	- On Begin Facing Camera(): -> Runtime Only -> Palm UI Pivot Animation -> TranformTweenBehaviour.PlayForward
	- On End Facing Camera(): -> Runtime Only -> Palm UI Pivot Animation -> TranformTweenBehaviour.PlayBackward

All'interno di questo contenitore ho messo il GameObject "Palm UI" avente lo script "Ignore Collisions In Children" che serve a prevenire collisioni tra gli elementi della UI.
Dentro "Palm UI" ho inserito un GameObject chiamato "Button Panel" che corrisponde all'inventario.
Dentro l'inventario ho inserito una serie di bottoni 3d (6 bottoni con immagini diverse per ogni funzione dell'inventario) creati con dei cubi alla quale è stato assegnato lo script "Interaction Button" (Script del Package del LeapMotion), il Manager indicato delle proprietà dello script corrisponde all'InteractionManager (vedi capitoli seguenti).

#### InteractionManager

All'interno dell'HandModel ho creato il GameObject "IntercationManager" inserendo al suo interno lo script "Interaction Manager" e lasciando le impostazioni di default, in seguito all'interno del GameObject appena creato ho inserito i Prefab:
	- Interaction Hand Left
	- Interaction Hand Right
entrambe queste Prefab sono trovabili nel progetto in "Assets/Plugins/LeapMotion/Modules/InteractionEngine/Prefabs/Interaction Controllers".

#### Inserimento degli scripts nell'ActionController

Nel GameObject "ActionController" creato la scorsa settimana ho apportato i seguenti cambiamenti:

- Modificato lo script "ShowMenu" aggiungendo come parametri in entrata "Hands" e "TelaDisegnabile", nel metodo Start dello script questi due GameObject sono stati impostati come non attivi. (Così non si vedono in contemporanea con il menù iniziale).

- Aggiunta dello script "Startdrawing" che serve a disattivare i menù iniziali (Start_Page e impostazioni) e,  a mostrare mani e tela quando si pigia il bottone "Continua" oppure il bottone "FoglioEsistente".

- Aggiunta dello script "CreateFile" creato da Karim (vedi Diario di Karim).

- Aggiunta dello script "GetFile" creato da Zeno (vedi Diario di Zeno).


## Errori


##  Punto della situazione rispetto alla pianificazione



## Programma di massima per la prossima giornata di lavoro
### Zeno
Finire la paletta di colori.

### Karim
Finire salvataggio nuova tela e inizio azione disegno.

### Sara
Finire l'inventario e sistemare gli errori per la quale l'inventario si vede anche se la mano non è girata.
