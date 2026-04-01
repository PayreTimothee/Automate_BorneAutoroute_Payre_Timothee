using BorneAutorouteIHM.Ecrans;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BorneAutorouteIHM.Fenetres
{
    /// <summary>
    /// Interface d'une fenêtre
    /// </summary>
    public interface IFenetre
    {
        /// <summary>
        /// Change l'écran affiché par la fenêtre
        /// </summary>
        /// <param name="nouvelEcran">Le nouvel écran</param>
        void ChangerEcran(Ecran nouvelEcran);
    }
}
