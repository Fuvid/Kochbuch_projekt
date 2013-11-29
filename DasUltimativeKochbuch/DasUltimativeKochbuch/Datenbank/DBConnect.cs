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
            this.verbindungOeffnen();
            cmd = new MySqlCommand();

            commandLine = query;

            //Set the command texat  
            cmd.CommandText = commandLine;
            //Ausführen des Sql Queries
            cmd.ExecuteNonQuery();
            //Close the connection  
            cmd.Connection.Close();
        }

        public List<string> Select(string query)
        {
            List<string> rueck = new List<string>();
            this.verbindungOeffnen();

            //Create Command
            MySqlCommand cmd = new MySqlCommand(query, connect);
            //Create a data reader and Execute the command
            MySqlDataReader dataReader = cmd.ExecuteReader();

            while (dataReader.Read())
            {
                rueck.Add(dataReader[""] + "");
            }
            dataReader.Close();
            cmd.Connection.Close();
            return rueck;
        }



        public void rezSpeichern(Rezept r)
        {

            String query1;
            String query2;
            String query3;

            String name = r.name;
            String zubereitung = r.zubereitung;
            int pers = r.pers;
            // int usrID = 0;

            int rezeptID = 0;

            query1 = "INSERT INTO rezept(Name, Zubereitung, Personen) VALUES(@name, @zubereitung, @pers);SELECT LAST_INSERT_ID();"; // @usrID
            
            cmd = new MySqlCommand();
            this.verbindungOeffnen();
            //Parameter hinzufügen
            cmd.Parameters.AddWithValue("@name", name);
            cmd.Parameters.AddWithValue("@zubereitung", zubereitung);
            cmd.Parameters.AddWithValue("@pers", pers);
            // cmd.Parameters.AddWithValue("@usrID", usrID);
            commandLine = query1;
            
            //Set the command text  
            cmd.CommandText = commandLine;
            //Ausführen des Sql Queries
            rezeptID = Convert.ToInt32(cmd.ExecuteScalar());

            //-----------------------------------------------------

            foreach (Zutat zt in r.zutaten)
            {
                Console.WriteLine(zt);

                cmd.CommandText = @"SELECT ID FROM zutat WHERE name = @Name;";
                //Parameter hinzufügen
                cmd.Parameters.AddWithValue("Name", zt.name);
                MySqlDataReader Reader = cmd.ExecuteReader();
                while (Reader.Read())
                {
                    string rID = Reader["ID"].ToString();

                    if (rID == null)
                    {
                        query2 = "INSERT INTO zutat(´Name´,´Score´) VALUES(@name, @score);";
                        //Parameter hinzufügen
                        cmd.Parameters.AddWithValue("Name", zt.name);
                        cmd.Parameters.AddWithValue("Score", 0);

                        commandLine = query2;

                        //Set the command text  
                        cmd.CommandText = commandLine;
                        //Ausführen des Sql Queries
                        cmd.ExecuteNonQuery();
                    }
                    else
                    {
                        query2 = "UPDATE zutat SET Score=Score + 1 WHERE ID = @ID";
                        //Parameter hinzufügen
                        cmd.Parameters.AddWithValue("ID", rID);
                        commandLine = query2;

                        //Set the command text  
                        cmd.CommandText = commandLine;
                        //Ausführen des Sql Queries
                        cmd.ExecuteNonQuery();
                    }

                    //----------- Muss um EinheitID ergänzt werden

                    query3 = "INSERT INTO rezzut(´ZutatID´, ´Menge´,´RezeptID´) VALUES(@ZutatID, @rezeptID, @menge);";
                    //Parameter hinzufügen
                    cmd.Parameters.AddWithValue("ZutatID", rID);
                    cmd.Parameters.AddWithValue("Menge", zt.menge);
                    cmd.Parameters.AddWithValue("RezeptID", rezeptID);
                    

                    commandLine = query3;

                    //Set the command text  
                    cmd.CommandText = commandLine;
                    //Ausführen des Sql Queries
                    cmd.ExecuteNonQuery();

                    //Close the connection  
                    cmd.Connection.Close();
                }
                Reader.Close();
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
