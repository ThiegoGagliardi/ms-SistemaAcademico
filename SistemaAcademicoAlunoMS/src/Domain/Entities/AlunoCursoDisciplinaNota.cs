
namespace SistemaAcademicoAlunoMS.src.Domain.Entities;

public class AlunoCursoDisciplinaNota
{
    public int AlunoId  { get; set; }

    public int CursoId { get; set; }

    public int DisciplinaId { get; set; }

    public string Bimestre { get; set; } = string.Empty;    

    public DateOnly Data { get; set; }
    
    public decimal Nota { get; set; }

    public int Peso { get; set; }

    public Aluno Aluno { get; set; }
}