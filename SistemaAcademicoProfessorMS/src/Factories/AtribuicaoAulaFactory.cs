using SistemaAcademicoProfessorMS.src.DTOs;
using SistemaAcademicoProfessorMS.src.Domain.Entities;
using SistemaAcademicoProfessorMS.src.Factories.Interfaces;
using SistemaAcademicoProfessorMS.Domain.Enums;
using SistemaAcademicoProfessorMS.src.Domain.Enum;

namespace SistemaAcademicoProfessorMS.src.Factories;

public class AtribuicaoAulaFactory : IAtribuicaoAulaFactory
{
    public AtribuicaoAula CriarAtribuicaoAula(AtribuicaoAulaEnvioDTO atribuicaoAulaDTO, Professor professor)
    {
        AtribuicaoAula atribuicaoAula = new()
        {
            CursoId      = atribuicaoAulaDTO.CursoId,
            DisciplinaId = atribuicaoAulaDTO.DisciplinaId,
            ProfessorId  = atribuicaoAulaDTO.ProfessorId,
            Dia          = (DiaSemana)Enum.Parse(typeof(DiaSemana),atribuicaoAulaDTO.Dia,true),
            HoraInicio   = TimeSpan.Parse(atribuicaoAulaDTO.HoraInicio),
            HoraFim      = TimeSpan.Parse(atribuicaoAulaDTO.HoraFim),
            Duracao      = TimeSpan.Parse(atribuicaoAulaDTO.Duracao),
            Professor    = professor,
        };

        return atribuicaoAula;
    }

    public AtribuicaoAula CriarAtribuicaoAula(AtribuicaoAulaEnvioDTO atribuicaoAulaDTO)
    {
        AtribuicaoAula atribuicaoAula = new()
        {
            CursoId      = atribuicaoAulaDTO.CursoId,
            DisciplinaId = atribuicaoAulaDTO.DisciplinaId,
            ProfessorId  = atribuicaoAulaDTO.ProfessorId,
            Dia          = (DiaSemana)Enum.Parse(typeof(DiaSemana),atribuicaoAulaDTO.Dia,true),
            HoraInicio   = TimeSpan.Parse(atribuicaoAulaDTO.HoraInicio),
            HoraFim      = TimeSpan.Parse(atribuicaoAulaDTO.HoraFim),
            Duracao      = TimeSpan.Parse(atribuicaoAulaDTO.Duracao)
        };

        return atribuicaoAula;
    }    

    public AtribuicaoAulaRetornoDTO CriarAtribuicaoAulaRetornoDTO(AtribuicaoAula atribuicaoAula)
    { 
        AtribuicaoAulaRetornoDTO atribuicaoAulaDto = new()
        {
            Professor       = atribuicaoAula.Professor.Nome,            
            Dia             = atribuicaoAula.Dia.ToString(),            
            HoraInicio      = atribuicaoAula.HoraInicio.ToString(),
            HoraFim         = atribuicaoAula.HoraFim.ToString(),
            Duracao         = atribuicaoAula.Duracao.ToString()           
        }; 

        return atribuicaoAulaDto;
    }
}