using SistemaAcademicoCursoMS.src.DTOs;
using SistemaAcademicoCursoMS.src.Domain.Entities;

namespace SistemaAcademicoCursoMS.src.Factories.Interfaces;

public interface IFormacaoFactory
{
    Formacao CriarFormacao (FormacaoEnvioDTO formacaoDTO);

    FormacaoRetornoDTO CriarFormacaoRetornoDTO (Formacao formacao);  

    Formacao CriarFormacaoAtualizaAsync (FormacaoAtualizaDTO formacaoDTO); 
}
