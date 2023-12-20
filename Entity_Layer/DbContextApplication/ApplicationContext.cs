using Entity_Layer.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity_Layer.DbContextApplication
{
    public class ApplicationContext: DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }
        public DbSet<Activity> Activities { get; set; }
        public DbSet<Actor> Actors { get; set; }
        public DbSet<Campus> Campuses { get; set; }
        public DbSet<Equipment> Equipments { get; set; }
        public DbSet<SportComplex> SportComplexes { get; set; }

         

    }
}
