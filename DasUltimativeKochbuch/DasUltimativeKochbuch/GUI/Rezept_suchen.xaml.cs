﻿using System;
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
            CB_Suchkrit.Items.Add("Wenig neu kaufen");
            CB_Suchkrit.Items.Add("Häufig benutze Zutaten");
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
            if ((sender as TextBox).Text == String.Empty)
            {
                (sender as TextBox).Text = Ref.defaultValues[(sender as TextBox).Name];
            }
            else
            {

            }
        }


        /**
         * In dieser Funktion soll eine Liste von Zutaten an die Suche übergeben werden.
         * Die zurückkommende Liste wird dann abgeabeitet, d.h. das jeder Rezeptname
         * in das Feld LB_Rezepte geschrieben wird.
         * 
         * Die Liste muss bis zu einer neuen suche oder bis zur Beendigung des Programmes
         * temporär gespeichert werden!
         * 
         * Momentan wird nur das dummy Rezept geladen und ausgegeben.
         * Hier muss ein Funktions aufruf der Rezeptsuche stattfinden und diese müssen
         * als Liste zurück kommen!
         */
        private void BSuchen_Click(object sender, RoutedEventArgs e)
        {
            if (TB_Zutaten.Text == Ref.defaultValues["TB_Zutaten"])
            {
                System.Windows.Forms.MessageBox.Show("Sie haben keine Zutaten angegeben.");
            }
            else
            {
                var blubber = Ref.rl;
                int blah = CB_Suchkrit.SelectedIndex;
                System.Windows.Forms.MessageBox.Show("" + blah);
                System.Windows.Forms.MessageBox.Show("Nette Zutaten");
                LB_Rezepte.Items.Clear();

                foreach (var item in blubber)
                {
                    ListBoxItem blubb = new ListBoxItem();
                    blubb.Content = item.name;
                    blubb.GotFocus += Show_Rezept;
                    LB_Rezepte.Items.Add(blubb);
                }
            }
        }



        /*
         * Mit dieser Funktion wird aus der Liste der Rezepte das ausgewählte gesucht und 
         * in den anderen Fenstern erscheint dann die Zubereitung und die Zutaten.
         * 
         * WICHTIG!!
         * Die Zutaten werden noch nicht ausgegeben, weil mir noch das Design für das Anzeigen nicht klar ist!!
         * Sobald das klar ist wird das auslesen des Rezeptes richtig dargestellt!
         */

        private void Show_Rezept(object sender, RoutedEventArgs e)
        {
            System.Windows.Forms.MessageBox.Show("Auswahl: " + (sender as ListBoxItem).Content);
            //var temp = (sender as ListBoxItem).Content;
            //string ficken = (string)temp;

            Rezept result = Ref.rl.Find(

                delegate(Rezept bk)
                {
                    return bk.name == "dolles rezept";
                }
            );
            if (result != null)
            {
                TB_Rezeptanzeigen.Text = "Rezeptname: " + result.name + "\n\nPersonenanzahl: " + result.pers + "\n\nRezeptbeschreibung:\n" + result.zubereitung;
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("\nNot found: {0}");
            }
           
        }

        private void CB_Suchkrit_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
