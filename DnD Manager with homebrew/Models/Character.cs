using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnD_Manager.Models
{
    class Character: ModelObject
    {
        public int id { get; set; }
        public string name { get; set; }
        public int currentHealth { get; set; }
        public int maxHealth { get; set; }
        public int currentXP { get; set; }
        public string background { get; set; }
        public string gender { get; set; }
        public List<CharacterProficiency> proficiencies { get; set; }

        public override int Insert()
        {
            Database.DatabaseModels.Character character = new Database.DatabaseModels.Character();
            character.name = name;
            character.currentHealth = currentHealth;
            character.maxHealth = maxHealth;
            character.currentXP = currentXP;
            character.background = background;
            character.gender = gender;
            return character.Insert();
        }
        public override bool Load(int id)
        {
            Database.DatabaseModels.Character character = new Database.DatabaseModels.Character();
            bool charLoad = character.Load(id);
            this.id = character.id;
            name = character.name;
            currentHealth = character.currentHealth;
            maxHealth = character.maxHealth;
            currentXP = character.currentXP;
            background = character.background;
            gender = character.gender;
            proficiencies = CharacterProficiency.LoadByCharacterId(id);
            return charLoad;
        }
    }
}
