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
    /// Interaktionslogik für Rezept_suchen.xaml
    /// </summary>
    public partial class Rezept_suchen : Page
    {
        /**
         * Hier werden die Startwerte für die Page Rezept_suchen gesetzt
         * in der Coreinit.cs stehen die Textfeldbezeichnungen die dann geladen werden.
         */
        public Rezept_suchen()
        {
            InitializeComponent();
            TB_Zutaten.Text = Ref.defaultValues["TB_Zutaten"];

        }


        /**
         * Diese Funktion dient zum leeren des Textfeldes wenn der Startwert
         * gesetzt ist, ist ein anderer Inhalt in dem Textfeld wird nichts unternommen.
         */
        private void TB_GotFocus(object sender, RoutedEventArgs e)
        {
            if ((sender as TextBox).Text == Ref.defaultValues[(sender as TextBox).Name])
            {
                (sender as TextBox).Text = String.Empty;
            }
            else
            {

            }
            
        }

        /**
         * Mit dieser Funktion wird überprüft ob in dem Textfeld etwas drinne steht, wenn nichs
         * drinne steht wird der Startwert gesetzt, damit wird der Defaultwert Simuliert.
         * Ist ein Wert vorhanden bleibt dieser in dem Textfeld erhalten.
         */
        private void TB_LostFocus(object sender, RoutedEventArgs e)
        {
            if((sender as TextBox).Text == String.Empty){
                (sender as TextBox).Text = Ref.defaultValues[(sender as TextBox).Name];
            }
            else
            {

            }
        }
    }
}
