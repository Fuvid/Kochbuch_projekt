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

namespace DasUltimativeKochbuch.GUI
{
    /// <summary>
    /// Interaktionslogik für Rezept_erstellen.xaml
    /// </summary>
    public partial class Rezept_erstellen : Page
    {
        public Rezept_erstellen()
        {
            InitializeComponent();
        }

        private void AddZutat_Click(object sender, RoutedEventArgs e)
        {
            string Zutat = TBZutat.Text;
            string Einheit = TBEinehit.Text;
            string Menge = TBMenge.Text;

            LVZutaten.Items.Add(
                    new
                    {
                        Zutaten = Zutat,
                        Mengen = Menge,
                        Einheiten = Einheit,
                    });
        }
    }
}
