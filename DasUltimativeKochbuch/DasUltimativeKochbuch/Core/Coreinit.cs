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
        void ini() {
            DatenbankConnector dbc = new DBConnect();
            List<Einheit> el = new List<Einheit>();
            el.Add(new Einheit(""));

            el.Add(new Einheit("Stk"));
            el.Add(new Einheit("tl"));


            el.Add(new Einheit("kg"));
            el.Add(new Einheit("g"));

            el.Add(new Einheit("l"));
            el.Add(new Einheit("ml"));
            el.Add(new Einheit("cl"));
            foreach (Einheit e in el) {
                dbc.einheitSpeichern(e);
            }
            
        }
    }
}
