using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DasUltimativeKochbuch.Core;

namespace DasUltimativeKochbuch.Datenbank
{
    public interface DatenbankConnector
    {
        void rezSpeichern(Rezept r);
        void rezLoeschen(Rezept r);

        //Liste mit allen Rezepten, die mindestens eine der Zutaten enthält
        List<Rezept> rezepteMit(List<Zutat> lz);

        void einheitSpeichern(Einheit e);
        List<Einheit> alleEinheiten();
    }
}
