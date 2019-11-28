using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnD_Manager.Database.DatabaseModels
{
    abstract class LinkedDatabaseObject
    {
        public abstract int Insert();
        public abstract bool Load(int id1, int id2);
    }
}
