using System;
using System.Collections.Generic;

namespace LearnExpress.Domain.Entities;

public partial class Aula
{
    public int Id { get; set; }

    public string Titulo { get; set; } = null!;

    public string Descricao { get; set; } = null!;

    public int Duração { get; set; }

    public string Link { get; set; } = null!;

    public int? Idcurso { get; set; }

    public virtual ICollection<Comentario> Comentarios { get; set; } = new List<Comentario>();

    public virtual Curso? IdcursoNavigation { get; set; }

    public virtual ICollection<MaterialComplementar> MaterialComplementars { get; set; } = new List<MaterialComplementar>();
}
