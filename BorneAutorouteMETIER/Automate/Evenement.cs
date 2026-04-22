using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BorneAutorouteMETIER.Automate
{
    public enum Evenement
    {
        INSERTION_TICKET,
        PAIEMENT_SANS_CONTACT,
        RESET,
        ANNULATION,
        REESAYER_PAIEMENT,
        DEMANDE_RECU,
        PAIEMENT_AVEC_CARTE_BANCAIRE,
        SAISIE_DU_CODE,
    }
}
