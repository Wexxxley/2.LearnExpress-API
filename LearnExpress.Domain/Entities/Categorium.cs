using System;
using System.Collections.Generic;

namespace LearnExpress.Domain.Entities;

public partial class Categorium
{
    public int Id { get; set; }

    public string? Descricao { get; set; }

    public virtual ICollection<Curso> Idcursos { get; set; } = new List<Curso>();
}
