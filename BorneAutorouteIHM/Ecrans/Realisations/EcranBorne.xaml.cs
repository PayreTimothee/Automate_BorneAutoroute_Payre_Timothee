using BorneAutorouteEXCEPTION;
using BorneAutorouteIHM.Composants;
using BorneAutorouteIHM.Composants.Boutons;
using BorneAutorouteIHM.Composants.ElementsMobiles;
using BorneAutorouteIHM.Composants.ZoneEcranBornes;
using BorneAutorouteIHM.Fenetres;
using BorneAutorouteIHM.Ressources;
using BorneAutorouteVM;
using BorneAutorouteVM.VMSecondaires;
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

namespace BorneAutorouteIHM.Ecrans.Realisations
{
    /// <summary>
    /// Ecran principal de la borne d'autoroute
    /// </summary>
    public partial class EcranBorne : Ecran
    {

        private ElementDeplacable? objetDrag;
        private Point positionDepart;

        private BorneVM vueModele;

        /// <summary>
        /// Constructeur
        /// </summary>
        /// <param name="fenetre">Fenêtre portant l'écran</param>
        /// <param name="borneVM">Vue-Modèle de la borne</param>
        public EcranBorne(IFenetre fenetre,BorneVM borneVM) : base(fenetre)
        {
            //Vue-Modèle
            this.vueModele = borneVM;
            this.DataContext = borneVM;

            InitializeComponent();

            //Gestion des couleurs
            this.PanelFond.Background = Couleurs.CouleurFondGris;

            //Ajout de la zone de texte
            this.BorderZoneAffichage.Background = Couleurs.CouleurFondNoir;
            this.BorderZoneAffichage.BorderBrush = Couleurs.CouleurBordure;
            this.ZoneAffichage.Foreground = Couleurs.CouleurTexteClair;

            //Ajout des zones centrales
            ZoneEcranBorne[] zones = { new ZoneTicket(borneVM), new ZoneCarte(borneVM), new ZoneSansContact(borneVM), new ZoneRecu(borneVM) };
            for (int i = 0; i < zones.Length; i++)
            {
                Grid.SetColumn(zones[i], i);
                this.PanelZones.Children.Add(zones[i]);
            }

            //Ajout des zones basses
            Image boutonAnnuler = new BoutonPressoir("BoutonRouge")
            {
                Margin = new Thickness(90)
            };
            boutonAnnuler.MouseDown += (s, e) => this.vueModele.Annulation();
            Grid.SetColumn(boutonAnnuler,0);
            this.PanelBas.Children.Add(boutonAnnuler);
            Image boutonHelp = new BoutonPressoir("BoutonHelp")
            {
                Margin = new Thickness(90)
            };
            boutonHelp.MouseDown += (s, e) => this.vueModele.AppelHelp();
            Grid.SetColumn(boutonHelp, 1);
            this.PanelBas.Children.Add(boutonHelp);

            Grid bordureZoneDepot = new Grid()
            {
                Background = Couleurs.CouleurBordure,
                Margin = new Thickness(10,20,20,20)
            };
            Grid.SetColumn(bordureZoneDepot, 2);
            Grid zoneDepot = new Grid()
            {
                Background = Couleurs.CouleurFondNoir,
                Margin = new Thickness(5)
            };
            bordureZoneDepot.Children.Add(zoneDepot);
            this.PanelBas.Children.Add(bordureZoneDepot);

            //Carte bleu
            CarteBancaire cb = new CarteBancaire(new CarteBancaireVM());
            this.AjouterDeplacable(cb, 1045, 490);
            //Tickets
            this.AjouterTickets();
        }

        private void AjouterRecu()
        {
            Recu recu = new Recu(new RecuVM());
            this.AjouterDeplacable(recu, 1317, 390);
        }

        //Ajoute 2 tickets
        private void AjouterTickets()
        {
            //Ticket
            Ticket ticket = new Ticket(new TicketVM());
            this.AjouterDeplacable(ticket, 840, 485);
            //Ticket
            Ticket ticket2 = new Ticket(new TicketVM());
            this.AjouterDeplacable(ticket2, 850, 495);
        }

