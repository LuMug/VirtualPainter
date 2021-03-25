# VirtualPainter | Diario di lavoro
##### Karim Galliciotti, Zeno Darani, Stefano Mureddu e Sara Bressan
### SAMT, 2021-03-18

## Lavori svolti

Link utili:


### Karim Galliciotti


|Orario        |Lavoro svolto                 |
|--------------|------------------------------|
|8:20-15:00| |
|15:00-15:45| |

### Zeno Darani


|Orario        |Lavoro svolto                 |
|--------------|------------------------------|
|08:20 - 11:35 | Modifica struttura ColorPicker|
|12:30 - 15:45 | Modifica classe ColorPicker e implementazione|

#### Modifica struttura ColorPicker
Oggi ho iniziato a rielaborare la gestione dei colori della paletta del ColorPicker. Prima i colori erano situati sulla parte inferiore dello strumento, ma ciò si è rilevata una posizione scomoda da raggiungere. Allora ho optato per un piccolo ridesign dell'interfaccia spostando i colori a destra e mettendoli posizionati in una matrice. Quindi nello script ho dovuto solamente modificare la fase di posizionamento dei colori clonati. Poi ho iniziato a lavorare sulla selezione del colore attivo. Per fare questo ho assegnato lo script InteractionButton come componente del GameObject rappresentante il colore della paletta. In questo modo è possibile interagirvi con il sistema di interaction del leap motion.

#### Modifica classe ColorPicker e implementazione
Ho dovuto quindi apportare alcune modifiche al vecchio script dovute al nuovo metodo di interazione adottato. Finita la classe ho quindi esportato il pacchetto contenente il modello del ColorPicker con i suoi materiali, e lo script della classe ColorPicker. Poi con Sara lo abbiamo implementato nel progetto principale. Adesso è possibile selezionare il colore mentre si disegna, anche se ci sono ancora alcuni problemi da risolvere.

### Stefano Mureddu


|Orario        |Lavoro svolto                 |
|--------------|------------------------------|
|08:20 - 14:00 |Messo a posto la fase di disegno|
|14:00 - 15:45 |Creato script per salvare|


#### Disegno

Ad inizio lezione io e Karim abbiamo deciso di cambiare completamente il modo di disegnare. Dopo varie ricerche abbiamo deciso di utilizzare i raycast, ovvero dei vettori che in base a dove si trova la mano danno la coordinata sulla texture. Abbiamo passato quasi tutta la giornata a fare questo e alla fine siamo riusciti a far funzionare tutto :)

#### Script per salvare

Sempre con Karim abbiamo creato 2 script, uno per salvare il file, e l'altro per salvare il file con un nuovo nome. Abbiamo utilizzato il file json che avevamo creato precedentemente e lo script di salvataggio iniziale così da non perderci troppo tempo, e per utilizzare il json che altrimenti non avremmo utilizzato da nessuna parte.

### Sara Bressan


|Orario        |Lavoro svolto                 |
|--------------|------------------------------|
|08:20 - 09:50 | Creazione della funzione di rotazione della tela |
|10:05 - 11:35 | Creazione della funzione di Zoom della tela |
|12:30 - 15:45 | Integrazione del codice di Zeno e della tavolozza dei colori|

#### Rotazione della tela
Per gestire la rotazione della tela ho creato un nuovo script chiamato "Rotate".
All'interno di questa tela ho messo 3 metodi pubblici che ruotano la tela 
cambiando la rotazione con "tela.transform.Rotate(new Vector3(0, {rotazione} ,0));"

La tela è ruotabile anche premendo i bottoni Right e Left Arrow della tastiera 
e la barra spaziatrice (resetta la rotazione).

Questo script è stato aggiunto all'ActionController.

#### Zoom della tela
Per gestire lo Zoom della tela ho creato un nuovo script chiamato "Zoom".
All'interno di questa tela ho messo 3 metodi pubblici che avvicinano/allontanano la tela 
dalla telecamera così da ottenere un'effetto di zoom.
Questo script è stato aggiunto all'ActionController.

#### Manage Right Hand
Ho creato il nuovo script "ManageRight" che si occupa di gestire i movimenti della mano destra.
Usando la stessa metodologia di GetLeapFingers ManageRight è stato assegnato alla mano destra "RigidRoundHand_R" e tramite il controller leap Motion viene preso l'oggetto mano.
Dopo aver controllato che la mano esista nel contesto corrente e che sia effettivamente la mano destra viene salvata in una variabile la posizione della mano.
In seguito viene controllato se l'indice tocca il pollice:
- Se è vero la variabile pinch viene settata a true ed inoltre viene salvata la distanza tra le due dita.
- Se è falso controlla la rotazione della mano e a dipendenza di quanto è ruotata richiama il metodo RotateRight o RotateLeft della classe Rotate. Se la mano è a pugno chiuso la rotazione torna come era inizialmente con il metodo NormalizeRotation della classe Rotate.

Questa classe ha inoltre i tre metodi pubblici : IsHandPinching, GetPinchDistance,GetPalmNormal che ritornano le tre variabili settate in precedenza.

#### GetLeapFinger
Nel metodo GetLeapFinger creato in precedenza dopo aver controllato che la mano sinistra è effettivamente visibile controlla se entrambe le mani hanno il pollice e l'indice che si toccano (Pinching).
Se le dita si toccano allora viene controllata la distanza tra le due mani:
- Se la distanza è maggiore di 0.38 unità di Unity allora viene eseguito un ZoomOut
- Se la distanza è minore di 0.2 unità di Unity allore viene eseguito un ZoomIn

Vedi metodi pubblici della classe Zoom per ZoomIn e ZoomOut.

#### Integrazione della tavolozza dei colori

Ho inserito nel progetto la tavolozza di colori creata da Zeno con annesso codice.
Inoltre ho fatto in modo che cliccando l'apposito bottone colori dall'inventario la tavolozza sparisca e riappaia.

## Errori
A volte le mani vengono visualizzate erroneamente oppure al contrario: per 
sistemare questo problema bisogna pulire il sensore e/o ruotare
il LeapMotionController di 180°, controllando che sia posizionato su una 
superficie orizzontale.

##  Punto della situazione rispetto alla pianificazione



## Programma di massima per la prossima giornata di lavoro
### Zeno


### Karim


### Sara
