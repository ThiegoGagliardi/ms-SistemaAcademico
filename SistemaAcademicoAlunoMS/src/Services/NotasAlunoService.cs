using SistemaAcademicoAlunoMS.src.Domain;
using SistemaAcademicoAlunoMS.src.Domain.Repositories.Interfaces;
using SistemaAcademicoAlunoMS.src.Factories.Interfaces;
using SistemaAcademicoAlunoMS.src.DTOs;
using SistemaAcademicoAlunoMS.Domain.Enums;
using SistemaAcademicoAlunoMS.src.Domain.Entities;
using SistemaAcademicoAlunoMS.src.Services.Interfaces;

namespace SistemaAcademicoAlunoMS.src.Services;

public class NotasAlunoService : INotasAlunoService
{
    private readonly INotasAlunoRepository _notasRepository;
    private readonly INotasAlunoFactory _notasFactory;
    private readonly IAlunoRepository _alunoRepository;

    public NotasAlunoService(INotasAlunoRepository notasRepository,
                             IAlunoRepository alunoRepository,
                             INotasAlunoFactory notasFactory)
    {
        this._notasRepository  = notasRepository;        
        this._notasFactory     = notasFactory;
        this._alunoRepository  = alunoRepository;
    }

    public async Task<AlunoNotaRetornoDTO> AddAsync(AlunoNotaEnvioDTO notaDTO)
    {
        var nota = _notasFactory.CriarNota(notaDTO);

        nota = await _notasRepository.AddAsync(nota);                                                         
         
        return _notasFactory.CriarNotaRetornoDTO(nota);
    }

    public async Task<IList<AlunoNotaRetornoDTO>> GetByAlunoIdAsync(int id)
    {
        var notas = await _notasRepository.GetByAlunoIdAsync(id);

        List<AlunoNotaRetornoDTO> notasDTO = new();

        foreach(var n in notas)
        {
            notasDTO.Add(_notasFactory.CriarNotaRetornoDTO(n));            
        }

        return notasDTO;
    }

    public async Task<AlunoNotaRetornoDTO> UpdateAsync(AlunoNotaEnvioDTO notaDTO)
    {
        var nota = _notasFactory.CriarNota(notaDTO);

        nota = await _notasRepository.UpdateAsync(nota);

        return _notasFactory.CriarNotaRetornoDTO(nota);
    } 

    public async Task<AlunoNotaRetornoDTO> DeleteAsync(AlunoNotaConsultaDTO notaDTO)
    {
        var nota = await _notasRepository.DeleteAsync(notaDTO);
        return _notasFactory.CriarNotaRetornoDTO(nota);
    }

    public async Task<List<AlunoCursoDisciplinaRetornoDTO>> FecharNotasAlunoAsync(int alunoId,int cursoId)
    {
        var aluno = await _alunoRepository.GetByIdAsync(alunoId);

        var notas = await _notasRepository.GetByAlunoIdAsync(alunoId);
        
        FecharMediaAluno mediaFinal =  new(aluno, cursoId, notas);
        var medias = mediaFinal.CalcularMediaFinal();

        List<AlunoCursoDisciplinaRetornoDTO> mediasRetorno = new();

        foreach (var m in medias)
        {          
           await _notasRepository.FechaMediaDisciplinaAsync(m);
           mediasRetorno.Add(_notasFactory.CriaMediaFinalRetorno(m));
        }       

        return mediasRetorno;
    }

    public async Task<List<AlunoCursoDisciplinaRetornoDTO>> FecharNotasCursoAsync(int CursoId)
    {
        var alunos = await _alunoRepository.GetByCursoId(CursoId);
        
        List<AlunoCursoDisciplinaRetornoDTO> mediasRetorno =  new();

        foreach (var a in alunos)
        {
            var notas = await _notasRepository.GetNotasByCursoIdAlunoId(CursoId, a.Id);
            FecharMediaAluno mediaFinal =  new(a, CursoId, notas);
            var medias = mediaFinal.CalcularMediaFinal();

           foreach (var m in medias) {

               await _notasRepository.FechaMediaDisciplinaAsync(m);
               mediasRetorno.Add(_notasFactory.CriaMediaFinalRetorno(m));
           }  
        }

        return mediasRetorno;
    }                     
}