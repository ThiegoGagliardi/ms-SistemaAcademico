using SistemaAcademicoAlunoMS.src.DTOs;
using SistemaAcademicoAlunoMS.src.Domain.Entities;

namespace SistemaAcademicoAlunoMS.src.Factories.Interfaces;

public interface IAlunoFactory
{
    Aluno CriarAluno (AlunoEnvioDTO alunoDTO);

    Aluno CriarAluno (AlunoEnvioAtualizaDTO alunoDTO);
    
    AlunoRetornoDTO CriarAlunoRetornoDTO (Aluno aluno);
}