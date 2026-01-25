using SistemaAcademicoProfessorMS.src.Domain.Entities;

namespace SistemaAcademicoProfessorMS.src.Domain.Repositories.Interfaces;

public interface IProfessorRepository : IRepository<Professor>
{
    Task<Professor> GetByRegistroMecAsync(string registroMec);

    Task<Professor> AdicionarTitulosProfessorAsync(ProfessorTitulo ProfessorTitulo);    
    
}