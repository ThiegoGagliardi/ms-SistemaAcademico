using SistemaAcademicoAlunoMS.src.DTOs;
using SistemaAcademicoAlunoMS.src.Domain.Entities;
using SistemaAcademicoAlunoMS.src.Factories.Interfaces;
using SistemaAcademicoAlunoMS.Domain.Enums;

namespace SistemaAcademicoAlunoMS.src.Factories;

public class AlunoFactory : IAlunoFactory
{
    public Aluno CriarAluno(AlunoEnvioDTO alunoDTO)
    {
        Aluno aluno = new()
        {
            Nome = alunoDTO.Nome,
            RA = alunoDTO.RA
        };

        return aluno;
    }

    public Aluno CriarAluno(AlunoEnvioAtualizaDTO alunoDTO)
    {
        Aluno aluno = new()
        {
            Id = alunoDTO.Id,
            Nome = alunoDTO.Nome,
            RA = alunoDTO.RA
        };

        return aluno;
    }

    public AlunoRetornoDTO CriarAlunoRetornoDTO(Aluno aluno)
    {
        AlunoRetornoDTO alunoDTO = new()
        {
            Id = aluno.Id,
            Nome = aluno.Nome,
            RA = aluno.RA
        };

        var cursos = aluno.Matriculas.DistinctBy(c => c.CursoId).ToList();

        foreach (var c in cursos)
        {
            alunoDTO.CursosMatriculados.Add(c.NomeCurso);
        }

        var Disciplinas = aluno.Matriculas.DistinctBy(c => c.CursoId).ToList();

        foreach (var d in aluno.Disciplinas)
        {
            var curso = aluno.Matriculas.Where(c => c.CursoId == d.CursoId).FirstOrDefault();

            AlunoCursoDisciplinaRetornoDTO disciplinaDTO = new()
            {
                Disciplina = d.NomeDisciplina,
                SiglaDisciplina  = d.SiglaDisciplina,
                Curso = curso.NomeCurso                
            };

            alunoDTO.GradeHoraria.Add(disciplinaDTO);
        }

        return alunoDTO;
    }

}
