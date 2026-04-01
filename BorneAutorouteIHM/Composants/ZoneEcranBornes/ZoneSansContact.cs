using BorneAutorouteIHM.Ressources;
using BorneAutorouteVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace BorneAutorouteIHM.Composants.ZoneEcranBornes
{
    /// <summary>
    /// Zone pour le paiement sans contact
    /// </summary>
    public class ZoneSansContact : ZoneEcranBorne
    {
        public override TypeZone TypeZone => TypeZone.SANSCONTACT;

        public ZoneSansContact(BorneVM borneVM) : base(borneVM, 2, "Sans contact")
        {
            Grid grid = new Grid();
            grid.Background = Couleurs.CouleurFondNoir;
            grid.Margin = new System.Windows.Thickness(90,50,90,50);

            Grid ingrid = new Grid();
            ingrid.Background = Couleurs.CouleurBordure;
            ingrid.Margin = new System.Windows.Thickness(5);

            Image image = new Image()
            {
                Source = ImageManager.GetImage("SansContact"),
                Margin = new System.Windows.Thickness(40)
            };
            grid.Children.Add(ingrid);
            ingrid.Children.Add(image);

            this.AjouterContenu(grid);
        }
    }
}
