using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DasUltimativeKochbuch.Core;


namespace DasUltimativeKochbuch.Datenbank
{
    class Mockup:DatenbankConnector
    {

        List<Rezept> rl = new List<Rezept>();
        List<Einheit> el = new List<Einheit>();
        List<Zutat> zl = new List<Zutat>();

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

            rl.Add(new Rezept());
        }


        public void rezSpeichern(Core.Rezept r)
        {
            throw new NotImplementedException();
        }

        public List<Core.Rezept> alleRezepte()
        {
            throw new NotImplementedException();
        }

        public List<Core.Rezept> rezepteMit(List<Core.Zutat> lz)
        {
            throw new NotImplementedException();
        }

        public List<Core.Zutat> alleZutaten()
        {
            throw new NotImplementedException();
        }

        public void einheitSpeichern(Core.Einheit e)
        {
            throw new NotImplementedException();
        }

        public List<Core.Einheit> alleEinheiten()
        {
            throw new NotImplementedException();
        }
    }
}
