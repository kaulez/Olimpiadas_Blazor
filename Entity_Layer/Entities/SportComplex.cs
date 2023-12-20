using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity_Layer.Entities
{
    //Complejo deportivo, considere oportuno tener una sola tabla para para polideportivo y unico, para no tener muchas tablas si los campos variaran mucho se crearia otra tabla, pero como no hay detalles de cada tabla se considero asi.
    public  class SportComplex
    {
        public int Id {  get; set; }
        public int CampusId { get; set; }   
        public int Type { get; set; }   
        public string Localization { get; set; }
        public string OrganizationManager { get; set; }
        public double TotalOccupiedArea { get; set; }
        public List<Activity> Activities { get; set; }
        public int State { get; set; }

    }
}
