using BorneAutorouteIHM.Fenetres;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace BorneAutorouteIHM.Ecrans
{
    /// <summary>
    /// Classe abstraite représentant un écran pour la fenêtre
    /// </summary>
    public abstract class Ecran : UserControl
    {
        //Fenêtre portant l'écran
        private IFenetre fenetre;

        /// <summary>
        /// Fenêtre portant l'écran
        /// </summary>
        protected IFenetre Fenetre => this.fenetre;

        /// <summary>
        /// Constructeur
        /// </summary>
        /// <param name="fenetre">La fenêtre portant l'écran</param>
        public Ecran(IFenetre fenetre)
        {
            this.fenetre = fenetre;
        }

        /// <summary>
        /// Méthode appelée en cas de pression d'une touche à cet écran
        /// </summary>
        /// <param name="key">Touche pressée</param>
        public virtual void OnKeyPress(Key key)
        {

        }
    }
}
