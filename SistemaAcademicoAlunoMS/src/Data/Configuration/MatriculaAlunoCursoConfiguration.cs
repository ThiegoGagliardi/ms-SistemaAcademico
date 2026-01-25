using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using SistemaAcademicoAlunoMS.src.Domain.Entities;

namespace SistemaAcademicoAlunoMS.src.Data.Configuration;

public class MatriculaAlunoCursoConfiguration : IEntityTypeConfiguration<MatriculaAlunoCurso>
{

    public void Configure(EntityTypeBuilder<MatriculaAlunoCurso> builder)
    {
        builder.ToTable("Matricula_Aluno_Curso");

        builder.HasKey(m => new {m.AlunoId, m.CursoId});

        builder.Property(m => m.DataInicio)
               .IsRequired()
               .HasColumnType("Date");

        builder.Property(m => m.DataFim)
               .IsRequired()
               .HasColumnType("Date");

        builder.HasOne(m => m.Aluno)
               .WithMany(a => a.Matriculas)
               .HasForeignKey(m => m.AlunoId)
               .OnDelete(DeleteBehavior.Restrict);            
    }
}