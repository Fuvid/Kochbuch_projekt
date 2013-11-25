using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DasUltimativeKochbuch.Core
{
    class Coreinit
    {
        void ini() {
            List<Rezept> rl = new List<Rezept>();
            List<Einheit> el = new List<Einheit>();
            List<Zutat> zl = new List<Zutat>();
            
            el.Add(new Einheit(""));

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



        }
    }
}
