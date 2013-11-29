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

        private int executeQueryMitReturn(string query)
        {
            int ret;
            cmd = new MySqlCommand();
            this.verbindungOeffnen();
            

            commandLine = query;

            //Set the command texat  
            cmd.CommandText = commandLine;
            //Ausführen des Sql Queries
            ret = Convert.ToInt32(cmd.ExecuteScalar());
            //Close the connection  
            cmd.Connection.Close();
            return ret;
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
            String query;
            int rezeptID;

            query = "INSERT INTO rezept(Name, Zubereitung, Personen) VALUES('"+ r.name +"', '"+ r.zubereitung +"', '"+ r.pers +"');SELECT LAST_INSERT_ID();"; // @usrID

            rezeptID = this.executeQueryMitReturn(query);

            //-----------------------------------------------------

            foreach (Zutat zt in r.zutaten)
            {
                cmd.CommandText = @"SELECT ID FROM zutat WHERE name = '"+ zt.name +"';";
                //Parameter hinzufügen
                //cmd.Parameters.AddWithValue("Name", zt.name);
                MySqlDataReader Reader = cmd.ExecuteReader();
                while (Reader.Read())
                {
                    string rID = Reader["ID"].ToString();
                    MessageBox.Show(rID);
                    String query2;
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
                    String query3;
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
