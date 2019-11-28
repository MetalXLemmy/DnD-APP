using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnD_Manager.Database.DatabaseModels
{
    class Proficiency: DatabaseObject
    {
        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public int primaryProficiencyId { get; set; }
        public int linkedId { get; set; }
        public string linkedType { get; set; }

        public override int Insert()
        {
            using (var sqlite = DBConnector.GetConnection())
            {
                using (SQLiteCommand objCommand = sqlite.CreateCommand())
                {
                    sqlite.Open();
                    objCommand.CommandText = "INSERT INTO Proficiency (name, description, primaryProficiencyId, linkedId, linkedType) VALUES (@name, @description, @primaryProficiencyId, @linkedId, @linkedType)";
                    objCommand.Prepare();

                    objCommand.Parameters.AddWithValue("@name", name);
                    objCommand.Parameters.AddWithValue("@description", description);
                    objCommand.Parameters.AddWithValue("@totalXp", primaryProficiencyId);
                    objCommand.Parameters.AddWithValue("@linkedId", linkedId);
                    objCommand.Parameters.AddWithValue("@linkedType", linkedType);
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
                            description = r["description"].ToString();
                            primaryProficiencyId = Convert.ToInt32(r["primaryProficiencyId"]);
                            linkedId = Convert.ToInt32(r["linkedId"]);
                            linkedType = r["linkedType"].ToString();
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
