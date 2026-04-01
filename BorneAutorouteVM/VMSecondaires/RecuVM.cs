using BorneAutorouteMETIER.Elements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BorneAutorouteVM.VMSecondaires
{
    /// <summary>
    /// Vue-modèle du reçu
    /// </summary>
    public class RecuVM
    {
        //Le reçu (métier)
        private Recu metier;
        
        /// <summary>
        /// Constructeur
        /// </summary>
        /// <param name="metier">Le reçu</param>
        public RecuVM()
        {
            this.metier = new Recu();
        }
    }
}
