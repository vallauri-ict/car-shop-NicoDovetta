#region Riferimenti
//Interni
using System.Windows.Forms;

//Esterni
#endregion Riferimenti

namespace SwitchTextBox
{
    public partial class SwitchTextBox: UserControl
    {
        /*
         * Se impostato a true la textBox si reiferisce a una moto,
         * se è impostata a false la textBox si riferisce a una macchina.
         */
        private bool isMoto = true;

        public SwitchTextBox()
        {
            InitializeComponent();
        }

        public bool IsMoto { get => isMoto; set => isMoto = value; }
    }
}