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
        /// Constructeur
        /// </summary>
        public Ticket()
        {
            this.estDansMachine = false;
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
