using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using BorneAutorouteMETIER.Automate.Etats;

namespace BorneAutorouteMETIER.Automate
{
    /// <summary>
    /// Classe automate qui gère les états de la borne
    /// </summary>
    public class Automate : INotifyPropertyChanged
    {
        private Borne metier;
        private Etat etatcourant;

        /// <summary>
        /// Observateur de changement d'état
        /// </summary>
        public event PropertyChangedEventHandler? PropertyChanged;

        /// <summary>
        /// Message à afficher pour l'état courant de la borne
        /// </summary>
        public string Message { get => this.etatcourant.Message; }
        /// <summary>
        /// Nom de l'état courant de la borne
        /// </summary>
        public string NomEtat { get => this.etatcourant.Nom; }

        /// <summary>
        /// Constructeur de l'automate
        /// </summary>
        /// <param name="metier">Le metier du programme</param>
        public Automate(Borne metier)
        {
            this.metier = metier;
            this.etatcourant = new EtatAttenteClient(this.metier);
        }

        /// <summary>
        /// Active l'automate en fonction de l'événement reçu
        /// </summary>
        /// <param name="e"></param>
        public void Activer(Evenement e)
        {
            this.etatcourant.Action(e);
            this.etatcourant = this.etatcourant.Transition(e);
            NotifyPropertyChanged("NomEtat");
            NotifyPropertyChanged("Message");
        }

        /// <summary>
        /// Observeur de changement de propriété
        /// </summary>
        /// <param name="propertyName">le nom de la propriété</param>
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
