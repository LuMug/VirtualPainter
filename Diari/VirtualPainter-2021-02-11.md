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
|12:30 - 15:45 ||

### Inserimento delle mani e dello script GetLeapFingers
Per prima cosa ho aggiunto alla mia parte di progetto le parti fatte da Karim durante la lezione precedente.
(Visualizzazione e utilizzo delle mani e lo script per vedere se la mano non dominante è girata).

##  Punto della situazione rispetto alla pianificazione



## Programma di massima per la prossima giornata di lavoro
### Zeno
Finire la paletta di colori.

### Karim
Finire salvataggio nuova tela e inizio azione disegno.
