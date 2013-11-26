using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DasUltimativeKochbuch.Core;

namespace DasUltimativeKochbuch.Datenbank
{
    interface DatenbankConnector
    {
        public void rezSpeichern(Rezept r);
        public List<Rezept> alleRezepte();
        public List<Rezept> rezepteMit(List<Zutat> lz);

        public List<Zutat> alleZutaten();

        public void einheitSpeichern(Einheit e);
        public List<Einheit> alleEinheiten();

    }
}
