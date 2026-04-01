using BorneAutorouteIHM.Ecrans;
using BorneAutorouteIHM.Ecrans.Realisations;
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

namespace BorneAutorouteIHM.Fenetres
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class FenetrePrincipal : Window, IFenetre
    {

        //Ecran actuellement affiché
        private Ecran? ecran;

        /// <summary>
        /// Constructeur
        /// </summary>
        /// <param name="borneVM">Vue-Modèle de la borne</param>
        public FenetrePrincipal(BorneVM borneVM)
        {
            InitializeComponent();

            //Gestion de la taille
            this.Width = (SystemParameters.PrimaryScreenWidth * 80) / 100;
            this.Height = (SystemParameters.PrimaryScreenHeight * 80) / 100;

            //Gestion des couleurs
            this.GridEcran.Background = Couleurs.CouleurFondGris;

            //Chargement de l'écran
            this.ChangerEcran(new EcranBorne(this,borneVM));
        }

        public void ChangerEcran(Ecran nouvelEcran)
        {
            this.ecran = nouvelEcran;
            this.GridEcran.Children.Clear();
            this.GridEcran.Children.Add(nouvelEcran);
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (this.ecran != null) this.ecran.OnKeyPress(e.Key);
            e.Handled = true;
        }
    }
}
