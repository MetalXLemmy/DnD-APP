using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnD_Manager.Models
{
    abstract class ModelObject
    {
        public abstract int Insert();
        public abstract bool Load(int id);
    }
}
