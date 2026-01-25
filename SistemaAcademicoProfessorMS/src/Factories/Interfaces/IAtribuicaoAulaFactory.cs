using SistemaAcademicoProfessorMS.src.DTOs;
using SistemaAcademicoProfessorMS.src.Domain.Entities;


namespace SistemaAcademicoProfessorMS.src.Factories.Interfaces;

public interface IAtribuicaoAulaFactory
{
    AtribuicaoAula CriarAtribuicaoAula(AtribuicaoAulaEnvioDTO atribuicaoAulaDTO,                                      
                                      Professor professor);

    AtribuicaoAula CriarAtribuicaoAula(AtribuicaoAulaEnvioDTO atribuicaoAulaDTO);                                  
  
    AtribuicaoAulaRetornoDTO CriarAtribuicaoAulaRetornoDTO(AtribuicaoAula atribuicaoAula);
}