using SistemaAcademicoProfessorMS.src.DTOs;
using SistemaAcademicoProfessorMS.src.Domain.Entities;
using SistemaAcademicoProfessorMS.src.Factories.Interfaces;
using SistemaAcademicoProfessorMS.Domain.Enums;

namespace SistemaAcademicoProfessorMS.src.Factories;

public class ProfessorFactory : IProfessorFactory
{
    public Professor CriarProfessor(ProfessorEnvioDTO professorDto)
    {
        Professor professor = new()
        {
            Nome = professorDto.Nome,
            RegistroMec = professorDto.RegistroMec,
            Nivel  = professorDto.Nivel,
            DataContratacao = DateTime.Parse(professorDto.DataContratacao)
        };

        return professor;        
    }

    public Professor CriarProfessor(ProfessorAtualizaDTO professorDto)
    {
        Professor professor = new()
        {
            Id              = professorDto.Id,
            Nome            = professorDto.Nome,
            RegistroMec     = professorDto.RegistroMec,
            DataContratacao = DateTime.Parse(professorDto.DataContratacao)
        };
        return professor;        
    }   

    public ProfessorRetornoDTO CriarProfessorDTO(Professor professor, 
                                                 ITitulosFactory titulosFactory)
    {
        ProfessorRetornoDTO professorDto = new()
        {
            Id          = professor.Id,
            Nome        = professor.Nome,
            RegistroMec = professor.RegistroMec,
            Pontuacao   = professor.Pontuacao,
            DataContratacao = professor.DataContratacao            
        };

        foreach (var f in professor.Titulos)
        {
            if (f.Titulo is null) {
                continue;
            }

            professorDto.Titulos.Add(titulosFactory.CriarTituloRetornoDTO(f.Titulo));  
        }

        return professorDto;       
    }

    public ProfessorTitulo CriarProfessorTitulo(ProfessorTituloDTO TitulosDTO)
    {
        ProfessorTitulo Titulos = new()
        {
           TitulosId  = TitulosDTO.TitulosId,
           ProfessorId = TitulosDTO.ProfessorId,
           Inicio      = TitulosDTO.Inicio,
           Termino     = TitulosDTO.Termino            
        };

        return Titulos;   
    }
}