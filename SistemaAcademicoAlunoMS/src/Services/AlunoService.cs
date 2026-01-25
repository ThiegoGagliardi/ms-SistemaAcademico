using Microsoft.EntityFrameworkCore;

using SistemaAcademicoAlunoMS.src.DTOs;
using SistemaAcademicoAlunoMS.src.Domain.Entities;
using SistemaAcademicoAlunoMS.src.Domain.Enum;
using SistemaAcademicoAlunoMS.src.Data;
using SistemaAcademicoAlunoMS.src.Domain.Repositories.Interfaces;
using SistemaAcademicoAlunoMS.src.Services.Interfaces;
using SistemaAcademicoAlunoMS.src.Factories;
using SistemaAcademicoAlunoMS.src.Factories.Interfaces;

namespace SistemaAcademicoAlunoMS.src.Services;

public class AlunoService : IAlunoService
{

    private readonly IAlunoRepository _alunoRepository;
    private readonly IAlunoFactory _alunoFactory;

    public AlunoService(IAlunoRepository alunoRepository,
                        IAlunoFactory factory)
    {
        this._alunoRepository   = alunoRepository;
        this._alunoFactory      = factory;
    }

    public async Task<AlunoRetornoDTO> AddAsync(AlunoEnvioDTO alunoDTO)
    {
        var novoAluno = _alunoFactory.CriarAluno(alunoDTO);

        novoAluno = await _alunoRepository.AddAsync(novoAluno);
         
        return _alunoFactory.CriarAlunoRetornoDTO(novoAluno);       
    }

    public async Task<AlunoRetornoDTO> AddMatriculaAlunoAsync(AlunoMatriculaDTO alunoDTO)
    {
         MatriculaAlunoCurso matricula = new()
         {
             CursoId = alunoDTO.CursoId,
             AlunoId = alunoDTO.AlunoId,
             DataInicio = DateOnly.Parse(alunoDTO.DataInicio),
             DataFim = DateOnly.Parse(alunoDTO.DataFim),
             Status  = (StatusAlunoCurso)Enum.Parse(typeof(StatusAlunoCurso), alunoDTO.Status, true)
         };

        var novoAluno = await _alunoRepository.MatricularAlunoCursoAsync(matricula);
         
        return _alunoFactory.CriarAlunoRetornoDTO(novoAluno);       
    }    

    public async Task<AlunoRetornoDTO> GetByIdAsync(int id)
    {
        var aluno = await _alunoRepository.GetByIdAsync(id);

        return _alunoFactory.CriarAlunoRetornoDTO(aluno);
    }
  
    public async Task<ICollection<AlunoRetornoDTO>> GetAllAsync(int? pagina, int? quantidade)
    {
        var alunos = await _alunoRepository.GetAllAsync(pagina, quantidade);

        ICollection<AlunoRetornoDTO> alunosDTOs = new List<AlunoRetornoDTO>();

        foreach (var aluno in alunos)
        {
            alunosDTOs.Add( _alunoFactory.CriarAlunoRetornoDTO(aluno));
        }

        return alunosDTOs;        
    }
    public async Task<ICollection<AlunoRetornoDTO>> GetByNomeAsync(string nome)
    {
        var alunos = await _alunoRepository.GetByNomeAsync(nome);

        ICollection<AlunoRetornoDTO> alunosDTOs = new List<AlunoRetornoDTO>();

        foreach (var aluno in alunos)
        {
            alunosDTOs.Add(_alunoFactory.CriarAlunoRetornoDTO(aluno));
        }

        return alunosDTOs;
    }

    public async Task<AlunoRetornoDTO> UpdateAsync(AlunoEnvioAtualizaDTO alunoDTO)
    {
        var aluno = _alunoFactory.CriarAluno(alunoDTO);

        aluno = await _alunoRepository.UpdateAsync(aluno);

        return _alunoFactory.CriarAlunoRetornoDTO(aluno);
    }

    public async Task<AlunoRetornoDTO> DeleteAsync(int id)
    {
        var aluno =  await _alunoRepository.DeleteAsync(id);
        return _alunoFactory.CriarAlunoRetornoDTO(aluno);
    }
}