using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnD_Manager.Database
{
    public class DBConnector
    {
        static string DBString = "DndManagerDatabase.sqlite";
        public bool SetupDB()
        {
            try
            {
                if (!File.Exists("./" + DBString))
                {
                    // Create the database file
                    SQLiteConnection.CreateFile(DBString);

                    using (var sqlite = GetConnection())
                    {
                        // Execute the setup
                        string strCommand = File.ReadAllText("DatabaseSetup.sql");
                        using (SQLiteCommand objCommand = sqlite.CreateCommand())
                        {
                            sqlite.Open();
                            objCommand.CommandText = strCommand;
                            objCommand.ExecuteNonQuery();
                            sqlite.Close();
                        }
                    }
                }
            }
            catch(Exception e)
            {
                return false;
            }
            return true;
        }

        public static SQLiteConnection GetConnection()
        {
            return new SQLiteConnection("Data Source=" + DBString);
        }
    }
}
