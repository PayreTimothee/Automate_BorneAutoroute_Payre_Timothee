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
    /// Zone pour la carte bancaire
    /// </summary>
    public class ZoneCarte : ZoneEcranBorne
    {
        public override TypeZone TypeZone => TypeZone.CARTEBANCAIRE;

        public ZoneCarte(BorneVM borneVM) : base(borneVM,2, "Carte")
        {//Création d'un dockPanel
            DockPanel dockPanel = new DockPanel();
            dockPanel.Margin = new System.Windows.Thickness(50,10,50,20);

            //Image de la fente placé en bas du panel
            Image imageFente = new Image()
            {
                Source = ImageManager.GetImage("Fente")
            };
            RenderOptions.SetBitmapScalingMode(imageFente, BitmapScalingMode.HighQuality);

            DockPanel.SetDock(imageFente, Dock.Bottom);
            dockPanel.Children.Add(imageFente);

            //Panneau chiffres
            Grid grid = new Grid();
            grid.Width = 150;
            grid.Height = 200;
            grid.Background = Couleurs.CouleurFondNoir;
            grid.Margin = new System.Windows.Thickness(0, 0, 0, 20);

            for(int i=0;i<4;i++)
            {
                if(i!=3)
                {
                    ColumnDefinition col = new ColumnDefinition();
                    col.Width = new System.Windows.GridLength(1, System.Windows.GridUnitType.Star);
                    grid.ColumnDefinitions.Add(col);
                }
                RowDefinition row = new RowDefinition();
                row.Height = new System.Windows.GridLength(1, System.Windows.GridUnitType.Star);
                grid.RowDefinitions.Add(row);
            }

            for(int i=0; i<10;i++)
            {
                BoutonCarte bouton = new BoutonCarte(i);
                bouton.Background = Couleurs.CouleurBordure;
                bouton.Margin = new System.Windows.Thickness(2);
                if(i!=0)
                {
                    Grid.SetColumn(bouton, (i - 1) % 3);
                    Grid.SetRow(bouton, (i - 1) / 3);
                }
                else
                {
                    Grid.SetColumn(bouton, 1);
                    Grid.SetRow(bouton, 3);
                }
                int value = i;
                bouton.MouseDown += (s, e) => this.VueModele.AjoutNumeroCode(value);
                grid.Children.Add(bouton);
            }

            DockPanel.SetDock(grid, Dock.Bottom);
            dockPanel.Children.Add(grid);

            //Complétion
            dockPanel.Children.Add(new Grid());


            this.AjouterContenu(dockPanel);
        }
    }
}
