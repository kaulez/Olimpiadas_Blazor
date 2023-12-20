using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Olimpiadas.Shared.ViewModels
{
    public  class CampusViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double ApproximateEstimation { get; set; }
        public int State { get; set; }
        public List<SportComplexViewModel> SportComplexViewModels { get; set; } = new List<SportComplexViewModel>();

    }
}
