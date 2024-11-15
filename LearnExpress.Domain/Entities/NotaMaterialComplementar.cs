using System;
using System.Collections.Generic;

namespace LearnExpress.Domain.Entities;

public partial class NotaMaterialComplementar
{
    public int Nota { get; set; }

    public int Idmaterial { get; set; }

    public int Idusuario { get; set; }

    public virtual MaterialComplementar IdmaterialNavigation { get; set; } = null!;

    public virtual Usuario IdusuarioNavigation { get; set; } = null!;
}
