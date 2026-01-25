using SistemaAcademicoCursoMS.src.DTOs;
using SistemaAcademicoCursoMS.src.Domain.Entities;

namespace SistemaAcademicoCursoMS.src.Factories.Interfaces;

public interface ICursoFactory
{
    Curso CriarCurso(CursoEnvioDTO cursoDTO);
  
    CursoRetornoDTO CriarCursoRetornoDTO(Curso curso,
                                         IDisciplinaFactory disciplinaFactory);

    CursoRetornoDTO CriarCursoRetornoDTO(Curso curso);                                         

    Curso CriarCurso(CursoAtualizaDTO cursoDTO);    

    CursoDisciplina CriarCursoDisciplinaDTO(CursoDisciplinaDTO cursoDisciplinaDTO);

}