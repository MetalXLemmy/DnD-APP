using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnD_Manager.Models
{
    class CharacterRace: Race
    {
        public int charId { get; set; }
        public int raceId { get; set; }

        public override int Insert()
        {
            Database.DatabaseModels.CharacterRace proficiency = new Database.DatabaseModels.CharacterRace();
            proficiency.charId = charId;
            proficiency.raceId = raceId;
            return proficiency.Insert();
        }
        public override bool Load(int id)
        {
            return base.Load(id);
        }

        public static List<CharacterRace> LoadByCharacterId(int charId)
        {
            List<Database.DatabaseModels.CharacterRace> list = Database.DatabaseModels.CharacterRace.LoadByCharacterId(charId);
            List<CharacterRace> characterRaces = new List<CharacterRace>();
            foreach(Database.DatabaseModels.CharacterRace characterRace in list)
            {
                // Convert DB model to Model
                CharacterRace newRace = Convert(characterRace);
                newRace.Load(characterRace.raceId);

                characterRaces.Add(newRace);
            }
            return characterRaces;
        }

        public static CharacterRace Convert(Database.DatabaseModels.CharacterRace dbCharacterProficiency)
        {
            CharacterRace charProf = new CharacterRace();
            charProf.charId = dbCharacterProficiency.charId;
            charProf.raceId = dbCharacterProficiency.raceId;
            return charProf;
        }
    }
}
