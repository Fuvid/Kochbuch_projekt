using System;
using System.Collections.Generic;
using DasUltimativeKochbuch.Core;


namespace DasUltimativeKochbuch.Datenbank
{
    class Mockup//:DatenbankConnector
    {
        /*
        HashSet<Rezept> rl = new HashSet<Rezept>();
        HashSet<Einheit> el = new HashSet<Einheit>();
        HashSet<Zutat> zl = new HashSet<Zutat>();

        public Mockup() {

            el.Add(new Einheit(""));

            el.Add(new Einheit("Stk"));
            el.Add(new Einheit("tl"));
            el.Add(new Einheit("el"));
            el.Add(new Einheit("msp"));
            el.Add(new Einheit("pkg"));
            el.Add(new Einheit("Prise"));


            el.Add(new Einheit("kg"));
            el.Add(new Einheit("g"));

            el.Add(new Einheit("l"));
            el.Add(new Einheit("ml"));
            el.Add(new Einheit("cl"));

            zl.Add(new Zutat("Kartoffeln", el.Find(x => x.name == "kg")));
            zl.Add(new Zutat("Zwiebeln", el.Find(x => x.name == "Stk")));
            zl.Add(new Zutat("Milch", el.Find(x => x.name == "l")));
            zl.Add(new Zutat("Mehl", el.Find(x => x.name == "g")));
            zl.Add(new Zutat("Schweinelende", el.Find(x => x.name == "kg")));
            zl.Add(new Zutat("Nudeln", el.Find(x => x.name == "g")));

          
        }


        public void rezSpeichern(Rezept r)
        {
            rl.Add(r);
        }

        public HashSet<Rezept> alleRezepte()
        {
            return rl;
        }

        public HashSet<Rezept> rezepteMit(HashSet<Zutat> lz)
        {
            HashSet<Rezept> res = new HashSet<Rezept>();
            foreach (Rezept rezept in rl)
            {
                foreach (var zut in lz)
                {
                    if (rezept.zutaten.Find(x => x.name == zut.name)!=null) {
                        continue;
                    }
                    break;
                }
            }
            return res;
        }

        public HashSet<Zutat> alleZutaten()
        {
            throw new NotImplementedException();
        }

        public void einheitSpeichern(Einheit e)
        {
            throw new NotImplementedException();
        }

        public HashSet<Einheit> alleEinheiten()
        {
            throw new NotImplementedException();
        }*/
    }
}
