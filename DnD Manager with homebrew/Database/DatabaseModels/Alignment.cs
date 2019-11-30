using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnD_Manager.Database.DatabaseModels
{
    class Alignment: DatabaseObject
    {
        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }

        public override int Insert()
        {
            using (var sqlite = DBConnector.GetConnection())
            {
                using (SQLiteCommand objCommand = sqlite.CreateCommand())
                {
                    sqlite.Open();
                    objCommand.CommandText = "INSERT INTO Alignment (name, description) VALUES (@name, @description)";
                    objCommand.Prepare();

                    objCommand.Parameters.AddWithValue("@name", name);
                    objCommand.Parameters.AddWithValue("@description", description);
                    int result = objCommand.ExecuteNonQuery();
                    sqlite.Close();
                    return result;
                }
            }
        }

        public override bool Load(int id)
        {
            using (var sqlite = DBConnector.GetConnection())
            {
                using (SQLiteCommand objCommand = sqlite.CreateCommand())
                {
                    sqlite.Open();
                    objCommand.CommandText = "SELECT * FROM Alignment WHERE id = @id";
                    objCommand.Prepare();

                    objCommand.Parameters.AddWithValue("@id", id);
                    objCommand.CommandType = CommandType.Text;
                    try
                    {
                        SQLiteDataReader r = objCommand.ExecuteReader();
                        while (r.Read())
                        {
                            this.id = Convert.ToInt32(r["id"]);
                            name = r["name"].ToString();
                            description = r["description"].ToString();
                        }
                        sqlite.Close();
                        return true;
                    }
                    catch (SQLiteException e)
                    {
                        return false;
                    }
                }
            }
        }
    }
}
