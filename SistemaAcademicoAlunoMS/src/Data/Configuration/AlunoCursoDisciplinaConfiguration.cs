using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using SistemaAcademicoAlunoMS.src.Domain.Entities;

namespace SistemaAcademicoAlunoMS.src.Data.Configuration;

public class AlunoCursoDisciplinaConfiguration : IEntityTypeConfiguration<AlunoCursoDisciplina>
{
    public void Configure(EntityTypeBuilder<AlunoCursoDisciplina> builder)
    {
        builder.ToTable("Aluno_Curso_Discplina");

        builder.HasKey(ac => new {ac.AlunoId, ac.DisciplinaId, ac.CursoId});

        builder.Property(ac => ac.MediaFinal)
               .HasColumnType("Decimal(10,2)");

        builder.Property(ac => ac.DataInicio)
               .IsRequired()
               .HasColumnType("Date");

        builder.Property(ac => ac.DataFim)
               .IsRequired()
               .HasColumnType("Date");

        builder.Property(ac => ac.Status)
               .IsRequired()
               .HasMaxLength(100);

        builder.HasOne(ac => ac.Aluno)
               .WithMany(a => a.Disciplinas)
               .HasForeignKey(ac => ac.AlunoId)
               .OnDelete(DeleteBehavior.Restrict);

    }
}