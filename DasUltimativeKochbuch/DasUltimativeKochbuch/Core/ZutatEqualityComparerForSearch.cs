using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DasUltimativeKochbuch.Core
{   
    //Klassen zum vergleich bei der Scuhe für das passendste Rezept
    class ZutatEqualityComparerForSearch : IEqualityComparer<object>
    {
        public new bool Equals(object x, object y)
        {
            if (x is Zutat && y is Zutat)
            {
                Zutat zx = (Zutat)x;
                Zutat zy = (Zutat)y;
                if (zx.name == zy.name)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return false;
        }

        public int GetHashCode(object obj)
        {
            if (obj is Zutat)
            {
                return ((Zutat)obj).name.GetHashCode();
            }
            else {
                return obj.GetHashCode();
            }
        }
    }
}
