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
        List<Rezept> rezeptliste = new List<Rezept>();
        ///<summary>
        /// Hier werden die Startwerte für die Page <c>Rezept_suchen</c> gesetzt
        /// in der <c>Coreinit.cs</c> stehen die Textfeldbezeichnungen die dann geladen werden.
        ///</summary>
        public Rezept_suchen()
        {
            InitializeComponent();
            TB_Zutaten.Text = Ref.defaultValues["TB_Zutaten"]; // Setzten des Textes der Textbox TB_Zutaten
            CB_Suchkrit.Items.Add("Wenig neu kaufen"); // Hinzufügen der Auswahlmöglichkeit der Combobox
            CB_Suchkrit.Items.Add("Häufig benutze Zutaten"); // Hinzufügen der Auswahlmöglichkeit der Combobox
            CB_Suchkrit.SelectedIndex = 0; // Standertwert für die Combobox Setzen
        }


        ///<summary>
        /// Diese Funktion dient zum leeren des Textfeldes wenn der Startwert
        /// gesetzt ist, ist ein anderer Inhalt in dem Textfeld wird nichts unternommen.
        ///</summary>
        private void TB_GotFocus(object sender, RoutedEventArgs e)
        {
            // Wenn die Textbox den Startwert enthält diese leeren, ansonsten nichts unternehmen.
            if ((sender as TextBox).Text == Ref.defaultValues[(sender as TextBox).Name])
            {
                (sender as TextBox).Text = String.Empty; // Leeren der Textbox
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
            // Wenn in die Textbox nichts hinein geschrieben wurde wieder Default-Wert setzten.
            if ((sender as TextBox).Text == String.Empty) // Prüfen auf leer
            {
                (sender as TextBox).Text = Ref.defaultValues[(sender as TextBox).Name]; // Default-Wert setzen.
            }
            else
            {

            }
        }


        /// <summary>
        /// In dieser Funktion soll eine Liste von Zutaten an die Suche übergeben werden.
        /// Die zurückkommende Liste wird dann abgeabeitet, d.h. das jeder Rezeptname
        /// in das Feld LB_Rezepte geschrieben wird.
        /// </summary>
        private void BSuchen_Click(object sender, RoutedEventArgs e)
        {
            LB_Personenanzahl.Content = "Anzahl";
            LB_Rezeptname.Content = "Rezeptname";
            LV_Zutaten.Items.Clear();
            LB_Rezepte.Items.Clear(); // Leeren der Rezeptliste
            TB_Zubereitung.Text = "";
            if (TB_Zutaten.Text == Ref.defaultValues["TB_Zutaten"]) // Prüfen ob eine Zutat eingegeben wurde.
            {
                System.Windows.Forms.MessageBox.Show("Sie haben keine Zutaten angegeben.");
            }
            else
            {
                if (CB_Suchkrit.SelectedIndex == -1) // Prüfen ob eine Auswahl der Combobox getroffen wurde.
                {
                    System.Windows.Forms.MessageBox.Show("Sie haben noch nicht ausgewählt wie Sie die Rezepte aufgelistet haben möchten.\n\nSie haben die Möglichkeit sie so auflisten zu lassen das sie entweder wenige Zutaten neu kaufen müssen, oder das Sie nur häufig gebrauchte Zutaten dazukaufen müssen.");
                }
                else
                {
                    //var blubber = Ref.rl;
                    //LB_Rezepte.Items.Clear(); // Leeren der Rezeptliste

                    string zutaten = TB_Zutaten.Text; // Zutaten aus der Textbox auslesen.
                    string[] zutat = zutaten.Split(','); // Zutaten in ein Array schreiben.

                    List<Zutat> zutatens = new List<Zutat>();
                    foreach (string brot in zutat) // Das Array mit den Zutaten durchgehen und in eine Liste schreiben.
                    {
                        //System.Windows.Forms.MessageBox.Show("Dorians Messagebox: " + brot);
                        zutatens.Add(new Zutat(brot, null));
                    }

                    Suche s = new Suche();
                    byte cb_id = (byte)CB_Suchkrit.SelectedIndex;
                    List<Rezept> blah = s.find(zutatens, cb_id); // Die Rezeptsuche starten und die Liste speichern.

                    foreach (Rezept item in blah) // Die Rezeptliste abarbeiten und in die Listbox hinzufügen.
                    {
                        ListBoxItem blubb = new ListBoxItem();
                        blubb.Content = item.name;
                        blubb.GotFocus += Show_Rezept;
                        LB_Rezepte.Items.Add(blubb);
                    }
                    this.rezeptliste = blah;
                }

            }
        }



        ///<summary>
        /// Mit dieser Funktion wird aus der Liste der Rezepte das ausgewählte gesucht und 
        /// in den anderen Fenstern erscheint dann die Zubereitung und die Zutaten.
        /// 
        /// WICHTIG!!
        /// Die Zutaten werden noch nicht ausgegeben, weil mir noch das Design für das Anzeigen nicht klar ist!!
        /// Sobald das klar ist wird das auslesen des Rezeptes richtig dargestellt!
        ///</summary>

        private void Show_Rezept(object sender, RoutedEventArgs e)
        {
            LV_Zutaten.Items.Clear();
            Rezept result = this.rezeptliste.Find( // Die Liste nach dem Rezept durchsuchen.
                delegate(Rezept bk)
                {
                    return bk.name == (sender as ListBoxItem).Content; // Rezeptnamen mit Rezeptnamen in der Liste vergleichen
                }
            );
            if (result != null)
            {
                // Die Ensprechenden inhalte auf die entsprechenden Felder verteilen so das man das Rezept schön lesen kann.
                //TB_Rezeptanzeigen.Text = "Rezeptname: " + result.name + "\n\nPersonenanzahl: " + result.pers + "\n\nRezeptbeschreibung:\n" + result.zubereitung;
                LB_Rezeptname.Content = result.name;
                LB_Personenanzahl.Content = result.pers;
                TB_Zubereitung.Text = result.zubereitung;

                foreach (Zutat kartoffel in result.zutaten)
                {
                    LV_Zutaten.Items.Add(kartoffel);
                    //System.Windows.Forms.MessageBox.Show(kartoffel.name);
                }
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("\nNot found: {0}");
            }

        }
    }
}
