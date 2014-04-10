using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DasUltimativeKochbuch.Datenbank;
using DasUltimativeKochbuch.Core;

namespace DasUltimativeKochbuch.XML
{
    public class XMLConnector:DatenbankConnector
    { 
        public void rezSpeichern(Rezept r)
        {
           // string dodo;
            throw new NotImplementedException();
        }

        public List<Rezept> alleRezepte()
        {
            throw new NotImplementedException();
        }

        public List<Rezept> rezepteMit(Zutat lz)
        {
            throw new NotImplementedException();
        }

        public SortedSet<Zutat> alleZutaten()
        {
            throw new NotImplementedException();
        }

        public void einheitSpeichern(Einheit e)
        {
            throw new NotImplementedException();
        }

        public List<Einheit> alleEinheiten()
        {
            throw new NotImplementedException();
        }
    }
}
