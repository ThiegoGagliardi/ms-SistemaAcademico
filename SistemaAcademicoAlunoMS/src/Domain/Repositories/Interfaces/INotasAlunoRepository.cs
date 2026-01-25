using SistemaAcademicoAlunoMS.src.Domain.Entities;
using SistemaAcademicoAlunoMS.src.DTOs;
using SistemaAcademicoAlunoMS.Domain.Enums;

namespace SistemaAcademicoAlunoMS.src.Domain.Repositories.Interfaces;

public interface INotasAlunoRepository
{
    Task<AlunoCursoDisciplinaNota> AddAsync(AlunoCursoDisciplinaNota notaDTO);
    Task<IList<AlunoCursoDisciplinaNota>> GetByAlunoIdAsync(int id);
    Task<AlunoCursoDisciplinaNota> UpdateAsync(AlunoCursoDisciplinaNota nota);
    Task<AlunoCursoDisciplinaNota> DeleteAsync(AlunoNotaConsultaDTO notaDTO);
    Task<AlunoCursoDisciplina> FechaMediaDisciplinaAsync(AlunoCursoDisciplina disciplina);
    Task<IList<AlunoCursoDisciplinaNota>> GetNotasByCursoIdAlunoId(int cursoId, int alunoId);
}