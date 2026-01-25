using SistemaAcademicoProfessorMS.src.Domain.Enum;

namespace SistemaAcademicoProfessorMS.src.Domain.Entities;

public class AtribuicaoAula
{
    public int CursoId { get; set; }

    public int DisciplinaId { get; set; }

    public int ProfessorId { get; set; }

    public string Curso { get; set; } = string.Empty;

    public string Disciplina { get; set; } = string.Empty;

    public DiaSemana Dia { get; set; }

    public TimeSpan HoraInicio { get; set; }

    public TimeSpan HoraFim { get; set; }
    
    public TimeSpan Duracao { get; set; }
    
    public Professor? Professor { get; set; }
    
}