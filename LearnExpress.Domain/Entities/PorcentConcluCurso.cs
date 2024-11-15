using System;
using System.Collections.Generic;

namespace LearnExpress.Domain.Entities;

public partial class PorcentConcluCurso
{
    public int? Porcentagem { get; set; }

    public int Idcurso { get; set; }

    public int Idusuario { get; set; }

    public virtual Curso IdcursoNavigation { get; set; } = null!;

    public virtual Usuario IdusuarioNavigation { get; set; } = null!;
}
