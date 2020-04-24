#region Riferimenti
//Interni
using System.Windows.Forms;

//Esterni

#endregion Riferimenti

namespace SwitchLabel
{
    public partial class SwitchLabel: UserControl
    {
        /*
         * Se la proprietà isMoto è impostata a true la label fa riferimento a una moto,
         * se la proprietà è impostata a false la label si riferisce a una macchina.
         */
        private bool isMoto = true;
        private string text = "label";

        public SwitchLabel()
        {
            InitializeComponent();
        }

        public bool IsMoto { get => isMoto; set => isMoto = value; }

        public string Text1
        {
            get => text;
            set
            {
                text = value;
                this.label1.Text = value;
            }
        }
    }
}