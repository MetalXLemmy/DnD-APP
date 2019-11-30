using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnD_Manager.Database.DatabaseModels
{
    class CharacterRace: LinkedDatabaseObject
    {
        public int charId { get; set; }
        public int raceId { get; set; }

        public override int Insert()
        {
            using (var sqlite = DBConnector.GetConnection())
            {
                using (SQLiteCommand objCommand = sqlite.CreateCommand())
                {
                    sqlite.Open();
                    objCommand.CommandText = "INSERT INTO CharacterRace (charId, raceId) VALUES (@charId, @raceId)";
                    objCommand.Prepare();

                    objCommand.Parameters.AddWithValue("@charId", charId);
                    objCommand.Parameters.AddWithValue("@raceId", raceId);
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
                    objCommand.CommandText = "SELECT * FROM CharacterRace WHERE charId = @id1 AND raceId = @id2";
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
                            raceId = Convert.ToInt32(r["raceId"]);
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

        public static List<CharacterRace> LoadByCharacterId(int charId)
        {
            List<CharacterRace> list = new List<CharacterRace>();
            using (var sqlite = DBConnector.GetConnection())
            {
                using (SQLiteCommand objCommand = sqlite.CreateCommand())
                {
                    sqlite.Open();
                    objCommand.CommandText = "SELECT * FROM CharacterRace WHERE charId = @id1";
                    objCommand.Prepare();

                    objCommand.Parameters.AddWithValue("@id1", charId);
                    objCommand.CommandType = CommandType.Text;
                    try
                    {
                        SQLiteDataReader r = objCommand.ExecuteReader();
                        while (r.Read())
                        {
                            CharacterRace charProf = new CharacterRace();
                            charProf.charId = Convert.ToInt32(r["charId"]);
                            charProf.raceId = Convert.ToInt32(r["raceId"]);
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
