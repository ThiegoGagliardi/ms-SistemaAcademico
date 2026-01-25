using SistemaAcademicoProfessorMS.src.DTOs;

namespace SistemaAcademicoProfessorMS.src.Services.Interfaces;

public interface IAtribuicaoAulaService
{
    Task<List<ProfessorDisciplinaRetornoDTO>> GetProfessoresRanqueadosAsync(List<int> TitulosId);

    Task<List<AtribuicaoAulaRetornoDTO>> GetAtribuicaoAulaByCursoIdAsync(int cursoId);

    Task<AtribuicaoAulaRetornoDTO> AddAtribuicaoAulaAsync(AtribuicaoAulaEnvioDTO atribuicaoAulaDTO);
    
    Task<AtribuicaoAulaRetornoDTO> RemoverAtribuicaoAulaAsync(AtribuicaoAulaBuscaDTO atribuicaoAulaDTO);    
}