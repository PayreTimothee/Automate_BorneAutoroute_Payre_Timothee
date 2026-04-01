using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace BorneAutorouteMETIER.Elements
{
    /// <summary>
    /// La carte bancaire
    /// </summary>
    public class CarteBancaire : INotifyPropertyChanged
    {
        //La carte bancaire est-elle valide
        private bool estValide;
        //Code de la carte bancaire
        private string code = "1234";

        // La CB est-il dans la machine
        private bool estDansMachine;
        /// <summary>
        /// La CB est-il dans la machine
        /// </summary>
        public bool EstDansMachine
        {
            get => estDansMachine;
            set
            {
                estDansMachine = value;
                this.OnPropertyChanged();
            }
        }

        /// <summary>
        /// La carte bancaire est-elle valide
        /// </summary>
        public bool EstValide { get => estValide;set => estValide = value; }

        /// <summary>
        /// Constructeur
        /// </summary>
        public CarteBancaire() 
        {
            this.estValide = true;
            this.estDansMachine = false;
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
