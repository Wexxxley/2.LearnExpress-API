using System;
using System.Collections.Generic;

namespace LearnExpress.Domain.Entities;

public partial class Pedido
{
    public int Id { get; set; }

    public int? Idcurso { get; set; }

    public int? Idusuario { get; set; }

    public DateOnly Data { get; set; }

    public virtual Curso? IdcursoNavigation { get; set; }

    public virtual Usuario? IdusuarioNavigation { get; set; }
}
