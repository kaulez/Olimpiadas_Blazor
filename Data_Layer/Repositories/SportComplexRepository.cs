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
    public  class SportComplexRepository : ISportComplexRepository
    {
        private readonly ApplicationContext _context;

        public SportComplexRepository(ApplicationContext context)
        {
            _context = context;
        }
        public async Task CreateSportComplex(SportComplex sportComplex)
        {
            _context.Add(sportComplex);
            await _context.SaveChangesAsync();
        }
        /// <summary>Solo cambiamos de estado, por un tema de persistencia de datos.
        /// </summary>
        public async Task UnsuscribeSportComplex(int idSportComplex)
        {
            var sportComplex = await _context.SportComplexes.Where(c => c.Id == idSportComplex).FirstAsync();
            sportComplex.State = Convert.ToInt32(StateRegistration.Unsuscribe);
            _context.Entry(sportComplex).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
        public async Task EditSportComplex(SportComplex sportcomplex)
        {
            var sportComplexBd = await _context.SportComplexes.Where(c => c.Id == sportcomplex.Id).FirstAsync();
            sportComplexBd.Type= sportcomplex.Type;
            sportComplexBd.Localization = sportcomplex.Localization;
            sportComplexBd.OrganizationManager= sportcomplex.OrganizationManager;
            sportComplexBd.TotalOccupiedArea= sportcomplex.TotalOccupiedArea;
            await _context.SaveChangesAsync();
        }
    }
}
