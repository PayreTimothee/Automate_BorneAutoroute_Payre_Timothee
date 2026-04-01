using BorneAutorouteIHM.Composants.ZoneEcranBornes;
using System.Windows.Controls;

namespace BorneAutorouteIHM.Composants.ElementsMobiles
{
    /// <summary>
    /// Element déplaçable sur l'écran
    /// </summary>
    public abstract class ElementDeplacable : Grid
    {
        /// <summary>
        /// Type de l'élément remplaçable
        /// </summary>
        public abstract TypeElementDeplacable TypeElement { get; }
    }
}
