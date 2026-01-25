using SistemaAcademicoCursoMS.src.Domain.Enum;

namespace SistemaAcademicoCursoMS.src.Domain.Entities;

public class GradeHoraria
{
    public int CursoId { get; set; }

    public int DisciplinaId { get; set; }

    public DiaSemana Dia { get; set; }

    public TimeSpan HoraInicio { get; set; }

    public TimeSpan HoraFim { get; set; }
    
    public TimeSpan Duracao { get; set; }

    public Curso? Curso { get; set; }

    public Disciplina? Disciplina { get; set; }
}