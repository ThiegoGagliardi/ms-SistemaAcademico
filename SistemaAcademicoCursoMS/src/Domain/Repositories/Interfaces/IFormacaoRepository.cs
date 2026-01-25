using SistemaAcademicoCursoMS.src.Domain.Entities;
using SistemaAcademicoCursoMS.Domain.Enums;

namespace SistemaAcademicoCursoMS.src.Domain.Repositories.Interfaces;

public interface IFormacaoRepository : IRepository<Formacao>
{   
    Task<IEnumerable<Formacao>> GetByNivelAsync(NivelFormacao nivel);

    Task<IEnumerable<Formacao>> GetByNomeAsync(string nome);
}
