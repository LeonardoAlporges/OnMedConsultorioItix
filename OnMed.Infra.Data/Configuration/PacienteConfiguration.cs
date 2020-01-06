using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnMed.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnMed.Infra.Data.Configuration
{
    public class PacienteConfiguration : IEntityTypeConfiguration<Paciente>
    {

        public void Configure(EntityTypeBuilder<Paciente> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Nome).HasMaxLength(100).IsRequired(true); 
            builder.Property(x => x.Nacimento).IsRequired(true); 
            builder.Property(x => x.DataConsultaInicial).IsRequired(true); 
            builder.Property(x => x.DataConsultaFinal).IsRequired(true); 
            builder.Property(x => x.Observacao).IsRequired(true); 
        }
    }
}
