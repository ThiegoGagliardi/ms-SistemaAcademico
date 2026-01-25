using SistemaAcademicoCursoMS.src.DTOs;
using SistemaAcademicoCursoMS.src.Domain.Entities;


namespace SistemaAcademicoCursoMS.src.Factories.Interfaces;

public interface IGradeHorariaFactory
{
    GradeHoraria CriaGradeHoraria(GradeHorariaEnvioDTO gradeHoraraiDTO,
                                  Curso curso,
                                  Disciplina disciplina);

    GradeHoraria CriaGradeHoraria(GradeHorariaEnvioDTO gradeHoraraiDTO);                                  
  
    GradeHorariaRetornoDTO CriaGradeHorariaRetornoDTO(GradeHoraria grade);
}