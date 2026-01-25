using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using SistemaAcademicoCursoMS.src.Domain.Entities;

namespace SistemaAcademicoCursoMS.src.Data.Configuration;

public class FormacaoConfiguration : IEntityTypeConfiguration<Formacao>
{
    public void Configure(EntityTypeBuilder<Formacao> builder)
    {
        builder.ToTable("Formacoes");

        builder.HasKey(f => f.Id);

        builder.Property(f => f.Nome)
               .IsRequired()
               .HasMaxLength(100);
                             
        builder.Property(f => f.Nivel)
               .IsRequired()
               .HasMaxLength(100);

        builder.Property(f => f.AreaConhecimento)
               .HasColumnName("Area_Conhecimento")
               .IsRequired()
               .HasMaxLength(100);

        builder.HasMany(d => d.Disciplinas)
               .WithMany(f => f.Formacoes)
               .UsingEntity(j => j.ToTable("DisciplinasFormacoes"));                             
    }
}