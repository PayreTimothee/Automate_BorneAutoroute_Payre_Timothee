using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace BorneAutorouteMETIER.Automate.Etats
{
    /// <summary>
    /// Etat d'attente de paiement, la borne attend que le client règle le montant à payer pour pouvoir ouvrir la barrière
    /// </summary>
    public class EtatAttenteDePaiement : Etat
    {
        public EtatAttenteDePaiement(Borne metier) : base(metier)
        {
        }

        public override string Nom => "AttenteDePaiement";

        public override string Message => $"Montant à régler : {this.Metier.Montant}";

        public override void Action(Evenement e)
        {

        }

        public override Etat Transition(Evenement e)
        {
            Etat etat = this;
            switch (e)
            {
                case Evenement.PAIEMENT_SANS_CONTACT:
                    etat = new EtatOuverture(Metier);
                    break;
                default:
                    etat = this;
                    break;
            }
            return etat;
        }
    }
}
