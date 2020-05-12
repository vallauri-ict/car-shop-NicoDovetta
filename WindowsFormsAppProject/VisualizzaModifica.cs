#region Riferimenti
//Interni
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using veicoliDLLProject;

//Esterni
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using System.Collections.Generic;
using DatabaseInstruction;

#endregion Riferimenti

namespace WindowsFormsAppProject
{
	public partial class VisualizzaModifica : Form
	{
		#region globalVariables

		private static string imgDirectoryPath = $"{Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName}\\resources\\img";//Percorso della cartella "resources".
		private static string noImgPath = Path.Combine(imgDirectoryPath, Properties.Resources.NO_Img);//Percorso dell'immagine di default.
		private string imgPath = noImgPath;
		private string colore = "";

		Veicolo veicolo;
		SerialBindList<Veicolo> listVeicoli;

		#endregion globalVariables

		public VisualizzaModifica()
		{
			InitializeComponent();
		}

		/// <summary>
		/// Mi salvo i riferimenti al veicolo e alla lista dove, nel caso di modifica, vado a modificare anche lì il veicolo o nel caso di vendita di esso vado a rimuoverlo.
		/// </summary>
		/// <param name="v"></param>
		/// <param name="l"></param>
		public VisualizzaModifica(Veicolo v, ref SerialBindList<Veicolo> l)
		{
			InitializeComponent();
			veicolo = v;
			listVeicoli = l;
		}

		/// <summary>
		/// Quando si carica la form vengono anche caricati i parametri attuali del veicolo.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void VisualizzaModifica_Load(object sender, EventArgs e)
		{
			dtpImmatricolazione.MaxDate = DateTime.Today;
			if (!File.Exists(veicolo.ImgPath))
			{
				veicolo.ImgPath = noImgPath;
			}
			pcbImg.ImageLocation = veicolo.ImgPath;
			txtMarca.Text = veicolo.Marca;
			txtModello.Text = veicolo.Modello;
			txtTarga.Text = veicolo.Targa;
			txtCilindrata.Text = veicolo.Cilindrata.ToString();
			try
			{
				txtColore.BackColor = System.Drawing.Color.FromName(veicolo.Colore);
			}
			catch (Exception)
			{
				MessageBox.Show("Impossibile impostare il colore per la visualizzaione. Solitamente il problema è dovuto a colori con sfumature.", "Autosalone Nico");
			}
			colore = veicolo.Colore;
			dtpImmatricolazione.Value = veicolo.Immatricolazione;
			txtPotenza.Text = veicolo.PotenzaKw.ToString();
			txtKmPercorsi.Text = veicolo.KmPercorsi.ToString();
			if (veicolo.GetType().ToString().Contains("Moto"))
			{
				lblMarcaSella.Visible = txtMarcaSella.Visible = true;
				lblNAirbag.Visible = numAirbag.Visible = false;
				txtMarcaSella.Text = (veicolo as Moto).MarcaSella;
			}
			else
			{
				lblNAirbag.Visible = numAirbag.Visible = true;
				lblMarcaSella.Visible = txtMarcaSella.Visible = false;
				numAirbag.Value = (veicolo as Automobili).NumAirbag;
			}
			txtPrezzo.Text = veicolo.Prezzo.ToString();
		}

		/// <summary>
		/// Quando si è scelto il colore lo si imposta come background di un textbox per dare una preview.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnCambiaColore_Click(object sender, EventArgs e)
		{
			ColorDialog c = new ColorDialog();
			c.ShowDialog();
			txtColore.BackColor = c.Color;//Imposta lo sfondo di una textBox al colore selezionato, da intendersi come "pre-view"
			colore = c.Color.ToKnownColor().ToString();
		}

		/// <summary>
		/// Quando si va a cambiare l'immagine si danno tutti i controlli per verificarne la funzionalità e poi la si cambia anche nel visualizzatore dell'immagine.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnChangeImg_Click(object sender, EventArgs e)
		{
			ofdImg.ShowDialog();
			string img = ofdImg.FileName;
			if (img.Substring(img.LastIndexOf('.')) == ".png" || img.Substring(img.LastIndexOf('.')) == ".jpg" || img.Substring(img.LastIndexOf('.')) == ".jpeg")
			{
				if (File.Exists(img))
				{
					imgPath = img;
					pcbImg.ImageLocation = imgPath;
				}
			}
			else
			{
				MessageBox.Show("Formati accettati '.png' '.jpg' '.jpeg'", "Autosalone Nico");
			}
		}

