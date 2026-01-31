
using System.Text.Json;
using System.Text.Json.Serialization;
using System;

namespace SistemaAcademicoAlunoMS.src.DTOs;

public class DisciplinaRetornoDTO
{
    public int Id { get; set; }

    public string Nome { get; set; } = string.Empty;      

    public string Codigo { get; set; } = string.Empty;

    public string Sigla { get; set; } = string.Empty;

    public string AreaConhecimento { get; set; } = string.Empty;  
}
