using Microsoft.EntityFrameworkCore;

using SistemaAcademicoProfessorMS.src.DTOs;
using SistemaAcademicoProfessorMS.src.Domain.Entities;
using SistemaAcademicoProfessorMS.src.Data;
using SistemaAcademicoProfessorMS.src.Domain.Repositories.Interfaces;

namespace SistemaAcademicoProfessorMS.src.Domain.Repositories;

public class ProfessorRepository : IProfessorRepository
{
    private ProfessorDbContext _context;

    public ProfessorRepository(ProfessorDbContext context)
    {
        this._context = context;
    }

    public async Task<Professor> AddAsync(Professor professor)
    {
        var professorLocate = await _context.Professores
                                           .Include(pf => pf.Titulos)
                                           .ThenInclude(f => f.Titulo)
                                           .FirstOrDefaultAsync(p => p.RegistroMec == professor.RegistroMec);

        if (professorLocate != null)
            throw new Exception("Professor já existe.");

        await _context.Professores.AddAsync(professor);
        await _context.SaveChangesAsync();

        return professor;
    }

    public async Task<Professor> AdicionarTitulosProfessorAsync(ProfessorTitulo professorTitulo)
    {
        var professorLocate = await _context.Professores
                                           .Include(pf => pf.Titulos)
                                           .ThenInclude(f => f.Titulo)
                                           .FirstOrDefaultAsync(p => p.Id == professorTitulo.ProfessorId);

        if (professorLocate == null)
            throw new Exception("Professor não localizado.");

        var TitulosLocate = professorLocate.Titulos.FirstOrDefault(f => f.TitulosId == professorTitulo.TitulosId);

        if (TitulosLocate != null)
            throw new Exception("Formação já adicionada para o professor.");

        professorLocate.Titulos.Add(professorTitulo);
        await _context.SaveChangesAsync();

        return professorLocate;       
    }

    public async Task<Professor> DeleteAsync(int id)
    {
        var professorLocate = await _context.Professores.FirstOrDefaultAsync(p => p.Id == id);

        if (professorLocate == null)
            throw new Exception("Professor não localizado");

        _context.Professores.Remove(professorLocate);
        await _context.SaveChangesAsync();

        return professorLocate;
    }

    public async Task<IEnumerable<Professor>> GetAllAsync(int? pagina, int? quantidade)
    {
        pagina = pagina ?? 1;
        quantidade = quantidade ?? 10;

        return await this._context.Professores                                 
                                  .Skip(((int)pagina - 1) * (int)quantidade)
                                  .Take((int)quantidade)
                                  .ToListAsync();
    }

    public async Task<Professor> GetByIdAsync(int id)
    {
        var professorLocate = await _context.Professores
                                            .Include(f => f.Titulos)
                                            .ThenInclude(f => f.Titulo)
                                            .FirstOrDefaultAsync(p => p.Id == id);

        if (professorLocate == null)
            throw new Exception("Professor não localizado");

        return professorLocate;
    }

    public async Task<Professor> GetByRegistroMecAsync(string registroMec)
    {
        var professor = await _context.Professores
                                           .FirstOrDefaultAsync(p => p.RegistroMec == registroMec);

        if (professor == null)
            throw new Exception("Professor não localizado.");

        return professor;
    }
    public async Task<Professor> UpdateAsync(Professor professor)
    {
        var professorLocate = await _context.Professores.FirstOrDefaultAsync(p => p.Id == professor.Id);

        if (professorLocate == null)
            throw new Exception("Professor não localizado.");

        professorLocate.Nome = professor.Nome;
        professorLocate.RegistroMec = professor.RegistroMec;

        _context.Professores.Update(professorLocate);
        await _context.SaveChangesAsync();

        return professorLocate;
    }
}