using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DasUltimativeKochbuch.Core
{
    public class Zutat
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
    }
}
