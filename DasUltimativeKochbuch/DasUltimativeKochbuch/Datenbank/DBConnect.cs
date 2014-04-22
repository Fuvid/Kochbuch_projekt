using System;
using System.Collections.Generic;
using System.Linq;
using MySql.Data.MySqlClient;
using System.Windows;
using DasUltimativeKochbuch.Core;

namespace DasUltimativeKochbuch.Datenbank
{
    public class DBConnect:DatenbankConnector
    {
        MySqlConnection connect;
        MySqlCommand cmd;
        string connectionLine;
        string commandLine;
        

        public DBConnect()
        {
            //Anmeldedaten des MySQL Servers
            connectionLine = "Data source=localhost;UserId=root;Password=;database=kochbuch";
            connect = new MySqlConnection(connectionLine);
        }

        private void verbindungOeffnen()
        {
            try
            {
                //Create a connection  
                cmd.Connection = connect;
                //Open the connection
                cmd.Connection.Open();
            }
            catch (NullReferenceException ex)
            {
                //Fehler abfangen und in Messagebox ausgeben
                MessageBox.Show(ex.Message);
            }
        }

        private void executeQuery(string query)         //Zum ausführen von SQL Anweisungen ohne Rückgabe
        {
            cmd = new MySqlCommand();
            this.verbindungOeffnen();
            

            commandLine = query;

            //Set the command texat  
            cmd.CommandText = commandLine;
            //Ausführen des Sql Queries
            cmd.ExecuteNonQuery();
            //Close the connection  
            cmd.Connection.Close();
        }

        private int executeQueryMitReturn(string query)         //
        {
            cmd = new MySqlCommand();
            this.verbindungOeffnen();

            cmd.CommandText = query;
            //Ausführen des Sql Queries und Rückgabe der ersten Spalte in der ersten Reihe
            int ret = Convert.ToInt32(cmd.ExecuteScalar());
            //Verbindung schließen  
            cmd.Connection.Close();
            return ret;
        }

        public int selectID(string query)
        {
            MySqlCommand cmd = new MySqlCommand(query, connect);
            this.verbindungOeffnen();
            //Create a data reader and Execute the command
            MySqlDataReader dataReader = cmd.ExecuteReader();

            dataReader.Read();      //der Reader fängt an Zeilen zu lesen
                if (dataReader.HasRows)     //Wenn der Reader Zeilen besitzt dann wird die Id zurückgegeben
                {
                    string ID = Convert.ToString(dataReader["ID"]);
                    cmd.Connection.Close();
                    return Convert.ToInt32(ID);
                }
                else        //Wenn nicht wird 0 zurückgegeben
                {
                    cmd.Connection.Close();
                    return 0;
                }
        }

        public List<Einheit> selectEinheitName(string query)
        {
            MySqlCommand cmd = new MySqlCommand(query, connect);
            this.verbindungOeffnen();
            //Create a data reader and Execute the command
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
            rezeptID = this.executeQueryMitReturn(query);       // Insert ausführen und die ID des Rezeptes speichern
            foreach (Zutat zt in r.zutaten)
            {
                query = "SELECT ID FROM zutat WHERE name = '"+ zt.name +"';";
                int zID = Convert.ToInt32(this.selectID(query));        //Nach Zutat suchen

                if (zID != 0)       //Wenn Zutat vorhanden Score inkrementieren | Wenn nicht vorhanden, Zutat hinzufügen und ID der Zutat speichern
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
                
                //----------- Muss um EinheitID ergänzt werden
                query = "INSERT INTO rezzut(ZutatID, Menge, RezeptID) VALUES('" + zID +"', '" + zt.menge +"', '" + rezeptID +"');";  //ZutatID, RezeptID und Menge in Tabelle "rezzut" eintragen
                this.executeQuery(query);
                
            }
            MessageBox.Show("Rezept hinzugefügt");
        }


