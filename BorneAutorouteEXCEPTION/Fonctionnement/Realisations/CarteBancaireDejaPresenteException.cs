using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BorneAutorouteEXCEPTION.Fonctionnement.Realisations
{
    /// <summary>
    /// Exception levée si on cherche à mettre une CB dans la machine alors qu'elle en possède déjà une
    /// </summary>
    public class CarteBancaireDejaPresenteException : FonctionnementException
    {
        public CarteBancaireDejaPresenteException() : base("Une carte bancaire est déjà présente dans la machine !")
        {
        }
    }
}
