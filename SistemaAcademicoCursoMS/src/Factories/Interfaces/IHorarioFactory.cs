using SistemaAcademicoCursoMS.src.DTOs;
using SistemaAcademicoCursoMS.src.Domain.Entities;

namespace SistemaAcademicoCursoMS.src.Factories.Interfaces;

public interface IHorarioFactory
{
    HorarioRetornoDTO CriarHorarioDTO(GradeHoraria horario);
}