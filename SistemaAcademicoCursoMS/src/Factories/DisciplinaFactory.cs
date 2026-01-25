using SistemaAcademicoCursoMS.src.DTOs;
using SistemaAcademicoCursoMS.src.Domain.Entities;
using SistemaAcademicoCursoMS.src.Factories.Interfaces;
using SistemaAcademicoCursoMS.Domain.Enums;

namespace SistemaAcademicoCursoMS.src.Factories;

public class DisciplinaFactory : IDisciplinaFactory
{
    public Disciplina CriarDisciplina(DisciplinaEnvioDTO disciplinaEnvioDTO)
    { 
        Disciplina disciplina = new ()
        {
            Nome             = disciplinaEnvioDTO.Nome,
            Codigo           = disciplinaEnvioDTO.Codigo,
            Sigla            = disciplinaEnvioDTO.Sigla,
            AreaConhecimento = (AreaConhecimento) Enum.Parse(typeof(AreaConhecimento), disciplinaEnvioDTO.AreaConhecimento , true)
        };

        return disciplina;
    }

    public Disciplina CriarDisciplina (DisciplinaAtualizaDTO disciplinaEnvioDTO)
    {
        Disciplina disciplina = new ()
        {
            Id               = disciplinaEnvioDTO.Id,
            Nome             = disciplinaEnvioDTO.Nome,
            Codigo           = disciplinaEnvioDTO.Codigo,
            Sigla            = disciplinaEnvioDTO.Sigla,
            AreaConhecimento = (AreaConhecimento) Enum.Parse(typeof(AreaConhecimento), disciplinaEnvioDTO.AreaConhecimento , true)
            
        };

        return disciplina;        
    }

    public  DisciplinaRetornoDTO CriarDisciplinaRetornoDTO (Disciplina disciplina,                                                      
                                                      IFormacaoFactory formacaoFactory)
    {

        DisciplinaRetornoDTO disciplinaDTO = new () 
        {
            Id               = disciplina.Id,
            Nome             = disciplina.Nome,
            Codigo           = disciplina.Codigo,
            Sigla            = disciplina.Sigla,
            AreaConhecimento = disciplina.AreaConhecimento.ToString()
            
        };              
        
        foreach (var f in disciplina.Formacoes)
        {           
            disciplinaDTO.Formacoes.Add(formacaoFactory.CriarFormacaoRetornoDTO(f));            
        }   

        return disciplinaDTO;
    }

    public DisciplinaRetornoDTO CriarDisciplinaRetornoDTO (Disciplina disciplina)
    {         
        DisciplinaRetornoDTO disciplinaDTO = new () 
        {
            Id               = disciplina.Id,
            Nome             = disciplina.Nome,
            Codigo           = disciplina.Codigo,
            Sigla            = disciplina.Sigla,
            AreaConhecimento = disciplina.AreaConhecimento.ToString()            
        };        

        return disciplinaDTO;
    }    
}
