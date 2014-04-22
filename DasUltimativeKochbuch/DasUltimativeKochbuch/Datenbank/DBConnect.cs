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
        string connectionLine;
        string commandLine;

        /// <summary>
        /// Anmeldedaten des MySQL Servers
        /// </summary>
        public DBConnect()
        {
            connectionLine = "Data source=localhost;UserId=root;Password=;database=kochbuch";
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

        public List<Einheit> selectEinheitName(string query)
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
                query = "INSERT INTO rezzut(ZutatID, Menge, RezeptID) VALUES('" + zID + "', '" + zt.menge + "', '" + rezeptID + "');";  //ZutatID, RezeptID und Menge in Tabelle "rezzut" eintragen
                this.executeQuery(query);

            }
            MessageBox.Show("Rezept hinzugefügt");
        }


        public List<Rezept> alleRezepte()
        {
            List<Rezept> alleRezepte = new List<Rezept>(); //Liste in die alle Rezepte gespeichert werden
            string query;
            string zutatQuery;
            query = "SELECT * FROM rezept"; //SQL -> alle Rezepte selektieren

            cmd = new MySqlCommand();
            this.verbindungOeffnen();

            commandLine = query;
            ///<summary>
            ///Set the command text | Befehlszeile setzen
            ///</summary>
            cmd.CommandText = commandLine;
            MySqlDataReader Reader = cmd.ExecuteReader();
            //--------------------------------
            while (Reader.Read())
            {
                int rID = Convert.ToInt32(Reader["ID"].ToString());//Deklarieren der Variablen, die Ein Obejekt in der Liste sind
                string rName = Reader["Name"].ToString();
                string rzubereitung = Reader["Zubereitung"].ToString();
                int rPersonen = Convert.ToInt32(Reader["Personen"].ToString());

                List<Zutat> rzutaten = new List<Zutat>();//Liste mit Zutaten erstellen, die später einen Teil der Liste<Rezept> darstellt

                zutatQuery = "SELECT ZutatID, Menge, Score FROM rezzut WHERE RezeptID = " + rID + ";";
                commandLine = zutatQuery;
                cmd.CommandText = commandLine;

                MySqlDataReader readerRezzut = cmd.ExecuteReader();
                while (readerRezzut.Read())
                {
                    int zID = Convert.ToInt32(readerRezzut["ZutatID"].ToString());
                    double zMenge = Convert.ToDouble(readerRezzut["Menge"]);
                    commandLine = "SELECT Name FROM zutat WHERE ID = " + zID + ";";
                    cmd.CommandText = commandLine;
                    MySqlDataReader readerZutat = cmd.ExecuteReader();
                    while (readerZutat.Read())
                    {
                        string zName = readerZutat["ID"].ToString();
                        Einheit e = new Einheit("test");

                        Zutat z = new Zutat(zName, e, zMenge);
                        rzutaten.Add(z);//Zutaten dem Rezept hinzufügen
                    }
                }
                Rezept r = new Rezept(rzutaten, rzubereitung, rName, rPersonen);
                alleRezepte.Add(r);//Rezept der Liste hinzufügen
            }
            Reader.Close();
            return alleRezepte;//Rückgabe aller Rezepte
        }

        public List<Rezept> rezepteMit(Zutat lz)
        {
            List<Rezept> rMit = new List<Rezept>();// Erstellen der Liste für alle Rezepte mit einer bestimmten Zutat

            cmd.CommandText = "SELECT ID FROM zutat WHERE Name = " + lz.name + ";";
            MySqlDataReader readerZutat = cmd.ExecuteReader();
            while (readerZutat.Read())
            {
                int zID = Convert.ToInt32(readerZutat["ID"]);
                cmd.CommandText = "SELECT RezeptID FROM rezzut WHERE ZutatID = " + zID + ";";
                MySqlDataReader readerRID = cmd.ExecuteReader();
                while (readerRID.Read())
                {
                    int rID = Convert.ToInt32(readerRID["RezeptID"]);
                    cmd.CommandText = "SELECT * FROM rezept WHERE ID = " + rID + ";";
                    MySqlDataReader readerRezept = cmd.ExecuteReader();
                    while (readerRezept.Read())
                    {
                        List<Zutat> z = new List<Zutat>();

                        string rName = readerRezept["Name"].ToString();
                        string rZubereitung = readerRezept["Zubereitung"].ToString();
                        int rPersonen = Convert.ToInt32(readerRezept["Personen"]);

                        cmd.CommandText = "SELECT ZutatID FROM rezzut WHERE RezeptID = " + rID + ";";
                        MySqlDataReader readerZutatID = cmd.ExecuteReader();
                        while (readerZutatID.Read())
                        {
                            string zutatenID = readerZutatID["ZutatID"].ToString();

                            cmd.CommandText = "SELECT Name FROM zutat WHERE ID = " + zutatenID + ";";
                            MySqlDataReader readerZutatName = cmd.ExecuteReader();
                            while (readerZutatName.Read())
                            {
                                string zName = readerZutatName["Name"].ToString();

                                Einheit e = new Einheit("Tasse");
                                Zutat zut = new Zutat(zName, e);
                                z.Add(zut);
                            }

                        }
                        Rezept r = new Rezept(z, rZubereitung, rName, rPersonen);
                        rMit.Add(r);
                    }
                }
            }
            return rMit;
        }

        public SortedSet<Zutat> alleZutaten()
        {
           // SortedSet<Zutat> alleZutaten = new SortedSet<Zutat>();
            //cmd.CommandText = "SELECT * FROM zutat";
            //MySqlDataReader readerZutat = cmd.ExecuteReader();
            //while (readerZutat.Read())
            //{
            //    Einheit e = new Einheit("test");
             //   string zName = readerZutat["Name"].ToString();
              //  Zutat z = new Zutat(zName, e);
              //  alleZutaten.Add(z);
            //}
            //return alleZutaten;
            throw new NotImplementedException();
        }

        public void einheitSpeichern(Einheit e)
        {
            string query;
            string name = e.name;

            query = "INSERT INTO einheit(Name) VALUES('" + name + "');";
            this.executeQuery(query);
            MessageBox.Show("Einheit hinzugefügt.");
        }

        public List<Einheit> alleEinheiten()
        {
            List<Einheit> einheiten = new List<Einheit>();
            commandLine = "SELECT * FROM einheit";
            cmd.CommandText = commandLine;
            MySqlDataReader readerEinheit = cmd.ExecuteReader();
            while (readerEinheit.Read())
            {
                string eName = readerEinheit["Name"].ToString();
                Einheit e = new Einheit(eName);
                einheiten.Add(e);
            }
            return einheiten;
        }


        public List<Rezept> rezepteMit(List<Zutat> lz)
        {
            this.verbindungOeffnen();
            cmd = new MySqlCommand();
            cmd.Connection = this.connect;
            List<Rezept> rMit = new List<Rezept>();
            List<int> rids = new List<int>();
            foreach (Zutat z in lz)
            {
                cmd.CommandText = "SELECT ID FROM zutat WHERE Name = '" + z.name + "';";
               
               
                MySqlDataReader readerZutat = cmd.ExecuteReader();
                while (readerZutat.Read())
                {
                    int zID = Convert.ToInt32(readerZutat["ID"]);
                    MessageBox.Show("SELECT RezeptID FROM rezzut WHERE ZutatID = '" + zID + "';");
                    cmd.CommandText = "SELECT RezeptID FROM rezzut WHERE ZutatID = '" + zID + "';";
                    MySqlDataReader readerRID = cmd.ExecuteReader();
                    while (readerRID.Read())
                    {
                        int rID = Convert.ToInt32(readerRID["RezeptID"]);
                        if (rids.Contains(rID))
                        {
                            continue;
                        }
                        rids.Add(rID);
                        cmd.CommandText = "SELECT * FROM rezept WHERE ID = '" + rID + "';";
                        MySqlDataReader readerRezept = cmd.ExecuteReader();
                        while (readerRezept.Read())
                        {
                            List<Zutat> zl = new List<Zutat>();

                            string rName = readerRezept["Name"].ToString();
                            string rZubereitung = readerRezept["Zubereitung"].ToString();
                            int rPersonen = Convert.ToInt32(readerRezept["Personen"]);

                            cmd.CommandText = "SELECT ZutatID FROM rezzut WHERE RezeptID = " + rID + ";";
                            MySqlDataReader readerZutatID = cmd.ExecuteReader();
                            while (readerZutatID.Read())
                            {
                                string zutatenID = readerZutatID["ZutatID"].ToString();

                                cmd.CommandText = "SELECT Name FROM zutat WHERE ID = " + zutatenID + ";";
                                MySqlDataReader readerZutatName = cmd.ExecuteReader();
                                while (readerZutatName.Read())
                                {
                                    string zName = readerZutatName["Name"].ToString();

                                    Einheit e = new Einheit("Tasse");
                                    Zutat zut = new Zutat(zName, e);
                                    zl.Add(zut);
                                }

                            }
                            Rezept r = new Rezept(zl, rZubereitung, rName, rPersonen);
                            rMit.Add(r);
                        }
                    }
                }
            }
            cmd.Connection.Close();
            return rMit;

        }
    }
}
