using BorneAutorouteIHM.Ressources;
using BorneAutorouteVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;

namespace BorneAutorouteIHM.Composants.ZoneEcranBornes
{
    /// <summary>
    /// Zone pour le ticket
    /// </summary>
    public class ZoneTicket : ZoneEcranBorne
    {
        public override TypeZone TypeZone => TypeZone.TICKET;

        public ZoneTicket(BorneVM borneVM) : base(borneVM, 1, "Ticket")
        {
            //Création d'un dockPanel
            DockPanel dockPanel = new DockPanel();
            dockPanel.Margin = new System.Windows.Thickness(50, 10, 50, 20);

            //Image de la fente placé en bas du panel
            Image imageFente = new Image()
            {
                Source = ImageManager.GetImage("Fente")
            };
            RenderOptions.SetBitmapScalingMode(imageFente, BitmapScalingMode.HighQuality);

            DockPanel.SetDock(imageFente, Dock.Bottom);
            dockPanel.Children.Add(imageFente);

            //Complétion
            dockPanel.Children.Add(new Grid());


            this.AjouterContenu(dockPanel);
        }
    }
}
