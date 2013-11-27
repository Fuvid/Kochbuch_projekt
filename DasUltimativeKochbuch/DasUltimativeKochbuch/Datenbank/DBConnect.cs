using System;
using MySql.Data.MySqlClient;
using System.Windows;
using System.Collections.Generic;
using DasUltimativeKochbuch.Core;

namespace DasUltimativeKochbuch.Datenbank
{
    public class DBConnect:DatenbankConnector
    {
        private void executeQuery(string query)
        {
            MySqlConnection connect;
            MySqlCommand cmd;
            
            string connectionLine;
            string commandLine;

            connectionLine = "Data source=localhost;UserId=root;Password=;database=kochbuch";
            connect = new MySqlConnection(connectionLine);
            cmd = new MySqlCommand();
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

            commandLine = query;

            //Set the command texat  
            cmd.CommandText = commandLine;
            //Ausführen des Sql Queries
            cmd.ExecuteNonQuery();
            //Close the connection  
            cmd.Connection.Close();
        }





        public void rezSpeichern(Rezept r)
        {
            throw new NotImplementedException();
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
