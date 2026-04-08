using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using Timer = System.Timers.Timer;

namespace BorneAutorouteMETIER.Automate.Etats
{
    /// <summary>
    /// Etat d'ouverture de la barrière
    /// </summary>
    public class EtatOuverture : Etat
    {
        public static Timer timer;

        public EtatOuverture(Borne metier, Automate automate) : base(metier, automate)
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

        public override string Nom => "Ouverture";

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
            Etat etat;  
            switch (e)
            {
                case Evenement.RESET:
                    etat = new EtatAttenteClient(Metier, Automate);
                    break;
                default:
                    etat = this;
                    break;
            }
            return etat;
        }

        private void Time_Elapsed(object? sender, ElapsedEventArgs  e)
        {
            this.Automate.Activer(Evenement.RESET); //active le reset pour revenir à l'état initial
            timer.Dispose(); //libère les ressources utilisées par le timer
            timer = null; //réinitialise le timer
        }
    }
}
