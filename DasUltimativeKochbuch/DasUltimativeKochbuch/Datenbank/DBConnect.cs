using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows;

namespace DasUltimativeKochbuch.Datenbank
{
    class DBConnect
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



    }
}
