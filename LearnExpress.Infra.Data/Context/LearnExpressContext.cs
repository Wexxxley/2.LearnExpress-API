using System;
using System.Collections.Generic;
using LearnExpress.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace LearnExpress.Infra.Data.Context;

public partial class LearnExpressContext : DbContext
{
    public LearnExpressContext()
    {
    }

    public LearnExpressContext(DbContextOptions<LearnExpressContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Aula> Aulas { get; set; }

    public virtual DbSet<Categorium> Categoria { get; set; }

    public virtual DbSet<Certificado> Certificados { get; set; }

    public virtual DbSet<Comentario> Comentarios { get; set; }

    public virtual DbSet<Curso> Cursos { get; set; }

    public virtual DbSet<MaterialComplementar> MaterialComplementars { get; set; }

    public virtual DbSet<NotaMaterialComplementar> NotaMaterialComplementars { get; set; }

    public virtual DbSet<Pedido> Pedidos { get; set; }

    public virtual DbSet<PorcentConcluCurso> PorcentConcluCursos { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=localhost;Database=LearnExpress;Username=postgres;Password=Wfrso2022");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Aula>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("aula_pkey");

            entity.ToTable("aula", "learnexpress");

            entity.HasIndex(e => e.Link, "aula_link_key").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Descricao).HasColumnName("descricao");
            entity.Property(e => e.Duração).HasColumnName("duração");
            entity.Property(e => e.Idcurso).HasColumnName("idcurso");
            entity.Property(e => e.Link)
                .HasMaxLength(100)
                .HasColumnName("link");
            entity.Property(e => e.Titulo)
                .HasMaxLength(50)
                .HasColumnName("titulo");

            entity.HasOne(d => d.IdcursoNavigation).WithMany(p => p.Aulas)
                .HasForeignKey(d => d.Idcurso)
                .HasConstraintName("aula_idcurso_fkey");
        });

        modelBuilder.Entity<Categorium>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("categoria_pkey");

            entity.ToTable("categoria", "learnexpress");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Descricao).HasColumnName("descricao");

            entity.HasMany(d => d.Idcursos).WithMany(p => p.Idcategoria)
                .UsingEntity<Dictionary<string, object>>(
                    "IdcursoCategorium",
                    r => r.HasOne<Curso>().WithMany()
                        .HasForeignKey("Idcurso")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("idcurso_categoria_idcurso_fkey"),
                    l => l.HasOne<Categorium>().WithMany()
                        .HasForeignKey("Idcategoria")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("idcurso_categoria_idcategoria_fkey"),
                    j =>
                    {
                        j.HasKey("Idcategoria", "Idcurso").HasName("idcurso_categoria_pkey");
                        j.ToTable("idcurso_categoria", "learnexpress");
                        j.IndexerProperty<int>("Idcategoria").HasColumnName("idcategoria");
                        j.IndexerProperty<int>("Idcurso").HasColumnName("idcurso");
                    });
        });

        modelBuilder.Entity<Certificado>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("certificado_pkey");

            entity.ToTable("certificado", "learnexpress");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.DataEmissao).HasColumnName("data_emissao");
            entity.Property(e => e.Idcurso).HasColumnName("idcurso");
            entity.Property(e => e.Idusuario).HasColumnName("idusuario");

            entity.HasOne(d => d.IdcursoNavigation).WithMany(p => p.Certificados)
                .HasForeignKey(d => d.Idcurso)
                .HasConstraintName("certificado_idcurso_fkey");

            entity.HasOne(d => d.IdusuarioNavigation).WithMany(p => p.Certificados)
                .HasForeignKey(d => d.Idusuario)
                .HasConstraintName("certificado_idusuario_fkey");
        });

        modelBuilder.Entity<Comentario>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("comentario_pkey");

            entity.ToTable("comentario", "learnexpress");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Conteudo).HasColumnName("conteudo");
            entity.Property(e => e.Idaula).HasColumnName("idaula");
            entity.Property(e => e.Idusuario).HasColumnName("idusuario");

            entity.HasOne(d => d.IdaulaNavigation).WithMany(p => p.Comentarios)
                .HasForeignKey(d => d.Idaula)
                .HasConstraintName("comentario_idaula_fkey");

            entity.HasOne(d => d.IdusuarioNavigation).WithMany(p => p.Comentarios)
                .HasForeignKey(d => d.Idusuario)
                .HasConstraintName("comentario_idusuario_fkey");
        });

        modelBuilder.Entity<Curso>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("curso_pkey");

            entity.ToTable("curso", "learnexpress");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Descricao).HasColumnName("descricao");
            entity.Property(e => e.HorasTotais).HasColumnName("horas_totais");
            entity.Property(e => e.Preco).HasColumnName("preco");
            entity.Property(e => e.Professor)
                .HasMaxLength(50)
                .HasColumnName("professor");
            entity.Property(e => e.Titulo)
                .HasMaxLength(50)
                .HasColumnName("titulo");
        });

        modelBuilder.Entity<MaterialComplementar>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("material_complementar_pkey");

            entity.ToTable("material_complementar", "learnexpress");

            entity.HasIndex(e => e.Link, "material_complementar_link_key").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Descricao).HasColumnName("descricao");
            entity.Property(e => e.Idaula).HasColumnName("idaula");
            entity.Property(e => e.Link)
                .HasMaxLength(100)
                .HasColumnName("link");
            entity.Property(e => e.Tipo)
                .HasMaxLength(50)
                .HasColumnName("tipo");

            entity.HasOne(d => d.IdaulaNavigation).WithMany(p => p.MaterialComplementars)
                .HasForeignKey(d => d.Idaula)
                .HasConstraintName("material_complementar_idaula_fkey");
        });

        modelBuilder.Entity<NotaMaterialComplementar>(entity =>
        {
            entity.HasKey(e => new { e.Idmaterial, e.Idusuario }).HasName("nota_material_complementar_pkey");

            entity.ToTable("nota_material_complementar", "learnexpress");

            entity.Property(e => e.Idmaterial).HasColumnName("idmaterial");
            entity.Property(e => e.Idusuario).HasColumnName("idusuario");
            entity.Property(e => e.Nota).HasColumnName("nota");

            entity.HasOne(d => d.IdmaterialNavigation).WithMany(p => p.NotaMaterialComplementars)
                .HasForeignKey(d => d.Idmaterial)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("nota_material_complementar_idmaterial_fkey");

            entity.HasOne(d => d.IdusuarioNavigation).WithMany(p => p.NotaMaterialComplementars)
                .HasForeignKey(d => d.Idusuario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("nota_material_complementar_idusuario_fkey");
        });

        modelBuilder.Entity<Pedido>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("pedido_pkey");

            entity.ToTable("pedido", "learnexpress");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Data).HasColumnName("data");
            entity.Property(e => e.Idcurso).HasColumnName("idcurso");
            entity.Property(e => e.Idusuario).HasColumnName("idusuario");

            entity.HasOne(d => d.IdcursoNavigation).WithMany(p => p.Pedidos)
                .HasForeignKey(d => d.Idcurso)
                .HasConstraintName("pedido_idcurso_fkey");

            entity.HasOne(d => d.IdusuarioNavigation).WithMany(p => p.Pedidos)
                .HasForeignKey(d => d.Idusuario)
                .HasConstraintName("pedido_idusuario_fkey");
        });

        modelBuilder.Entity<PorcentConcluCurso>(entity =>
        {
            entity.HasKey(e => new { e.Idcurso, e.Idusuario }).HasName("porcent_conclu_curso_pkey");

            entity.ToTable("porcent_conclu_curso", "learnexpress");

            entity.Property(e => e.Idcurso).HasColumnName("idcurso");
            entity.Property(e => e.Idusuario).HasColumnName("idusuario");
            entity.Property(e => e.Porcentagem).HasColumnName("porcentagem");

            entity.HasOne(d => d.IdcursoNavigation).WithMany(p => p.PorcentConcluCursos)
                .HasForeignKey(d => d.Idcurso)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("porcent_conclu_curso_idcurso_fkey");

            entity.HasOne(d => d.IdusuarioNavigation).WithMany(p => p.PorcentConcluCursos)
                .HasForeignKey(d => d.Idusuario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("porcent_conclu_curso_idusuario_fkey");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("usuario_pkey");

            entity.ToTable("usuario", "learnexpress");

            entity.HasIndex(e => e.Email, "usuario_email_key").IsUnique();

            entity.HasIndex(e => e.Senha, "usuario_senha_key").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .HasColumnName("email");
            entity.Property(e => e.Nome)
                .HasMaxLength(50)
                .HasColumnName("nome");
            entity.Property(e => e.Senha)
                .HasMaxLength(20)
                .HasColumnName("senha");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
