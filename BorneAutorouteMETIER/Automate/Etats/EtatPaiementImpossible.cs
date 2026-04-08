using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BorneAutorouteMETIER.Automate.Etats
{
    /// <summary>
    /// Etat de paiement impossible
    /// </summary>
    public class EtatPaiementImpossible : Etat
    {
        public EtatPaiementImpossible(Borne metier, Automate automate) : base(metier, automate)
        {
        }

        public override string Nom => "PaiementImpossible";

        public override string Message => "Paiement impossible";

        public override void Action(Evenement e)
        {

        }

        public override Etat Transition(Evenement e)
        {
            throw new NotImplementedException();
        }
    }
}
