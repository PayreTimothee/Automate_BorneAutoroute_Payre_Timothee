using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BorneAutorouteEXCEPTION.GestionRessources
{
    /// <summary>
    /// Exception générale liée à la gestion des ressources (images...)
    /// </summary>
    public abstract class GestionRessourcesException : BorneAutorouteException
    {
        /// <summary>
        /// Constructeur
        /// </summary>
        /// <param name="message">Message de l'exception</param>
        public GestionRessourcesException(string message) : base("Erreur de gestion des ressources", message)
        {
        }
    }
}