		/// <summary>
		/// Esegue una serie di controlli prima di andare a modificare il veicolo in maniera errata.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnModifica_Click(object sender, EventArgs e)
		{
			string targa = txtTarga.Text;
			if (targa == veicolo.Targa)
			{
				double _;
				if (double.TryParse(txtCilindrata.Text, out _) && double.TryParse(txtPotenza.Text, out _))
				{
					if (!chkUsato.Checked && chkKmZ.Checked)
					{
						MessageBox.Show("Dati non corrispondenti, controllare Usato e Km zero.", "Autosalone Nico");
					}
					else
					{
						if (double.TryParse(txtPrezzo.Text, out _))
						{
							updateVeicolo();
						}
						else
						{
							MessageBox.Show("Formato del prezzo non valido.", "Autosalone Nico");
						}
					}
				}
				else
				{
					MessageBox.Show("Potenza e cilindrata non validi.", "Autosalone Nico");
				}
			}
			else
			{
				if (Utils.checkTarga(ref targa, listVeicoli))
				{
					double _;
					if (double.TryParse(txtCilindrata.Text, out _) && double.TryParse(txtPotenza.Text, out _))
					{
						if (!chkUsato.Checked && chkKmZ.Checked)
						{
							MessageBox.Show("Dati non corrispondenti, controllare Usato e Km zero.", "Autosalone Nico");
						}
						else
						{
							if (double.TryParse(txtPrezzo.Text, out _))
							{
								updateVeicolo();
							}
							else
							{
								MessageBox.Show("Formato del prezzo non valido.", "Autosalone Nico");
							}
						}
					}
					else
					{
						MessageBox.Show("Potenza e cilindrata non validi.", "Autosalone Nico");
					}
				}
				else
				{
					MessageBox.Show("Targa non valida.", "Autosalone Nico");
				}
			}
		}

		/// <summary>
		/// Una volta eseguiti i controlli vado eliminare il veicolo dalla lista dei veicoli, cambio i valori all'interno del veicolo e infine reinserisco
		/// il veicolo con i nuovi valori all'interno della lista.
		/// </summary>
		private void updateVeicolo()
		{
			listVeicoli.Remove(veicolo);
			veicolo.Targa = txtTarga.Text;
			veicolo.Cilindrata = Convert.ToDouble(txtCilindrata.Text);
			veicolo.Colore = colore;
			veicolo.ImgPath = imgPath;
			veicolo.Immatricolazione = dtpImmatricolazione.Value;
			veicolo.IsKmZero = chkKmZ.Checked;
			veicolo.IsUsato = chkUsato.Checked;
			veicolo.KmPercorsi = Convert.ToInt32(txtKmPercorsi.Text);
			veicolo.Marca = txtMarca.Text;
			veicolo.Modello = txtModello.Text;
			veicolo.PotenzaKw = Convert.ToDouble(txtPotenza.Text);
			veicolo.Prezzo = Convert.ToDouble(txtPrezzo.Text);
			listVeicoli.Add(veicolo);
			MessageBox.Show("Modifiche apportate con successo.", "Autosalone Nico");
		}

		/// <summary>
		/// Elimina il veicolo dalla lista e, dato che non c'è più il veicolo, chiude la form di visualizzazione.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnElimina_Click(object sender, EventArgs e)
		{
			listVeicoli.Remove(veicolo);
			MessageBox.Show("Veicolo eliminato.","Autosalone Nico");
			Close();
		}

		/// <summary>
		/// Chiude la form di visualizzazione e NON effettua nessuna modifica.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnChiudi_Click(object sender, EventArgs e)
		{
			DialogResult res = MessageBox.Show("Se hai effettuato delle modifiche andranno perse. Continuare?", "Autosalone Nico", MessageBoxButtons.YesNoCancel);
			switch (res)
			{
				case DialogResult.Yes:
					Close();
					break;
				default:
					break;
			}
		}

