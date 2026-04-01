using BorneAutorouteIHM.Composants.ZoneEcranBornes;
using BorneAutorouteIHM.Ressources;
using BorneAutorouteVM.VMSecondaires;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace BorneAutorouteIHM.Composants.ElementsMobiles
{
    //Un ticket pour la borne
    public class Ticket : ElementDeplacable
    {
        //Vue-Modèle
        private TicketVM vueModele;
        /// <summary>
        /// Le vue-Modèle
        /// </summary>
        public TicketVM VueModele => vueModele;

        //Image du ticket
        private Image image;

        public override TypeElementDeplacable TypeElement => TypeElementDeplacable.TICKET;

        public Ticket(TicketVM vueModele)
        {
            //Vue-Modèle
            this.vueModele = vueModele;
            this.vueModele.PropertyChanged += VueModele_PropertyChanged;

            //Gestion de la taille
            this.Height = 230;
            this.Width = 246 * this.Height / 383.0;

            //Gestion de l'image
            this.image = new Image();
            this.image.Source = ImageManager.GetImage("Ticket");
            this.Children.Add(image);
        }

        //Changement dans le vue-modèle
        private void VueModele_PropertyChanged(object? sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if(e.PropertyName == "EstDansMachine")
            {
                this.MiseAJourVisibilite();
            }
        }

        //Met à jour la visibilité 
        private void MiseAJourVisibilite()
        {
            if (this.vueModele.EstDansMachine) this.Visibility = System.Windows.Visibility.Hidden;
            else this.Visibility = System.Windows.Visibility.Visible;
        }
    }
}