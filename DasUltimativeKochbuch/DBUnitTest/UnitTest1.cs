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
            //Hier abändern je nach Einträgen in der Datenbank, auf Reihenfolge achten
            Einheit[] earray = new Einheit[2];
            earray[0] = new Einheit("Stk");
            earray[1] = new Einheit("kg");

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
    }
}