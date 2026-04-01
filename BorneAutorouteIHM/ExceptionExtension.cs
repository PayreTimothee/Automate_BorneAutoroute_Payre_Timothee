using BorneAutorouteEXCEPTION;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace BorneAutorouteIHM
{
    /// <summary>
    /// Extension de la classe d'exception pour la gestion
    /// </summary>
    public static class ExceptionExtension
    {
        /// <summary>
        /// Affichage de l'exception
        /// </summary>
        /// <param name="exception">L'exception à afficher</param>
        public static void Afficher(this BorneAutorouteException exception)
        {
            MessageBox.Show(exception.Message,exception.Titre,MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}
