using BorneAutorouteIHM.Composants.Boutons;
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
    /// Zone pour le reçu
    /// </summary>
    public class ZoneRecu : ZoneEcranBorne
    {
        public override TypeZone TypeZone => TypeZone.RECU;

        public ZoneRecu(BorneVM borneVM) : base(borneVM, 3, "Reçu")
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

            //Image du bouton
            Image imageBouton = new BoutonPressoir("BoutonVert")
            {
                Margin = new System.Windows.Thickness(80, 20, 80, 80)
            };
            imageBouton.MouseDown += (s, e) => this.VueModele.DemandeRecu();

            DockPanel.SetDock(imageBouton, Dock.Bottom);

            dockPanel.Children.Add(imageBouton);
            //Complétion
            dockPanel.Children.Add(new Grid());


            this.AjouterContenu(dockPanel);
        }
    }
}
