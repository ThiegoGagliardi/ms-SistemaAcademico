using Microsoft.EntityFrameworkCore;

using SistemaAcademicoProfessorMS.src.Domain.Entities;
using SistemaAcademicoProfessorMS.src.Data;
using SistemaAcademicoProfessorMS.src.Domain.Repositories.Interfaces;
using SistemaAcademicoProfessorMS.src.DTOs;

namespace SistemaAcademicoProfessorMS.src.Domain.Repositories;

public class AtribuicaoAulaRepository : IAtribuicaoAulaRepository
{
    private ProfessorDbContext _context;

    public AtribuicaoAulaRepository(ProfessorDbContext context)
    {
        this._context = context;
    }

    public async Task<AtribuicaoAula> AddAsync(AtribuicaoAula aula)
    {
        var aulaLocate = await _context.AtribuicaoAulas
                                           .FirstOrDefaultAsync(a => a.Dia  == aula.Dia &&
                                                                     a.CursoId == aula.CursoId &&
                                                                     a.HoraInicio == aula.HoraInicio);

        if (aulaLocate != null)
            throw new Exception("Horário já atribuido.");

        await _context.AtribuicaoAulas.AddAsync(aula);
        await _context.SaveChangesAsync();

        return aula;
    }

    public async Task<AtribuicaoAula> DeleteAsync(AtribuicaoAulaBuscaDTO aula)
    {
        var aulaLocate = await _context.AtribuicaoAulas
                                       .Include(p => p.Professor)
                                       .FirstOrDefaultAsync(a => a.CursoId == aula.CursoId &&
                                                            a.DisciplinaId == aula.DisciplinaId &&
                                                            a.ProfessorId == aula.ProfessorId);

        if (aulaLocate == null)
            throw new Exception("Aula não localizado");

        _context.AtribuicaoAulas.Remove(aulaLocate);
        await _context.SaveChangesAsync();

        return aulaLocate;
    }

    public async Task<IEnumerable<AtribuicaoAula>> GetAllAsync(int? pagina, int? quantidade)
    {
        pagina = pagina ?? 1;
        quantidade = quantidade ?? 10;

        return await this._context.AtribuicaoAulas                                 
                                  .Skip(((int)pagina - 1) * (int)quantidade)
                                  .Take((int)quantidade)
                                  .ToListAsync();
    }

    public async Task<AtribuicaoAula> GetByIdAsync(AtribuicaoAulaBuscaDTO aula)
    {
        var aulaLocate = await _context.AtribuicaoAulas
                                       .Include(p => p.Professor)
                                       .FirstOrDefaultAsync(a => a.CursoId == aula.CursoId &&
                                                                 a.DisciplinaId == aula.DisciplinaId &&
                                                                 a.ProfessorId == aula.ProfessorId);

        if (aulaLocate == null)
            throw new Exception("Aula não localizado");

        return aulaLocate;
    }

    public async Task<List<AtribuicaoAula>> GetByCursoIdAsync(int CursoId)
    {
        var aulaLocate = await _context.AtribuicaoAulas
                                       .Include(p => p.Professor)
                                       .Where(a => a.CursoId == CursoId).ToListAsync();

        if (aulaLocate == null)
            throw new Exception("Aula não localizado");
        
        return aulaLocate;  
    }    

    public Task<AtribuicaoAula> UpdateAsync(AtribuicaoAula entity)
    {
        throw new NotImplementedException();
    }
}