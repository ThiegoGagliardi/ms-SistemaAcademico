using SistemaAcademicoProfessorMS.src.Domain.Repositories.Interfaces;
using SistemaAcademicoProfessorMS.src.Factories.Interfaces;
using SistemaAcademicoProfessorMS.src.DTOs;
using SistemaAcademicoProfessorMS.Domain.Enums;

namespace SistemaAcademicoProfessorMS.src.Services.Interfaces;

public class TitulosService : ITitulosService
{    
    private readonly ITitulosRepository _titulosRepository;

    private readonly ITitulosFactory _titulosFactory;

    public TitulosService(ITitulosRepository TitulosRepository,
                           ITitulosFactory TitulosFactory)
    {
        this._titulosRepository = TitulosRepository;
        this._titulosFactory    = TitulosFactory;        
    }

    public async Task<TituloRetornoDTO> AddAsync(TituloEnvioDTO tituloDTO)
    {
        var novaTitulos = _titulosFactory.CriarTitulos(tituloDTO);

        novaTitulos = await _titulosRepository.AddAsync(novaTitulos);                                                         
         
        return _titulosFactory.CriarTituloRetornoDTO(novaTitulos);
    }

    public async Task<ICollection<TituloRetornoDTO>> GetAllAsync(int? pagina, int? quantidade)
    {
        var titulos = await _titulosRepository.GetAllAsync(pagina, quantidade);

        ICollection<TituloRetornoDTO> titulosDTOs = new List<TituloRetornoDTO>();

        foreach (var titulo in titulos)
        {
            titulosDTOs.Add(_titulosFactory.CriarTituloRetornoDTO(titulo));
        }

        return titulosDTOs;
    }

    public async Task<ICollection<TituloRetornoDTO>> GetByNomeAsync(string nome)
    {
        var titulos = await _titulosRepository.GetByNomeAsync(nome);

        ICollection<TituloRetornoDTO> TitulosDTOs = new List<TituloRetornoDTO>();

        foreach (var titulo in titulos)
        {
            TitulosDTOs.Add(_titulosFactory.CriarTituloRetornoDTO(titulo));
        }

        return TitulosDTOs;
    }

    public async Task<ICollection<TituloRetornoDTO>> GetByNivelAsync(string nivel)
    {
        var nivelTitulos = (NivelTitulos)Enum.Parse(typeof(NivelTitulos),nivel,true);

        var Titulos = await _titulosRepository.GetByNivelAsync(nivelTitulos);

        ICollection<TituloRetornoDTO> TitulosDTOs = new List<TituloRetornoDTO>();

        foreach (var titulo in Titulos)
        {
            TitulosDTOs.Add(_titulosFactory.CriarTituloRetornoDTO(titulo));
        }

        return TitulosDTOs;
    }      

    public async Task<TituloRetornoDTO> GetByIdAsync(int id)
    {
        var titulo = await _titulosRepository.GetByIdAsync(id);

        return _titulosFactory.CriarTituloRetornoDTO(titulo);
    }

    public async Task<TituloRetornoDTO> UpdateAsync(TituloAtualizaDTO tituloDto)
    {
        var titulo = _titulosFactory.CriarTitulosAtualizaAsync(tituloDto);

        titulo = await _titulosRepository.UpdateAsync(titulo);

        return _titulosFactory.CriarTituloRetornoDTO(titulo);
    }

    public async Task<TituloRetornoDTO> DeleteAsync(int id)
    {
        var titulo = await _titulosRepository.DeleteAsync(id);
        return _titulosFactory.CriarTituloRetornoDTO(titulo);
    }
}