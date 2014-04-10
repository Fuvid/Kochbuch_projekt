using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using  System.Collections.ObjectModel;
using DasUltimativeKochbuch.Datenbank;

namespace DasUltimativeKochbuch.Core
{
    public static class Ref
    {
        public static Dictionary<string, string> defaultValues;
        static List<Einheit> _ehl;
        public static List<Rezept> rl;

        public static List<Einheit> ehl
        { 
            get { return _ehl;}
            set { _ehl = value; }
        }
        static DatenbankConnector _dbc;
        public static  DatenbankConnector dbc
        {
            get { return _dbc; }
            set { _dbc = value; }
        }
    }
}
