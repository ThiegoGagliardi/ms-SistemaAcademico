using SistemaAcademicoCursoMS.Domain.Enums;
using SistemaAcademicoCursoMS.src.Domain.Entities;

namespace SistemaAcademicoCursoMS.src.Domain.Repositories.Interfaces;

public interface ICursoRepository : IRepository<Curso>
{
    Task<Curso> AdicionarDisciplinaCursoAsync(CursoDisciplina cursoDisciplina);

    Task<IEnumerable<Curso>> GetByNomeAsync(string nome);
     
    Task<IEnumerable<Curso>> GetByAreaConhecimentoAsync(AreaConhecimento area);


}