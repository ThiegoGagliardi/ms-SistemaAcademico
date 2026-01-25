using SistemaAcademicoAlunoMS.src.DTOs;
using SistemaAcademicoAlunoMS.src.Domain.Entities;
using SistemaAcademicoAlunoMS.src.Factories.Interfaces;

namespace SistemaAcademicoAlunoMS.src.Factories;

public class NotasAlunoFactory : INotasAlunoFactory
{
    public AlunoCursoDisciplinaNota CriarNota(AlunoNotaEnvioDTO notaDTO)
    {
        AlunoCursoDisciplinaNota nota = new()
        {
            AlunoId = notaDTO.AlunoId,
            CursoId = notaDTO.CursoId,
            DisciplinaId = notaDTO.DisciplinaId,
            Bimestre = notaDTO.Bimestre,
            Nota = notaDTO.Nota,
            Data = notaDTO.Data,
            Peso = notaDTO.Peso
        };

        return nota;
    }

    public AlunoNotaRetornoDTO CriarNotaRetornoDTO(AlunoCursoDisciplinaNota nota)
    {
        var curso = nota.Aluno.Matriculas.Where( m => m.CursoId == nota.CursoId).FirstOrDefault();

        var disciplina = nota.Aluno
                             .Disciplinas
                             .Where( d => d.CursoId == nota.CursoId &&
                                          d.DisciplinaId == nota.DisciplinaId
                             ).FirstOrDefault();

        AlunoNotaRetornoDTO notaDTO = new()
        {
            Aluno = nota.Aluno.Nome,
            Curso = curso.NomeCurso,
            Disciplina = disciplina.NomeDisciplina,
            Bimestre = nota.Bimestre,
            Nota = nota.Nota
        };

        return notaDTO;
    }

    public AlunoCursoDisciplinaRetornoDTO CriaMediaFinalRetorno(AlunoCursoDisciplina media)
    {
        var curso = media.Aluno.Matriculas.Where( m => m.CursoId == media.CursoId).FirstOrDefault();
        
        var disciplina = media.Aluno
                             .Disciplinas
                             .Where( d => d.CursoId == media.CursoId &&
                                          d.DisciplinaId == media.DisciplinaId
                             ).FirstOrDefault();

        var mediaFinal = new AlunoCursoDisciplinaRetornoDTO
        {
            Aluno = media.Aluno.Nome,

            Curso = curso.NomeCurso,

            Disciplina = disciplina.NomeDisciplina,           

            MediaFinal = media.MediaFinal.ToString(),

            Status = media.Status.ToString()
        };

        return mediaFinal;
    }
}