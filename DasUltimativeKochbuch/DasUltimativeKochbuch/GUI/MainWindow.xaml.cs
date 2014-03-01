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
using DasUltimativeKochbuch.Core;

namespace DasUltimativeKochbuch
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {

            InitializeComponent();
            
            Coreinit.ini();
        }

        private void Rezept_hinzufügen_Click(object sender, RoutedEventArgs e)
        {
            view.NavigationService.Navigate(new Uri("GUI\\Rezept_erstellen.xaml", UriKind.Relative));
            Hauptfenster.Title = "Das Ultimative Kochbuch - Rezept hinzufügen";
        }

        private void Rezept_suchen_Click(object sender, RoutedEventArgs e)
        {
            view.NavigationService.Navigate(new Uri("GUI\\Rezept_suchen.xaml", UriKind.Relative));
            Hauptfenster.Title = "Das Ultimative Kochbuch - Rezept suchen";
        }


    }
}
