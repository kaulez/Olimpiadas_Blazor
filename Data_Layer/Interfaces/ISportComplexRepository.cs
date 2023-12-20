using Entity_Layer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Layer.Interfaces
{
    public interface ISportComplexRepository
    {
        Task CreateSportComplex(SportComplex sportComplex);
        Task UnsuscribeSportComplex(int idSportComplex);
        Task EditSportComplex(SportComplex sportcomplex);
    }
}
