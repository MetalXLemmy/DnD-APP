using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnD_Manager.Database.DatabaseModels
{
    class CharacterProficiency: LinkedDatabaseObject
    {
        public int charId { get; set; }
        public int proficiencyId { get; set; }
        public int proficiencyLevel { get; set; }
        public int passiveValue { get; set; }

        public override int Insert()
        {
            using (var sqlite = DBConnector.GetConnection())
            {
                using (SQLiteCommand objCommand = sqlite.CreateCommand())
                {
                    sqlite.Open();
                    objCommand.CommandText = "INSERT INTO CharacterProficiency (charId, proficiencyId, proficiencyLevel, passiveValue) VALUES (@charId, @proficiencyId, @proficiencyLevel, @passiveValue)";
                    objCommand.Prepare();

                    objCommand.Parameters.AddWithValue("@charId", charId);
                    objCommand.Parameters.AddWithValue("@proficiencyId", proficiencyId);
                    objCommand.Parameters.AddWithValue("@proficiencyLevel", proficiencyLevel);
                    objCommand.Parameters.AddWithValue("@passiveValue", passiveValue);
                    int result = objCommand.ExecuteNonQuery();
                    sqlite.Close();
                    return result;
                }
            }
        }
        public override bool Load(int id1, int id2)
        {
            using (var sqlite = DBConnector.GetConnection())
            {
                using (SQLiteCommand objCommand = sqlite.CreateCommand())
                {
                    sqlite.Open();
                    objCommand.CommandText = "SELECT * FROM Character WHERE charId = @id1 AND proficiencyId = @id2";
                    objCommand.Prepare();

                    objCommand.Parameters.AddWithValue("@id1", id1);
                    objCommand.Parameters.AddWithValue("@id2", id2);
                    objCommand.CommandType = CommandType.Text;
                    try
                    {
                        SQLiteDataReader r = objCommand.ExecuteReader();
                        while (r.Read())
                        {
                            charId = Convert.ToInt32(r["charId"]);
                            proficiencyId = Convert.ToInt32(r["proficiencyId"]);
                            proficiencyLevel = Convert.ToInt32(r["proficiencyLevel"]);
                            passiveValue = Convert.ToInt32(r["passiveValue"]);
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

        public static List<CharacterProficiency> LoadByCharacterId(int charId)
        {
            List<CharacterProficiency> list = new List<CharacterProficiency>();
            using (var sqlite = DBConnector.GetConnection())
            {
                using (SQLiteCommand objCommand = sqlite.CreateCommand())
                {
                    sqlite.Open();
                    objCommand.CommandText = "SELECT * FROM Character WHERE charId = @id1";
                    objCommand.Prepare();

                    objCommand.Parameters.AddWithValue("@id1", charId);
                    objCommand.CommandType = CommandType.Text;
                    try
                    {
                        SQLiteDataReader r = objCommand.ExecuteReader();
                        while (r.Read())
                        {
                            CharacterProficiency charProf = new CharacterProficiency();
                            charProf.charId = Convert.ToInt32(r["charId"]);
                            charProf.proficiencyId = Convert.ToInt32(r["proficiencyId"]);
                            charProf.proficiencyLevel = Convert.ToInt32(r["proficiencyLevel"]);
                            charProf.passiveValue = Convert.ToInt32(r["passiveValue"]);
                            list.Add(charProf);
                        }
                        sqlite.Close();
                        return list;
                    }
                    catch (SQLiteException e)
                    {
                        return list;
                    }
                }
            }
        }
    }
}
