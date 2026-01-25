using SistemaAcademicoProfessorMS.src.DTOs;

namespace SistemaAcademicoProfessorMS.src.Services.Interfaces;

public interface ITitulosService
{
    Task<TituloRetornoDTO> AddAsync(TituloEnvioDTO tituloDTO);
    
    Task<ICollection<TituloRetornoDTO>> GetAllAsync(int? pagina, int? quantidade);  

    Task<TituloRetornoDTO> GetByIdAsync(int id);

    Task<ICollection<TituloRetornoDTO>> GetByNomeAsync(string nome);
    
    Task<ICollection<TituloRetornoDTO>> GetByNivelAsync(string nivel);

    Task<TituloRetornoDTO> UpdateAsync(TituloAtualizaDTO titulosDTO);

    Task<TituloRetornoDTO> DeleteAsync(int id);
}