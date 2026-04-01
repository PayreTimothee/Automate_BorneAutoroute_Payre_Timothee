using BorneAutorouteIHM.Ressources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;

namespace BorneAutorouteIHM.Composants.Boutons
{
    //Bouton pressoir
    public class BoutonPressoir : Image
    {
        //Base du nom de l'image
        private string nomBaseImage;

        /// <summary>
        /// Constructeur
        /// </summary>
        /// <param name="nomBaseImage">Base du nom de l'image</param>
        public BoutonPressoir(string nomBaseImage)
        {
            this.nomBaseImage = nomBaseImage;
            this.Source = ImageManager.GetImage(this.nomBaseImage);
            RenderOptions.SetBitmapScalingMode(this, BitmapScalingMode.HighQuality);
            this.MouseDown += BoutonPressoir_MouseDown;
            this.MouseUp += BoutonPressoir_MouseUp;
            this.MouseLeave += BoutonPressoir_MouseLeave;
        }

        private void BoutonPressoir_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            this.Source = ImageManager.GetImage(this.nomBaseImage);
        }

        private void BoutonPressoir_MouseUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            this.Source = ImageManager.GetImage(this.nomBaseImage);
        }

        private void BoutonPressoir_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            this.Source = ImageManager.GetImage(this.nomBaseImage + "Click");
        }
    }
}
