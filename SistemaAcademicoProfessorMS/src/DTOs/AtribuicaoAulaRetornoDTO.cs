using SistemaAcademicoProfessorMS.src.DTOs;
using SistemaAcademicoProfessorMS.src.Domain.Entities;
using SistemaAcademicoProfessorMS.src.Factories.Interfaces;
using SistemaAcademicoProfessorMS.Domain.Enums;

namespace SistemaAcademicoProfessorMS.src.DTOs;

public class AtribuicaoAulaRetornoDTO
{
    public string Curso { get; set; } = string.Empty;

    public string Disciplina { get; set; } = string.Empty;      
    
    public string SiglaDisciplina { get; set; } = string.Empty;
    
    public string Professor { get; set; } = string.Empty;

    public string Dia { get; set; } = string.Empty;

    public string HoraInicio { get; set; } = string.Empty;

    public string HoraFim { get; set; } = string.Empty;
    
    public string Duracao { get; set; } = string.Empty;
}
