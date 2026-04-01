using BorneAutorouteMETIER.Elements;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace BorneAutorouteVM.VMSecondaires
{
    /// <summary>
    /// Vue-Modèle du ticket
    /// </summary>
    public class TicketVM : INotifyPropertyChanged
    {
        //Le ticket
        private Ticket metier;
        /// <summary>
        /// Le ticket
        /// </summary>
        public Ticket Metier => this.metier;

        /// <summary>
        /// Le ticket est-il dans la machine
        /// </summary>
        public bool EstDansMachine { get => metier.EstDansMachine; set => metier.EstDansMachine = value; }

        /// <summary>
        /// Constructeur
        /// </summary>
        public TicketVM()
        {
            this.metier = new Ticket();
            this.metier.PropertyChanged += Metier_PropertyChanged;
        }

        //Changement du métier
        private void Metier_PropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            this.OnPropertyChanged(e.PropertyName);
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
