using Microsoft.EntityFrameworkCore;
using OnMed.Domain.Entity;
using OnMed.Infra.Data.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnMed.Infra.Data.Context
{
    public class OnMedContext : DbContext
    {
        public OnMedContext(DbContextOptions option) : base(option)
        {
        }

        public DbSet<Paciente> Paciente { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PacienteConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
