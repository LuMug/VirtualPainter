# VirtualPainter | Diario di lavoro
##### Karim Galliciotti, Zeno Darani, Stefano Mureddu e Sara Bressan
### SAMT, 2021-04-29

## Lavori svolti

Link utili:


### Karim Galliciotti


|Orario        |Lavoro svolto                 |
|--------------|------------------------------|
|8:20  - 15:45 | Documentazione e revisione codice|

### Documentazione e commento

Oggi ho perlopiù documentato e revisionato le parti di implementazioni svolte da me.


### Zeno Darani


|Orario        |Lavoro svolto                 |
|--------------|------------------------------|
|08:20 - 15:45 | Documentazione codice|

#### Documentazione codice
Oggi ho ripreso i miei codici e gli ho riccommentati utilizando tag XML così da poter poi generare la documentazione per le classi.
Ho fatto una prova utilizando il software Doxygen e ho generato una doc di prova in formato HTML.

### Stefano Mureddu


|Orario        |Lavoro svolto                 |
|--------------|------------------------------|
|08:20 - 15:45 |Lavorato sulla documentazione|

#### Documentato

DocumentatoDocumentatoDocumentatoDocumentatoDocumentatoDocumentatoDocumentatoDocumentato



### Sara Bressan


|Orario        |Lavoro svolto                 |
|--------------|------------------------------|
|08:20 - 15:45 |  Documentazione, Revisione codice e Build |

Ho rebuildato il programma e sistemato modificato il metodo HandReset il quale ora controlla che la mano 
sia effettivamente inserita prima di utilizzarla.

protected override void HandReset()
    {
        if (leap_hand != null)
        {
            Debug.Log("RIGHT IN");
            handIn = true;
            ...
        }
    }
}

In seguito ho riguardato tutti i codici e ottimizzato il programma.
Ho aiutato Zeno a sistemare un problema per la quale il colore selezionato non veniva applicato 
durante il disegno.

##  Punto della situazione rispetto alla pianificazione


## Programma di massima per la prossima giornata di lavoro
### Zeno


### Karim


### Sara
Finire ManageRight e Exit

### Stefano
