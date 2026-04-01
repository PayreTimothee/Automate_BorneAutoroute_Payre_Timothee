using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;

namespace BorneAutorouteIHM.Composants.Boutons
{
    /// <summary>
    /// Bouton du clavier de saisi du code
    /// </summary>
    public class BoutonCarte : Grid
    {

        private TextBlock text;

        /// <summary>
        /// Constructeur
        /// </summary>
        /// <param name="num">Numéro du bouton</param>
        public BoutonCarte(int num)
        {
            Background = Couleurs.CouleurBordure;
            text = new TextBlock();
            text.Text = num.ToString();
            text.FontFamily = new FontFamily("Roboto");
            text.FontSize = 40;
            text.Foreground = Couleurs.CouleurTexteClair;
            text.VerticalAlignment = System.Windows.VerticalAlignment.Center;
            text.HorizontalAlignment = System.Windows.HorizontalAlignment.Center;
            Children.Add(text);

            MouseDown += BoutonCarte_MouseDown;
            MouseUp += BoutonCarte_MouseUp;
            MouseLeave += BoutonCarte_MouseLeave; ;
        }

        //Exit
        private void BoutonCarte_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            text.Foreground = Couleurs.CouleurTexteClair;
        }

        //Relachement de la souris
        private void BoutonCarte_MouseUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            text.Foreground = Couleurs.CouleurTexteClair;
        }

        //Pression de la souris
        private void BoutonCarte_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            text.Foreground = Couleurs.CouleurVert;
        }

    }
}
