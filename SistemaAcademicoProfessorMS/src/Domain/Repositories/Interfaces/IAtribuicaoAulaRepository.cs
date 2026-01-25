using SistemaAcademicoProfessorMS.src.Domain.Entities;
using SistemaAcademicoProfessorMS.src.DTOs;

namespace SistemaAcademicoProfessorMS.src.Domain.Repositories.Interfaces;

public interface IAtribuicaoAulaRepository 
{
    Task<AtribuicaoAula> AddAsync(AtribuicaoAula aula);

    Task<AtribuicaoAula> DeleteAsync(AtribuicaoAulaBuscaDTO aula);

    Task<IEnumerable<AtribuicaoAula>> GetAllAsync(int? pagina, int? quantidade);

    Task<List<AtribuicaoAula>> GetByCursoIdAsync(int CursoId);

    Task<AtribuicaoAula> GetByIdAsync(AtribuicaoAulaBuscaDTO aula);

}