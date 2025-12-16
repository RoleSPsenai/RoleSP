using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using RoleSP.Models;

namespace RoleSP.Data;

public partial class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Endereco> Enderecos { get; set; }

    public virtual DbSet<Filtro> Filtros { get; set; }

    public virtual DbSet<Locai> Locais { get; set; }

    public virtual DbSet<Post> Posts { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Endereco>(entity =>
        {
            entity.HasKey(e => e.IdEndereco).HasName("PK__Endereco__0B7C7F1731DE3CF0");
        });

        modelBuilder.Entity<Filtro>(entity =>
        {
            entity.HasKey(e => e.IdFiltro).HasName("PK__Filtro__0772E7B28E97C55D");
        });

        modelBuilder.Entity<Locai>(entity =>
        {
            entity.HasKey(e => e.IdLocais).HasName("PK__Locais__7DE164768E4D6C7A");

            entity.HasOne(d => d.IdEnderecoNavigation).WithMany(p => p.Locais)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("IdEnderecoFk");

            entity.HasOne(d => d.IdFiltroNavigation).WithMany(p => p.Locais)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("IdFiltroFk");
        });

        modelBuilder.Entity<Post>(entity =>
        {
            entity.HasKey(e => e.IdPost).HasName("PK__Post__F8DCBD4D7FB9F824");

            entity.Property(e => e.CriadoEm).HasDefaultValueSql("(dateadd(hour,(-3),sysutcdatetime()))");

            entity.HasOne(d => d.IdLocaisNavigation).WithMany(p => p.Posts)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("IdLocaisFk");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.Posts)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("IdUsuarioFkPost");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.IdUsuario).HasName("PK__Usuario__5B65BF97670C9090");

            entity.Property(e => e.CriadoEm).HasDefaultValueSql("(dateadd(hour,(-3),sysutcdatetime()))");

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
