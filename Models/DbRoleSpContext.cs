using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace RoleSP.Models;

public partial class DbRoleSpContext : DbContext
{
    public DbRoleSpContext()
    {
    }

    public DbRoleSpContext(DbContextOptions<DbRoleSpContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Endereco> Enderecos { get; set; }

    public virtual DbSet<Filtro> Filtros { get; set; }

    public virtual DbSet<Locai> Locais { get; set; }

    public virtual DbSet<Post> Posts { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Name=ConnectionStrings:ConexaoPadrao");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Endereco>(entity =>
        {
            entity.HasKey(e => e.IdEndereco).HasName("PK__Endereco__0B7C7F1731DE3CF0");

            entity.ToTable("Endereco");

            entity.Property(e => e.Bairro)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Cidade)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Rua)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Filtro>(entity =>
        {
            entity.HasKey(e => e.IdFiltro).HasName("PK__Filtro__0772E7B28E97C55D");

            entity.ToTable("Filtro");

            entity.Property(e => e.NomeFiltro).HasMaxLength(120);
        });

        modelBuilder.Entity<Locai>(entity =>
        {
            entity.HasKey(e => e.IdLocais).HasName("PK__Locais__7DE164768E4D6C7A");

            entity.Property(e => e.NomeLocal).HasMaxLength(120);

            entity.HasOne(d => d.IdEnderecoNavigation).WithMany(p => p.Locais)
                .HasForeignKey(d => d.IdEndereco)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("IdEnderecoFk");

            entity.HasOne(d => d.IdFiltroNavigation).WithMany(p => p.Locais)
                .HasForeignKey(d => d.IdFiltro)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("IdFiltroFk");
        });

        modelBuilder.Entity<Post>(entity =>
        {
            entity.HasKey(e => e.IdPost).HasName("PK__Post__F8DCBD4D7FB9F824");

            entity.ToTable("Post");

            entity.Property(e => e.Avaliacao).HasMaxLength(500);
            entity.Property(e => e.CriadoEm)
                .HasPrecision(0)
                .HasDefaultValueSql("(dateadd(hour,(-3),sysutcdatetime()))");

            entity.HasOne(d => d.IdLocaisNavigation).WithMany(p => p.Posts)
                .HasForeignKey(d => d.IdLocais)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("IdLocaisFk");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.Posts)
                .HasForeignKey(d => d.IdUsuario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("IdUsuarioFkPost");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.IdUsuario).HasName("PK__Usuario__5B65BF97670C9090");

            entity.ToTable("Usuario");

            entity.Property(e => e.Apelido).HasMaxLength(120);
            entity.Property(e => e.CriadoEm)
                .HasPrecision(0)
                .HasDefaultValueSql("(dateadd(hour,(-3),sysutcdatetime()))");
            entity.Property(e => e.Email).HasMaxLength(150);
            entity.Property(e => e.NomeUsuario).HasMaxLength(120);
            entity.Property(e => e.Senha).HasMaxLength(32);

            entity.HasMany(d => d.IdPosts).WithMany(p => p.IdUsuarios)
                .UsingEntity<Dictionary<string, object>>(
                    "Destino",
                    r => r.HasOne<Post>().WithMany()
                        .HasForeignKey("IdPost")
                        .HasConstraintName("IdPostFkDestino"),
                    l => l.HasOne<Usuario>().WithMany()
                        .HasForeignKey("IdUsuario")
                        .HasConstraintName("IdUsuarioFkDestino"),
                    j =>
                    {
                        j.HasKey("IdUsuario", "IdPost").HasName("PkDestino");
                        j.ToTable("Destino");
                    });

            entity.HasMany(d => d.IdPostsNavigation).WithMany(p => p.IdUsuariosNavigation)
                .UsingEntity<Dictionary<string, object>>(
                    "Favorito",
                    r => r.HasOne<Post>().WithMany()
                        .HasForeignKey("IdPost")
                        .HasConstraintName("IdPostFkFavorito"),
                    l => l.HasOne<Usuario>().WithMany()
                        .HasForeignKey("IdUsuario")
                        .HasConstraintName("IdUsuarioFkFavorito"),
                    j =>
                    {
                        j.HasKey("IdUsuario", "IdPost").HasName("PkFavorito");
                        j.ToTable("Favorito");
                    });
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
