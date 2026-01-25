using SistemaAcademicoCursoMS.src.DTOs;
using SistemaAcademicoCursoMS.src.Domain.Entities;

namespace SistemaAcademicoCursoMS.src.Factories.Interfaces;

public interface IDisciplinaFactory
{
    Disciplina CriarDisciplina (DisciplinaEnvioDTO disciplinaEnvioDTO);

    Disciplina CriarDisciplina (DisciplinaAtualizaDTO disciplinaEnvioDTO);

    DisciplinaRetornoDTO CriarDisciplinaRetornoDTO (Disciplina disciplina, IFormacaoFactory formacaoFactory);

    DisciplinaRetornoDTO CriarDisciplinaRetornoDTO (Disciplina disciplina);
}