using Microsoft.EntityFrameworkCore;

using SistemaAcademicoAlunoMS.src.Domain.Entities;
using SistemaAcademicoAlunoMS.src.Data.Configuration;

namespace SistemaAcademicoAlunoMS.src.Data;

public class AlunoDbContext : DbContext
{

    public DbSet<Aluno> Alunos { get; set; }

    public DbSet<AlunoCursoDisciplinaNota> Notas { get; set;}  
     
    public DbSet<AlunoCursoDisciplina> Medias { get; set;}  

    public AlunoDbContext(DbContextOptions<AlunoDbContext> options) : base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {       
        
        builder.ApplyConfiguration(new AlunoConfiguration());      
        builder.ApplyConfiguration(new MatriculaAlunoCursoConfiguration());
        builder.ApplyConfiguration(new AlunoCursoDisciplinaConfiguration());
        builder.ApplyConfiguration(new AlunoCursoDisciplinaNotaConfiguration());
    }
}
