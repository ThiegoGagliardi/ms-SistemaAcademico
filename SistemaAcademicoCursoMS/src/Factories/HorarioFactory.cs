using SistemaAcademicoCursoMS.src.DTOs;
using SistemaAcademicoCursoMS.src.Domain.Entities;
using SistemaAcademicoCursoMS.src.Factories.Interfaces;
using SistemaAcademicoCursoMS.Domain.Enums;

namespace SistemaAcademicoCursoMS.src.Factories;

public class HorarioFactory : IHorarioFactory
{
    public HorarioRetornoDTO CriarHorarioDTO(GradeHoraria horario)
    {
        HorarioRetornoDTO horarioDTO = new()
        {
             Curso           = horario.Curso.Nome,
             Disciplina      = horario.Disciplina.Nome,
             SiglaDisciplina = horario.Disciplina.Sigla,
             Dia             = horario.Dia.ToString(),
             HoraInicio      = horario.HoraInicio.ToString(), 
             HoraFim         = horario.HoraFim.ToString(),
             Duracao         = horario.Duracao.ToString()
            
        };

        return horarioDTO;
    }
}
