using System;

namespace DnD_Equip_screen
{
    internal class Character
    {
        

        public decimal STR { get; set; }
        public decimal DEX { get; set; }
        public decimal CON { get; set; }
        public decimal INT { get; set; }
        public decimal WIS { get; set; }
        public decimal CHA { get; set; }
        public decimal ProficiencyValue { get; set; } = 5;
        public bool STRproficiency { get; set; }
        public bool DEXproficiency { get; set; }
        public bool CONproficiency { get; set; }
        public bool INTproficiency { get; set; }
        public bool WISproficiency { get; set; }
        public bool CHAproficiency { get; set; }
        private string _CharacterName;
        public bool isFemale { get; set; }
        public bool isLeftHanded { get; set; }

        private Tuple<string, bool>[] skillProficiencyList = new Tuple<string, bool>[18];
        private Tuple<string, bool>[] skillExpertiseList = new Tuple<string, bool>[18];

        public Character()
        {
            string[] skillNameList = new string[18] { 
                "Athletics", "Acrobatics", 
                "Sleight of Hand", "Stealth", 
                "Arcana", "History", 
                "Investigation", "Nature", 
                "Religion", "Animal Handling", 
                "Insight", "Medicine", 
                "Perception", "Survival", 
                "Deception", "Intimidation", 
                "Performance", "Persuasion" };

            for (int i = 0; i < skillNameList.Length; i++)
            {
                skillProficiencyList[i] = new Tuple<string, bool>(skillNameList[i], false);
                skillExpertiseList[i] = new Tuple<string, bool>(skillNameList[i], false);
            }
        }

        public string CharacterName
        {
            get { return _CharacterName; }
            set { _CharacterName = value; }
        }

        public decimal getSTRmod()
        {
            decimal result = -6;

            if (STR > 0)
            {
                result = Math.Floor(STR / 2) - 5;
                if (STRproficiency) result += ProficiencyValue;
            }

            return result;
        }

        public decimal getDEXmod()
        {
            decimal result = -6;

            if (DEX == 0)
            {
                result = Math.Floor(DEX / 2) - 5;
                if (DEXproficiency) result += ProficiencyValue;
            }

            return result;
        }

        public decimal getCONmod()
        {
            decimal result = -6;

            if (CON == 0)
            {
                result = Math.Floor(CON / 2) - 5;
                if (CONproficiency) result += ProficiencyValue;
            }

            return result;
        }

        public decimal getINTmod()
        {
            decimal result = -6;

            if (INT == 0)
            {
                result = Math.Floor(INT / 2) - 5;
                if (INTproficiency) result += ProficiencyValue;
            }

            return result;
        }

        public decimal getWISmod()
        {
            decimal result = -6;

            if (WIS == 0)
            {
                result = Math.Floor(WIS / 2) - 5;
                if (WISproficiency) result += ProficiencyValue;
            }

            return result;
        }

        public decimal getCHAmod()
        {
            decimal result = -6;

            if (CHA == 0)
            {
                result = Math.Floor(CHA / 2) - 5;
                if (CONproficiency) result += ProficiencyValue;
            }

            return result;
        }
    }
}