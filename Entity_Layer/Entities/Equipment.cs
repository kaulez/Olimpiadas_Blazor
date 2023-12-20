using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity_Layer.Entities
{
    public class Equipment
    {
        public int Id { get; set; } 
        public int ActivityId { get; set; }
        public string Name { get; set; }
        public int State { get; set; }

    }
}
