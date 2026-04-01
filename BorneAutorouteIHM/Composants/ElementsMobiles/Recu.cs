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
    //Un reçu
    public class Recu : ElementDeplacable
    {
        
        //Vue-Modèle
        private RecuVM vueModele;
        /// <summary>
        /// Le vue-Modèle
        /// </summary>
        public RecuVM VueModele => vueModele;

        //Image du reçu
        private Image image;

        public override TypeElementDeplacable TypeElement => TypeElementDeplacable.RECU;

        public Recu(RecuVM vueModele)
        {
            //Vue-Modèle
            this.vueModele = vueModele;

            //Gestion de la taille
            this.Height = 230;
            this.Width = 246 * this.Height / 383.0;

            //Gestion de l'image
            this.image = new Image();
            this.image.Source = ImageManager.GetImage("Recu");
            this.Children.Add(image);
        }
    }
}