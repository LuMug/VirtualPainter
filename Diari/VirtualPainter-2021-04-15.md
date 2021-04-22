# VirtualPainter | Diario di lavoro
##### Karim Galliciotti, Zeno Darani, Stefano Mureddu e Sara Bressan
### SAMT, 2021-04-01

## Lavori svolti

Link utili:
- https://github.com/intuiface/LeapIA


### Karim Galliciotti


|Orario        |Lavoro svolto                 |
|--------------|------------------------------|
|8:20 - 11:45  | |
|12:35 - 15:45 ||


### Zeno Darani


|Orario        |Lavoro svolto                 |
|--------------|------------------------------|
|08:20 - 09:50 | Debuggato problema con ColorPicker|
|10:05 - 15:45 | Pulizia generale del codice|

#### Debuggato problema con ColorPicker

Oggi ho iniziato con il sistemare un bug nel ColorPicker. Il problema consisteva che quando il programma partiva
il primo colore aveva gli slider rappresentanti i suoi valori in una posizione diversa da quelle che divrebbero
essere in base al colore di default. In breve il colore di default [0,0,0,255] (Nero) aveva gli slider impostati
sui valori [0,0,0,0] (trasparente). Quindi per risolverlo ho aggiunto nel metodo start dello script ColorPicker.cs
una linea dove viene richiamato il metodo OnColorSelected che va ad aggiornare gli slider ed i suoi valori, solitamente
usato quando un colore viene selezionato dalla paletta.

#### Pulizia generale del codice

Poi ho aiutato Sara nel debuggare problemi inerenti alla gestione delle mani. Uno traquesti era che quando il programma partiva,
venivano create delle copie delle mani. Questo generava il problema che a volte lo script che gestisce le mani, attivava quelle 
clonate e non quelle originali. Perciò il menu non funzionava correttamente. Mi sono ricordato  quindi di una proprietà del
Hands Model, lo script che prende i dati dal HandController e aggiorna la posizione delle mani, chiamata "Can Duplicate".
L'abbiamo quindi disattivata ed effettivamente i cloni non sono più apparsi.

### Stefano Mureddu


|Orario        |Lavoro svolto                 |
|--------------|------------------------------|
|08:20 - 15:15 |Documentato e aiutato Karim|
|15:15 - 15:45 |Fatto il diario e tentato di finire quello che stavamo facendo|

#### Documentato
Durante la mattinata ho documentato le varie azioni di salvataggio e il ctrl+z, mentre nel pomeriggio la parte di disegno della tela(solo il disegno senza colore o strumento)

#### aiuto a Karim
Mentre documentavo ho aiutato Karim con i suoi lavori, prima abbiamo finito di mettere a posto l'azion ctrl+z creata da me in precedenza, che poi ho subito documentato, e successivamente abbiamo provato a risolvere il resize della tela. Sfortunatamente non siamo riusciti a risolverla visto che se le proporzioni cambiavano non si disegnava più giusto


### Sara Bressan


|Orario        |Lavoro svolto                 |
|--------------|------------------------------|
|08:20 - 15:45 | Debugging e ottimizzazione del codice |

Errore sistemato per la quale le mani non eseguivano nessuna azione siccome venivano creati dei cloni delle mani.
Soluzione: Nell'HandModel Manager delle mani l'impostazione "Can Duplicate" deve essere disattivata.

Errore: Quando la mano destra usciva dalla finestra le impostazioni del pennello venivano resettate
Soluzione: creazione di una variabile "brushValue" nella quale viene salvato il valore dello slide della dimensione del pennello,
il quale viene settato al rientro della mano nella finestra.

Errore: Non venivano captate le uscite e le entrate delle mani nella finestra.
Soluzione: Sia "ManageLeft" che "ManageRight" implementano "HandTransitionBehavior", a questo punto bisogna importare i due seguenti metodi:

- "HandReset" viene richiamato all'inserimento della mano nella scena
- "HandFinish" viene richiamato all'uscita della mano dalla scena

Errore: le texture è rotonda, quindi fuoriuscendo dai lati della texture mentre si colora si disegna nel lato opposto.

## Errori

- Cambio nome classe GetLeapFingers in ManageLeft.
- Eliminato PixelConverter(classe)


Problemi:      
- Tavola menu appare anche in assenza delle mani.
	Soluzione:
	- Un if nello script CheckHandsIn cha abbiamo inserito in HandsModel, questo if controlla se l'oggetto RigidRoundHand_L è null in questo caso nasconde il menù.
- Tela scalata in basso di un po' di pixel. -> Causa: Durante l'impostazione delle dimensioni della tela il MoveCanvas capta i click sul numpad della tastiera muovando la tela
	Soluzione:
	- Disattivare il MoveTela quando la tela non si vede.
-Rimozione rotazione con la mano che doventa possibile solamente coi tasti.  

##  Punto della situazione rispetto alla pianificazione


## Programma di massima per la prossima giornata di lavoro
### Zeno


### Karim


### Sara

Eseguire una build del programma di prova ed eseguire i test mancarti

### Stefano
