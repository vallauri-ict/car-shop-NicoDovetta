# VenditaVeicoliSolution
## Dovetta Nicolas, 4^B Informatica - I.I.S. "G. Vallauri" Fossano

Programma di gestione di un autosalone per vendita di automobili e moto. Entrambe le classi di oggetto sono classi derivate dalla classe astratta Veicolo che contiene la maggior parte della impostazioni comuni di un veicolo, mentre le classi specifiche contengono le variabili per la definizione di alcune caratteristiche specifiche per la moto(marca della sella) e per la macchina (numero di airbag).
La soluzione contiene diveri progetti:

1. "CLI_Database": progetto console per la gestione del database;
2. "DatabaseInstriction": una dll contenente la classe UtilsDb.cs che, definendo un oggetto del tipo UtilsDb ci consente di andare ad apportare modifiche al database;
3. "SwitchLabel" e "SwitchTextBox": sono due progetti per dei controlli WindowsForm personalizzati che vengono usati nella form di aggiunta veicolo;
4. "veicoliDllProject": contiene la definizione della classe astratta "Veicolo.cs" e delle classi derivate "Moto.cs" e "Automobili.cs", inoltre contiene la classe "Utils.cs" che
                        implementa alcune funzionalità condivise in molti progetti. Vi è anche la classe "WordUtilities.cs" che implementa i metodi per creare dei documenti word (.docx)
                        tramite l'uso di OpenXML;
5. "WindowsFormAppProject": contiene le form per l'utilizzo da parte di utenti non addetti alla gestione del database. La form "Main.cs" è la form che parte inizialmente e che mostra i veicoli ed
                            i report tramite il cambio della selezione di una combobox. Poi abbiamo la form "AddNewVeicolo.cs" per l'aggiunta di un veicolo mentre la form "VisualizzaModifica.cs"
                            consente la modifica, la vendita, la visualizzazione in dettaglio e l'eliminazione di un veicolo.


### CLI_Database

Appare un menù che ci lascia fare una selezione per andare poi effettivamente a effettuare le modifiche sul database. Gli unici metodi che sono effettivamente implementati quì che influiscono sul database sono quello per la creazione del backup, per l'eliminazione del database e la creazione di esso.


### DatabaseInstruction

Contiene effettivamente i metodi di modifica del database: ecco la lista dei metodi che possono essere richiamati:

```C#
/// <summary>
/// Crea la tabella "Automobili".
/// </summary>
public void CreateTableCars(){}

/// <summary>
/// Crea la tabella "Moto".
/// </summary>
public void CreateTableMoto(){}

/// <summary>
/// Crea la tabella "Report_Vendite".
/// </summary>
public void CreateTableReport(){}

/// <summary>
/// Aggiunge un veicolo automaticamente a una delle 2 tabelle (Moto o Automobili) a seconda del tipo del veicolo.
/// </summary>
/// <param name="v">Veicolo da aggiungere alla tabella del tipo rispettivo.</param>
public void AddNewVeicol(Veicolo v){}

/// <summary>
/// Aggiunge un record alla tabella "Report_Vendite".
/// </summary>
/// <param name="v">Veicolo da aggiungere alla tabella.</param>
public void AggiungiVendita(Veicolo v){}

/// <summary>
/// Imposta il nome della tabella "Moto" per evitare che si possano cancellare più tabelle al posto di una sola.
/// </summary>
public void DropMoto(){}

/// <summary>
/// Imposta il nome della tabella "Automobili" per evitare che si possano cancellare più tabelle al posto di una sola.
/// </summary>
public void DropAutomobili(){}

/// <summary>
/// Imposta il nome della tabella "Report_Vendite" per evitare che si possano cancellare più tabelle al posto di una sola.
/// </summary>
public void DropReport(){}

/// <summary>
/// Imposta la query per prendere tutti i dati della tabella "Automobili" e richiama il metodo che si occupa di scrivere a video ciò che viene riportato.
/// </summary>
public void ListMacchine(){}

/// <summary>
/// Imposta la query per prendere tutti i dati della tabella "Moto" e richiama il metodo che si occupa di scrivere a video ciò che viene riportato.
/// </summary>
public void ListMoto(){}

/// <summary>
/// Imposta la query per prendere tutti i dati della tabella "Report_Vendite" e richiama il metodo che si occupa di scrivere a video ciò che viene riportato.
/// </summary>
public void ListReport(){}

/// <summary>
/// Prende dal database tutti i veicoli appartenenti alle tabella "Automobili" e gli restituisce in una lista.
/// </summary>
/// <param name="list">Lista passata per referenza nella quale sono contenuti i veicoli.</param>
public void GetVeicolListAuto(ref SerialBindList<Veicolo> list){}

/// <summary>
/// Prende dal database tutti i veicoli appartenenti alle tabella "Moto" e gli restituisce in una lista.
/// </summary>
/// <param name="list">Lista passata per referenza nella quale sono contenuti i veicoli.</param>
public void GetVeicolListMoto(ref SerialBindList<Veicolo> list){}

/// <summary>
/// Prende dal database tutti i veicoli appartenenti alle tabella "Report_Vendite" e gli restituisce in una lista.
/// </summary>
/// <param name="list">Lista passata per referenza nella quale sono contenuti i veicoli.</param>
public void GetVeicolListReport(ref SerialBindList<Veicolo> list){}

/// <summary>
/// Per evitare di andare a fare delle query a una tabella inesistente controllo che esista.
/// </summary>
/// <param name="tableName">Nome della tabella da verificare.</param>
/// <returns>True se esiste la tabella false se non esiste.</returns>
public bool PresTabella(string tableName){}
```


