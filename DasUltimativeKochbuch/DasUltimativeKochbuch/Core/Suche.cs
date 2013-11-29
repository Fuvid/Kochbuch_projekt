using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DasUltimativeKochbuch.Datenbank;

namespace DasUltimativeKochbuch.Core
{


    class Suche
    {
        private const int _RESULTS = 100;
        DatenbankConnector dbc = new DBConnect();
        SortedSet<Zutat> zl;

        public Suche() {
            zl = dbc.alleZutaten();
        }
        List<Rezept> find(List<Zutat> z) {
            List<Rezept> rezmit = dbc.rezepteMit(z);
            List<Rezept> res = new List<Rezept>();
            
            
            while (res.Count < _RESULTS) { 
                foreach (Rezept r in rezmit) {
                    
                    if (r.zutaten.Equals(z)) {
                        res.Add(r);
                        rezmit.Remove(r);
                    }
    
                }
            }

            return res;
        }

        public void update() {
            zl = dbc.alleZutaten();
        }
    }
}