        //Ajoute un élément déplaçable sur l'écran et activant les zones lors du dépot
        private void AjouterDeplacable(ElementDeplacable elementDeplacable,int left,int top)
        {
            Canvas.SetLeft(elementDeplacable, left);
            Canvas.SetTop(elementDeplacable, top);
            elementDeplacable.PreviewMouseLeftButtonDown += Deplacable_PreviewMouseDown;
            elementDeplacable.MouseMove += Deplacable_MouseMove;
            elementDeplacable.PreviewMouseLeftButtonUp += Deplacable_PreviewMouseLeftButtonUp;
            this.PanelFront.Children.Add(elementDeplacable);
        }


        //Click sur un élément déplaçable
        private void Deplacable_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (this.objetDrag == null)
            {
                this.objetDrag = sender as ElementDeplacable;
                this.positionDepart = e.GetPosition(this.PanelFront);
                this.objetDrag?.CaptureMouse();
            }
        }

        //Relachement de la souris sur un objet déplaçable
        private void Deplacable_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if(this.objetDrag == sender)
            {
                this.objetDrag.ReleaseMouseCapture();
                this.objetDrag = null;
                this.Depot_ElementDeplacable(sender as ElementDeplacable, e);
            }
        }

        //Déplacement d'un objet déplaçable
        private void Deplacable_MouseMove(object sender, MouseEventArgs e)
        {
            if(this.objetDrag == sender)
            {
                double deltaX = e.GetPosition(this.PanelFront).X - positionDepart.X;
                double deltaY = e.GetPosition(this.PanelFront).Y - positionDepart.Y;

                Canvas.SetLeft(this.objetDrag, Canvas.GetLeft(this.objetDrag) + deltaX);
                Canvas.SetTop(this.objetDrag, Canvas.GetTop(this.objetDrag) + deltaY);

                this.positionDepart = e.GetPosition(this.PanelFront);
            }
        }

        //Dépot d'un objet déplaçable sur un l'écran => détection des zones activées
        private void Depot_ElementDeplacable(ElementDeplacable? sender, MouseButtonEventArgs e)
        {
            // On récupère l'élément le plus bas touché par le click
            HitTestResult result = VisualTreeHelper.HitTest(this.PanelZones, e.GetPosition(this.PanelZones));
            if (result != null)
            {
                //On remonte jusqu'à trouver une ZoneEcranBorne
                DependencyObject obj = result.VisualHit;
                while (obj != null && obj != sender)
                {
                    if (obj is ZoneEcranBorne)
                        //On invoque manuellement le dépôt
                        this.Depot(((ZoneEcranBorne)obj).TypeZone,sender);
                   obj = VisualTreeHelper.GetParent(obj);
                }
            }
        }

        //Dépot d'un ticket
        private void DepotTicket(TypeZone zone, Ticket ticket)
        {
            if (zone == TypeZone.TICKET) this.vueModele.InsertionTicket(ticket.VueModele);
        }

        //Dépot d'une CB
        private void DepotCarteBancaire(TypeZone zone, CarteBancaire cb)
        {
            if(zone == TypeZone.CARTEBANCAIRE) this.vueModele.InsertionCarteBancaire(cb.VueModele);
            else if(zone == TypeZone.SANSCONTACT) this.vueModele.InsertionCarteBancaireSansContact(cb.VueModele);
        }

        //Activation du dépot d'un objet sur une zone
        private void Depot(TypeZone zone,ElementDeplacable element)
        {
            try
            {
                switch(element.TypeElement)
                {
                    case TypeElementDeplacable.TICKET: this.DepotTicket(zone,(Ticket)element); break;
                    case TypeElementDeplacable.CARTEBANCAIRE: this.DepotCarteBancaire(zone, (CarteBancaire)element); break;
                }
            }
            catch(BorneAutorouteException e)
            {
                e.Afficher();
            }
        }
        
        public override void OnKeyPress(Key key)
        {
            //Reset
            if(key == Key.Escape) 
            {
                this.Fenetre.ChangerEcran(new EcranBorne(this.Fenetre,new BorneVM()));
            }
            //Ajout de ticket
            else if (key == Key.N)
            {
                this.AjouterTickets();
            }
        }

    }
}
