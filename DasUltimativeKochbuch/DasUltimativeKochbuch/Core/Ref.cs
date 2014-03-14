using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DasUltimativeKochbuch.Datenbank;

namespace DasUltimativeKochbuch.Core
{
    public static class Ref
    {
        static List<Einheit> _ehl;
        public static List<Einheit> ehl { 
            get { return _ehl;}
            set { _ehl = value; }
        }
        static DatenbankConnector _dbc;
        public static DatenbankConnector dbc
        {
            get { return _dbc; }
            set { _dbc = value; }
        }
    }
}
