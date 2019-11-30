using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnD_Manager.Models
{
    class Race: ModelObject
    {
        public int id { get; set; }
        public string name { get; set; }
        public string shortDescription { get; set; }
        public string description { get; set; }
        public decimal age { get; set; }
        public int speed { get; set; }
        public Alignment alignment { get; set; }
        public Size size { get; set; }
        public Race variantOf { get; set; }

        public override int Insert()
        {
            Database.DatabaseModels.Race race = new Database.DatabaseModels.Race
            {
                name = name,
                shortDescription = shortDescription,
                description = description,
                age = age,
                speed = speed,
                alignmentId = alignment.id,
                sizeId = size.id,
                variantId = variantOf.id,
            };
            return race.Insert();
        }
        public override bool Load(int id)
        {
            Database.DatabaseModels.Race race = new Database.DatabaseModels.Race();
            bool hasLoaded = race.Load(id);
            this.id = race.id;
            name = race.name;
            shortDescription = race.shortDescription;
            description = race.description;
            age = race.age;
            speed = race.speed;
            Alignment alignment1 = new Alignment();
            alignment1.Load(race.alignmentId);
            alignment = alignment1;
            Size size1 = new Size();
            size1.Load(race.sizeId);
            size = size1;
            Race race1 = new Race();
            race1.Load(race.variantId);
            this.variantOf = race1;
            return hasLoaded;
        }
    }
}
