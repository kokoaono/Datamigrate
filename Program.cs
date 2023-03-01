using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Data.SQLite;
namespace HelloWorld
{
    class Program
    {
        public static SQLiteConnection sqlite;
        public Program()
        {
              //This part killed me in the beginning.  I was specifying "DataSource"
              //instead of "Data Source"
              sqlite = new SQLiteConnection("Data Source=Documents/Workspace/Datamigrate/omega.db");

        }
        static void Main(string[] args)
        {
            string connetionString;
            SqlConnection cnn;
            connetionString = @"Server=tcp:omega-sql.database.windows.net,1433;Initial Catalog=omega-sql;Persist Security Info=False;User ID=omega-sql-admin;Password=P@55w0rd!123;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
            cnn = new SqlConnection(connetionString);
            cnn.Open();
            Console.WriteLine("Connection Open  !");
            cnn.Close();

            SQLiteDataAdapter ad;
            DataTable dt = new DataTable();
            
            string query;
            query = "SELECT * FROM tableOne";
            sqlite = new SQLiteConnection("Data Source=Documents/Workspace/Datamigrate/omega.db");

            try
            {
                SQLiteCommand cmd;
                // Program.sqlite = new SQLiteConnection("Data Source=Documents/Workspace/Datamigrate/omega.db");
                sqlite.Open();  //Initiate connection to the db
                cmd = sqlite.CreateCommand();
                cmd.CommandText = query;  //set the passed query
                ad = new SQLiteDataAdapter(cmd);
                ad.Fill(dt); //fill the datasource
            }
            catch(SQLiteException ex)
            {
                //Add your exception code here.
                Console.WriteLine("error !" + ex.Message);
            
            }
            sqlite.Close();

            Console.WriteLine(dt.Rows.Count);
            //return dt;

        }
    }
}