# VirtualPainter | Diario di lavoro
##### Karim Galliciotti, Zeno Darani, Stefano Mureddu e Sara Bressan
### SAMT, 2021-02-25

## Lavori svolti

Link utili:


### Karim Galliciotti


|Orario        |Lavoro svolto                 |
|--------------|------------------------------|
|08:20 - 11:35 |File json che tiene in memoria i file creati |
|12:30 - 15:45 |Iniziato a pensare a come poter disegnare sulle texture, convertito valore da pixel a unity per altezza e larghezza immagine|

### Memoria file creati
Inizialmente quando cercavamo di salvare il percorso del file nella lista quando veniva creato veniva sollevata
una NullPointerException, causata dal metodo "JsonConvert.DeserializeObject" che cercava di raccogliere dei dati
dal file json vuoto e in seguito non riuscivamo ad aggiugere il percorso alla lista
dataci dallo stesso metodo. Per risolvere il tutto abbiamo visto che sarebbe stato più ottimale usare un Json array
contenente i percorsi creati con una classe apposita (Classe Paths, creata da noi, che contiene solamente l'attributo path)
aggiungerci il nuovo percorso e in seguito controllare che il file json non sia vuoto. Se esso è vuoto andiamo direttamente
salvarci la nuova path altrimenti usiamo "JsonConvert.DeserializeObject" che ritorna un Json array contenente tutti
i vecchi percorsi e ci aggiungiamo quello nuovo. A questo punto usiamo "JsonConvert.SerializeObject" e riscriviamo
il tutto nel file .json.

### Disegni su texture
Le seconde due ore le abbiamo passate a pensare e cercare ad un modo per poter disegnare sulle texture.
Inizialmente abbiamo trovato un tutorial di uno che usava una RawImage in un canvas, cosa che abbiamo provato
ad implementare ma cha abbiamo quasi subito scartato. Perciò siamo arrivati alla conclusione che avremmo sfruttato
le coordinate delle dita per assegnarle a determinati pixel sull'immagine. Per fare ciò dobbiamo però tener conto di
diversi fattori, come la grandezza in pixel dell'immagine. Difatti, visto che vorremmo avere sempre l'immagine
il più brande possibile, useremo una specie di "Zoom", ovvero se l'immagine è grande dovremmo tenere la texture
e molto più distante alla mainCamera e alla mani rispetto ad un immagine più piccola.  

### Covertire valori altezza e larghezza da pixel a valori di unity
Verso la fine mi sono occupato di convertire l'altezza e la larghezza in pixel inseriti alla creazione del file nei
valori usati in unity. Visto che cercando su internet abbiamo trovato che in genere 1 unità sono 100pixel abbiamo
tenuto questo rapporto.

### Zeno Darani


|Orario        |Lavoro svolto                 |
|--------------|------------------------------|
|08:20 - 09:50 | Risoluzione Bug e implementazione del ColorPicker|
|10:05 - 15:45 | Creazione della versione 3d del ColorPicker|

#### Risoluzione Bug e implementazione del ColorPicker

Come primo lavoro ho risolto un bug nella scelta del colore del colorpicker. Il problema consisteva che il primo colore una volta deselezionato non poteva più venir selezionato per modificarlo. Questo perchè essendo che era il pallino che clonavo per generare gli alrti mi sono dimenticato di aggiungergli il metodo ascoltatore, cosa che facevo con gli altri colori dentro un ciclo al momento della creazione. Dopodiché assieme a Sara abbiamo aggiunto il mio colorpicker al progetto principale aggiungendolo come accessorio da collegare al polso del braccio sinistro.

#### Creazione della versione 3d del ColorPicker

Ho iniziato quindi a lavorare su una versione tre dimensionale del colorpicker così da essere interagibile con le mani del leapmotion tramite al proprio sistema di interazione con gli oggetti. Al momento ho implementato uno slider 3 dimensionale funzionante formato da cubi. La parte che ha richiesto tanto tempo è stato a capire la struttura per gestire correttamente le interazioni con gli oggeti. Per il funzionamento dello script sarà solamente necessario adattarlo al cambiamento degli oggetti utilizzati ma la logica rimarrà la stessa. 


### Stefano Mureddu


|Orario        |Lavoro svolto                 |
|--------------|------------------------------|
|08:20 - 11:35 |Risolto un problema con Karim|
|12:30 - 15:35 |Iniziato a lavorare su come disegnare|

#### Risolto un problema con Karim

Con Karim bbiamo fatto si che si crei un file json con gli ultimi file aperti così da poter fare in futuro un'apertura rapida
Abbiamo un po litigato con il file json e qualche null pointer ex e con il file che si sovrascriveva male.

#### Iniziato a lavorare su come disegnare

Abbiamo iniziato a lavorare sulla parte più importante della applicazione, ma per far si che sia tutto a posto abbiamo dovuto adattare le varie grandezze dei fogli di lavoro.
La prossima lezione inizieremo a calcolare la posizione delle mani rispetto al foglio adattato alla finestra per disegnare nel punto giusto.


### Sara Bressan


|Orario        |Lavoro svolto                 |
|--------------|------------------------------|
|08:20 - 09:50 | Con Zeno abbiamo provato ad inserire il color picker nel progetto condiviso, essendo un Canvas e il progetto in 3D abbiamo dovuto cambiare la disposizione grafica degli oggetti.|
|10:05 - 11:35 | Risoluzione di errori inerenti al tracciamento della mano |
|12:30 - 15:45 | Tracking della mano e gestione dell'inventario|

#### Inserimento del color picker di Zeno nel progetto

#### Tracking per capire se la mano è girata oppure no
Inizialmente il tracking della mano "GetLeapFingers" creato da Karim non funzionava nella scena principale del nostro programma, siccome il programma alla partenza disattiva le mani che poi "GetLeapFingers" deve leggere. Poi però quando le mani compaiono nella scena questo problema scompare.
Inoltre mi sono accorta che alcuni pezzi del codice di Karim andavano in conflitto con il metodo "SetActive" utilizzato per nascondere le mani mentre viene mostrato il menù del gioco.
In seguito ho cambiato il quindi il codice in modo che controlli l'orientamento del palmo della mano (la y del palmo deve essere >= 0.6) a questo punto se il palmo è girato verso l'alto setto l'inventario come attivo (cioè visibile), altrimenti lo setto come non attivo (non visibile).

#### Tracking della mano
Ho scoperto che si può tracciare la mano utilizzando i metodi delle mani (vedi documentazione ufficiale "Ultraleap"), ed che esiste un metodo chiamato IsPinching che serve a vedere se il pollice e l'indice della mano si toccano, questo metodo tornerà utile in futuro.


## Errori


##  Punto della situazione rispetto alla pianificazione



## Programma di massima per la prossima giornata di lavoro
### Zeno
Concludere il ColorPicker a tre dimensioni e implementarlo nel progetto principale.

### Karim
Procedere con l'azione di disegno sulla tela


### Sara

