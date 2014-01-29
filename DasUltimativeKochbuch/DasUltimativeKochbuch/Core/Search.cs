using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DasUltimativeKochbuch.Datenbank;

namespace DasUltimativeKochbuch.Core
{
    class Search
    {

        private const int _RESULTS = 100;

        Search()
        {

        }
 
        SortedSet<Rezept> findeMit(List<Zutat> zl) {
            SortedSet<Rezept> result = new SortedSet<Rezept>();
            zl.Sort();
            Ref.dbc.rezepteMit(zl.ElementAt(0));
            zl.Remove(zl.ElementAt(0));
            return result;
        }

    }
}