		private void btnVendi_Click(object sender, EventArgs e)
		{
			string resourcesDirectoryPath = $"{Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName}\\resources\\salvataggi";//Percorso della cartella "resources".
			string DbPath = Path.Combine(resourcesDirectoryPath, Properties.Resources.DB_Name);//Percorso del file contenente il database.
			string connStr = $"Provider=Microsoft.Ace.Oledb.12.0;Data Source={DbPath};";//Stringa di connessione completa al database access.
			UtilsDb udDb = new UtilsDb(connStr);
			if (udDb.PresTabella("Report_Vendite"))
			{
				try
				{
					string filepath = Utils.OutputFileName(Utils.SelectPath(fbd), "docx");

					using (WordprocessingDocument doc = WordprocessingDocument.Create(filepath, WordprocessingDocumentType.Document))
					{
						//Aggiunge la parte principale del documento.
						MainDocumentPart mainPart = doc.AddMainDocumentPart();

						//Crea la struttura principale del documento.
						mainPart.Document = new Document();
						Body body = mainPart.Document.AppendChild(new Body());

						//Definizione di alcuni stili per il testo.
						WordUtilities.AddStyle(mainPart, false, false, false, false, "Head1", "Titolone", "Calibri Light", 30, "000000");
						WordUtilities.AddStyle(mainPart, false, false, false, false, "Main1", "Calibri", "Calibri", 10, "000000");

						//Aggiunge il titolo con lo stile "Head1".
						Paragraph headingPar = WordUtilities.CreateParagraphWithStyle("Head1", JustificationValues.Center);
						WordUtilities.AddTextToParagraph(headingPar, $"Fattura per il veicolo: {veicolo.Targa}");
						body.AppendChild(headingPar);

						//Aggiunge del testo
						Paragraph para = body.AppendChild(new Paragraph());
						Run run = para.AppendChild(new Run());
						// String msg contains the text, "Hello, Word!"
						run.AppendChild(new Text($"Busca, {DateTime.Today.ToShortDateString()}"));

						//Aggiunta dello stile "Main" e del corpo del documento.
						Paragraph typescriptParagraph = WordUtilities.CreateParagraphWithStyle("Main1", JustificationValues.Distribute);
						WordUtilities.AddTextToParagraph(typescriptParagraph, $"Con il presente documento si sottoscrive il cambio di proprietà per il veicolo targato {veicolo.Targa}, immatricolato il {veicolo.Immatricolazione.ToShortDateString()}" +
							$" da Autosalone Nico a #nome_Compratore# in data {(DateTime.Today).ToShortDateString()} presso la sede legale di Autosalone Nico.");
						body.AppendChild(typescriptParagraph);

						//Aggiunta della tabella
						bool[] bolds = { false, false, false, false, false, false, false, false, false, false, false, false };
						bool[] italics = { false, false, false, false, false, false, false, false, false, false, false, false };
						bool[] underlines = { false, false, false, false, false, false, false, false, false, false, false, false };
						string aus;
						if (veicolo.GetType().ToString().Contains("Moto"))
						{
							aus = $"Marca£Modello£Colore£Cilindrata£Potenza£Marcasella£{veicolo.Marca}£{veicolo.Modello}£{veicolo.Colore}£{veicolo.Cilindrata}£{veicolo.PotenzaKw}£{(veicolo as Moto).MarcaSella}";
						}
						else
						{
							aus = $"Marca£Modello£Colore£Cilindrata£Potenza£Marcasella£{veicolo.Marca}£{veicolo.Modello}£{veicolo.Colore}£{veicolo.Cilindrata}£{veicolo.PotenzaKw}£{(veicolo as Automobili).NumAirbag}";
						}
						string[] texts1 = aus.Split('£');
						JustificationValues[] justifications = { JustificationValues.Left, JustificationValues.Left, JustificationValues.Left, JustificationValues.Left, JustificationValues.Left, JustificationValues.Left, JustificationValues.Left, JustificationValues.Left, JustificationValues.Left, JustificationValues.Left, JustificationValues.Left, JustificationValues.Left };
						Table myTable = WordUtilities.createTable(mainPart, bolds, italics, underlines, texts1, justifications, 2, 6, "000000");
						body.Append(myTable);
						WordUtilities.InsertPicture(doc, veicolo.ImgPath);

						/*
						//Lista a pallini.
						string[] texts2 = { "First element", "Second Element", "Third Element" };
						WordUtilities.CreateBulletNumberingPart(mainPart);
						List<Paragraph> bulletList = new List<Paragraph>();
						WordUtilities.CreateBulletOrNumberedList(100, 200, bulletList, texts2.Length, texts2);
						foreach (Paragraph paragraph in bulletList)
							body.Append(paragraph);

						//Lista con i numeri.
						List<Paragraph> numberedList = new List<Paragraph>();
						WordUtilities.CreateBulletOrNumberedList(100, 240, numberedList, texts2.Length, texts2, false);
						foreach (Paragraph paragraph in numberedList)
							body.Append(paragraph);
						*/
						//Aggiunta immagine.
					}
					Utils.ProcedureCompleted("Il documento è pronto!", filepath);

					//Aggiunta del veicolo alla tabella 'Report_Ventite' ed eliminazione di esso dalla lista.
					if (udDb.PresTabella("Report_Vendite"))
					{
						udDb.AggiungiVendita(veicolo);
						listVeicoli.Remove(veicolo);
					}
					Close();
				}
				catch (Exception)
				{
					MessageBox.Show("Problemi con il documento. Se è aperto da un altro programma, chiudilo e riprova.","Autosalone Nico");
				}
			}
			else
			{
				MessageBox.Show("Impossibile effettuare la vendita. Contattare l'amministratore del database.","Autosalone Nico");
			}
		}
	}
}