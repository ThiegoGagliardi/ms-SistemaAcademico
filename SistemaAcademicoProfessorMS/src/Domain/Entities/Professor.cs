namespace SistemaAcademicoProfessorMS.src.Domain.Entities;

public class Professor
{
    public int Id { get; set; }
    public string Nome { get; set ;}  = string.Empty;
    public string RegistroMec { get; set; } = string.Empty;
    public double Pontuacao { get; set; }
    public int Nivel { get; set; }

    public DateTime DataContratacao { get; set;}
    
    public List<ProfessorTitulo> Titulos { get; set; } = new();

    public List<AtribuicaoAula> Aulas { get; set; } = new();

    public void AtualizarPotuacao ()
    {
       TimeSpan periodo = DateTime.Now.Date - DataContratacao;
       this.Pontuacao = Math.Truncate(periodo.TotalDays/365.25) * this.Nivel;
        
       foreach (var f in Titulos)
       {
          if (f.Titulo is null){
           continue;
         }

         this.Pontuacao += f.Titulo.ValorPontuacao;
       }
    }
}
