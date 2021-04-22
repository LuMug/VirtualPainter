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
|08:20 - 15:45 | Gestione delle lingue|

### Gestione delle lingue
La scorsa volta avevo finito di implementare il ridimensionamento del pennello, quindi questa mattina ho scelto una nuova feature
tra quelle da implementare nel progetto. Ho scelto una proposta da me, ovverro il supporto di più lingue. Mi sono quindi documentato un
attimo su come implemntare la cosa nel progetto e ho trovato che Unity nel 2018 ha rilasciato il pacchetto Localization utile alla gestione di assests
in base alla regione geografica. Link alla pagina del manuale sul pacchetto Localization:  https://docs.unity3d.com/Packages/com.unity.localization@0.4/manual/index.html
Ho installato il pacchetto andando sulla finestra Window->Package Manager e ho aggiunto il pacchetto tramite ULR (com.unity.localization).
Quindi ho eseguito delle prove per capire meglio come utilizzare il pacchetto. In Edit->Project Settings->Localzation ho creato un nuovo Localization Settings,
ovvero l'oggetto che conterrà le impostazioni relative al pacchetto. Si è aperta quindi una finestra divisa in 4 sezioni. Le Available Locates corrispondono
alle zone geografiche che il progetto supporterà. Con il bottone Locale Generator è possibile aggiungere un Locale tra quelli standard. Ho scelto quindi di
aggiungere English (en) e Italian (it). Nella parte Locale Selectors sono indicati con che ordine verrà scelto il Locale alla partenza dell'applicazione.
Per primo ho messo la selezione in base alla linea di comando, ovvero si basa sul parametro -language=, poi se questo non è disponibile tra gli Available dell'applicazione
ho messo System Locale selector, ovvero seleziona quello del sistema operativo, ed infine se nemmeno quello di sistema è disponibile imposta English (en) come default.
Assets Database e String Database sono impostazioni relative ai due database nelle quale vengono salvate le risorse che devono essere "tradotte".
Poi in Window->Asset Managment->Localization Tables e ho creato una nuova String Table Connection per i due Locale. Ho aggiunto quindi una stringa di prova
con id "hello", valore per English (en) "Hello" e valore per Italian (it) "Ciao". Per valori all'interno di un gameObject di tipo text bisogna aggiungergli
lo script LocalizeStringEvent e quindi specificare la stringa di riferimento. Quando si fa partire l'applicazione, nell'editor appare un menu dropdown nell'
angolo in alto a destra che serve per selezionare il Locale attivo tra quelli disponibili. Così con il cambio di Locale tutte le risorse associate verrano
rimpiazzate con quelle del nuovo Locale. Per cambiare Locale manualmente tramite script si può modificare la seguente proprietà:
LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.GetLocale("it");
In questo modo il SelectedLocale diventa il Locale con id = "it" (Italian). Per accedere alla risorsa invece si può eseguire il seguente proceditemnto.
var operation = LocalizationSettings.StringDatabase.GetLocalizedStringAsync("Strings", "hello");
        if (operation.IsDone)
        {
            Debug.Log(operation.Result);
        }
        else
        {
            operation.Completed += (op) => Debug.Log(op.Result);
        }
Alla variabile operation viene assegnata l'AsyncOperationHandler per l'operazione asincrona di far ritornare la stringa. Quindi si controlla se l'operazione
è definita nel caso la StringTable contenente la risorsa sia già caricata. Se così non fosse all'AsyncOperationHandler viene assegnata l'azione che si vuole
svolgere una volta che l'operazione sarà completata. Questo metodo lo ho trovato nel forum: https://forum.unity.com/threads/localizating-strings-on-script.847000/
Poi mi sono quindi occupato di mostrare rifare il procedimento sul computer di Sara, dove è siutato il progetto principale. Ho quindi tradotto le varie stringhe visualizzate nei vari menù.

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