        public List<Rezept> alleRezepte()
        {
            List<Rezept> alleRezepte = new List<Rezept>();                  //Liste in die alle Rezepte gespeichert werden
            string query = "SELECT * FROM rezept";                          //SQL -> alle Rezepte selektieren
            string zutatQuery;
            cmd = new MySqlCommand();
            this.verbindungOeffnen();
            commandLine = query;
            cmd.CommandText = commandLine;
            MySqlDataReader Reader = cmd.ExecuteReader();           
            while (Reader.Read())
            {
                int rID = Convert.ToInt32(Reader["ID"].ToString());         //Deklarieren der Variablen, die Ein Obejekt in der Liste sind
                string rName = Reader["Name"].ToString();
                string rzubereitung = Reader["Zubereitung"].ToString();
                int rPersonen = Convert.ToInt32(Reader["Personen"].ToString());

                List<Zutat> rzutaten = new List<Zutat>();                   //Liste mit Zutaten erstellen, die später einen Teil der Liste<Rezept> darstellt

                //-----------
                zutatQuery = "SELECT ZutatID, Menge, Score FROM rezzut WHERE RezeptID = "+ rID +";";    //SQL-> Selektieren von ZutatID, Menge, Score der Zutaten
                commandLine = zutatQuery;
                cmd.CommandText = commandLine;
                //---------
                MySqlDataReader readerRezzut = cmd.ExecuteReader();
                while (readerRezzut.Read())
                {
                    int zID = Convert.ToInt32(readerRezzut["ZutatID"].ToString());
                    double zMenge = Convert.ToDouble(readerRezzut["Menge"]);
                    commandLine = "SELECT Name FROM zutat WHERE ID = "+zID+";";         //Selektieren von Zutaten-Name
                    cmd.CommandText = commandLine;
                    MySqlDataReader readerZutat = cmd.ExecuteReader();
                    while (readerZutat.Read())
                    {
                        string zName = readerZutat["ID"].ToString();                    
                        Einheit e = new Einheit("test");                                //Erstellen der Einheit für die Zutat

                        Zutat z = new Zutat(zName, e, zMenge);                          //Erstellen des Objekts Zutat
                        rzutaten.Add(z);            //Zutaten dem Rezept hinzufügen
                    }
                }
                Rezept r = new Rezept(rzutaten, rzubereitung, rName, rPersonen);        //Rezept erstellen
                alleRezepte.Add(r);         //Rezept der Liste hinzufügen
            }
            Reader.Close();         
            return alleRezepte;             //Rückgabe aller Rezepte
        }

        public List<Rezept> rezepteMit(Zutat lz)
        {
            List<Rezept> rMit = new List<Rezept>();         // Erstellen der Liste für alle Rezepte mit einer bestimmten Zutat
            
            cmd.CommandText = "SELECT ID FROM zutat WHERE Name = " + lz.name + ";";         //SQL-> Selektieren der ID 
            MySqlDataReader readerZutat = cmd.ExecuteReader();
            while(readerZutat.Read())
            {
               int zID = Convert.ToInt32(readerZutat["ID"]);
               cmd.CommandText = "SELECT RezeptID FROM rezzut WHERE ZutatID = "+zID+";";
               MySqlDataReader readerRID = cmd.ExecuteReader();
               while(readerRID.Read())
               {
                   int rID = Convert.ToInt32(readerRID["RezeptID"]);
                   cmd.CommandText = "SELECT * FROM rezept WHERE ID = "+rID+";";
                   MySqlDataReader readerRezept = cmd.ExecuteReader();
                   while(readerRezept.Read())
                   {
                       List<Zutat> z = new List<Zutat>();

                       string rName = readerRezept["Name"].ToString();
                       string rZubereitung = readerRezept["Zubereitung"].ToString();
                       int rPersonen = Convert.ToInt32(readerRezept["Personen"]);
                       
                       cmd.CommandText = "SELECT ZutatID FROM rezzut WHERE RezeptID = "+rID+";";
                       MySqlDataReader readerZutatID = cmd.ExecuteReader();
                       while(readerZutatID.Read())
                       {
                           string zutatenID = readerZutatID["ZutatID"].ToString();

                           cmd.CommandText = "SELECT Name FROM zutat WHERE ID = "+zutatenID+";";
                           MySqlDataReader readerZutatName = cmd.ExecuteReader();
                           while(readerZutatName.Read())
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

        public SortedSet<Zutat> alleZutaten()       // Methode für Rückgabe aller Zutaten
        {
            SortedSet<Zutat> alleZutaten = new SortedSet<Zutat>();      //Erstellen des Sortedsets
            cmd.CommandText = "SELECT * FROM zutat";                    //SQL-> Selektieren aller Zutaten
            MySqlDataReader readerZutat = cmd.ExecuteReader();
            while (readerZutat.Read())
            {
                Einheit e = new Einheit("test");                //Einheit der Zutat erstellen
                string zName = readerZutat["Name"].ToString();  
                Zutat z = new Zutat(zName, e);              //Zutat erstellen
                alleZutaten.Add(z);             //Zutat der Liste hinzufügen
            }
            return alleZutaten;         //Rückgabe des SortedSet
        }

        public void einheitSpeichern(Einheit e)     //Methode zum speichern einer Einheit
        {
            string query;
            string name = e.name;

            query = "INSERT INTO einheit(Name) VALUES('" + name + "');";    //SQL-> Einfügen der Einheiten
            this.executeQuery(query);       //Aufruf der Execute Methode
            MessageBox.Show("Einheit hinzugefügt.");    
        }

        public List<Einheit> alleEinheiten()
        {
            List<Einheit> einheiten = new List<Einheit>();      // Liste aller Einheiten
            commandLine = "SELECT * FROM einheit";      //SQL-> Selektieren aller Einheiten
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
            throw new NotImplementedException();
        }
    }
}
