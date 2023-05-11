using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using TestDB.Models;

namespace TestDB.DATA
{
    public class Data:DbContext
    {
        public DbSet<Patient> Patients { get; set; }
        public DbSet<CoronaDetails> CoronaDetails { get; set; }
        public DbSet<DetailVacsions> DetailVacsions { get; set; }
      //  public DbSet<CoronaPatient> CoronaPatients { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CoronaDetails>()
                .HasKey(e => e.id);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.\\SQLExpress;Database=DADABASE;Trusted_Connection=true;TrustServerCertificate=true");
        }

    }
}
