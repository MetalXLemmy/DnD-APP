using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnD_Manager.Database.DatabaseModels
{
    class Character: DatabaseObject
    {
        public int id { get; set; }
        public string name { get; set; }
        public int currentHealth { get; set; }
        public int maxHealth { get; set; }
        public int currentXP { get; set; }
        public string background { get; set; }
        public string gender { get; set; }

        public override int Insert()
        {
            using (var sqlite = DBConnector.GetConnection())
            {
                using (SQLiteCommand objCommand = sqlite.CreateCommand())
                {
                    sqlite.Open();
                    objCommand.CommandText = "INSERT INTO Character (name, currentHealth, maxHealth, currentXP, background, gender) VALUES (@name, @currentHealth, @maxHealth, @currentXP, @background, @gender)";
                    objCommand.Prepare();

                    objCommand.Parameters.AddWithValue("@name", name);
                    objCommand.Parameters.AddWithValue("@currentHealth", currentHealth);
                    objCommand.Parameters.AddWithValue("@maxHealth", maxHealth);
                    objCommand.Parameters.AddWithValue("@currentXP", currentXP);
                    objCommand.Parameters.AddWithValue("@background", background);
                    objCommand.Parameters.AddWithValue("@gender", gender);
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
                    objCommand.CommandText = "SELECT * FROM Character WHERE id = @id";
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
                            currentHealth = Convert.ToInt32(r["currentHealth"]);
                            maxHealth = Convert.ToInt32(r["maxHealth"]);
                            currentXP = Convert.ToInt32(r["currentXP"]);
                            background = r["background"].ToString();
                            gender = r["gender"].ToString();
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
