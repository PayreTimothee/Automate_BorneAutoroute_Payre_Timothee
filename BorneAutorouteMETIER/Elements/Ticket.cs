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
    /// Le ticket
    /// </summary>
    public class Ticket : INotifyPropertyChanged
    {
        //Le ticket est-il dans la machine
        private bool estDansMachine;
        private double montant;

        /// <summary>
        /// Le ticket est-il dans la machine
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
        /// Le montant du ticket
        /// </summary>
        public double Montant
        {
            get => montant;
        }

        /// <summary>
        /// Constructeur
        /// </summary>
        public Ticket()
        {
            this.estDansMachine = false;
            Random random = new Random();
            this.montant = 10 + random.NextDouble() * 10;
            this.montant = Math.Round(this.montant, 2);
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