### SwitchLabel e SwitchTextBox

Crea i controlli dinamici che cambiano a seconda della selezione nella form di aggiungi veicolo.


### veicoliDllProject

Contiene le specifiche per definire le classi "Veicolo.cs", "Moto.cs" e "Automobili.cs". Contiene anche le definizioni delle classi "Utils.cs" e "WordUtilities.cs".

#### Utils.cs

```C#
//Salvataggi.

/// <summary>
/// Crea dei dati statici per effettuare un test delle funzionalità.
/// Aggiornato: 14/12/2019.
/// </summary>
/// <where>Main riga:35</where>
public static void caricaDatiDiTest(SerialBindList<Veicolo> listaVeicoli){}

/// <summary>
/// Controlla che si sia un file con i dati dei veicoli. In caso non ci sia può creare un file con dati di test, annullare e quindi chiudere l'applicazione o
/// caricare il progetto senza dati.
/// </summary>
/// <param name="listaVeicoli">Contiene/Conterrà i dati presenti nel file Veicoli.json</param>
public static void loadData(SerialBindList<Veicolo> listaVeicoli){}

/// <summary>
/// Da un file orignie ".json", carico la lista con i dati presenti nel file.
/// </summary>
/// <param name="listaVeicoli">Lista di destinazione degi oggetti del file ".json".</param>
/// <param name="path">Path di provenienza del file ".json".</param>
public static void apriSalvataggi(SerialBindList<Veicolo> listaVeicoli, string path){}


//FormatoJson.

/// <summary>
/// Con qualunque tipo crea un file di estensione ".json" con tutte le variabili. Se usato più volte, con lo stesso path, sovrascrive il file.
/// </summary>
/// <typeparam name="T">
/// *** Tipo Generico ***
/// Accetta qualunque oggetto di qualuncque tipo.
/// </typeparam>
/// <param name="objectlist">Lista source.</param>
/// <param name="pathName">Indirizzo di destinazione del file ".json".</param>
public static void serializeToJson<T>(IEnumerable<T> objectlist, string pathName){}

public static void parseJsonToObject(string pathName, SerialBindList<Veicolo> objectlist){}


//Visualizza.

/// <summary>
/// Richiamato tutte le volte che devo cambiare i veicoli all'interno della dgv.
/// </summary>
/// <param name="dgv">Elemento della form dove carico i dati.</param>
/// <param name="listaVeicoli">Lista che contiene i veicoli.</param>
/// <param name="visual">Campo che mi indica quale tipo di veicolo devo inserire nella form.</param>
public static void visualNew(DataGridView dgv, SerialBindList<Veicolo> listaVeicoli, int visual){}


//Controlli sulla targa.

/// <summary>
/// Crea una targa che possa funzionare da id e non vada in errore
/// </summary>
/// <param name="listaVeicoli">Per selezionare l'ultima targa "non immatricolata"</param>
/// <returns></returns>
public static string makeTarga(SerialBindList<Veicolo> listaVeicoli){}

/// <summary>
/// Tramite una regular expression controlla la targa
/// </summary>
/// <returns>True se la targa va bene, false se la targa non è accettabile.</returns>
public static bool checkTarga(ref string targa, SerialBindList<Veicolo> listaVeicoli){}


//Altri metodi.

/// <summary>
/// Ci restirtuisce il percorso dove si vuole salvare il documento.
/// </summary>
/// <param name="fbd">Oggetto dei windows form che si occupa di trovare il path.</param>
/// <returns>Ritorna il path dove vogliamo che sia salvato il documento</returns>
public static string SelectPath(FolderBrowserDialog fbd){}

/// <summary>
/// Combina il nome e il path del file, in maniera che si possa salvare.
/// </summary>
/// <param name="OutputFileDirectory">Directory preferenziale dove salvare il file.</param>
/// <param name="fileExtension">Estensione del file.</param>
/// <returns>Restituisce la directory dove si salva il file</returns>
public static string OutputFileName(string OutputFileDirectory, string fileExtension){}

/// <summary>
/// Genera un messaggio e poi avvia un documento o un'altro tipo di file.
/// </summary>
/// <param name="msg"></param>
/// <param name="filepath"></param>
public static void ProcedureCompleted(string msg, string filepath){}

/// <summary>
/// Aggiunge il testo al paragrafo.
/// </summary>
/// <param name="mainPart">Parte principale del documento.</param>
/// <returns>Il paragrado con testo e stili.</returns>
public static Paragraph WordPotentialTest(MainDocumentPart mainPart){}

/// <summary>
/// Crea e avvia, con il browser predefinito, una pagina HTML con tutti i veicoli e alcune variabili; pronto per l'esportazione.
/// </summary>
/// <param name="listaVeicoli">Source dei veicoli</param>
/// <param name="pathName">Path destinazione di "index.html"</param>
/// <param name="skeletonPathName">Path del modello html</param>
public static void createHtml(BindingList<Veicolo> listaVeicoli, string pathName){}
```

