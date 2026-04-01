using System;
using System.Printing;

namespace BorneAutorouteEXCEPTION
{
    /// <summary>
    /// Exception générique du projet
    /// </summary>
    public abstract class BorneAutorouteException : Exception
    {
        //Titre de l'exception
        private string titre;

        /// <summary>
        /// Titre de l'exception
        /// </summary>
        public string Titre => this.titre;

        /// <summary>
        /// Constructeur
        /// </summary>
        /// <param name="titre">Titre de l'exception</param>
        /// <param name="message">Message de l'exception</param>
        public BorneAutorouteException(string titre, string message) : base(message)
        {
            this.titre = titre;
        }
    }
}
