using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace BorneAutorouteIHM
{
    /// <summary>
    /// Classe statique pour la gestion des principales couleurs
    /// </summary>
    public static class Couleurs
    {
        public static Brush? CouleurFondBleu => (SolidColorBrush?)new BrushConverter().ConvertFrom("#2941bd");
        public static Brush? CouleurFondGris => (SolidColorBrush?)new BrushConverter().ConvertFrom("#c7c7c5");
        public static Brush? CouleurFondNoir => (SolidColorBrush?)new BrushConverter().ConvertFrom("#121212");
        public static Brush? CouleurTexteClair => (SolidColorBrush?)new BrushConverter().ConvertFrom("#ffffff");
        public static Brush? CouleurBordure => (SolidColorBrush?)new BrushConverter().ConvertFrom("#444444");
        public static Brush? CouleurVert => (SolidColorBrush?)new BrushConverter().ConvertFrom("#48b515");
    }
}
