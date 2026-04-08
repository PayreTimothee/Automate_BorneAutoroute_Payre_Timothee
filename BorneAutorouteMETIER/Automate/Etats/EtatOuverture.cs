using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BorneAutorouteMETIER.Automate.Etats
{
    /// <summary>
    /// Etat d'ouverture de la barrière
    /// </summary>
    public class EtatOuverture : Etat
    {
        public EtatOuverture(Borne metier) : base(metier)
        {
        }

        public override string Nom => "Ouverture";

        public override string Message => "Barrière ouverte, bonne journée !";

        public override void Action(Evenement e)
        {

        }

        public override Etat Transition(Evenement e)
        {
            throw new NotImplementedException();
        }
    }
}
