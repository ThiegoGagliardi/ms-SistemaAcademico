using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using SistemaAcademicoProfessorMS.src.Domain.Entities;

namespace SistemaAcademicoProfessorMS.src.Data.Configuration;

public class AtribuicaoAulaConfiguration : IEntityTypeConfiguration<AtribuicaoAula>
{
    public void Configure(EntityTypeBuilder<AtribuicaoAula> builder)
    {
       builder.ToTable("Atribuicao_Aula");

       builder.HasKey(a => new {a.CursoId, a.DisciplinaId, a.ProfessorId, a.HoraInicio});

       builder.Property(a => a.Dia)
              .HasMaxLength(100);

        builder.Property(a => a.HoraInicio)
               .HasColumnName("Hora_Inicio")
               .HasColumnType("time")
               .IsRequired();

        builder.Property(a => a.HoraFim)
               .HasColumnName("Hora_Fim")
               .HasColumnType("time")
               .IsRequired();

        builder.Property(a => a.Duracao)
               .HasColumnName("Duracao")
               .HasColumnType("time")
               .IsRequired();                             


        builder.HasOne(a => a.Professor)
               .WithMany(p => p.Aulas)
               .HasForeignKey(a => a.ProfessorId)
               .OnDelete(DeleteBehavior.Restrict);                            
    }
}