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
|10:05 - 14:00 | |
|14:15 - 15:45 | |

### Stefano Mureddu


|Orario        |Lavoro svolto                 |
|--------------|------------------------------|
|08:20 - 15:15 |	|
|15:15 - 15:45 ||

### Sara Bressan


|Orario        |Lavoro svolto                 |
|--------------|------------------------------|
|08:20 - 15:45 | Debugging e ottimizzazione del codice |

Errore sistemato per la quale le mani non eseguivano nessuna azione siccome venivano creati dei cloni delle mani.
Soluzione: Nell'HandModel Manager delle mani l'impostazione "Can Duplicate" deve essere disattivata.

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
