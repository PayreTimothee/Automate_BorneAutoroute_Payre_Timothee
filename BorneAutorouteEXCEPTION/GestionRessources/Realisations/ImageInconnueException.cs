using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BorneAutorouteEXCEPTION.GestionRessources.Realisations
{
    /// <summary>
    /// Exception levée en cas d'utilisation d'une image inconnue
    /// </summary>
    public class ImageInconnueException : GestionRessourcesException
    {
        /// <summary>
        /// Constructeur
        /// </summary>
        /// <param name="nomImage">Nom de l'image</param>
        public ImageInconnueException(string nomImage) : base("L'image : "+nomImage+" n'existe pas !")
        {
        }
    }
}
