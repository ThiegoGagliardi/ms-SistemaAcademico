using Microsoft.EntityFrameworkCore;

using SistemaAcademicoProfessorMS.src.Domain.Entities;
using SistemaAcademicoProfessorMS.src.Data;
using SistemaAcademicoProfessorMS.src.Domain.Repositories.Interfaces;
using SistemaAcademicoProfessorMS.Domain.Enums;

namespace SistemaAcademicoProfessorMS.src.Domain.Repositories;

public class TitulosRepository : ITitulosRepository
{
    private readonly ProfessorDbContext _context;

    public TitulosRepository(ProfessorDbContext context)
    {
        this._context = context;
    }

    public async Task<Titulo> AddAsync(Titulo titulo)
    {
        var tituloLocate = await _context.Titulos
                                           .FirstOrDefaultAsync(f => f.Nome == titulo.Nome);

        if (tituloLocate != null)
            throw new Exception("Formação já existe.");

        await _context.Titulos.AddAsync(titulo);
        await _context.SaveChangesAsync();

        return titulo;
    }

    public async Task<Titulo> DeleteAsync(int id)
    {
        var TitulosLocate = await _context.Titulos.FirstOrDefaultAsync(f => f.Id == id);

        if (TitulosLocate == null)
            throw new Exception("Formação não localizado");

        _context.Titulos.Remove(TitulosLocate);
        await _context.SaveChangesAsync();

        return TitulosLocate;
    }

    public async Task<IEnumerable<Titulo>> GetAllAsync(int? pagina, int? quantidade)
    {
        pagina = pagina ?? 1;
        quantidade = quantidade ?? 10;

        return await this._context.Titulos                                 
                                  .Skip(((int)pagina - 1) * (int)quantidade)
                                  .Take((int)quantidade)
                                  .ToListAsync();
    }

    public async Task<Titulo> GetByIdAsync(int id)
    {
        var TitulosLocate = await _context.Titulos.FirstOrDefaultAsync(f => f.Id == id);

        if (TitulosLocate == null)
            throw new Exception("Formação não localizado");

        return TitulosLocate;
    }

    public async Task<IEnumerable<Titulo>> GetByNivelAsync(NivelTitulos nivel)
    {
        var Titulos = await _context.Titulos.Where(f => f.Nivel == nivel).ToListAsync();

        if (Titulos == null)
            throw new Exception("Formação não localizado");

        return Titulos;
    }

    public async Task<IEnumerable<Titulo>> GetByNomeAsync(string nome)
    {
        var TitulosLocate =  await  _context.Titulos.Where(f => f.Nome == nome).ToListAsync();

        if (TitulosLocate == null)
            throw new Exception("Formação não localizado");

        return TitulosLocate;
    }        

    public async Task<Titulo> UpdateAsync(Titulo titulos)
    {
        var TitulosLocate = await _context.Titulos.FirstOrDefaultAsync(f => f.Id == titulos.Id);

        if (TitulosLocate == null)
            throw new Exception("Formação não localizada.");

        TitulosLocate.Nome             = titulos.Nome;
        TitulosLocate.Instituicao      = titulos.Instituicao;
        TitulosLocate.AreaConhecimento = titulos.AreaConhecimento;
        TitulosLocate.Nivel            = titulos.Nivel;
        TitulosLocate.ValorPontuacao   = titulos.ValorPontuacao;

        _context.Titulos.Update(TitulosLocate);
        await _context.SaveChangesAsync();

        return TitulosLocate;
    }
}