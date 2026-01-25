using SistemaAcademicoCursoMS.Domain.Enums;

namespace SistemaAcademicoCursoMS.src.Domain.Entities;

public class Formacao
{
    public int Id { get; set; }

    public string Nome { get; set; } = string.Empty;

    public NivelFormacao Nivel { get; set;}

    public AreaConhecimento AreaConhecimento { get; set; }    

    public IList<Disciplina> Disciplinas { get; set;} = new List<Disciplina>();    

}
