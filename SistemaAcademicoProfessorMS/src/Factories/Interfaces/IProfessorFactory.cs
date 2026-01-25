using SistemaAcademicoProfessorMS.src.DTOs;
using SistemaAcademicoProfessorMS.src.Domain.Entities;

namespace SistemaAcademicoProfessorMS.src.Factories.Interfaces;

public interface IProfessorFactory
{
    ProfessorRetornoDTO CriarProfessorDTO(Professor professor,
                                          ITitulosFactory TitulosFactory);

    Professor CriarProfessor(ProfessorEnvioDTO professorDto);

    Professor CriarProfessor(ProfessorAtualizaDTO professorDto);
    
    ProfessorTitulo CriarProfessorTitulo(ProfessorTituloDTO TitulosDTO);
}