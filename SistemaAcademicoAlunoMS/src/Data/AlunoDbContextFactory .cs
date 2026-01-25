using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace SistemaAcademicoAlunoMS.src.Data;

public class AlunoDbContextFactory 
    : IDesignTimeDbContextFactory<AlunoDbContext>
{
    public AlunoDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<AlunoDbContext>();

        optionsBuilder.UseSqlServer(
            "Server=sqlserver-aluno-db,1433;Database=AlunoMsBd;User Id=sa;Password=S3nhA4luno.0;TrustServerCertificate=True"
        );

        return new AlunoDbContext(optionsBuilder.Options);
    }
}