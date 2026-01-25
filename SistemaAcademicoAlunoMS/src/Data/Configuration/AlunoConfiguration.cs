using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using SistemaAcademicoAlunoMS.src.Domain.Entities;

namespace SistemaAcademicoAlunoMS.src.Data.Configuration;

public class AlunoConfiguration : IEntityTypeConfiguration<Aluno>
{
    public void Configure(EntityTypeBuilder<Aluno> builder)
    {
        builder.ToTable("Alunos");

        builder.HasKey(a => a.Id);

        builder.Property(a => a.Nome)
               .IsRequired()
               .HasMaxLength(100);

        builder.Property(a => a.RA)
               .IsRequired()
               .HasMaxLength(100);             
    }
}
