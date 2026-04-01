using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BorneAutorouteEXCEPTION.Fonctionnement.Realisations
{
    /// <summary>
    /// Exception levée si on cherche à mettre un ticket dans la machine alors qu'elle en possède déjà un
    /// </summary>
    public class TicketDejaPresentException : FonctionnementException
    {
        public TicketDejaPresentException() : base("Un ticket est déjà présent dans la machine !")
        {
        }
    }
}
