using SistemaAcademicoAlunoMS.src.DTOs;
using SistemaAcademicoAlunoMS.src.Domain.Entities;

namespace SistemaAcademicoAlunoMS.src.Factories.Interfaces;

public interface INotasAlunoFactory
{
    AlunoCursoDisciplinaNota CriarNota(AlunoNotaEnvioDTO notaDTO);

    AlunoNotaRetornoDTO CriarNotaRetornoDTO(AlunoCursoDisciplinaNota nota);

    AlunoCursoDisciplinaRetornoDTO CriaMediaFinalRetorno(AlunoCursoDisciplina media);
}
