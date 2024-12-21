using System;
using System.Collections.Generic;

namespace minhasaulasnewbackend.Models;

public partial class Aula
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public string Escola { get; set; } = null!;

    public DateTime Data { get; set; }

    public TimeOnly HoraInicial { get; set; }

    public TimeOnly HoraFinal { get; set; }

    public string? Turma { get; set; }

    public string? Conteudo { get; set; }

    public decimal? Valor { get; set; }

    public DateTime Modified { get; set; }

    public DateTime Created { get; set; }

    public string TotalHoras { get; set; } = null!;
}
