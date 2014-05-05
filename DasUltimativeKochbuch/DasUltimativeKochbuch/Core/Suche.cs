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
       /// Die Klasse, die Rezepte anhand der Wertigkeiten ihrer Zutaten sortiert<br />
       /// Rezepte sind mehr wert, wenn man weniger zusätzliche Zutaten benötigt werden
       /// </summary>
        private class SBLess : IComparer<Rezept>
        {
           
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
                //Die Zutaten aus dem 1. Rezept
                List<Zutat> x_zut = x.zutaten;
                //Die Zutaten aus dem 2. Rzepte 
                List<Zutat> y_zut  = y.zutaten;
                //die "Punkte des ersten Rezeptes"
                int score_x = 0;
                //die Punkte des 2. Rezeptes
                int score_y = 0;
                //Hier werden dei bereits Vorhandenen Zutaten abgezogen
                foreach (Zutat z in toIgnore)
                {
                    if(x_zut.Contains(z))
                        score_x--;
                    if (y_zut.Contains(z))
                        score_y--;
                }
                //und hier wird die Anzahl der Zutaten wieder draufaddiert
                score_x += x_zut.Count;
                score_y += y_zut.Count;
                
                return score_y - score_x;
            }
        }
        /// <summary>
        /// Die Klasse, die Rezepte anhand der Wertigkeiten ihrer Zutaten sortiert<br />
        /// Rezepte sind mehr wert, wenn man Häufigere Zutaten verwendet
        /// </summary>
        private class SBPop : IComparer<Rezept>
        {
            /// <summary>
            /// Die Liste der Zutaten, die Bei der Punkteberechnung ignoriert werden soll
            /// </summary>
            public List<Zutat> toIgnore;
            /// <summary>
            /// Standartkonstruktor
            /// </summary>
            /// <param name="tig">Die zu ignorierenden Zutaten</param>
            public SBPop(List<Zutat> tig)
            {
                this.toIgnore = tig;
            }
            /// <summary>
            /// Vergleicht anhand der Punktzahl zwei Rezepte
            /// </summary>
            /// <param name="x"></param>
            /// <param name="y"></param>
            /// <returns></returns>
            public int Compare(Rezept x, Rezept y)
            {
                List<Zutat> x_zut = x.zutaten;
                List<Zutat> y_zut = y.zutaten;
                int score_x = 0;
                int score_y = 0;
               
                foreach (Zutat s in x_zut)
                {
                    if (!toIgnore.Contains(s))
                        score_x += s.score;
                }

                foreach (Zutat s in y_zut)
                {
                    if (!toIgnore.Contains(s))
                        score_y += s.score;
                }

                return score_x - score_y;
            }
        }
        /// <summary>
        /// Statische Variablen, um das Sortierverhalten steuern zu können
        /// </summary>
        public const int SORT_BY_BUY_LESS = 0;
        public const int SORT_BY_BUY_POPULAR = 1;
        private const int _RESULTS = 100;
        /// <summary>
        /// Standartkonstruktor
        /// </summary>
        public Suche(){}
        /// <summary>
        /// Die Funktion zum Suchen nach Rezepten anhand einer Liste von Zutaten
        /// </summary>
        /// <param name="z">Liste der Zutaten, nach denen gesucht werden soll</param>
        /// <param name="sortby">Das Verfahren, nach dem Gesucht werden soll</param>
        /// <returns>Die gefundenen Rezepte</returns>
        public List<Rezept> find(List<Zutat> z, int sortby)
        {
            
            List<Rezept> res=new List<Rezept>();
            IComparer<Rezept> comp;
     
                switch (sortby)
                {
                    case SORT_BY_BUY_LESS: //SORT_BY_BUY_LESS
                        comp = new SBLess(z);
                        break;
                    case SORT_BY_BUY_POPULAR:
                        comp = new SBPop(z);
                        break;
                    default:
                        MessageBox.Show("Kein gültiges Sortierverfahren für " + sortby);
                        return res;
                        break;
                }
                res.AddRange( Ref.dbc.rezepteMit(z));
                
                res.Sort(comp);

            return res;

        }

     
    }
}
