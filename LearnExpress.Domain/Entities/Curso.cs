using System;
using System.Collections.Generic;

namespace LearnExpress.Domain.Entities;

public partial class Curso
{
    public int Id { get; set; }

    public string Titulo { get; set; } = null!;

    public string Professor { get; set; } = null!;

    public string Descricao { get; set; } = null!;

    public int HorasTotais { get; set; }

    public double Preco { get; set; }

    public virtual ICollection<Aula> Aulas { get; set; } = new List<Aula>();

    public virtual ICollection<Certificado> Certificados { get; set; } = new List<Certificado>();

    public virtual ICollection<Pedido> Pedidos { get; set; } = new List<Pedido>();

    public virtual ICollection<PorcentConcluCurso> PorcentConcluCursos { get; set; } = new List<PorcentConcluCurso>();

    public virtual ICollection<Categorium> Idcategoria { get; set; } = new List<Categorium>();

}
