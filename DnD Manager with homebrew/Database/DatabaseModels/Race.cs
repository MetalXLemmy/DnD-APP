using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnD_Manager.Database.DatabaseModels
{
    class Race: DatabaseObject
    {
        public int id { get; set; }
        public string name { get; set; }
        public string shortDescription { get; set; }
        public string description { get; set; }
        public decimal age { get; set; }
        public int speed { get; set; }
        public int alignmentId { get; set; }
        public int sizeId { get; set; }
        public int variantId { get; set; }

        public override int Insert()
        {
            using (var sqlite = DBConnector.GetConnection())
            {
                using (SQLiteCommand objCommand = sqlite.CreateCommand())
                {
                    sqlite.Open();
                    objCommand.CommandText = "INSERT INTO Size (name, shortDescription, description, age, speed, alignmentId, sizeId, variantId) VALUES (@name, @shortDescription, @description, @age, @speed, @alignmentId, @sizeId, @variantId)";
                    objCommand.Prepare();

                    objCommand.Parameters.AddWithValue("@name", name);
                    objCommand.Parameters.AddWithValue("@shortDescription", shortDescription);
                    objCommand.Parameters.AddWithValue("@description", description);
                    objCommand.Parameters.AddWithValue("@age", age);
                    objCommand.Parameters.AddWithValue("@speed", speed);
                    objCommand.Parameters.AddWithValue("@alignmentId", alignmentId);
                    objCommand.Parameters.AddWithValue("@sizeId", sizeId);
                    objCommand.Parameters.AddWithValue("@variantId", variantId);
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
                            shortDescription = r["shortDescription"].ToString();
                            description = r["description"].ToString();
                            age = Convert.ToDecimal(r["age"]);
                            speed = Convert.ToInt32(r["speed"]);
                            alignmentId = Convert.ToInt32(r["alignmentId"]);
                            sizeId = Convert.ToInt32(r["sizeId"]);
                            variantId = Convert.ToInt32(r["variantId"]);
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
