using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/**
 * @Autor: David 
 */

namespace DasUltimativeKochbuch.Core
{
    public class Rezept
    {
        //Liste der benötigten Zutaten
        public List<Zutat> zutaten { get; set; }

        //Fließtext zur Zubereitung
        public string zubereitung;

        //Der name des Rezept z.B. "Omas Hausgemachte Käsespätzle"
        public string name;

        //Für wie viele Personen ist das Rezept gedacht, um später besser Skalieren zu können
        public int pers;

        public Rezept(List<Zutat> zt, String zub, String n, int p)
        {
            zutaten = zt;
            zubereitung = zub;
            name = n;
            pers = p;
        }

        string toString(){
            string res = "";
            res += this.name;
            res += '\n';
            res += '\n';
            foreach (Zutat item in zutaten)
            {
                res += item.name + '\n';
            }
            res += '\n';
            res += this.zubereitung;

            return res;

        }
    }
}
