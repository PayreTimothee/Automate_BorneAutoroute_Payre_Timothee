using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BorneAutorouteMETIER.Automate
{
    /// <summary>
    /// Classe abstraite représentant un état de la borne autoroute
    /// </summary>
    public abstract class Etat
    {
        private Borne metier;
        private string nom;

        /// <summary>
        /// Métier de la borne autoroute
        /// </summary>
        public Borne Metier => this.metier;

        /// <summary>
        /// Nom de l'état
        /// </summary>
        public abstract string Nom { get; }

        /// <summary>
        /// Initialise l'état
        /// </summary>
        /// <param name="metier">le métier du programme</param>
        public Etat(Borne metier)
        {
            this.metier = metier;
        }

        /// <summary>
        /// Transition vers un nouvel état en fonction de l'événement reçu
        /// </summary>
        /// <param name="e">L'evenement</param>
        /// <returns>un état</returns>
        public abstract Etat Transistion(Evenement e);

        /// <summary>
        /// L'action à effectuer lors de l'entrée dans cet état en fonction de l'événement reçu
        /// </summary>
        /// <param name="e">l'évenement</param>
        public abstract void Action(Evenement e);   
    }
}
