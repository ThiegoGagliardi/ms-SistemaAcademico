using SistemaAcademicoCursoMS.src.DTOs;
using SistemaAcademicoCursoMS.src.Domain.Entities;
using SistemaAcademicoCursoMS.src.Factories.Interfaces;
using SistemaAcademicoCursoMS.Domain.Enums;
using SistemaAcademicoCursoMS.src.Domain.Enum;

namespace SistemaAcademicoCursoMS.src.Factories;

public class GradeHorariaFactory : IGradeHorariaFactory
{

    public GradeHoraria CriaGradeHoraria(GradeHorariaEnvioDTO gradeHoraraiDTO,
                                         Curso curso,
                                         Disciplina disciplina)
    {
        GradeHoraria grade = new()
        {
            CursoId      = gradeHoraraiDTO.CursoId,
            DisciplinaId = gradeHoraraiDTO.DisciplinaId,
            Dia          = (DiaSemana)Enum.Parse(typeof(DiaSemana),gradeHoraraiDTO.Dia,true),
            HoraInicio   = TimeSpan.Parse(gradeHoraraiDTO.HoraInicio),
            HoraFim      = TimeSpan.Parse(gradeHoraraiDTO.HoraFim),
            Duracao      = TimeSpan.Parse(gradeHoraraiDTO.Duracao),
            Disciplina   = disciplina,
            Curso        = curso
        };

        return grade;
    }

    public GradeHoraria CriaGradeHoraria(GradeHorariaEnvioDTO gradeHoraraiDTO)
    {
        GradeHoraria grade = new()
        {
            CursoId      = gradeHoraraiDTO.CursoId,
            DisciplinaId = gradeHoraraiDTO.DisciplinaId,
            Dia          = (DiaSemana)Enum.Parse(typeof(DiaSemana),gradeHoraraiDTO.Dia,true),
            HoraInicio   = TimeSpan.Parse(gradeHoraraiDTO.HoraInicio),
            HoraFim      = TimeSpan.Parse(gradeHoraraiDTO.HoraFim),
            Duracao      = TimeSpan.Parse(gradeHoraraiDTO.Duracao)
        };

        return grade;
    }    

    public GradeHorariaRetornoDTO CriaGradeHorariaRetornoDTO(GradeHoraria grade)
    { 
        GradeHorariaRetornoDTO gradeDto = new()
        {
            Curso           = grade.Curso.Nome,
            Disciplina      = grade.Disciplina.Nome,
            SiglaDisciplina = grade.Disciplina.Sigla,        
            Dia             = grade.Dia.ToString(),            
            HoraInicio      = grade.HoraInicio.ToString(),
            HoraFim         = grade.HoraFim.ToString(),
            Duracao         = grade.Duracao.ToString()           
        }; 

        return gradeDto;
    }  

}