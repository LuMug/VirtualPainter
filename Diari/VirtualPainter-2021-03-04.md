# VirtualPainter | Diario di lavoro
##### Karim Galliciotti, Zeno Darani, Stefano Mureddu e Sara Bressan
### SAMT, 2021-02-25

## Lavori svolti

Link utili:


### Karim Galliciotti


|Orario        |Lavoro svolto                 |
|--------------|------------------------------|
|8:20-15:00| Script che mostra la tela alle sue massime dimensioni|
|15:00-15:45| Integrato lo script per le dimensioni della tela nella build di Sara e iniziato lo script per l'uscita dall'applicazione|

### Scalatura tela

Inizialmente l'dea per avere la tela alle sue dimensioni massime era quella di avvicinarla o allontanarla dalla mainCamera.
Idea in seguito scartata verso la fine dell prime due ore avendo pensato ad un modo più semplice e meno macchinoso, ovvero solamente di scalare le dimensioni della tela tenendola sempre nello stesso posto. 
Inizialmente lo script creato scalava l'immagine invertendo altezza e larghezza e dopo averci indagato un bel po' abbiamo scoperto che nel codice che le assegnava alla texture da creare gliele forniva al contrario, 
ovvero altezza al posto di larghezza e viceversa. 
Dopo averli assegnati
nel modo giusto la tela veniva scalata nel modo corretto sia durante la creazione che all'importazione di un file, anche se solo con una risoluzione di 16:9.

### Exit

L'idea è quella di far uscire una finestra che chieda all'utente se vuole uscire salvando, senza salvare oppure di annullare l'uscita.
Per intanto abbiamo solamente implementato il codice che va a prendere il file corrente andandolo a salvare e Sara ha cominciato a creare la finestra.


### Zeno Darani


|Orario        |Lavoro svolto                 |
|--------------|------------------------------|
|08:20 - 11:35 | Creazione del modello del nuovo ColorPicker |
|12:30 - 15:45 | Riadattamento dello script|

#### Creazione del modello del nuovo ColorPicker

Oggi ho continuato a lavorare sulla nuova versione del ColorPicker. Come prima cosa ho ricostruito la struttura del vecchio ColorPicker utilizzando componenti tre dimensionali. Infatti il nuovo ColorPicker come base non usa più un pannello 2d ma un parallelepipedo rettangolo. Per la parte sopra con gli slider ho preso dei modelli già fatti dagli esempi e li ho riscalati e riadattati. Da parte ad ogni slider ci sono i valori numerici che essi rappresentano. Sotto ho inserito un cubo che rappresenta il colore selezionato.

#### Riadattamento dello script

Per la parte di scripting ho dovuto riadattare i metodi utilizzando le nuove componenti (Un GameObject generico al posto dell'immagine che rappresenta il colore, InteractiveSlider del LeapMotion al posto degli slider standard di Unity, TextMesh al posto di Text per la rappresentazione numerica del colore). Per la prima versione avevo aggiunto agli slider un metodo ascoltatore usando:

```markdown
SliderRed.onValueChanged.AddListener(OnChangedRed);
```
Adesso ho dovuto utilizzare questo altro metodo che necessita la creazione di un oggetto Action. Questo tipo di oggetto serve a richiamare il codice contenuto in un determinato metodo. Viene utilizzato nel sistema di eventi di unity. Infatti per la nuova versione del ColorPicker ho usato:
```markdown
SliderRed.HorizontalSlideEvent = new Action<float>(OnChangedRed);
```
In questa linea di codice si assegna un'azione da eseguire quando l'HorizontalSlideEvent verrà triggerato. Il <float> sta ad indicare che il metodo OnChangeRed ha un metodo che si aspetta un parametro di tipo float, che in questo caso è il valore attuale dello slider. Il valore è fornito dall'evento.


### Stefano Mureddu


|Orario        |Lavoro svolto                 |
|--------------|------------------------------|
|08:20 - 11:35 |Documentazione|
|12:30 - 15:35 |Completata conversione da pixel a unità e scala|

#### Documentazione

Ho passato la mattina a documentare parti già completate e a dare supporto e aiutare quando un compagno aveva bisogno.
Ho finito di documentare creazione file, la prova LeapMotionController e il tracciamento mani.

#### Completata conversione da pixel a unità e scala

Per scalare da pixel inseriti nei form a le unità per la grandezza fisica della tela lavorando con Karim abbiamo trovato un metodo di conversione e trovando l'errore siamo riusciti a risolvere tutto con successo.
Nell'ultima ora abbiamo inoltre iniziato a lavorare sul salva ed esci.


### Sara Bressan


|Orario        |Lavoro svolto                 |
|--------------|------------------------------|
|08:20 - 11:35 | Aggiunta delle azioni al click dei bottoni dell'inventario|
|12:30 - 15:17 | Mi sono documentata cercando il modo di disegnare e ho effettuato l'integrazione del codice scritto da Karim e Stefano nel progetto iniziale|
|15:17 - 15:45 | Creazione dell'interfaccia utente per il salvataggio e l'uscita dal programma.|


#### Aggiunta delle azioni al click dei bottoni dell'inventario

Ho creato per ogni bottone uno script dedicato, il quale utilizzando "isPressed" ascolta se il 
bottone viene cliccato con la mano destra.
Nel caso in cui venga cliccato ogni bottone fa una diversa azione.

##### Exit

Il bottone di uscita utilizza lo script "Esci", il quale se il bottone viene cliccato esegue la seguente azione:
Application.Quit(); che serve a chiudere l'applicazione.

##### Impostazioni

Lo script "OpenImpostazioni" assegnato al bottone delle impostazioni nasconde mani e tela e mostra il GameObject
"Configurazione_Tela" tramite il quale si possono modificare le dimensioni della tela.

#### Errore

Inizialmente quando si cliccavano i tasti con la mano destra non succedeva nulla, dopo aver investigato 
in cerca dell'errore durante la mattinata ho scoperto che "Contact Enabled" era disattivato nell'Interaction Hand 
della mano destra, una volta attivato il flag i bottoni hanno iniziato a funzionare correttamente.

#### Disegno

Per disegnare ho creato uno script nominato "Draw" e l'ho assegnato al RigidRoundHand_R, il codice in questione 
per ora notifica solamente se il dito indice e il pollice della mano destra si stanno toccando (isPinching).

#### Integrazione codice

Ho aggiunto al progetto principale i codici creati da Karim e Stefano per la creazione della tela in scala:
Attenzione!!! Il gioco deve avere risoluzione schermo di 16:9 altrimenti la tela non ricopre l'intera schermata del programma.

#### Creazione del Menù UI per l'uscita e il salvataggio dal programma

Questa UI è visualizzabile quando si clicca il pulsante esci dell'inventario.

## Errori


##  Punto della situazione rispetto alla pianificazione



## Programma di massima per la prossima giornata di lavoro
### Zeno


### Karim
Completare l'uscita e ottimizzare la scalatura in modo che funzioni con qualunque tipo di risoluzione.

### Sara