##### WordUtilities.cs

```C#
/// <summary>
/// Inserisce l'immagine nel documento.
/// </summary>
/// <param name="wordprocessingDocument">Documento a cui appendere l'immagine.</param>
/// <param name="fileName">Path dell'immagine.</param>
public static void InsertPicture(WordprocessingDocument wordprocessingDocument, string fileName){}

/// <summary>
/// Aggiunge gli stili.
/// </summary>
/// <param>Definisce tutt e le caratteristiche dello stile.</param>
/// <returns>Lo stile.</returns>
public static RunProperties AddStyle(MainDocumentPart mainPart, bool isBold = false, bool isItalic = false, bool isUnderline = false, bool isOnlyRun = false, string styleId = "00", string styleName = "Default", string fontName = "Calibri", int fontSize = 12, string rgbColor = "000000", UnderlineValues underline = UnderlineValues.Single){}

/// <summary>
/// Crea un paragrafo e lo aggiunge al documento.
/// </summary>
/// <param name="styleId"></param>
/// <param name="justification"></param>
/// <returns></returns>
public static Paragraph CreateParagraphWithStyle(string styleId, JustificationValues justification = JustificationValues.Left){}

/// <summary>
/// Aggiunge il testo al paragrafo.
/// </summary>
/// <param name="paragraph">Paragrafo a cui aggiungere il testo.</param>
/// <param name="content">Testo da aggiungere.</param>
/// <param name="rpr">Proprietà/Stile del testo</param>
public static void AddTextToParagraph(Paragraph paragraph, string content, SpaceProcessingModeValues space = SpaceProcessingModeValues.Default, RunProperties rpr = null){}

/// <summary>
/// Crea una lista a pallini.
/// </summary>
/// <param name="mainPart">Documento dove si vuole appendere la lista.</param>
/// <param name="bulletChar">Carattere usato come tag per il nuovo elemento.</param>
public static void CreateBulletNumberingPart(MainDocumentPart mainPart, string bulletChar = "-"){}

/// <summary>
/// Crea una lista ordinata.
/// </summary>
public static void CreateBulletOrNumberedList(int indentLeft, int indentHanging, List<Paragraph> paragraphs, int numberOfParagraph, string[] texts, bool isBullet = true){}

/// <summary>
/// Crea una tabella.
/// </summary>
/// <param name="mainPart">Documento.</param>
/// <param name="bolds" name="italics" name="underlines" name="texts" name="justifications"></param>
/// <param name="right">Numero di righe.</param>
/// <param name="cell">Numero di celle.</param>
/// <param name="rgbColor">Colore del testo.</param>
/// <param name="borderValues">Spessore dei bordi.</param>
/// <returns>Tabella appesa al documento.</returns>
public static Table createTable(MainDocumentPart mainPart, bool[] bolds, bool[] italics, bool[] underlines, string[] texts, JustificationValues[] justifications, int right, int cell, string rgbColor = "000000", BorderValues borderValues = BorderValues.Thick){}
```


### WindowsFormAppProject

Gestione dei veicoli in maniera visuale, com una combobox che al cambio della selezione cambio i dati all'interno di una DataGrivView, mentre per i report gli stampo all'interno di un ReachTextBox.

Per i veicoli, se faccio un doppio click sulla riga che mi interessa, apre una form per la visualizzazione in specifico del veicolo dove posso modificarlo, eliminarlo e venderlo, alla chiusura della form di visualizzazione specifica riaggiorno la form in base alla selezione della combo per poter vedere i dati cambiati.

Dalla form principale posso invece creare un nuovo veicolo, se non so la targa o non è immatricolata metto una data casuale e lascio vuoto il TextBox per la data e il programma creerà una targa che vada bene all'interno del database come chiave primaria.
Sempre dalla form principale posso salvare i dati e creare un piccolo sito per la visualizzaione dei miei veicoli, differenziati tra nuovi e usati.