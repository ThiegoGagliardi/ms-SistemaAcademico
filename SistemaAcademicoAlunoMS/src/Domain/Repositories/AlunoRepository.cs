using Microsoft.EntityFrameworkCore;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;

using SistemaAcademicoAlunoMS.src.Domain.Entities;
using SistemaAcademicoAlunoMS.src.Data;
using SistemaAcademicoAlunoMS.src.Domain.Repositories.Interfaces;
using SistemaAcademicoAlunoMS.src.DTOs;

namespace SistemaAcademicoAlunoMS.src.Domain.Repositories;

public class AlunoRepository : IAlunoRepository
{
    private AlunoDbContext _context;

    private readonly HttpClient _http;

    public AlunoRepository(AlunoDbContext context, HttpClient http)
    {
        this._context = context;
        _http = http;        
    }

    public async Task<Aluno> AddAsync(Aluno aluno)
    {
        var alunoLocate = await _context.Alunos
                                           .FirstOrDefaultAsync(a => a.Nome == aluno.Nome);

        if (alunoLocate != null)
            throw new Exception("Aluno já existe.");

        await _context.Alunos.AddAsync(aluno);
        await _context.SaveChangesAsync();

        return aluno;
    }

    public async Task<Aluno> MatricularAlunoCursoAsync(MatriculaAlunoCurso matricula)
    {
        var alunoLocate = await _context.Alunos
                                        .FirstOrDefaultAsync(a => a.Id == matricula.AlunoId);

        if (alunoLocate == null)
            throw new Exception("Aluno não localizado.");

        var matriculaLocate = alunoLocate.Matriculas.FirstOrDefault(m => m.CursoId == matricula.CursoId);

        if (matriculaLocate != null)
            throw new Exception("Aluno já matriculado.");

        alunoLocate.Matriculas.Add(matricula);
        
        var response  = await _http.GetAsync($"{matricula.CursoId}");
        response.EnsureSuccessStatusCode();

        var disciplinas = await response.Content.ReadFromJsonAsync<List<CursoDisciplinaRetornoDTO>>();

        foreach(var d in disciplinas)
        {
            AlunoCursoDisciplina disciplina = new()
            {
                AlunoId = matricula.AlunoId,
                CursoId = d.CursoId,
                DisciplinaId = d.DisciplinaId,

                NomeCurso = d.NomeCurso,
                NomeDisciplina = d.NomeDisciplina,
                SiglaDisciplina = d.SiglaDisciplina,

                DataInicio = matricula.DataInicio,
                DataFim    = matricula.DataInicio.AddMonths(6)               
            };

            alunoLocate.Disciplinas.Add(disciplina);                        
        }

        await _context.SaveChangesAsync();

        return alunoLocate;       
    }

    public async Task<Aluno> DeleteAsync(int id)
    {
        var alunoLocate = await _context.Alunos.FirstOrDefaultAsync(a => a.Id == id);

        if (alunoLocate == null)
            throw new Exception("Alunos não localizado");

        _context.Alunos.Remove(alunoLocate);
        await _context.SaveChangesAsync();

        return alunoLocate;
    }

    public async Task<IEnumerable<Aluno>> GetAllAsync(int? pagina, int? quantidade)
    {
        pagina = pagina ?? 1;
        quantidade = quantidade ?? 10;

        return await this._context.Alunos                                         
                                  .Skip(((int)pagina - 1) * (int)quantidade)
                                  .Take((int)quantidade)
                                  .ToListAsync();
    }

    public async Task<Aluno> GetByIdAsync(int id)
    {
        var alunoLocate = await _context.Alunos
                                        .Include(m => m.Matriculas)
                                        .Include(n => n.Notas)                                        
                                        .AsSplitQuery()
                                        .FirstOrDefaultAsync(a => a.Id == id);

        if (alunoLocate == null)
            throw new Exception("Aluno não localizado");

        return alunoLocate;
    }

    public async Task<IEnumerable<Aluno>> GetByNomeAsync(string nome)
    {
        var alunoLocalizado = await _context.Alunos.Where(a => a.Nome == nome).ToListAsync();

        if (alunoLocalizado == null)
            throw new Exception("Aluno não localizado");

        return alunoLocalizado;
    }  

    public async Task<IEnumerable<Aluno>> GetByCursoId(int cursoId)
    {
        var alunoLocalizado = await _context.Alunos
                                            .Include(m => m.Matriculas)
                                            .Where(a => a.Matriculas.Any(m => m.CursoId == cursoId))
                                            .AsSplitQuery()
                                            .ToListAsync();

        if (alunoLocalizado == null)
          throw new Exception("Aluno não localizado");

        return alunoLocalizado;        
    }

    public async Task<Aluno> UpdateAsync(Aluno aluno)
    {
        var alunoLocate = await _context.Alunos.FirstOrDefaultAsync(a => a.Id == aluno.Id);

        if (alunoLocate == null)
            throw new Exception("Aluno não localizado.");

        alunoLocate.Nome = aluno.Nome;
        alunoLocate.RA   = aluno.RA;
        
        _context.Alunos.Update(alunoLocate);
        await _context.SaveChangesAsync();

        return alunoLocate;
    }
}