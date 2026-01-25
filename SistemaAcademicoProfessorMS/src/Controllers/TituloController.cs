using Microsoft.AspNetCore.Mvc;
using System.Net;

using SistemaAcademicoProfessorMS.src.Services.Interfaces;
using SistemaAcademicoProfessorMS.src.DTOs;

namespace SistemaAcademicoProfessorMS.src.Controllers;

[ApiController]
[Route("api/[controller]")]

public class TitulosController : ControllerBase
{
    private readonly ITitulosService _titulosService;

    public TitulosController(ITitulosService titulosService)
    {
        this._titulosService = titulosService;        
    }
    
    [HttpPost]
    public async Task<ActionResult<TituloRetornoDTO>> AddAsync([FromBody] TituloEnvioDTO tituloDTO)
    {
        try
        {
            var result = await _titulosService.AddAsync(tituloDTO);
            return Ok(result);
        } catch (Exception E)
        {
            return StatusCode((int)HttpStatusCode.InternalServerError, new { message = E.Message });
        }
    }    

    [HttpGet("{id}")]
    public async Task<ActionResult<TituloRetornoDTO>> GetByIdAsync(int id)
    {
        try
        {
            var result = await _titulosService.GetByIdAsync(id);
            return Ok(result);
        } catch (Exception E)
        {
            return StatusCode((int)HttpStatusCode.InternalServerError, new { message = E.Message });
        }
    }

    [HttpGet("nome/{nome}")]
    public async Task<ActionResult<IEnumerable<TituloRetornoDTO>>> GetByNomeAsync(string nome)
    {
        try
        {
            var result = await _titulosService.GetByNomeAsync(nome);
            return Ok(result);
        } catch (Exception E)
        {
            return StatusCode((int)HttpStatusCode.InternalServerError, new { message = E.Message });
        }
    }

    [HttpGet("nivel/{nivel}")]
    public async Task<ActionResult<IEnumerable<TituloRetornoDTO>>> GetByNivelAsync(string nivel)
    {
        try
        {
            var result = await _titulosService.GetByNivelAsync(nivel);
            return Ok(result);
        } catch (Exception E)
        {
            return StatusCode((int)HttpStatusCode.InternalServerError, new { message = E.Message });
        }
    }      

   [HttpGet]
    public async Task<ActionResult<IEnumerable<TituloRetornoDTO>>> GetAllAsync([FromQuery] int? pagina, 
                                                                                  [FromQuery] int? quantidade)
    {
        try
        {
            var result = await _titulosService.GetAllAsync(pagina, quantidade);
            return Ok(result);
        } catch (Exception E)
        {
            return StatusCode((int)HttpStatusCode.InternalServerError, new { message = E.Message });
        }
    }    

    [HttpPut]
    public async Task<ActionResult<TituloRetornoDTO>> UpdateAsync([FromBody] TituloAtualizaDTO tituloDTO)
    {
        try
        {
            var result = await _titulosService.UpdateAsync(tituloDTO);
            return Ok(result);
        } catch (Exception E)
        {
            return StatusCode((int)HttpStatusCode.InternalServerError, new { message = E.Message });
        }
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<TituloRetornoDTO>> DeleteAsync(int id)
    {
        try
        {
            var result = await _titulosService.DeleteAsync(id);
            return Ok(result);
        } catch (Exception E)
        {
            return StatusCode((int)HttpStatusCode.InternalServerError, new { message = E.Message });
        }        
    }
}
