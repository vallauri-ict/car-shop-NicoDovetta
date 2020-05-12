#region Riferimenti
//Interni
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using veicoliDLLProject;

//Esterni

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
			txtColore.BackColor = Color.FromName(veicolo.Colore);
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

		}
	}
}