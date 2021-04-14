# VirtualPainter | Diario di lavoro
##### Karim Galliciotti, Zeno Darani, Stefano Mureddu e Sara Bressan
### SAMT, 2021-04-01

## Lavori svolti

Link utili:
- Ctrl-z: https://stackoverflow.com/questions/3944552/undo-for-a-paint-program


### Karim Galliciotti


|Orario        |Lavoro svolto                 |
|--------------|------------------------------|
|8:20 - 11:45  | Risoluzione errori, test e ottimizzazione dell'applicazione|
|12:35 - 15:45 |ctrl+z|

Vedi punto errori

### Ctrl+z
Il pomeriggio ho aiutato Stefano a far funzionare il ctrl+z. Non siamo riusciti a farlo perfettamente funzionante, difatti funziona se lo si esegue una sola volta, dalla seconda rimuove la texture. Per il funzionamento vedi punto ctrl+z di Stefano.



### Zeno Darani


|Orario        |Lavoro svolto                 |
|--------------|------------------------------|
|10:05 - 14:00 | Ridimensionamento del pennello|
|14:15 - 15:45 | Documentazione|

### Stefano Mureddu


|Orario        |Lavoro svolto                 |
|--------------|------------------------------|
|08:20 - 15:15 |Lavorato sul ctrl+Z	|
|15:15 - 15:45 |Fatto il diari|


#### ctrl+z

Il ctrl+z che ho ideato non fa altro che prendere un array di texture e aggiungerci sempre la texture dopo l'ultima modifica
Per farlo ogni volta ciclo l'array spostando in là le vecchie texture per poi aggiungerci quella nuova così da avere sempre 9 texture ricaricabili
Prima di salvare una nuova texture controllo se è stata fatta una nuova modifica dopo l'ultimo salvataggio o se la modifica è ancora in corso.
Quando si clicca ctrl + z la texture della tela viese settata come la penultima dell'array(penultima perchè l'ultima è quella con l'ultima modifica da rimuovere), e, successivamente sposta tutte le altre texture avanti, così da avere pronta la texture ancora precedente pronta in caso di un altro ctrl+z.
Il problema è che quando prendiamo la texture vengono sovrascritte tutte perchè queste non vengono istanziate, ma abbiamo in programma di fixarlo se si riesce già oggi.


### Sara Bressan


|Orario        |Lavoro svolto                 |
|--------------|------------------------------|
|08:20 - 11:35 | Risoluzione errori, test e ottimizzazione dell'applicazione|
|12:30 - 15:45 | Visualizzazione strumento utilizzato |

Vedi punto Errori del diario.

#### Visualizzazione strumento utilizzato

Per prima cosa ho creato un Canvas nella scena, questo Canvas ha RenderMode con la MainCamera, in questo modo pur cambiando la dimensione
dello schermo lo strumento selezionato sarà sempre in alto a sinistra.

Nel canvas ho creato tre oggetti immagini (gomma, penna e riempi) le quali mostrano ognuna uno strumento, ogni qualvolta viene selezionato
uno strumento diverso dal precedente verrà mostrato solamente l'oggetto immagine dell'oggetto in uso.
In seguito ho aggiunto un'altro oggetto RawImage alla quale cambio il colore secondo il colore del pennello attualmente in uso.

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

### Stefano
