using System;
using System.Collections.Generic;
using System.Linq;
using MySql.Data.MySqlClient;
using System.Windows;
using System.Collections.Generic;
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

        private void verbindungOeffen()
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
            this.verbindungOeffen();
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
            this.verbindungOeffen();

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
            throw new NotImplementedException();
            String query1;
            String query2;
            String query3;
            query1 = "INSERT INTO rezept(´Name´,´Zubereitung´,´Personen´,´UsrID´) VALUES();";
            query2 = "INSERT INTO zutat(´Name´,´Score´) VALUES();";
            query3 = "INSERT INTO rezzut(´Menge´,´´) VALUES();";
        }

        public List<Rezept> alleRezepte()
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
