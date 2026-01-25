using SistemaAcademicoCursoMS.src.DTOs;
using SistemaAcademicoCursoMS.src.Domain.Entities;
using SistemaAcademicoCursoMS.src.Factories.Interfaces;
using SistemaAcademicoCursoMS.Domain.Enums;

namespace SistemaAcademicoCursoMS.src.DTOs;

public class GradeHorariaRetornoDTO
{
    public string Curso { get; set; } = string.Empty;

    public string Disciplina { get; set; } = string.Empty;      
    
    public string SiglaDisciplina { get; set; } = string.Empty;

    public string Dia { get; set; } = string.Empty;

    public string HoraInicio { get; set; } = string.Empty;

    public string HoraFim { get; set; } = string.Empty;
    
    public string Duracao { get; set; } = string.Empty;
}
