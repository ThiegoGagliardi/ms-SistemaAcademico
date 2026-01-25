
using Microsoft.EntityFrameworkCore;

using SistemaAcademicoProfessorMS.src.Domain.Entities;
using SistemaAcademicoProfessorMS.src.Data;

namespace SistemaAcademicoProfessorMS.src.Domain;

public class RanqueiaProfessor
{
    private IList<int> _titulosIds;

    private ProfessorDbContext _context;

    private IList<Professor> professores = new List<Professor>();

    public RanqueiaProfessor(ProfessorDbContext context, List<int> titulosIds)
    {
        _context = context;
        _titulosIds = titulosIds;
    }

    public async Task<IList<Professor>> GetRanqueAsync()
    {

        var titulos = await  _context.Titulos.Include(f => f.Professores)
                                                  .ThenInclude(pf => pf.Professor)  
                                                  .Where(f => _titulosIds.Contains(f.Id))
                                                  .ToListAsync();
        foreach (var f in titulos)
        {
            foreach (var p in f.Professores)
            {
                if (p.Professor is null)
                {
                    continue;
                }

                p.Professor.AtualizarPotuacao();
                professores.Add(p.Professor);
            }
        }

        return professores.OrderByDescending(r => r.Pontuacao).DistinctBy(p => p.Id).ToList();
    }
}