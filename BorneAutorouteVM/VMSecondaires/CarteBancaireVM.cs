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
    /// Vue-Modèle de la carte bancaire
    /// </summary>
    public class CarteBancaireVM : INotifyPropertyChanged
    {
        //Carte bancaire
        private CarteBancaire metier;
        /// <summary>
        /// La carte bancaire
        /// </summary>
        public CarteBancaire Metier => this.metier;

        //La carte bancaire est-elle valide
        public bool EstValide { get => metier.EstValide; set => metier.EstValide = value; }

        /// <summary>
        /// La CB est-elle dans la machine
        /// </summary>
        public bool EstDansMachine { get => metier.EstDansMachine; set => metier.EstDansMachine = value; }

        /// <summary>
        /// Constructeur
        /// </summary>
        public CarteBancaireVM()
        {
            this.metier = new CarteBancaire();
            this.metier.PropertyChanged += Metier_PropertyChanged;
        }

        //Modification du métier
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
