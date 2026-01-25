using Microsoft.EntityFrameworkCore;

using SistemaAcademicoProfessorMS.src.DTOs;
using SistemaAcademicoProfessorMS.src.Domain.Entities;
using SistemaAcademicoProfessorMS.src.Data;
using SistemaAcademicoProfessorMS.src.Domain.Repositories.Interfaces;
using SistemaAcademicoProfessorMS.src.Domain;
using SistemaAcademicoProfessorMS.src.Services.Interfaces;
using SistemaAcademicoProfessorMS.src.Factories;
using SistemaAcademicoProfessorMS.src.Factories.Interfaces;

namespace SistemaAcademicoProfessorMS.src.Services;

public class AtribuicaoAulaService : IAtribuicaoAulaService
{
    private IAtribuicaoAulaRepository _repository;
    private IAtribuicaoAulaFactory _atribuicaoAulaFactory;

    private ProfessorDbContext _context;

    public AtribuicaoAulaService(IAtribuicaoAulaRepository repository,
                                 IAtribuicaoAulaFactory AtribuicaoAulaFactory,
                                 ProfessorDbContext context
                                 )
    {
        this._repository = repository;

        this._atribuicaoAulaFactory = AtribuicaoAulaFactory;

        this._context = context;
    }

    public async Task<AtribuicaoAulaRetornoDTO> AddAtribuicaoAulaAsync(AtribuicaoAulaEnvioDTO atribuicaoAulaDTO)
    {
        var aulaAtribuida = _atribuicaoAulaFactory.CriarAtribuicaoAula(atribuicaoAulaDTO);

        await _repository.AddAsync(aulaAtribuida);

        AtribuicaoAulaBuscaDTO localizarAulaDTO = new()
        {
            CursoId = atribuicaoAulaDTO.CursoId,
            ProfessorId = atribuicaoAulaDTO.ProfessorId,
            DisciplinaId = atribuicaoAulaDTO.DisciplinaId
        };

        var retorno = await _repository.GetByIdAsync(localizarAulaDTO);

        var atribuicaoAulaRetornoDTO = _atribuicaoAulaFactory.CriarAtribuicaoAulaRetornoDTO(retorno);

        return atribuicaoAulaRetornoDTO;
    }

    public async Task<List<AtribuicaoAulaRetornoDTO>> GetAtribuicaoAulaByCursoIdAsync(int cursoId)
    {
        var retorno = await _repository.GetByCursoIdAsync(cursoId);

        List<AtribuicaoAulaRetornoDTO> lista = new();

        foreach (var g in retorno)
        {

            lista.Add(_atribuicaoAulaFactory.CriarAtribuicaoAulaRetornoDTO(g));
        }

        return lista;
    }

    public async Task<List<ProfessorDisciplinaRetornoDTO>> GetProfessoresRanqueadosAsync(List<int> TitulosId)
    {
        RanqueiaProfessor ranqueia = new RanqueiaProfessor(_context, TitulosId);

        var professores = await ranqueia.GetRanqueAsync();

        List<ProfessorDisciplinaRetornoDTO> professoresDTO = new List<ProfessorDisciplinaRetornoDTO>();

        foreach (var p in professores)
        {

            ProfessorDisciplinaRetornoDTO professor = new()
            {
                Id = p.Id,
                Nome = p.Nome,
                Pontuacao = p.Pontuacao
            };

            professoresDTO.Add(professor);
        }

        return professoresDTO;
    }

    public async Task<AtribuicaoAulaRetornoDTO> RemoverAtribuicaoAulaAsync(AtribuicaoAulaBuscaDTO atribuicaoAulaDTO)
    {
        var aula = await _repository.DeleteAsync(atribuicaoAulaDTO);

        return _atribuicaoAulaFactory.CriarAtribuicaoAulaRetornoDTO(aula);
    }
}