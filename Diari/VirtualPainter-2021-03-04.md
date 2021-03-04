# VirtualPainter | Diario di lavoro
##### Karim Galliciotti, Zeno Darani, Stefano Mureddu e Sara Bressan
### SAMT, 2021-02-25

## Lavori svolti

Link utili:


### Karim Galliciotti


|Orario        |Lavoro svolto                 |
|--------------|------------------------------|
|08:20 - 11:35 | |
|12:30 - 15:45 ||


### Zeno Darani


|Orario        |Lavoro svolto                 |
|--------------|------------------------------|
|08:20 - 09:50 | |
|10:05 - 15:45 | |


### Stefano Mureddu


|Orario        |Lavoro svolto                 |
|--------------|------------------------------|
|08:20 - 11:35 ||
|12:30 - 15:35 ||


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


### Sara
