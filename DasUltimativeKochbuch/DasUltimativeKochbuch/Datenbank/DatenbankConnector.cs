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
        List<Rezept> alleRezepte();
        //Liste mit allen Rezepten, die mindestens eine der Zutaten enthält

        List<Rezept> rezepteMit(Zutat lz);


        SortedSet<Zutat> alleZutaten();

        void einheitSpeichern(Einheit e);
        List<Einheit> alleEinheiten();

    }
}
