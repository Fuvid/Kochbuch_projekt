using System;
using System.Collections.Generic;
using System.Linq;
using MySql.Data.MySqlClient;
using System.Windows;
using DasUltimativeKochbuch.Core;

namespace DasUltimativeKochbuch.Datenbank
{
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1001:TypesThatOwnDisposableFieldsShouldBeDisposable")]
    public class DBConnect : DatenbankConnector
    {
        MySqlConnection connect;
        MySqlCommand cmd = new MySqlCommand();
        string connectionLine = "Data source=localhost;UserId=root;Password=;database=kochbuch";
        string commandLine;

        /// <summary>
        /// Anmeldedaten des MySQL Servers
        /// </summary>
        public DBConnect()
        {
            connect = new MySqlConnection(connectionLine);
        }
        ///<summary>
        ///Verbindung zur Datenbank herstellen
        ///Bei Misserfolg Fehlermeldung ausgeben
        ///</summary>
        private void verbindungOeffnen()
        {
            try
            {
                cmd.Connection = connect;
                cmd.Connection.Open();
            }
            catch (NullReferenceException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        ///<summary>
        ///Zum ausführen von einfachen SQL Anweisungen ohne Rückgabe
        ///</summary>
        private void executeQuery(string query)
        {
            cmd = new MySqlCommand();
            this.verbindungOeffnen();
            commandLine = query;
            cmd.CommandText = commandLine;
            cmd.ExecuteNonQuery();
            cmd.Connection.Close();
        }

        ///<summary>
        /// Zum ausführen von einfachen SQL Anweisungen mit Rückgabe, z.B. eine Id nach einem Insert
        ///</summary>
        private int executeQueryMitReturn(string query)
        {
            cmd = new MySqlCommand();
            this.verbindungOeffnen();
            cmd.CommandText = query;
            int ret = Convert.ToInt32(cmd.ExecuteScalar());
            cmd.Connection.Close();
            return ret;
        }

        public int selectID(string query)
        {
            MySqlCommand cmd = new MySqlCommand(query, connect);
            this.verbindungOeffnen();
            ///<summary>
            ///Erstellen eines MySQL-Datensatzlesers und anschließende Befehlausführung 
            ///</summary>
            MySqlDataReader dataReader = cmd.ExecuteReader();

            ///<summary>
            ///Der Reader fängt an Zeilen zu lesen 
            ///</summary>
            dataReader.Read();

            ///<summary>
            ///Wenn der Reader Zeilen besitzt dann wird die ID zurückgegeben
            ///</summary>
            if (dataReader.HasRows)
            {
                string ID = Convert.ToString(dataReader["ID"]);
                cmd.Connection.Close();
                return Convert.ToInt32(ID);
            }
            else
            ///<summary>
            ///Wenn nicht wird 0 zurückgegeben
            ///</summary>
            {
                cmd.Connection.Close();
                return 0;
            }
        }

        ///<summary>
        ///Selektieren der Einheiten und Rückgabe einer Liste mit allen in der Datenbank vorhandenen Einheiten
        ///</summary>
        public List<Einheit> selectEinheitName(string query)
        {
            MySqlCommand cmd = new MySqlCommand(query, connect);
            this.verbindungOeffnen();
            MySqlDataReader dataReader = cmd.ExecuteReader();
            List<Einheit> einheiten = new List<Einheit>();
            while (dataReader.Read())
            {
                string tmp = Convert.ToString(dataReader["Name"]);
                Einheit e = new Einheit("tmp");
                einheiten.Add(e);
            }
            cmd.Connection.Close();
            return einheiten;
        }


        ///<summary>
        ///Methode zum einfügen von Rezepten in die Datenbank, sowie der dazugehörigen Zutaten
        ///</summary>
        public void rezSpeichern(Rezept r)
        {

            int rezeptID;
            String query;

            query = "INSERT INTO rezept(Name, Zubereitung, Personen) VALUES('" + r.name + "', '" + r.zubereitung + "', '" + r.pers + "');SELECT LAST_INSERT_ID();"; // @usrID
            rezeptID = this.executeQueryMitReturn(query);
            foreach (Zutat zt in r.zutaten)
            {
                query = "SELECT ID FROM zutat WHERE name = '" + zt.name + "';";
                int zID = Convert.ToInt32(this.selectID(query));
                if (zID != 0)
                {
                    query = "UPDATE zutat SET Score=Score+1 WHERE ID = '" + zID + "'";
                    this.executeQuery(query);
                }
                else
                {
                    query = "INSERT INTO zutat(Name, Score) VALUES('" + zt.name + "', 0);";
                    this.executeQuery(query);

                    query = "SELECT ID FROM zutat WHERE name = '" + zt.name + "';";
                    zID = Convert.ToInt32(this.selectID(query));
                }
                //Muss um EinheitID ergänzt werden
                string einheitName = zt.einh.name;

                cmd = new MySqlCommand();
                this.verbindungOeffnen();
                cmd.CommandText = "SELECT ID FROM einheit WHERE Name = '" + einheitName + "';";
                MySqlDataReader readerRID = cmd.ExecuteReader();
                string eID = "";
                while (readerRID.Read())
                {
                    eID = readerRID["ID"].ToString();
                }
                readerRID.Close();
                cmd.Connection.Close();

                query = "INSERT INTO rezzut(ZutatID, Menge, RezeptID, EinheitID) VALUES('" + zID + "', '" + zt.menge + "', '" + rezeptID + "','" + eID + "');";  //ZutatID, RezeptID und Menge in Tabelle "rezzut" eintragen
                this.executeQuery(query);
            }
            MessageBox.Show("Rezept hinzugefügt");
        }
        ///<summary>
        ///Methode zum speichern von Einheiten in die Datenbank
        ///</summary>
        public void einheitSpeichern(Einheit e)
        {
            string query;
            string name = e.name;

            query = "INSERT INTO einheit(Name) VALUES('" + name + "');";
            this.executeQuery(query);
        }
        ///<summary>
        ///Methode zum selektieren aller Einheiten
        ///</summary>
        public List<Einheit> alleEinheiten()//sollte funktionieren
        {
            List<Einheit> einheiten = new List<Einheit>();
            commandLine = "SELECT * FROM einheit";
            cmd.CommandText = commandLine;
            this.verbindungOeffnen();
            MySqlDataReader readerEinheit = cmd.ExecuteReader();
            while (readerEinheit.Read())
            {
                string eName = readerEinheit["Name"].ToString();
                Einheit e = new Einheit(eName);
                einheiten.Add(e);
            }
            cmd.Connection.Close();
            return einheiten;
        }

        ///<summary>
        ///Methode für den Abruf aller Rezepte aus der Datenbank mit einer bestimmten Zutat
        ///</summary>
        public List<Rezept> rezepteMit(List<Zutat> lz)
        {
            this.verbindungOeffnen();
            cmd = new MySqlCommand();
            cmd.Connection = this.connect;
            List<Rezept> rMit = new List<Rezept>();
            List<int> rids = new List<int>();
            HashSet<int> rezID = new HashSet<int>();
            int[] zID = new int[100];
            int counter1 = 0;
            int counter2 = 0;
            foreach (Zutat z in lz)
            {
                cmd.CommandText = "SELECT ID FROM zutat WHERE Name = '" + z.name + "';";
                MySqlDataReader readerZutat = cmd.ExecuteReader();
                while (readerZutat.Read())
                {
                    zID[counter1] = Convert.ToInt32(readerZutat["ID"]);
                    counter1++;
                }
                readerZutat.Close();
                //ID der Zutat in zID
                //Jetzt RezeptID's der Zutat holen

                foreach (int zutID in zID)
                {
                    if (zutID == 0) break;
                    cmd.CommandText = "SELECT RezeptID FROM rezzut WHERE ZutatID = " + zutID + " limit 100;";
                    MySqlDataReader readerRID = cmd.ExecuteReader();
                    int[] rID = new int[100];
                    //HashSet<int> rezID = new HashSet<int>();

                    int i = 0;
                    while (readerRID.Read())
                    {
                        //rID[i] = Convert.ToInt32(readerRID["RezeptID"]);
                        //i++;
                        if (rezID.Contains(Convert.ToInt32(readerRID["RezeptID"])))
                        {
                        }
                        else
                        {
                            rezID.Add(Convert.ToInt32(readerRID["RezeptID"]));
                        }
                    }
                    readerRID.Close();
                }
            }
            foreach (int id in rezID)
            {
                //Jetzt Daten des rezeptes holen
                if (id == 0) break;
                cmd.CommandText = "SELECT * FROM rezept WHERE ID = '" + id + "';";
                MySqlDataReader readerRezept = cmd.ExecuteReader();
                string rName = "";
                string rZubereitung = "";
                int rPersonen = 0;
                int rId = 0;
                List<Zutat> zl = new List<Zutat>();
                while (readerRezept.Read())
                {
                    rName = readerRezept["Name"].ToString();
                    rZubereitung = readerRezept["Zubereitung"].ToString();
                    rPersonen = Convert.ToInt32(readerRezept["Personen"]);
                    rId = Convert.ToInt32(readerRezept["ID"]);
                }
                readerRezept.Close();
                cmd.CommandText = "SELECT ZutatID FROM rezzut WHERE RezeptID = " + id + ";";
                MySqlDataReader readerZutatID = cmd.ExecuteReader();
                int[] zutatenID = new int[100];
                int j = 0;
                while (readerZutatID.Read())
                {
                    zutatenID[j] = Convert.ToInt32(readerZutatID["ZutatID"]);
                    j++;
                }
                readerZutatID.Close();
                foreach (int zid in zutatenID)
                {
                    string eName = "";
                    double m = 0;
                    cmd.CommandText = "SELECT R.ZutatID, E.Name AS Name, R.Menge AS Menge FROM rezzut AS R JOIN Einheit AS E ON R.EinheitID = E.ID WHERE R.ZutatID =" + zid + " AND R.RezeptID =" + id + ";";
                    MySqlDataReader readerEinheit = cmd.ExecuteReader();
                    while (readerEinheit.Read())
                    {
                        eName = readerEinheit["Name"].ToString();
                        m = Convert.ToInt32(readerEinheit["Menge"]);
                    }
                    readerEinheit.Close();
                    cmd.CommandText = "SELECT Name, Score FROM zutat WHERE ID = '" + zid + "';";
                    MySqlDataReader readerZutatName = cmd.ExecuteReader();
                    while (readerZutatName.Read())
                    {
                        string zName = readerZutatName["Name"].ToString();

                        Einheit e = new Einheit(eName);
                        Zutat zut = new Zutat(zName, e, m);
                        zut.score = Convert.ToInt32(readerZutatName["Score"]);
                        zl.Add(zut);
                    }
                    readerZutatName.Close();
                }
                Rezept r = new Rezept(zl, rZubereitung, rName, rPersonen);
                r.rezeptId = rId;
                rMit.Add(r);
            }
            cmd.Connection.Close();
            return rMit;
        }
        ///<summary>
        ///Methode zum Löschen einzelner Rezepte
        ///</summary>
        public void rezLoeschen(Rezept r)
        {
            string query;
            query = "DELETE FROM rezept WHERE ID = "+r.rezeptId+";";
            this.executeQuery(query);
            query = "DELETE FROM rezzut WHERE ID = " + r.rezeptId + ";";
            this.executeQuery(query);
        }
    }
}
