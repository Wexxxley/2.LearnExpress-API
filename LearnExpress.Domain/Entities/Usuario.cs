using System;
using System.Collections.Generic;

namespace LearnExpress.Domain.Entities;

public partial class Usuario
{
    public int Id { get; set; }

    public string Nome { get; set; } = null!;

    public string? Email { get; set; }

    public string? Senha { get; set; }

    public virtual ICollection<Certificado> Certificados { get; set; } = new List<Certificado>();

    public virtual ICollection<Comentario> Comentarios { get; set; } = new List<Comentario>();

    public virtual ICollection<NotaMaterialComplementar> NotaMaterialComplementars { get; set; } = new List<NotaMaterialComplementar>();

    public virtual ICollection<Pedido> Pedidos { get; set; } = new List<Pedido>();

    public virtual ICollection<PorcentConcluCurso> PorcentConcluCursos { get; set; } = new List<PorcentConcluCurso>();
}
