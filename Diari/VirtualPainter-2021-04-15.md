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
23

|Orario        |Lavoro svolto                 |

24

|--------------|------------------------------|

25

|10:05 - 14:00 | |

26

|14:15 - 15:45 | |

27



28

### Stefano Mureddu

29



30



31

|Orario        |Lavoro svolto                 |

32

|--------------|------------------------------|

33

|08:20 - 15:15 |Documentato e aiutato Karim|

34

|15:15 - 15:45 |Fatto il diario e tentato di finire quello che stavamo facendo|

35



36

#### Documentato

37

Durante la mattinata ho documentato le varie azioni di salvataggio e il ctrl+z, mentre nel pomeriggio la parte di disegno della tela(solo il disegno senza colore o strumento)

38



39

#### aiuto a Karim

40

Mentre documentavo ho aiutato Karim con i suoi lavori, prima abbiamo finito di mettere a posto l'azion ctrl+z creata da me in precedenza, che poi ho subito documentato, e successivamente abbiamo provato a risolvere il resize della tela. Sfortunatamente non siamo riusciti a risolverla visto che se le proporzioni cambiavano non si disegnava più giusto

41



42



43

### Sara Bressan

44



45



46

|Orario        |Lavoro svolto                 |

47

|--------------|------------------------------|

48

|08:20 - 15:45 | Debugging e ottimizzazione del codice |

49



50

Errore sistemato per la quale le mani non eseguivano nessuna azione siccome venivano creati dei cloni delle mani.

51

Soluzione: Nell'HandModel Manager delle mani l'impostazione "Can Duplicate" deve essere disattivata.

52



53

Errore: Quando la mano destra usciva dalla finestra le impostazioni del pennello venivano resettate

54

Soluzione: creazione di una variabile "brushValue" nella quale viene salvato il valore dello slide della dimensione del pennello,

55

il quale viene settato al rientro della mano nella finestra.

56



57

Errore: Non venivano captate le uscite e le entrate delle mani nella finestra.

58

Soluzione: Sia "ManageLeft" che "ManageRight" implementano "HandTransitionBehavior", a questo punto bisogna importare i due seguenti metodi:

59



60

- "HandReset" viene richiamato all'inserimento della mano nella scena

61

- "HandFinish" viene richiamato all'uscita della mano dalla scena

62



63

Errore: le texture è rotonda, quindi fuoriuscendo dai lati della texture mentre si colora si disegna nel lato opposto.

64



65

## Errori

66



67

- Cambio nome classe GetLeapFingers in ManageLeft.

68

- Eliminato PixelConverter(classe)

69



70



71

Problemi:      

72

- Tavola menu appare anche in assenza delle mani.

73

        Soluzione:

74

        - Un if nello script CheckHandsIn cha abbiamo inserito in HandsModel, questo if controlla se l'oggetto RigidRoundHand_L è null in questo caso nasconde il menù.

75

- Tela scalata in basso di un po' di pixel. -> Causa: Durante l'impostazione delle dimensioni della tela il MoveCanvas capta i click sul numpad della tastiera muovando la tela

76

        Soluzione:

77

        - Disattivare il MoveTela quando la tela non si vede.

78

-Rimozione rotazione con la mano che doventa possibile solamente coi tasti.  

79



80

##  Punto della situazione rispetto alla pianificazione

81



82



83

## Programma di massima per la prossima giornata di lavoro

84

### Zeno

85



86



87

### Karim

88



89



90

### Sara

Eseguire una build del programma di prova ed eseguire i test mancarti

### Stefano
