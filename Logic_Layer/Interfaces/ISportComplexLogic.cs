using Olimpiadas.Shared.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic_Layer.Interfaces
{
    public interface ISportComplexLogic
    {
        Task CreateSportcomplex(SportComplexViewModel sportComplex);
        Task UnsuscribeSportComplex(int idSportComplex);
        Task EditSportComplex(SportComplexViewModel sportcomplex);
    }
}
