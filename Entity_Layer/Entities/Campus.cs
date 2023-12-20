using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity_Layer.Entities
{
    public class Campus
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double ApproximateEstimation{ get; set; }
        public List<SportComplex> SportComplexes { get; set; }
        public int State { get; set; }

    }
}
