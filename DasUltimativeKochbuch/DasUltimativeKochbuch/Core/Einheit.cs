using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DasUltimativeKochbuch.Core
{
    /// <summary>
    /// Repräsentiert eine Einheit, z. B.: kg, Tasse, ...
    /// </summary>
    public class Einheit
    {
        /// <summary>
        /// der Name der Einheit
        /// </summary>
        public string name{get;set;}
        public override string ToString()
        {
            return name;
        }
        public Einheit(string n) {
            this.name = n;
        }
    }
}
