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

    public virtual DbSet<Avaliacao> Avaliacaos { get; set; }

    public virtual DbSet<Endereco> Enderecos { get; set; }

    public virtual DbSet<Filtro> Filtros { get; set; }

    public virtual DbSet<Locai> Locais { get; set; }

    public virtual DbSet<Post> Posts { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Name=ConnectionStrings:ConexaoPadrao");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Avaliacao>(entity =>
        {
            entity.HasKey(e => e.ID_Avaliacao).HasName("PK__Avaliaca__E8926B16EF216AB6");

            entity.ToTable("Avaliacao");

            entity.Property(e => e.ID_Avaliacao).ValueGeneratedNever();
            entity.Property(e => e.Comentario)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.DataAvaliacao)
                .HasPrecision(0)
                .HasDefaultValueSql("(dateadd(hour,(-3),sysutcdatetime()))");
            entity.Property(e => e.Nota).HasColumnType("decimal(3, 2)");

            entity.HasOne(d => d.ID_PostNavigation).WithMany(p => p.Avaliacaos)
                .HasForeignKey(d => d.ID_Post)
                .HasConstraintName("FK__Avaliacao__ID_Po__60A75C0F");

            entity.HasOne(d => d.ID_UsuarioNavigation).WithMany(p => p.Avaliacaos)
                .HasForeignKey(d => d.ID_Usuario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Avaliacao__Comen__59063A47");
        });

        modelBuilder.Entity<Endereco>(entity =>
        {
            entity.HasKey(e => e.ID_Endereco).HasName("PK__Endereco__FDCCCFA616F12834");

            entity.ToTable("Endereco");

            entity.Property(e => e.ID_Endereco).ValueGeneratedNever();
            entity.Property(e => e.Bairro)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.CEP)
                .HasMaxLength(10)
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
            entity.HasKey(e => e.ID_Filtro).HasName("PK__Filtro__931D1A29229F3680");

            entity.ToTable("Filtro");

            entity.HasIndex(e => e.Nome, "UQ__Filtro__7D8FE3B21225AB22").IsUnique();

            entity.Property(e => e.ID_Filtro).ValueGeneratedNever();
            entity.Property(e => e.Nome)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Locai>(entity =>
        {
            entity.HasKey(e => e.ID_Locais).HasName("PK__Locais__458CCA647161D385");

            entity.Property(e => e.ID_Locais).ValueGeneratedNever();

            entity.HasOne(d => d.ID_EnderecoNavigation).WithMany(p => p.Locais)
                .HasForeignKey(d => d.ID_Endereco)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Locais__ID_Ender__5441852A");

            entity.HasOne(d => d.ID_FiltroNavigation).WithMany(p => p.Locais)
                .HasForeignKey(d => d.ID_Filtro)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Locais__ID_Filtr__534D60F1");
        });

        modelBuilder.Entity<Post>(entity =>
        {
            entity.HasKey(e => e.ID_Post).HasName("PK__Post__B41D0E30F8647C25");

            entity.ToTable("Post");

            entity.HasIndex(e => e.ID_Avaliacao, "UQ__Post__E8926B178635791F").IsUnique();

            entity.Property(e => e.ID_Post).ValueGeneratedNever();
            entity.Property(e => e.DataPostagem)
                .HasPrecision(0)
                .HasDefaultValueSql("(dateadd(hour,(-3),sysutcdatetime()))");

            entity.HasOne(d => d.ID_AvaliacaoNavigation).WithOne(p => p.Post)
                .HasForeignKey<Post>(d => d.ID_Avaliacao)
                .HasConstraintName("FK__Post__ID_Avaliac__5EBF139D");

            entity.HasOne(d => d.ID_LocalNavigation).WithMany(p => p.Posts)
                .HasForeignKey(d => d.ID_Local)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Post__ID_Local__5FB337D6");

            entity.HasOne(d => d.ID_UserNavigation).WithMany(p => p.Posts)
                .HasForeignKey(d => d.ID_User)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Post__ID_User__5DCAEF64");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.IdUsuario).HasName("PK__Usuario__5B65BF97DA584ADF");

            entity.ToTable("Usuario");

            entity.HasIndex(e => e.Email, "UQ__Usuario__A9D10534F2E89FDC").IsUnique();

            entity.Property(e => e.CriadoEm)
                .HasPrecision(0)
                .HasDefaultValueSql("(dateadd(hour,(-3),sysutcdatetime()))");
            entity.Property(e => e.Email).HasMaxLength(150);
            entity.Property(e => e.NomeCompleto).HasMaxLength(200);
            entity.Property(e => e.NomeUsuario).HasMaxLength(80);
            entity.Property(e => e.Senha).HasMaxLength(32);

            entity.HasMany(d => d.ID_Locals).WithMany(p => p.ID_Users)
                .UsingEntity<Dictionary<string, object>>(
                    "Destino",
                    r => r.HasOne<Locai>().WithMany()
                        .HasForeignKey("ID_Local")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__Destino__ID_Loca__6477ECF3"),
                    l => l.HasOne<Usuario>().WithMany()
                        .HasForeignKey("ID_User")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__Destino__ID_User__6383C8BA"),
                    j =>
                    {
                        j.HasKey("ID_User", "ID_Local").HasName("PK__Destino__2EAEAF6B36F3E2A7");
                        j.ToTable("Destino");
                    });

            entity.HasMany(d => d.ID_Posts).WithMany(p => p.ID_Users)
                .UsingEntity<Dictionary<string, object>>(
                    "Favorito",
                    r => r.HasOne<Post>().WithMany()
                        .HasForeignKey("ID_Post")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__Favorito__ID_Pos__68487DD7"),
                    l => l.HasOne<Usuario>().WithMany()
                        .HasForeignKey("ID_User")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__Favorito__ID_Use__6754599E"),
                    j =>
                    {
                        j.HasKey("ID_User", "ID_Post").HasName("PK__Favorito__F60C34A1195C82F2");
                        j.ToTable("Favorito");
                    });
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
