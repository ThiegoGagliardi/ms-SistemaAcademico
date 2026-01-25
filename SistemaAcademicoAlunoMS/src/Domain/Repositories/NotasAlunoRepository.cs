using Microsoft.EntityFrameworkCore;

using SistemaAcademicoAlunoMS.src.Domain.Entities;
using SistemaAcademicoAlunoMS.src.Data;
using SistemaAcademicoAlunoMS.src.Domain.Repositories.Interfaces;
using SistemaAcademicoAlunoMS.src.DTOs;
using SistemaAcademicoAlunoMS.src.Domain.Enum;
using SistemaAcademicoAlunoMS.Domain.Enums;

namespace SistemaAcademicoAlunoMS.src.Domain.Repositories;

public class NotasAlunoRepository : INotasAlunoRepository
{
    private readonly AlunoDbContext _context;    

    public NotasAlunoRepository(AlunoDbContext context)
    {
         this._context = context;       
    }

    public async Task<AlunoCursoDisciplinaNota> AddAsync(AlunoCursoDisciplinaNota nota)
    {
        var notaLocate = await _context.Notas.FirstOrDefaultAsync(n => n.AlunoId == nota.AlunoId &&
                                                                       n.CursoId == nota.CursoId &&
                                                                       n.DisciplinaId == nota.DisciplinaId &&
                                                                       n.Bimestre == nota.Bimestre
                                                                       );

        if (notaLocate != null)
            throw new Exception("Nota já lançada.");

        await _context.Notas.AddAsync(nota);
        await _context.SaveChangesAsync();

        notaLocate = await _context.Notas
                                   .Include(a => a.Aluno)
                                   .FirstOrDefaultAsync(n => n.AlunoId == nota.AlunoId &&
                                                        n.CursoId == nota.CursoId &&
                                                        n.DisciplinaId == nota.DisciplinaId&&
                                                        n.Bimestre == nota.Bimestre);
        return notaLocate;
    }

    public async Task<AlunoCursoDisciplinaNota> UpdateAsync(AlunoCursoDisciplinaNota nota)
    {
        var notaLocate = await _context.Notas
                                       .Include(a => a.Aluno)   
                                       .FirstOrDefaultAsync(n => n.AlunoId == nota.AlunoId &&
                                                            n.CursoId == nota.CursoId &&
                                                            n.DisciplinaId == nota.DisciplinaId &&
                                                            n.Bimestre == nota.Bimestre);

        if (notaLocate is null)
            throw new Exception("Nota não lançada.");

        notaLocate.Nota = nota.Nota;
        notaLocate.Data = nota.Data;
        notaLocate.Peso = nota.Peso;

        _context.Notas.Update(notaLocate);
        await _context.SaveChangesAsync();

        return notaLocate;
    }

    public async Task<IList<AlunoCursoDisciplinaNota>> GetByAlunoIdAsync(int id)
    {
        var notasLocate = await _context.Notas
                                       .Include(a => a.Aluno)
                                       .Where(n => n.AlunoId == id).ToListAsync();

        if (notasLocate is null)
            throw new Exception("Nota não lançada.");                                                                  

        return notasLocate;        
    }

    public async Task<IList<AlunoCursoDisciplinaNota>> GetNotasByCursoIdAlunoId(int cursoId, int alunoId)
    {
        var notasLocate = await _context.Notas
                                       .Include(a => a.Aluno)
                                       .Where(n => n.CursoId == cursoId &&
                                                   n.AlunoId == alunoId).ToListAsync();

        if (notasLocate is null)
            throw new Exception("Nota não lançada.");                                                                  

        return notasLocate;        
    }    

    public async Task<AlunoCursoDisciplina> FechaMediaDisciplinaAsync(AlunoCursoDisciplina disciplina)
    {
        var aluno = await _context.Alunos
                                   .Include(d => d.Disciplinas)
                                   .FirstOrDefaultAsync(a => a.Id == disciplina.AlunoId);

        if (aluno is null)
            throw new Exception("Aluno não localizada.");
        
        var disciplinaLocate = aluno.Disciplinas.FirstOrDefault(d => d.CursoId  == disciplina.CursoId &&
                                                                     d.DisciplinaId == disciplina.DisciplinaId);

        if (aluno is null)
            throw new Exception("Discplina não localizada.");                                                                     


        disciplinaLocate.MediaFinal  = disciplina.MediaFinal;

        _context.Medias.Update(disciplinaLocate);
        await _context.SaveChangesAsync();

        return disciplinaLocate;     
    }      

    public async Task<AlunoCursoDisciplinaNota> DeleteAsync(AlunoNotaConsultaDTO nota)
    {
        var notaLocate = await _context.Notas
                                       .Include(a => a.Aluno)     
                                       .FirstOrDefaultAsync(n => n.AlunoId == nota.AlunoId &&
                                                            n.CursoId == nota.CursoId &&
                                                            n.DisciplinaId == nota.DisciplinaId &&
                                                            n.Bimestre == nota.Bimestre);

        if (notaLocate is null)
            throw new Exception("Nota não lançada.");
        
        _context.Notas.Remove(notaLocate);
        await _context.SaveChangesAsync();

        return notaLocate;
    }      

}