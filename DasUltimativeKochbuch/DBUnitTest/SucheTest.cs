using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DasUltimativeKochbuch.Core;
using DasUltimativeKochbuch.Datenbank;
using System.Collections.Generic;

namespace DBUnitTest
{
    [TestClass]
    public class SucheTest
    {
        
        private class database : DatenbankConnector
        {
            List<Rezept> rez = new List<Rezept>();
            List<Einheit> ehl = new List<Einheit>();
            public void rezSpeichern(Rezept r)
            {

                rez.Add(r);
            }

            public void rezLoeschen(Rezept r)
            {
                rez.Remove(r);
            }

            public System.Collections.Generic.List<Rezept> rezepteMit(System.Collections.Generic.List<Zutat> lz)
            {
                List<Rezept> res = new List<Rezept>();
                foreach (Rezept r in rez) {
                    foreach (Zutat z in lz) { 
                        if (r.zutaten.Contains(z)) res.Add(r);
                    }
                }
                return res;
            }

            public void einheitSpeichern(Einheit e)
            {
                ehl.Add(e);
            }

            public System.Collections.Generic.List<Einheit> alleEinheiten()
            {
                return ehl;
            }
        }
        [TestMethod]
        public void TestSuche()
        {
            Ref.dbc = new database();
            Suche s = new Suche();
            //Hier abändern je nach Einträgen in der Datenbank, auf Reihenfolge achten!!
            Ref.dbc.einheitSpeichern(new Einheit("kg"));
            Ref.dbc.einheitSpeichern(new Einheit("g"));
            Ref.dbc.einheitSpeichern(new Einheit("l"));
            Ref.dbc.einheitSpeichern(new Einheit("Stk"));
            Ref.dbc.einheitSpeichern(new Einheit("tl"));
            Ref.dbc.einheitSpeichern(new Einheit("Msp"));
            Ref.dbc.einheitSpeichern(new Einheit("ml"));
            Ref.dbc.einheitSpeichern(new Einheit("cl"));
            //------------------------------------------------

            Zutat z = new Zutat("Wasser",new Einheit("l"));
            List<Zutat> zl = new List<Zutat>();
            zl.Add(z);
            Rezept r = new Rezept(zl, "gefrieren", "Eis", 4);
            s.find(zl,Suche.SORT_BY_BUY_LESS);
        }
    }
}
