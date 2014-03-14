using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DasUltimativeKochbuch.Datenbank;

namespace DasUltimativeKochbuch.Core
{
    static class Coreinit
    {
        private static bool intialisiert = false;
        public static void ini() {
            Ref.dbc = new DBConnect();
            Ref.defaultValues = new Dictionary<string, string>();
            Ref.defaultValues.Add("TB_Zutaten", "Hier Zutaten bitte Kommagetrennt eingeben");
            Ref.defaultValues.Add("TB_Rezeptname", "Rezeptname");
            Ref.defaultValues.Add("TB_Zubereitung", "Zubereitung");
            Ref.defaultValues.Add("TB_Zutat", "Zutat");
            Ref.defaultValues.Add("TB_Menge", "Menge");
            
            List<Einheit> el = new List<Einheit>();
            el.Add(new Einheit(""));

            el.Add(new Einheit("Stk"));
            el.Add(new Einheit("tl"));


            el.Add(new Einheit("kg"));
            el.Add(new Einheit("g"));

            el.Add(new Einheit("l"));
            el.Add(new Einheit("ml"));
            el.Add(new Einheit("cl"));
            
            //foreach (Einheit e in el) {
            //    dbc.einheitSpeichern(e);
            //}
            Ref.ehl = el;
          
            List<Zutat> zl1 = new List<Zutat>();

//            zl1.Add(new Zutat("Kartoffel", el.));
            
        }
    }
}
