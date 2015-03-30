using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Data.SQLite;

namespace WebShop
{
    public class ConnDB // clasa za komunikaciju sa bazom (prvi lejer)
    {
        string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString; // connection string
        public DataSet GetDataFromDB(string sqlCommand) // funkcija koja preko parametra sqlCommand dobija instrukcije za upit bazi i vraca objekat DataSet klase 
        {      
            using (SQLiteConnection conn = new SQLiteConnection(CS))
            {
                conn.Open();
                SQLiteDataAdapter DA = new SQLiteDataAdapter(sqlCommand, conn);
                conn.Close();
                DataSet DS = new DataSet();
                DA.Fill(DS);
                
                return DS;
            }

        }

        public void InsertDataToDB(string sqlCommand) // funkcija koja preko parametra dobija instrukcije za upis u bazu
        {
            using (SQLiteConnection conn = new SQLiteConnection(CS))
            {
                SQLiteCommand cmd = new SQLiteCommand(sqlCommand, conn);
                conn.Open();
                cmd.ExecuteReader();
                conn.Close();

            }
        }
        public void UpdateDataFromDB(string sqlCommand) //funkcija za izmenu podataka iz baze 
        {
            using (SQLiteConnection conn = new SQLiteConnection(CS))
            {
                SQLiteCommand cmd = new SQLiteCommand(sqlCommand, conn);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();

            }
        }
        public void DeleteDataFromDB(string sqlCommand) // funkcija za brisanje iz baze
        {
            UpdateDataFromDB(sqlCommand);
        }
    }
}
