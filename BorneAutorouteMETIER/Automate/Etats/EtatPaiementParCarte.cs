using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BorneAutorouteMETIER.Automate.Etats
{
    public class EtatPaiementParCarte : Etat
    {
        private string codeSaisie;
        public EtatPaiementParCarte(Borne metier, Automate automate, string codeSaisie) : base(metier, automate)
        {
            this.codeSaisie = codeSaisie;
        }

        public override string Nom => "EtatPaiementParCarte";

        public override string Message => $"Carte insérée. Montant à régler : {this.Metier.Montant}";

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
                case Evenement.SAISIE_DU_CODE:
                    string code = this.codeSaisie + this.Metier.ChiffreCode;
                    if (code.Length == 4) { 
                        if (this.Metier.EstValide && code == this.Metier.Code)
                        {
                            etat = new EtatOuverture(Metier, Automate);
                        }
                        else
                        {
                            etat = new EtatPaiementImpossible(Metier, Automate);
                        }
                    }
                    else
                    {
                        etat = new EtatPaiementParCarte(Metier, Automate, code);
                    }
                    break;
                case Evenement.ANNULATION:
                    etat = new EtatAttenteClient(Metier, Automate);
                    break;
            }
            return etat;
        }
    }
}
