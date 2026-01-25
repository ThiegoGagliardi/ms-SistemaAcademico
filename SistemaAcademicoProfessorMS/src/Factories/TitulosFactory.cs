using SistemaAcademicoProfessorMS.src.DTOs;
using SistemaAcademicoProfessorMS.src.Domain.Entities;
using SistemaAcademicoProfessorMS.src.Factories.Interfaces;
using SistemaAcademicoProfessorMS.Domain.Enums;

namespace SistemaAcademicoProfessorMS.src.Factories;

public class TitulosFactory : ITitulosFactory
{

    public Titulo CriarTitulos (TituloEnvioDTO titulosDTO)
    {
        Titulo titulo = new ()
        {
                        
           Nome             = titulosDTO.Nome,
           Instituicao      = titulosDTO.Instituicao,
           ValorPontuacao   = titulosDTO.ValorPontuacao,
           Nivel            = (NivelTitulos) Enum.Parse(typeof(NivelTitulos), titulosDTO.Nivel, true),
           AreaConhecimento = (AreaConhecimento) Enum.Parse(typeof(AreaConhecimento), titulosDTO.AreaConhecimento, true)
        };
        
        return titulo;
    }

    public Titulo CriarTitulosAtualizaAsync(TituloAtualizaDTO titulosDTO)
    {
        Titulo titulo = new ()
        {

           Id               = titulosDTO.Id,             
           Nome             = titulosDTO.Nome,
           Instituicao      = titulosDTO.Instituicao,
           ValorPontuacao   = titulosDTO.ValorPontuacao,
           Nivel            = (NivelTitulos) Enum.Parse(typeof(NivelTitulos), titulosDTO.Nivel, true),
           AreaConhecimento = (AreaConhecimento) Enum.Parse(typeof(AreaConhecimento), titulosDTO.AreaConhecimento, true)
        };
        
        return titulo;
    }

    public TituloRetornoDTO CriarTituloRetornoDTO (Titulo titulo)
    {
        TituloRetornoDTO titulosDTO = new ()
        {
           Id               = titulo.Id,                        
           Nome             = titulo.Nome,
           Instituicao      = titulo.Instituicao,
           ValorPontuacao   = titulo.ValorPontuacao,
           Nivel            = titulo.Nivel.ToString(),
           AreaConhecimento = titulo.AreaConhecimento.ToString()
        };
        
        return titulosDTO;
    }    
}