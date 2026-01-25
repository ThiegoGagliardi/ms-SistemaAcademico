namespace SistemaAcademicoProfessorMS.src.Domain.Entities;

public class ProfessorTitulo
{
    public int ProfessorId { get; set; }

    public int TitulosId { get; set;}

    public DateOnly Inicio { get; set; }

    public DateOnly Termino { get; set; } 

    public Professor? Professor { get; set; }

    public Titulo? Titulo { get; set; }

}