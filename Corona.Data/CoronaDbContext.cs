using Corona.Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Corona.Data
{
   public class CoronaDbContext: DbContext
    {
        public CoronaDbContext(DbContextOptions<CoronaDbContext> options) : base(options)
        {

        }

        public DbSet<Patient> Patients { get; set; }
        public DbSet<Hospital> Hospitals { get; set; }
        public DbSet<History> Histories { get; set; }
    }
}
