
namespace SistemaAcademicoAlunoMS.src.DTOs;

public class CursoDisciplinaRetornoDTO
{
    public int DisciplinaId  { get; set; }

    public int CursoId { get; set; }

    public string NomeCurso { get; set;} = string.Empty;

    public string NomeDisciplina { get; set;} = string.Empty;

    public string SiglaDisciplina { get; set;} = string.Empty;
}