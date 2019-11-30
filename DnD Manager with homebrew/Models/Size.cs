using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnD_Manager.Models
{
    class Size: ModelObject
    {
        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public int avgWidth { get; set; }
        public int avgHeight { get; set; }
        public decimal carryModifier { get; set; }

        public override int Insert()
        {
            Database.DatabaseModels.Size size = new Database.DatabaseModels.Size
            {
                name = name,
                description = description,
                avgWidth = avgWidth,
                avgHeight = avgHeight,
                carryModifier = carryModifier
            };
            return size.Insert();
        }
        public override bool Load(int id)
        {
            Database.DatabaseModels.Size size = new Database.DatabaseModels.Size();
            bool hasLoaded = size.Load(id);
            this.id = size.id;
            name = size.name;
            description = size.description;
            avgWidth = size.avgWidth;
            avgHeight = size.avgHeight;
            carryModifier = size.carryModifier;
            return hasLoaded;
        }
    }
}
