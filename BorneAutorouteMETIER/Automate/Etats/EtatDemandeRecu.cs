using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BorneAutorouteMETIER.Automate.Etats
{
    /// <summary>
    /// Etat de demande de reçu
    /// </summary>
    public class EtatDemandeRecu : Etat
    {
        public EtatDemandeRecu(Borne metier, Automate automate) : base(metier, automate)
        {
        }

        public override string Nom => "Demande Recu";

        public override string Message => "Barrière ouverte, bonne journée !";

        public override void Action(Evenement e)
        {
            if (e == Evenement.RESET)
            {
                this.Metier.Reset();
            }
        }

        public override Etat Transition(Evenement e)
        {
            Etat etat = this;
            switch (e)
            {
                case Evenement.RESET:
                    etat = new EtatAttenteClient(Metier, Automate);
                    break;
                case Evenement.DEMANDE_RECU:
                    etat = this;
                    break;
            }
            return etat;
        }
    }
}
