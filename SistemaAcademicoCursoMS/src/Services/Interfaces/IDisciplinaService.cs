using SistemaAcademicoCursoMS.src.DTOs;
using SistemaAcademicoCursoMS.src.Domain.Enum;

namespace SistemaAcademicoCursoMS.src.Services.Interfaces;

public interface IDisciplinaService
{
    Task<DisciplinaRetornoDTO> AddAsync(DisciplinaEnvioDTO disciplinaDTO);

    Task<DisciplinaRetornoDTO> AddDisciplinaFormacaoAsync(DisciplinaFormacaoEnvioDTO disciplinaFormacaoDTO);

    Task<ICollection<DisciplinaRetornoDTO>> GetAllAsync(int? pagina, int? quantidade);

    Task<ICollection<DisciplinaRetornoDTO>> GetByFormacaoAsync(string formacao);
    
    Task<DisciplinaRetornoDTO> GetByIdAsync(int id);
    
    Task<DisciplinaRetornoDTO> DeleteAsync(int id);

    Task<DisciplinaRetornoDTO> UpdateAsync(DisciplinaAtualizaDTO diciplinaDto);
}
