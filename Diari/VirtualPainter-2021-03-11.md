# VirtualPainter | Diario di lavoro
##### Karim Galliciotti, Zeno Darani, Stefano Mureddu e Sara Bressan
### SAMT, 2021-03-11

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
|08:20 - 11:35 | |
|12:30 - 15:45 | |

#### Creazione del modello del nuovo ColorPicker


### Stefano Mureddu


|Orario        |Lavoro svolto                 |
|--------------|------------------------------|
|08:20 - 11:35 |Lavorato con Karim sul disegnare sulla tela|
|12:30 - 14:00 |Creato lo script per salvare col nome|
|14:15 - 15:45 |Lavorato con Karim sul disegnare sulla tela|

### Lavorato con Karim sul disegnare sulla tela

Insieme a Karim ho lavorato sulla parte importonte del progetto, ovvero il disegnare sulla tela. Per farlo abbiamo passato una buona ora a guradare vari opzioni su come farlo e abbiamo deciso di optare per una che si basa su un vettore che parte dalla mano e tocca costantemente la tela. Questo vettore invoca costantemente un metodo che controlla se la mano è nella posizione di disegno e se è vero disegna su quelle coordinate. Sfortunatamente la fase di testing ha poi rivelato che non funzionava come volevamo e dopo aver cambiato i vari controlli per disegnare siamo riusciti almeno a far disegnare, seppur nel punto sbagliato, un pallino blu al momento giusto.


### Creato lo script per salvare col nome

Per questo script, a cui abbiamo lavorato mentre il leap motion era occupato e non potevamo fare i test, abbiamo preso parte dello script per la creazione del file e abbiamo tenuto solo la parte di pre salvataggio che faceva esattamente quello che avevamo bisogno.
Abbiamo passato poi lo script a Sara per l'implementazione ed il testing di esso.

### Sara Bressan


|Orario        |Lavoro svolto                 |
|--------------|------------------------------|
|08:20 - 11:35 | Aggiunta dell'apertura del menù "Esci" nell'inventario |
|12:30 - 15:45 | Gestione della rotazione della tela e mi sono informata sui metodi di disegno|

Nell'LeapHandController la TimePose è stata impostata come "Desktop Mode A", in questo modo le mani 
vengono rilevate se il LeapMotionController è posizionato in orizzontale su una superficie piana.

#### Integrazione dell'interfaccia "Esci" quando si clicca il pulsante sull'inventario
Nello script "Exit" assegnato al bottone di uscita dell'inventario (vedi diario precedente)
ho aggiunto le seguenti linee di codice:

if (button.isPressed && !prevPress)
{
    exitUI.SetActive(true);
    hands.SetActive(false);
}

Se il bottone viene cliccato, le mani non vengono più visualizzate e al loro posto viene 
visualizzata l'interfaccia utente creata l'ultima lezione (Exit_menu).

In seguito ho creato un nuovo script "close" (con Karim), il quale gestisce le interazioni dell'utente con l'interfaccia.
"Close" è stato quindi assegnato all'ActionController.
Se il bottone "si" (che indica se si vuole salvare e uscire) viene cliccato viene richiamato il metodo "salvaEdEsci" il quale salva la texture (tela) e chiude il programma.
Se invece viene cliccato il bottone "no" (non salvare, ma uscire ugualmente) il programma viene chiuso.
Infine se viene cliccato il tasto "Annulla", le mani vengono nuovamente mostrate e l'UI non viene più visualizzata.

Non è possibile testare l'uscita dal programma (Application.Quit();) se non è ancora stata eseguita una build del programma.

#### Ruotando la mano, anche la tela ruota

Girando la mano la tela ruota (è solo un esperimento).

## Errori


##  Punto della situazione rispetto alla pianificazione



## Programma di massima per la prossima giornata di lavoro
### Zeno


### Karim


### Sara
Aggiungere ciò che è stato fatto da Zeno , Karim e Stefano.
