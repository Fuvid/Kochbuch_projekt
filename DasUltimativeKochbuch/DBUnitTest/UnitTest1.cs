using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DasUltimativeKochbuch.Core;
using DasUltimativeKochbuch.Datenbank;
using System.Collections.Generic;

namespace DBUnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void einheitenTest()
        {
            //Hier abändern je nach Einträgen in der Datenbank, auf Reihenfolge achten!!
            Einheit[] earray = new Einheit[2];
            earray[0] = new Einheit("Stk");
            earray[1] = new Einheit("kg");
            //------------------------------------------------
            DBConnect db = new DBConnect();
            List<Einheit> el = new List<Einheit>();
            el = db.alleEinheiten();
            int i = 0;
            foreach (Einheit e in el)
            {
                string eName = e.name;
                Assert.AreEqual(eName, earray[i].name);
                i++;
            }
        }

        [TestMethod]
        public void RezepteTest()
        {
            /* Vor ausführen dieses Tests Rezept in der Datenbank hinzufügen
             * Name: eis, personen: 1, zubereitung: asdsdas
             * Zutat: wasser: 1 Stk
             * Zusätzlich darf kein anderes Rezept mit Zutat wasser in der Db stehen
            */ 
            DBConnect db = new DBConnect();

            Einheit e1 = new Einheit("Stk");
            Zutat z = new Zutat("wasser", e1);
            List<Zutat> zl = new List<Zutat>();
            zl.Add(z);
            Rezept r1 = new Rezept(zl, "asdsdas", "eis", 1);

            List<Rezept> dbrez = new List<Rezept>();


            dbrez = db.rezepteMit(zl);

            foreach (Rezept r in dbrez)
            {
                Assert.AreEqual(r1.name, r.name);
                Assert.AreEqual(r1.zubereitung, r.zubereitung);
                Assert.AreEqual(r1.pers, r.pers);
                
            }

        }

    }
}