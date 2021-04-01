# VirtualPainter | Diario di lavoro
##### Karim Galliciotti, Zeno Darani, Stefano Mureddu e Sara Bressan
### SAMT, 2021-04-01

## Lavori svolti

Link utili:
- Ctrl-z: https://stackoverflow.com/questions/3944552/undo-for-a-paint-program


### Karim Galliciotti


|Orario        |Lavoro svolto                 |
|--------------|------------------------------|
|8:20 - 15:45  | Azione riempimento|



### Zeno Darani


|Orario        |Lavoro svolto                 |
|--------------|------------------------------|
|10:05 - 14:00 | Ridimensionamento del pennello|
|14:15 - 15:45 | Documentazione|

### Stefano Mureddu


|Orario        |Lavoro svolto                 |
|--------------|------------------------------|
|08:20 - 14:00 |Documentato e aiutato chi aveva bisogno	|
|14:15 - 15:45 |Fatto i diari|


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
