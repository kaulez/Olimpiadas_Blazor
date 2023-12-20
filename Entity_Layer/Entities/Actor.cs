using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity_Layer.Entities
{
    //Considero tener una tabla generica Actor para los distintos tipos de personaas, comisiarios participantes etc.
    public class Actor
    {
        public int Id { get; set; } 
        public int ActivityId { get; set; }
        public string Name { get; set; }
        public string Task { get; set; }
        public int State { get; set; }

    }
}
