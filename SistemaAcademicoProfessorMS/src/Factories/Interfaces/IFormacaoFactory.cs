using SistemaAcademicoProfessorMS.src.DTOs;
using SistemaAcademicoProfessorMS.src.Domain.Entities;

namespace SistemaAcademicoProfessorMS.src.Factories.Interfaces;

public interface ITitulosFactory
{
    Titulo CriarTitulos (TituloEnvioDTO titulosDTO);

    TituloRetornoDTO CriarTituloRetornoDTO (Titulo titulo);  

    Titulo CriarTitulosAtualizaAsync (TituloAtualizaDTO tituloDTO); 
}
