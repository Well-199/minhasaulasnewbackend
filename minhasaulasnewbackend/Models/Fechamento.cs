using System;
using System.Collections.Generic;

namespace minhasaulasnewbackend.Models;

public partial class Fechamento
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public decimal Valor { get; set; }

    public DateTime DataInicial { get; set; }

    public DateTime DataFinal { get; set; }

    public int Quantidade { get; set; }

    public DateTime Modified { get; set; }

    public DateTime Created { get; set; }
}
