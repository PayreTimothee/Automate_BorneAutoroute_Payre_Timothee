using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using BorneAutorouteEXCEPTION.Fonctionnement.Realisations;
using BorneAutorouteMETIER.Elements;

namespace BorneAutorouteMETIER
{
    /// <summary>
    /// La borne
    /// </summary>
    public class Borne : INotifyPropertyChanged
    {
        //Ticket présent dans la machine
        private Ticket? ticket;
        //CarteBancaire présente dans la machine
        private CarteBancaire? carteBancaire;
        //CarteBancaire lue par le lecteur sans contact
        private CarteBancaire? carteBancaireLueParSansContact;

        public event PropertyChangedEventHandler? PropertyChanged;

        /// <summary>
        /// Getteur du montant du ticket présent dans la machine, ou 0 si aucun ticket n'est présent
        /// </summary>
        public double Montant => this.ticket?.Montant ?? 0.0;

        /// <summary>
        /// Getteur de la carte bancaire présente dans la machine pour savoir si elle est valide ou non, ou null si aucune carte bancaire n'est présente
        /// </summary>
        public bool EstValide => this.carteBancaireLueParSansContact != null && this.carteBancaireLueParSansContact.EstValide;
        /// <summary>
        /// Insertion d'un ticket dans la machine
        /// </summary>
        /// <param name="ticket">Ticket inséré</param>
        /// <exception cref="TicketDejaPresentException">Si un autre ticket est déjà dans la machine</exception>
        public void InsertionTicket(Ticket ticket)
        {
            //Si un ticket est déjà présent
            if (this.ticket != null) throw new TicketDejaPresentException();
            //Sinon
            this.ticket = ticket;
            this.ticket.EstDansMachine = true;
        }

        /// <summary>
        /// Insertion d'une nouvelle carte bancaire
        /// </summary>
        /// <param name="carteBancaire">Nouvelle CB</param>
        /// <exception cref="CarteBancaireDejaPresenteException">Si une CB est déjà présente dans la machine</exception>
        public void InsertionCarteBancaire(CarteBancaire carteBancaire)
        {
            //Si une CB est déjà présente
            if (this.carteBancaire != null) throw new CarteBancaireDejaPresenteException();
            //Sinon
            this.carteBancaire = carteBancaire;
            this.carteBancaire.EstDansMachine = true;

        }

        /// <summary>
        /// Lecture d'une nouvelle CB par le lecteur sans contact
        /// </summary>
        /// <param name="carteBancaire">La nouvelle CB lue</param>
        public void LireCarteBancaireParSansContact(CarteBancaire carteBancaire)
        {
            this.carteBancaireLueParSansContact = carteBancaire;
        }

        /// <summary>
        /// Reset la borne en retirant le ticket et les cartes bancaires présentes
        /// </summary>
        public void Reset()
        {
            this.ticket = null;
            this.carteBancaire = null;
            this.carteBancaireLueParSansContact = null;
        }

        /// <summary>
        /// Annulation de la transaction en cours, qui ejecte le ticket
        /// </summary>
        public void Annulation()
        {
            if (this.ticket != null)
            {
                this.ticket.EstDansMachine = false;
            }
            this.Reset();
        }

        public void ImprimerRecu()
        {
            NotifyPropertyChanged("NouveauRecu");
        }

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
