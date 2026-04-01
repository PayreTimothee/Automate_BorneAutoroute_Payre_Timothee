using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using BorneAutorouteMETIER;
using BorneAutorouteMETIER.Automate;
using BorneAutorouteMETIER.Elements;
using BorneAutorouteVM.VMSecondaires;

namespace BorneAutorouteVM
{
    /// <summary>
    /// Vue-Modèle de la borne autoroute
    /// </summary>
    public class BorneVM : INotifyPropertyChanged
    {
        //La borne
        private Borne metier;
        private Automate automate;

        /// <summary>
        /// Evenement d'observation
        /// </summary>
        public event PropertyChangedEventHandler? PropertyChanged;

        /// <summary>
        /// Message de la borne
        /// </summary>
        public string Message
        {
            get => this.automate.Message;
            set {
                NotifyPropertyChanged("Message");
            }
        } 
        


        /// <summary>
        /// Constructeur
        /// </summary>
        public BorneVM()
        {
            this.metier = new Borne();
            this.automate = new Automate(this.metier);
        }

        /// <summary>
        /// Insertion d'un ticket dans la fente
        /// </summary>
        /// <param name="ticket">Le ticket inséré</param>
        /// <returns>Action valide ou non</returns>
        public void InsertionTicket(TicketVM ticket)
        {
        }

        /// <summary>
        /// Insertion de la carte bancaire dans la fente
        /// </summary>
        /// <param name="carteBancaire">La carte bancaire insérée</param>
        /// <returns>Action valide ou non</returns>
        public void InsertionCarteBancaire(CarteBancaireVM carteBancaire)
        {
        }

        /// <summary>
        /// Pression d'un numéro sur le pavé numérique de la borne
        /// </summary>
        /// <param name="numero">Numéro saisi</param>
        /// <returns>Action valide ou non</returns>
        public void AjoutNumeroCode(int numero)
        {
        }

        /// <summary>
        /// Passage de la CB devant le sans contact
        /// </summary>
        /// <param name="carteBancaire">La carte bancaire insérée</param>
        /// <returns>Action valide ou non</returns>
        public void InsertionCarteBancaireSansContact(CarteBancaireVM carteBancaire)
        {
        }

        /// <summary>
        /// Demande d'un reçu
        /// </summary>
        /// <returns>Action valide ou non</returns>
        public void DemandeRecu()
        {
        }

        /// <summary>
        /// Annulation
        /// </summary>
        /// <returns>Action valide ou non</returns>
        public void Annulation()
        {
        }

        /// <summary>
        /// Appel d'un assistant
        /// </summary>
        /// <returns>Action valide ou non</returns>
        public void AppelHelp()
        {
        }

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
