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
            entity.HasKey(e => e.ID_Comentario).HasName("PK__Comentar__E9AA9973DB539290");

            entity.ToTable("Comentario");

            entity.Property(e => e.DataComentario).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.Texto).HasMaxLength(500);

            entity.HasOne(d => d.ID_PostNavigation).WithMany(p => p.Comentarios)
                .HasForeignKey(d => d.ID_Post)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Comentari__ID_Po__6477ECF3");

            entity.HasOne(d => d.ID_UserNavigation).WithMany(p => p.Comentarios)
                .HasForeignKey(d => d.ID_User)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Comentari__ID_Us__656C112C");
        });

        modelBuilder.Entity<Destino>(entity =>
        {
            entity.HasKey(e => e.ID_Destino).HasName("PK__Destino__A7BDD3CEC502C0DF");

            entity.ToTable("Destino");

            entity.HasOne(d => d.ID_PostNavigation).WithMany(p => p.Destinos)
                .HasForeignKey(d => d.ID_Post)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Destino__ID_Post__6383C8BA");

            entity.HasOne(d => d.ID_UserNavigation).WithMany(p => p.Destinos)
                .HasForeignKey(d => d.ID_User)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Destino__ID_User__628FA481");
        });

        modelBuilder.Entity<Favorito>(entity =>
        {
            entity.HasKey(e => e.ID_Favorito).HasName("PK__Favorito__FA228CC5B73A4A19");

            entity.ToTable("Favorito");

            entity.HasOne(d => d.ID_PostNavigation).WithMany(p => p.Favoritos)
                .HasForeignKey(d => d.ID_Post)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Favorito__ID_Pos__619B8048");

            entity.HasOne(d => d.ID_UserNavigation).WithMany(p => p.Favoritos)
                .HasForeignKey(d => d.ID_User)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Favorito__ID_Use__60A75C0F");
        });

        modelBuilder.Entity<Filtro>(entity =>
        {
            entity.HasKey(e => e.ID_Filtro).HasName("PK__Filtro__931D1A2995200EBE");

            entity.ToTable("Filtro");

            entity.Property(e => e.Nome).HasMaxLength(120);

            entity.HasMany(d => d.ID_Locals).WithMany(p => p.ID_Filtros)
                .UsingEntity<Dictionary<string, object>>(
                    "Local_Filtro",
                    r => r.HasOne<Local>().WithMany()
                        .HasForeignKey("ID_Local")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__Local_Fil__ID_Lo__5DCAEF64"),
                    l => l.HasOne<Filtro>().WithMany()
                        .HasForeignKey("ID_Filtro")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__Local_Fil__ID_Fi__5CD6CB2B"),
                    j =>
                    {
                        j.HasKey("ID_Filtro", "ID_Local").HasName("PK__Local_Fi__50FE51009816BC8E");
                        j.ToTable("Local_Filtro");
                    });
        });

        modelBuilder.Entity<Local>(entity =>
        {
            entity.HasKey(e => e.ID_Local).HasName("PK__Local__3E34B29D70974B92");

            entity.ToTable("Local");

            entity.Property(e => e.Endereco).HasMaxLength(500);
            entity.Property(e => e.ID_NomeLocal).HasMaxLength(200);

            entity.HasOne(d => d.ID_ZonaNavigation).WithMany(p => p.Locals)
                .HasForeignKey(d => d.ID_Zona)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Local__ID_Zona__5535A963");
        });

        modelBuilder.Entity<Post>(entity =>
        {
            entity.HasKey(e => e.ID_Post).HasName("PK__Post__B41D0E307ACB928E");

            entity.ToTable("Post");

            entity.Property(e => e.DataPost).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.Imagem)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Legenda).HasMaxLength(500);

            entity.HasOne(d => d.ID_FavoritoNavigation).WithMany(p => p.Posts)
                .HasForeignKey(d => d.ID_Favorito)
                .HasConstraintName("FK__Post__ID_Favorit__68487DD7");

            entity.HasOne(d => d.ID_LocalNavigation).WithMany(p => p.Posts)
                .HasForeignKey(d => d.ID_Local)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Post__ID_Local__6754599E");

            entity.HasOne(d => d.ID_UserNavigation).WithMany(p => p.Posts)
                .HasForeignKey(d => d.ID_User)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Post__ID_User__66603565");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.ID_User).HasName("PK__Usuario__ED4DE44254E3FE3A");

            entity.ToTable("Usuario");

            entity.Property(e => e.Apelido).HasMaxLength(120);
            entity.Property(e => e.DataCriacao)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Email)
                .HasMaxLength(120)
                .IsUnicode(false);
            entity.Property(e => e.ImagemPerfil)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Nome).HasMaxLength(120);
            entity.Property(e => e.SenhaHash).HasMaxLength(32);

            entity.HasOne(d => d.ID_DestinoNavigation).WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.ID_Destino)
                .HasConstraintName("FK_Usuario_Destino");

            entity.HasOne(d => d.ID_FavoritoNavigation).WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.ID_Favorito)
                .HasConstraintName("FK_Usuario_Favorito");
        });

        modelBuilder.Entity<Zona>(entity =>
        {
            entity.HasKey(e => e.ID_Zona).HasName("PK__Zona__813493234B83BF87");

            entity.ToTable("Zona");

            entity.Property(e => e.Nome).HasMaxLength(120);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
