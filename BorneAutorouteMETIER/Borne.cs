using BorneAutorouteEXCEPTION.Fonctionnement.Realisations;
using BorneAutorouteMETIER.Elements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BorneAutorouteMETIER
{
    /// <summary>
    /// La borne
    /// </summary>
    public class Borne
    {
        //Ticket présent dans la machine
        private Ticket? ticket;
        //CarteBancaire présente dans la machine
        private CarteBancaire? carteBancaire;
        //CarteBancaire lue par le lecteur sans contact
        private CarteBancaire? carteBancaireLueParSansContact;

        /// <summary>
        /// Getteur du montant du ticket présent dans la machine, ou 0 si aucun ticket n'est présent
        /// </summary>
        public double Montant => this.ticket?.Montant ?? 0.0;

        /// <summary>
        /// Insertion d'un ticket dans la machine
        /// </summary>
        /// <param name="ticket">Ticket inséré</param>
        /// <exception cref="TicketDejaPresentException">Si un autre ticket est déjà dans la machine</exception>
        public void InsertionTicket(Ticket ticket)
        {
            //Si un ticket est déjà présent
            if(this.ticket != null) throw new TicketDejaPresentException();
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
            if(this.carteBancaire != null) throw new CarteBancaireDejaPresenteException();
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
    }
}
