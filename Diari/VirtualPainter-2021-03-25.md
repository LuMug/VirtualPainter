# VirtualPainter | Diario di lavoro
##### Karim Galliciotti, Zeno Darani, Stefano Mureddu e Sara Bressan
### SAMT, 2021-03-25

## Lavori svolti

Link utili:
- Icone: https://www.flaticon.com/search?word=fill
- FloodFill: https://gist.github.com/ProGM/22a615b812c5a9f1183d43b536d14a42

### Karim Galliciotti


|Orario        |Lavoro svolto                 |
|--------------|------------------------------|
|8:20 - 15:45  | Azione riempimento|

### Riempimento

Mi sono occupato della realizazzione dell'azione di riempimento. Prima di tutto ho fatto delle ricerche per vedere se esistesse qualcosa che faccia già questa azioni, ma senza risultati mi sono ritrovato a cercare di capire come funzionano gli algoritimi di riempimento. Dopo varie ricerche mi sono imbattuto in una pagina Github che mette a disposizione il suo codice, perciò ho prima cercato di capire il funzionamento di quest'ultimo e di seguito l'ho adattato al nostro codice.

### Problemi

Il codice preso funziona bene solamente con immagini di piccole dimensioni poichè guarda un pixel per volta mettendoci un'infinità di tempo, perciò bloccando tutto il programma. Per risolvere ciò teoricamente bisognerebbe rendere più veloce il tutto facendogli controllare più pixel per volta magari usando le Thread.


### Zeno Darani


|Orario        |Lavoro svolto                 |
|--------------|------------------------------|
|10:05 - 14:00 | Ridimensionamento del pennello|
|14:15 - 15:45 | Documentazione|

#### Ridimensionamento del pennello

Sono arrivato in classe e mi sono consultato con i miei compagni di progetto per fare il quadro della situazione. Dunque ho scelto di aiutare Sara con la funzionalità di ridemnsionamento del pennello. Lei ha creato la parte grafica composta da uno slider con componente InteractionSlider, lo stesso che ho usato per i valori RGB del ColorPicker. Io mi sono occupato di modificare lo script DrawRaycast in modo di poter disegnare utilizando la dimensione del pennello assegnata dallo slider. Il funzionamento è molto simile a quello presente nello script ColorPIcker. In pratica alla classe DrawRaycast è stata aggiunta la proprietà BrushSizeSlider alla quale verrà assegnato il riferimento allo slider dall'editor di Unity. Quindi ho creato il metodo UpdateBrushSize(float value) che permette di aggiornare la dimensione del pennello in base al valore passato come argomento. La dimensione del pennello viene calcolata come: value * MAX_BRUSH_SIZE, dove value è compreso nel range [0;1] e MAX_BRUSH_SIZE è una costante che corrisponde alla dimensione massima del pennello. Se la dimensione calcolata risulta minore di 1 viene impostata a 1. Poi ho testato assieme a Sara il funzionamento dello script con lo slider.

### Stefano Mureddu


|Orario        |Lavoro svolto                 |
|--------------|------------------------------|
|08:20 - 14:00 |Documentato e aiutato chi aveva bisogno	|
|14:15 - 15:45 |Fatto i diari|


#### Documentato

Ho passato quasi tutta la giornata a documentare e ad aiutare chi aveva bisogno. Le parti che ho documentato sono quelle sulla creazione della tela come l'aggiunta della texture o il ridimensionamento.
Ogni tanto ho aiutato Karim con dei piccoli problemi oppure ho assistito ad un paio di dimostrazioni di Sara.

#### Diari

Ho recuperato il diario di settimana scorsa e fatto quello di questa. Durante il resto del tempo ho discusso con Zeno dell'andamento e del futuro del progetto.


### Sara Bressan


|Orario        |Lavoro svolto                 |
|--------------|------------------------------|
|08:20 - 15:45 | Creazione degli strumenti (gomma, penna e filler)|

#### Menù degli strumenti

Ho creato degli interaction buttons e uno slider, i 3 bottoni servono ad attivare le 3 tre funzionalità:
penna, gomma e filler, mentre lo slider gestisce la gradezza della gomma e della penna.

#### Integrazione del gestore della dimensione del pennello

Nello script ManageRight ho inserito i metodi creati da Zeno per la gestione della grandezza della penna.

#### Creazione del InfoPanel

Ho creato un pannello che mostra i comandi principali per l'utilizzo dell'applicazione,
questo menù è visibile selezionando il tasto "i" e diventa invisibile utilizzando la stessa
modalità.

## Errori

Il colore e la dimensione di default venivano messi ogni volta che si toglieva e si inseriva la mano destra,
per rimuovere questo problema ogni volta che viene inserita la mano nuovamente vengono settati i valori
presi dallo slider per la gestione della dimensione del pennello e l'ultimo colore utilizzato.


##  Punto della situazione rispetto alla pianificazione

Il cambio di strumenti funziona, è possibile salvare il disegno e disegnare con vari colori, inoltre
si può cancellare il disegno.

## Programma di massima per la prossima giornata di lavoro
### Zeno


### Karim


### Sara
