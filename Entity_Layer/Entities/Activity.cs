using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity_Layer.Entities
{
    public class Activity
    {
        public int Id { get; set; } 
        public int SportComplexId { get; set; } 
        public int Name { get; set;}
        public DateTime Date { get; set; }
        public TimeSpan Duration { get; set; }
        public int ParticipantsNumber {  get; set; }
        public int Type { get; set; }
        public List<Actor> Actors { get; set; }
        public List<Equipment> Equipments { get; set; }
        public int State { get; set; }
    }
}
