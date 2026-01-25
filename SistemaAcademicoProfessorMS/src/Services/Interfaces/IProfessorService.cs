using SistemaAcademicoProfessorMS.src.Data;
using SistemaAcademicoProfessorMS.src.Domain.Entities;
using SistemaAcademicoProfessorMS.Domain.Enums;
using SistemaAcademicoProfessorMS.src.Domain.Repositories;
using SistemaAcademicoProfessorMS.src.Domain.Repositories.Interfaces;
using SistemaAcademicoProfessorMS.src.Factories.Interfaces;
using SistemaAcademicoProfessorMS.src.DTOs;
using SistemaAcademicoProfessorMS.src.Services.Interfaces;

namespace SistemaAcademicoProfessorMS.src.Services.Interfaces;

public interface IProfessorService
{
    Task<ProfessorRetornoDTO> AddAsync(ProfessorEnvioDTO professorDTO);
    
    Task<ICollection<ProfessorRetornoDTO>> GetAllAsync(int? pagina, int? quantidade);
    
    Task<ProfessorRetornoDTO> GetByRegistroMecAsync(string registroMec);

    Task<ProfessorRetornoDTO> GetByIdAsync(int id);

    Task<ProfessorRetornoDTO> UpdateAsync(ProfessorAtualizaDTO professorDto);

    Task<ProfessorRetornoDTO> DeleteAsync(int id);

    Task<ProfessorRetornoDTO> AdicionarTitulosProfessorAsync(ProfessorTituloDTO ProfessorTituloDTO);
    
    Task<ProfessorRetornoDTO> AtualizaPontuacaoAsync(int id);    
}