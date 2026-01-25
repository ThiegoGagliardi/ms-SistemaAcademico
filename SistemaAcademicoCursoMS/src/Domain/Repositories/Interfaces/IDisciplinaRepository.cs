using SistemaAcademicoCursoMS.src.Domain.Entities;
using SistemaAcademicoCursoMS.src.DTOs;

namespace SistemaAcademicoCursoMS.src.Domain.Repositories.Interfaces;

public interface IDisciplinaRepository : IRepository<Disciplina>
{    
    Task<IEnumerable<Disciplina>> GetByFormacaoAsync(Formacao formacao);

    Task<Disciplina> AddDisciplinaFormacaoAsync(DisciplinaFormacaoEnvioDTO disciplina);
}