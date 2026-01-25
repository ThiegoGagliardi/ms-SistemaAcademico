using SistemaAcademicoAlunoMS.src.Domain.Enum;

namespace SistemaAcademicoAlunoMS.src.Domain.Entities;

public class MatriculaAlunoCurso
{
    public int AlunoId  { get; set; }

    public int CursoId { get; set; }

    public string NomeCurso { get; set;} = string.Empty;

    public DateOnly DataInicio { get; set; }

    public DateOnly DataFim { get; set; }

    public StatusAlunoCurso Status { get; set; }

    public Aluno? Aluno { get; set; }  
    
}