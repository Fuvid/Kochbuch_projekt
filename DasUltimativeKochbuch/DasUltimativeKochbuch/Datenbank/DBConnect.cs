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

        private void verbindungOeffnen()
        {
            try
            {
                ///<summary>
                ///Verbindung an die Datenbank herstellen
                ///</summary>
                cmd.Connection = connect;
                ///<summary>
                ///Verbindung öffnen
                ///</summary>
                cmd.Connection.Open();
            }
            catch (NullReferenceException ex)
            {

                ///<summary>
                ///Fehler abfangen und in Messagebox ausgeben
                ///</summary>
                MessageBox.Show(ex.Message);
            }
        }

        ///<summary>
        ///Zum ausführen von SQL Anweisungen ohne Rückgabe
        ///</summary>
        private void executeQuery(string query)
        {
            cmd = new MySqlCommand();
            this.verbindungOeffnen();


            commandLine = query;

            ///<summary>
            ///Set the command text | Befehlszeile setzen
            ///</summary>
            cmd.CommandText = commandLine;
            ///<summary>
            ///Ausführen des SQL-Eintrages
            ///</summary>
            cmd.ExecuteNonQuery();
            ///<summary>
            ///Verbindung schließen
            ///</summary>
            cmd.Connection.Close();
        }

        ///<summary>
        /// 
        ///</summary>
        private int executeQueryMitReturn(string query)
        {
            cmd = new MySqlCommand();
            this.verbindungOeffnen();

            cmd.CommandText = query;
            ///<summary>
            ///Ausführen des SQL-Eintrages und Rückgabe der ersten Spalte in der ersten Reihe
            ///</summary>
            int ret = Convert.ToInt32(cmd.ExecuteScalar());
            ///<summary>
            ///Verbindung schließen 
            ///</summary>  
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

        private List<Einheit> selectEinheitName(string query)
        {
            MySqlCommand cmd = new MySqlCommand(query, connect);
            this.verbindungOeffnen();
            ///<summary>
            ///Erstellen eines MySQL-Datensatzlesers und anschließende Befehlausführung 
            ///</summary>
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



        public void rezSpeichern(Rezept r)
        {

            int rezeptID;
            String query;

            query = "INSERT INTO rezept(Name, Zubereitung, Personen) VALUES('" + r.name + "', '" + r.zubereitung + "', '" + r.pers + "');SELECT LAST_INSERT_ID();"; // @usrID
            ///<summary>
            ///Insert ausführen und die ID des Rezeptes speichern
            ///</summary>
            rezeptID = this.executeQueryMitReturn(query);
            foreach (Zutat zt in r.zutaten)
            {
                query = "SELECT ID FROM zutat WHERE name = '" + zt.name + "';";
                ///<summary>
                ///Nach Zutat suchen
                ///</summary>
                int zID = Convert.ToInt32(this.selectID(query));

                ///<summary>
                ///Wenn Zutat vorhanden Score inkrementieren | Wenn nicht vorhanden, Zutat hinzufügen und ID der Zutat speichern
                ///</summary>
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

                ///<summary>
                ///Muss um EinheitID ergänzt werden
                ///</summary>
                ///
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

        public void einheitSpeichern(Einheit e)
        {
            string query;
            string name = e.name;

            query = "INSERT INTO einheit(Name) VALUES('" + name + "');";
            this.executeQuery(query);
        }

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


        public List<Rezept> rezepteMit(List<Zutat> lz)//Done
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
                List<Zutat> zl = new List<Zutat>();
                while (readerRezept.Read())
                {
                    rName = readerRezept["Name"].ToString();
                    rZubereitung = readerRezept["Zubereitung"].ToString();
                    rPersonen = Convert.ToInt32(readerRezept["Personen"]);
                }
                readerRezept.Close();
                cmd.CommandText = "SELECT ZutatID FROM rezzut WHERE RezeptID = " + id + ";";
                MySqlDataReader readerZutatID = cmd.ExecuteReader();
                //hier for
                int[] zutatenID = new int[100];
                int j = 0;
                while (readerZutatID.Read())
                {
                    zutatenID[j] = Convert.ToInt32(readerZutatID["ZutatID"]);
                    j++;
                }
                readerZutatID.Close();
                //--
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
                    //---------------
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

                    //counter2++;
                }
                Rezept r = new Rezept(zl, rZubereitung, rName, rPersonen);
                rMit.Add(r);
            }
            cmd.Connection.Close();
            return rMit;
        }
       public void rezLoeschen(Rezept r) {
            throw new NotImplementedException();
        }
    }
}
