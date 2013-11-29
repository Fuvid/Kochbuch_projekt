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
                Console.WriteLine(ex.Message);
            }
        }

        private void executeQuery(string query)
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

        private int executeQueryMitReturn(string query)
        {
            int ret;
            cmd = new MySqlCommand();
            this.verbindungOeffnen();

            cmd.CommandText = query;
            //Ausführen des Sql Queries und Rückgabe der ersten Spalte in der ersten Reihe
            ret = Convert.ToInt32(cmd.ExecuteScalar());
            //Close the connection  
            cmd.Connection.Close();
            return ret;
        }

        public int selectID(string query)
        {
            MySqlCommand cmd = new MySqlCommand(query, connect);
            this.verbindungOeffnen();
            //Create a data reader and Execute the command
            MySqlDataReader dataReader = cmd.ExecuteReader();
            dataReader.Read();
                if (dataReader.HasRows)
                {
                    string zID = Convert.ToString(dataReader["ID"]);
                    MessageBox.Show(zID);
                    cmd.Connection.Close();
                    return Convert.ToInt32(zID);
                }
                else
                {
                    cmd.Connection.Close();
                    return 0;
                }
        }



        public void rezSpeichern(Rezept r)
        {
            String query;
            int rezeptID;

            query = "INSERT INTO rezept(Name, Zubereitung, Personen) VALUES('"+ r.name +"', '"+ r.zubereitung +"', '"+ r.pers +"');SELECT LAST_INSERT_ID();"; // @usrID
            rezeptID = this.executeQueryMitReturn(query);       // Insert ausführen und die ID des Rezeptes speichern

            foreach (Zutat zt in r.zutaten)
            {
                query = "SELECT ID FROM zutat WHERE name = '"+ zt.name +"';";
                int zID = Convert.ToInt32(this.selectID(query));
                String query2;
                if (zID != 0)
                {
                    MessageBox.Show("Zutat vorhanden");
                    query2 = "UPDATE zutat SET Score=Score+1 WHERE ID = '" + zID + "'";
                    this.executeQuery(query2);
                }
                else
                {
                    MessageBox.Show("Zutat nicht vorhanden");
                    query2 = "INSERT INTO zutat(Name, Score) VALUES('" + zt.name + "', 0);";
                    this.executeQuery(query2);
                }
                


                    //----------- Muss um EinheitID ergänzt werden
                    //----------- Muss ZutatsID benutzen
                    
                
                    //String query3;
                    //query3 = "INSERT INTO rezzut(ZutatID, Menge, RezeptID) VALUES('" + zID +"', '" + zt.menge +"', '" + rezeptID +"');";
                    //this.executeQuery(query3);
            }
        }


            

        public List<Rezept> alleRezepte()
        {
            List<Rezept> alleRezepte = new List<Rezept>();
            string query;
            query = "SELECT * FROM rezept";
            
            cmd = new MySqlCommand();
            this.verbindungOeffnen();

            commandLine = query;

            //Set the command text  
            cmd.CommandText = commandLine;
            MySqlDataReader Reader = cmd.ExecuteReader();

            while (Reader.Read())
            {
                string rID = Reader["ID"].ToString();
                string rName = Reader["Name"].ToString();
                string rzubereitung = Reader["Zubereitung"].ToString();
                string rPersonen = Reader["Personen"].ToString();
            }
            Reader.Close();
            return alleRezepte;
        }
        private string GetDBString(string p, MySqlDataReader Reader)
        {
            throw new NotImplementedException();
        }
        public List<Rezept> rezepteMit(List<Zutat> lz)
        {
            throw new NotImplementedException();
        }

        public SortedSet<Zutat> alleZutaten()
        {
            throw new NotImplementedException();
        }

        public void einheitSpeichern(Einheit e)
        {
            throw new NotImplementedException();
        }

        public List<Einheit> alleEinheiten()
        {
            throw new NotImplementedException();
        }
    }
}
