using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using DasUltimativeKochbuch.Datenbank;

namespace DasUltimativeKochbuch.Core
{
    static class Coreinit
    {
       /// <summary>
       /// <para> 
       /// Wird am anfang des Programmes aufgerufen und soll die wichtigsten Umgebungsvariablen setzen,
       /// die für den Programmablauf benötigt werden. 
       /// </para>
       /// </summary>
        public static void ini() {

            Ref.dbc = new DBConnect();
            
            Ref.defaultValues = new Dictionary<string, string>();
            
            Ref.defaultValues.Add("TB_Zutaten", "Hier Zutaten bitte Kommagetrennt eingeben");
            Ref.defaultValues.Add("TB_Rezeptname", "Rezeptname");
            Ref.defaultValues.Add("TB_Zubereitung", "Zubereitung");
            Ref.defaultValues.Add("TB_Zutat", "Zutat");
            Ref.defaultValues.Add("TB_Menge", "Menge");
            Ref.defaultValues.Add("TB_Personenanzahl", "4");
            //Ref.defaultValues.Add();
            MessageBox.Show("Eiheiten:"+Ref.dbc.alleEinheiten().Count);
            if (Ref.dbc.alleEinheiten().Count==0) {
                List<Einheit> ehl = new List<Einheit>();
                ehl.Add(new Einheit("kg"));
                ehl.Add(new Einheit("g"));
                ehl.Add(new Einheit("l"));
                ehl.Add(new Einheit("Stk"));
                ehl.Add(new Einheit("tl"));
                ehl.Add(new Einheit("Msp"));
                ehl.Add(new Einheit("ml"));
                ehl.Add(new Einheit("cl"));
                foreach (Einheit e in ehl) {
                    Ref.dbc.einheitSpeichern(e);
                }
            }
            Ref.ehl = Ref.dbc.alleEinheiten();
            
        }
    }
}
