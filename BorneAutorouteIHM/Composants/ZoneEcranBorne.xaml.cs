using BorneAutorouteIHM.Composants.ElementsMobiles;
using BorneAutorouteIHM.Composants.ZoneEcranBornes;
using BorneAutorouteVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BorneAutorouteIHM.Composants
{
    /// <summary>
    /// Zone pour l'écran de la borne
    /// </summary>
    public abstract partial class ZoneEcranBorne : UserControl
    {

        /// <summary>
        /// Type de la zone
        /// </summary>
        public abstract TypeZone TypeZone { get; }

        //Vue Modèle
        private BorneVM vueModele;
        protected BorneVM VueModele => this.vueModele;

        /// <summary>
        /// Constructeur
        /// </summary>
        /// <param name="numeroZone">Numéro de la zone</param>
        /// <param name="titre">Titre de la zone</param>
        public ZoneEcranBorne(BorneVM borneVM,int numeroZone,string titre)
        {
            this.vueModele = borneVM;

            InitializeComponent();

            //Gestion du titre
            this.LabelNumeroEtape.Content = numeroZone;
            this.LabelNomEtape.Content = titre;

            //Gestion des couleurs
            this.PanelFond.Background = Couleurs.CouleurFondBleu;
            this.LabelNumeroEtape.Foreground = Couleurs.CouleurTexteClair;
            this.LabelNomEtape.Foreground = Couleurs.CouleurTexteClair;
        }

        /// <summary>
        /// Ajoute une élément au gridPanel du contenu
        /// </summary>
        /// <param name="control">L'élément à ajouter</param>
        protected void AjouterContenu(UIElement control)
        {
            this.PanelContenu.Children.Add(control);
        }
    }
}
