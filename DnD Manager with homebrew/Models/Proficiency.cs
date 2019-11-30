using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnD_Manager.Models
{
    class Proficiency: ModelObject
    {
        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public int primaryProficiencyId { get; set; }
        public int linkedId { get; set; }
        public string linkedType { get; set; }

        public override int Insert()
        {
            Database.DatabaseModels.Proficiency proficiency = new Database.DatabaseModels.Proficiency();
            proficiency.name = name;
            proficiency.description = description;
            proficiency.primaryProficiencyId = primaryProficiencyId;
            proficiency.linkedId = linkedId;
            proficiency.category = linkedType;
            return proficiency.Insert();
        }
        public override bool Load(int id)
        {
            Database.DatabaseModels.Proficiency proficiency = new Database.DatabaseModels.Proficiency();
            bool charLoad = proficiency.Load(id);
            name = proficiency.name;
            this.id = proficiency.id;
            description = proficiency.description;
            primaryProficiencyId = proficiency.primaryProficiencyId;
            linkedId = proficiency.linkedId;
            linkedType = proficiency.category;
            return charLoad;
        }
    }
}
