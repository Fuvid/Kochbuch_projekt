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
    /// <summary>
    /// 
    /// </summary>
    public class Rezept
    {
        /// <summary>
        /// Liste der benötigten Zutaten
        /// </summary>

        public List<Zutat> zutaten { get; set; }

        /// <summary>
        /// Fließtext zur Zubereitung
        /// </summary>

        public string zubereitung;

        //Der name des Rezept z.B. "Omas Hausgemachte Käsespätzle"
        public string name;

        //Für wie viele Personen ist das Rezept gedacht, um Skalieren zu können
        public int pers;
        /// <summary>
        /// Konstruktor
        /// </summary>
        /// <param name="zt">Die Liste der Zutaten</param>
        /// <param name="zub">Zubereitung</param>
        /// <param name="n">Name</param>
        /// <param name="p">Personenanzahl</param>
        public Rezept(List<Zutat> zt, String zub, String n, int p)
        {
            zutaten = zt;
            zubereitung = zub;
            name = n;
            pers = p;
        }
        /// <summary>
        /// toString Methode, zum ausgeben eines Rezeptes als string
        /// </summary>
        /// <returns>einen string, der das Rezept repräsentiert</returns>
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
