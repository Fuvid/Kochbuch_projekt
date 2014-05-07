using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DasUltimativeKochbuch.Core
{
    public class Zutat:IEquatable<Zutat>
    {
        /// <summary>
        /// Name der Zutat
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// interne Bewertung der Zutat
        /// </summary>
        public int score;
        /// <summary>
        /// Einheit der Zutat
        /// </summary>
        public Einheit einh { get; internal set; }

        /// <summary>
        /// benötigte Menge der Zutat
        /// </summary>
        public double menge { get; set; }
        
        public string ToString() {
            return name;
        }
        /// <summary>
        /// Konstruktor
        /// </summary>
        /// <param name="n">Name der Zutat</param>
        /// <param name="e">Einzheit</param>
        public Zutat(string n, Einheit e) {

            name = n;
            einh = e;
            score = 0;
            menge = 0;
        }
        /// <summary>
        /// Konstruktor
        /// </summary>
        /// <param name="n">Name</param>
        /// <param name="e">Einheit</param>
        /// <param name="m">Menge</param>
        public Zutat(string n, Einheit e, double m)
        {
            name = n;
            einh = e;
            score = 0;
            menge = m;
        }
        /// <summary>
        /// Konstruktor
        /// </summary>
        /// <param name="n">Name</param>
        /// <param name="e">Einheit</param>
        /// <param name="m">Menge</param>
        /// <param name="s">Score(Wird von der Datenbank geschrieben)</param>
        public Zutat(string n, Einheit e, double m, int s)
        {
            name = n;
            einh = e;
            score = s;
            menge = m;
        }

        public bool Equals(Zutat other)
        {
            if (other == null) return false;
            if (this.name != other.name) return false;
            return true;
        }
    }
}
