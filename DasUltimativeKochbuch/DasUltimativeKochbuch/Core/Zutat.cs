using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DasUltimativeKochbuch.Core
{
    public class Zutat:Comparer<Zutat>, IEqualityComparer<Zutat>
    {
        //Name der Zutat
        public string name { get; set; }
        //interne Bewertung der Zutat
        public int score;
        //Die Einheit in der die Zutat berechnet wird
        public Einheit einh { get; internal set; }


        public double menge { get; set; }


        public Zutat(string n, Einheit e) {
            n = name;
            einh = e;
            score = 0;
            menge = 0;
        }
        public Zutat(string n, Einheit e, double m)
        {
            name = n;
            einh = e;
            score = 0;
            menge = m;
        }

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
            else
            {
                return obj.GetHashCode();
            }
        }

        public override int Compare(Zutat x, Zutat y)
        {
            //wenn die Punkte größer sind
            if (x.score > y.score)
            {

                return 1;
            }
            else if (x.score == y.score)
            {
                return 0;
            }
            return -1;
        }



        public bool Equals(Zutat x, Zutat y)
        {
            throw new NotImplementedException();
        }

        public int GetHashCode(Zutat obj)
        {
            throw new NotImplementedException();
        }
    }
}
