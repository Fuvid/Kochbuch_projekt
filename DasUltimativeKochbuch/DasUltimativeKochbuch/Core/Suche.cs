using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DasUltimativeKochbuch.Datenbank;
using DasUltimativeKochbuch.Core;
using System.Windows.Forms;

namespace DasUltimativeKochbuch.Core
{

    /// <summary>
    /// Klasse zum Suchen von Rezepten in der Vorgegenen datenbank
    /// </summary>
    class Suche
    {
        /// <summary>
        /// Ermöglicht es, Zutaten als gleich zu behandeln, falls der name gleich ist
        /// </summary>
        private class ZutComparer :IEqualityComparer<Zutat>{

            public bool Equals(Zutat x, Zutat y)
            {
                return x.name.Equals(y.name);
            }

            public int GetHashCode(Zutat obj)
            {
                return obj.name.GetHashCode();
            }
        }
       /// <summary>
       /// Die Klasse, die Rezepte anhand deren Zutaten<br />
       /// Rezepte sind mehr wert, wenn man weniger zusätzliche Zutaten benötigt werden
       /// </summary>
        private class SBLess : IComparer<Rezept>
        {
            IEqualityComparer<Zutat> iec = new ZutComparer();
            /// <summary>
            /// Die Liste, nach der gesucht wurde, diese soll nicht in die Wertung mit eingehen
            /// </summary>
            public List<Zutat> toIgnore;
            /// <summary>
            /// Konstruktor
            /// </summary>
            /// <param name="tig">Die zu ignorierenden Zutaten</param>
            
            public SBLess(List<Zutat> tig)
            {
                this.toIgnore = tig;
            }
            /// <summary>
            /// vergleicht zwei Rezepte
            /// </summary>
            /// <param name="x"></param>
            /// <param name="y"></param>
            /// <returns></returns>
            public int Compare(Rezept x, Rezept y)
            {
                List<Zutat> x_zut = x.zutaten;
                List<Zutat> y_zut  = y.zutaten;
                int score_x = 0;
                int score_y = 0;
                
                foreach (Zutat z in toIgnore)
                {
                    if(x_zut.Contains(z, iec))
                    score_x--;
                }
                foreach (Zutat z in toIgnore)
                {
                    if (y_zut.Contains(z, iec))
                    score_y--;
                }
                score_x = x_zut.Count;
                score_y = y_zut.Count;
                return score_x - score_y;
            }
        }
        private class SBPop : IComparer<Rezept>
        {
            IEqualityComparer<Zutat> iec = new ZutComparer();
            public List<Zutat> toIgnore;
            public SBPop(List<Zutat> tig)
            {
                this.toIgnore = tig;
            }
            public int Compare(Rezept x, Rezept y)
            {
                List<Zutat> clean_x = x.zutaten;
                List<Zutat> clean_y = y.zutaten;
                int score_x = 0;
                int score_y = 0;
               
                foreach (Zutat s in clean_x)
                {
                    if (!clean_x.Contains(s, iec))
                    score_x += s.score;
                }
                foreach (Zutat s in clean_y)
                {
                    if(!clean_y.Contains(s,iec))
                    score_y += s.score;
                }
                return score_x - score_y;
            }
        }
        public static readonly int SORT_BY_BUY_LESS = 0;
        public static readonly int SORT_BY_BUY_POPULAR = 1;
        private const int _RESULTS = 100;

        public Suche()
        {
            
        }
        public List<Rezept> find(List<Zutat> z, int sortby)
        {
            
            List<Rezept> res=new List<Rezept>();
            IComparer<Rezept> comp;
            try
            {    
                switch (sortby)
                {
                    case 0: //SORT_BY_BUY_LESS
                        comp = new SBLess(z);
                        break;
                    case 1:
                        comp = new SBPop(z);
                        break;
                    default:
                        throw new KeyNotFoundException();
                }
                res.AddRange( Ref.dbc.rezepteMit(z));
                
                res.Sort(comp);
            }catch(Exception ex){
                MessageBox.Show(ex.Message);
            }
            return res;

        }

     
    }
}
