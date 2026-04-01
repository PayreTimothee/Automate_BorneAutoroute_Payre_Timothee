using BorneAutorouteIHM.Fenetres;
using BorneAutorouteVM;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace BorneAutorouteIHM
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        //Start the application
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            BorneVM borneVM = new BorneVM();
            new FenetrePrincipal(borneVM).Show();
        }
    }
}
