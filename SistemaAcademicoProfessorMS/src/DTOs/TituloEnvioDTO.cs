namespace SistemaAcademicoProfessorMS.src.DTOs;

public class TituloEnvioDTO
{
   public string Nome { get; set; } = string.Empty;

    public string Instituicao { get; set; } = string.Empty;

    public string Nivel { get; set;} = string.Empty;

    public string AreaConhecimento { get; set; } = string.Empty;    

    public double ValorPontuacao { get; set; }
}