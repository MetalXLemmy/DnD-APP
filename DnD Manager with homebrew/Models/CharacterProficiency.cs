using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnD_Manager.Models
{
    class CharacterProficiency: Proficiency
    {
        public int charId { get; set; }
        public int proficiencyId { get; set; }
        public int proficiencyLevel { get; set; }
        public int passiveValue { get; set; }

        public override int Insert()
        {
            Database.DatabaseModels.CharacterProficiency proficiency = new Database.DatabaseModels.CharacterProficiency();
            proficiency.charId = charId;
            proficiency.proficiencyId = proficiencyId;
            proficiency.proficiencyLevel = proficiencyLevel;
            proficiency.passiveValue = passiveValue;
            return proficiency.Insert();
        }
        public override bool Load(int id)
        {
            return base.Load(id);
        }

        public static List<CharacterProficiency> LoadByCharacterId(int charId)
        {
            List<Database.DatabaseModels.CharacterProficiency> list = Database.DatabaseModels.CharacterProficiency.LoadByCharacterId(charId);
            List<CharacterProficiency> characterProficiencies = new List<CharacterProficiency>();
            foreach(Database.DatabaseModels.CharacterProficiency characterProficiency in list)
            {
                // Convert DB model to Model
                CharacterProficiency newProf = Convert(characterProficiency);

                // Get Proficiency data and add it to Model
                newProf.Load(characterProficiency.proficiencyId);

                characterProficiencies.Add(newProf);
            }
            return characterProficiencies;
        }

        public static CharacterProficiency Convert(Database.DatabaseModels.CharacterProficiency dbCharacterProficiency)
        {
            CharacterProficiency charProf = new CharacterProficiency();
            charProf.charId = dbCharacterProficiency.charId;
            charProf.proficiencyId = dbCharacterProficiency.proficiencyId;
            charProf.proficiencyLevel = dbCharacterProficiency.proficiencyLevel;
            charProf.passiveValue = dbCharacterProficiency.passiveValue;
            return charProf;
        }
    }
}
