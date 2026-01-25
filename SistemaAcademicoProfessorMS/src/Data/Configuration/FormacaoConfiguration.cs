using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using SistemaAcademicoProfessorMS.src.Domain.Entities;

namespace SistemaAcademicoProfessorMS.src.Data.Configuration;

public class TitulosConfiguration : IEntityTypeConfiguration<Titulo>
{
    public void Configure(EntityTypeBuilder<Titulo> builder)
    {
        builder.ToTable("Titulos");

        builder.HasKey(f => f.Id);

        builder.Property(f => f.Nome)
               .IsRequired()
               .HasMaxLength(100);

        builder.Property(f => f.Instituicao)
               .IsRequired()
               .HasMaxLength(100);
                              
        builder.Property(f => f.Nivel)
               .IsRequired()
               .HasMaxLength(100);

        builder.Property(f => f.ValorPontuacao)
               .HasColumnName("Valor_Pontuacao")
               .HasColumnType("decimal(12,4)")
               .IsRequired();

        builder.Property(f => f.AreaConhecimento)
               .HasColumnName("Area_Conhecimento")
               .IsRequired()
               .HasMaxLength(100);                          
    }
}