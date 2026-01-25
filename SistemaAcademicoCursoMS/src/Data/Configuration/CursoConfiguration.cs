using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using SistemaAcademicoCursoMS.src.Domain.Entities;

namespace SistemaAcademicoCursoMS.src.Data.Configuration;

public class CursoConfiguration : IEntityTypeConfiguration<Curso>
{
    public void Configure (EntityTypeBuilder<Curso> builder)
    {
        builder.ToTable("Cursos");

        builder.HasKey(c => c.Id);

        builder.Property(c => c.Nome)
               .IsRequired()
               .HasMaxLength(100);

        builder.Property(c => c.Descricao)
               .HasMaxLength(100);

        builder.Property(c => c.AreaConhecimento)
               .HasColumnName("Area_Conhecimento")
               .HasMaxLength(100);            

    }
}
