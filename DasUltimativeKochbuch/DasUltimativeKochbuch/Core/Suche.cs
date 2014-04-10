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
        public static readonly byte SORT_BY_BUY_LESS = 0x0;
        public static readonly byte SORT_BY_BUY_POPULAR = 0x1;
        private const int _RESULTS = 100;
        SortedSet<Zutat> zl;

        public Suche() { 
            zl = Ref.dbc.alleZutaten();
        }
        List<Rezept> find(List<Zutat> z, int sortby) {
            return Ref.rl;
            
        }

        public void update() {
            zl = Ref.dbc.alleZutaten();
        }
    }
}
