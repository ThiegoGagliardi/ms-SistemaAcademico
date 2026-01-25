using SistemaAcademicoProfessorMS.src.Data;
using SistemaAcademicoProfessorMS.src.Domain.Entities;
using SistemaAcademicoProfessorMS.Domain.Enums;
using SistemaAcademicoProfessorMS.src.Domain.Repositories;
using SistemaAcademicoProfessorMS.src.Domain.Repositories.Interfaces;
using SistemaAcademicoProfessorMS.src.Factories.Interfaces;
using SistemaAcademicoProfessorMS.src.DTOs;
using SistemaAcademicoProfessorMS.src.Services.Interfaces;

namespace SistemaAcademicoProfessorMS.src.Services;

public class ProfessorService : IProfessorService
{
    private readonly IProfessorRepository _professorRepository;    
    private readonly ITitulosFactory _TitulosFactory;

    private readonly IProfessorFactory _professorFactory; 

    public ProfessorService(IProfessorRepository professorRepository,
                            ITitulosFactory TitulosFactory,
                            IProfessorFactory professorFactory)
    {
        this._professorRepository = professorRepository;
        this._TitulosFactory     = TitulosFactory;
        this._professorFactory    = professorFactory;
    }

    public async Task<ProfessorRetornoDTO> AddAsync(ProfessorEnvioDTO professorDTO)
    {
        var novoProfessor = _professorFactory.CriarProfessor(professorDTO);

        novoProfessor = await _professorRepository.AddAsync(novoProfessor);                                                         
         
        return _professorFactory.CriarProfessorDTO(novoProfessor,
                                                             _TitulosFactory);
    }

    public async Task<ICollection<ProfessorRetornoDTO>> GetAllAsync(int? pagina, int? quantidade)
    {
        var professores = await _professorRepository.GetAllAsync(pagina, quantidade);

        ICollection<ProfessorRetornoDTO> professoresRequestDTOs = new List<ProfessorRetornoDTO>();

        foreach (var professor in professores)
        {
            professoresRequestDTOs.Add(_professorFactory.CriarProfessorDTO(professor,
                                                                           _TitulosFactory));
        }

        return professoresRequestDTOs;
    }

    public async Task<ProfessorRetornoDTO> GetByRegistroMecAsync(string registroMec)
    {
        var professor = await _professorRepository.GetByRegistroMecAsync(registroMec);

        return _professorFactory.CriarProfessorDTO(professor,
                                                   _TitulosFactory);        
    }

    public async Task<ProfessorRetornoDTO> GetByIdAsync(int id)
    {
        var professor = await _professorRepository.GetByIdAsync(id);

        return _professorFactory.CriarProfessorDTO(professor,
                                                   _TitulosFactory);
    }

    public async Task<ProfessorRetornoDTO> UpdateAsync(ProfessorAtualizaDTO professorDto)
    {
        var professor = _professorFactory.CriarProfessor(professorDto);

        professor = await _professorRepository.UpdateAsync(professor);

        return _professorFactory.CriarProfessorDTO(professor,
                                                   _TitulosFactory);
    }

    public async Task<ProfessorRetornoDTO> AdicionarTitulosProfessorAsync(ProfessorTituloDTO ProfessorTituloDTO)
    {
        var Titulos  = _professorFactory.CriarProfessorTitulo(ProfessorTituloDTO);

        await _professorRepository.AdicionarTitulosProfessorAsync(Titulos);

        var professor = await _professorRepository.GetByIdAsync(ProfessorTituloDTO.ProfessorId);

        return _professorFactory.CriarProfessorDTO(professor,
                                                   _TitulosFactory);        
    }

    public async Task<ProfessorRetornoDTO> DeleteAsync(int id)
    {
        var professor = await _professorRepository.DeleteAsync(id);
        return _professorFactory.CriarProfessorDTO(professor,
                                                   _TitulosFactory);
    }


    public async Task<ProfessorRetornoDTO> AtualizaPontuacaoAsync(int id)
    {
        var professor = await _professorRepository.GetByIdAsync(id);

        professor.AtualizarPotuacao();

        return _professorFactory.CriarProfessorDTO(professor,
                                                   _TitulosFactory);
    }   

}
