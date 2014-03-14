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
        DatenbankConnector dbc = new DBConnect();
        
        public Rezept_erstellen()
        {
            InitializeComponent();
            zl = new List<Zutat>();
            foreach(Einheit e in Ref.ehl){
                Einheit.Items.Add(e);
            }
            TB_Menge.Text = Ref.defaultValues["TB_Menge"];
            TB_Zutat.Text = Ref.defaultValues["TB_Zutat"];
            TB_Rezeptname.Text = Ref.defaultValues["TB_Rezeptname"];
            TB_Zubereitung.Text = Ref.defaultValues["TB_Zubereitung"];
        }
       
        private void AddZutat_Click(object sender, RoutedEventArgs e)
        {
            // Hinzufügen einer neuen Zeile in das ListView Fenster.
            if (Einheit.SelectedItem == null) {
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
            catch(FormatException) {
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
            Rezept r = new Rezept(zl, TB_Zubereitung.Text, TB_Rezeptname.Text, 4);//-TODO Personenangabe
            dbc.rezSpeichern(r);

        }
    }
}
