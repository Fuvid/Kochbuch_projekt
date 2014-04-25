using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using  System.Collections.ObjectModel;
using DasUltimativeKochbuch.Datenbank;

namespace DasUltimativeKochbuch.Core
{
    /// <summary>
    /// <para>
    /// Hier werden die Referenzen auf Variablen und Klassen gespeichert, 
    /// damit von überall darauf zugegriffen werden kann
    /// </para>
    /// </summary>
    public static class Ref
    {
        /// <summary>
        /// Hier können Stringwerte gesetzt werden
        /// </summary>
        public static Dictionary<string, string> defaultValues = new Dictionary<string,string>();
        /// <summary>
        /// Die Liste aller Einheiten, wird in der Core.ini() mit den WErten der Datenbank gefüllt
        /// </summary>
        public static List<Einheit> ehl = new List<Einheit>();
        /// <summary>
        /// Der DatenbankConnector, der verwendet werden soll, wenn Rezepte gelesen werden sollen
        /// </summary>
        public static DatenbankConnector dbc;
    }
}
