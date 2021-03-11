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
|08:20 - 11:35 ||
|12:30 - 15:35 ||


### Sara Bressan


|Orario        |Lavoro svolto                 |
|--------------|------------------------------|
|08:20 - 11:35 | Aggiunta dell'apertura del menù "Esci" nell'inventario |
|12:30 - 15:17 | |
|15:17 - 15:45 | |

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

## Errori


##  Punto della situazione rispetto alla pianificazione



## Programma di massima per la prossima giornata di lavoro
### Zeno


### Karim


### Sara
