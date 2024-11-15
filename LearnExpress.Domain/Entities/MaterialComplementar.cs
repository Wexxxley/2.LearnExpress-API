using System;
using System.Collections.Generic;

namespace LearnExpress.Domain.Entities;

public partial class MaterialComplementar
{
    public int Id { get; set; }

    public string Link { get; set; } = null!;

    public string Descricao { get; set; } = null!;

    public int? Idaula { get; set; }

    public string Tipo { get; set; } = null!;

    public virtual Aula? IdaulaNavigation { get; set; }

    public virtual ICollection<NotaMaterialComplementar> NotaMaterialComplementars { get; set; } = new List<NotaMaterialComplementar>();
}
