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
    /// <summary>
    /// Carte bancaire
    /// </summary>
    public class CarteBancaire : ElementDeplacable
    {
        //VueModele
        private CarteBancaireVM vueModele;
        /// <summary>
        /// Le vue-Modèle
        /// </summary>
        public CarteBancaireVM VueModele => vueModele;

        //Image de la cb
        private Image image;

        public override TypeElementDeplacable TypeElement => TypeElementDeplacable.CARTEBANCAIRE;

        public CarteBancaire(CarteBancaireVM vueModele)
        {
            //Vue Modèle
            this.vueModele = vueModele;
            this.vueModele.PropertyChanged += VueModele_PropertyChanged;

            //Gestion de la taille
            this.Height = 230;
            this.Width = 246 * this.Height / 383.0;

            //Validité
            this.vueModele.EstValide = true;
            this.MouseDown += CarteBancaire_MouseDown;

            //Gestion de l'image
            this.image = new Image();
            this.Children.Add(image);
            this.MiseAJourImage();
        }

        //Changement dans le vue-modèle
        private void VueModele_PropertyChanged(object? sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "EstDansMachine")
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

        private void CarteBancaire_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if(e.ClickCount==2)
            {
                this.vueModele.EstValide = !this.vueModele.EstValide;
                this.MiseAJourImage();
            }
        }

        private void MiseAJourImage()
        {
            if (this.vueModele.EstValide) this.image.Source = ImageManager.GetImage("CarteBancaire");
            else this.image.Source = ImageManager.GetImage("CarteBancaireFaux");
        }
    }
}
