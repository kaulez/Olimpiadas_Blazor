using Entity_Layer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Layer.Interfaces
{
    public interface ICampusRepository
    {
        Task<List<Campus>> GetAllCampuses();
        Task<Campus> GetCampusById(int campusId);
        Task UnsuscribeCampus(int idCampus);
        Task CreateCampus(Campus campus);
        Task EditCampus(Campus campusEdit);
    }

}
