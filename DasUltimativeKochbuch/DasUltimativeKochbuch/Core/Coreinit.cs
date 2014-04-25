using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DasUltimativeKochbuch.Datenbank;

namespace DasUltimativeKochbuch.Core
{
    static class Coreinit
    {
       /// <summary>
       /// <para> 
       /// Wird am anfang des Programmes aufgerufen und soll die wichtigsten Umgebungsvariablen setzen,
       /// die für den Programmablauf benötigt werden. 
       /// </para>
       /// </summary>
        public static void ini() {

            Ref.dbc = new DBConnect();
            
            Ref.defaultValues = new Dictionary<string, string>();
            
            Ref.defaultValues.Add("TB_Zutaten", "Hier Zutaten bitte Kommagetrennt eingeben");
            Ref.defaultValues.Add("TB_Rezeptname", "Rezeptname");
            Ref.defaultValues.Add("TB_Zubereitung", "Zubereitung");
            Ref.defaultValues.Add("TB_Zutat", "Zutat");
            Ref.defaultValues.Add("TB_Menge", "Menge");
            Ref.defaultValues.Add("TB_Personenanzahl", "");
            //Ref.defaultValues.Add();

            Ref.ehl = Ref.dbc.alleEinheiten();
            
        }
    }
}
