using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DasUltimativeKochbuch.Core
{   
    //Klassen zum vergleich bei der Scuhe für das passendste Rezept
    class ZutatEqualityComparerForSearch : IEqualityComparer<Zutat>
    {
      
        public bool Equals(Zutat x, Zutat y)
        {
            if (x.name == y.name)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public int GetHashCode(Zutat obj)
        {
            return obj.name.GetHashCode();
        }
    }
}
