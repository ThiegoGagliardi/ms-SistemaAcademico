
namespace SistemaAcademicoAlunoMS.src.DTOs;

public class CursoDisciplinaRetornoDTO
{
    public int Id { get; set; }

    public string Nome { get; set; } = string.Empty;

    public string Descricao { get; set; } = string.Empty;

    public string AreaConhecimento { get; set;} = string.Empty;

    public IList<DisciplinaRetornoDTO> Disciplinas { get; set; } = new List<DisciplinaRetornoDTO>();
}