using BorneAutorouteEXCEPTION.GestionRessources.Realisations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace BorneAutorouteIHM.Ressources
{
    /// <summary>
    /// Manager pour les image
    /// </summary>
    public class ImageManager
    {
        //Dictionnaire des images chargées
        private Dictionary<string, BitmapImage> images;
        //Dictionnaire du chemin des images
        private Dictionary<string, string> adresses;

        /// <summary>
        /// Singleton
        /// </summary>
        private static ImageManager? instance;

        private static ImageManager Instance
        {
            get
            {
                if (instance == null) instance = new ImageManager();
                return instance;
            }
        }

        /// <summary>
        /// Constructeur
        /// </summary>
        private ImageManager()
        {
            //Initialisation
            adresses = new Dictionary<string, string>();
            images = new Dictionary<string, BitmapImage>();

            //Borne
            AjouterImage("Fente", "/Ressources/Images/Fente.png");
            //Boutons
            AjouterImage("BoutonVert", "/Ressources/Images/BoutonVert.png");
            AjouterImage("BoutonRouge", "/Ressources/Images/BoutonRouge.png");
            AjouterImage("BoutonHelp", "/Ressources/Images/BoutonHelp.png");
            AjouterImage("BoutonVertClick", "/Ressources/Images/BoutonVertClick.png");
            AjouterImage("BoutonRougeClick", "/Ressources/Images/BoutonRougeClick.png");
            AjouterImage("BoutonHelpClick", "/Ressources/Images/BoutonHelpClick.png");
            //CB
            AjouterImage("SansContact", "/Ressources/Images/SansContact.png");
            AjouterImage("CarteBancaire", "/Ressources/Images/CarteBancaire.png");
            AjouterImage("CarteBancaireFaux", "/Ressources/Images/CarteBancaireFaux.png");
            //Ticket
            AjouterImage("Ticket", "/Ressources/Images/Ticket.png");
            //Recu
            AjouterImage("Recu", "/Ressources/Images/Recu.png");

        }

        /// <summary>
        /// Ajoute une image dans la base des chemins
        /// </summary>
        /// <param name="nom">Nom de l'image</param>
        /// <param name="path">Chemin du fichier</param>
        private void AjouterImage(string nom, string path)
        {
            adresses[nom] = path;
        }

        /// <summary>
        /// Get an image
        /// </summary>
        /// <param name="nom">Name of the image</param>
        /// <returns>The bitmapimage</returns>
        /// <exception cref="ImageInconnueException">Si l'image n'est pas définie</exception>
        public static BitmapImage GetImage(string nom)
        {
            if (!Instance.images.ContainsKey(nom))
            {
                if (Instance.adresses.ContainsKey(nom))
                {
                    Instance.images[nom] = new BitmapImage(new Uri("pack://application:,,,/BorneAutorouteIHM;component/" + Instance.adresses[nom]));
                }
                else throw new ImageInconnueException(nom);
            }
            return Instance.images[nom];
        }
    }
}
