namespace SistemaAcademicoProfessorMS.src.DTOs;

public class ProfessorTituloDTO
{
    public int ProfessorId { get; set; }

    public int TitulosId { get; set;}

    public DateOnly Inicio { get; set; }

    public DateOnly Termino { get; set; }
}