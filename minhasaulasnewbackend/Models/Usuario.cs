using System;
using System.Collections.Generic;

namespace minhasaulasnewbackend.Models;

public partial class Usuario
{
    public int Id { get; set; }

    public string Nome { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Senha { get; set; } = null!;

    public string Device { get; set; } = null!;

    public string Token { get; set; } = null!;

    public decimal ValorHora { get; set; }

    public DateTime Modified { get; set; }

    public DateTime Created { get; set; }

    public string CodCli { get; set; } = null!;
}
