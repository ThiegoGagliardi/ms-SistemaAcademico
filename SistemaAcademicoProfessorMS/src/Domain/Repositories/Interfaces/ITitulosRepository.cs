using SistemaAcademicoProfessorMS.src.Domain.Entities;
using SistemaAcademicoProfessorMS.Domain.Enums;

namespace SistemaAcademicoProfessorMS.src.Domain.Repositories.Interfaces;

public interface ITitulosRepository : IRepository<Titulo>
{   
    Task<IEnumerable<Titulo>> GetByNivelAsync(NivelTitulos nivel);

    Task<IEnumerable<Titulo>> GetByNomeAsync(string nome);
}
