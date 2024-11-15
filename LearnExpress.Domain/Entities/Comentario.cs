using System;
using System.Collections.Generic;

namespace LearnExpress.Domain.Entities;

public partial class Comentario
{
    public int Id { get; set; }

    public string Conteudo { get; set; } = null!;

    public int? Idaula { get; set; }

    public int? Idusuario { get; set; }

    public virtual Aula? IdaulaNavigation { get; set; }

    public virtual Usuario? IdusuarioNavigation { get; set; }
}
