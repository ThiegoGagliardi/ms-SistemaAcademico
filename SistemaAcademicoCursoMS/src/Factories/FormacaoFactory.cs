using SistemaAcademicoCursoMS.src.DTOs;
using SistemaAcademicoCursoMS.src.Domain.Entities;
using SistemaAcademicoCursoMS.src.Factories.Interfaces;
using SistemaAcademicoCursoMS.Domain.Enums;

namespace SistemaAcademicoCursoMS.src.Factories;

public class FormacaoFactory : IFormacaoFactory
{

    public Formacao CriarFormacao (FormacaoEnvioDTO formacaoDTO)
    {
        Formacao formacao = new ()
        {
                        
           Nome             = formacaoDTO.Nome,
           Nivel            = (NivelFormacao) Enum.Parse(typeof(NivelFormacao), formacaoDTO.Nivel, true),
           AreaConhecimento = (AreaConhecimento) Enum.Parse(typeof(AreaConhecimento), formacaoDTO.AreaConhecimento, true)
        };
        
        return formacao;
    }

    public Formacao CriarFormacaoAtualizaAsync(FormacaoAtualizaDTO formacaoDTO)
    {
        Formacao formacao = new ()
        {

           Id               = formacaoDTO.Id,             
           Nome             = formacaoDTO.Nome,
           Nivel            = (NivelFormacao) Enum.Parse(typeof(NivelFormacao), formacaoDTO.Nivel, true),
           AreaConhecimento = (AreaConhecimento) Enum.Parse(typeof(AreaConhecimento), formacaoDTO.AreaConhecimento, true)
        };
        
        return formacao;
    }

    public FormacaoRetornoDTO CriarFormacaoRetornoDTO (Formacao formacao)
    {
        FormacaoRetornoDTO formacaoDTO = new ()
        {
           Id               = formacao.Id,                        
           Nome             = formacao.Nome,
           Nivel            = formacao.Nivel.ToString(),
           AreaConhecimento = formacao.AreaConhecimento.ToString()
        };
        
        return formacaoDTO;
    }    
}