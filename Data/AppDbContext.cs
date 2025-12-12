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

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Name=ConnectionStrings:ConexaoPadrao");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Comentario>(entity =>
        {
            entity.HasKey(e => e.ID_Comentario).HasName("PK__Comentar__E9AA997398914C49");

            entity.ToTable("Comentario");

            entity.Property(e => e.DataComentario).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.Texto).HasMaxLength(500);

            entity.HasOne(d => d.ID_PostNavigation).WithMany(p => p.Comentarios)
                .HasForeignKey(d => d.ID_Post)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Comentari__ID_Po__4D94879B");

            entity.HasOne(d => d.ID_UserNavigation).WithMany(p => p.Comentarios)
                .HasForeignKey(d => d.ID_User)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Comentari__ID_Us__4E88ABD4");
        });

        modelBuilder.Entity<Destino>(entity =>
        {
            entity.HasKey(e => e.ID_Destino).HasName("PK__Destino__A7BDD3CECBFF9FA4");

            entity.ToTable("Destino");

            entity.HasOne(d => d.ID_PostNavigation).WithMany(p => p.Destinos)
                .HasForeignKey(d => d.ID_Post)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Destino__ID_Post__4CA06362");

            entity.HasOne(d => d.ID_UserNavigation).WithMany(p => p.Destinos)
                .HasForeignKey(d => d.ID_User)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Destino__ID_User__4BAC3F29");
        });

        modelBuilder.Entity<Favorito>(entity =>
        {
            entity.HasKey(e => e.ID_Favorito).HasName("PK__Favorito__FA228CC5EDC0210C");

            entity.ToTable("Favorito");

            entity.HasOne(d => d.ID_PostNavigation).WithMany(p => p.Favoritos)
                .HasForeignKey(d => d.ID_Post)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Favorito__ID_Pos__4AB81AF0");

            entity.HasOne(d => d.ID_UserNavigation).WithMany(p => p.Favoritos)
                .HasForeignKey(d => d.ID_User)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Favorito__ID_Use__49C3F6B7");
        });

        modelBuilder.Entity<Filtro>(entity =>
        {
            entity.HasKey(e => e.ID_Filtro).HasName("PK__Filtro__931D1A29806E6D1F");

            entity.ToTable("Filtro");

            entity.Property(e => e.Nome).HasMaxLength(120);

            entity.HasMany(d => d.ID_Locals).WithMany(p => p.ID_Filtros)
                .UsingEntity<Dictionary<string, object>>(
                    "Local_Filtro",
                    r => r.HasOne<Local>().WithMany()
                        .HasForeignKey("ID_Local")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__Local_Fil__ID_Lo__48CFD27E"),
                    l => l.HasOne<Filtro>().WithMany()
                        .HasForeignKey("ID_Filtro")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__Local_Fil__ID_Fi__47DBAE45"),
                    j =>
                    {
                        j.HasKey("ID_Filtro", "ID_Local").HasName("PK__Local_Fi__50FE51005FB744F3");
                        j.ToTable("Local_Filtro");
                    });
        });

        modelBuilder.Entity<Local>(entity =>
        {
            entity.HasKey(e => e.ID_Local).HasName("PK__Local__3E34B29D0F5FB31F");

            entity.ToTable("Local");

            entity.Property(e => e.Endereco).HasMaxLength(500);
            entity.Property(e => e.ID_NomeLocal).HasMaxLength(200);
        });

        modelBuilder.Entity<Post>(entity =>
        {
            entity.HasKey(e => e.ID_Post).HasName("PK__Post__B41D0E30AA92C6D5");

            entity.ToTable("Post");

            entity.Property(e => e.DataPost).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.Imagem).IsUnicode(false);
            entity.Property(e => e.Legenda).HasMaxLength(500);

            entity.HasOne(d => d.ID_FavoritoNavigation).WithMany(p => p.Posts)
                .HasForeignKey(d => d.ID_Favorito)
                .HasConstraintName("FK__Post__ID_Favorit__5165187F");

            entity.HasOne(d => d.ID_LocalNavigation).WithMany(p => p.Posts)
                .HasForeignKey(d => d.ID_Local)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Post__ID_Local__5070F446");

            entity.HasOne(d => d.ID_UserNavigation).WithMany(p => p.Posts)
                .HasForeignKey(d => d.ID_User)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Post__ID_User__4F7CD00D");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.ID_User).HasName("PK__Usuario__ED4DE44282CFE77E");

            entity.ToTable("Usuario");

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

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
