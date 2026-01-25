using Microsoft.EntityFrameworkCore;

using SistemaAcademicoProfessorMS.src.Domain.Entities;
using SistemaAcademicoProfessorMS.src.Data.Configuration;

namespace SistemaAcademicoProfessorMS.src.Data;

public class ProfessorDbContext : DbContext
{
    public DbSet<Professor> Professores { get; set; }

    public DbSet<Titulo> Titulos { get; set; }

    public DbSet<AtribuicaoAula> AtribuicaoAulas { get; set; }       

    public ProfessorDbContext(DbContextOptions<ProfessorDbContext> options) : base(options)
    { }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfiguration(new ProfessorConfiguration());
        builder.ApplyConfiguration(new TitulosConfiguration());           
        builder.ApplyConfiguration(new ProfessorTituloConfiguration());
        builder.ApplyConfiguration(new AtribuicaoAulaConfiguration());           
    }
}