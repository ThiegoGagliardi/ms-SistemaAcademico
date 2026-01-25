using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using SistemaAcademicoProfessorMS.src.Domain.Entities;

namespace SistemaAcademicoProfessorMS.src.Data.Configuration;

public class ProfessorTituloConfiguration : IEntityTypeConfiguration<ProfessorTitulo>
{
    public void Configure(EntityTypeBuilder<ProfessorTitulo> builder)
    {
        builder.ToTable("Professores_Titulos");

        builder.HasKey(pf => new{pf.ProfessorId, pf.TitulosId} );

        builder.Property(pf => pf.Inicio)
               .IsRequired()
               .HasColumnType("Date");

        builder.Property(pf => pf.Termino)
               .IsRequired()
               .HasColumnType("Date");

        builder.HasOne(pf => pf.Professor)
               .WithMany(p => p.Titulos)
               .HasForeignKey(pf => pf.ProfessorId)
               .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(pf => pf.Titulo)
               .WithMany(p => p.Professores)
               .HasForeignKey(pf => pf.TitulosId)
               .OnDelete(DeleteBehavior.Restrict);               
    }
}