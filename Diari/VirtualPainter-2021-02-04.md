# VirtualPainter | Diario di lavoro
##### Karim Galliciotti, Zeno Darani, Stefano Mureddu e Sara Bressan
### SAMT, 2021-02-04

## Lavori svolti

Link utili:
 - https://assetstore.unity.com/packages/2d/gui/icons/simple-icon-pastel-tone-107568 , Package contenente le immagini che sono state inserite nei bottoni.


### Karim Galliciotti


|Orario        |Lavoro svolto                 |
|--------------|------------------------------|
|08:20 - 11:35 | Inizio tracciamento mani in Unity|
|12:30 - 15:45 | Conclusione tracciamento mani in Unity|

## Tracciamento mani in Unity
Per prima cosa ho scaricato gli Unity module packages (https://developer.leapmotion.com/unity) e li ho importati in Unity, in seguito ho installato il plugin "XR plugin Management" versione 3.2.16 (Window -> Package Manager) e l'ho selezionato sotto la scheda "Project Settings".

Per testare il funzionamento delle configurazioni effettuate ho aperto la scena "Capsule Hands (Desktop)" (Nella cartella Assets/Plugins/LeapMotion/Core/Example) e verificato che LeapMotion interagisse con le mani presenti in essa.

Dopo aver confermato il successo del test ho provato a rifarla da capo.
Per prima cosa ho trascinato il prefab LeapHandController (Assets/Plugins/LeapMotion/Core/Prefabs) nella scena e creato un nuovo GameObject di nome "HandsModel", che conterrà "RigidRoundHand_L", "RigidRoundHand_R" (entrambi in Assets/Plugins/LeapMotion/Core/Prefabs/HandModelPhysical), "Capsule Hand Left" e "Capsule Hand Right" (entrambi in Assets/Plugins/LeapMotion/Core/Prefabs/HandModelsNonHuman).

HandsModel deve usare lo script "Hand Model Manager" e modificando il campo Size sotto Models Pool da 0 a 2 compariranno 2 nuovi gruppi di campi, da chiamare "Graphics_Hands" e "Physics_Hands". Sotto Graphics_Hands, nei campi Left Model e Right Model vanno selezionati "Capsule Hand Right e Left", mentre in "Physics_Hands" verranno selezionati "RigidRoundHand_L e R". In entrambi i gruppi vanno spuntate le caselle "Is enable" e "Can duplicate".

### Zeno Darani


|Orario        |Lavoro svolto                 |
|--------------|------------------------------|
|08:20 - 09:50 | Installazione Visual Studio  |
|10:05 - 14:00 | Creazione classe FileManager per caricamento e salvataggio texture|
|14:15 - 15:45 | Cercato un package per l'esplorazione di file e percorsi|

## Installazione Visual Studio
Nelle prime due ore della mattina ho provato ad installare Visual Studio ma senza successo a causa della ISO di Windows 10 troppo vecchia che ho usato per la macchina virtuale. Per questo ho deciso di non soffermarmi troppo, visto che comunque Unity è stato installato a casa, a perdere tempo e ho installato Visual Studio Code. Non avendo l'aiuto di un itellisense è stato un po' più complicato a usare le classi di cui avevo bisogno essendo la prima volta che le utilizavo. 

## Classe FileManager
In questa giornata di lavoro ho realizzato la classe FileManager. Questa classe permette di caricare immagini JPG, e PNG sottoforma di texture e, viceversa, di salvare texture sottoforma di immagini JPG e PNG.

## File Browser
Poi ho cercato online qualcosa che potrebbe aiutarmi per scegliere i percorsi delle immagini da aprire e salvare. Ho trovato un package che permette di aprire una finestra "esplora file" di sistema (sia Windows che Mac che Linux), e scegliere file da aprire o percorsi in cui salvare. Il package si chiama "UnityStandaloneFileBrowser" ed è stato sviluppato da  Gökhan Gökçe e Ricardo Rodrigues (https://github.com/gkngkc/UnityStandaloneFileBrowser#:~:text=%20Unity%20Standalone%20File%20Browser%20%201%20Works,Ricardo%20Rodrigues.%207%20Basic%20WebGL%20support.%20More).


### Stefano Mureddu


|Orario        |Lavoro svolto                 |
|--------------|------------------------------|
|10:05 - 11:35 | |
|12:30 - 15:45 | |

### Sara Bressan


|Orario        |Lavoro svolto                 |
|--------------|------------------------------|
|08:20 - 09:50 | Creazione della GUI in Unity della pagina iniziale (Start Page) che cossriponde al menù iniziale|
|10:05 - 11:35 | Creazione della GUI in Unity per la configurazione di una nuova tela / foglio|
|12:30 - 15:45 | Creazione di una scena unica contenente le due GUI create al mattino e interazione tra i due Canvas tramite un bottone |

## Start Page GUI

Per prima cosa è stata creata la scena "Start_Page" nel progetto di Unity "Virtual Painter", a questo punto si è inserito un nuovo Canvas nella scena appena creata.
Al canvas è stato impostato il render mode: Screen Space - Camera, in questo modo il canvas sarà sempre grande come la Main Camera, quindi grande come l'applicazione.
Il Canvas ha inoltre un Vertical Layout Group, che consentirà di disporre il Label con il titolo del programma e i bottoni uno sopra l'altro, e  sia l'altezza che la larghezza dei componenti all'interno di questo layout sono controllati dal canvas (altezza e larghezza sono spuntate nelle impostazioni: "Control Child Size" e "Child Force Expand").

In seguito ho aggiunto nel Canvas un Label con scritto "Virtual Painter" e un panello che andrà a contenere i due bottoni con la quale caricare o creare un nuovo file (tela).
Il pannello ha a sua volta un Horizontal Layout Group che serve a disporre i due bottoni in fila e che si adattino alla finestra dell'applicazione, in questo caso è stato però inserito un padding di 10 su tutti i lati (i questo modo i bottoni sono staccati tra loro e dai bordi della finestra).

Infine sono stati creati i bottoni "NuovoFoglio", il quale servirà a creare una nuova tela, e "FoglioEsistente", il quelse servirà invece ad aprire l'explorer per selezionare una tela preesistente.

Per inserire le immagini nei bottoni abbiamo importato un package dall'Asset Store di Unity (il pacchetto è gratuito ed è trovabile nella seguente pagina: https://assetstore.unity.com/packages/2d/gui/icons/simple-icon-pastel-tone-107568 ), il pacchetto è stato importato tramite l'UnityHub.
Ad ogni bottone è stata assegnato un Grid Layout Group (con "Child Alignment" settato a "Middle Center   ") nella quale sono stati inseriti un'immagine (presa dal package intallato in precedenza) e un testo.

### Configurazione Foglio GUI

Nella scena di configurazione del foglio è stato aggiunto un Canvas avente un Vertical Layout Group, il quale permette agli elemnti al suo interno di essere messi uno sotto l'altro, il Label (testo "Grandezza Foglio"), il pannello contenente gli Input Field e i Label per la gerstione delle impostazioni del foglio e il bottone "continua", ereditano altezza e larghezza dal canvas ed hanno la grandezza massima contenibile.

La gestione dell'altezza e la larghezza è gestita da 2 Input Field, i quali accettano sultanto numeri interi.

### Creazione di una Scena Unica

Per evitare errori durante il passaggio di informazioni tra due scene abbiamo deciso infine di collassare tutto il programma in un'unica Scene (Scena di Unity).
Abbiamo quindi copiato e incollato i due Canvas delle scene descritte in precedenza nella scena chiamata "Tela".
A questo punto abbiamo creato un GameObject vuoto chiamato "ActionController" alla quale abbiamo assegnato lo script "ShowMenu".
"ShowMenu" riceve come argomenti in entrata il Canvas "Start_Page", il Canvas "ConfigurazioneFoglio" e il bottone "NuovoFoglio" presente nel Canvas "Start_Page".
Nel metodo "Start" abbiamo aggiunto un listener per il bottone, il quale rende inattiva il Canvas del menu e attiva il Canvas nelle quali verranno messe le impostazioni del nuovo foglio, inoltre nel metodo start viene attivato il "Menu_Start" (Canvas iniziale del programma) e viene disattivato il Canvas delle impostazioni di una nuova tela / foglio.

##  Problemi riscontrati e soluzioni adottate

Non si riusciva a interagire con i bottoni e i textBox delle GUI una volta integrati entrambi i Canvas in una Scena unica, abbiamo risolto il problema mettendo i due Canvas in due Layer differenti (uno più avanti e l'altro dietro).

##  Punto della situazione rispetto alla pianificazione



## Programma di massima per la prossima giornata di lavoro
