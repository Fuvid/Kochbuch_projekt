using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DasUltimativeKochbuch.Datenbank;

namespace DasUltimativeKochbuch.Core
{
    static class Ref
    {
        public static DatenbankConnector dbc { set; get; }
        public static List<Einheit> einheiten { set; get; }
 
    }
}
