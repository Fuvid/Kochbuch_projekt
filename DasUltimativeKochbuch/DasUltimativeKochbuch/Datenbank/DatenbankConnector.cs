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
        void rezSpeichern(Rezept r);
        HashSet<Rezept> alleRezepte();
        HashSet<Rezept> rezepteMit(HashSet<Zutat> lz);

        HashSet<Zutat> alleZutaten();

        void einheitSpeichern(Einheit e);
        HashSet<Einheit> alleEinheiten();

    }
}
