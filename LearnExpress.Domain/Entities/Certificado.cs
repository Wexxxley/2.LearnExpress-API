using System;
using System.Collections.Generic;

namespace LearnExpress.Domain.Entities;

public partial class Certificado
{
    public int Id { get; set; }

    public DateOnly DataEmissao { get; set; }

    public int? Idusuario { get; set; }

    public int? Idcurso { get; set; }

    public virtual Curso? IdcursoNavigation { get; set; }

    public virtual Usuario? IdusuarioNavigation { get; set; }
}
