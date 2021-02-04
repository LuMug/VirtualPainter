# VirtualPainter | Diario di lavoro
##### Karim Galliciotti, Zeno Darani, Stefano Mureddu e Sara Bressan
### SAMT, 2021-02-04

## Lavori svolti

Link utili:
 - 


### Karim Galliciotti


|Orario        |Lavoro svolto                 |
|--------------|------------------------------|
|10:05 - 11:35 | Inizio tracciamento mani in Unity|
|12:30 - 15:45 | Conclusione tracciamento mani in Unity|

### Tracciamento mani in Unity
Per prima cosa ho scaricato gli Unity module packages (https://developer.leapmotion.com/unity) e li ho importati in Unity, in seguito ho installato il plugin "XR plugin Management" versione 3.2.16 (Window -> Package Manager) e l'ho selezionato sotto la scheda "Project Settings".

Per testare il funzionamento delle configurazioni effettuate ho aperto la scena "Capsule Hands (Desktop)" (Nella cartella Assets/Plugins/LeapMotion/Core/Example) e verificato che LeapMotion interagisse con le mani presenti in essa.

Dopo aver confermato il successo del test ho provato a rifarla da capo.
Per prima cosa ho trascinato il prefab LeapHandController (Assets/Plugins/LeapMotion/Core/Prefabs) nella scena e creato un nuovo GameObject di nome "HandsModel", che conterrà "RigidRoundHand_L", "RigidRoundHand_R" (entrambi in Assets/Plugins/LeapMotion/Core/Prefabs/HandModelPhysical), "Capsule Hand Left" e "Capsule Hand Right" (entrambi in Assets/Plugins/LeapMotion/Core/Prefabs/HandModelsNonHuman).

HandsModel deve usare lo script "Hand Model Manager" e modificando il campo Size sotto Models Pool da 0 a 2 compariranno 2 nuovi gruppi di campi, da chiamare "Graphics_Hands" e "Physics_Hands". Sotto Graphics_Hands, nei campi Left Model e Right Model vanno selezionati "Capsule Hand Right e Left", mentre in "Physics_Hands" verranno selezionati "RigidRoundHand_L e R". In entrambi i gruppi vanno spuntate le caselle "Is enable" e "Can duplicate".

### Zeno Darani


|Orario        |Lavoro svolto                 |
|--------------|------------------------------|
|10:05 - 11:35 | |
|12:30 - 15:45 | |

### Stefano Mureddu


|Orario        |Lavoro svolto                 |
|--------------|------------------------------|
|10:05 - 11:35 | |
|12:30 - 15:45 | |

### Sara Bressan


|Orario        |Lavoro svolto                 |
|--------------|------------------------------|
|10:05 - 11:35 | Creazione della GUI in Unity della pagina iniziale (Start Page) che cossriponde al menù iniziale|
|11:35 - 12:30 | Creazione della GUI in Unity per la configurazione di una nuova tela / foglio|
|13:15 - 15:45 | |

### Start Page GUI
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

##  Problemi riscontrati e soluzioni adottate


##  Punto della situazione rispetto alla pianificazione



## Programma di massima per la prossima giornata di lavoro
