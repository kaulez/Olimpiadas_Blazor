using Olimpiadas.Shared.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic_Layer.Interfaces
{
    public interface ICampusLogic
    {
        Task<List<CampusViewModel>> GetAllCampuses();
        Task UnsuscribeCampus(int idCampus);
        Task CreateCampus(CampusViewModel campus);
        Task EditCampus(CampusViewModel campus);
        Task<CampusViewModel> GetCampusById(int idCampus);
    }
}
