using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DasUltimativeKochbuch.Datenbank;

namespace DasUltimativeKochbuch.Core
{
    class Coreinit
    {
        private static bool intialisiert = false;
        public static void ini() {
            Ref.dbc = new DBConnect();
            //el.Add(new Einheit(""));
            Ref.einheiten = new List<Einheit>();
            Ref.einheiten.Add(new Einheit("Stk"));//, "Stück"));
            Ref.einheiten.Add(new Einheit("tl"));//, "Teelöffel"));


            Ref.einheiten.Add(new Einheit("kg"));//, "Kilogramm"));
            Ref.einheiten.Add(new Einheit("g"));//, "Gramm"));

            Ref.einheiten.Add(new Einheit("l"));//, "Liter"));
            Ref.einheiten.Add(new Einheit("ml"));//, "Milliliter"));
            Ref.einheiten.Add(new Einheit("cl"));//, "Zentiliter"));

            /*
            foreach (Einheit e in Ref.einheiten)
            {
                dbc.einheitSpeichern(e);
            }
  */          
            List<Zutat> zl1 = new List<Zutat>();

//            zl1.Add(new Zutat("Kartoffel", el.));
            
        }
    }
}
