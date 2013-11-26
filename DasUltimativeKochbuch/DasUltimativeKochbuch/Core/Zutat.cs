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
        int score;
        //Die Einheit in der die Zutat berechnet wird
        Einheit einh;

        public Zutat(string n, Einheit e) {
            n = name;
            einh = e;
            score = 0;
        }
    }
}
