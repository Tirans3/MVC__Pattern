using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace MvcCar.Models
{
    public class MvcCarContext : DbContext
    {
        public MvcCarContext (DbContextOptions<MvcCarContext> options)
            : base(options)
        {
        }

        public DbSet<MvcCar.Models.Car> Car { get; set; }
    }
}
