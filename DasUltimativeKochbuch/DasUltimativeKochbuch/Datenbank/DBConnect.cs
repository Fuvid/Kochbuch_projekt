using System;
using MySql.Data.MySqlClient;
using System.Windows;

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





        public void rezSpeichern(Core.Rezept r)
        {
            throw new NotImplementedException();
        }

        public System.Collections.Generic.List<Core.Rezept> alleRezepte()
        {
            throw new NotImplementedException();
        }

        public System.Collections.Generic.List<Core.Rezept> rezepteMit(System.Collections.Generic.List<Core.Zutat> lz)
        {
            throw new NotImplementedException();
        }

        public System.Collections.Generic.List<Core.Zutat> alleZutaten()
        {
            throw new NotImplementedException();
        }

        public void einheitSpeichern(Core.Einheit e)
        {
            throw new NotImplementedException();
        }

        public System.Collections.Generic.List<Core.Einheit> alleEinheiten()
        {
            throw new NotImplementedException();
        }
    }
}
