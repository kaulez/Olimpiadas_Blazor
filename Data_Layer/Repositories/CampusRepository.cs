using Data_Layer.Enums;
using Data_Layer.Interfaces;
using Entity_Layer.DbContextApplication;
using Entity_Layer.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Layer.Repositories
{
    public class CampusRepository:ICampusRepository
    {
        private readonly ApplicationContext _context;

        public CampusRepository(ApplicationContext context)
        {
            _context = context;
        }
         public async Task<List<Campus>> GetAllCampuses()
        {
            return await _context.Campuses.Where(c=>c.State==Convert.ToInt32(StateRegistration.Active)).ToListAsync();
        }

        public async Task<Campus> GetCampusById(int campusId)
        {
            return await _context.Campuses.Where(c => c.Id == campusId)
                .Include(c => c.SportComplexes.Where(sc => sc.State == Convert.ToInt32(StateRegistration.Active)))
                .FirstAsync();
        }
        /// <summary>como es persistencia solo modelos de entidades
        /// </summary>
        public async Task EditCampus(Campus campusEdit)
        {
            var campusBd = await _context.Campuses.Where(c => c.Id == campusEdit.Id).FirstAsync();
            campusBd.Name = campusEdit.Name;    
            campusBd.ApproximateEstimation= campusEdit.ApproximateEstimation;
            await _context.SaveChangesAsync();
        }
        public async Task CreateCampus(Campus campus)
        {
            _context.Add(campus);
            await _context.SaveChangesAsync();
        }
        /// <summary>Solo cambiamos de estado, por un tema de persistencia de datos.
        /// </summary>
        public async Task UnsuscribeCampus(int idCampus)
        {
           var campus= await _context.Campuses.Where(c=>c.Id== idCampus).FirstAsync();
            campus.State= Convert.ToInt32(StateRegistration.Unsuscribe);
            _context.Entry(campus).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
