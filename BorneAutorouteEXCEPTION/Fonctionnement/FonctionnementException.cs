using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BorneAutorouteEXCEPTION.Fonctionnement
{
    /// <summary>
    /// Exception générale liée au fonctionnement de la borne
    /// </summary>
    public abstract class FonctionnementException : BorneAutorouteException
    {
        /// <summary>
        /// Constructeur
        /// </summary>
        /// <param name="message">Message de l'exception</param>
        public FonctionnementException(string message) : base("Erreur de fonctionnement", message)
        {
        }
    }
}
