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
       
        private class SBLess : IComparer<Rezept>
        {
            public List<Zutat> toIgnore;
            public SBLess(List<Zutat> tig)
            {
                this.toIgnore = tig;
            }

            public int Compare(Rezept x, Rezept y)
            {
                List<Zutat> clean_x = x.zutaten;
                List<Zutat> clean_y = y.zutaten;
                int score_x = 0;
                int score_y = 0;

                foreach (Zutat z in toIgnore)
                {
                    if(clean_x.Contains(z))
                    clean_x.Remove(z);
                }
                foreach (Zutat z in toIgnore)
                {
                    if (clean_y.Contains(z))
                    clean_y.Remove(z);
                }
                score_x = clean_x.Count;
                score_y = clean_y.Count;
                return score_x - score_y;
            }
        }
        private class SBPop : IComparer<Rezept>
        {
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

                foreach (Zutat z in toIgnore)
                {
                    clean_x.Remove(z);
                }
                foreach (Zutat z in toIgnore)
                {
                    clean_y.Remove(z);
                }
                foreach (Zutat s in clean_x)
                {
                    score_x += s.score;
                }
                foreach (Zutat s in clean_y)
                {
                    score_y += s.score;
                }
                return score_x - score_y;
            }
        }
        public static readonly byte SORT_BY_BUY_LESS = 0;
        public static readonly byte SORT_BY_BUY_POPULAR = 1;
        private const int _RESULTS = 100;
        SortedSet<Zutat> zl;

        public Suche()
        {
            zl = Ref.dbc.alleZutaten();
        }
        List<Rezept> find(List<Zutat> z, byte sortby)
        {
            List<Rezept> res;
            IComparer<Rezept> comp;

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
            res = Ref.dbc.rezepteMit(z);

            res.Sort(comp);

            return res;

        }

        public void update()
        {
            zl = Ref.dbc.alleZutaten();
        }
    }
}
