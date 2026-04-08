using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace BorneAutorouteMETIER.Automate.Etats
{
    /// <summary>
    /// Etat de paiement impossible
    /// </summary>
    public class EtatPaiementImpossible : Etat
    {

        private static Timer timer = null;

        public EtatPaiementImpossible(Borne metier, Automate automate) : base(metier, automate)
        {
            timer = null;
            if (timer == null)
            {
                timer = new Timer(2000); //Met un timer de 2 secondes 
                timer.Elapsed += Time_Elapsed; //Abonne la méthode Time_Elapsed à l'événement Elapsed du timer(il sera appelé lorsque le timer se déclenche)
                timer.AutoReset = false; //Le timer ne se répète pas, il s'arrête après le premier déclenchement
                timer.Start();//Démarre le timer
            }
        }

        public override string Nom => "PaiementImpossible";

        public override string Message => "Paiement impossible";

        public override void Action(Evenement e)
        {

        }

        public override Etat Transition(Evenement e)
        {
            Etat etat = this;
            switch (e)
            {
                case Evenement.REESAYER_PAIEMENT:
                    etat = new EtatAttenteDePaiement(Metier, Automate);
                    break;
            }
            return etat;
        }

        private void Time_Elapsed(object? sender, ElapsedEventArgs e)
        {
            this.Automate.Activer(Evenement.REESAYER_PAIEMENT); //active le reset pour revenir à l'état initial
            timer.Dispose(); //libère les ressources utilisées par le timer
            timer = null; //réinitialise le timer
        }
    }
}
