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
            return Ref.rl;
            
        }

        public void update() {
            zl = Ref.dbc.alleZutaten();
        }
    }
}
