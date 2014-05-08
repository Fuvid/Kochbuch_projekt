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
using DasUltimativeKochbuch.Datenbank;

namespace DasUltimativeKochbuch.GUI
{
    /// <summary>
    /// Interaktionslogik für Rezept_erstellen.xaml
    /// </summary>
    public partial class Rezept_erstellen : Page
    {
        List<Zutat> zl;


        /// <summary>
        /// Hier werden Startwerte für die Page Rezept_erstellen gesetzt und festgelegt.
        /// In der Coreinit.cs stehen die Feldnamen die dann gesetzt werden, auch die
        /// Einheiten sind dort festgelegt und werden hier initialisiert.
        /// </summary>
        public Rezept_erstellen()
        {

            InitializeComponent();
            zl = new List<Zutat>();
            foreach (Einheit e in Ref.ehl)
            {
                Einheit.Items.Add(e);
            }
            TB_Menge.Text = Ref.defaultValues["TB_Menge"];
            TB_Zutat.Text = Ref.defaultValues["TB_Zutat"];
            TB_Rezeptname.Text = Ref.defaultValues["TB_Rezeptname"];
            TB_Zubereitung.Text = Ref.defaultValues["TB_Zubereitung"];
        }


        /// <summary>
        /// Diese Funktion dient zum leeren des Textfeldes wenn der Startwert
        /// gesetzt ist, ist ein anderer Inhalt in dem Textfeld wird nichts unternommen.
        /// </summary>
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

        /// <summary>
        /// Mit dieser Funktion wird überprüft ob in dem Textfeld etwas drinne steht, wenn nichs
        /// drinne steht wird der Startwert gesetzt, damit wird der Defaultwert Simuliert.
        /// Ist ein Wert vorhanden bleibt dieser in dem Textfeld erhalten.
        /// </summary>
        private void TB_LostFocus(object sender, RoutedEventArgs e)
        {
            if ((sender as TextBox).Text == String.Empty)
            {
                (sender as TextBox).Text = Ref.defaultValues[(sender as TextBox).Name];
            }
            else
            {

            }
        }


        private void AddZutat_Click(object sender, RoutedEventArgs e)
        {
            // Hinzufügen einer neuen Zeile in das ListView Fenster.
            if (Einheit.SelectedItem == null)
            {
                MessageBox.Show("Keine Einheit angegeben");
                return;
            }
            if (!(Einheit.SelectedItem is Einheit))
            {
                MessageBox.Show("Keine Einheit");
                return;
            }
                
            double mng;
            try
            {
                mng = Convert.ToDouble(TB_Menge.Text);

            }
            catch (FormatException)
            {
                MessageBox.Show("Bitte eine Zahl als Menge angeben");
                return;
            }

            Zutat zt = new Zutat(TB_Zutat.Text, (Einheit)Einheit.SelectionBoxItem, Convert.ToDouble(TB_Menge.Text));
            zl.Add(zt);
            LV_Zutaten.Items.Add(zt);
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
            int persAnz = 0;
            try
            {
                persAnz = Convert.ToInt32(TB_Personenanzahl.Text);
            }
            catch (Exception) {

                MessageBox.Show("Die Anzahl der Personen muss eine Zahl sein");
                return;
            }
            Rezept r = new Rezept(zl, TB_Zubereitung.Text, TB_Rezeptname.Text, persAnz);//-TODO Personenangabe
            Ref.dbc.rezSpeichern(r);

        }

      
        private void Delete_Zutat_Click(object sender, RoutedEventArgs e)
        {
            Zutat z = ((FrameworkElement)sender).DataContext as Zutat;
            LV_Zutaten.Items.Remove(z);
            zl.Remove(z);
        }
    }
}
