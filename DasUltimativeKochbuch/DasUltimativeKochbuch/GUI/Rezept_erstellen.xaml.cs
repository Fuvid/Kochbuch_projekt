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
            // Hinzufügen einer neuen Zeile in das ListView Fenster.
            LVZutaten.Items.Add(
                    new Zutat(TBZutat.Text, new Einheit(TBEinehit.Text), Convert.ToDouble(TBMenge.Text))
                    );
                    //{
                    //    Zutaten = TBZutat.Text,     // Zutat auslesen und an die Spalte Zutaten binden.
                    //    Mengen = TBMenge.Text,      // Menge auslesen und an die Spalte Mengen binden.
                    //    Einheiten = TBEinehit.Text  // Einheit auslesen und an die Spalte Einheiten binden.
                    //});
        }

        private void Save_Rezept_Click(object sender, RoutedEventArgs e)
        {
            //foreach (object item in LVZutaten.Items)
            //{
            //    if (item is String)
            //    {
            //        String i = (String) item;
            //        TBZubereitung.Text = i;
            //    }
            //    else throw new Exception("WPF ist DUMM!");
            //}


        }
    }
}
