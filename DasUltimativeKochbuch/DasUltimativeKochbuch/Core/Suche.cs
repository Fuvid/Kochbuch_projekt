using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DasUltimativeKochbuch.Datenbank;
using DasUltimativeKochbuch.Core;

namespace DasUltimativeKochbuch.Core
{


    class Suche
    {
        private const int _RESULTS = 100;
        SortedSet<Zutat> zl;

        public Suche() { 
            zl = Ref.dbc.alleZutaten();
        }
        List<Rezept> find(List<Zutat> z) {
            Ref.dbc.rezepteMit(z[0]);



            List<Rezept> res = new List<Rezept>();
            
            
          /**  while (res.Count < _RESULTS) { 
                foreach (Rezept r in rezmit) {
                    
                    if (r.zutaten.Equals(z)) {
                        res.Add(r);
                        rezmit.Remove(r);
                    }
    
                }
            }
            */
            return res;
        }

        public void update() {
            zl = Ref.dbc.alleZutaten();
        }
    }
}
