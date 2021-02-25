# VirtualPainter | Diario di lavoro
##### Karim Galliciotti, Zeno Darani, Stefano Mureddu e Sara Bressan
### SAMT, 2021-02-25

## Lavori svolti

Link utili:


### Karim Galliciotti


|Orario        |Lavoro svolto                 |
|--------------|------------------------------|
|08:20 - 09:50 | |
|10:05 - 11:35 | |
|12:30 - 14:00 | |
|14:15 - 15:45 | |


### Zeno Darani


|Orario        |Lavoro svolto                 |
|--------------|------------------------------|
|08:20 - 14:00 | |
|14:15 - 15:45 | |



### Stefano Mureddu


|Orario        |Lavoro svolto                 |
|--------------|------------------------------|
|08:20 - 11:35 |Risolto un problema con Karim|
|12:30 - 15:35 |Iniziato a lavorare su come disegnare|

####Risolto un problema con Karim
Con Karim bbiamo fatto si che si crei un file json con gli ultimi file aperti così da poter fare in futuro un'apertura rapida
Abbiamo un po litigato con il file json e qualche null pointer ex e con il file che si sovrascriveva male.

####Iniziato a lavorare su come disegnare
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


### Karim


### Sara

