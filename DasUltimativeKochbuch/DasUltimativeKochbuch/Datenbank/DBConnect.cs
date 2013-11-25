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
        private void executeQuery()
        {
            MySqlConnection connect;  
            MySqlCommand cmd;  
            string connectionLine;  
            string commandLine;  

            connectionLine = "Data source=localhost;UserId=root;Password=;";   
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
                MessageBox.Show(ex.Message);  
            }  
  
            commandLine = @"Hier Query";  
            
                //Set the command text  
  
                cmd.CommandText = commandLine;  
  
                //Set the parameters  
                
                //cmd.Parameters.AddWithValue("@name", inputName);  
                

               //Ausführen des Sql Queries
                cmd.ExecuteNonQuery();  
  
                //Close the connection  
                cmd.Connection.Close();  
  
                //Clear parameters  
                cmd.Parameters.Clear();  
        }



    }
}
