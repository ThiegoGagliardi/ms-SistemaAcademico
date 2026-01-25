using Microsoft.EntityFrameworkCore;

using SistemaAcademicoCursoMS.src.Domain.Entities;
using SistemaAcademicoCursoMS.src.Data;
using SistemaAcademicoCursoMS.src.Domain.Repositories.Interfaces;
using SistemaAcademicoCursoMS.src.Domain.Enum;
using SistemaAcademicoCursoMS.Domain.Enums;

namespace SistemaAcademicoCursoMS.src.Domain.Repositories;

public class FormacaoRepository : IFormacaoRepository
{
    private readonly CursoDbContext _context;

    public FormacaoRepository(CursoDbContext context)
    {
        this._context = context;
    }

    public async Task<Formacao> AddAsync(Formacao formacao)
    {
        var formacaoLocate = await _context.Formacoes
                                           .FirstOrDefaultAsync(f => f.Nome == formacao.Nome);

        if (formacaoLocate != null)
            throw new Exception("Formação já existe.");

        await _context.Formacoes.AddAsync(formacao);
        await _context.SaveChangesAsync();

        return formacao;
    }

    public async Task<Formacao> DeleteAsync(int id)
    {
        var formacoesLocate = await _context.Formacoes.FirstOrDefaultAsync(f => f.Id == id);

        if (formacoesLocate == null)
            throw new Exception("Formação não localizado");

        _context.Formacoes.Remove(formacoesLocate);
        await _context.SaveChangesAsync();

        return formacoesLocate;
    }

    public async Task<IEnumerable<Formacao>> GetAllAsync(int? pagina, int? quantidade)
    {
        pagina = pagina ?? 1;
        quantidade = quantidade ?? 10;

        return await this._context.Formacoes                                 
                                  .Skip(((int)pagina - 1) * (int)quantidade)
                                  .Take((int)quantidade)
                                  .ToListAsync();
    }

    public async Task<Formacao> GetByIdAsync(int id)
    {
        var formacoesLocate = await _context.Formacoes.FirstOrDefaultAsync(f => f.Id == id);

        if (formacoesLocate == null)
            throw new Exception("Formação não localizado");

        return formacoesLocate;
    }

    public async Task<IEnumerable<Formacao>> GetByNivelAsync(NivelFormacao nivel)
    {
        var formacoes = await _context.Formacoes.Where(f => f.Nivel == nivel).ToListAsync();

        if (formacoes == null)
            throw new Exception("Formação não localizado");

        return formacoes;
    }

    public async Task<IEnumerable<Formacao>> GetByNomeAsync(string nome)
    {
        var formacoesLocate =  await  _context.Formacoes.Where(f => f.Nome == nome).ToListAsync();

        if (formacoesLocate == null)
            throw new Exception("Formação não localizado");

        return formacoesLocate;
    }        

    public async Task<Formacao> UpdateAsync(Formacao formacao)
    {
        var formacoesLocate = await _context.Formacoes.FirstOrDefaultAsync(f => f.Id == formacao.Id);

        if (formacoesLocate == null)
            throw new Exception("Formação não localizada.");

        formacoesLocate.Nome             = formacao.Nome;
        formacoesLocate.AreaConhecimento = formacao.AreaConhecimento;
        formacoesLocate.Nivel            = formacao.Nivel;

        _context.Formacoes.Update(formacoesLocate);
        await _context.SaveChangesAsync();

        return formacoesLocate;
    }
}