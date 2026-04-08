using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BorneAutorouteMETIER.Automate.Etats
{
    /// <summary>
    /// Etat d'attente du client, la borne attend que le client insère son ticket pour pouvoir ouvrir la barrière
    /// </summary>
    public class EtatAttenteClient : Etat
    {
        public EtatAttenteClient(Borne metier, Automate automate) : base(metier,automate)
        {
        }

        public override string Nom => "AttenteClient";

        public override string Message => "Bonjour, insérez votre ticket !";

        public override void Action(Evenement e)
        {
            
        }

        public override Etat Transition(Evenement e)
        {
            Etat etat = this;
            switch (e)
            {
                case Evenement.INSERTION_TICKET:
                    etat = new EtatAttenteDePaiement(Metier, Automate);
                    break;
                default:
                    etat = this;
                    break;
            }
            return etat;
        }
    }
}
