using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Olimpiadas.Shared.ViewModels
{
    public class SportComplexViewModel
    {
        public int Id { get; set; }
        public int CampusId { get; set; }
        public int Type { get; set; }
        public string Localization { get; set; }
        public string OrganizationManager { get; set; }
        public double TotalOccupiedArea { get; set; }
        public int State { get; set; }
        public string TypeString { get;set; }

    }
}
