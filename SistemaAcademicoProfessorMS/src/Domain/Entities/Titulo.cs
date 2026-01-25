using SistemaAcademicoProfessorMS.Domain.Enums;

namespace SistemaAcademicoProfessorMS.src.Domain.Entities;

public class Titulo
{
    public int Id { get; set; }

    public string Nome { get; set; } = string.Empty;

    public string Instituicao { get; set; } = string.Empty;

    public NivelTitulos Nivel { get; set;}

    public AreaConhecimento AreaConhecimento { get; set; }    

    public double ValorPontuacao { get; set; }    

    public IList<ProfessorTitulo> Professores { get; set;} = new List<ProfessorTitulo>();

}
