using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BorneAutorouteMETIER.Automate.EtatAttenteClient
{
    public class EtatAttenteClient : Etat
    {
        public EtatAttenteClient(Borne metier) : base(metier)
        {
        }

        public override string Nom => "AttenteClient";

        public override void Action(Evenement e)
        {
            
        }

        public override Etat Transistion(Evenement e)
        {
            Etat etat = new EtatAttenteClient(this.Metier);
            return etat;
        }
    }
}
