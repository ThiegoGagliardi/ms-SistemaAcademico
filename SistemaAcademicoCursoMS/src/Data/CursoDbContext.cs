using Microsoft.EntityFrameworkCore;

using SistemaAcademicoCursoMS.src.Domain.Entities;
using SistemaAcademicoCursoMS.src.Data.Configuration;

namespace SistemaAcademicoCursoMS.src.Data;

public class CursoDbContext : DbContext
{
    public DbSet<Curso> Cursos { get; set; }

    public DbSet<Disciplina> Disciplinas { get; set; }

    public DbSet<Formacao> Formacoes { get; set; }
    
    public DbSet<GradeHoraria> GradeHoraria { get; set; }


    public CursoDbContext(DbContextOptions options) : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfiguration(new DisciplinaConfiguration());
        builder.ApplyConfiguration(new CursoConfiguration());
        builder.ApplyConfiguration(new FormacaoConfiguration());
        
        builder.ApplyConfiguration(new CursoDisciplinaConfiguration());
        builder.ApplyConfiguration(new GradeHorariaConfiguration());
    }
}