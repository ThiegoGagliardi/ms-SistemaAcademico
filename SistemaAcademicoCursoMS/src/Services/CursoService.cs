using Microsoft.EntityFrameworkCore;

using SistemaAcademicoCursoMS.src.Domain.Entities;
using SistemaAcademicoCursoMS.src.Data;
using SistemaAcademicoCursoMS.src.Domain.Repositories.Interfaces;
using SistemaAcademicoCursoMS.src.Domain.Enum;
using SistemaAcademicoCursoMS.Domain.Enums;
using SistemaAcademicoCursoMS.src.Services.Interfaces;
using SistemaAcademicoCursoMS.src.Factories.Interfaces;
using SistemaAcademicoCursoMS.src.DTOs;

namespace SistemaAcademicoCursoMS.src.Services;

public class CursoService : ICursoService
{
    private readonly ICursoRepository _cursoRepository;
    private readonly ICursoFactory _cursoFactory;
    private readonly IDisciplinaFactory _disciplinaFactory;

    public CursoService(ICursoRepository cursoRepository,
                        ICursoFactory cursoFactory,
                        IDisciplinaFactory disciplinaFactory)
    {
        this._cursoRepository   = cursoRepository;
        this._cursoFactory      = cursoFactory;
        this._disciplinaFactory = disciplinaFactory;

    }

    public async Task<CursoRetornoDTO> AddAsync(CursoEnvioDTO cursoDTO)
    {
         var novoCurso = _cursoFactory.CriarCurso(cursoDTO);

        novoCurso = await _cursoRepository.AddAsync(novoCurso);
         
        return _cursoFactory.CriarCursoRetornoDTO(novoCurso,
                                                  _disciplinaFactory);       
    }

    public async Task<CursoRetornoDTO> GetByIdAsync(int id)
    {
        var curso = await _cursoRepository.GetByIdAsync(id);

        return _cursoFactory.CriarCursoRetornoDTO(curso,
                                                  _disciplinaFactory);       
    }
  
    public async Task<ICollection<CursoRetornoDTO>> GetAllAsync(int? pagina, int? quantidade)
    {
        var cursos = await _cursoRepository.GetAllAsync(pagina, quantidade);

        ICollection<CursoRetornoDTO> cursosDTOs = new List<CursoRetornoDTO>();

        foreach (var curso in cursos)
        {
            cursosDTOs.Add( _cursoFactory.CriarCursoRetornoDTO(curso,
                                                               _disciplinaFactory));
        }

        return cursosDTOs;        
    }
    public async Task<ICollection<CursoRetornoDTO>> GetByNomeAsync(string nome)
    {
        var cursos = await _cursoRepository.GetByNomeAsync(nome);

        ICollection<CursoRetornoDTO> cursosDTOs = new List<CursoRetornoDTO>();

        foreach (var curso in cursos)
        {
            cursosDTOs.Add(_cursoFactory.CriarCursoRetornoDTO(curso,
                                                             _disciplinaFactory));
        }

        return cursosDTOs;       
    }

    public async Task<CursoRetornoDTO> AdicionarDisciplinaCursoAsync(CursoDisciplinaDTO cursoDisciplinaDTO)
    {
        var cursoDisciplina = _cursoFactory.CriarCursoDisciplinaDTO(cursoDisciplinaDTO);

        var curso = await _cursoRepository.AdicionarDisciplinaCursoAsync(cursoDisciplina);

        return _cursoFactory.CriarCursoRetornoDTO(curso,
                                                  _disciplinaFactory);        
    }

    public async Task<CursoRetornoDTO> UpdateAsync(CursoAtualizaDTO cursoDto)
    {
        var curso = _cursoFactory.CriarCurso(cursoDto);

        curso = await _cursoRepository.UpdateAsync(curso);

        return _cursoFactory.CriarCursoRetornoDTO(curso, _disciplinaFactory);        
    }

    public async Task<CursoRetornoDTO> DeleteAsync(int id)
    {
       var curso = await _cursoRepository.DeleteAsync(id);
       return _cursoFactory.CriarCursoRetornoDTO(curso, _disciplinaFactory); 
    }
}