﻿using System;
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
                MessageBox.Show("Rezept hinzugefügt");
            }
        }


            

        public List<Rezept> alleRezepte()
        {
            List<Rezept> alleRezepte = new List<Rezept>();
            string query;
            string zut_query;
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
                String rPersonen = Reader["Personen"].ToString();
               // ab hier nur test oder halt falsch
                zut_query = "SELECT ZutatID, EinheitID FROM rezzut WHERE RezeptID ='" + rID + "'";
                cmd.CommandText = zut_query;
               
                MySqlDataReader ZutReader = cmd.ExecuteReader();
                List<Zutat> zl = new List<Zutat>();
                while (ZutReader.Read()){
                 //   zl.Add(new Zutat(ZutReader["Name"].ToString(),Ref.einheiten.Find(eh => eh.)));
                }
                alleRezepte.Add(new Rezept(zl, rzubereitung,rName, Convert.ToInt32(rPersonen)));

            }
            Reader.Close();

            return alleRezepte;
        }
        private string GetDBString(string p, MySqlDataReader Reader)
        {
            throw new NotImplementedException();
        }
        public List<Rezept> rezepteMit(Zutat zt)
        {
            int zID;
            int rezeptID;
            String query;

            query = "SELECT ID FROM zutat WHERE name = '" + zt.name + "';";
            zID = Convert.ToInt32(this.selectID(query));        //Nach Zutat suchen

            query = "SELECT * FROM rezzut WHERE zutatID ='"+zID+"'";
            
            cmd = new MySqlCommand();
            this.verbindungOeffnen();

            commandLine = query;

            //Set the command text  
            cmd.CommandText = commandLine;
            MySqlDataReader Reader = cmd.ExecuteReader();


            query = "INSERT INTO rezept(Name, Zubereitung, Personen) VALUES('" + r.name + "', '" + r.zubereitung + "', '" + r.pers + "');SELECT LAST_INSERT_ID();"; // @usrID
            rezeptID = this.executeQueryMitReturn(query);       // Insert ausführen und die ID des Rezeptes speichern
            
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
            query = "INSERT INTO rezzut(ZutatID, Menge, RezeptID) VALUES('" + zID + "', '" + zt.menge + "', '" + rezeptID + "');";  //ZutatID, RezeptID und Menge in Tabelle "rezzut" eintragen
            this.executeQuery(query);
            MessageBox.Show("Rezept hinzugefügt");
            
        }

        public SortedSet<Zutat> alleZutaten()
        {
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
            throw new NotImplementedException();
        }
    }
}
