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

namespace DasUltimativeKochbuch.GUI
{
    /// <summary>
    /// Interaktionslogik für Rezept_suchen.xaml
    /// </summary>
    public partial class Rezept_suchen : Page
    {
        public Rezept_suchen()
        {
            InitializeComponent();
        }

        private void TB_Zutaten_GotFocus(object sender, RoutedEventArgs e)
        {
            if ((sender as TextBox).Text == "Hier Zutaten bitte Kommagetrennt eingeben")
            {
                (sender as TextBox).Text = String.Empty;
            }
            else
            {

            }
            
        }

        private void TB_Zutaten_LostFocus(object sender, RoutedEventArgs e)
        {
            if((sender as TextBox).Text == String.Empty){
                (sender as TextBox).Text = "Hier Zutaten bitte Kommagetrennt eingeben";
            }
            else
            {

            }
        }
    }
}