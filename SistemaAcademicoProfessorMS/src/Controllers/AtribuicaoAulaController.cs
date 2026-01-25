using Microsoft.AspNetCore.Mvc;
using System.Net;

using SistemaAcademicoProfessorMS.src.Services.Interfaces;
using SistemaAcademicoProfessorMS.src.DTOs;

namespace SistemaAcademicoProfessorMS.src.Controllers;

[ApiController]
[Route("api/[controller]")]

public class AtribuicaoAulaController : ControllerBase
{
    private readonly IAtribuicaoAulaService _atribuicaoAulaService;

    public AtribuicaoAulaController(IAtribuicaoAulaService atribuicaoAulaService)
    {
        this._atribuicaoAulaService = atribuicaoAulaService;        
    }

    [HttpGet("curso/id")]
    public async Task<ActionResult<List<AtribuicaoAulaRetornoDTO>>> GetAtribuicaoAulaCursoIdAsync(int Id)
    {
        try
        {            
            var result = await _atribuicaoAulaService.GetAtribuicaoAulaByCursoIdAsync(Id);
            
            return Ok(result);
        } catch (Exception E)
        {
            return StatusCode((int)HttpStatusCode.InternalServerError, new { message = E.Message });
        }
    }    

    [HttpGet("ProfessoresRanqueados")]
    public async Task<ActionResult<ProfessorDisciplinaRetornoDTO>> GetProfessorRanqueadoAsync([FromQuery]List<int> tituloId)
    {
        try
        {            
            var result = await _atribuicaoAulaService.GetProfessoresRanqueadosAsync(tituloId);
            
            return Ok(result);
        } catch (Exception E)
        {
            return StatusCode((int)HttpStatusCode.InternalServerError, new { message = E.Message });
        }
    }

    [HttpPost]
    public async Task<ActionResult<ProfessorRetornoDTO>> AddAtribuicaoAulaAsync([FromBody] AtribuicaoAulaEnvioDTO atribuicaoAulaDTO)
    {
        try
        {
            var result = await _atribuicaoAulaService.AddAtribuicaoAulaAsync(atribuicaoAulaDTO);
            return Ok(result);
        } catch (Exception E)
        {
            return StatusCode((int)HttpStatusCode.InternalServerError, new { message = E.Message });
        }
    }

    [HttpDelete]
    public async Task<ActionResult<ProfessorRetornoDTO>> RemoveAtribuicaoAulaAsync([FromBody] AtribuicaoAulaBuscaDTO atribuicaoAulaDTO)
    {
        try
        {
            var result = await _atribuicaoAulaService.RemoverAtribuicaoAulaAsync(atribuicaoAulaDTO);
            return Ok(result);
        } catch (Exception E)
        {
            return StatusCode((int)HttpStatusCode.InternalServerError, new { message = E.Message });
        }
    }          

}