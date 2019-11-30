using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnD_Manager.Models
{
    class Alignment: ModelObject
    {
        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }

        public override int Insert()
        {
            Database.DatabaseModels.Alignment alignment = new Database.DatabaseModels.Alignment
            {
                name = name,
                description = description
            };
            return alignment.Insert();
        }
        public override bool Load(int id)
        {
            Database.DatabaseModels.Alignment alignment = new Database.DatabaseModels.Alignment();
            bool hasLoaded = alignment.Load(id);
            this.id = alignment.id;
            name = alignment.name;
            description = alignment.description;
            return hasLoaded;
        }
    }
}
