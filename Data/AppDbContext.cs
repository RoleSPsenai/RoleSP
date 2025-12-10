using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using RoleSP.Models;

namespace RoleSP.Data;

public partial class AppDbContext : DbContext
{
    public AppDbContext()
    {
    }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Comentario> Comentarios { get; set; }

    public virtual DbSet<Destino> Destinos { get; set; }

    public virtual DbSet<Favorito> Favoritos { get; set; }

    public virtual DbSet<Filtro> Filtros { get; set; }

    public virtual DbSet<Local> Locals { get; set; }

    public virtual DbSet<Post> Posts { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    public virtual DbSet<Zona> Zonas { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Name=ConnectionStrings:ConexaoPadrao");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Comentario>(entity =>
        {
            entity.HasKey(e => e.ID_Comentario).HasName("PK__Comentar__E9AA9973D75F56F4");

            entity.ToTable("Comentario");

            entity.Property(e => e.DataComentario).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.Texto).HasMaxLength(500);

            entity.HasOne(d => d.ID_PostNavigation).WithMany(p => p.Comentarios)
                .HasForeignKey(d => d.ID_Post)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Comentari__ID_Po__5FB337D6");

            entity.HasOne(d => d.ID_UserNavigation).WithMany(p => p.Comentarios)
                .HasForeignKey(d => d.ID_User)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Comentari__ID_Us__60A75C0F");
        });

        modelBuilder.Entity<Destino>(entity =>
        {
            entity.HasKey(e => e.ID_Destino).HasName("PK__Destino__A7BDD3CE3F3F6D9C");

            entity.ToTable("Destino");

            entity.HasIndex(e => e.ID_Post, "IX_Destino_Post");

            entity.HasIndex(e => e.ID_User, "IX_Destino_User");

            entity.HasOne(d => d.ID_PostNavigation).WithMany(p => p.Destinos)
                .HasForeignKey(d => d.ID_Post)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Destino__ID_Post__5BE2A6F2");

            entity.HasOne(d => d.ID_UserNavigation).WithMany(p => p.Destinos)
                .HasForeignKey(d => d.ID_User)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Destino__ID_Post__5AEE82B9");
        });

        modelBuilder.Entity<Favorito>(entity =>
        {
            entity.HasKey(e => e.ID_Favorito).HasName("PK__Favorito__FA228CC5736A5403");

            entity.ToTable("Favorito");

            entity.HasOne(d => d.ID_PostNavigation).WithMany(p => p.Favoritos)
                .HasForeignKey(d => d.ID_Post)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Favorito__ID_Pos__5812160E");

            entity.HasOne(d => d.ID_UserNavigation).WithMany(p => p.Favoritos)
                .HasForeignKey(d => d.ID_User)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Favorito__ID_Use__571DF1D5");
        });

        modelBuilder.Entity<Filtro>(entity =>
        {
            entity.HasKey(e => e.ID_Filtro).HasName("PK__Filtro__931D1A292DA0D936");

            entity.ToTable("Filtro");

            entity.Property(e => e.Nome).HasMaxLength(120);

            entity.HasMany(d => d.ID_Locals).WithMany(p => p.ID_Filtros)
                .UsingEntity<Dictionary<string, object>>(
                    "Local_Filtro",
                    r => r.HasOne<Local>().WithMany()
                        .HasForeignKey("ID_Local")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__Local_Fil__ID_Lo__66603565"),
                    l => l.HasOne<Filtro>().WithMany()
                        .HasForeignKey("ID_Filtro")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__Local_Fil__ID_Fi__656C112C"),
                    j =>
                    {
                        j.HasKey("ID_Filtro", "ID_Local").HasName("PK__Local_Fi__50FE510068A137F2");
                        j.ToTable("Local_Filtro");
                    });
        });

        modelBuilder.Entity<Local>(entity =>
        {
            entity.HasKey(e => e.ID_Local).HasName("PK__Local__3E34B29D410A42EF");

            entity.ToTable("Local");

            entity.Property(e => e.Endereco).HasMaxLength(500);
            entity.Property(e => e.ID_NomeLocal).HasMaxLength(200);

            entity.HasOne(d => d.ID_ZonaNavigation).WithMany(p => p.Locals)
                .HasForeignKey(d => d.ID_Zona)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Local__ID_Zona__4F7CD00D");
        });

        modelBuilder.Entity<Post>(entity =>
        {
            entity.HasKey(e => e.ID_Post).HasName("PK__Post__B41D0E3003FE033C");

            entity.ToTable("Post");

            entity.HasIndex(e => e.ID_Local, "IX_Post_Local");

            entity.HasIndex(e => e.ID_User, "IX_Post_User");

            entity.Property(e => e.DataPost).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.Imagem)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Legenda).HasMaxLength(500);

            entity.HasOne(d => d.ID_LocalNavigation).WithMany(p => p.Posts)
                .HasForeignKey(d => d.ID_Local)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Post__ID_Local__5441852A");

            entity.HasOne(d => d.ID_UserNavigation).WithMany(p => p.Posts)
                .HasForeignKey(d => d.ID_User)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Post__ID_User__534D60F1");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.ID_User).HasName("PK__Usuario__ED4DE442FA282525");

            entity.ToTable("Usuario");

            entity.HasIndex(e => e.Email, "IX_Usuario_Email").IsUnique();

            entity.Property(e => e.Apelido).HasMaxLength(120);
            entity.Property(e => e.DataCriacao)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Email)
                .HasMaxLength(120)
                .IsUnicode(false);
            entity.Property(e => e.ImagemPerfil).IsUnicode(false);
            entity.Property(e => e.Nome).HasMaxLength(120);
            entity.Property(e => e.SenhaHash).HasMaxLength(32);
        });

        modelBuilder.Entity<Zona>(entity =>
        {
            entity.HasKey(e => e.ID_Zona).HasName("PK__Zona__813493232AA162A3");

            entity.ToTable("Zona");

            entity.Property(e => e.Nome).HasMaxLength(120);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
